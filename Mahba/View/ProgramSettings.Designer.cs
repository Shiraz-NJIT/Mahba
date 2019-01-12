namespace NjitSoftware.View
{
    partial class ProgramSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureSelectBoxLogo = new Njit.Controls.PictureSelectBox();
            this.txtOrganName = new Njit.Program.Controls.TextBoxExtended();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureSelectBoxBackground = new Njit.Controls.PictureSelectBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageSavePath = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMaxDocSize = new Njit.Program.Controls.TextBoxExtended();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbCompressionType = new Njit.Program.Controls.ComboBoxExtended();
            this.compressionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbDocumentsFormat = new Njit.Program.Controls.ComboBoxExtended();
            this.imageFormatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxDocumentsDatabases = new System.Windows.Forms.GroupBox();
            this.groupBoxDocumentsPath = new System.Windows.Forms.GroupBox();
            this.btnDocumentsPath = new Njit.Program.Controls.BrowseButton();
            this.txtDocumentsPath = new Njit.Program.Controls.TextBoxExtended();
            this.lblDocumentsPath = new System.Windows.Forms.Label();
            this.groupBoxBackupPath = new System.Windows.Forms.GroupBox();
            this.browseButtonBackup = new Njit.Program.Controls.BrowseButton();
            this.txtBackupPath = new Njit.Program.Controls.TextBoxExtended();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageArchive = new System.Windows.Forms.TabPage();
            this.groupBoxArchiveSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxShowContactTab = new System.Windows.Forms.CheckBox();
            this.txtPersonnelNumber_MaxLength = new Njit.Program.Controls.TextBoxExtended();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPersonnelNumber_MinLength = new Njit.Program.Controls.TextBoxExtended();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPersonnelNumber_Label = new Njit.Program.Controls.TextBoxExtended();
            this.label5 = new System.Windows.Forms.Label();
            this.chkShowBackupFormOnExit = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabControlExtended.SuspendLayout();
            this.tabPageProgramSettings.SuspendLayout();
            this.tabPageSavedResponse.SuspendLayout();
            this.panelSavedResponseActions.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageSavePath.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFormatBindingSource)).BeginInit();
            this.groupBoxDocumentsPath.SuspendLayout();
            this.groupBoxBackupPath.SuspendLayout();
            this.tabPageArchive.SuspendLayout();
            this.groupBoxArchiveSettings.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlExtended
            // 
            this.tabControlExtended.Controls.Add(this.tabPageArchive);
            this.tabControlExtended.Controls.Add(this.tabPageSavePath);
            this.tabControlExtended.Size = new System.Drawing.Size(758, 508);
            this.tabControlExtended.Controls.SetChildIndex(this.tabPageSavePath, 0);
            this.tabControlExtended.Controls.SetChildIndex(this.tabPageSavedResponse, 0);
            this.tabControlExtended.Controls.SetChildIndex(this.tabPageArchive, 0);
            this.tabControlExtended.Controls.SetChildIndex(this.tabPageProgramSettings, 0);
            // 
            // tabPageProgramSettings
            // 
            this.tabPageProgramSettings.Controls.Add(this.groupBox4);
            this.tabPageProgramSettings.Controls.Add(this.groupBox2);
            this.tabPageProgramSettings.Controls.Add(this.groupBox1);
            this.tabPageProgramSettings.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageProgramSettings.Size = new System.Drawing.Size(750, 481);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(784, 532);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 532);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Size = new System.Drawing.Size(764, 529);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureSelectBoxLogo);
            this.groupBox1.Controls.Add(this.txtOrganName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات شرکت / سازمان";
            // 
            // pictureSelectBoxLogo
            // 
            this.pictureSelectBoxLogo.Location = new System.Drawing.Point(418, 49);
            this.pictureSelectBoxLogo.MaxHeight = 300;
            this.pictureSelectBoxLogo.MaxWidth = 300;
            this.pictureSelectBoxLogo.Name = "pictureSelectBoxLogo";
            this.pictureSelectBoxLogo.Size = new System.Drawing.Size(164, 140);
            this.pictureSelectBoxLogo.TabIndex = 3;
            // 
            // txtOrganName
            // 
            this.txtOrganName.Location = new System.Drawing.Point(218, 21);
            this.txtOrganName.Name = "txtOrganName";
            this.txtOrganName.Size = new System.Drawing.Size(364, 22);
            this.txtOrganName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "آرم:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام شرکت / سازمان:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureSelectBoxBackground);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(10, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 207);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تصویر پس زمینه";
            // 
            // pictureSelectBoxBackground
            // 
            this.pictureSelectBoxBackground.Location = new System.Drawing.Point(218, 21);
            this.pictureSelectBoxBackground.MaxHeight = 768;
            this.pictureSelectBoxBackground.MaxWidth = 1024;
            this.pictureSelectBoxBackground.Name = "pictureSelectBoxBackground";
            this.pictureSelectBoxBackground.Size = new System.Drawing.Size(364, 180);
            this.pictureSelectBoxBackground.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "تصویر پس زمینه نرم افزار:";
            // 
            // tabPageSavePath
            // 
            this.tabPageSavePath.Controls.Add(this.groupBox5);
            this.tabPageSavePath.Controls.Add(this.groupBox3);
            this.tabPageSavePath.Controls.Add(this.groupBoxDocumentsDatabases);
            this.tabPageSavePath.Controls.Add(this.groupBoxDocumentsPath);
            this.tabPageSavePath.Controls.Add(this.groupBoxBackupPath);
            this.tabPageSavePath.Location = new System.Drawing.Point(4, 23);
            this.tabPageSavePath.Name = "tabPageSavePath";
            this.tabPageSavePath.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageSavePath.Size = new System.Drawing.Size(750, 481);
            this.tabPageSavePath.TabIndex = 2;
            this.tabPageSavePath.Text = "تنظیمات ذخیره سازی";
            this.tabPageSavePath.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtMaxDocSize);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(10, 342);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(730, 54);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "حجم اسناد";
            // 
            // txtMaxDocSize
            // 
            this.txtMaxDocSize.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Int;
            this.txtMaxDocSize.Location = new System.Drawing.Point(378, 21);
            this.txtMaxDocSize.Name = "txtMaxDocSize";
            this.txtMaxDocSize.Size = new System.Drawing.Size(119, 22);
            this.txtMaxDocSize.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(325, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 2;
            this.label11.Text = "کیلوبایت";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(503, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(214, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "حداکثر حجم قابل قبول برای ذخیره اسناد:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbCompressionType);
            this.groupBox3.Controls.Add(this.cmbDocumentsFormat);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(10, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(730, 92);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "فرمت ذخیره اسناد و نوع فشرده سازی";
            // 
            // cmbCompressionType
            // 
            this.cmbCompressionType.DataSource = this.compressionTypeBindingSource;
            this.cmbCompressionType.DisplayMember = "Title";
            this.cmbCompressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompressionType.FormattingEnabled = true;
            this.cmbCompressionType.Location = new System.Drawing.Point(351, 54);
            this.cmbCompressionType.Name = "cmbCompressionType";
            this.cmbCompressionType.Size = new System.Drawing.Size(247, 22);
            this.cmbCompressionType.TabIndex = 3;
            this.cmbCompressionType.ValueMember = "Code";
            // 
            // compressionTypeBindingSource
            // 
            this.compressionTypeBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.CompressionType);
            // 
            // cmbDocumentsFormat
            // 
            this.cmbDocumentsFormat.DataSource = this.imageFormatBindingSource;
            this.cmbDocumentsFormat.DisplayMember = "Title";
            this.cmbDocumentsFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentsFormat.FormattingEnabled = true;
            this.cmbDocumentsFormat.Location = new System.Drawing.Point(351, 26);
            this.cmbDocumentsFormat.Name = "cmbDocumentsFormat";
            this.cmbDocumentsFormat.Size = new System.Drawing.Size(247, 22);
            this.cmbDocumentsFormat.TabIndex = 1;
            this.cmbDocumentsFormat.ValueMember = "Code";
            // 
            // imageFormatBindingSource
            // 
            this.imageFormatBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.ImageFormat);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(604, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 14);
            this.label9.TabIndex = 2;
            this.label9.Text = "نوع فشرده سازی:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(604, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "فرمت ذخیره اسناد:";
            // 
            // groupBoxDocumentsDatabases
            // 
            this.groupBoxDocumentsDatabases.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDocumentsDatabases.Location = new System.Drawing.Point(10, 158);
            this.groupBoxDocumentsDatabases.Name = "groupBoxDocumentsDatabases";
            this.groupBoxDocumentsDatabases.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxDocumentsDatabases.Size = new System.Drawing.Size(730, 92);
            this.groupBoxDocumentsDatabases.TabIndex = 2;
            this.groupBoxDocumentsDatabases.TabStop = false;
            this.groupBoxDocumentsDatabases.Text = "پایگاه های داده اسناد";
            // 
            // groupBoxDocumentsPath
            // 
            this.groupBoxDocumentsPath.Controls.Add(this.btnDocumentsPath);
            this.groupBoxDocumentsPath.Controls.Add(this.lblDocumentsPath);
            this.groupBoxDocumentsPath.Controls.Add(this.txtDocumentsPath);
            this.groupBoxDocumentsPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDocumentsPath.Location = new System.Drawing.Point(10, 84);
            this.groupBoxDocumentsPath.Name = "groupBoxDocumentsPath";
            this.groupBoxDocumentsPath.Size = new System.Drawing.Size(730, 74);
            this.groupBoxDocumentsPath.TabIndex = 1;
            this.groupBoxDocumentsPath.TabStop = false;
            this.groupBoxDocumentsPath.Text = "مسیر ذخیره اسناد";
            // 
            // btnDocumentsPath
            // 
            this.btnDocumentsPath.Description = "مسیر ذخیره اسناد";
            this.btnDocumentsPath.Location = new System.Drawing.Point(47, 27);
            this.btnDocumentsPath.Name = "btnDocumentsPath";
            this.btnDocumentsPath.PathControl = this.txtDocumentsPath;
            this.btnDocumentsPath.Size = new System.Drawing.Size(109, 23);
            this.btnDocumentsPath.TabIndex = 2;
            this.btnDocumentsPath.Text = "انتخاب مسیر...";
            this.btnDocumentsPath.UseVisualStyleBackColor = true;
            // 
            // txtDocumentsPath
            // 
            this.txtDocumentsPath.Location = new System.Drawing.Point(162, 27);
            this.txtDocumentsPath.Name = "txtDocumentsPath";
            this.txtDocumentsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDocumentsPath.Size = new System.Drawing.Size(364, 22);
            this.txtDocumentsPath.TabIndex = 1;
            // 
            // lblDocumentsPath
            // 
            this.lblDocumentsPath.AutoSize = true;
            this.lblDocumentsPath.Location = new System.Drawing.Point(532, 31);
            this.lblDocumentsPath.Name = "lblDocumentsPath";
            this.lblDocumentsPath.Size = new System.Drawing.Size(185, 14);
            this.lblDocumentsPath.TabIndex = 0;
            this.lblDocumentsPath.Text = "مسیر پیش فرض برای ذخیره اسناد:";
            // 
            // groupBoxBackupPath
            // 
            this.groupBoxBackupPath.Controls.Add(this.browseButtonBackup);
            this.groupBoxBackupPath.Controls.Add(this.label4);
            this.groupBoxBackupPath.Controls.Add(this.txtBackupPath);
            this.groupBoxBackupPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBackupPath.Location = new System.Drawing.Point(10, 10);
            this.groupBoxBackupPath.Name = "groupBoxBackupPath";
            this.groupBoxBackupPath.Size = new System.Drawing.Size(730, 74);
            this.groupBoxBackupPath.TabIndex = 0;
            this.groupBoxBackupPath.TabStop = false;
            this.groupBoxBackupPath.Text = "مسیر ذخیره فایل های پشتیبان";
            // 
            // browseButtonBackup
            // 
            this.browseButtonBackup.Description = "مسیر ذخیره فایل های پشتیبان";
            this.browseButtonBackup.Location = new System.Drawing.Point(47, 27);
            this.browseButtonBackup.Name = "browseButtonBackup";
            this.browseButtonBackup.PathControl = this.txtBackupPath;
            this.browseButtonBackup.Size = new System.Drawing.Size(109, 23);
            this.browseButtonBackup.TabIndex = 2;
            this.browseButtonBackup.Text = "انتخاب مسیر...";
            this.browseButtonBackup.UseVisualStyleBackColor = true;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(162, 27);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupPath.Size = new System.Drawing.Size(364, 22);
            this.txtBackupPath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "مسیر ذخیره فایل های پشتیبان:";
            // 
            // tabPageArchive
            // 
            this.tabPageArchive.Controls.Add(this.groupBoxArchiveSettings);
            this.tabPageArchive.Location = new System.Drawing.Point(4, 23);
            this.tabPageArchive.Name = "tabPageArchive";
            this.tabPageArchive.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageArchive.Size = new System.Drawing.Size(750, 382);
            this.tabPageArchive.TabIndex = 3;
            this.tabPageArchive.Text = "تنظیمات بایگانی";
            this.tabPageArchive.UseVisualStyleBackColor = true;
            // 
            // groupBoxArchiveSettings
            // 
            this.groupBoxArchiveSettings.Controls.Add(this.checkBoxShowContactTab);
            this.groupBoxArchiveSettings.Controls.Add(this.txtPersonnelNumber_MaxLength);
            this.groupBoxArchiveSettings.Controls.Add(this.label7);
            this.groupBoxArchiveSettings.Controls.Add(this.txtPersonnelNumber_MinLength);
            this.groupBoxArchiveSettings.Controls.Add(this.label6);
            this.groupBoxArchiveSettings.Controls.Add(this.txtPersonnelNumber_Label);
            this.groupBoxArchiveSettings.Controls.Add(this.label5);
            this.groupBoxArchiveSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxArchiveSettings.Location = new System.Drawing.Point(10, 10);
            this.groupBoxArchiveSettings.Name = "groupBoxArchiveSettings";
            this.groupBoxArchiveSettings.Size = new System.Drawing.Size(730, 116);
            this.groupBoxArchiveSettings.TabIndex = 0;
            this.groupBoxArchiveSettings.TabStop = false;
            // 
            // checkBoxShowContactTab
            // 
            this.checkBoxShowContactTab.AutoSize = true;
            this.checkBoxShowContactTab.Location = new System.Drawing.Point(357, 77);
            this.checkBoxShowContactTab.Name = "checkBoxShowContactTab";
            this.checkBoxShowContactTab.Size = new System.Drawing.Size(229, 18);
            this.checkBoxShowContactTab.TabIndex = 6;
            this.checkBoxShowContactTab.Text = "سربرگ اطلاعات تماس نمایش داده شود";
            this.checkBoxShowContactTab.UseVisualStyleBackColor = true;
            // 
            // txtPersonnelNumber_MaxLength
            // 
            this.txtPersonnelNumber_MaxLength.Location = new System.Drawing.Point(143, 49);
            this.txtPersonnelNumber_MaxLength.Name = "txtPersonnelNumber_MaxLength";
            this.txtPersonnelNumber_MaxLength.Size = new System.Drawing.Size(150, 22);
            this.txtPersonnelNumber_MaxLength.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "حداکثر طول فیلد اصلی:";
            // 
            // txtPersonnelNumber_MinLength
            // 
            this.txtPersonnelNumber_MinLength.Location = new System.Drawing.Point(436, 49);
            this.txtPersonnelNumber_MinLength.Name = "txtPersonnelNumber_MinLength";
            this.txtPersonnelNumber_MinLength.Size = new System.Drawing.Size(150, 22);
            this.txtPersonnelNumber_MinLength.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(592, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "حداقل طول فیلد اصلی:";
            // 
            // txtPersonnelNumber_Label
            // 
            this.txtPersonnelNumber_Label.Location = new System.Drawing.Point(340, 21);
            this.txtPersonnelNumber_Label.Name = "txtPersonnelNumber_Label";
            this.txtPersonnelNumber_Label.Size = new System.Drawing.Size(246, 22);
            this.txtPersonnelNumber_Label.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "عنوان فیلد اصلی:";
            // 
            // chkShowBackupFormOnExit
            // 
            this.chkShowBackupFormOnExit.AutoSize = true;
            this.chkShowBackupFormOnExit.Location = new System.Drawing.Point(410, 21);
            this.chkShowBackupFormOnExit.Name = "chkShowBackupFormOnExit";
            this.chkShowBackupFormOnExit.Size = new System.Drawing.Size(314, 18);
            this.chkShowBackupFormOnExit.TabIndex = 2;
            this.chkShowBackupFormOnExit.Text = "نمایش فرم پشتیبان گیری از اطلاعات هنگام خروج از برنامه";
            this.chkShowBackupFormOnExit.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkShowBackupFormOnExit);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(10, 412);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(730, 56);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "سایر تنظیمات";
            // 
            // ProgramSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Name = "ProgramSettings";
            this.tabControlExtended.ResumeLayout(false);
            this.tabPageProgramSettings.ResumeLayout(false);
            this.tabPageSavedResponse.ResumeLayout(false);
            this.panelSavedResponseActions.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageSavePath.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFormatBindingSource)).EndInit();
            this.groupBoxDocumentsPath.ResumeLayout(false);
            this.groupBoxDocumentsPath.PerformLayout();
            this.groupBoxBackupPath.ResumeLayout(false);
            this.groupBoxBackupPath.PerformLayout();
            this.tabPageArchive.ResumeLayout(false);
            this.groupBoxArchiveSettings.ResumeLayout(false);
            this.groupBoxArchiveSettings.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Njit.Program.Controls.TextBoxExtended txtOrganName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Njit.Controls.PictureSelectBox pictureSelectBoxLogo;
        private System.Windows.Forms.GroupBox groupBox2;
        private Njit.Controls.PictureSelectBox pictureSelectBoxBackground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageSavePath;
        private System.Windows.Forms.GroupBox groupBoxBackupPath;
        private Njit.Program.Controls.BrowseButton browseButtonBackup;
        private Njit.Program.Controls.TextBoxExtended txtBackupPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxDocumentsDatabases;
        private System.Windows.Forms.GroupBox groupBoxDocumentsPath;
        private Njit.Program.Controls.BrowseButton btnDocumentsPath;
        private Njit.Program.Controls.TextBoxExtended txtDocumentsPath;
        private System.Windows.Forms.Label lblDocumentsPath;
        private System.Windows.Forms.TabPage tabPageArchive;
        private System.Windows.Forms.GroupBox groupBoxArchiveSettings;
        private System.Windows.Forms.CheckBox checkBoxShowContactTab;
        private Njit.Program.Controls.TextBoxExtended txtPersonnelNumber_MaxLength;
        private System.Windows.Forms.Label label7;
        private Njit.Program.Controls.TextBoxExtended txtPersonnelNumber_MinLength;
        private System.Windows.Forms.Label label6;
        private Njit.Program.Controls.TextBoxExtended txtPersonnelNumber_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private Njit.Program.Controls.ComboBoxExtended cmbCompressionType;
        private Njit.Program.Controls.ComboBoxExtended cmbDocumentsFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource compressionTypeBindingSource;
        private System.Windows.Forms.BindingSource imageFormatBindingSource;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkShowBackupFormOnExit;
        private System.Windows.Forms.GroupBox groupBox5;
        private Njit.Program.Controls.TextBoxExtended txtMaxDocSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}