namespace Njit.Program.ElegantProgram.Forms
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
            this.components = new System.ComponentModel.Container();
            this.imageViewer = new Njit.Program.Controls.ImageViewer();
            this.ribbonGroup1 = new Elegant.Ui.RibbonGroup();
            this.btnSelectFiles = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.btnSelectFolder = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.ribbonGroup2 = new Elegant.Ui.RibbonGroup();
            this.btnScan = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.ribbonGroup3 = new Elegant.Ui.RibbonGroup();
            this.panelSaveType = new Elegant.Ui.Panel();
            this.comboBoxCompression = new Elegant.Ui.ComboBox();
            this.label2 = new Elegant.Ui.Label();
            this.comboBoxSaveFormat = new Elegant.Ui.ComboBox();
            this.label1 = new Elegant.Ui.Label();
            this.btnSave = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ribbonGroup4 = new Elegant.Ui.RibbonGroup();
            this.checkBoxInsertFilesIntoCurrentPosition = new Elegant.Ui.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ribbonTabPageSetting = new Elegant.Ui.RibbonTabPage();
            this.ribbonGroup5 = new Elegant.Ui.RibbonGroup();
            this.btnSelectScanner = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.checkBoxDisableAfterAcq = new Elegant.Ui.CheckBox();
            this.checkBoxShowUI = new Elegant.Ui.CheckBox();
            this.checkBoxShowIndicators = new Elegant.Ui.CheckBox();
            this.ribbonGroupSavePath = new Elegant.Ui.RibbonGroup();
            this.btnSelectSavePath = new Elegant.Ui.Button();
            this.label3 = new Elegant.Ui.Label();
            this.txtDefaultSavePath = new Elegant.Ui.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageCommand)).BeginInit();
            this.ribbonTabPageCommand.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup1)).BeginInit();
            this.ribbonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup2)).BeginInit();
            this.ribbonGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup3)).BeginInit();
            this.ribbonGroup3.SuspendLayout();
            this.panelSaveType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup4)).BeginInit();
            this.ribbonGroup4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageSetting)).BeginInit();
            this.ribbonTabPageSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup5)).BeginInit();
            this.ribbonGroup5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroupSavePath)).BeginInit();
            this.ribbonGroupSavePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRibbon
            // 
            this.mainRibbon.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Default;
            this.mainRibbon.MinimizeButtonVisible = true;
            this.mainRibbon.QuickAccessToolbarPlacementMode = Elegant.Ui.QuickAccessToolbarPlacementMode.AboveRibbon;
            this.mainRibbon.Size = new System.Drawing.Size(832, 149);
            this.mainRibbon.TabPages.AddRange(new Elegant.Ui.RibbonTabPage[] {
            this.ribbonTabPageSetting});
            // 
            // ribbonTabPageCommand
            // 
            this.ribbonTabPageCommand.Controls.Add(this.ribbonGroup2);
            this.ribbonTabPageCommand.Controls.Add(this.ribbonGroup1);
            this.ribbonTabPageCommand.Controls.Add(this.ribbonGroup3);
            this.ribbonTabPageCommand.Controls.Add(this.ribbonGroup4);
            this.ribbonTabPageCommand.Size = new System.Drawing.Size(832, 96);
            this.ribbonTabPageCommand.Text = "اسناد";
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.progressBar);
            this.panelCommand.Controls.Add(this.lblStatus);
            this.panelCommand.Location = new System.Drawing.Point(0, 642);
            this.panelCommand.Size = new System.Drawing.Size(832, 29);
            this.panelCommand.Controls.SetChildIndex(this.btnExit, 0);
            this.panelCommand.Controls.SetChildIndex(this.lblStatus, 0);
            this.panelCommand.Controls.SetChildIndex(this.progressBar, 0);
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.imageViewer);
            this.panelMain.Location = new System.Drawing.Point(0, 149);
            this.panelMain.Size = new System.Drawing.Size(832, 493);
            // 
            // imageViewer
            // 
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.Location = new System.Drawing.Point(10, 3);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(812, 487);
            this.imageViewer.TabIndex = 0;
            this.imageViewer.BrightnessApplied += new System.EventHandler(this.imageViewer_BrightnessApplied);
            this.imageViewer.ContrastApplied += new System.EventHandler(this.imageViewer_ContrastApplied);
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Controls.Add(this.btnSelectFiles);
            this.ribbonGroup1.Controls.Add(this.btnSelectFolder);
            this.ribbonGroup1.Location = new System.Drawing.Point(56, 1);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Size = new System.Drawing.Size(126, 91);
            this.ribbonGroup1.TabIndex = 0;
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Id = "5168f947-0281-41ca-b0a6-dab27dd35908";
            this.btnSelectFiles.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.NewDoc)});
            this.btnSelectFiles.Location = new System.Drawing.Point(4, 2);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(42, 69);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "انتخاب اسناد";
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Id = "8796785d-9196-44c0-8f5c-4184546d3b3d";
            this.btnSelectFolder.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.NewDossier)});
            this.btnSelectFolder.Location = new System.Drawing.Point(48, 2);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(73, 69);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "انتخاب گروهی اسناد";
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Controls.Add(this.btnScan);
            this.ribbonGroup2.Location = new System.Drawing.Point(5, 1);
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Size = new System.Drawing.Size(51, 91);
            this.ribbonGroup2.TabIndex = 1;
            // 
            // btnScan
            // 
            this.btnScan.Id = "29a91280-1380-4d32-9fd2-dbcc2c48b5f6";
            this.btnScan.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.Scanner)});
            this.btnScan.Location = new System.Drawing.Point(4, 2);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(42, 69);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = " اسکن";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.Controls.Add(this.panelSaveType);
            this.ribbonGroup3.Controls.Add(this.btnSave);
            this.ribbonGroup3.Location = new System.Drawing.Point(182, 1);
            this.ribbonGroup3.Name = "ribbonGroup3";
            this.ribbonGroup3.Size = new System.Drawing.Size(312, 91);
            this.ribbonGroup3.TabIndex = 2;
            // 
            // panelSaveType
            // 
            this.panelSaveType.Controls.Add(this.comboBoxCompression);
            this.panelSaveType.Controls.Add(this.label2);
            this.panelSaveType.Controls.Add(this.comboBoxSaveFormat);
            this.panelSaveType.Controls.Add(this.label1);
            this.panelSaveType.Location = new System.Drawing.Point(3, 2);
            this.panelSaveType.Name = "panelSaveType";
            this.panelSaveType.Size = new System.Drawing.Size(261, 58);
            this.panelSaveType.TabIndex = 0;
            // 
            // comboBoxCompression
            // 
            this.comboBoxCompression.FormattingEnabled = false;
            this.comboBoxCompression.Id = "c1794f06-bf00-4a23-906c-a20d52e2b5b3";
            this.comboBoxCompression.Items.AddRange(new object[] {
            "بدون فشرده سازی",
            "فشرده سازی LZW",
            "فشرده سازی CCITT4"});
            this.comboBoxCompression.Location = new System.Drawing.Point(116, 30);
            this.comboBoxCompression.Name = "comboBoxCompression";
            this.comboBoxCompression.Size = new System.Drawing.Size(144, 20);
            this.comboBoxCompression.TabIndex = 3;
            this.comboBoxCompression.TextEditorWidth = 125;
            this.comboBoxCompression.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompression_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "نوع فشرده سازی:";
            // 
            // comboBoxSaveFormat
            // 
            this.comboBoxSaveFormat.FormattingEnabled = false;
            this.comboBoxSaveFormat.Id = "a47c4c2e-5431-4349-bc5c-381817e00e0f";
            this.comboBoxSaveFormat.Items.AddRange(new object[] {
            "بدون تغییر",
            "همه فایل ها در یک PDF",
            "PDF",
            "همه فایل ها در یک TIFF",
            "TIFF",
            "JPEG",
            "PNG",
            "BMP"});
            this.comboBoxSaveFormat.Location = new System.Drawing.Point(116, 6);
            this.comboBoxSaveFormat.Name = "comboBoxSaveFormat";
            this.comboBoxSaveFormat.Size = new System.Drawing.Size(144, 20);
            this.comboBoxSaveFormat.TabIndex = 1;
            this.comboBoxSaveFormat.TextEditorWidth = 125;
            this.comboBoxSaveFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxSaveFormat_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "فرمت ذخیره اسناد:";
            // 
            // btnSave
            // 
            this.btnSave.Id = "c4019f9e-ca5e-4554-b696-a9ef94a7f1cc";
            this.btnSave.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.Save2)});
            this.btnSave.Location = new System.Drawing.Point(265, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(42, 69);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // ribbonGroup4
            // 
            this.ribbonGroup4.Controls.Add(this.checkBoxInsertFilesIntoCurrentPosition);
            this.ribbonGroup4.Location = new System.Drawing.Point(494, 1);
            this.ribbonGroup4.Name = "ribbonGroup4";
            this.ribbonGroup4.Size = new System.Drawing.Size(242, 91);
            this.ribbonGroup4.TabIndex = 3;
            // 
            // checkBoxInsertFilesIntoCurrentPosition
            // 
            this.checkBoxInsertFilesIntoCurrentPosition.Id = "b175283c-8e9e-4222-bb91-221444d5680f";
            this.checkBoxInsertFilesIntoCurrentPosition.Location = new System.Drawing.Point(4, 2);
            this.checkBoxInsertFilesIntoCurrentPosition.Name = "checkBoxInsertFilesIntoCurrentPosition";
            this.checkBoxInsertFilesIntoCurrentPosition.Size = new System.Drawing.Size(233, 23);
            this.checkBoxInsertFilesIntoCurrentPosition.TabIndex = 0;
            this.checkBoxInsertFilesIntoCurrentPosition.Text = "اضافه کردن اسناد بعد از سند انتخاب شده";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "انتخاب مسیر اسناد";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // ribbonTabPageSetting
            // 
            this.ribbonTabPageSetting.Controls.Add(this.ribbonGroup5);
            this.ribbonTabPageSetting.Controls.Add(this.ribbonGroupSavePath);
            this.ribbonTabPageSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonTabPageSetting.KeyTip = null;
            this.ribbonTabPageSetting.Location = new System.Drawing.Point(0, 0);
            this.ribbonTabPageSetting.Name = "ribbonTabPageSetting";
            this.ribbonTabPageSetting.Size = new System.Drawing.Size(832, 96);
            this.ribbonTabPageSetting.TabIndex = 0;
            this.ribbonTabPageSetting.Text = "تنظیمات";
            // 
            // ribbonGroup5
            // 
            this.ribbonGroup5.Controls.Add(this.btnSelectScanner);
            this.ribbonGroup5.Controls.Add(this.checkBoxDisableAfterAcq);
            this.ribbonGroup5.Controls.Add(this.checkBoxShowUI);
            this.ribbonGroup5.Controls.Add(this.checkBoxShowIndicators);
            this.ribbonGroup5.Location = new System.Drawing.Point(602, 1);
            this.ribbonGroup5.Name = "ribbonGroup5";
            this.ribbonGroup5.Size = new System.Drawing.Size(225, 91);
            this.ribbonGroup5.TabIndex = 0;
            // 
            // btnSelectScanner
            // 
            this.btnSelectScanner.Id = "8eb5c49d-6743-43d2-8d67-eddbc773bf1c";
            this.btnSelectScanner.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.Scanner)});
            this.btnSelectScanner.Location = new System.Drawing.Point(4, 2);
            this.btnSelectScanner.Name = "btnSelectScanner";
            this.btnSelectScanner.Size = new System.Drawing.Size(42, 69);
            this.btnSelectScanner.TabIndex = 0;
            this.btnSelectScanner.Text = "انتخاب اسکنر";
            this.btnSelectScanner.Click += new System.EventHandler(this.btnSelectScaner_Click);
            // 
            // checkBoxDisableAfterAcq
            // 
            this.checkBoxDisableAfterAcq.Id = "6b7a3e4d-d8fa-4483-888e-357311e82498";
            this.checkBoxDisableAfterAcq.Location = new System.Drawing.Point(48, 2);
            this.checkBoxDisableAfterAcq.Name = "checkBoxDisableAfterAcq";
            this.checkBoxDisableAfterAcq.Size = new System.Drawing.Size(172, 23);
            this.checkBoxDisableAfterAcq.TabIndex = 1;
            this.checkBoxDisableAfterAcq.Text = "بسته شدن درایور بعد از اسکن";
            this.checkBoxDisableAfterAcq.CheckedChanged += new System.EventHandler(this.checkBoxDisableAfterAcq_CheckedChanged);
            // 
            // checkBoxShowUI
            // 
            this.checkBoxShowUI.Id = "43400de6-647f-453a-8e2f-9c8183f15f3e";
            this.checkBoxShowUI.Location = new System.Drawing.Point(48, 25);
            this.checkBoxShowUI.Name = "checkBoxShowUI";
            this.checkBoxShowUI.Size = new System.Drawing.Size(159, 23);
            this.checkBoxShowUI.TabIndex = 2;
            this.checkBoxShowUI.Text = "نمایش عملکرد اسکن اسناد";
            this.checkBoxShowUI.CheckedChanged += new System.EventHandler(this.checkBoxShowUI_CheckedChanged);
            // 
            // checkBoxShowIndicators
            // 
            this.checkBoxShowIndicators.Id = "39952b70-6d57-4ec9-b966-fec1cecb2a7b";
            this.checkBoxShowIndicators.Location = new System.Drawing.Point(48, 48);
            this.checkBoxShowIndicators.Name = "checkBoxShowIndicators";
            this.checkBoxShowIndicators.Size = new System.Drawing.Size(116, 23);
            this.checkBoxShowIndicators.TabIndex = 3;
            this.checkBoxShowIndicators.Text = "نمایش درایور اسکنر";
            this.checkBoxShowIndicators.CheckedChanged += new System.EventHandler(this.checkBoxShowIndicators_CheckedChanged);
            // 
            // ribbonGroupSavePath
            // 
            this.ribbonGroupSavePath.Controls.Add(this.btnSelectSavePath);
            this.ribbonGroupSavePath.Controls.Add(this.label3);
            this.ribbonGroupSavePath.Controls.Add(this.txtDefaultSavePath);
            this.ribbonGroupSavePath.Location = new System.Drawing.Point(295, 1);
            this.ribbonGroupSavePath.Name = "ribbonGroupSavePath";
            this.ribbonGroupSavePath.Size = new System.Drawing.Size(307, 91);
            this.ribbonGroupSavePath.TabIndex = 1;
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.Id = "558683ae-46f4-463c-828a-2de4d052d04c";
            this.btnSelectSavePath.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.group)});
            this.btnSelectSavePath.Location = new System.Drawing.Point(4, 2);
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.Size = new System.Drawing.Size(44, 69);
            this.btnSelectSavePath.TabIndex = 2;
            this.btnSelectSavePath.Text = "انتخاب مسیر...";
            this.btnSelectSavePath.Click += new System.EventHandler(this.btnSelectSavePath_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(49, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "مسیر پیش فرض ذخیره فایل ها:";
            // 
            // txtDefaultSavePath
            // 
            this.txtDefaultSavePath.Id = "d52df11c-b34c-47f0-8055-317b60475656";
            this.txtDefaultSavePath.Location = new System.Drawing.Point(50, 25);
            this.txtDefaultSavePath.Name = "txtDefaultSavePath";
            this.txtDefaultSavePath.ReadOnly = true;
            this.txtDefaultSavePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDefaultSavePath.Size = new System.Drawing.Size(252, 23);
            this.txtDefaultSavePath.TabIndex = 1;
            this.txtDefaultSavePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDefaultSavePath.TextEditorWidth = 246;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStatus.Location = new System.Drawing.Point(772, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 14);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "          ";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressBar.Location = new System.Drawing.Point(564, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(208, 23);
            this.progressBar.TabIndex = 2;
            // 
            // ImportFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 671);
            this.KeyPreview = true;
            this.Name = "ImportFiles";
            this.Text = "ذخیره اسناد";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImportFiles_KeyDown);
            this.Controls.SetChildIndex(this.mainRibbon, 0);
            this.Controls.SetChildIndex(this.panelCommand, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageCommand)).EndInit();
            this.ribbonTabPageCommand.ResumeLayout(false);
            this.ribbonTabPageCommand.PerformLayout();
            this.panelCommand.ResumeLayout(false);
            this.panelCommand.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup1)).EndInit();
            this.ribbonGroup1.ResumeLayout(false);
            this.ribbonGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup2)).EndInit();
            this.ribbonGroup2.ResumeLayout(false);
            this.ribbonGroup2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup3)).EndInit();
            this.ribbonGroup3.ResumeLayout(false);
            this.ribbonGroup3.PerformLayout();
            this.panelSaveType.ResumeLayout(false);
            this.panelSaveType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup4)).EndInit();
            this.ribbonGroup4.ResumeLayout(false);
            this.ribbonGroup4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageSetting)).EndInit();
            this.ribbonTabPageSetting.ResumeLayout(false);
            this.ribbonTabPageSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroup5)).EndInit();
            this.ribbonGroup5.ResumeLayout(false);
            this.ribbonGroup5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroupSavePath)).EndInit();
            this.ribbonGroupSavePath.ResumeLayout(false);
            this.ribbonGroupSavePath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.ImageViewer imageViewer;
        private Elegant.Ui.RibbonGroup ribbonGroup1;
        private Njit.Program.ElegantProgram.Controls.ElegantButton btnSelectFiles;
        private Njit.Program.ElegantProgram.Controls.ElegantButton btnSelectFolder;
        private Elegant.Ui.RibbonGroup ribbonGroup2;
        private Njit.Program.ElegantProgram.Controls.ElegantButton btnScan;
        private Elegant.Ui.RibbonGroup ribbonGroup3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private Elegant.Ui.RibbonGroup ribbonGroup4;
        private Elegant.Ui.CheckBox checkBoxInsertFilesIntoCurrentPosition;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private Njit.Program.ElegantProgram.Controls.ElegantButton btnSave;
        private Elegant.Ui.RibbonTabPage ribbonTabPageSetting;
        private Elegant.Ui.RibbonGroup ribbonGroup5;
        private Elegant.Ui.CheckBox checkBoxDisableAfterAcq;
        private Elegant.Ui.CheckBox checkBoxShowUI;
        private Elegant.Ui.CheckBox checkBoxShowIndicators;
        private Elegant.Ui.Panel panelSaveType;
        private Elegant.Ui.ComboBox comboBoxCompression;
        private Elegant.Ui.Label label2;
        private Elegant.Ui.ComboBox comboBoxSaveFormat;
        private Elegant.Ui.Label label1;
        private Njit.Program.ElegantProgram.Controls.ElegantButton btnSelectScanner;
        private Elegant.Ui.RibbonGroup ribbonGroupSavePath;
        private Elegant.Ui.Label label3;
        private Elegant.Ui.TextBox txtDefaultSavePath;
        private Elegant.Ui.Button btnSelectSavePath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
    }
}