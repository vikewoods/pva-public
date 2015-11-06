using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PvaLibrary;

namespace PvaCore.Vfs
{
    public class TaskTabs
    {

        private readonly WebBrowser _webBrowser;
        private readonly RichTextBox _richTextBox;
        private readonly Button _deleteButton;
        private readonly Button _renewButton;
        private readonly Button _restartButton;
        private DataTypes _currentTaskDataTypes;
        private bool _allowStep = true;
        private RotEvents _enum = RotEvents.Start;
        private readonly TabPage _tabPage;
        private int countIEErrors = 0;
        private int _countAttempt;
        private int _countOperation;
        private readonly DataTypesComparer _dataTypesComparer = new DataTypesComparer();
        private readonly ProxyHelper _proxyHelper = new ProxyHelper();

        public bool IsTabExists { get; set; }
        public List<DataTypes> TasksDataTypes = new List<DataTypes>();
        public delegate void GetNextProxyDelegate();
        public event GetNextProxyDelegate GetNextProxyEvent;


        // Initialize class
        public TaskTabs()
        {
        }

        public TaskTabs(DataTypes taskDataTypes, TabPage taskTabPage)
        {

        }
    }
}
