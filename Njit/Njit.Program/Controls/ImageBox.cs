using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.Controls
{
    public partial class ImageBox : UserControl
    {
        public ImageBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, false);
            this.AutoScroll = true;
        }

        private Image _Image;
        [DefaultValue(null)]
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                try
                {
                    if (_Image != null)
                        _Image.Dispose();
                }
                catch { }
                _Image = value;
                if (value != null)
                    this.AutoScrollMinSize = value.Size;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.Image != null)
                e.Graphics.DrawImageUnscaled(this.Image, this.AutoScrollPosition);
        }

        bool isMouseDown = false;
        Point mousePosition = Point.Empty;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            isMouseDown = true;
            mousePosition = e.Location;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isMouseDown = false;
            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isMouseDown)
            {
                int x = this.HorizontalScroll.Value;
                if ((e.X - mousePosition.X) > 0)
                    x -= (e.X - mousePosition.X);
                else if ((e.X - mousePosition.X) < -0)
                    x += Math.Abs(e.X - mousePosition.X);
                if (x >= this.HorizontalScroll.Minimum && x <= this.HorizontalScroll.Maximum)
                    this.HorizontalScroll.Value = x;

                int y = this.VerticalScroll.Value;
                if ((e.Y - mousePosition.Y) > 0)
                    y -= (e.Y - mousePosition.Y);
                else if ((e.Y - mousePosition.Y) < -0)
                    y += Math.Abs(e.Y - mousePosition.Y);
                if (y >= this.VerticalScroll.Minimum && y <= this.VerticalScroll.Maximum)
                    this.VerticalScroll.Value = y;

                mousePosition = e.Location;
            }
        }

        internal void SetAutoScrollMinSize()
        {
            if (this.Image != null)
                this.AutoScrollMinSize = this.Image.Size;
        }
    }
}
