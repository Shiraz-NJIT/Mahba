namespace NjitSoftware.View
{
    partial class BackupDocuments
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
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new Njit.Program.Controls.TextBoxExtended();
            this.browseButton = new Njit.Program.Controls.BrowseButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(505, 146);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 146);
            this.panelCommand.Size = new System.Drawing.Size(505, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.progressBar);
            this.groupBoxMain.Controls.Add(this.browseButton);
            this.groupBoxMain.Controls.Add(this.txtPath);
            this.groupBoxMain.Controls.Add(this.lblStatus);
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Size = new System.Drawing.Size(485, 143);
            // 
            // btnCancel
            // 
            this.btnCancel.AllowCheckAccessPermission = false;
            this.btnCancel.Location = new System.Drawing.Point(280, 3);
            // 
            // btnOK
            // 
            this.btnOK.AllowCheckAccessPermission = false;
            this.btnOK.Location = new System.Drawing.Point(355, 3);
            this.btnOK.Size = new System.Drawing.Size(137, 23);
            this.btnOK.Text = "شروع پشتیبان گیری";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "لطفا مسیر ذخیره پشتیبان اسناد را انتخاب کنید";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(124, 48);
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(355, 22);
            this.txtPath.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.AllowCheckAccessPermission = false;
            this.browseButton.Description = "";
            this.browseButton.Location = new System.Drawing.Point(6, 47);
            this.browseButton.Name = "browseButton";
            this.browseButton.PathControl = this.txtPath;
            this.browseButton.Size = new System.Drawing.Size(112, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "انتخاب مسیر...";
            this.browseButton.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(6, 78);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(473, 28);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 114);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(473, 20);
            this.progressBar.TabIndex = 4;
            // 
            // BackupDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 175);
            this.Name = "BackupDocuments";
            this.Text = "پشتیبان گیری از اسناد";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.TextBoxExtended txtPath;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Njit.Program.Controls.BrowseButton browseButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
    }
}