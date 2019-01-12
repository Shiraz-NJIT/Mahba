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
    public partial class DiskSpaceProgress : UserControl
    {
        public DiskSpaceProgress()
        {
            InitializeComponent();
        }

        static Size _DefaultSize = new Size(150, 14);
        protected override Size DefaultSize
        {
            get
            {
                return _DefaultSize;
            }
        }

        private int _Value = 0;
        [DefaultValue(0)]
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen borderPen = new Pen(Color.LightSlateGray);
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, 0, 0, this.Width - 1, this.Height - 1);
            if (this.Value < 90)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, 0, 0, this.Width * this.Value / 100, this.Height - 1);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.IndianRed, 0, 0, this.Width * this.Value / 100, this.Height - 1);
            }
            e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            borderPen.Dispose();
        }
    }
}
