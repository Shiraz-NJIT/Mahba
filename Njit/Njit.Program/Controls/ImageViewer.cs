using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Njit.MessageBox;

namespace Njit.Program.Controls
{
    public partial class ImageViewer : UserControl
    {
        public ImageViewer()
        {
            InitializeComponent();
            this.Files = new System.Collections.ObjectModel.ObservableCollection<string>();
            this.Files.CollectionChanged += Files_CollectionChanged;
        }

        string[] imageExtensions = new string[] { ".png", ".bmp", ".jpg", ".jpeg", ".tif", ".tiff" };
        bool autoChangePosition = true;
        Image copyOfImage = null;
        Image originalImage = null;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetPageButtonsLocation();
        }

        private void Files_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.autoChangePosition)
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        this.Position = e.NewStartingIndex;
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        this.Position++;
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                        this.Position = -1;
                        break;
                }
            }
            SetDescription();
            toolStripButtonNext.Enabled = toolStripButtonPrevious.Enabled = this.Files.Count > 1;
        }

        private System.Collections.ObjectModel.ObservableCollection<string> _Files;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Collections.ObjectModel.ObservableCollection<string> Files
        {
            get
            {
                return _Files;
            }
            set
            {
                _Files = value;
                Reset();
            }
        }

        public void AddFile(string filePath)
        {
            autoChangePosition = false;
            this.Files.Add(filePath);
            this.Position = this.Files.Count - 1;
            autoChangePosition = true;
        }

        public void AddRange(string[] files)
        {
            autoChangePosition = false;
            foreach (string item in files)
                this.Files.Add(item);
            this.Position = this.Files.Count - 1;
            autoChangePosition = true;
        }

        public void InsertFile(string filePath)
        {
            autoChangePosition = false;
            this.Files.Insert(this.Position + 1, filePath);
            this.Position = this.Position + 1;
            autoChangePosition = true;
        }

        public void InsertRange(string[] files)
        {
            autoChangePosition = false;
            int i = 0;
            foreach (string item in files)
                this.Files.Insert(this.Position + ++i, item);
            this.Position = this.Position + i;
            autoChangePosition = true;
        }

        public void InsertFile(int index, string filePath)
        {
            autoChangePosition = false;
            this.Files.Insert(index, filePath);
            this.Position = index;
            autoChangePosition = true;
        }

        public void Reset()
        {
            if (this.Files.Count == 0)
                this.Position = -1;
            else
                this.Position = 0;
        }

        private int _Position = -1;
        [DefaultValue(-1)]
        [Browsable(false)]
        public int Position
        {
            get
            {
                return _Position;
            }
            set
            {
                if (this.Files.Count == 0)
                    _Position = -1;
                else
                {
                    if (value >= this.Files.Count)
                        _Position = 0;
                    else if (value < 0)
                        _Position = this.Files.Count - 1;
                    else
                        _Position = value;
                }
                SetDescription();
                LoadImage();
            }
        }

        private void SetDescription()
        {
            string text = "";
            if (this.Position >= 0)
                text += "فایل " + (this.Position + 1).ToString() + " از " + this.Files.Count.ToString();
            if (this.PageCount > 1)
                text += " (صفحه " + (this.PagePosition + 1).ToString() + " از " + this.PageCount.ToString() + ")";
            toolStripLabelDescription.Text = text;
        }

        private int _PagePosition = 0;
        [DefaultValue(0)]
        [Browsable(false)]
        public int PagePosition
        {
            get
            {
                return _PagePosition;
            }
            set
            {
                if (value == _PagePosition)
                    return;
                if (imageBox.Image == null || this.PageCount == 0)
                {
                    _PagePosition = 0;
                    return;
                }
                _PagePosition = value;
                if (_PagePosition >= this.PageCount)
                    _PagePosition = this.PageCount - 1;
                else if (_PagePosition < 0)
                    _PagePosition = 0;
                imageBox.Image.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, _PagePosition);
                imageBox.Invalidate();
                SetDescription();
            }
        }

        private int _PageCount = 0;
        [DefaultValue(0)]
        [Browsable(false)]
        public int PageCount
        {
            get
            {
                return _PageCount;
            }
            private set
            {
                _PageCount = value;
                panelPageNavigation.Visible = value > 1;
                SetDescription();
            }
        }

        public event EventHandler ImageLoaded;
        protected virtual void OnImageLoaded()
        {
            _Brightness = _Contrast = 0;
            if (ImageLoaded != null)
                ImageLoaded(this, EventArgs.Empty);
        }

        public void ReLoadImage()
        {
            LoadImageInternal(false);
        }

        public void LoadImage()
        {
            LoadImageInternal(true);
        }

        private void LoadImageInternal(bool isNewImage)
        {
            if (this.Position == -1)
            {
                originalImage = copyOfImage = imageBox.Image = null;
                PageCount = 0;
                this.PagePosition = 0;
            }
            else
            {
                try
                {
                    if (CurrentFileIsImage())
                    {
                        imageBox.Image = Image.FromFile(this.Files[this.Position]);
                        copyOfImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                        if (isNewImage)
                            originalImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                    }
                    else
                    {
                        imageBox.Image = Icon.ExtractAssociatedIcon(this.Files[this.Position]).ToBitmap();
                        copyOfImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                        if (isNewImage)
                            originalImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                    }
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در بارگذاری تصویر" + "\r\n\r\n" + ex.Message);
                    return;
                }
                imageBox.Invalidate();
                this.PageCount = imageBox.Image.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                this.PagePosition = 0;
                OnImageLoaded();
            }
        }

        private bool CurrentFileIsImage()
        {
            if (this.Position < 0)
                return false;
            return imageExtensions.Contains(System.IO.Path.GetExtension(this.Files[this.Position]).ToLower());
        }

        public void Next()
        {
            this.Position++;
        }

        public void Previous()
        {
            this.Position--;
        }

        //public static Bitmap RotateImage(Image image, float angle)
        //{
        //    Bitmap bitmap = new Bitmap(image.Width, image.Height);
        //    Graphics g = Graphics.FromImage(bitmap);
        //    g.RotateTransform(angle);
        //    g.DrawImageUnscaled(image, new Point(0, 0));
        //    g.Dispose();
        //    return bitmap;
        //}

        private void btnPageNext_Click(object sender, EventArgs e)
        {
            this.PagePosition++;
        }

        private void btnPagePrev_Click(object sender, EventArgs e)
        {
            this.PagePosition--;
        }

        public int SaveAsImages(Action<string> saveMethod)
        {
            Njit.Program.Forms.SaveFiles saveForm = new Njit.Program.Forms.SaveFiles(saveMethod, this.Files.ToArray(), (string)null, null, false);
            saveForm.ShowDialog();
            if (saveForm.Tag is int)
                return (int)saveForm.Tag;
            else
                return 0;
        }

        public int SaveAsImages(string savePath, bool useDateTimeForFileNames)
        {
            Njit.Program.Forms.SaveFiles saveForm = new Njit.Program.Forms.SaveFiles(null, this.Files.ToArray(), savePath, new Njit.Common.SystemUtility(), useDateTimeForFileNames);
            saveForm.ShowDialog();
            if (saveForm.Tag is int)
                return (int)saveForm.Tag;
            else
                return 0;
        }

        public void CloseImage()
        {
            if (imageBox.Image != null)
                imageBox.Image.Dispose();
            originalImage = copyOfImage = imageBox.Image = null;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetPageButtonsLocation();
        }

        private void SetPageButtonsLocation()
        {
            if (panelPageNavigation.Visible)
            {
                btnPageNext.Left = this.Width / 2 + 1;
                btnPagePrev.Left = this.Width / 2 - btnPagePrev.Width;
            }
        }

        private void panelPageNavigation_VisibleChanged(object sender, EventArgs e)
        {
            SetPageButtonsLocation();
        }

        private void toolStripButtonNext_Click(object sender, EventArgs e)
        {
            this.Next();
        }

        private void toolStripButtonPrevious_Click(object sender, EventArgs e)
        {
            this.Previous();
        }

        private void toolStripButtonRotateRight_Click(object sender, EventArgs e)
        {
            if (CurrentFileIsImage() && imageBox.Image != null)
            {
                try
                {
                    imageBox.Image.Dispose();
                    imageBox.Image = Njit.Common.Helpers.ImageHelper.RotateImage(this.Files[this.Position], RotateFlipType.Rotate90FlipNone);
                    copyOfImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                    originalImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ذخیره تصویر" + "\r\n\r\n" + ex.Message);
                }
            }
        }

        private void toolStripButtonRotateLeft_Click(object sender, EventArgs e)
        {
            if (CurrentFileIsImage() && imageBox.Image != null)
            {
                try
                {
                    imageBox.Image.Dispose();
                    imageBox.Image = Njit.Common.Helpers.ImageHelper.RotateImage(this.Files[this.Position], RotateFlipType.Rotate270FlipNone);
                    copyOfImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                    originalImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ذخیره تصویر" + "\r\n\r\n" + ex.Message);
                }
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (this.Files.Count > 0 && this.Position >= 0)
            {
                this.Files.RemoveAt(this.Position);
            }
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            CloseImage();
            this.Files.Clear();
        }

        private void SetBrightness(int brightness)
        {
            if (imageBox.Image != null)
            {
                if (copyOfImage == null)
                    copyOfImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                imageBox.Image = Njit.Common.Helpers.ImageHelper.SetBrightness(copyOfImage, brightness);
            }
        }

        private void SetContrast(int contrast)
        {
            if (imageBox.Image != null)
            {
                if (copyOfImage == null)
                    copyOfImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                imageBox.Image = Njit.Common.Helpers.ImageHelper.SetContrast(copyOfImage, (sbyte)contrast);
            }
        }

        private void SetGamma(int gamma)
        {
            if (imageBox.Image != null)
            {
                if (copyOfImage == null)
                    copyOfImage = Njit.Common.Helpers.ImageHelper.GetMultiCopyOfImage(imageBox.Image);
                imageBox.Image = Njit.Common.Helpers.ImageHelper.SetGamma(copyOfImage, gamma);
            }
        }

        private void SetGrayscale()
        {
            if (imageBox.Image != null)
            {
                imageBox.Image = Njit.Common.Helpers.ImageHelper.SetGrayScale(imageBox.Image);
            }
        }

        public event EventHandler BrightnessChanged;
        protected virtual void OnBrightnessChanged()
        {
            if (BrightnessChanged != null)
                BrightnessChanged(this, EventArgs.Empty);
        }

        public event EventHandler BrightnessApplied;
        protected virtual void OnBrightnessApplied()
        {
            if (BrightnessApplied != null)
                BrightnessApplied(this, EventArgs.Empty);
        }

        private int _Brightness = 0;
        [DefaultValue(0)]
        public int Brightness
        {
            get
            {
                return _Brightness;
            }
            set
            {
                if (value >= -255 && value <= 255 && _Brightness != value)
                {
                    _Brightness = value;
                    SetBrightness(value);
                    OnBrightnessChanged();
                }
            }
        }

        public event EventHandler ContrastChanged;
        protected virtual void OnContrastChanged()
        {
            if (ContrastChanged != null)
                ContrastChanged(this, EventArgs.Empty);
        }

        public event EventHandler ContrastApplied;
        protected virtual void OnContrastApplied()
        {
            if (ContrastApplied != null)
                ContrastApplied(this, EventArgs.Empty);
        }

        private int _Contrast = 0;
        [DefaultValue(0)]
        public int Contrast
        {
            get
            {
                return _Contrast;
            }
            set
            {
                if (value >= -100 && value <= 100 && _Contrast != value)
                {
                    _Contrast = value;
                    SetContrast(value);
                    OnContrastChanged();
                }
            }
        }

        private void btnBrightness_Click(object sender, EventArgs e)
        {
            if (this.imageBox.Image != null)
            {
                Njit.Program.Controls.SetBrightness trackBarBrightness = new Njit.Program.Controls.SetBrightness();
                trackBarBrightness.Minimum = -255;
                trackBarBrightness.Maximum = 255;
                trackBarBrightness.Value = this.Brightness;
                //trackBarBrightness.Width = 300;
                trackBarBrightness.ValueChanged += trackBarBrightness_ValueChanged;
                trackBarBrightness.Reset += trackBarBrightness_Reset;
                Njit.Common.Popup.Popup popupBrightness = new Common.Popup.Popup(trackBarBrightness, true, true, true, true, Common.Popup.PopupAnimations.Blend, 100, Common.Popup.PopupAnimations.Blend, 100);
                popupBrightness.Closed += brightnessPopup_Closed;
                popupBrightness.Show(System.Windows.Forms.Cursor.Position);
            }
        }

        private void trackBarBrightness_Reset(object sender, EventArgs e)
        {
            this.ResetImage();
        }

        private void ResetImage()
        {
            if (this.imageBox.Image != null && originalImage != null)
            {
                byte[] data = Njit.Common.Helpers.ImageHelper.GetImageBytes(originalImage, ((this.imageBox.Image.RawFormat.Guid == ImageFormat.MemoryBmp.Guid) ? ImageFormat.Png : this.imageBox.Image.RawFormat));
                this.CloseImage();
                System.IO.File.WriteAllBytes(this.Files[this.Position], data);
                this.LoadImage();
            }
        }

        private void brightnessPopup_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.OnBrightnessApplied();
            this.SaveAndReloadImage();
        }

        private void contrastPopup_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.OnContrastApplied();
            this.SaveAndReloadImage();
        }

        private void gammaPopup_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.SaveAndReloadImage();
        }

        public void SaveAndReloadImage()
        {
            try
            {
                if (this.imageBox.Image != null)
                {
                    if (this.imageBox.Image.GetFrameCount(FrameDimension.Page) > 1)
                    {
                        byte[] data = Njit.Common.Helpers.ImageHelper.GetMultiTiffImageBytes(this.imageBox.Image);
                        this.imageBox.Image.Dispose();
                        System.IO.File.WriteAllBytes(this.Files[this.Position], data);
                    }
                    else
                    {
                        byte[] data = Njit.Common.Helpers.ImageHelper.GetImageBytes(this.imageBox.Image, this.imageBox.Image.RawFormat.Guid == ImageFormat.MemoryBmp.Guid ? ImageFormat.Png : this.imageBox.Image.RawFormat);
                        this.imageBox.Image.Dispose();
                        System.IO.File.WriteAllBytes(this.Files[this.Position], data);
                    }
                    this.ReLoadImage();
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ذخیره تصویر" + "\r\n\r\n" + ex.Message);
            }
        }

        private void trackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            this.Brightness = ((sender as Controls.SetBrightness).Value);
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {
            if (this.imageBox.Image != null)
            {
                Njit.Program.Controls.SetBrightness setBrightness = new Njit.Program.Controls.SetBrightness();
                setBrightness.Minimum = -100;
                setBrightness.Maximum = 100;
                setBrightness.Value = this.Contrast;
                //trackContrast.Width = 300;
                setBrightness.ValueChanged += trackContrast_ValueChanged;
                setBrightness.Reset += trackContrast_Reset;
                Njit.Common.Popup.Popup popupContrast = new Common.Popup.Popup(setBrightness, true, true, true, true, Common.Popup.PopupAnimations.Blend, 100, Common.Popup.PopupAnimations.Blend, 300);
                popupContrast.Closed += contrastPopup_Closed;
                popupContrast.Show(System.Windows.Forms.Cursor.Position);
            }
        }

        private void trackContrast_Reset(object sender, EventArgs e)
        {
            this.ResetImage();
        }

        private void trackContrast_ValueChanged(object sender, EventArgs e)
        {
            this.Contrast = ((sender as Njit.Program.Controls.SetBrightness).Value);
        }

        private void btnGamma_Click(object sender, EventArgs e)
        {
            TrackBar trackGamma = new TrackBar();
            trackGamma.Minimum = 2;
            trackGamma.Maximum = 50;
            trackGamma.Width = 300;
            trackGamma.Scroll += trackGamma_Scroll;
            Njit.Common.Popup.Popup popupGamma = new Common.Popup.Popup(trackGamma, true, true, true, true, Common.Popup.PopupAnimations.Blend, 100, Common.Popup.PopupAnimations.Blend, 100);
            popupGamma.Closed += gammaPopup_Closed;
            popupGamma.Show(System.Windows.Forms.Cursor.Position);
        }

        private void trackGamma_Scroll(object sender, EventArgs e)
        {
            SetGamma((sender as TrackBar).Value / 10);
        }
    }
}
