namespace Njit.Sql.Forms
{
    partial class SetSqlConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetSqlConnection));
            this.labelServer = new System.Windows.Forms.Label();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.groupBoxLock = new System.Windows.Forms.GroupBox();
            this.txtLockServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelAuthentication = new System.Windows.Forms.GroupBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.checkBoxWinAuthentication = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panelServerSetting = new System.Windows.Forms.GroupBox();
            this.btnServerRefresh = new System.Windows.Forms.Button();
            this.txtDBName = new System.Windows.Forms.ComboBox();
            this.lblDB = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdvancedSetting = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorkerServerList = new System.ComponentModel.BackgroundWorker();
            this.groupBoxMain.SuspendLayout();
            this.groupBoxLock.SuspendLayout();
            this.panelAuthentication.SuspendLayout();
            this.panelServerSetting.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(360, 24);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(98, 14);
            this.labelServer.TabIndex = 0;
            this.labelServer.Text = "نام یا آدرس سرور:";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(151, 21);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxServer.Size = new System.Drawing.Size(203, 22);
            this.comboBoxServer.TabIndex = 1;
            this.mainToolTip.SetToolTip(this.comboBoxServer, "نام یا ادرس IP کامپیوتر سرور را به همراه نام نمونه اس کیو ال نصب شده وارد کنید\r\nب" +
        "ه عنوان مثال: Server\\SQL2008\r\nدر صورتی که همین کامپیوتر سرور است بجای نام کامپیو" +
        "تر میتوانید از . (نقطه) استفاده کنید");
            this.comboBoxServer.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.groupBoxLock);
            this.groupBoxMain.Controls.Add(this.panelAuthentication);
            this.groupBoxMain.Controls.Add(this.panelServerSetting);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Location = new System.Drawing.Point(10, 3);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10, 0, 10, 3);
            this.groupBoxMain.Size = new System.Drawing.Size(531, 306);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            // 
            // groupBoxLock
            // 
            this.groupBoxLock.Controls.Add(this.txtLockServer);
            this.groupBoxLock.Controls.Add(this.label3);
            this.groupBoxLock.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxLock.Location = new System.Drawing.Point(10, 239);
            this.groupBoxLock.Name = "groupBoxLock";
            this.groupBoxLock.Size = new System.Drawing.Size(511, 61);
            this.groupBoxLock.TabIndex = 2;
            this.groupBoxLock.TabStop = false;
            this.groupBoxLock.Text = "تنظیمات قفل سخت افزاری";
            // 
            // txtLockServer
            // 
            this.txtLockServer.Location = new System.Drawing.Point(97, 25);
            this.txtLockServer.Name = "txtLockServer";
            this.txtLockServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtLockServer.Size = new System.Drawing.Size(257, 22);
            this.txtLockServer.TabIndex = 1;
            this.mainToolTip.SetToolTip(this.txtLockServer, "آدرس IP سیستمی که قفل سخت افزاری به آن متصل است را وارد کنید\r\nدر صورتی که قفل سخت" +
        " افزاری به همین سیستم متصل است این مقدار را خالی قرار دهید");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "آدرس سیستم دارای قفل:";
            // 
            // panelAuthentication
            // 
            this.panelAuthentication.Controls.Add(this.txtTimeout);
            this.panelAuthentication.Controls.Add(this.checkBoxWinAuthentication);
            this.panelAuthentication.Controls.Add(this.label7);
            this.panelAuthentication.Controls.Add(this.label2);
            this.panelAuthentication.Controls.Add(this.txtUsername);
            this.panelAuthentication.Controls.Add(this.label1);
            this.panelAuthentication.Controls.Add(this.txtPassword);
            this.panelAuthentication.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAuthentication.Location = new System.Drawing.Point(10, 99);
            this.panelAuthentication.Name = "panelAuthentication";
            this.panelAuthentication.Size = new System.Drawing.Size(511, 140);
            this.panelAuthentication.TabIndex = 1;
            this.panelAuthentication.TabStop = false;
            this.panelAuthentication.Text = "سایر تنظیمات";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(151, 105);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTimeout.Size = new System.Drawing.Size(203, 22);
            this.txtTimeout.TabIndex = 6;
            this.mainToolTip.SetToolTip(this.txtTimeout, "حداکثر زمان تلاش برای اتصال بر حسب ثانیه");
            this.txtTimeout.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // checkBoxWinAuthentication
            // 
            this.checkBoxWinAuthentication.Location = new System.Drawing.Point(257, 21);
            this.checkBoxWinAuthentication.Name = "checkBoxWinAuthentication";
            this.checkBoxWinAuthentication.Size = new System.Drawing.Size(227, 22);
            this.checkBoxWinAuthentication.TabIndex = 0;
            this.checkBoxWinAuthentication.Text = "اعتبار سنجی با حساب کاربری ویندوز";
            this.mainToolTip.SetToolTip(this.checkBoxWinAuthentication, "در صورتی که از سرور شبکه استفاده میکنید\r\nو این سیستم سرور نیست\r\nتیک این گزینه را " +
        "بردارید و نام کاربری و رمز عبور سرور را وارد کنید");
            this.checkBoxWinAuthentication.UseVisualStyleBackColor = true;
            this.checkBoxWinAuthentication.CheckedChanged += new System.EventHandler(this.checkBox_win_authentication_CheckedChanged);
            this.checkBoxWinAuthentication.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 14);
            this.label7.TabIndex = 5;
            this.label7.Text = "حداکثر زمان انتظار (ثانیه):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "رمز عبور:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(151, 49);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.Size = new System.Drawing.Size(203, 22);
            this.txtUsername.TabIndex = 2;
            this.mainToolTip.SetToolTip(this.txtUsername, "نام کاربری سرور");
            this.txtUsername.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام کاربری:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(151, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(203, 22);
            this.txtPassword.TabIndex = 4;
            this.mainToolTip.SetToolTip(this.txtPassword, "رمز عبور سرور");
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // panelServerSetting
            // 
            this.panelServerSetting.Controls.Add(this.btnServerRefresh);
            this.panelServerSetting.Controls.Add(this.comboBoxServer);
            this.panelServerSetting.Controls.Add(this.labelServer);
            this.panelServerSetting.Controls.Add(this.txtDBName);
            this.panelServerSetting.Controls.Add(this.lblDB);
            this.panelServerSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelServerSetting.Location = new System.Drawing.Point(10, 15);
            this.panelServerSetting.Name = "panelServerSetting";
            this.panelServerSetting.Size = new System.Drawing.Size(511, 84);
            this.panelServerSetting.TabIndex = 0;
            this.panelServerSetting.TabStop = false;
            this.panelServerSetting.Text = "تنظیمات سرور پایگاه داده";
            // 
            // btnServerRefresh
            // 
            this.btnServerRefresh.Location = new System.Drawing.Point(9, 20);
            this.btnServerRefresh.Name = "btnServerRefresh";
            this.btnServerRefresh.Size = new System.Drawing.Size(136, 23);
            this.btnServerRefresh.TabIndex = 4;
            this.btnServerRefresh.Text = "تازه سازی";
            this.btnServerRefresh.UseVisualStyleBackColor = true;
            this.btnServerRefresh.Click += new System.EventHandler(this.btn_server_refresh_Click);
            // 
            // txtDBName
            // 
            this.txtDBName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtDBName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtDBName.FormattingEnabled = true;
            this.txtDBName.Location = new System.Drawing.Point(151, 49);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDBName.Size = new System.Drawing.Size(203, 22);
            this.txtDBName.TabIndex = 3;
            this.mainToolTip.SetToolTip(this.txtDBName, "نام پایگاه داده را وارد کنید");
            this.txtDBName.DropDown += new System.EventHandler(this.txtDBName_DropDown);
            this.txtDBName.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(360, 52);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(62, 14);
            this.lblDB.TabIndex = 2;
            this.lblDB.Text = "پایگاه داده:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnTest);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnAdvancedSetting);
            this.panelButtons.Controls.Add(this.btnOK);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(10, 309);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.panelButtons.Size = new System.Drawing.Size(531, 32);
            this.panelButtons.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTest.Location = new System.Drawing.Point(231, 6);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "تست ارتباط";
            this.mainToolTip.SetToolTip(this.btnTest, "برای تست ارتباط کلیک کنید");
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            this.btnTest.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(3, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btn_cancel_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // btnAdvancedSetting
            // 
            this.btnAdvancedSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdvancedSetting.Location = new System.Drawing.Point(306, 6);
            this.btnAdvancedSetting.Name = "btnAdvancedSetting";
            this.btnAdvancedSetting.Size = new System.Drawing.Size(141, 23);
            this.btnAdvancedSetting.TabIndex = 1;
            this.btnAdvancedSetting.Text = "تنظیمات پیشرفته...";
            this.mainToolTip.SetToolTip(this.btnAdvancedSetting, "در صورتی که نیاز به تنظیم خصوصیات بیشتری دارید کلیک کنید");
            this.btnAdvancedSetting.UseVisualStyleBackColor = true;
            this.btnAdvancedSetting.Visible = false;
            this.btnAdvancedSetting.Click += new System.EventHandler(this.btn_advanced_setting_Click);
            this.btnAdvancedSetting.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(447, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "ثبت";
            this.mainToolTip.SetToolTip(this.btnOK, "برای ثبت تنظیمات کلیک کنید");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            // 
            // backgroundWorkerServerList
            // 
            this.backgroundWorkerServerList.WorkerReportsProgress = true;
            this.backgroundWorkerServerList.WorkerSupportsCancellation = true;
            this.backgroundWorkerServerList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerServerList_DoWork);
            this.backgroundWorkerServerList.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerServerList_ProgressChanged);
            this.backgroundWorkerServerList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerServerList_RunWorkerCompleted);
            // 
            // SetSqlConnection
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(551, 344);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.panelButtons);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetSqlConnection";
            this.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات پایگاه داده و قفل سخت افزاری";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.control_HelpRequested);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxLock.ResumeLayout(false);
            this.groupBoxLock.PerformLayout();
            this.panelAuthentication.ResumeLayout(false);
            this.panelAuthentication.PerformLayout();
            this.panelServerSetting.ResumeLayout(false);
            this.panelServerSetting.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label labelServer;
        protected System.Windows.Forms.ComboBox comboBoxServer;
        protected System.Windows.Forms.GroupBox groupBoxMain;
        protected System.Windows.Forms.TextBox txtPassword;
        protected System.Windows.Forms.TextBox txtUsername;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ComboBox txtDBName;
        protected System.Windows.Forms.Label lblDB;
        protected System.Windows.Forms.GroupBox panelServerSetting;
        protected System.Windows.Forms.Panel panelButtons;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnAdvancedSetting;
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.GroupBox panelAuthentication;
        protected System.Windows.Forms.CheckBox checkBoxWinAuthentication;
        protected System.Windows.Forms.TextBox txtTimeout;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.ToolTip mainToolTip;
        protected System.Windows.Forms.Button btnTest;
        protected System.Windows.Forms.Button btnServerRefresh;
        private System.ComponentModel.BackgroundWorker backgroundWorkerServerList;
        private System.Windows.Forms.GroupBox groupBoxLock;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtLockServer;

    }
}

