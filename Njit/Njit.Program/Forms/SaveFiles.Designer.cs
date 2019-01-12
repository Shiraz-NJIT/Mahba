namespace Njit.Program.Forms
{
    partial class SaveFiles
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.backgroundWorkerInit = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCopy = new System.ComponentModel.BackgroundWorker();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(474, 154);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 154);
            this.panelCommand.Size = new System.Drawing.Size(474, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.progressBar1);
            this.groupBoxMain.Controls.Add(this.lblTitle);
            this.groupBoxMain.Size = new System.Drawing.Size(454, 151);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(386, 3);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(3, 118);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(448, 18);
            this.progressBar1.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(3, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(448, 100);
            this.lblTitle.TabIndex = 2;
            // 
            // backgroundWorkerInit
            // 
            this.backgroundWorkerInit.WorkerReportsProgress = true;
            this.backgroundWorkerInit.WorkerSupportsCancellation = true;
            this.backgroundWorkerInit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInit_DoWork);
            this.backgroundWorkerInit.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerInit_ProgressChanged);
            this.backgroundWorkerInit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInit_RunWorkerCompleted);
            // 
            // backgroundWorkerCopy
            // 
            this.backgroundWorkerCopy.WorkerReportsProgress = true;
            this.backgroundWorkerCopy.WorkerSupportsCancellation = true;
            this.backgroundWorkerCopy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCopy_DoWork);
            this.backgroundWorkerCopy.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCopy_ProgressChanged);
            this.backgroundWorkerCopy.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCopy_RunWorkerCompleted);
            // 
            // SaveFiles
            // 
            this.AllowCheckAccessPermission = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 183);
            this.Name = "SaveFiles";
            this.Text = "ذخیره فایل ها";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInit;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCopy;
    }
}