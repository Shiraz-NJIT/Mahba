namespace Njit.Program.ComponentOne.Forms
{
    partial class ImportFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFiles));
            this.btnScan = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonGroupAddFilesAndFolders = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonLabel1 = new C1.Win.C1Ribbon.RibbonLabel();
            this.btnSelectFiles = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnSelectFolder = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonLabel2 = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonGroupSave = new C1.Win.C1Ribbon.RibbonGroup();
            this.comboBoxSaveFormat = new C1.Win.C1Ribbon.RibbonComboBox();
            this.ribbonButtonNone = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonOnePDF = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonPDF = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonOneMultiTiff = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonTiff = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonJpeg = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonPng = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonBmp = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.comboBoxCompression = new C1.Win.C1Ribbon.RibbonComboBox();
            this.ribbonButtonCompressionNone = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonCompressionLZW = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonButtonCompressionC4 = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator3 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnSave = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonLabel3 = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonLabel4 = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonGroupAddSettings = new C1.Win.C1Ribbon.RibbonGroup();
            this.checkBoxInsertFilesIntoCurrentPosition = new C1.Win.C1Ribbon.RibbonCheckBox();
            this.ribbonTabSettings = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroupScannerSettings = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnSelectScanner = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.checkBoxDisableAfterAcq = new C1.Win.C1Ribbon.RibbonCheckBox();
            this.checkBoxShowUI = new C1.Win.C1Ribbon.RibbonCheckBox();
            this.checkBoxShowIndicators = new C1.Win.C1Ribbon.RibbonCheckBox();
            this.ribbonGroupSaveSettings = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnSelectSavePath = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.txtDefaultSavePath = new C1.Win.C1Ribbon.RibbonTextBox();
            this.imageViewer = new Njit.Program.Controls.ImageViewer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.RBFiles = new C1.Win.C1Ribbon.RibbonGroup();
            this.RbAddFiles = new C1.Win.C1Ribbon.RibbonSplitButton();
            this.Addone = new C1.Win.C1Ribbon.RibbonButton();
            this.AddAll = new C1.Win.C1Ribbon.RibbonButton();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.lblStatus);
            this.panelCommand.Controls.Add(this.progressBar);
            this.panelCommand.Location = new System.Drawing.Point(0, 486);
            this.panelCommand.Size = new System.Drawing.Size(907, 29);
            this.panelCommand.Controls.SetChildIndex(this.btnExit, 0);
            this.panelCommand.Controls.SetChildIndex(this.progressBar, 0);
            this.panelCommand.Controls.SetChildIndex(this.lblStatus, 0);
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.imageViewer);
            this.panelMain.Padding = new System.Windows.Forms.Padding(0);
            this.panelMain.Size = new System.Drawing.Size(907, 333);
            // 
            // mainRibbon
            // 
            this.mainRibbon.Size = new System.Drawing.Size(907, 153);
            this.mainRibbon.Tabs.Add(this.ribbonTabSettings);
            // 
            // ribbonQatMain
            // 
            this.ribbonQatMain.ItemLinks.Add(this.btnSelectFiles);
            this.ribbonQatMain.ItemLinks.Add(this.btnSelectFolder);
            this.ribbonQatMain.ToolTip = "سفارشی کردن دکمه های دسترسی سریع";
            // 
            // ribbonTabOperations
            // 
            this.ribbonTabOperations.Groups.Add(this.ribbonGroupAddFilesAndFolders);
            this.ribbonTabOperations.Groups.Add(this.ribbonGroupSave);
            this.ribbonTabOperations.Groups.Add(this.ribbonGroupAddSettings);
            // 
            // ribbonGroupOperations
            // 
            this.ribbonGroupOperations.Items.Add(this.ribbonLabel3);
            this.ribbonGroupOperations.Items.Add(this.btnScan);
            this.ribbonGroupOperations.Items.Add(this.ribbonLabel4);
            this.ribbonGroupOperations.Text = "اسکن تصویر";
            // 
            // btnScan
            // 
            this.btnScan.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.Scanner;
            this.btnScan.Name = "btnScan";
            this.btnScan.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.btnScan.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.Scanner;
            this.btnScan.SupportedGroupSizing = C1.Win.C1Ribbon.SupportedGroupSizing.LargeImageOnly;
            this.btnScan.Text = "اسکن";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);

            // 
            // RBFiles
            // 
            this.RBFiles.Items.Add(this.RbAddFiles);
            this.RBFiles.Name = "RBFiles";
            this.RBFiles.Text = "افزودن فایل";
            
            // 
            // RbAddFiles
            // 
            this.RbAddFiles.Items.Add(this.Addone);
            this.RbAddFiles.Items.Add(this.AddAll);
            this.RbAddFiles.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.NewDoc;
            this.RbAddFiles.Name = "RbAddFiles";
            this.RbAddFiles.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.NewDoc;
            this.RbAddFiles.Text = "افزودن فایل";
            this.RbAddFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // Addone
            // 
            this.Addone.Name = "Addone";
            this.Addone.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.NewDoc;
            this.Addone.Text = "افزودن از فایل";
            this.Addone.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // AddAll
            // 
            this.AddAll.Name = "AddAll";
            this.AddAll.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.NewDoc;
            this.AddAll.Text = "افزودن تمام اسناد یک فایل";
           this.AddAll.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // ribbonGroupAddFilesAndFolders
            // 
            this.ribbonGroupAddFilesAndFolders.Items.Add(this.RbAddFiles);
            //this.ribbonGroupAddFilesAndFolders.Items.Add(this.btnSelectFiles);
            //this.ribbonGroupAddFilesAndFolders.Items.Add(this.ribbonSeparator1);
            //this.ribbonGroupAddFilesAndFolders.Items.Add(this.btnSelectFolder);
            //this.ribbonGroupAddFilesAndFolders.Items.Add(this.ribbonLabel2);
            this.ribbonGroupAddFilesAndFolders.Name = "ribbonGroupAddFilesAndFolders";
            this.ribbonGroupAddFilesAndFolders.Text = "افزودن فایل";
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Name = "ribbonLabel1";
            this.ribbonLabel1.Text = "     ";
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.NewDoc;
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.NewDoc;
            this.btnSelectFiles.SupportedGroupSizing = C1.Win.C1Ribbon.SupportedGroupSizing.LargeImageOnly;
            this.btnSelectFiles.Text = "افزودن فایل ها";
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSelectFolder.LargeImage")));
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.NewDossier;
            this.btnSelectFolder.SupportedGroupSizing = C1.Win.C1Ribbon.SupportedGroupSizing.LargeImageOnly;
            this.btnSelectFolder.Text = "افزودن فایل‌های یک پوشه";
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Name = "ribbonLabel2";
            this.ribbonLabel2.Text = "     ";
            // 
            // ribbonGroupSave
            // 
            this.ribbonGroupSave.Items.Add(this.comboBoxSaveFormat);
            this.ribbonGroupSave.Items.Add(this.comboBoxCompression);
            this.ribbonGroupSave.Items.Add(this.ribbonSeparator3);
            this.ribbonGroupSave.Items.Add(this.btnSave);
            this.ribbonGroupSave.Name = "ribbonGroupSave";
            this.ribbonGroupSave.Text = "ذخیره";
            // 
            // comboBoxSaveFormat
            // 
            this.comboBoxSaveFormat.DropDownStyle = C1.Win.C1Ribbon.RibbonComboBoxStyle.DropDownList;
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonNone);
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonOnePDF);
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonPDF);
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonOneMultiTiff);
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonTiff);
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonJpeg);
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonPng);
            this.comboBoxSaveFormat.Items.Add(this.ribbonButtonBmp);
            this.comboBoxSaveFormat.Label = "فرمت ذخیره:";
            this.comboBoxSaveFormat.LabelWidth = 100;
            this.comboBoxSaveFormat.Name = "comboBoxSaveFormat";
            this.comboBoxSaveFormat.SupportedGroupSizing = C1.Win.C1Ribbon.SupportedGroupSizing.LargeImageOnly;
            this.comboBoxSaveFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboBoxSaveFormat.TextAreaWidth = 150;
            this.comboBoxSaveFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxSaveFormat_SelectedIndexChanged);
            // 
            // ribbonButtonNone
            // 
            this.ribbonButtonNone.Name = "ribbonButtonNone";
            this.ribbonButtonNone.Text = "بدون تغییر";
            // 
            // ribbonButtonOnePDF
            // 
            this.ribbonButtonOnePDF.Name = "ribbonButtonOnePDF";
            this.ribbonButtonOnePDF.Text = "همه فایل ها در یک PDF";
            // 
            // ribbonButtonPDF
            // 
            this.ribbonButtonPDF.Name = "ribbonButtonPDF";
            this.ribbonButtonPDF.Text = "Pdf";
            // 
            // ribbonButtonOneMultiTiff
            // 
            this.ribbonButtonOneMultiTiff.Name = "ribbonButtonOneMultiTiff";
            this.ribbonButtonOneMultiTiff.Text = "همه فایل ها در یک فایل Tiff";
            // 
            // ribbonButtonTiff
            // 
            this.ribbonButtonTiff.Name = "ribbonButtonTiff";
            this.ribbonButtonTiff.Text = "Tiff";
            // 
            // ribbonButtonJpeg
            // 
            this.ribbonButtonJpeg.Name = "ribbonButtonJpeg";
            this.ribbonButtonJpeg.Text = "Jpeg";
            // 
            // ribbonButtonPng
            // 
            this.ribbonButtonPng.Name = "ribbonButtonPng";
            this.ribbonButtonPng.Text = "Png";
            // 
            // ribbonButtonBmp
            // 
            this.ribbonButtonBmp.Name = "ribbonButtonBmp";
            this.ribbonButtonBmp.Text = "Bmp";
            // 
            // comboBoxCompression
            // 
            this.comboBoxCompression.DropDownStyle = C1.Win.C1Ribbon.RibbonComboBoxStyle.DropDownList;
            this.comboBoxCompression.Items.Add(this.ribbonButtonCompressionNone);
            this.comboBoxCompression.Items.Add(this.ribbonButtonCompressionLZW);
            this.comboBoxCompression.Items.Add(this.ribbonButtonCompressionC4);
            this.comboBoxCompression.Label = "نوع فشرده سازی:";
            this.comboBoxCompression.LabelWidth = 100;
            this.comboBoxCompression.Name = "comboBoxCompression";
            this.comboBoxCompression.SupportedGroupSizing = C1.Win.C1Ribbon.SupportedGroupSizing.LargeImageOnly;
            this.comboBoxCompression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.comboBoxCompression.TextAreaWidth = 150;
            this.comboBoxCompression.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompression_SelectedIndexChanged);
            // 
            // ribbonButtonCompressionNone
            // 
            this.ribbonButtonCompressionNone.Name = "ribbonButtonCompressionNone";
            this.ribbonButtonCompressionNone.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCompressionNone.SmallImage")));
            this.ribbonButtonCompressionNone.Text = "بدون فشرده سازی";
            // 
            // ribbonButtonCompressionLZW
            // 
            this.ribbonButtonCompressionLZW.Name = "ribbonButtonCompressionLZW";
            this.ribbonButtonCompressionLZW.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCompressionLZW.SmallImage")));
            this.ribbonButtonCompressionLZW.Text = "فشرده سازی LZW";
            // 
            // ribbonButtonCompressionC4
            // 
            this.ribbonButtonCompressionC4.Name = "ribbonButtonCompressionC4";
            this.ribbonButtonCompressionC4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonCompressionC4.SmallImage")));
            this.ribbonButtonCompressionC4.Text = "فشرده سازی CCITT4";
            // 
            // ribbonSeparator3
            // 
            this.ribbonSeparator3.Name = "ribbonSeparator3";
            // 
            // btnSave
            // 
            this.btnSave.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.Save2;
            this.btnSave.Name = "btnSave";
            this.btnSave.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.Save2;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ribbonLabel3
            // 
            this.ribbonLabel3.Name = "ribbonLabel3";
            this.ribbonLabel3.Text = "     ";
            // 
            // ribbonLabel4
            // 
            this.ribbonLabel4.Name = "ribbonLabel4";
            this.ribbonLabel4.Text = "     ";
            // 
            // ribbonGroupAddSettings
            // 
            this.ribbonGroupAddSettings.Items.Add(this.checkBoxInsertFilesIntoCurrentPosition);
            this.ribbonGroupAddSettings.Name = "ribbonGroupAddSettings";
            this.ribbonGroupAddSettings.Text = "تنظیمات";
            // 
            // checkBoxInsertFilesIntoCurrentPosition
            // 
            this.checkBoxInsertFilesIntoCurrentPosition.Name = "checkBoxInsertFilesIntoCurrentPosition";
            this.checkBoxInsertFilesIntoCurrentPosition.Text = "اضافه کردن فایل های جدید بعد از فایل جاری";
            // 
            // ribbonTabSettings
            // 
            this.ribbonTabSettings.Groups.Add(this.ribbonGroupScannerSettings);
            this.ribbonTabSettings.Groups.Add(this.ribbonGroupSaveSettings);
            this.ribbonTabSettings.Name = "ribbonTabSettings";
            this.ribbonTabSettings.Text = "تنظیمات";
            // 
            // ribbonGroupScannerSettings
            // 
            this.ribbonGroupScannerSettings.Items.Add(this.btnSelectScanner);
            this.ribbonGroupScannerSettings.Items.Add(this.checkBoxDisableAfterAcq);
            this.ribbonGroupScannerSettings.Items.Add(this.checkBoxShowUI);
            this.ribbonGroupScannerSettings.Items.Add(this.checkBoxShowIndicators);
            this.ribbonGroupScannerSettings.Name = "ribbonGroupScannerSettings";
            this.ribbonGroupScannerSettings.Text = "تنظیمات اسکنر";
            // 
            // btnSelectScanner
            // 
            this.btnSelectScanner.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.Scanner;
            this.btnSelectScanner.Name = "btnSelectScanner";
            this.btnSelectScanner.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSelectScanner.SmallImage")));
            this.btnSelectScanner.SupportedGroupSizing = C1.Win.C1Ribbon.SupportedGroupSizing.LargeImageOnly;
            this.btnSelectScanner.Text = "انتخاب اسکنر";
            this.btnSelectScanner.Click += new System.EventHandler(this.btnSelectScanner_Click);
            // 
            // checkBoxDisableAfterAcq
            // 
            this.checkBoxDisableAfterAcq.Name = "checkBoxDisableAfterAcq";
            this.checkBoxDisableAfterAcq.Text = "بسته شدن درایور بعد از اسکن";
            this.checkBoxDisableAfterAcq.CheckedChanged += new System.EventHandler(this.checkBoxDisableAfterAcq_CheckedChanged);
            // 
            // checkBoxShowUI
            // 
            this.checkBoxShowUI.Name = "checkBoxShowUI";
            this.checkBoxShowUI.Text = "نمایش عملکرد اسکنر";
            this.checkBoxShowUI.CheckedChanged += new System.EventHandler(this.checkBoxShowUI_CheckedChanged);
            // 
            // checkBoxShowIndicators
            // 
            this.checkBoxShowIndicators.Name = "checkBoxShowIndicators";
            this.checkBoxShowIndicators.Text = "نمایش پنجره اسکن مربوط به اسکنر";
            this.checkBoxShowIndicators.CheckedChanged += new System.EventHandler(this.checkBoxShowIndicators_CheckedChanged);
            // 
            // ribbonGroupSaveSettings
            // 
            this.ribbonGroupSaveSettings.Items.Add(this.btnSelectSavePath);
            this.ribbonGroupSaveSettings.Items.Add(this.txtDefaultSavePath);
            this.ribbonGroupSaveSettings.Name = "ribbonGroupSaveSettings";
            this.ribbonGroupSaveSettings.Text = "تنظیمات ذخیره سازی";
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.group;
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.SmallImage = global::Njit.Program.ComponentOne.Properties.Resources.group;
            this.btnSelectSavePath.Text = "انتخاب مسیر...";
            this.btnSelectSavePath.Click += new System.EventHandler(this.btnSelectSavePath_Click);
            // 
            // txtDefaultSavePath
            // 
            this.txtDefaultSavePath.Label = "مسیر پیش فرض ذخیره فایل ها:";
            this.txtDefaultSavePath.Name = "txtDefaultSavePath";
            this.txtDefaultSavePath.ReadOnly = true;
            this.txtDefaultSavePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDefaultSavePath.TextAreaWidth = 150;
            // 
            // imageViewer
            // 
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.Location = new System.Drawing.Point(0, 0);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(907, 333);
            this.imageViewer.TabIndex = 1;
            this.imageViewer.BrightnessApplied += new System.EventHandler(this.imageViewer_BrightnessApplied);
            this.imageViewer.ContrastApplied += new System.EventHandler(this.imageViewer_ContrastApplied);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "همه فایل ها|*.*";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "انتخاب اسناد";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "ذخیره اسناد";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "انتخاب مسیر اسناد";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressBar.Location = new System.Drawing.Point(592, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(302, 23);
            this.progressBar.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStatus.Location = new System.Drawing.Point(124, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(468, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImportFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 515);
            this.Name = "ImportFiles";
            this.Text = "ذخیره اسناد";
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Njit.Program.ComponentOne.Controls.RibbonButton btnScan;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroupAddFilesAndFolders;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroupSave;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnSelectFiles;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnSave;
        private C1.Win.C1Ribbon.RibbonLabel ribbonLabel1;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnSelectFolder;
        private C1.Win.C1Ribbon.RibbonLabel ribbonLabel2;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator3;
        private C1.Win.C1Ribbon.RibbonLabel ribbonLabel3;
        private C1.Win.C1Ribbon.RibbonLabel ribbonLabel4;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroupAddSettings;
        private C1.Win.C1Ribbon.RibbonCheckBox checkBoxInsertFilesIntoCurrentPosition;
        private C1.Win.C1Ribbon.RibbonTab ribbonTabSettings;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroupScannerSettings;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnSelectScanner;
        private C1.Win.C1Ribbon.RibbonCheckBox checkBoxDisableAfterAcq;
        private C1.Win.C1Ribbon.RibbonCheckBox checkBoxShowUI;
        private C1.Win.C1Ribbon.RibbonCheckBox checkBoxShowIndicators;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnSelectSavePath;
        private C1.Win.C1Ribbon.RibbonTextBox txtDefaultSavePath;
        private Njit.Program.Controls.ImageViewer imageViewer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        protected C1.Win.C1Ribbon.RibbonComboBox comboBoxSaveFormat;
        protected C1.Win.C1Ribbon.RibbonComboBox comboBoxCompression;
        protected C1.Win.C1Ribbon.RibbonGroup ribbonGroupSaveSettings;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonNone;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonOnePDF;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonOneMultiTiff;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonTiff;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonJpeg;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonPng;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonBmp;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonCompressionNone;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonCompressionLZW;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonCompressionC4;
        private Njit.Program.ComponentOne.Controls.RibbonButton ribbonButtonPDF;
        private C1.Win.C1Ribbon.RibbonGroup RBFiles;
        private C1.Win.C1Ribbon.RibbonSplitButton RbAddFiles;
        private C1.Win.C1Ribbon.RibbonButton Addone;
        private C1.Win.C1Ribbon.RibbonButton AddAll;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnNewDossier;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator22;
    }
}