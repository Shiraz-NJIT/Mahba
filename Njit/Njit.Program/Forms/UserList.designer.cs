namespace Njit.Program.Forms
{
    partial class UserList
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
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label labelRole;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.roleComboBox = new Njit.Program.Controls.ComboBoxExtended();
            this.groupBoxState = new System.Windows.Forms.GroupBox();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.fullNameTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.usersComboBox = new Njit.Program.Controls.ComboBoxExtended();
            this.lblLine = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbGuest = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExpire = new System.Windows.Forms.Label();
            this.txtExpire = new Njit.Program.Controls.DateControl();
            fullNameLabel = new System.Windows.Forms.Label();
            labelRole = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBoxState.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(455, 303);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 303);
            this.panelCommand.Size = new System.Drawing.Size(455, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label3);
            this.groupBoxMain.Controls.Add(this.groupBox1);
            this.groupBoxMain.Controls.Add(this.lblLine);
            this.groupBoxMain.Controls.Add(this.usersComboBox);
            this.groupBoxMain.Controls.Add(label2);
            this.groupBoxMain.Controls.Add(label1);
            this.groupBoxMain.Size = new System.Drawing.Size(435, 300);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(292, 3);
            this.btnCancel.Text = "خروج";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(367, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(298, 27);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(25, 14);
            fullNameLabel.TabIndex = 0;
            fullNameLabel.Text = "نام:";
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new System.Drawing.Point(298, 115);
            labelRole.Name = "labelRole";
            labelRole.Size = new System.Drawing.Size(59, 14);
            labelRole.TabIndex = 3;
            labelRole.Text = "گروه کاربر:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(389, 48);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 14);
            label1.TabIndex = 1;
            label1.Text = "کاربر:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(272, 18);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(150, 14);
            label2.TabIndex = 0;
            label2.Text = "کاربر مورد نظر را انتخاب کنید:";
            // 
            // roleComboBox
            // 
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(7, 112);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(285, 22);
            this.roleComboBox.TabIndex = 4;
            // 
            // groupBoxState
            // 
            this.groupBoxState.Controls.Add(this.radioButtonInactive);
            this.groupBoxState.Controls.Add(this.radioButtonActive);
            this.groupBoxState.Location = new System.Drawing.Point(7, 52);
            this.groupBoxState.Name = "groupBoxState";
            this.groupBoxState.Size = new System.Drawing.Size(285, 54);
            this.groupBoxState.TabIndex = 2;
            this.groupBoxState.TabStop = false;
            this.groupBoxState.Text = "وضعیت کاربر";
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.AutoSize = true;
            this.radioButtonInactive.Location = new System.Drawing.Point(128, 24);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Size = new System.Drawing.Size(68, 18);
            this.radioButtonInactive.TabIndex = 1;
            this.radioButtonInactive.Text = "غیر فعال";
            this.radioButtonInactive.UseVisualStyleBackColor = true;
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.AutoSize = true;
            this.radioButtonActive.Checked = true;
            this.radioButtonActive.Location = new System.Drawing.Point(202, 24);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(48, 18);
            this.radioButtonActive.TabIndex = 0;
            this.radioButtonActive.TabStop = true;
            this.radioButtonActive.Text = "فعال";
            this.radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(7, 24);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(285, 22);
            this.fullNameTextBox.TabIndex = 1;
            // 
            // usersComboBox
            // 
            this.usersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usersComboBox.FormattingEnabled = true;
            this.usersComboBox.Location = new System.Drawing.Point(98, 45);
            this.usersComboBox.Name = "usersComboBox";
            this.usersComboBox.Size = new System.Drawing.Size(285, 22);
            this.usersComboBox.TabIndex = 2;
            this.usersComboBox.SelectedValueChanged += new System.EventHandler(this.usersComboBox_SelectedValueChanged);
            // 
            // lblLine
            // 
            this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLine.Location = new System.Drawing.Point(19, 80);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(371, 2);
            this.lblLine.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGuest);
            this.groupBox1.Controls.Add(this.txtExpire);
            this.groupBox1.Controls.Add(this.lblExpire);
            this.groupBox1.Controls.Add(this.fullNameTextBox);
            this.groupBox1.Controls.Add(labelRole);
            this.groupBox1.Controls.Add(fullNameLabel);
            this.groupBox1.Controls.Add(this.roleComboBox);
            this.groupBox1.Controls.Add(this.groupBoxState);
            this.groupBox1.Location = new System.Drawing.Point(19, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 198);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات کاربر انتخاب شده";
            // 
            // cbGuest
            // 
            this.cbGuest.AutoSize = true;
            this.cbGuest.Location = new System.Drawing.Point(204, 143);
            this.cbGuest.Name = "cbGuest";
            this.cbGuest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbGuest.Size = new System.Drawing.Size(88, 18);
            this.cbGuest.TabIndex = 26;
            this.cbGuest.Text = "کاربر میهمان";
            this.cbGuest.UseVisualStyleBackColor = true;
            this.cbGuest.CheckedChanged += new System.EventHandler(this.cbGuest_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 14);
            this.label3.TabIndex = 25;
            // 
            // lblExpire
            // 
            this.lblExpire.AutoSize = true;
            this.lblExpire.Enabled = false;
            this.lblExpire.Location = new System.Drawing.Point(298, 170);
            this.lblExpire.Name = "lblExpire";
            this.lblExpire.Size = new System.Drawing.Size(62, 14);
            this.lblExpire.TabIndex = 24;
            this.lblExpire.Text = "تاریخ انقضا:";
            this.lblExpire.Visible = false;
            // 
            // txtExpire
            // 
            this.txtExpire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpire.Enabled = false;
            this.txtExpire.Location = new System.Drawing.Point(171, 167);
            this.txtExpire.Name = "txtExpire";
            this.txtExpire.Size = new System.Drawing.Size(121, 22);
            this.txtExpire.TabIndex = 23;
            this.txtExpire.Visible = false;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 332);
            this.Name = "UserList";
            this.Text = "اطلاعات کاربران";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.ComboBoxExtended usersComboBox;
        protected Controls.ComboBoxExtended roleComboBox;
        protected System.Windows.Forms.GroupBox groupBoxState;
        protected System.Windows.Forms.RadioButton radioButtonInactive;
        protected System.Windows.Forms.RadioButton radioButtonActive;
        protected Controls.TextBoxExtended fullNameTextBox;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.CheckBox cbGuest;
        protected Controls.DateControl txtExpire;
        private System.Windows.Forms.Label lblExpire;

    }
}