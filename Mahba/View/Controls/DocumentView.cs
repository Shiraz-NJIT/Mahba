using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.Controls
{
    public partial class DocumentView : UserControl
    {
        public DocumentView(Model.Archive.Document document)
        {
            InitializeComponent();
            this.document = document;
            this.DoubleBuffered = true;
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Controller.Archive.DocumentController.GetDocumentThumb(document, this.Size);
            if (this.BackgroundImage != null)
                this.Size = this.BackgroundImage.Size;
            this.ResizeRedraw = true;
        }

        Model.Archive.Document document;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.Lavender, 8))
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }

        bool drag;
        Point mouseDownLocation;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDownLocation = e.Location;
            drag = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (drag)
            {
                ToolStripDropDown menu = this.Parent as ToolStripDropDown;
                menu.Location = new Point(menu.Location.X + (e.Location.X - mouseDownLocation.X), menu.Location.Y + (e.Location.Y - mouseDownLocation.Y));
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            drag = false;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            ToolStripDropDown menu = this.Parent as ToolStripDropDown;
            if (menu != null)
                menu.Close();
        }

        protected override void WndProc(ref Message m)
        {
            if (Parent is Njit.Common.Popup.Popup && (Parent as Njit.Common.Popup.Popup).ProcessResizing(ref m))
                return;
            base.WndProc(ref m);
        }
    }
}
