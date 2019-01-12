namespace NjitSoftware.View
{
    partial class DossierChangeDataField
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPN = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radGridViewExtended1 = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1.MasterTemplate)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(836, 449);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 449);
            this.panelCommand.Size = new System.Drawing.Size(836, 40);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.panel3);
            this.groupBoxMain.Controls.Add(this.panel2);
            this.groupBoxMain.Controls.Add(this.panel1);
            this.groupBoxMain.Size = new System.Drawing.Size(816, 446);
            this.groupBoxMain.Enter += new System.EventHandler(this.groupBoxMain_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(673, 3);
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(748, 3);
            this.btnOK.Size = new System.Drawing.Size(75, 34);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "شماره پرونده:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "اضافه کردن";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPN);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 47);
            this.panel1.TabIndex = 0;
            // 
            // txtPN
            // 
            this.txtPN.Location = new System.Drawing.Point(545, 12);
            this.txtPN.Name = "txtPN";
            this.txtPN.Size = new System.Drawing.Size(173, 22);
            this.txtPN.TabIndex = 2;
            this.txtPN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPN_KeyDown);
            this.txtPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPN_KeyPress);
            this.txtPN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtPN_PreviewKeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radGridViewExtended1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 264);
            this.panel2.TabIndex = 1;
            // 
            // radGridViewExtended1
            // 
            this.radGridViewExtended1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridViewExtended1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridViewExtended1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewExtended1.EnableHotTracking = false;
            this.radGridViewExtended1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGridViewExtended1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridViewExtended1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridViewExtended1.Location = new System.Drawing.Point(0, 0);
            // 
            // radGridViewExtended1
            // 
            this.radGridViewExtended1.MasterTemplate.AllowAddNewRow = false;
            this.radGridViewExtended1.MasterTemplate.AllowColumnReorder = false;
            this.radGridViewExtended1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridViewExtended1.MasterTemplate.EnableGrouping = false;
            this.radGridViewExtended1.Name = "radGridViewExtended1";
            this.radGridViewExtended1.ReadOnly = true;
            this.radGridViewExtended1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridViewExtended1.ShowGroupPanel = false;
            this.radGridViewExtended1.Size = new System.Drawing.Size(810, 264);
            this.radGridViewExtended1.TabIndex = 0;
            this.radGridViewExtended1.Text = "radGridViewExtended1";
            this.radGridViewExtended1.Click += new System.EventHandler(this.radGridViewExtended1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlInfo);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 329);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(810, 111);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "پرونده های بالا تبدیل شود به:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = " فیلد اطلاعاتی:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(443, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 22);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInfo.Location = new System.Drawing.Point(13, 21);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlInfo.Size = new System.Drawing.Size(263, 50);
            this.pnlInfo.TabIndex = 3;
            // 
            // DossierChangeDataField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 489);
            this.Name = "DossierChangeDataField";
            this.Text = "تغییر گروهی اطلاعات";
            this.Load += new System.EventHandler(this.DossierChangeDataField_Load);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridViewExtended1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPN;
        private System.Windows.Forms.Panel pnlInfo;
    }
}