namespace NjitSoftware.View
{
    partial class ImportStudentFromExcel
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
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dossierTypeComboBoxExtended = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radGridViewExtended1 = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(950, 456);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 456);
            this.panelCommand.Size = new System.Drawing.Size(950, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.groupBox2);
            this.groupBoxMain.Controls.Add(this.groupBox1);
            this.groupBoxMain.Size = new System.Drawing.Size(930, 453);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(787, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(862, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // linkHelp
            // 
            this.linkHelp.AutoSize = true;
            this.linkHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkHelp.Location = new System.Drawing.Point(3, 18);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Size = new System.Drawing.Size(116, 14);
            this.linkHelp.TabIndex = 3;
            this.linkHelp.TabStop = true;
            this.linkHelp.Text = "راهنمای ورود اطلاعات";
            this.linkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelp_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(723, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChoose.Location = new System.Drawing.Point(798, 18);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(123, 27);
            this.btnChoose.TabIndex = 0;
            this.btnChoose.Text = "انتخاب فایل";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(20, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(884, 146);
            this.dataGridView1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dossierTypeComboBoxExtended);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.linkHelp);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnChoose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ورود اطلاعات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "سطح دسترسی پرونده ها:";
            // 
            // dossierTypeComboBoxExtended
            // 
            this.dossierTypeComboBoxExtended.FormattingEnabled = true;
            this.dossierTypeComboBoxExtended.Location = new System.Drawing.Point(425, 17);
            this.dossierTypeComboBoxExtended.Name = "dossierTypeComboBoxExtended";
            this.dossierTypeComboBoxExtended.Size = new System.Drawing.Size(121, 22);
            this.dossierTypeComboBoxExtended.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "نکته: ترتیب ستون ها مطابق با فایل\" راهنمای ورود اطلاعات \" باشد";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(20);
            this.groupBox2.Size = new System.Drawing.Size(924, 384);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات دانشجویان ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radGridViewExtended1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(20, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(884, 183);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "دانشجویانی که اطلاعاتشان ناقص بوده است";
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
            this.radGridViewExtended1.Location = new System.Drawing.Point(3, 18);
            // 
            // radGridViewExtended1
            // 
            this.radGridViewExtended1.MasterTemplate.AllowAddNewRow = false;
            this.radGridViewExtended1.MasterTemplate.AllowColumnReorder = false;
            this.radGridViewExtended1.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridViewExtended1.MasterTemplate.EnableGrouping = false;
            this.radGridViewExtended1.MasterTemplate.EnableSorting = false;
            this.radGridViewExtended1.Name = "radGridViewExtended1";
            this.radGridViewExtended1.ReadOnly = true;
            this.radGridViewExtended1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridViewExtended1.ShowGroupPanel = false;
            this.radGridViewExtended1.Size = new System.Drawing.Size(878, 162);
            this.radGridViewExtended1.TabIndex = 0;
            this.radGridViewExtended1.Text = "radGridViewExtended1";
            // 
            // ImportStudentFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 485);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ImportStudentFromExcel";
            this.Text = "ImportStudentFromExcel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImportStudentFromExcel_Load_1);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridViewExtended1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dossierTypeComboBoxExtended;
    }
}