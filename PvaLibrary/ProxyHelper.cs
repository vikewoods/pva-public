using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;

namespace PvaLibrary
{
    public class ProxyHelper : IOleClientSite, IServiceProvider, IAuthenticate
    {
        #region Proxy def

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer,
            int lpdwBufferLength);

        private Guid IID_IAuthenticate = new Guid("79eac9d0-baf9-11ce-8c82-00aa004ba90b");
        private const int INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011);
        private const int S_OK = unchecked(0x00000000);
        private const int INTERNET_OPTION_PROXY = 38;
        private const int INTERNET_OPEN_TYPE_DIRECT = 1;
        private const int INTERNET_OPEN_TYPE_PROXY = 3;
        protected string CurrentUsername;
        protected string CurrentPassword;

        #endregion

        #region Proxy helper properties

        public event Action<bool> ChangeUseProxy;
        public string Host { get; set; }
        public Queue<WebProxy> WebProxies { get; set; }
        public WebProxy CurrentWebProxy { get; set; }

        public Dictionary<WebProxy, NetworkCredential> ProxyUsers { get; set; } =
            new Dictionary<WebProxy, NetworkCredential>();

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

        public ProxyHelper(string host, bool useproxy, int allowreg, NameValueCollection parseRegCounts,
            NameValueCollection parseProxies)
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
                        if (rc.RegDate.ToString(Const.DateFormat, CultureInfo.InvariantCulture) ==
                            DateTime.Now.ToString(Const.DateFormat, CultureInfo.InvariantCulture))
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

        #region Proxy

        public void SetProxyServer(string proxy)
        {
            //Create structure
            INTERNET_PROXY_INFO proxyInfo = new INTERNET_PROXY_INFO();

            if (proxy == null)
            {
                proxyInfo.dwAccessType = INTERNET_OPEN_TYPE_DIRECT;
            }
            else
            {
                var prx = proxy.Substring("http://".Length);
                proxyInfo.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
                proxyInfo.proxy = Marshal.StringToHGlobalAnsi(prx.Remove(prx.Length - 1));
                proxyInfo.proxyBypass = Marshal.StringToHGlobalAnsi("local");
            }

            // Allocate memory
            IntPtr proxyInfoPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(proxyInfo));

            // Convert structure to IntPtr
            Marshal.StructureToPtr(proxyInfo, proxyInfoPtr, true);
            bool returnValue = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY,
                proxyInfoPtr, Marshal.SizeOf(proxyInfo));
        }

        #region IOleClientSite Members

        public void SaveObject()
        {
            // TODO:  Add Form1.SaveObject implementation
        }

        public void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk)
        {
            // TODO:  Add Form1.GetMoniker implementation
        }

        public void GetContainer(object ppContainer)
        {
            ppContainer = this;
        }

        public void ShowObject()
        {
            // TODO:  Add Form1.ShowObject implementation
        }

        public void OnShowWindow(bool fShow)
        {
            // TODO:  Add Form1.OnShowWindow implementation
        }

        public void RequestNewObjectLayout()
        {
            // TODO:  Add Form1.RequestNewObjectLayout implementation
        }

        #endregion

        #region IServiceProvider Members

        public int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
        {
            int nRet = guidService.CompareTo(IID_IAuthenticate);
            if (nRet == 0)
            {
                nRet = riid.CompareTo(IID_IAuthenticate);
                if (nRet == 0)
                {
                    ppvObject = Marshal.GetComInterfaceForObject(this, typeof (IAuthenticate));
                    return S_OK;
                }
            }

            ppvObject = new IntPtr();
            return INET_E_DEFAULT_ACTION;
        }

        #endregion

        #region IAuthenticate Members

        public int Authenticate(ref IntPtr phwnd, ref IntPtr pszUsername, ref IntPtr pszPassword)
        {
            IntPtr sUser = Marshal.StringToCoTaskMemAuto(CurrentUsername);
            IntPtr sPassword = Marshal.StringToCoTaskMemAuto(CurrentPassword);

            pszUsername = sUser;
            pszPassword = sPassword;
            return S_OK;
        }

        #endregion
    }

    public struct INTERNET_PROXY_INFO
    {
        public int dwAccessType;
        public IntPtr proxy;
        public IntPtr proxyBypass;
    }

    #region COM Interfaces

    [ComImport, Guid("00000112-0000-0000-C000-000000000046"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleObject
    {
        void SetClientSite(IOleClientSite pClientSite);
        void GetClientSite(IOleClientSite ppClientSite);
        void SetHostNames(object szContainerApp, object szContainerObj);
        void Close(uint dwSaveOption);
        void SetMoniker(uint dwWhichMoniker, object pmk);
        void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk);

        void InitFromData(IDataObject pDataObject, bool
            fCreation, uint dwReserved);

        void GetClipboardData(uint dwReserved, IDataObject ppDataObject);

        void DoVerb(uint iVerb, uint lpmsg, object pActiveSite,
            uint lindex, uint hwndParent, uint lprcPosRect);

        void EnumVerbs(object ppEnumOleVerb);
        void Update();
        void IsUpToDate();
        void GetUserClassID(uint pClsid);
        void GetUserType(uint dwFormOfType, uint pszUserType);
        void SetExtent(uint dwDrawAspect, uint psizel);
        void GetExtent(uint dwDrawAspect, uint psizel);
        void Advise(object pAdvSink, uint pdwConnection);
        void Unadvise(uint dwConnection);
        void EnumAdvise(object ppenumAdvise);
        void GetMiscStatus(uint dwAspect, uint pdwStatus);
        void SetColorScheme(object pLogpal);
    }

    [ComImport, Guid("00000118-0000-0000-C000-000000000046"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleClientSite
    {
        void SaveObject();
        void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk);
        void GetContainer(object ppContainer);
        void ShowObject();
        void OnShowWindow(bool fShow);
        void RequestNewObjectLayout();
    }

    [ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
     ComVisible(false)]
    public interface IServiceProvider
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryService(ref Guid guidService, ref Guid riid, out IntPtr ppvObject);
    }

    [ComImport, Guid("79EAC9D0-BAF9-11CE-8C82-00AA004BA90B"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
     ComVisible(false)]
    public interface IAuthenticate
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Authenticate(ref IntPtr phwnd, ref IntPtr pszUsername, ref IntPtr pszPassword);
    }

    #endregion

    #endregion
}

