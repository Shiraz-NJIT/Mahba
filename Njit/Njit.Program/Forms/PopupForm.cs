using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace Njit.Program.Forms
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        [Flags]
        public enum PopupAnimations
        {
            None = 0,
            LeftToRight = 0x00001,
            RightToLeft = 0x00002,
            TopToBottom = 0x00004,
            BottomToTop = 0x00008,
            Center = 0x00010,
            Slide = 0x40000,
            Blend = 0x80000,
            Roll = 0x100000,
            SystemDefault = 0x200000,
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Hide();
            base.OnFormClosed(e);
        }

        public void SendCaptionHitTest()
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.AutoDrag && e.Button == MouseButtons.Left)
            {
                SendCaptionHitTest();
            }
        }

        private bool _DropShadow = true;
        [DefaultValue(true)]
        public bool DropShadow
        {
            get
            {
                return _DropShadow;
            }
            set
            {
                _DropShadow = value;
            }
        }

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (this.DropShadow)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

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
            int AnimationDuration = this.Visible ? this.ShowingDuration : this.HidingDuration;
            PopupAnimations _flags = this.Visible ? this.ShowingAnimation : this.HidingAnimation;
            PopupNativeMethods.AnimationFlags flags = this.Visible ? PopupNativeMethods.AnimationFlags.Roll : PopupNativeMethods.AnimationFlags.Hide;
            flags = flags | (PopupNativeMethods.AnimationFlags.Mask & (PopupNativeMethods.AnimationFlags)(int)_flags);
            PopupNativeMethods.AnimateWindow(this, AnimationDuration, flags);
        }

        int _ShowingDuration = 100;
        [DefaultValue(100)]
        [Category("Njit")]
        public int ShowingDuration
        {
            get
            {
                return _ShowingDuration;
            }
            set
            {
                _ShowingDuration = value;
            }
        }
        int _HidingDuration = 100;
        [DefaultValue(100)]
        [Category("Njit")]
        public int HidingDuration
        {
            get
            {
                return _HidingDuration;
            }
            set
            {
                _HidingDuration = value;
            }
        }
        PopupAnimations _ShowingAnimation = PopupAnimations.Slide | PopupAnimations.TopToBottom;
        [Category("Njit")]
        [DefaultValue(typeof(PopupAnimations), "TopToBottom,Slide")]
        public PopupAnimations ShowingAnimation
        {
            get
            {
                return _ShowingAnimation;
            }
            set
            {
                _ShowingAnimation = value;
            }
        }
        PopupAnimations _HidingAnimation = PopupAnimations.Slide | PopupAnimations.TopToBottom;
        [Category("Njit")]
        [DefaultValue(typeof(PopupAnimations), "TopToBottom,Slide")]
        public PopupAnimations HidingAnimation
        {
            get
            {
                return _HidingAnimation;
            }
            set
            {
                _HidingAnimation = value;
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

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
        }

        public void RefreshRegion()
        {
            if (_Angle > 0 && !this.DesignMode)
            {
                this.Region = new System.Drawing.Region(Njit.Common.Helpers.GraphicsHelper.GetRoundedRectanglePath(0, 0, this.Width, this.Height, _Angle));
            }
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

        private bool _Resizable = false;
        [DefaultValue(false)]
        public bool Resizable
        {
            get
            {
                return _Resizable;
            }
            set
            {
                _Resizable = value;
            }
        }

        public static class PopupNativeMethods
        {
            public const int WM_NCHITTEST = 0x0084,
                               WM_NCACTIVATE = 0x0086,
                               WS_EX_TRANSPARENT = 0x00000020,
                               WS_EX_TOOLWINDOW = 0x00000080,
                               WS_EX_LAYERED = 0x00080000,
                               WS_EX_NOACTIVATE = 0x08000000,
                               HTTRANSPARENT = -1,
                               HTLEFT = 10,
                               HTRIGHT = 11,
                               HTTOP = 12,
                               HTTOPLEFT = 13,
                               HTTOPRIGHT = 14,
                               HTBOTTOM = 15,
                               HTBOTTOMLEFT = 16,
                               HTBOTTOMRIGHT = 17,
                               WM_PRINT = 0x0317,
                               WM_USER = 0x0400,
                               WM_REFLECT = WM_USER + 0x1C00,
                               WM_COMMAND = 0x0111,
                               CBN_DROPDOWN = 7,
                               WM_GETMINMAXINFO = 0x0024;

            private static HandleRef HWND_TOPMOST = new HandleRef(null, new IntPtr(-1));

            [Flags]
            public enum AnimationFlags : int
            {
                Roll = 0x0000, // Uses a roll animation.
                HorizontalPositive = 0x00001, // Animates the window from left to right. This flag can be used with roll or slide animation.
                HorizontalNegative = 0x00002, // Animates the window from right to left. This flag can be used with roll or slide animation.
                VerticalPositive = 0x00004, // Animates the window from top to bottom. This flag can be used with roll or slide animation.
                VerticalNegative = 0x00008, // Animates the window from bottom to top. This flag can be used with roll or slide animation.
                Center = 0x00010, // Makes the window appear to collapse inward if Hide is used or expand outward if the Hide is not used.
                Hide = 0x10000, // Hides the window. By default, the window is shown.
                Activate = 0x20000, // Activates the window.
                Slide = 0x40000, // Uses a slide animation. By default, roll animation is used.
                Blend = 0x80000, // Uses a fade effect. This flag can be used only with a top-level window.
                Mask = 0xfffff,
            }

            [System.Security.SuppressUnmanagedCodeSecurity]
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern int AnimateWindow(HandleRef windowHandle, int time, AnimationFlags flags);

            public static void AnimateWindow(Control control, int time, AnimationFlags flags)
            {
                try
                {
                    SecurityPermission sp = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                    sp.Demand();
                    AnimateWindow(new HandleRef(control, control.Handle), time, flags);
                }
                catch (SecurityException) { }
            }

            [SuppressUnmanagedCodeSecurity]
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

            public static void SetTopMost(Control control)
            {
                try
                {
                    SecurityPermission sp = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                    sp.Demand();
                    SetWindowPos(new HandleRef(control, control.Handle), HWND_TOPMOST, 0, 0, 0, 0, 0x13);
                }
                catch (SecurityException) { }
            }

            public static int HIWORD(int n)
            {
                return (short)((n >> 16) & 0xffff);
            }

            public static int HIWORD(IntPtr n)
            {
                return HIWORD(unchecked((int)(long)n));
            }

            public static int LOWORD(int n)
            {
                return (short)(n & 0xffff);
            }

            public static int LOWORD(IntPtr n)
            {
                return LOWORD(unchecked((int)(long)n));
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MINMAXINFO
            {
                public Point reserved;
                public Size maxSize;
                public Point maxPosition;
                public Size minTrackSize;
                public Size maxTrackSize;
            }

            private static bool? _isRunningOnMono;
            public static bool IsRunningOnMono
            {
                get
                {
                    if (!_isRunningOnMono.HasValue)
                        _isRunningOnMono = Type.GetType("Mono.Runtime") != null;
                    return _isRunningOnMono.Value;
                }
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool ProcessResizing(ref Message m)
        {
            if (m.Msg == Njit.Common.Popup.NativeMethods.WM_NCHITTEST)
                return OnNcHitTest(ref m);
            return false;
        }

        private bool OnNcHitTest(ref Message m)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            Point clientLocation = PointToClient(new Point(x, y));

            Njit.Common.Popup.GripBounds gripBouns = new Njit.Common.Popup.GripBounds(ClientRectangle);

            if (gripBouns.BottomRight.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTBOTTOMRIGHT;
                return true;
            }
            if (gripBouns.TopRight.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTTOPRIGHT;
                return true;
            }
            if (gripBouns.BottomLeft.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTBOTTOMLEFT;
                return true;
            }
            if (gripBouns.TopLeft.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTTOPLEFT;
                return true;
            }
            if (gripBouns.Top.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTTOP;
                return true;
            }
            if (gripBouns.Left.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTLEFT;
                return true;
            }
            if (gripBouns.Bottom.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTBOTTOM;
                return true;
            }
            if (gripBouns.Right.Contains(clientLocation))
            {
                m.Result = (IntPtr)Njit.Common.Popup.NativeMethods.HTRIGHT;
                return true;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            if (this.Resizable && this.ProcessResizing(ref m))
                return;
            base.WndProc(ref m);
        }
    }
}
