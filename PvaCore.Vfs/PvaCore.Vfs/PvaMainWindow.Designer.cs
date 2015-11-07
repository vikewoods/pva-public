namespace PvaCore.Vfs
{
    partial class PvaMainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PvaMainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.logTxtBoxMainWindow = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clsUserBtn = new System.Windows.Forms.Button();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.userPassTxt = new System.Windows.Forms.TextBox();
            this.userEmailTxt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.priorityList = new System.Windows.Forms.ComboBox();
            this.dateEndFrom = new System.Windows.Forms.DateTimePicker();
            this.dateStartFrom = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.natList = new System.Windows.Forms.ComboBox();
            this.receptionCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comBackDate = new System.Windows.Forms.DateTimePicker();
            this.passValidDate = new System.Windows.Forms.DateTimePicker();
            this.dobDate = new System.Windows.Forms.DateTimePicker();
            this.statusList = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lastNameTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.firstNameTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.categoryList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.childNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.adultNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.purposeList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cityList = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationalityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dobDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passportEndDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.redLineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.greenLineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivalDtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrationInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peoplesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vpaPolandDbDataSet = new PvaCore.Vfs.VpaPolandDbDataSet();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.peoplesTableAdapter = new PvaCore.Vfs.VpaPolandDbDataSetTableAdapters.PeoplesTableAdapter();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adultNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peoplesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vpaPolandDbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1007, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionInfoToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectionInfoToolStripMenuItem
            // 
            this.connectionInfoToolStripMenuItem.Name = "connectionInfoToolStripMenuItem";
            this.connectionInfoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.connectionInfoToolStripMenuItem.Text = "Connection info";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 659);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1007, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel2.Text = "Disconnected...";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 635);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logTxtBoxMainWindow);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(999, 606);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New User";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // logTxtBoxMainWindow
            // 
            this.logTxtBoxMainWindow.Location = new System.Drawing.Point(8, 380);
            this.logTxtBoxMainWindow.Name = "logTxtBoxMainWindow";
            this.logTxtBoxMainWindow.Size = new System.Drawing.Size(984, 223);
            this.logTxtBoxMainWindow.TabIndex = 3;
            this.logTxtBoxMainWindow.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clsUserBtn);
            this.groupBox3.Controls.Add(this.addUserBtn);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.userPassTxt);
            this.groupBox3.Controls.Add(this.userEmailTxt);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.priorityList);
            this.groupBox3.Controls.Add(this.dateEndFrom);
            this.groupBox3.Controls.Add(this.dateStartFrom);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.natList);
            this.groupBox3.Controls.Add(this.receptionCode);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comBackDate);
            this.groupBox3.Controls.Add(this.passValidDate);
            this.groupBox3.Controls.Add(this.dobDate);
            this.groupBox3.Controls.Add(this.statusList);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lastNameTxtBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.firstNameTxtBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(412, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 368);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Personal details:";
            // 
            // clsUserBtn
            // 
            this.clsUserBtn.Location = new System.Drawing.Point(265, 335);
            this.clsUserBtn.Name = "clsUserBtn";
            this.clsUserBtn.Size = new System.Drawing.Size(150, 23);
            this.clsUserBtn.TabIndex = 28;
            this.clsUserBtn.Text = "Clear fields";
            this.clsUserBtn.UseVisualStyleBackColor = true;
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(421, 335);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(150, 23);
            this.addUserBtn.TabIndex = 27;
            this.addUserBtn.Text = "Add new user";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(301, 283);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "User password:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 283);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "User email:";
            // 
            // userPassTxt
            // 
            this.userPassTxt.Location = new System.Drawing.Point(304, 305);
            this.userPassTxt.Name = "userPassTxt";
            this.userPassTxt.ReadOnly = true;
            this.userPassTxt.Size = new System.Drawing.Size(267, 22);
            this.userPassTxt.TabIndex = 24;
            // 
            // userEmailTxt
            // 
            this.userEmailTxt.Location = new System.Drawing.Point(9, 305);
            this.userEmailTxt.Name = "userEmailTxt";
            this.userEmailTxt.ReadOnly = true;
            this.userEmailTxt.Size = new System.Drawing.Size(270, 22);
            this.userEmailTxt.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(388, 221);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Priority:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(198, 221);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Deadline date:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 221);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Date to start from:";
            // 
            // priorityList
            // 
            this.priorityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityList.FormattingEnabled = true;
            this.priorityList.Location = new System.Drawing.Point(388, 245);
            this.priorityList.Name = "priorityList";
            this.priorityList.Size = new System.Drawing.Size(183, 21);
            this.priorityList.TabIndex = 19;
            // 
            // dateEndFrom
            // 
            this.dateEndFrom.Location = new System.Drawing.Point(198, 245);
            this.dateEndFrom.Name = "dateEndFrom";
            this.dateEndFrom.Size = new System.Drawing.Size(185, 22);
            this.dateEndFrom.TabIndex = 18;
            // 
            // dateStartFrom
            // 
            this.dateStartFrom.Location = new System.Drawing.Point(9, 245);
            this.dateStartFrom.Name = "dateStartFrom";
            this.dateStartFrom.Size = new System.Drawing.Size(185, 22);
            this.dateStartFrom.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(301, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Nationallity:";
            // 
            // natList
            // 
            this.natList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.natList.FormattingEnabled = true;
            this.natList.Location = new System.Drawing.Point(301, 182);
            this.natList.Name = "natList";
            this.natList.Size = new System.Drawing.Size(270, 21);
            this.natList.TabIndex = 15;
            // 
            // receptionCode
            // 
            this.receptionCode.Location = new System.Drawing.Point(9, 183);
            this.receptionCode.Name = "receptionCode";
            this.receptionCode.Size = new System.Drawing.Size(270, 22);
            this.receptionCode.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Reception number:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(388, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Comeback date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(198, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Passport valid date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Date of birth:";
            // 
            // comBackDate
            // 
            this.comBackDate.Location = new System.Drawing.Point(388, 120);
            this.comBackDate.Name = "comBackDate";
            this.comBackDate.Size = new System.Drawing.Size(183, 22);
            this.comBackDate.TabIndex = 9;
            // 
            // passValidDate
            // 
            this.passValidDate.Location = new System.Drawing.Point(198, 120);
            this.passValidDate.Name = "passValidDate";
            this.passValidDate.Size = new System.Drawing.Size(185, 22);
            this.passValidDate.TabIndex = 8;
            // 
            // dobDate
            // 
            this.dobDate.Location = new System.Drawing.Point(9, 120);
            this.dobDate.Name = "dobDate";
            this.dobDate.Size = new System.Drawing.Size(185, 22);
            this.dobDate.TabIndex = 7;
            // 
            // statusList
            // 
            this.statusList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusList.FormattingEnabled = true;
            this.statusList.Location = new System.Drawing.Point(9, 58);
            this.statusList.Name = "statusList";
            this.statusList.Size = new System.Drawing.Size(93, 21);
            this.statusList.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Status:";
            // 
            // lastNameTxtBox
            // 
            this.lastNameTxtBox.Location = new System.Drawing.Point(344, 59);
            this.lastNameTxtBox.Name = "lastNameTxtBox";
            this.lastNameTxtBox.Size = new System.Drawing.Size(230, 22);
            this.lastNameTxtBox.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Lastname:";
            // 
            // firstNameTxtBox
            // 
            this.firstNameTxtBox.Location = new System.Drawing.Point(108, 59);
            this.firstNameTxtBox.Name = "firstNameTxtBox";
            this.firstNameTxtBox.Size = new System.Drawing.Size(230, 22);
            this.firstNameTxtBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Firstname:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.categoryList);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.childNum);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.adultNum);
            this.groupBox2.Location = new System.Drawing.Point(8, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 190);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chooise adult, childs and visa type:";
            // 
            // categoryList
            // 
            this.categoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(8, 149);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(367, 21);
            this.categoryList.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Visa type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total ammount ofchilds:";
            // 
            // childNum
            // 
            this.childNum.Location = new System.Drawing.Point(245, 92);
            this.childNum.Name = "childNum";
            this.childNum.Size = new System.Drawing.Size(130, 22);
            this.childNum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total ammount of adults:";
            // 
            // adultNum
            // 
            this.adultNum.Location = new System.Drawing.Point(245, 43);
            this.adultNum.Name = "adultNum";
            this.adultNum.Size = new System.Drawing.Size(130, 22);
            this.adultNum.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.purposeList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cityList);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chooise city and purpose:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Purpose:";
            // 
            // purposeList
            // 
            this.purposeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.purposeList.FormattingEnabled = true;
            this.purposeList.Location = new System.Drawing.Point(8, 120);
            this.purposeList.Name = "purposeList";
            this.purposeList.Size = new System.Drawing.Size(367, 21);
            this.purposeList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "City:";
            // 
            // cityList
            // 
            this.cityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cityList.FormattingEnabled = true;
            this.cityList.Location = new System.Drawing.Point(8, 57);
            this.cityList.Name = "cityList";
            this.cityList.Size = new System.Drawing.Size(367, 21);
            this.cityList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(999, 606);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DB Users";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.City,
            this.categoryDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.nationalityDataGridViewTextBoxColumn,
            this.receiptDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.dobDataGridViewTextBoxColumn,
            this.passportEndDateDataGridViewTextBoxColumn,
            this.redLineDataGridViewTextBoxColumn,
            this.greenLineDataGridViewTextBoxColumn,
            this.arrivalDtDataGridViewTextBoxColumn,
            this.registrationInfoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.peoplesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(993, 600);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.NullValue = null;
            this.idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // nationalityDataGridViewTextBoxColumn
            // 
            this.nationalityDataGridViewTextBoxColumn.DataPropertyName = "Nationality";
            this.nationalityDataGridViewTextBoxColumn.HeaderText = "Nationality";
            this.nationalityDataGridViewTextBoxColumn.Name = "nationalityDataGridViewTextBoxColumn";
            // 
            // receiptDataGridViewTextBoxColumn
            // 
            this.receiptDataGridViewTextBoxColumn.DataPropertyName = "Receipt";
            this.receiptDataGridViewTextBoxColumn.HeaderText = "Receipt";
            this.receiptDataGridViewTextBoxColumn.Name = "receiptDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            // 
            // dobDataGridViewTextBoxColumn
            // 
            this.dobDataGridViewTextBoxColumn.DataPropertyName = "Dob";
            this.dobDataGridViewTextBoxColumn.HeaderText = "Dob";
            this.dobDataGridViewTextBoxColumn.Name = "dobDataGridViewTextBoxColumn";
            // 
            // passportEndDateDataGridViewTextBoxColumn
            // 
            this.passportEndDateDataGridViewTextBoxColumn.DataPropertyName = "PassportEndDate";
            this.passportEndDateDataGridViewTextBoxColumn.HeaderText = "PassportEndDate";
            this.passportEndDateDataGridViewTextBoxColumn.Name = "passportEndDateDataGridViewTextBoxColumn";
            // 
            // redLineDataGridViewTextBoxColumn
            // 
            this.redLineDataGridViewTextBoxColumn.DataPropertyName = "RedLine";
            this.redLineDataGridViewTextBoxColumn.HeaderText = "RedLine";
            this.redLineDataGridViewTextBoxColumn.Name = "redLineDataGridViewTextBoxColumn";
            // 
            // greenLineDataGridViewTextBoxColumn
            // 
            this.greenLineDataGridViewTextBoxColumn.DataPropertyName = "GreenLine";
            this.greenLineDataGridViewTextBoxColumn.HeaderText = "GreenLine";
            this.greenLineDataGridViewTextBoxColumn.Name = "greenLineDataGridViewTextBoxColumn";
            // 
            // arrivalDtDataGridViewTextBoxColumn
            // 
            this.arrivalDtDataGridViewTextBoxColumn.DataPropertyName = "ArrivalDt";
            this.arrivalDtDataGridViewTextBoxColumn.HeaderText = "ArrivalDt";
            this.arrivalDtDataGridViewTextBoxColumn.Name = "arrivalDtDataGridViewTextBoxColumn";
            // 
            // registrationInfoDataGridViewTextBoxColumn
            // 
            this.registrationInfoDataGridViewTextBoxColumn.DataPropertyName = "RegistrationInfo";
            this.registrationInfoDataGridViewTextBoxColumn.HeaderText = "RegistrationInfo";
            this.registrationInfoDataGridViewTextBoxColumn.Name = "registrationInfoDataGridViewTextBoxColumn";
            // 
            // peoplesBindingSource
            // 
            this.peoplesBindingSource.DataMember = "Peoples";
            this.peoplesBindingSource.DataSource = this.vpaPolandDbDataSet;
            // 
            // vpaPolandDbDataSet
            // 
            this.vpaPolandDbDataSet.DataSetName = "VpaPolandDbDataSet";
            this.vpaPolandDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(999, 606);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Total status";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // peoplesTableAdapter
            // 
            this.peoplesTableAdapter.ClearBeforeFill = true;
            // 
            // PvaMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1007, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PvaMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poland Auto Visa";
            this.Load += new System.EventHandler(this.PvaMainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adultNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peoplesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vpaPolandDbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox purposeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cityList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private VpaPolandDbDataSet vpaPolandDbDataSet;
        private System.Windows.Forms.BindingSource peoplesBindingSource;
        private VpaPolandDbDataSetTableAdapters.PeoplesTableAdapter peoplesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox categoryList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown childNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown adultNum;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationalityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passportEndDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn redLineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn greenLineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivalDtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registrationInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox statusList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lastNameTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox firstNameTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox natList;
        private System.Windows.Forms.TextBox receptionCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker comBackDate;
        private System.Windows.Forms.DateTimePicker passValidDate;
        private System.Windows.Forms.DateTimePicker dobDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox priorityList;
        private System.Windows.Forms.DateTimePicker dateEndFrom;
        private System.Windows.Forms.DateTimePicker dateStartFrom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox userPassTxt;
        private System.Windows.Forms.TextBox userEmailTxt;
        private System.Windows.Forms.Button clsUserBtn;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.RichTextBox logTxtBoxMainWindow;
    }
}

