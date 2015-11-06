using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PvaLibrary;

namespace PvaCore.Vfs
{
    public partial class PvaMainWindow : Form
    {
        private static string _userEmailDomain = "vedev.in.ua";
        private BindingList<DataTypes> _dataTypeses;
        private Engine _engine;

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        // Base initialize
        public PvaMainWindow()
        {
            InitializeComponent();
            Text = $"{Text} / Main thread /";
        }
        public PvaMainWindow(string city, bool isMain = false)
        {
            InitializeComponent();
            Text = $"{Text} / {city}";
        }

        // Initialize Main UI Components
        private void PvaMainWindow_Load(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                PvaMainUiAutoLoad(sender, e);
            }
            else
            {
                MessageBox.Show(
                    "No internet connection. This version of application require strong internet connection! Please try again or check your connection",
                    "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void PvaMainUiAutoLoad(object autoLoadSender, EventArgs autoLoadEventArgs)
        {
            // Initialize header
            UpdateHeaderStrip();

            // Initialize first tab Add people
            cityList.DataSource = Const.GetListFromDict(Const.SettingsCities);
            purposeList.DataSource = Const.GetListFromDict(Const.FillPurpose());
            categoryList.DataSource = Const.GetListFromDict(Const.GetCategoryType());
            statusList.DataSource = Const.GetListFromDict(Const.FillStatus());
            natList.DataSource = Const.GetListFromDict(Const.FillNations());
            priorityList.DataSource = Const.GetListPriority();
            natList.SelectedItem = "UKRAINE";
            statusList.SelectedItem = "Mr.";
            receptionCode.Text = "0000/0000/0000";
            adultNum.Text = "1";

            try
            {
                if (!vpaPolandDbDataSet.IsInitialized || !vpaPolandDbDataSet.Peoples.IsInitialized) return;
                // Initialize second tab DB peoples
                peoplesTableAdapter.Fill(vpaPolandDbDataSet.Peoples);
                UpdateStatusStrip("SQL DB Connection established!", Color.Green, true);
            }
            catch (SqlException sqlException)
            {
                MessageBox.Show(sqlException.Message, "SQL Connection error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                UpdateStatusStrip("SQL Connection error! Cannot establish connection...", Color.Red, true);
            }

            // Temp func
            clsUserBtn.Enabled = false;

            // Start engine
            _engine = new Engine(_dataTypeses, tabControl1, false);
            _engine.RefreshViewTab();
        }

        

        // Misc. function UI
        private void UpdateStatusStrip(string statusMessage, Color statusColor, bool statusIsNew)
        {
            if (statusIsNew)
            {
                toolStripStatusLabel2.ForeColor = statusColor;
                toolStripStatusLabel2.Text = statusMessage;
            }
            else
            {
                toolStripStatusLabel2.ForeColor = Color.Red;
                toolStripStatusLabel2.Text = "Something went wrong! Please check log for errors!";
            }
        }
        private void UpdateHeaderStrip()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fvi.FileVersion;
            Text += " Version of app: " + version;
        }

        // Menu strip UI
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.AllowQuit)
                Application.Exit();
        }

        // Misc. function NOT UI
        private static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        private string _generateuserEmail(string fname, string lname, string domain)
        {
            return $"{fname.ToLower()+lname.ToLower()}@{domain}";
        }
        private string _generateUserPassword(int lenght)
        {
            return Guid.NewGuid().ToString().Replace("-", "").Remove(lenght);
        }


        // User btn functions UI
        private void addUserBtn_Click(object sender, EventArgs e)
        {
            if (firstNameTxtBox.Text.Length > 0 && lastNameTxtBox.Text.Length > 0)
            {
                userEmailTxt.Text = _generateuserEmail(firstNameTxtBox.Text, lastNameTxtBox.Text, _userEmailDomain);
                userPassTxt.Text = _generateUserPassword(12);
            }
            else
            {
                MessageBox.Show("You have to submit user Firstname and Lastname before generating email and password.",
                    "Warning - Generating user login details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
