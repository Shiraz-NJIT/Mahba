using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Njit.MessageBox;

namespace Njit.Controls
{
    public partial class PictureSelectBox : UserControl
    {
        public PictureSelectBox()
        {
            InitializeComponent();
            myPictureBox.AnimationSpeed = 20;
        }

        public event EventHandler PictureChanged;
        public virtual void OnPictureChanged(EventArgs e)
        {
            if (PictureChanged != null)
                PictureChanged(this, e);
        }

        private MemoryStream _DataStream;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public MemoryStream DataStream
        {
            get
            {
                if (_DataStream == null)
                    _DataStream = new MemoryStream();
                return _DataStream;
            }
            set
            {
                if (_DataStream != null)
                    _DataStream.Dispose();
                _DataStream = value;
                RefreshPicture();
            }
        }

        public void SetImageData(byte[] data)
        {
            if (data == null)
            {
                DeletePicture();
                return;
            }
            if (_DataStream != null)
                this._DataStream.Dispose();
            this._DataStream = new MemoryStream(data);
            RefreshPicture();
        }

        public void RefreshPicture()
        {
            try
            {
                if (_DataStream == null)
                    myPictureBox.Image = null;
                else if (_DataStream.Length > 0)
                    myPictureBox.Image = Image.FromStream(_DataStream);
                else
                    myPictureBox.Image = null;
                OnPictureChanged(EventArgs.Empty);
            }
            catch { }
        }

        private int _MaxWidth = 500;
        [DefaultValue(500)]
        public int MaxWidth
        {
            get
            {
                return _MaxWidth;
            }
            set
            {
                _MaxWidth = value;
            }
        }

        private int _MaxHeight = 500;
        [DefaultValue(500)]
        public int MaxHeight
        {
            get
            {
                return _MaxHeight;
            }
            set
            {
                _MaxHeight = value;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_DataStream != null)
                        this._DataStream.Dispose();
                    this._DataStream = new MemoryStream(File.ReadAllBytes(openFileDialog.FileName));
                    Image tempImg = Image.FromStream(this._DataStream);
                    if (tempImg.Width > this.MaxWidth || tempImg.Height > this.MaxHeight)
                    {
                        DeletePicture();
                        tempImg.Dispose();
                        PersianMessageBox.Show(this, string.Format("اندازه تصویر نباید از {0} در {1} پیکسل بزرگتر باشد", this.MaxWidth, this.MaxHeight));
                        return;
                    }
                    tempImg.Dispose();
                    RefreshPicture();
                }
                catch (Exception ex)
                {
                    DeletePicture();
                    PersianMessageBox.Show(this, "خطا در بارگذاری تصویر" + "\r\n\r\n" + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePicture();
        }

        public void DeletePicture()
        {
            if (_DataStream != null)
                this._DataStream.Dispose();
            this._DataStream = new MemoryStream();
            RefreshPicture();
        }

        private void myPictureBox_Click(object sender, EventArgs e)
        {
            InvokeOnClick(btnSelect, EventArgs.Empty);
        }

    }
}
