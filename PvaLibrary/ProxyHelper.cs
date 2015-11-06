using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace PvaLibrary
{
    public class ProxyHelper
    {
        #region Proxy helper properties
        public event Action<bool> ChangeUseProxy;     
        public string Host { get; set; }
        public Queue<WebProxy> WebProxies { get; set; }
        public WebProxy CurrentWebProxy { get; set; }
        public Dictionary<WebProxy, NetworkCredential> ProxyUsers { get; set; } = new Dictionary<WebProxy, NetworkCredential>();
        public Dictionary<WebProxy, RegCount> ProxyRegCounts { get; set; } = new Dictionary<WebProxy, RegCount>();
        public List<RegCount> RegCounts { get; set; }
        public int AllowReg { get; set; }
        private int _preventDeadLock = 0;
        private bool _useProxy;
        public bool UseProxy
        {
            get { return _useProxy; }
            set
            {
                _useProxy = value;
                ChangeUseProxy?.Invoke(_useProxy);
            }
        }
        #endregion

        // <summary>
        // Initialize class for proxies
        // </summary>
        public ProxyHelper()
        {
            Host = ConfigurationManager.AppSettings[Const.HOST];
            UseProxy = bool.Parse(ConfigurationManager.AppSettings[Const.USEPROXY]);
            AllowReg = int.Parse(ConfigurationManager.AppSettings[Const.ALLOWREG]);
            ParseRegCounts(ConfigurationManager.AppSettings[Const.REGCOUNTS]);
            ParseProxies(ConfigurationManager.AppSettings[Const.PROXYSERVERS]);
        }

        public ProxyHelper(string host, bool useproxy, int allowreg, NameValueCollection parseRegCounts, NameValueCollection parseProxies)
        {

        }

        #region Work with proxies from application settings
        public void SaveCurrentProxyList()
        {
            var sb = new StringBuilder();
            foreach (var webProxy in WebProxies)
            {
                sb.Append(webProxy.Address.Host);
                sb.Append(":");
                sb.Append(webProxy.Address.Port);
                sb.Append(":");
                sb.Append(ProxyUsers[webProxy].UserName);
                sb.Append(":");
                sb.Append(ProxyUsers[webProxy].Password);
                sb.Append(";");
            }
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[Const.PROXYSERVERS].Value = sb.ToString();
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        public void SaveProxyRegList()
        {
            var sb = new StringBuilder();
            foreach (var rc in ProxyRegCounts.Values.Where(rc => rc != null))
            {
                sb.Append(rc.CountRegistrations);
                sb.Append("|");
                sb.Append(rc.RegDate.ToString(Const.DateFormat, CultureInfo.InvariantCulture));
                sb.Append("|");
                sb.Append(rc.Address);
                sb.Append(";");
            }
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[Const.REGCOUNTS].Value = sb.ToString();
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void ParseRegCounts(string str)
        {
            RegCounts = new List<RegCount>();
            if (str != null)
            {
                var list = str.Split(';');
                foreach (string s in list)
                {
                    var prox = s.Split('|');
                    if (prox.Length == 3)
                    {
                        var rc = new RegCount()
                        {
                            CountRegistrations = int.Parse(prox[0]),
                            RegDate = DateTime.ParseExact(prox[1], Const.DateFormat, CultureInfo.InvariantCulture),
                            Address = prox[2]
                        };
                        if (rc.RegDate.ToString(Const.DateFormat, CultureInfo.InvariantCulture) == DateTime.Now.ToString(Const.DateFormat, CultureInfo.InvariantCulture))
                            RegCounts.Add(rc);
                    }
                }
            }
        }
        private void ParseProxies(string str)
        {
            ProxyUsers = new Dictionary<WebProxy, NetworkCredential>();
            WebProxies = new Queue<WebProxy>();
            var list = str.Split(';');
            foreach (string s in list)
            {
                var prox = s.Split(':');
                if (prox.Length == 4)
                {
                    try
                    {
                        WebProxy proxy = new WebProxy(prox[0], int.Parse(prox[1]));
                        //Set credentials
                        var credentials = new NetworkCredential(prox[2], prox[3]);
                        proxy.Credentials = credentials;
                        ProxyUsers.Add(proxy, credentials);
                        //Set proxy
                        //WebProxy proxy = new WebProxy(proxyURI, true, null, credentials );
                        // WebProxy proxy = new WebProxy(prox[0], int.Parse(prox[1]));
                        WebProxies.Enqueue(proxy);
                        RegCount rcTofind = null;
                        foreach (var rc in RegCounts)
                        {
                            if (rc.Address == proxy.Address.ToString())
                            {
                                rcTofind = rc;
                                break;
                            }
                        }
                        ProxyRegCounts.Add(proxy, rcTofind);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex);
                    }
                }
            }
            if (WebProxies.Count > 0)
                CurrentWebProxy = WebProxies.Peek();
        }
        #endregion

        // <summary>
        // Public function to get next proxies in a list
        // </summary>
        public void SelectNextProxy()
        {

            var taskProxy = new Task(() =>
            {
                if (_preventDeadLock == WebProxies.Count + 1)
                {
                    Logger.Info("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Logger.Info("Закончились прокси сервера на сегодня. Каждый уже зарегил максимум человек.");
                    Logger.Info("Переключаюсь на основной адрес.");
                    Logger.Info("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    CurrentWebProxy = null;
                    UseProxy = false;
                    _preventDeadLock = 0;
                    return;
                }

                WebProxies.Enqueue(WebProxies.Dequeue());
                var webProxy = WebProxies.Peek();
                var rc = ProxyRegCounts[webProxy];
                if (rc == null || rc.CountRegistrations < AllowReg)
                {
                    CurrentWebProxy = webProxy;
                    Logger.Info("SetProxy " + CurrentWebProxy.Address.Host + " " + CurrentWebProxy.Address.Port);
                    SaveCurrentProxyList();
                    _preventDeadLock = 0;
                }
                else
                {
                    _preventDeadLock++;
                    SelectNextProxy();
                }
            }, CancellationToken.None, TaskCreationOptions.AttachedToParent);

            taskProxy.Start();
            taskProxy.Wait();

        }

        #region Get current and get current correct proxies
        public WebProxy GetCorrectCurrentWebProxy
        {
            get
            {
                if (CurrentWebProxy == null)
                    SelectNextProxy();
                if (CurrentWebProxy == null)
                    return null;
                if (ProxyRegCounts.ContainsKey(CurrentWebProxy))
                {
                    var rc = ProxyRegCounts[CurrentWebProxy];
                    if (rc != null && rc.CountRegistrations >= AllowReg)
                    {
                        SelectNextProxy();
                    }
                }
                return CurrentWebProxy;
            }
        }
        public string CurrentWebProxyRegCount
        {
            get
            {
                var rc = ProxyRegCounts[CurrentWebProxy];
                if (rc == null)
                    return DateToString(0);
                return DateToString(rc.CountRegistrations);
            }
        }
        private static string DateToString(int val)
        {
            return
                $"Количество регистраций на {DateTime.Now.ToString(Const.DateFormat, CultureInfo.InvariantCulture)} - {val.ToString()} ";
        }
        #endregion

        // <summary>
        // Check on limit of registration tries
        // </summary>
        public bool ChekOnLimitRegistraions
        {
            get
            {
                try
                {
                    var rc = ProxyRegCounts[CurrentWebProxy];
                    if (rc == null)
                    {
                        rc = new RegCount()
                        {
                            Address = CurrentWebProxy.Address.ToString(),
                            RegDate = DateTime.Now,
                            CountRegistrations = 1
                        };
                        ProxyRegCounts[CurrentWebProxy] = rc;
                        return false;
                    }
                    rc.CountRegistrations++;
                    return rc.CountRegistrations >= AllowReg;
                }
                finally
                {
                    SaveProxyRegList();
                }
            }
        }
    }
}
