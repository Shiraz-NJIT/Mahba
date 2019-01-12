using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class ArchivesDiskSpaceManage : View.BaseForms.AlertBase
    {
        public ArchivesDiskSpaceManage()
        {
            InitializeComponent();
            this.Angle = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var archive in Controller.Common.ArchiveController.GetActiveArchives())
            {
                View.Controls.ArchiveDiskSpaceView c = new Controls.ArchiveDiskSpaceView(archive.Title, archive.DatabasePath[0]);
                c.Dock = DockStyle.Top;
                contentPanel.Controls.Add(c);
                c.BringToFront();
            }
        }

        protected override void SetLocation()
        {
            this.Location = new System.Drawing.Point(View.Main.Instance.Location.X + 15, View.Main.Instance.Location.Y + View.Main.Instance.Height - this.Height - View.Main.Instance.statusBar.Height - 15);
        }

        protected override void SetSize()
        {

        }
    }
}
