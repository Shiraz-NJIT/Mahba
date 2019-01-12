using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace NjitSoftware.View.BaseForms
{
    public partial class AlertBase : Njit.Program.Forms.PopupForm
    {
        public AlertBase()
        {
            InitializeComponent();
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                SetLocation();
                View.Main.Instance.Move += new EventHandler(MainForm_Move);
                View.Main.Instance.ResizeEnd += new EventHandler(MainForm_ResizeEnd);
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            SetSize();
            SetLocation();
        }

        protected virtual void SetSize()
        {
            if (this.State == FormWindowState.Normal)
                this.Height = View.Main.Instance.Height - View.Main.Instance.mainRibbon.Height - View.Main.Instance.statusBar.Height - 5 - 20;
        }

        protected virtual void SetLocation()
        {
            this.Location = new System.Drawing.Point(View.Main.Instance.Location.X + View.Main.Instance.Width - this.Width - 15, View.Main.Instance.Location.Y + View.Main.Instance.mainRibbon.Height /*- this.Height - UI.Main.Instance.statusBar.Height -*/ + 10);
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            SetLocation();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (!DesignMode)
            {
                View.Main.Instance.Move -= new EventHandler(MainForm_Move);
                View.Main.Instance.ResizeEnd -= new EventHandler(MainForm_ResizeEnd);
            }
            base.OnFormClosed(e);
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (this.State == FormWindowState.Minimized)
                this.State = FormWindowState.Normal;
            else
                this.State = FormWindowState.Minimized;
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.AutoDrag && e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        int height;

        private FormWindowState _State = FormWindowState.Normal;
        [DefaultValue(typeof(FormWindowState), "Normal")]
        public FormWindowState State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
                switch (_State)
                {
                    case FormWindowState.Maximized:
                        break;
                    case FormWindowState.Minimized:
                        if (this.Height > topPanel.Height)
                        {
                            this.Visible = false;
                            height = this.Height;
                            this.Height = topPanel.Height;
                            SetLocation();
                            pictureBoxClose.Image = Properties.Resources.maximize;
                            this.Visible = true;
                        }
                        break;
                    case FormWindowState.Normal:
                        if (height > 0)
                        {
                            this.Visible = false;
                            this.Height = height;
                            SetLocation();
                            pictureBoxClose.Image = Properties.Resources.minimize;
                            this.Visible = true;
                        }
                        break;
                }
            }
        }

    }
}
