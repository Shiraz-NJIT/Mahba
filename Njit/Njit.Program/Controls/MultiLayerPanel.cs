using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace Njit.Program.Controls
{
    [Designer(typeof(Njit.Program.Controls.Design.MultiLayerPanelDesigner))]
    [ToolboxItem(typeof(Njit.Program.Controls.Design.MultiPaneControlToolboxItem))]
    [DefaultProperty("SelectedPage")]
    [DefaultEvent("SelectedPageChanged")]
    public class MultiLayerPanel : Control
    {
        protected static readonly System.Drawing.Size _DefaultSize = new System.Drawing.Size(200, 100);
        protected static readonly Padding _DefaultPadding = new Padding(5);

        public event EventHandler SelectedPageChanging;
        public event EventHandler SelectedPageChanged;

        public MultiLayerPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override Padding DefaultPadding
        {
            get
            {
                return _DefaultPadding;
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return _DefaultSize;
            }
        }

        protected Page _SelectedPage;
        [Editor(typeof(Njit.Program.Controls.Design.MultiPaneControlSelectedPageEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DefaultValue(null)]
        public Page SelectedPage
        {
            get
            {
                return _SelectedPage;
            }

            set
            {
                if (_SelectedPage == value)
                    return;
                if (SelectedPageChanging != null)
                    SelectedPageChanging(this, EventArgs.Empty);
                if (_SelectedPage != null)
                    _SelectedPage.Visible = false;
                _SelectedPage = value;
                if (_SelectedPage != null)
                    _SelectedPage.Visible = true;
                if (SelectedPageChanged != null)
                    SelectedPageChanged(this, EventArgs.Empty);
            }
        }

        private bool _DrawVisualStyleBorder = true;
        [DefaultValue(true)]
        public bool DrawVisualStyleBorder
        {
            get
            {
                return _DrawVisualStyleBorder;
            }
            set
            {
                _DrawVisualStyleBorder = value;
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is Page)
            {
                Page multiPanePage = (Page)e.Control;
                multiPanePage.Location = new Point(0, 0);
                multiPanePage.Size = ClientSize;
                multiPanePage.Dock = DockStyle.Fill;
                if (SelectedPage == null)
                    SelectedPage = multiPanePage;
                else
                    multiPanePage.Visible = false;
            }
            else
            {
                Controls.Remove(e.Control);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            foreach (Page c in Controls)
                c.Size = this.ClientSize;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.DrawVisualStyleBorder)
                ControlPaint.DrawVisualStyleBorder(e.Graphics, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }

    [Designer(typeof(Njit.Program.Controls.Design.MultiPanePageDesigner))]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    public class Page : Panel
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Point Location
        {
            get { return base.Location; }
            set { base.Location = value; }
        }
    }
}