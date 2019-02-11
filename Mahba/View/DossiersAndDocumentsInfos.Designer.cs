namespace NjitSoftware.View
{
    partial class DossiersAndDocumentsInfos
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radGridViewExtended = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new Njit.Program.Controls.ButtonExtended();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 465);
            this.panelCommand.Size = new System.Drawing.Size(827, 29);
            this.panelCommand.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.radGridViewExtended);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.progressBar);
            this.panelMain.Size = new System.Drawing.Size(827, 465);
            this.panelMain.TabIndex = 0;
            // 
            // radGridViewExtended
            // 
            this.radGridViewExtended.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewExtended.Location = new System.Drawing.Point(10, 44);
            // 
            // radGridViewExtended
            // 
            this.radGridViewExtended.MasterTemplate.AllowAddNewRow = false;
            this.radGridViewExtended.MasterTemplate.AllowColumnReorder = false;
            //this.radGridViewExtended.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FormatString = "";
            gridViewTextBoxColumn1.HeaderText = "";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 394;
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 393;
            this.radGridViewExtended.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.radGridViewExtended.MasterTemplate.EnableFiltering = true;
            this.radGridViewExtended.MasterTemplate.EnableGrouping = false;
            this.radGridViewExtended.MasterTemplate.EnableSorting = false;
            this.radGridViewExtended.Name = "radGridViewExtended";
            this.radGridViewExtended.ReadOnly = true;
            this.radGridViewExtended.Size = new System.Drawing.Size(807, 398);
            this.radGridViewExtended.TabIndex = 1;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(10, 442);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(807, 20);
            this.progressBar.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 41);
            this.panel1.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.AllowCheckAccessPermission = false;
            this.btnStart.Location = new System.Drawing.Point(267, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "محاسبه";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(563, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(223, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "محاسبه تعداد و حجم اسناد و پرونده ها";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(348, 11);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(209, 18);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "محاسبه فقط تعداد اسناد و پرونده ها";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // DossiersAndDocumentsInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 494);
            this.Name = "DossiersAndDocumentsInfos";
            this.Text = "گزارش مدیریتی";
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridViewExtended;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel1;
        private Njit.Program.Controls.ButtonExtended btnStart;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}