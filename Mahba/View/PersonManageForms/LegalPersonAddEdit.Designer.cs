namespace NjitSoftware.View.PersonManageForms
{
    partial class LegalPersonAddEdit
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
            System.Windows.Forms.Label companyNumberLabel;
            System.Windows.Forms.Label economicNumberLabel;
            System.Windows.Forms.Label managerLabel;
            System.Windows.Forms.Label managerTelLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label telLabel;
            this.legalPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addressTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.companyNumberTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.economicNumberTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.managerTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.managerTelTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.nameTextBox = new Njit.Program.Controls.TextBoxExtended();
            this.telTextBox = new Njit.Program.Controls.TextBoxExtended();
            addressLabel = new System.Windows.Forms.Label();
            companyNumberLabel = new System.Windows.Forms.Label();
            economicNumberLabel = new System.Windows.Forms.Label();
            managerLabel = new System.Windows.Forms.Label();
            managerTelLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            telLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legalPersonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(609, 173);
            // 
            // panelCommand
            // 
            this.panelCommand.Size = new System.Drawing.Size(609, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(addressLabel);
            this.groupBoxMain.Controls.Add(this.addressTextBox);
            this.groupBoxMain.Controls.Add(companyNumberLabel);
            this.groupBoxMain.Controls.Add(this.companyNumberTextBox);
            this.groupBoxMain.Controls.Add(economicNumberLabel);
            this.groupBoxMain.Controls.Add(this.economicNumberTextBox);
            this.groupBoxMain.Controls.Add(managerLabel);
            this.groupBoxMain.Controls.Add(this.managerTextBox);
            this.groupBoxMain.Controls.Add(managerTelLabel);
            this.groupBoxMain.Controls.Add(this.managerTelTextBox);
            this.groupBoxMain.Controls.Add(nameLabel);
            this.groupBoxMain.Controls.Add(this.nameTextBox);
            this.groupBoxMain.Controls.Add(telLabel);
            this.groupBoxMain.Controls.Add(this.telTextBox);
            this.groupBoxMain.Size = new System.Drawing.Size(589, 170);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(446, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(521, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // legalPersonBindingSource
            // 
            this.legalPersonBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.LegalPerson);
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(509, 108);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(39, 14);
            addressLabel.TabIndex = 10;
            addressLabel.Text = "آدرس:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.legalPersonBindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(20, 105);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(483, 22);
            this.addressTextBox.TabIndex = 11;
            // 
            // companyNumberLabel
            // 
            companyNumberLabel.AutoSize = true;
            companyNumberLabel.Location = new System.Drawing.Point(509, 52);
            companyNumberLabel.Name = "companyNumberLabel";
            companyNumberLabel.Size = new System.Drawing.Size(66, 14);
            companyNumberLabel.TabIndex = 2;
            companyNumberLabel.Text = "شماره ثبت:";
            // 
            // companyNumberTextBox
            // 
            this.companyNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.legalPersonBindingSource, "CompanyNumber", true));
            this.companyNumberTextBox.Location = new System.Drawing.Point(302, 49);
            this.companyNumberTextBox.Name = "companyNumberTextBox";
            this.companyNumberTextBox.Size = new System.Drawing.Size(201, 22);
            this.companyNumberTextBox.TabIndex = 3;
            // 
            // economicNumberLabel
            // 
            economicNumberLabel.AutoSize = true;
            economicNumberLabel.Location = new System.Drawing.Point(204, 52);
            economicNumberLabel.Name = "economicNumberLabel";
            economicNumberLabel.Size = new System.Drawing.Size(69, 14);
            economicNumberLabel.TabIndex = 4;
            economicNumberLabel.Text = "کد اقتصادی:";
            // 
            // economicNumberTextBox
            // 
            this.economicNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.legalPersonBindingSource, "EconomicNumber", true));
            this.economicNumberTextBox.Location = new System.Drawing.Point(20, 49);
            this.economicNumberTextBox.Name = "economicNumberTextBox";
            this.economicNumberTextBox.Size = new System.Drawing.Size(178, 22);
            this.economicNumberTextBox.TabIndex = 5;
            // 
            // managerLabel
            // 
            managerLabel.AutoSize = true;
            managerLabel.Location = new System.Drawing.Point(509, 80);
            managerLabel.Name = "managerLabel";
            managerLabel.Size = new System.Drawing.Size(76, 14);
            managerLabel.TabIndex = 6;
            managerLabel.Text = "نام مدیرعامل:";
            // 
            // managerTextBox
            // 
            this.managerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.legalPersonBindingSource, "Manager", true));
            this.managerTextBox.Location = new System.Drawing.Point(302, 77);
            this.managerTextBox.Name = "managerTextBox";
            this.managerTextBox.Size = new System.Drawing.Size(201, 22);
            this.managerTextBox.TabIndex = 7;
            // 
            // managerTelLabel
            // 
            managerTelLabel.AutoSize = true;
            managerTelLabel.Location = new System.Drawing.Point(204, 80);
            managerTelLabel.Name = "managerTelLabel";
            managerTelLabel.Size = new System.Drawing.Size(88, 14);
            managerTelLabel.TabIndex = 8;
            managerTelLabel.Text = "تلفن مدیر عامل:";
            // 
            // managerTelTextBox
            // 
            this.managerTelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.legalPersonBindingSource, "ManagerTel", true));
            this.managerTelTextBox.Location = new System.Drawing.Point(20, 77);
            this.managerTelTextBox.Name = "managerTelTextBox";
            this.managerTelTextBox.Size = new System.Drawing.Size(178, 22);
            this.managerTelTextBox.TabIndex = 9;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(509, 24);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(25, 14);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "نام:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.legalPersonBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(20, 21);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(483, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // telLabel
            // 
            telLabel.AutoSize = true;
            telLabel.Location = new System.Drawing.Point(509, 136);
            telLabel.Name = "telLabel";
            telLabel.Size = new System.Drawing.Size(33, 14);
            telLabel.TabIndex = 12;
            telLabel.Text = "تلفن:";
            // 
            // telTextBox
            // 
            this.telTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.legalPersonBindingSource, "Tel", true));
            this.telTextBox.Location = new System.Drawing.Point(302, 133);
            this.telTextBox.Name = "telTextBox";
            this.telTextBox.Size = new System.Drawing.Size(201, 22);
            this.telTextBox.TabIndex = 13;
            // 
            // LegalPersonAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 202);
            this.Name = "LegalPersonAddEdit";
            this.Text = "اطلاعات شخص حقوقی";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legalPersonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.TextBoxExtended addressTextBox;
        private System.Windows.Forms.BindingSource legalPersonBindingSource;
        private Njit.Program.Controls.TextBoxExtended companyNumberTextBox;
        private Njit.Program.Controls.TextBoxExtended economicNumberTextBox;
        private Njit.Program.Controls.TextBoxExtended managerTextBox;
        private Njit.Program.Controls.TextBoxExtended managerTelTextBox;
        private Njit.Program.Controls.TextBoxExtended nameTextBox;
        private Njit.Program.Controls.TextBoxExtended telTextBox;

    }
}