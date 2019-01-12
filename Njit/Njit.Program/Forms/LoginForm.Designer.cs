namespace Njit.Program.Forms
{
    partial class LoginForm
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
            this.usersComboBox = new Njit.Program.Controls.ComboBoxExtended();
            this.passwordTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnOK = new Njit.Program.Controls.ButtonExtended();
            this.btnCancel = new Njit.Program.Controls.ButtonExtended();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.linkLabelNetwork = new System.Windows.Forms.LinkLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // usersComboBox
            // 
            this.usersComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.usersComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.usersComboBox.FormattingEnabled = true;
            this.usersComboBox.Location = new System.Drawing.Point(119, 72);
            this.usersComboBox.Name = "usersComboBox";
            this.usersComboBox.Size = new System.Drawing.Size(194, 22);
            this.usersComboBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Location = new System.Drawing.Point(125, 103);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(182, 15);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.WaterMark = "رمزعبور را اینجا وارد کنید";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(94, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(281, 14);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "لطفا کاربر مورد نظر را انتخاب کنید و رمز عبور را وارد کنید";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(318, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "ورود";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(243, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.linkLabelNetwork);
            this.buttonsPanel.Controls.Add(this.btnCancel);
            this.buttonsPanel.Controls.Add(this.btnOK);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 176);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.buttonsPanel.Size = new System.Drawing.Size(408, 29);
            this.buttonsPanel.TabIndex = 3;
            // 
            // linkLabelNetwork
            // 
            this.linkLabelNetwork.AutoSize = true;
            this.linkLabelNetwork.Location = new System.Drawing.Point(51, 7);
            this.linkLabelNetwork.Name = "linkLabelNetwork";
            this.linkLabelNetwork.Size = new System.Drawing.Size(106, 14);
            this.linkLabelNetwork.TabIndex = 2;
            this.linkLabelNetwork.TabStop = true;
            this.linkLabelNetwork.Text = "تغییر تنظیمات شبکه";
            this.linkLabelNetwork.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNetwork_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.RightToLeft = true;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Njit.Program.Properties.Resources.Loginback;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(408, 205);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usersComboBox);
            this.DoubleBuffered = true;
            this.Name = "LoginForm";
            this.RightToLeftLayout = false;
            this.Text = "ورود به سیستم";
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Njit.Program.Controls.ComboBoxExtended usersComboBox;
        protected Njit.Program.Controls.TextBoxExtended passwordTextBox;
        protected System.Windows.Forms.Label titleLabel;
        protected Njit.Program.Controls.ButtonExtended btnOK;
        protected Njit.Program.Controls.ButtonExtended btnCancel;
        protected System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel linkLabelNetwork;

    }
}