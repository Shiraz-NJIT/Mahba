using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Njit.Program.Forms
{
    public partial class AeroPeekForm : Form
    {
        public AeroPeekForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private bool _AutoDrag = true;
        [DefaultValue(true)]
        public bool AutoDrag
        {
            get
            {
                return _AutoDrag;
            }
            set
            {
                _AutoDrag = value;
            }
        }

        delegate void AeroPeekEffectDelegate(bool show);

        private bool _HideAnimation = true;
        [DefaultValue(true)]
        public bool HideAnimation
        {
            get
            {
                return _HideAnimation;
            }
            set
            {
                _HideAnimation = value;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel)
            {
                if (HideAnimation)
                {
                    e.Cancel = true;
                    HideAnimation = false;
                    IAsyncResult invokeResult = BeginInvoke(new AeroPeekEffectDelegate(AeroPeekEffect), false);
                    EndInvoke(invokeResult);
                    this.Close();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.AutoDrag && e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //private const int CS_DROPSHADOW = 0x00020000;
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DROPSHADOW;
        //        return cp;
        //    }
        //}

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!DesignMode && Visible)
            {
                IAsyncResult invokeResult = BeginInvoke(new AeroPeekEffectDelegate(AeroPeekEffect), true);
                EndInvoke(invokeResult);
            }
        }

        int _Angle = 10;
        [DefaultValue(10)]
        [Category("Njit")]
        public int Angle
        {
            get
            {
                return _Angle;
            }
            set
            {
                _Angle = value;
            }
        }

        public void RefreshRegion()
        {
            if (_Angle > 0 && !this.DesignMode)
                this.Region = new System.Drawing.Region(Njit.Common.Helpers.GraphicsHelper.GetRoundedRectanglePath(ClientRectangle, _Angle));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RefreshRegion();
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(HandleRef hObject);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        static double opacitySpeed;
        public void AeroPeekEffect(bool show)
        {
            //if (InvokeRequired)
            //{
            //    AeroPeekEffectDelegate aeroPeekEffectDelegate = new AeroPeekEffectDelegate(AeroPeekEffect);
            //    aeroPeekEffectDelegate.Invoke(show);
            //    return;
            //}
            if (show)
            {
                this.Opacity = 0;
                this.Top -= 30;
            }
            opacitySpeed = .01;
            foreach (Control c in this.Controls)
            {
                c.Tag = c.Visible;
                c.Visible = false;
            }
            this.Refresh();

            while (show ? (this.Opacity < 1) : (this.Opacity > 0))
            {
                if (show)
                {
                    this.Opacity += opacitySpeed;
                    this.Top += 2;
                }
                else
                {
                    this.Opacity -= opacitySpeed;
                    this.Top -= 1;
                }
                System.Threading.Thread.Sleep(5);
                opacitySpeed += .01;
                this.Refresh();
            }
            if (show)
                this.Opacity = 1;

            foreach (Control c in this.Controls)
                c.Visible = (bool)c.Tag;
            this.Refresh();
        }
    }
}
