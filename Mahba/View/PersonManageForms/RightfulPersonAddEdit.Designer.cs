namespace NjitSoftware.View.PersonManageForms
{
    partial class RightfulPersonAddEdit
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
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label birthdateLabel;
            System.Windows.Forms.Label fathernameLabel;
            System.Windows.Forms.Label firstnameLabel;
            System.Windows.Forms.Label identityNumberLabel;
            System.Windows.Forms.Label lastnameLabel;
            System.Windows.Forms.Label nationalCodeLabel;
            System.Windows.Forms.Label telLabel;
            System.Windows.Forms.Label mobileLabel;
            System.Windows.Forms.Label workAddressLabel;
            System.Windows.Forms.Label backAccountLabel;
            this.addressTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.rightfulPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.birthdateTextBox = new Njit.Program.Controls.DateControl();
            this.fathernameTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.firstnameTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.identityNumberTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.lastnameTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.nationalCodeTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.telTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.mobileTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.workAddressTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.backAccountTextBox = new Njit.Program.Controls.TextBoxExtended();
            addressLabel = new System.Windows.Forms.Label();
            birthdateLabel = new System.Windows.Forms.Label();
            fathernameLabel = new System.Windows.Forms.Label();
            firstnameLabel = new System.Windows.Forms.Label();
            identityNumberLabel = new System.Windows.Forms.Label();
            lastnameLabel = new System.Windows.Forms.Label();
            nationalCodeLabel = new System.Windows.Forms.Label();
            telLabel = new System.Windows.Forms.Label();
            mobileLabel = new System.Windows.Forms.Label();
            workAddressLabel = new System.Windows.Forms.Label();
            backAccountLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightfulPersonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(637, 203);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 203);
            this.panelCommand.Size = new System.Drawing.Size(637, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(backAccountLabel);
            this.groupBoxMain.Controls.Add(this.backAccountTextBox);
            this.groupBoxMain.Controls.Add(workAddressLabel);
            this.groupBoxMain.Controls.Add(this.workAddressTextBox);
            this.groupBoxMain.Controls.Add(mobileLabel);
            this.groupBoxMain.Controls.Add(this.mobileTextBox);
            this.groupBoxMain.Controls.Add(addressLabel);
            this.groupBoxMain.Controls.Add(this.addressTextBox);
            this.groupBoxMain.Controls.Add(birthdateLabel);
            this.groupBoxMain.Controls.Add(this.birthdateTextBox);
            this.groupBoxMain.Controls.Add(fathernameLabel);
            this.groupBoxMain.Controls.Add(this.fathernameTextBox);
            this.groupBoxMain.Controls.Add(firstnameLabel);
            this.groupBoxMain.Controls.Add(this.firstnameTextBox);
            this.groupBoxMain.Controls.Add(identityNumberLabel);
            this.groupBoxMain.Controls.Add(this.identityNumberTextBox);
            this.groupBoxMain.Controls.Add(lastnameLabel);
            this.groupBoxMain.Controls.Add(this.lastnameTextBox);
            this.groupBoxMain.Controls.Add(nationalCodeLabel);
            this.groupBoxMain.Controls.Add(this.nationalCodeTextBox);
            this.groupBoxMain.Controls.Add(telLabel);
            this.groupBoxMain.Controls.Add(this.telTextBox);
            this.groupBoxMain.Size = new System.Drawing.Size(617, 200);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(474, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(549, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(532, 113);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(39, 14);
            addressLabel.TabIndex = 12;
            addressLabel.Text = "آدرس:";
            // 
            // birthdateLabel
            // 
            birthdateLabel.AutoSize = true;
            birthdateLabel.Location = new System.Drawing.Point(210, 85);
            birthdateLabel.Name = "birthdateLabel";
            birthdateLabel.Size = new System.Drawing.Size(55, 14);
            birthdateLabel.TabIndex = 10;
            birthdateLabel.Text = "تاریخ تولد:";
            // 
            // fathernameLabel
            // 
            fathernameLabel.AutoSize = true;
            fathernameLabel.Location = new System.Drawing.Point(532, 57);
            fathernameLabel.Name = "fathernameLabel";
            fathernameLabel.Size = new System.Drawing.Size(43, 14);
            fathernameLabel.TabIndex = 4;
            fathernameLabel.Text = "نام پدر:";
            // 
            // firstnameLabel
            // 
            firstnameLabel.AutoSize = true;
            firstnameLabel.Location = new System.Drawing.Point(532, 29);
            firstnameLabel.Name = "firstnameLabel";
            firstnameLabel.Size = new System.Drawing.Size(25, 14);
            firstnameLabel.TabIndex = 0;
            firstnameLabel.Text = "نام:";
            // 
            // identityNumberLabel
            // 
            identityNumberLabel.AutoSize = true;
            identityNumberLabel.Location = new System.Drawing.Point(210, 57);
            identityNumberLabel.Name = "identityNumberLabel";
            identityNumberLabel.Size = new System.Drawing.Size(101, 14);
            identityNumberLabel.TabIndex = 6;
            identityNumberLabel.Text = "شماره شناسنامه:";
            // 
            // lastnameLabel
            // 
            lastnameLabel.AutoSize = true;
            lastnameLabel.Location = new System.Drawing.Point(210, 32);
            lastnameLabel.Name = "lastnameLabel";
            lastnameLabel.Size = new System.Drawing.Size(76, 14);
            lastnameLabel.TabIndex = 2;
            lastnameLabel.Text = "نام خانوادگی:";
            // 
            // nationalCodeLabel
            // 
            nationalCodeLabel.AutoSize = true;
            nationalCodeLabel.Location = new System.Drawing.Point(532, 85);
            nationalCodeLabel.Name = "nationalCodeLabel";
            nationalCodeLabel.Size = new System.Drawing.Size(50, 14);
            nationalCodeLabel.TabIndex = 8;
            nationalCodeLabel.Text = "کد ملی:";
            // 
            // telLabel
            // 
            telLabel.AutoSize = true;
            telLabel.Location = new System.Drawing.Point(210, 113);
            telLabel.Name = "telLabel";
            telLabel.Size = new System.Drawing.Size(58, 14);
            telLabel.TabIndex = 14;
            telLabel.Text = "تلفن ثابت:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(317, 110);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(209, 22);
            this.addressTextBox.TabIndex = 13;
            // 
            // rightfulPersonBindingSource
            // 
            this.rightfulPersonBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.RightfulPerson);
            // 
            // birthdateTextBox
            // 
            this.birthdateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "Birthdate", true));
            this.birthdateTextBox.Location = new System.Drawing.Point(9, 79);
            this.birthdateTextBox.Name = "birthdateTextBox";
            this.birthdateTextBox.Size = new System.Drawing.Size(195, 22);
            this.birthdateTextBox.TabIndex = 11;
            // 
            // fathernameTextBox
            // 
            this.fathernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "Fathername", true));
            this.fathernameTextBox.Location = new System.Drawing.Point(317, 54);
            this.fathernameTextBox.Name = "fathernameTextBox";
            this.fathernameTextBox.Size = new System.Drawing.Size(209, 22);
            this.fathernameTextBox.TabIndex = 5;
            // 
            // firstnameTextBox
            // 
            this.firstnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "Firstname", true));
            this.firstnameTextBox.Location = new System.Drawing.Point(317, 26);
            this.firstnameTextBox.Name = "firstnameTextBox";
            this.firstnameTextBox.Size = new System.Drawing.Size(209, 22);
            this.firstnameTextBox.TabIndex = 1;
            // 
            // identityNumberTextBox
            // 
            this.identityNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "IdentityNumber", true));
            this.identityNumberTextBox.Location = new System.Drawing.Point(9, 51);
            this.identityNumberTextBox.Name = "identityNumberTextBox";
            this.identityNumberTextBox.Size = new System.Drawing.Size(195, 22);
            this.identityNumberTextBox.TabIndex = 7;
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "Lastname", true));
            this.lastnameTextBox.Location = new System.Drawing.Point(9, 26);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(195, 22);
            this.lastnameTextBox.TabIndex = 3;
            // 
            // nationalCodeTextBox
            // 
            this.nationalCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "NationalCode", true));
            this.nationalCodeTextBox.Location = new System.Drawing.Point(317, 82);
            this.nationalCodeTextBox.Name = "nationalCodeTextBox";
            this.nationalCodeTextBox.Size = new System.Drawing.Size(209, 22);
            this.nationalCodeTextBox.TabIndex = 9;
            // 
            // telTextBox
            // 
            this.telTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "Tel", true));
            this.telTextBox.Location = new System.Drawing.Point(9, 107);
            this.telTextBox.Name = "telTextBox";
            this.telTextBox.Size = new System.Drawing.Size(195, 22);
            this.telTextBox.TabIndex = 15;
            // 
            // mobileLabel
            // 
            mobileLabel.AutoSize = true;
            mobileLabel.Location = new System.Drawing.Point(532, 141);
            mobileLabel.Name = "mobileLabel";
            mobileLabel.Size = new System.Drawing.Size(77, 14);
            mobileLabel.TabIndex = 16;
            mobileLabel.Text = "شماره همراه:";
            // 
            // mobileTextBox
            // 
            this.mobileTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "Mobile", true));
            this.mobileTextBox.Location = new System.Drawing.Point(317, 138);
            this.mobileTextBox.Name = "mobileTextBox";
            this.mobileTextBox.Size = new System.Drawing.Size(209, 22);
            this.mobileTextBox.TabIndex = 17;
            // 
            // workAddressLabel
            // 
            workAddressLabel.AutoSize = true;
            workAddressLabel.Location = new System.Drawing.Point(210, 138);
            workAddressLabel.Name = "workAddressLabel";
            workAddressLabel.Size = new System.Drawing.Size(52, 14);
            workAddressLabel.TabIndex = 18;
            workAddressLabel.Text = "محل کار:";
            // 
            // workAddressTextBox
            // 
            this.workAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "WorkAddress", true));
            this.workAddressTextBox.Location = new System.Drawing.Point(9, 135);
            this.workAddressTextBox.Name = "workAddressTextBox";
            this.workAddressTextBox.Size = new System.Drawing.Size(195, 22);
            this.workAddressTextBox.TabIndex = 19;
            // 
            // backAccountLabel
            // 
            backAccountLabel.AutoSize = true;
            backAccountLabel.Location = new System.Drawing.Point(532, 169);
            backAccountLabel.Name = "backAccountLabel";
            backAccountLabel.Size = new System.Drawing.Size(78, 14);
            backAccountLabel.TabIndex = 20;
            backAccountLabel.Text = "حساب بانکی:";
            // 
            // backAccountTextBox
            // 
            this.backAccountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.rightfulPersonBindingSource, "BackAccount", true));
            this.backAccountTextBox.Location = new System.Drawing.Point(317, 166);
            this.backAccountTextBox.Name = "backAccountTextBox";
            this.backAccountTextBox.Size = new System.Drawing.Size(209, 22);
            this.backAccountTextBox.TabIndex = 21;
            // 
            // RightfulPersonAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 232);
            this.Name = "RightfulPersonAddEdit";
            this.Text = "اطلاعات شخص حقیقی";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightfulPersonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.TextBoxExtended addressTextBox;
        private System.Windows.Forms.BindingSource rightfulPersonBindingSource;
        private Njit.Program.Controls.DateControl birthdateTextBox;
        private Njit.Program.Controls.TextBoxExtended fathernameTextBox;
        private Njit.Program.Controls.TextBoxExtended firstnameTextBox;
        private Njit.Program.Controls.TextBoxExtended identityNumberTextBox;
        private Njit.Program.Controls.TextBoxExtended lastnameTextBox;
        private Njit.Program.Controls.TextBoxExtended nationalCodeTextBox;
        private Njit.Program.Controls.TextBoxExtended telTextBox;
        private Njit.Program.Controls.TextBoxExtended backAccountTextBox;
        private Njit.Program.Controls.TextBoxExtended workAddressTextBox;
        private Njit.Program.Controls.TextBoxExtended mobileTextBox;
    }
}