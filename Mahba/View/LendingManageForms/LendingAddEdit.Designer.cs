namespace NjitSoftware.View.LendingManageForms
{
    partial class LendingAddEdit
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
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label durationDayLabel;
            System.Windows.Forms.Label durationHourLabel;
            System.Windows.Forms.Label intentionLabel;
            System.Windows.Forms.Label personIDLabel;
            System.Windows.Forms.Label timeLabel;
            this.dateDateControl = new Njit.Program.Controls.DateControl();
            this.lendingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.durationDayTextBoxExtended = new Njit.Program.Controls.TextBoxExtended();
            this.durationHourTextBoxExtended = new Njit.Program.Controls.TextBoxExtended();
            this.timeTimeControl = new Njit.Program.Controls.TimeControl();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSelectDossier = new Njit.Program.Controls.ButtonExtended();
            this.intentionComboBoxExtended = new Njit.Program.Controls.ComboBoxExtended();
            this.groupBoxDossier = new NjitSoftware.View.Controls.DossierInfo();
            this.cmPerson = new System.Windows.Forms.ComboBox();
            dateLabel = new System.Windows.Forms.Label();
            durationDayLabel = new System.Windows.Forms.Label();
            durationHourLabel = new System.Windows.Forms.Label();
            intentionLabel = new System.Windows.Forms.Label();
            personIDLabel = new System.Windows.Forms.Label();
            timeLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lendingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(617, 300);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 300);
            this.panelCommand.Size = new System.Drawing.Size(617, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.cmPerson);
            this.groupBoxMain.Controls.Add(this.intentionComboBoxExtended);
            this.groupBoxMain.Controls.Add(this.btnSelectDossier);
            this.groupBoxMain.Controls.Add(this.groupBoxDossier);
            this.groupBoxMain.Controls.Add(dateLabel);
            this.groupBoxMain.Controls.Add(this.dateDateControl);
            this.groupBoxMain.Controls.Add(durationDayLabel);
            this.groupBoxMain.Controls.Add(this.durationDayTextBoxExtended);
            this.groupBoxMain.Controls.Add(durationHourLabel);
            this.groupBoxMain.Controls.Add(this.durationHourTextBoxExtended);
            this.groupBoxMain.Controls.Add(intentionLabel);
            this.groupBoxMain.Controls.Add(personIDLabel);
            this.groupBoxMain.Controls.Add(timeLabel);
            this.groupBoxMain.Controls.Add(this.timeTimeControl);
            this.groupBoxMain.Controls.Add(this.lblTitle);
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.groupBoxMain.Size = new System.Drawing.Size(597, 297);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(454, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(529, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dateLabel
            // 
            dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(501, 208);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(33, 14);
            dateLabel.TabIndex = 5;
            dateLabel.Text = "تاریخ:";
            // 
            // durationDayLabel
            // 
            durationDayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            durationDayLabel.AutoSize = true;
            durationDayLabel.Location = new System.Drawing.Point(501, 264);
            durationDayLabel.Name = "durationDayLabel";
            durationDayLabel.Size = new System.Drawing.Size(82, 14);
            durationDayLabel.TabIndex = 11;
            durationDayLabel.Text = "مدت روز امانت:";
            // 
            // durationHourLabel
            // 
            durationHourLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            durationHourLabel.AutoSize = true;
            durationHourLabel.Location = new System.Drawing.Point(253, 264);
            durationHourLabel.Name = "durationHourLabel";
            durationHourLabel.Size = new System.Drawing.Size(103, 14);
            durationHourLabel.TabIndex = 13;
            durationHourLabel.Text = "مدت ساعت امانت:";
            // 
            // intentionLabel
            // 
            intentionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            intentionLabel.AutoSize = true;
            intentionLabel.Location = new System.Drawing.Point(501, 236);
            intentionLabel.Name = "intentionLabel";
            intentionLabel.Size = new System.Drawing.Size(63, 14);
            intentionLabel.TabIndex = 9;
            intentionLabel.Text = "قصد امانت:";
            // 
            // personIDLabel
            // 
            personIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            personIDLabel.AutoSize = true;
            personIDLabel.Location = new System.Drawing.Point(501, 180);
            personIDLabel.Name = "personIDLabel";
            personIDLabel.Size = new System.Drawing.Size(73, 14);
            personIDLabel.TabIndex = 3;
            personIDLabel.Text = "امانت گیرنده:";
            // 
            // timeLabel
            // 
            timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            timeLabel.AutoSize = true;
            timeLabel.Location = new System.Drawing.Point(223, 208);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(45, 14);
            timeLabel.TabIndex = 7;
            timeLabel.Text = "ساعت:";
            // 
            // dateDateControl
            // 
            this.dateDateControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDateControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lendingBindingSource, "Date", true));
            this.dateDateControl.Location = new System.Drawing.Point(395, 205);
            this.dateDateControl.Name = "dateDateControl";
            this.dateDateControl.Size = new System.Drawing.Size(100, 22);
            this.dateDateControl.TabIndex = 6;
            // 
            // lendingBindingSource
            // 
            this.lendingBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.Lending);
            // 
            // durationDayTextBoxExtended
            // 
            this.durationDayTextBoxExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.durationDayTextBoxExtended.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lendingBindingSource, "DurationDay", true));
            this.durationDayTextBoxExtended.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Int;
            this.durationDayTextBoxExtended.Location = new System.Drawing.Point(395, 261);
            this.durationDayTextBoxExtended.MaxValue = 10000D;
            this.durationDayTextBoxExtended.MinValue = 0D;
            this.durationDayTextBoxExtended.Name = "durationDayTextBoxExtended";
            this.durationDayTextBoxExtended.Size = new System.Drawing.Size(100, 22);
            this.durationDayTextBoxExtended.TabIndex = 12;
            this.durationDayTextBoxExtended.Text = "0";
            // 
            // durationHourTextBoxExtended
            // 
            this.durationHourTextBoxExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.durationHourTextBoxExtended.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lendingBindingSource, "DurationHour", true));
            this.durationHourTextBoxExtended.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Int;
            this.durationHourTextBoxExtended.Location = new System.Drawing.Point(147, 261);
            this.durationHourTextBoxExtended.MaxValue = 10000D;
            this.durationHourTextBoxExtended.MinValue = 0D;
            this.durationHourTextBoxExtended.Name = "durationHourTextBoxExtended";
            this.durationHourTextBoxExtended.Size = new System.Drawing.Size(100, 22);
            this.durationHourTextBoxExtended.TabIndex = 14;
            this.durationHourTextBoxExtended.Text = "0";
            // 
            // timeTimeControl
            // 
            this.timeTimeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTimeControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lendingBindingSource, "Time", true));
            this.timeTimeControl.Location = new System.Drawing.Point(147, 205);
            this.timeTimeControl.Name = "timeTimeControl";
            this.timeTimeControl.Size = new System.Drawing.Size(70, 22);
            this.timeTimeControl.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(13, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(577, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "مشخصات پرونده:";
            // 
            // btnSelectDossier
            // 
            this.btnSelectDossier.Location = new System.Drawing.Point(461, 18);
            this.btnSelectDossier.Name = "btnSelectDossier";
            this.btnSelectDossier.Size = new System.Drawing.Size(126, 23);
            this.btnSelectDossier.TabIndex = 0;
            this.btnSelectDossier.Text = "انتخاب پرونده";
            this.btnSelectDossier.UseVisualStyleBackColor = true;
            this.btnSelectDossier.Click += new System.EventHandler(this.btnSelectDossier_Click);
            // 
            // intentionComboBoxExtended
            // 
            this.intentionComboBoxExtended.CaptionField = "Title";
            this.intentionComboBoxExtended.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lendingBindingSource, "Intention", true));
            this.intentionComboBoxExtended.EditItemsEnabled = true;
            this.intentionComboBoxExtended.FormattingEnabled = true;
            this.intentionComboBoxExtended.KeyField = "ID";
            this.intentionComboBoxExtended.Location = new System.Drawing.Point(147, 233);
            this.intentionComboBoxExtended.Name = "intentionComboBoxExtended";
            this.intentionComboBoxExtended.Size = new System.Drawing.Size(348, 22);
            this.intentionComboBoxExtended.TabIndex = 10;
            this.intentionComboBoxExtended.TableName = "LendingIntention";
            // 
            // groupBoxDossier
            // 
            this.groupBoxDossier.Location = new System.Drawing.Point(10, 70);
            this.groupBoxDossier.Name = "groupBoxDossier";
            this.groupBoxDossier.Size = new System.Drawing.Size(577, 92);
            this.groupBoxDossier.TabIndex = 2;
            // 
            // cmPerson
            // 
            this.cmPerson.FormattingEnabled = true;
            this.cmPerson.Location = new System.Drawing.Point(147, 180);
            this.cmPerson.Name = "cmPerson";
            this.cmPerson.Size = new System.Drawing.Size(348, 22);
            this.cmPerson.TabIndex = 15;
            // 
            // LendingAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 329);
            this.Name = "LendingAddEdit";
            this.Text = "ثبت امانت";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lendingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.DateControl dateDateControl;
        private System.Windows.Forms.BindingSource lendingBindingSource;
        private Njit.Program.Controls.TextBoxExtended durationDayTextBoxExtended;
        private Njit.Program.Controls.TextBoxExtended durationHourTextBoxExtended;
        private Njit.Program.Controls.TimeControl timeTimeControl;
        private NjitSoftware.View.Controls.DossierInfo groupBoxDossier;
        private System.Windows.Forms.Label lblTitle;
        private Njit.Program.Controls.ButtonExtended btnSelectDossier;
        private Njit.Program.Controls.ComboBoxExtended intentionComboBoxExtended;
        private System.Windows.Forms.ComboBox cmPerson;

    }
}