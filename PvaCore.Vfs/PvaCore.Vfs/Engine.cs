using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PvaCore.Vfs
{
    public class Engine
    {
        private BindingList<DataTypes> _dataTypeses;
        private Dictionary<string, TaskTabs> _tabTasks;
        //private Dictionary<string, VisaTab> _cityTasks;
        private bool _isMainThread = false;
        private TabControl _tabControl;
        private Timer _timer;

        public static Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        public Engine(BindingList<DataTypes> dataTypeses, TabControl tabControl, bool isMainThread)
        {
            _isMainThread = isMainThread;
            _tabControl = tabControl;
            _dataTypeses = dataTypeses;
            _tabTasks = new Dictionary<string, TaskTabs>();

            _timer = new Timer {Interval = 1500};
            _timer.Tick += TimerOnTick;
        }

        private void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            _tabControl.Invalidate();
        }
        public void RefreshViewTab()
        {
            var dtT = new DataTypes
            {
                City = "Львов",
                CityCode = "1"
            };
            _dataTypeses = new BindingList<DataTypes> {dtT};

            foreach (var dt in _dataTypeses)
            {
                if (!_tabTasks.ContainsKey(dt.CityV))
                {
                    // Create UI tab first
                    var tabPage = new TabPage(dt.CityV) {Name = dt.CityV};

                    // Create webbrowser UI
                    var webBrowser = new WebBrowser
                    {
                        Location = new Point(0, 0),
                        Size = new Size(1000, 460),
                        Dock = DockStyle.Top,
                        Name = "webBrowser" + dt.City,
                        Url = new Uri("http://google.com")
                    };
                    tabPage.Controls.Add(webBrowser);

                    var logTxtBox = new RichTextBox
                    {
                        Location = new Point(0, 0),
                        Size = new Size(1000, 130),
                        Dock = DockStyle.Bottom,
                        Name = "logTxtBox"
                    };
                    tabPage.Controls.Add(logTxtBox);

                    SetTabHeader(tabPage, Color.Chartreuse);
                    _tabControl.TabPages.Add(tabPage);

                    //DataTypes visaTab = new DataTypes(dt, tabPage);
                }
                else
                {
                    return;
                }
            }

            foreach (KeyValuePair<string, TaskTabs> pair in _tabTasks)
            {
                
            }
        }


        // Events section
        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
