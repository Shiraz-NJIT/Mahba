namespace NjitSoftware.View
{
    partial class DossierReportView
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
            this.radGridView = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.btnPrint = new Njit.Program.Controls.ButtonExtended();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnPrint);
            this.panelCommand.Location = new System.Drawing.Point(0, 445);
            this.panelCommand.Size = new System.Drawing.Size(836, 29);
            this.panelCommand.TabIndex = 1;
            this.panelCommand.Controls.SetChildIndex(this.btnExit, 0);
            this.panelCommand.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // btnExit
            // 
            this.btnExit.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Size = new System.Drawing.Size(836, 445);
            this.panelMain.TabIndex = 0;
            // 
            // radGridView
            // 
            this.radGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView.Location = new System.Drawing.Point(3, 18);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AllowAddNewRow = false;
            this.radGridView.MasterTemplate.AllowDeleteRow = false;
            this.radGridView.MasterTemplate.AllowEditRow = false;
            this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView.MasterTemplate.EnableFiltering = true;
            this.radGridView.MasterTemplate.MultiSelect = true;
            this.radGridView.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView.Name = "radGridView";
            this.radGridView.ReadOnly = true;
            this.radGridView.Size = new System.Drawing.Size(810, 375);
            this.radGridView.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrint.Location = new System.Drawing.Point(738, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 43);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعداد سطر های مطابق شرط گزارش";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(736, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "تعداد سطرها:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNumber.Location = new System.Drawing.Point(675, 18);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(61, 14);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "lblNumber";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(10, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(816, 396);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نتایج گزارش";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(3, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "ذخیره در فایل اکسل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DossierReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 474);
            this.Name = "DossierReportView";
            this.Text = "نتیجه گزارش";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridView;
        private Njit.Program.Controls.ButtonExtended btnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}