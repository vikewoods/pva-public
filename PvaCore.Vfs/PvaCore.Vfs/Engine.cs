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
        private BindingList<VisaTask> _visaTasks;
        private Dictionary<string, VisaTabs> _cityTasks;
        private bool _isMainThread = false;
        private TabControl _tabControl;
        private Timer _timer;

        private static Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        public Engine(BindingList<VisaTask> visaTasks, TabControl tabControl, bool isMainThread)
        {
            _isMainThread = isMainThread;
            _tabControl = tabControl;

            _visaTasks = visaTasks;
            _cityTasks = new Dictionary<string, VisaTabs>();

            _timer = new Timer {Interval = 1500};
            _timer.Tick += TimerOnTick;
        }

        
        public void RefreshViewTab()
        {
            var dtT = new VisaTask
            {
                City = "Львов",
                CityCode = "1"
            };
            _visaTasks = new BindingList<VisaTask> {dtT};

            foreach (var dt in _visaTasks)
            {
                if (!_cityTasks.ContainsKey(dt.CityV))
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
                        Name = "logTxtBox" + dt.CityCode
                    };
                    tabPage.Controls.Add(logTxtBox);

                    SetTabHeader(tabPage, Color.Chartreuse);
                    _tabControl.TabPages.Add(tabPage);

                    VisaTabs visaTab = new VisaTabs(dt, tabPage);
                    _cityTasks.Add(dt.CityV, visaTab);
                }
                else
                {
                    return;
                }
            }

            foreach (KeyValuePair<string, VisaTabs> pair in _cityTasks)
            {
                
            }
        }

        // UI Misc. functions
        private void SetTabHeader(TabPage page, Color color)
        {
            TabColors[page] = color;
            _tabControl.Invalidate();
        }

        // Events section
        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
