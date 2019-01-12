namespace NjitSoftware.View
{
    partial class DocumentFailure
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNotSee = new System.Windows.Forms.CheckBox();
            this.cbSee = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radGridViewExtended1 = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(0, 67);
            this.panelMain.Size = new System.Drawing.Size(923, 321);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 388);
            this.panelCommand.Size = new System.Drawing.Size(923, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.radGridViewExtended1);
            this.groupBoxMain.Size = new System.Drawing.Size(903, 318);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(760, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(835, 3);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNotSee);
            this.groupBox1.Controls.Add(this.cbSee);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(923, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // cbNotSee
            // 
            this.cbNotSee.AutoSize = true;
            this.cbNotSee.Checked = true;
            this.cbNotSee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNotSee.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbNotSee.Location = new System.Drawing.Point(642, 29);
            this.cbNotSee.Name = "cbNotSee";
            this.cbNotSee.Size = new System.Drawing.Size(141, 35);
            this.cbNotSee.TabIndex = 2;
            this.cbNotSee.Text = "اسناد مشاهده نشده";
            this.cbNotSee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbNotSee.UseVisualStyleBackColor = true;
            this.cbNotSee.CheckedChanged += new System.EventHandler(this.cbNotSee_CheckedChanged);
            // 
            // cbSee
            // 
            this.cbSee.AutoSize = true;
            this.cbSee.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbSee.Location = new System.Drawing.Point(783, 29);
            this.cbSee.Name = "cbSee";
            this.cbSee.Size = new System.Drawing.Size(137, 35);
            this.cbSee.TabIndex = 1;
            this.cbSee.Text = "اسناد مشاهده شده";
            this.cbSee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbSee.UseVisualStyleBackColor = true;
            this.cbSee.CheckedChanged += new System.EventHandler(this.cbSee_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox2.Location = new System.Drawing.Point(0, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(923, 350);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست گزارش اسناد";
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
            this.radGridViewExtended1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridViewExtended1.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridViewExtended1.MasterTemplate.EnableFiltering = true;
            this.radGridViewExtended1.MasterTemplate.EnableGrouping = false;
            this.radGridViewExtended1.Name = "radGridViewExtended1";
            this.radGridViewExtended1.ReadOnly = true;
            this.radGridViewExtended1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridViewExtended1.ShowGroupPanel = false;
            this.radGridViewExtended1.Size = new System.Drawing.Size(897, 297);
            this.radGridViewExtended1.TabIndex = 0;
            this.radGridViewExtended1.Text = "radGridViewExtended1";
            this.radGridViewExtended1.DoubleClick += new System.EventHandler(this.radGridViewExtended1_DoubleClick);
            // 
            // DocumentFailure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 417);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DocumentFailure";
            this.Text = "لیست گزارش خرابی اسناد";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.panelCommand, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewExtended1)).EndInit();
            this.ResumeLayout(false);

        }

       
        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSee;
        private System.Windows.Forms.CheckBox cbNotSee;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridViewExtended1;
    }
}