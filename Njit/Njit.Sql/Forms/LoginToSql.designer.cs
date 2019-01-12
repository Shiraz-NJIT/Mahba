namespace Njit.Sql.Forms
{
    partial class LoginToSql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginToSql));
            this.txtInitialCatalog = new System.Windows.Forms.TextBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAuthentication = new System.Windows.Forms.ComboBox();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerServers = new System.ComponentModel.BackgroundWorker();
            this.lblServersRefresh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInitialCatalog
            // 
            this.txtInitialCatalog.Location = new System.Drawing.Point(82, 190);
            this.txtInitialCatalog.Name = "txtInitialCatalog";
            this.txtInitialCatalog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInitialCatalog.Size = new System.Drawing.Size(230, 22);
            this.txtInitialCatalog.TabIndex = 10;
            this.txtInitialCatalog.Text = "master";
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Location = new System.Drawing.Point(12, 219);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(393, 2);
            this.lblLine.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(249, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(330, 226);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "اتصال";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(82, 162);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(230, 22);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(82, 134);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.Size = new System.Drawing.Size(230, 22);
            this.txtUsername.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "نام دیتابیس:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "کلمه عبور:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "نام کاربری:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "نحوه اتصال:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام یا آدرس سرور:";
            // 
            // comboBoxAuthentication
            // 
            this.comboBoxAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAuthentication.FormattingEnabled = true;
            this.comboBoxAuthentication.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.comboBoxAuthentication.Location = new System.Drawing.Point(82, 106);
            this.comboBoxAuthentication.Name = "comboBoxAuthentication";
            this.comboBoxAuthentication.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxAuthentication.Size = new System.Drawing.Size(230, 22);
            this.comboBoxAuthentication.TabIndex = 4;
            this.comboBoxAuthentication.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAuthenticationSelectedIndexChanged);
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Items.AddRange(new object[] {
            "(Local)",
            "(Local)\\SQLEXPRESS",
            "(Local)\\ZAO"});
            this.comboBoxServer.Location = new System.Drawing.Point(82, 78);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxServer.Size = new System.Drawing.Size(230, 22);
            this.comboBoxServer.TabIndex = 1;
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxTitle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTitle.Image")));
            this.pictureBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(439, 72);
            this.pictureBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTitle.TabIndex = 6;
            this.pictureBoxTitle.TabStop = false;
            // 
            // backgroundWorkerServers
            // 
            this.backgroundWorkerServers.WorkerReportsProgress = true;
            this.backgroundWorkerServers.WorkerSupportsCancellation = true;
            this.backgroundWorkerServers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerServers_DoWork);
            this.backgroundWorkerServers.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerServers_ProgressChanged);
            this.backgroundWorkerServers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerServers_RunWorkerCompleted);
            // 
            // lblServersRefresh
            // 
            this.lblServersRefresh.Location = new System.Drawing.Point(19, 78);
            this.lblServersRefresh.Name = "lblServersRefresh";
            this.lblServersRefresh.Size = new System.Drawing.Size(57, 20);
            this.lblServersRefresh.TabIndex = 2;
            this.lblServersRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoginToSql
            // 
            this.AcceptButton = this.btnConnect;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(439, 259);
            this.Controls.Add(this.lblServersRefresh);
            this.Controls.Add(this.txtInitialCatalog);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAuthentication);
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.pictureBoxTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginToSql";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اتصال به SQLServer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTitle;
        private System.Windows.Forms.TextBox txtInitialCatalog;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBoxAuthentication;
        public System.Windows.Forms.ComboBox comboBoxServer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerServers;
        private System.Windows.Forms.Label lblServersRefresh;
    }
}
