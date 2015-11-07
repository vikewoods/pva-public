using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PvaLibrary;

namespace PvaCore.Vfs
{
    public class VisaTabs : ProxyHelper
    {

        //private string CurrentUsername;
       // private string CurrentPassword;
        private readonly WebBrowser _webBrowser;
        private readonly RichTextBox _richTextBox;
        private readonly Button _deleteButton;
        private readonly Button _renewButton;
        private readonly Button _restartButton;
        private VisaTask _currentTaskVisaTask;
        private bool _allowStep = true;
        private RotEvents _enum = RotEvents.Start;
        private VisaTask _currentTask;
        public List<VisaTask> Tasks = new List<VisaTask>();
        private readonly TabPage _tabPage;
        private int countIEErrors = 0;
        private int _countAttempt;
        private int _countOperation;
        private readonly VisaTaskComparer _visaTaskComparer = new VisaTaskComparer();
        private readonly ProxyHelper _proxyHelper = new ProxyHelper();

        public bool IsTabExists { get; set; }
        public List<VisaTask> TasksDataTypes = new List<VisaTask>();

        public delegate void TaskDelegate(VisaTask task);
        public event TaskDelegate TaskEvent;

        public delegate void TabDelegate(TabPage tab);
        public event TabDelegate TabEvent;

        public delegate void TabDelegateMain(VisaTabs visa, bool add);
        public event TabDelegateMain VisaEvent;

        public delegate void TabDelegateEx(TabPage tab, bool alarm);
        public event TabDelegateEx TabEventEx;

        public delegate void GetNextProxyDelegate();
        public event GetNextProxyDelegate GetNextProxyEvent;


        // Initialize class
        public VisaTabs()
        {
        }

        public VisaTabs(VisaTask visaTask, TabPage taskTabPage)
        {
            // Add curent task
            Tasks.Add(visaTask);

            // Initialize  tabs
            _tabPage = taskTabPage;

            // Finding controls
            _webBrowser = (WebBrowser) _tabPage.Controls.Find("webBrowser" + visaTask.City, true)[0];
            // Enable js
            _webBrowser.ScriptErrorsSuppressed = true;
            // Browser events
            _webBrowser.DocumentCompleted += WebBrowserOnDocumentCompleted;
            _webBrowser.DocumentTitleChanged += WebBrowserOnDocumentTitleChanged;
            _webBrowser.NewWindow += WebBrowserOnNewWindow;
            _webBrowser.Navigated += WebBrowserOnNavigated;

            _richTextBox = (RichTextBox) _tabPage.Controls.Find("logTxtBox" + visaTask.CityCode, true)[0];
            _richTextBox.ReadOnly = true;

            _proxyHelper.UseProxy = true;
            SetProxyHelper();
        }

        // Events section
        private void WebBrowserOnNavigated(object sender, WebBrowserNavigatedEventArgs webBrowserNavigatedEventArgs)
        {
            throw new NotImplementedException();
        }

        private void WebBrowserOnNewWindow(object sender, CancelEventArgs cancelEventArgs)
        {
            throw new NotImplementedException();
        }

        private void WebBrowserOnDocumentTitleChanged(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        private void WebBrowserOnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs webBrowserDocumentCompletedEventArgs)
        {
            _allowStep = true;
        }

        // Misc functions section
        private void SetProxyHelper()
        {
            if(!_proxyHelper.UseProxy)
                return;

            var curProxy = _proxyHelper.GetCorrectCurrentWebProxy;
            if (curProxy != null)
            {
                var obj = _webBrowser.ActiveXInstance;
                var oc = obj as IOleObject;
                oc?.SetClientSite(this);

                CurrentUsername = _proxyHelper.ProxyUsers[curProxy].UserName;
                CurrentPassword = _proxyHelper.ProxyUsers[curProxy].Password;
                _proxyHelper.SetProxyServer(curProxy.Address.ToString());

                _webBrowser.Navigate("http://2ip.ru");
                Application.DoEvents();
            }
        }



        #region Tricks section
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
            string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private void ClickOKButton()
        {
            IntPtr hwnd = FindWindow("#32770", "Message from webpage");
            hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "OK");
            uint message = 0xf5;
            SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
        }
        #endregion
    }
}
