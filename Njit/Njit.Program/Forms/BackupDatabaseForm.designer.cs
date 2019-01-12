namespace Njit.Program.Forms
{
    partial class BackupDatabaseForm
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new Njit.Program.Controls.ButtonExtended();
            this.btnBackup = new Njit.Program.Controls.ButtonExtended();
            this.txtBackupName = new Njit.Program.Controls.TextBoxExtended();
            this.lblBackupName = new System.Windows.Forms.Label();
            this.txtBackupPath = new Njit.Program.Controls.TextBoxExtended();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.checkBoxAuto = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new Njit.Program.Controls.ButtonExtended();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.panelButtons.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnBackup);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(10, 117);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(3);
            this.panelButtons.Size = new System.Drawing.Size(499, 29);
            this.panelButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(318, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBackup.Location = new System.Drawing.Point(393, 3);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(103, 23);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "پشتیبان گیری";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtBackupName
            // 
            this.txtBackupName.Location = new System.Drawing.Point(111, 21);
            this.txtBackupName.Name = "txtBackupName";
            this.txtBackupName.Size = new System.Drawing.Size(302, 22);
            this.txtBackupName.TabIndex = 1;
            // 
            // lblBackupName
            // 
            this.lblBackupName.AutoSize = true;
            this.lblBackupName.Location = new System.Drawing.Point(419, 24);
            this.lblBackupName.Name = "lblBackupName";
            this.lblBackupName.Size = new System.Drawing.Size(69, 14);
            this.lblBackupName.TabIndex = 0;
            this.lblBackupName.Text = "نام پشتیبان:";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(111, 50);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(302, 22);
            this.txtBackupPath.TabIndex = 3;
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Location = new System.Drawing.Point(419, 53);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(72, 14);
            this.lblBackupPath.TabIndex = 2;
            this.lblBackupPath.Text = "مسیر ذخیره:";
            // 
            // checkBoxAuto
            // 
            this.checkBoxAuto.AutoSize = true;
            this.checkBoxAuto.Location = new System.Drawing.Point(74, 78);
            this.checkBoxAuto.Name = "checkBoxAuto";
            this.checkBoxAuto.Size = new System.Drawing.Size(339, 18);
            this.checkBoxAuto.TabIndex = 5;
            this.checkBoxAuto.Text = "هنگام خروج از برنامه به صورت خودکار پشتیبان گیری انجام شود";
            this.checkBoxAuto.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(6, 49);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(99, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "انتخاب مسیر...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "مسیر ذخیره فایل پشتیبان";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.txtBackupName);
            this.groupBox.Controls.Add(this.btnBrowse);
            this.groupBox.Controls.Add(this.txtBackupPath);
            this.groupBox.Controls.Add(this.checkBoxAuto);
            this.groupBox.Controls.Add(this.lblBackupName);
            this.groupBox.Controls.Add(this.lblBackupPath);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(10, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(499, 114);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // BackupDatabaseForm
            // 
            this.AcceptButton = this.btnBackup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(519, 146);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.panelButtons);
            this.Name = "BackupDatabaseForm";
            this.Padding = new System.Windows.Forms.Padding(10, 3, 10, 0);
            this.Text = "پشتیبان گیری از اطلاعات";
            this.panelButtons.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelButtons;
        protected Njit.Program.Controls.ButtonExtended btnCancel;
        protected Njit.Program.Controls.ButtonExtended btnBackup;
        protected Njit.Program.Controls.TextBoxExtended txtBackupName;
        protected System.Windows.Forms.Label lblBackupName;
        protected Njit.Program.Controls.TextBoxExtended txtBackupPath;
        protected System.Windows.Forms.Label lblBackupPath;
        protected System.Windows.Forms.CheckBox checkBoxAuto;
        protected Controls.ButtonExtended btnBrowse;
        protected System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        protected System.Windows.Forms.GroupBox groupBox;


    }
}
