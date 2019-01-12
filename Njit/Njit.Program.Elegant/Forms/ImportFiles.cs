using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.ElegantProgram.Forms
{
    public partial class ImportFiles : Njit.Program.ElegantProgram.Forms.ListFormWithoutSearch
    {
        public ImportFiles()
            : this(/*null, null, false, false,*/ true, Enums.SaveFormats.None, Enums.CompressionTypes.None)
        {
        }

        //public ImportFiles(string personnelNumber, int? documentID)
        //    : this(personnelNumber, documentID, false, true, false)
        //{
        //}

        //public ImportFiles(string personnelNumber, bool attachToDossier)
        //    : this(personnelNumber, null, attachToDossier, true, false)
        //{
        //}

        public ImportFiles(/*string personnelNumber, int? documentID, bool attachToDossier, bool loadSettingsFromDatabase,*/ bool fastMode, Enums.SaveFormats saveFormat, Enums.CompressionTypes compressionType)
        {
            InitializeComponent();
            this.FastMode = fastMode;
            tempDirectory = Path.Combine(Path.GetTempPath(), "~Njit");
            //this.PersonnelNumber = personnelNumber;
            //this.DocumentID = documentID;
            //this.AttachToDossier = attachToDossier;
            comboBoxCompression.SelectedIndex = (int)saveFormat;
            comboBoxSaveFormat.SelectedIndex = (int)compressionType;
            txtDefaultSavePath.Text = Properties.Settings.Default.ScanSavePath ?? "";
            //if (loadSettingsFromDatabase)
            //{
            //    comboBoxCompression.SelectedIndex = Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? 0;
            //    comboBoxSaveFormat.SelectedIndex = Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? 0;
            //    ribbonGroupSavePath.Visible = false;
            //}
            this.SelectScannerBeforScan = fastMode;
            ribbonGroupSavePath.Visible = fastMode;
        }

        string tempDirectory;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            try
            {
                if (!System.IO.Directory.Exists(tempDirectory))
                    System.IO.Directory.CreateDirectory(tempDirectory);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در دسترسی به مسیر ذخیره فایل ها" + "\r\n\r\n" + ex.Message);
            }
            checkBoxDisableAfterAcq.Checked = VsTwain.DisableAfterAcquire = Properties.Settings.Default.DisableScannerAfterAcquire;
            checkBoxShowIndicators.Checked = VsTwain.ShowIndicators = Properties.Settings.Default.ShowScanIndicators;
            checkBoxShowUI.Checked = VsTwain.ShowUI = Properties.Settings.Default.ShowScanUI;
        }

        Vintasoft.Twain.VSTwain _VsTwain;
        private Vintasoft.Twain.VSTwain VsTwain
        {
            get
            {
                if (_VsTwain == null)
                {
                    _VsTwain = new Vintasoft.Twain.VSTwain();
                    _VsTwain.AppProductName = "VintaSoftTwain.NET";
                    _VsTwain.AutoCleanBuffer = true;
                    _VsTwain.FileFormat = Vintasoft.Twain.FileFormat.TiffMulti;
                    _VsTwain.FileName = Path.Combine(tempDirectory, "temp.tiff");
                    _VsTwain.JpegQuality = 90;
                    _VsTwain.MaxImages = 1000;
                    _VsTwain.ModalUI = false;
                    _VsTwain.Parent = this;
                    _VsTwain.PdfImageCompression = Vintasoft.Twain.PdfImageCompression.JPEG;
                    _VsTwain.PdfMultiPage = true;
                    _VsTwain.TiffCompression = Vintasoft.Twain.TiffCompression.Auto;
                    _VsTwain.TiffMultiPage = true;
                    _VsTwain.TransferMode = Vintasoft.Twain.TransferMode.Memory;
                    _VsTwain.ImageAcquired += new Vintasoft.Twain.VSTwain.ImageAcquiredEventHandler(VsTwain_ImageAcquired);
                    _VsTwain.ScanCompleted += new Vintasoft.Twain.VSTwain.ScanCompletedEventHandler(VsTwain_ScanCompleted);
                    _VsTwain.ProgressChanged += VsTwain_ProgressChanged;
                }
                return _VsTwain;
            }
        }

        void VsTwain_ProgressChanged(object sender, Vintasoft.Twain.ProgressChangedEventArgs e)
        {
            progressBar.Value = (int)e.PercentComplete;
        }

        private bool FastMode { get; set; }

        private string _ScanSource = null;
        [DefaultValue(null)]
        public string ScanSource
        {
            get
            {
                return _ScanSource;
            }
            set
            {
                _ScanSource = value;
            }
        }

        //private string _PersonnelNumber = null;
        ///// <summary>
        ///// شماره پرونده ای که سندها به آن اضاف می شوند
        ///// </summary>
        //[DefaultValue(null)]
        //protected string PersonnelNumber
        //{
        //    get
        //    {
        //        return _PersonnelNumber;
        //    }
        //    set
        //    {
        //        _PersonnelNumber = value;
        //    }
        //}

        //private int? _DocumentID = null;
        ///// <summary>
        ///// کد سندی که سندهای جدید به آن ضمیمه میشوند
        ///// </summary>
        //[DefaultValue(null)]
        //protected int? DocumentID
        //{
        //    get
        //    {
        //        return _DocumentID;
        //    }
        //    set
        //    {
        //        _DocumentID = value;
        //    }
        //}

        //private bool _AttachToDossier;
        ///// <summary>
        ///// آیا سندها به پرونده ضمیمه شوند
        ///// </summary>
        //protected bool AttachToDossier
        //{
        //    get
        //    {
        //        return _AttachToDossier;
        //    }
        //    set
        //    {
        //        _AttachToDossier = value;
        //    }
        //}

        private bool _SelectScannerBeforScan = false;
        [DefaultValue(false)]
        protected bool SelectScannerBeforScan
        {
            get
            {
                return _SelectScannerBeforScan;
            }
            set
            {
                _SelectScannerBeforScan = value;
            }
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (checkBoxInsertFilesIntoCurrentPosition.Checked)
                        imageViewer.InsertRange(openFileDialog.FileNames);
                    else
                        imageViewer.AddRange(openFileDialog.FileNames);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در افزودن اسناد" + "\r\n\r\n" + ex.Message);
                }
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (checkBoxInsertFilesIntoCurrentPosition.Checked)
                        imageViewer.InsertRange(System.IO.Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories));
                    else
                        imageViewer.AddRange(System.IO.Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories));
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در افزودن اسناد" + "\r\n\r\n" + ex.Message);
                }
            }
        }

        private void VsTwain_ImageAcquired(object sender, EventArgs e)
        {
            lblStatus.Text = "درحال ذخیره تصویر...";
            string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
            string documentPath = Path.Combine(tempDirectory, fileName + ".tiff").ToString();
            int i = 0;
            while (System.IO.File.Exists(documentPath))
            {
                documentPath = Path.Combine(tempDirectory, fileName + "(" + (++i).ToString() + ")" + ".tiff").ToString();
            }
            try
            {
                VsTwain.FileFormat = Vintasoft.Twain.FileFormat.TiffMulti;
                VsTwain.SaveImage(0, documentPath);
                VsTwain.DeleteImage(0);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ذخیره فایل اسکن شده" + "\r\n\r\n" + ex.Message);
                return;
            }
            if (checkBoxInsertFilesIntoCurrentPosition.Checked)
                imageViewer.InsertFile(documentPath);
            else
                imageViewer.AddFile(documentPath);
            lblStatus.Text = "در حال اعمال روشنایی و کنتراست بر روی تصویر...";
            SetImageBrightnessAndContrast(documentPath);
        }

        private void SetImageBrightnessAndContrast(string file)
        {
            if (ScannerSettingManager.Settings != null && _ScanSource != null)
            {
                var query = ScannerSettingManager.Settings.Where(t => t.Scanner == _ScanSource);
                if (query.Count() > 0)
                {
                    ScannerSetting selectedScanSourceSettings = query.First();
                    imageViewer.CloseImage();
                    Njit.Common.Helpers.ImageHelper.SetBrightness(file, selectedScanSourceSettings.Brightness);
                    Njit.Common.Helpers.ImageHelper.SetContrast(file, selectedScanSourceSettings.Contrast);
                    imageViewer.LoadImage();
                }
            }
        }

        private void VsTwain_ScanCompleted(object sender, EventArgs e)
        {
            lblStatus.Text = "اسکن به پایان رسید";
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                VsTwain.StartDevice();
                if (this.SelectScannerBeforScan && this.ScanSource == null)
                    if (!VsTwain.SelectSource())
                    {
                        PersianMessageBox.Show(this, "هیچ اسکنری انتخاب نشده است");
                        return;
                    }
                    else
                    {
                        this.ScanSource = VsTwain.GetSourceProductName(VsTwain.SourceIndex);
                    }
                VsTwain.Acquire();
                lblStatus.Text = "درحال اسکن تصویر...";
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        string[] imageExtensions = new string[] { ".bmp", ".jpg", ".jpeg", ".png", ".gif", ".tif", ".tiff" };
        Enums.SaveFormats selectedSaveFormat = Enums.SaveFormats.None;
        Enums.CompressionTypes selectedCompressionType = Enums.CompressionTypes.None;

        [DefaultValue(null)]
        protected string SelectedFolderForSaveFiles { get; private set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (imageViewer.Files.Count == 0)
            {
                PersianMessageBox.Show(this, "هیچ سندی انتخاب نشده است");
                return;
            }
            if (panelSaveType.Visible)
            {
                if (comboBoxSaveFormat.SelectedIndex < 0)
                {
                    PersianMessageBox.Show(this, "فرمت ذخیره اسناد را انتخاب کنید");
                    return;
                }
                if (comboBoxCompression.SelectedIndex < 0)
                {
                    PersianMessageBox.Show(this, "نوع فشرده سازی را انتخاب کنید");
                    return;
                }
            }
            if (comboBoxSaveFormat.SelectedIndex == (int)Enums.SaveFormats.OneMultiTiff)
            {
                ConverAllImagesToOneTiffFile();
            }
            else if (comboBoxSaveFormat.SelectedIndex == (int)Enums.SaveFormats.OnePdf)
            {
                ConverAllImagesToOnePDFFile();
            }
            if (this.FastMode)
            {
                if (txtDefaultSavePath.Text.Trim() == "")
                {
                    if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        txtDefaultSavePath.Text = folderBrowserDialog.SelectedPath;
                    else
                        return;
                }
            }
            SelectedFolderForSaveFiles = txtDefaultSavePath.Text;
            int saveCount = imageViewer.SaveAsImages(this.SaveFile);
            if (saveCount == imageViewer.Files.Count)
                PersianMessageBox.Show(this, "فایل ها ذخیره شدند");
            else
                PersianMessageBox.Show(this, "تعداد " + saveCount.ToString() + " فایل از " + imageViewer.Files.Count.ToString() + " فایل ذخیره شد");
            imageViewer.Clear();
            if (!this.FastMode)
                this.Close();
            //}
            //else
            //{
            //    int saveCount = imageViewer.SaveAsImages(this.SaveDocument);
            //    ProgramEvents.OnDocumentsChanged();
            //    if (saveCount == imageViewer.Files.Count)
            //        PersianMessageBox.Show(this, "سند ها ثبت شدند");
            //    else
            //        PersianMessageBox.Show(this, "تعداد " + saveCount.ToString() + " سند از " + imageViewer.Files.Count.ToString() + " سند ثبت شد");
            //    imageViewer.Clear();
            //    this.Close();
            //}
        }

        private void ConverAllImagesToOnePDFFile()
        {
            string documentPath = GetUniqFileName(".pdf");
            this.imageViewer.CloseImage();
            var imageFiles = this.imageViewer.Files.Where(t => imageExtensions.Contains(System.IO.Path.GetExtension(t).ToLower())).ToArray();
            Image[] images = new Image[imageFiles.Count()];
            for (int i = 0; i < imageFiles.Count(); i++)
                images[i] = Image.FromFile(imageFiles[i]);
            string directoryName = System.IO.Path.GetDirectoryName(documentPath);
            if (!System.IO.Directory.Exists(directoryName))
                System.IO.Directory.CreateDirectory(directoryName);
            Njit.Pdf.CreatePDF.FromImages(images, documentPath, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.OriginalSize);
            this.imageViewer.Clear();
            foreach (Image img in images)
                img.Dispose();
            this.imageViewer.AddFile(documentPath);
        }

        private void ConverAllImagesToOneTiffFile()
        {
            string documentPath = GetUniqFileName(".tiff");
            this.imageViewer.CloseImage();
            var imageFiles = this.imageViewer.Files.Where(t => imageExtensions.Contains(System.IO.Path.GetExtension(t).ToLower())).ToArray();
            Image[] images = new Image[imageFiles.Count()];
            for (int i = 0; i < imageFiles.Count(); i++)
                images[i] = Image.FromFile(imageFiles[i]);
            string directoryName = System.IO.Path.GetDirectoryName(documentPath);
            if (!System.IO.Directory.Exists(directoryName))
                System.IO.Directory.CreateDirectory(directoryName);
            Njit.Common.Helpers.ImageHelper.ConvertImagesToMultiTiff(images, documentPath, GetImageCompression(this.selectedCompressionType)).Dispose();
            this.imageViewer.Clear();
            foreach (Image img in images)
                img.Dispose();
            this.imageViewer.AddFile(documentPath);
        }

        //public void SaveDocument(string file)
        //{
        //    Controller.Archive.DocumentController.AddDocument(this.PersonnelNumber, file, this.DocumentID, this.AttachToDossier, this.selectedSaveFormat, this.selectedCompressionType);
        //}

        protected virtual void SaveFile(string file)
        {
            string fileExtension = Path.GetExtension(file).ToLower();
            if (imageExtensions.Contains(fileExtension))
            {
                switch (selectedSaveFormat)
                {
                    case Enums.SaveFormats.None:
                        break;
                    case Enums.SaveFormats.OnePdf:
                        if (fileExtension != ".pdf")
                        {
                            fileExtension = ".pdf";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Pdf.CreatePDF.FromImages(new Image[] { image }, newfile, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.OriginalSize);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Enums.SaveFormats.Pdf:
                        if (fileExtension != ".pdf")
                        {
                            fileExtension = ".pdf";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Pdf.CreatePDF.FromImages(new Image[] { image }, newfile, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.OriginalSize);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Enums.SaveFormats.OneMultiTiff:
                        if (fileExtension != ".tiff" && fileExtension != ".tif")
                        {
                            fileExtension = ".tiff";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Tiff, GetImageCompression(selectedCompressionType), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Enums.SaveFormats.Tiff:
                        if (fileExtension != ".tiff" && fileExtension != ".tif")
                        {
                            fileExtension = ".tiff";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Tiff, GetImageCompression(selectedCompressionType), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Enums.SaveFormats.JPEG:
                        if (fileExtension != ".jpg" && fileExtension != ".jpeg")
                        {
                            fileExtension = ".jpg";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Jpeg, GetImageCompression(selectedCompressionType), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Enums.SaveFormats.PNG:
                        if (fileExtension != ".png")
                        {
                            fileExtension = ".png";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Png, GetImageCompression(selectedCompressionType), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Enums.SaveFormats.BMP:
                        if (fileExtension != ".bmp")
                        {
                            fileExtension = ".bmp";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Bmp, GetImageCompression(selectedCompressionType), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }
            string fileName = System.IO.Path.GetFileNameWithoutExtension(file) + fileExtension; //Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true) + fileExtension;
            string destinationFile = null;
            destinationFile = Path.Combine(this.SelectedFolderForSaveFiles, fileName);
            int i = 1;
            while (System.IO.File.Exists(destinationFile))
            {
                fileName = System.IO.Path.GetFileNameWithoutExtension(file) + " (" + i.ToString() + ")" + fileExtension;//Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true) + fileExtension;
                destinationFile = Path.Combine(this.SelectedFolderForSaveFiles, fileName);
                i++;
            }

            FileStream serverFileStream = null;
            FileStream clientFileStream = null;
            try
            {
                if (!System.IO.Directory.Exists(this.SelectedFolderForSaveFiles))
                    System.IO.Directory.CreateDirectory(this.SelectedFolderForSaveFiles);
                serverFileStream = System.IO.File.Create(destinationFile);
                clientFileStream = System.IO.File.OpenRead(file);
                byte[] buffre = new byte[1 * 1024 * 1024];
                int readCount = 0;
                do
                {
                    readCount = clientFileStream.Read(buffre, 0, buffre.Length);
                    serverFileStream.Write(buffre, 0, readCount);
                }
                while (readCount > 0);
                clientFileStream.Close();
                serverFileStream.Close();
                clientFileStream.Dispose();
                serverFileStream.Dispose();
            }
            catch (Exception ex)
            {
                if (clientFileStream != null)
                    clientFileStream.Dispose();
                if (serverFileStream != null)
                    serverFileStream.Dispose();
                throw new Exception("خطا در ذخیره فایل" + "\r\n" + file + "\r\n\r\n" + ex.Message);
            }
        }

        public string GetUniqFileName()
        {
            return GetUniqFileName(".tmp");
        }

        public static Njit.Common.Helpers.ImageHelper.CompressionTypes GetImageCompression(Enums.CompressionTypes imageCompression)
        {
            switch (imageCompression)
            {
                case Enums.CompressionTypes.None:
                    return Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionNone;
                case Enums.CompressionTypes.LZW:
                    return Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionLZW;
                case Enums.CompressionTypes.CCITT4:
                    return Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionCCITT4;
                default:
                    throw new Exception();
            }
        }

        public string GetUniqFileName(string extension)
        {
            string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
            string documentPath = Path.Combine(tempDirectory, fileName + extension).ToString();
            int i = 0;
            while (System.IO.File.Exists(documentPath))
            {
                documentPath = Path.Combine(tempDirectory, fileName + "(" + (++i).ToString() + ")" + extension).ToString();
            }
            return documentPath;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.DesignMode)
                return;
            //if (this.PersonnelNumber != null && Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName.IsNullOrEmpty())
            //{
            //    PersianMessageBox.Show("مسیر ذخیره اسناد در تنظیمات برنامه مشخص نشده است");
            //    this.Close();
            //    return;
            //}
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            imageViewer.CloseImage();
            try
            {
                if (System.IO.Directory.Exists(tempDirectory))
                    System.IO.Directory.Delete(tempDirectory, true);
            }
            catch { }
            Properties.Settings.Default.ScanSavePath = txtDefaultSavePath.Text;
            Properties.Settings.Default.Save();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btnSelectScaner_Click(object sender, EventArgs e)
        {
            try
            {
                VsTwain.StartDevice();
                if (VsTwain.SelectSource())
                    this.ScanSource = VsTwain.GetSourceProductName(VsTwain.SourceIndex);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا" + "\r\n" + ex.Message);
            }
        }

        private void checkBoxDisableAfterAcq_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DisableScannerAfterAcquire = VsTwain.DisableAfterAcquire = checkBoxDisableAfterAcq.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxShowUI_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowScanUI = VsTwain.ShowUI = checkBoxShowUI.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxShowIndicators_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowScanIndicators = VsTwain.ShowIndicators = checkBoxShowIndicators.Checked;
            Properties.Settings.Default.Save();
        }

        private void comboBoxSaveFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSaveFormat.SelectedIndex >= 0)
                selectedSaveFormat = (Enums.SaveFormats)comboBoxSaveFormat.SelectedIndex;
        }

        private void comboBoxCompression_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCompression.SelectedIndex >= 0)
                selectedCompressionType = (Enums.CompressionTypes)comboBoxCompression.SelectedIndex;
        }

        private void imageViewer_BrightnessApplied(object sender, EventArgs e)
        {
            if (this.ScanSource != null)
            {
                foreach (var item in ScannerSettingManager.Settings)
                {
                    if (item.Scanner == this.ScanSource)
                    {
                        item.Brightness = imageViewer.Brightness;
                        ScannerSettingManager.SaveAndReload();
                        return;
                    }
                }
                ScannerSettingManager.Settings.Add(new ScannerSetting(this.ScanSource, imageViewer.Brightness, imageViewer.Contrast));
                ScannerSettingManager.SaveAndReload();
            }
        }

        private void imageViewer_ContrastApplied(object sender, EventArgs e)
        {
            if (this.ScanSource != null)
            {
                foreach (var item in ScannerSettingManager.Settings)
                {
                    if (item.Scanner == this.ScanSource)
                    {
                        item.Contrast = imageViewer.Contrast;
                        ScannerSettingManager.SaveAndReload();
                        return;
                    }
                }
                ScannerSettingManager.Settings.Add(new ScannerSetting(this.ScanSource, imageViewer.Brightness, imageViewer.Contrast));
                ScannerSettingManager.SaveAndReload();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImportFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (btnScan.Enabled && btnScan.Visible)
                    InvokeOnClick(btnScan, EventArgs.Empty);
            }
        }

        private void btnSelectSavePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDefaultSavePath.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
