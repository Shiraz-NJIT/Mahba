namespace NjitSoftware.View.UserManageForms
{
    partial class UserLog
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label dateLabel;
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.userLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.membershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxUsers = new Njit.Program.Controls.ComboBoxExtended();
            this.dateToTextBox = new Njit.Program.Controls.DateControl();
            this.dateFromTextBox = new Njit.Program.Controls.DateControl();
            this.radGridView = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            this.groupBoxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 486);
            this.panelCommand.Size = new System.Drawing.Size(942, 29);
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.radGridView);
            this.panelMain.Size = new System.Drawing.Size(942, 333);
            this.panelMain.Controls.SetChildIndex(this.groupBoxSearch, 0);
            this.panelMain.Controls.SetChildIndex(this.radGridView, 0);
            // 
            // mainRibbon
            // 
            this.mainRibbon.Size = new System.Drawing.Size(942, 153);
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.comboBoxUsers);
            this.groupBoxSearch.Controls.Add(label1);
            this.groupBoxSearch.Controls.Add(label2);
            this.groupBoxSearch.Controls.Add(dateLabel);
            this.groupBoxSearch.Controls.Add(this.dateToTextBox);
            this.groupBoxSearch.Controls.Add(this.dateFromTextBox);
            this.groupBoxSearch.Size = new System.Drawing.Size(922, 55);
            this.groupBoxSearch.Visible = true;
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(318, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 14);
            label1.TabIndex = 10;
            label1.Text = "تا تاریخ:";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(832, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 14);
            label2.TabIndex = 6;
            label2.Text = "کاربر:";
            // 
            // dateLabel
            // 
            dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(495, 19);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(44, 14);
            dateLabel.TabIndex = 8;
            dateLabel.Text = "از تاریخ:";
            // 
            // userLogBindingSource
            // 
            this.userLogBindingSource.DataSource = typeof(NjitSoftware.UserLogView);
            // 
            // membershipBindingSource
            // 
            this.membershipBindingSource.DataSource = typeof(NjitSoftware.Model.Common.User);
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUsers.DataSource = this.membershipBindingSource;
            this.comboBoxUsers.DisplayMember = "FullName";
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(585, 16);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(241, 22);
            this.comboBoxUsers.TabIndex = 7;
            this.comboBoxUsers.ValueMember = "Code";
            this.comboBoxUsers.SelectedValueChanged += new System.EventHandler(this.comboBoxUsers_SelectedValueChanged);
            // 
            // dateToTextBox
            // 
            this.dateToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateToTextBox.Location = new System.Drawing.Point(191, 16);
            this.dateToTextBox.Name = "dateToTextBox";
            this.dateToTextBox.Size = new System.Drawing.Size(121, 22);
            this.dateToTextBox.TabIndex = 11;
            this.dateToTextBox.TextChanged += new System.EventHandler(this.dateToTextBox_TextChanged);
            // 
            // dateFromTextBox
            // 
            this.dateFromTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFromTextBox.Location = new System.Drawing.Point(368, 16);
            this.dateFromTextBox.Name = "dateFromTextBox";
            this.dateFromTextBox.Size = new System.Drawing.Size(121, 22);
            this.dateFromTextBox.TabIndex = 9;
            this.dateFromTextBox.TextChanged += new System.EventHandler(this.dateFromTextBox_TextChanged);
            // 
            // radGridView
            // 
            this.radGridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.radGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGridView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView.Location = new System.Drawing.Point(10, 58);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AllowAddNewRow = false;
            this.radGridView.MasterTemplate.AllowDeleteRow = false;
            this.radGridView.MasterTemplate.AllowEditRow = false;
            this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Radif";
            gridViewTextBoxColumn1.HeaderText = "ردیف";
            gridViewTextBoxColumn1.Name = "Radif";
            gridViewTextBoxColumn1.Width = 75;
            gridViewTextBoxColumn2.DataType = typeof(int);
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "SystemCode";
            gridViewTextBoxColumn2.HeaderText = "کد سیستمی";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "SystemCode";
            gridViewTextBoxColumn2.Width = 52;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.FieldName = "UserCode";
            gridViewDecimalColumn1.HeaderText = "کد کاربر";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "UserCode";
            gridViewDecimalColumn1.Width = 89;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "UserFullName";
            gridViewTextBoxColumn3.HeaderText = "کاربر";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "UserFullName";
            gridViewTextBoxColumn3.Width = 112;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Unit";
            gridViewTextBoxColumn4.HeaderText = "واحد";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Unit";
            gridViewTextBoxColumn4.Width = 124;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Operation";
            gridViewTextBoxColumn5.HeaderText = "عملیات انجام شده";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Operation";
            gridViewTextBoxColumn5.Width = 124;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "OperationCode";
            gridViewTextBoxColumn6.HeaderText = "کد";
            gridViewTextBoxColumn6.Name = "OperationCode";
            gridViewTextBoxColumn6.Width = 60;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Description";
            gridViewTextBoxColumn7.HeaderText = "شرح";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "Description";
            gridViewTextBoxColumn7.Width = 173;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Date";
            gridViewTextBoxColumn8.HeaderText = "تاریخ";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "Date";
            gridViewTextBoxColumn8.Width = 79;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Time";
            gridViewTextBoxColumn9.HeaderText = "ساعت";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "Time";
            gridViewTextBoxColumn9.Width = 46;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "IPAddress";
            gridViewTextBoxColumn10.HeaderText = "IPAddress";
            gridViewTextBoxColumn10.Name = "IPAddress";
            gridViewTextBoxColumn10.Width = 57;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "ArchiveID";
            gridViewTextBoxColumn11.HeaderText = "نام بایگانی";
            gridViewTextBoxColumn11.Name = "ArchiveID";
            gridViewTextBoxColumn11.Width = 60;
            this.radGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11});
            this.radGridView.MasterTemplate.DataSource = this.userLogBindingSource;
            this.radGridView.MasterTemplate.EnableFiltering = true;
            this.radGridView.MasterTemplate.MultiSelect = true;
            this.radGridView.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView.Name = "radGridView";
            this.radGridView.ReadOnly = true;
            this.radGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView.Size = new System.Drawing.Size(922, 272);
            this.radGridView.TabIndex = 3;
            // 
            // UserLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 515);
            this.Name = "UserLog";
            this.Text = "عملکرد کاربران";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource userLogBindingSource;
        private System.Windows.Forms.BindingSource membershipBindingSource;
        private Njit.Program.Controls.ComboBoxExtended comboBoxUsers;
        private Njit.Program.Controls.DateControl dateToTextBox;
        private Njit.Program.Controls.DateControl dateFromTextBox;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridView;
    }
}