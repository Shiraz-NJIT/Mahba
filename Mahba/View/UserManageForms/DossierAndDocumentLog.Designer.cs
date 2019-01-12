namespace NjitSoftware.View.UserManageForms
{
    partial class DossierAndDocumentLog
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label label2;
            this.comboBoxUsers = new Njit.Program.Controls.ComboBoxExtended();
            this.dateToTextBox = new Njit.Program.Controls.DateControl();
            this.dateFromTextBox = new Njit.Program.Controls.DateControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radGridView = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            label1 = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 9F);
            label1.Location = new System.Drawing.Point(335, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 14);
            label1.TabIndex = 15;
            label1.Text = "تا تاریخ:";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateLabel.AutoSize = true;
            dateLabel.Font = new System.Drawing.Font("Tahoma", 9F);
            dateLabel.Location = new System.Drawing.Point(555, 32);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(44, 14);
            dateLabel.TabIndex = 13;
            dateLabel.Text = "از تاریخ:";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 9F);
            label2.Location = new System.Drawing.Point(931, 28);
            label2.Name = "label2";
            label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label2.Size = new System.Drawing.Size(33, 14);
            label2.TabIndex = 17;
            label2.Text = "کاربر:";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUsers.DisplayMember = "FullName";
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.Font = new System.Drawing.Font("Tahoma", 9F);
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(643, 23);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(280, 22);
            this.comboBoxUsers.TabIndex = 12;
            this.comboBoxUsers.ValueMember = "Code";
            this.comboBoxUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);
            // 
            // dateToTextBox
            // 
            this.dateToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateToTextBox.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dateToTextBox.Location = new System.Drawing.Point(187, 26);
            this.dateToTextBox.Name = "dateToTextBox";
            this.dateToTextBox.Size = new System.Drawing.Size(140, 22);
            this.dateToTextBox.TabIndex = 16;
            this.dateToTextBox.TextChanged += new System.EventHandler(this.dateToTextBox_TextChanged);
            // 
            // dateFromTextBox
            // 
            this.dateFromTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFromTextBox.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dateFromTextBox.Location = new System.Drawing.Point(395, 26);
            this.dateFromTextBox.Name = "dateFromTextBox";
            this.dateFromTextBox.Size = new System.Drawing.Size(140, 22);
            this.dateFromTextBox.TabIndex = 14;
            this.dateFromTextBox.TextChanged += new System.EventHandler(this.dateFromTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dateFromTextBox);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(this.dateToTextBox);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(dateLabel);
            this.groupBox1.Controls.Add(this.comboBoxUsers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 95);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(357, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "تعداد اسنادی که اطلاعاتش ثبت شده توسط کاربر   ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(643, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "تعداد اسناد ذخیره شده توسط کاربر   ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox2.Location = new System.Drawing.Point(0, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1004, 550);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "جدول عملکرد";
            // 
            // radGridView
            // 
            this.radGridView.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView.EnableHotTracking = false;
            this.radGridView.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGridView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView.Location = new System.Drawing.Point(3, 18);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AllowAddNewRow = false;
            this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.radGridView.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridView.MasterTemplate.EnableFiltering = true;
            this.radGridView.Name = "radGridView";
            this.radGridView.ReadOnly = true;
            this.radGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView.Size = new System.Drawing.Size(998, 529);
            this.radGridView.TabIndex = 0;
            this.radGridView.Text = "radGridViewExtended1";
            this.radGridView.DoubleClick += new System.EventHandler(this.radGridView_DoubleClick);
            this.radGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radGridView_KeyUp);
            // 
            // DossierAndDocumentLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 645);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Name = "DossierAndDocumentLog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش پرونده و اسناد";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DossierAndDocumentLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private Njit.Program.Controls.ComboBoxExtended comboBoxUsers;
        private Njit.Program.Controls.DateControl dateToTextBox;
        private Njit.Program.Controls.DateControl dateFromTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}