using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Njit.Program.Controls
{
    public partial class PictureBoxExtended : System.Windows.Forms.PictureBox
    {
        public PictureBoxExtended()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            imageAttributes = new System.Drawing.Imaging.ImageAttributes();
            colorMatrix = new System.Drawing.Imaging.ColorMatrix();
        }

        System.Threading.Timer timer;

        private bool _Animation = true;
        [DefaultValue(true)]
        public bool Animation
        {
            get
            {
                return _Animation;
            }
            set
            {
                _Animation = value;
            }
        }

        private int _AnimationSpeed = 10;
        [DefaultValue(10)]
        public int AnimationSpeed
        {
            get
            {
                return _AnimationSpeed;
            }
            set
            {
                _AnimationSpeed = value;
            }
        }

        [Bindable(true)]
        [Localizable(true)]
        [DefaultValue(null)]
        public new System.Drawing.Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                if (MarshalByRefObject.ReferenceEquals(this.Image, value))
                    return;
                base.Image = value;
                if (this.Animation)
                    FadeInImage();
            }
        }

        private void FadeInImage()
        {
            if (this.Image == null)
                return;
            speed = 0.00f;
            transparency = 0.0f;
            timer = new System.Threading.Timer(TimerTick, null, 0, this.AnimationSpeed);
        }

        private void TimerTick(object state)
        {
            speed += 0.01f;
            transparency += speed;
            if (transparency >= 1f)
            {
                transparency = 1f;
                timer.Dispose();
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.Animation)
                base.OnPaint(e);
            else
            {
                if (this.Image != null)
                {
                    //e.Graphics.InterpolationMode = InterpolationMode.Low;
                    //e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    //e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    colorMatrix.Matrix33 = transparency;
                    imageAttributes.SetColorMatrix(colorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);
                    e.Graphics.DrawImage(this.Image, this.ClientRectangle, 0, 0, this.Image.Width, this.Image.Height, System.Drawing.GraphicsUnit.Pixel, imageAttributes);
                }
            }
        }

        private MemoryStream ms;
        private float speed;
        private float transparency;
        private ImageAttributes imageAttributes;
        private ColorMatrix colorMatrix;

        public void LoadFile(string filePath)
        {
            if (this.Image != null)
                this.Image.Dispose();
            if (ms != null)
                ms.Dispose();
            ms = new System.IO.MemoryStream(System.IO.File.ReadAllBytes(filePath));
            this.Image = System.Drawing.Image.FromStream(ms);
        }
    }
}
