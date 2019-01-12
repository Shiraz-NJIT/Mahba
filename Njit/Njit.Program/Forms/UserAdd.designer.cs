namespace Njit.Program.Forms
{
    partial class UserAdd
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
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label passwordConfirmLabel;
            System.Windows.Forms.Label roleLabel;
            this.fullNameTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.passwordTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.passwordConfirmTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.groupBoxState = new System.Windows.Forms.GroupBox();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.roleComboBox = new Njit.Program.Controls.ComboBoxExtended();
            this.cbGuest = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExpire = new System.Windows.Forms.Label();
            this.txtExpire = new Njit.Program.Controls.DateControl();
            fullNameLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            passwordConfirmLabel = new System.Windows.Forms.Label();
            roleLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBoxState.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(560, 249);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 249);
            this.panelCommand.Size = new System.Drawing.Size(560, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.cbGuest);
            this.groupBoxMain.Controls.Add(this.label2);
            this.groupBoxMain.Controls.Add(this.lblExpire);
            this.groupBoxMain.Controls.Add(this.txtExpire);
            this.groupBoxMain.Controls.Add(this.roleComboBox);
            this.groupBoxMain.Controls.Add(this.groupBoxState);
            this.groupBoxMain.Controls.Add(fullNameLabel);
            this.groupBoxMain.Controls.Add(this.fullNameTextBox);
            this.groupBoxMain.Controls.Add(roleLabel);
            this.groupBoxMain.Controls.Add(passwordConfirmLabel);
            this.groupBoxMain.Controls.Add(passwordLabel);
            this.groupBoxMain.Controls.Add(this.passwordConfirmTextBox);
            this.groupBoxMain.Controls.Add(this.passwordTextBox);
            this.groupBoxMain.Size = new System.Drawing.Size(540, 246);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(397, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(472, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(360, 24);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(25, 14);
            fullNameLabel.TabIndex = 0;
            fullNameLabel.Text = "نام:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(360, 52);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(46, 14);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "رمزعبور:";
            // 
            // passwordConfirmLabel
            // 
            passwordConfirmLabel.AutoSize = true;
            passwordConfirmLabel.Location = new System.Drawing.Point(360, 80);
            passwordConfirmLabel.Name = "passwordConfirmLabel";
            passwordConfirmLabel.Size = new System.Drawing.Size(71, 14);
            passwordConfirmLabel.TabIndex = 4;
            passwordConfirmLabel.Text = "تکرار رمزعبور:";
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Location = new System.Drawing.Point(360, 168);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new System.Drawing.Size(59, 14);
            roleLabel.TabIndex = 7;
            roleLabel.Text = "گروه کاربر:";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(69, 21);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(285, 22);
            this.fullNameTextBox.TabIndex = 1;
            this.fullNameTextBox.WaterMark = "نام کاربر را وارد کنید";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(69, 49);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(285, 22);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.WaterMark = "رمز عبور را وارد کنید";
            // 
            // passwordConfirmTextBox
            // 
            this.passwordConfirmTextBox.Location = new System.Drawing.Point(69, 77);
            this.passwordConfirmTextBox.Name = "passwordConfirmTextBox";
            this.passwordConfirmTextBox.Size = new System.Drawing.Size(285, 22);
            this.passwordConfirmTextBox.TabIndex = 5;
            this.passwordConfirmTextBox.UseSystemPasswordChar = true;
            this.passwordConfirmTextBox.WaterMark = "رمز عبور را مجددا وارد کنید";
            // 
            // groupBoxState
            // 
            this.groupBoxState.Controls.Add(this.radioButtonInactive);
            this.groupBoxState.Controls.Add(this.radioButtonActive);
            this.groupBoxState.Location = new System.Drawing.Point(69, 105);
            this.groupBoxState.Name = "groupBoxState";
            this.groupBoxState.Size = new System.Drawing.Size(285, 54);
            this.groupBoxState.TabIndex = 6;
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
            // roleComboBox
            // 
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Location = new System.Drawing.Point(69, 165);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(285, 22);
            this.roleComboBox.TabIndex = 8;
            // 
            // cbGuest
            // 
            this.cbGuest.AutoSize = true;
            this.cbGuest.Location = new System.Drawing.Point(266, 199);
            this.cbGuest.Name = "cbGuest";
            this.cbGuest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbGuest.Size = new System.Drawing.Size(88, 18);
            this.cbGuest.TabIndex = 22;
            this.cbGuest.Text = "کاربر میهمان";
            this.cbGuest.UseVisualStyleBackColor = true;
            this.cbGuest.CheckedChanged += new System.EventHandler(this.cbGuest_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 21;
            // 
            // lblExpire
            // 
            this.lblExpire.AutoSize = true;
            this.lblExpire.Enabled = false;
            this.lblExpire.Location = new System.Drawing.Point(357, 225);
            this.lblExpire.Name = "lblExpire";
            this.lblExpire.Size = new System.Drawing.Size(62, 14);
            this.lblExpire.TabIndex = 20;
            this.lblExpire.Text = "تاریخ انقضا:";
            this.lblExpire.Visible = false;
            // 
            // txtExpire
            // 
            this.txtExpire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpire.Enabled = false;
            this.txtExpire.Location = new System.Drawing.Point(230, 219);
            this.txtExpire.Name = "txtExpire";
            this.txtExpire.Size = new System.Drawing.Size(121, 22);
            this.txtExpire.TabIndex = 19;
            this.txtExpire.Visible = false;
            // 
            // UserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 278);
            this.Name = "UserAdd";
            this.Text = "ثبت کاربر جدید";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.ComboBoxExtended roleComboBox;
        protected System.Windows.Forms.GroupBox groupBoxState;
        protected System.Windows.Forms.RadioButton radioButtonInactive;
        protected System.Windows.Forms.RadioButton radioButtonActive;
        protected Controls.TextBoxExtended fullNameTextBox;
        protected Controls.TextBoxExtended passwordConfirmTextBox;
        protected Controls.TextBoxExtended passwordTextBox;
        private System.Windows.Forms.CheckBox cbGuest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExpire;
        private Controls.DateControl txtExpire;

    }
}