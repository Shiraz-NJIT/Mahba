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
    public partial class TreeViewExtended : System.Windows.Forms.TreeView
    {
        public TreeViewExtended()
        {
            InitializeComponent();
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;
                if (Njit.Common.Win32.IsVistaOrLater)
                    cp.Style |= Njit.Common.Win32.TVS_NOHSCROLL; // lose the horizotnal scrollbar

                return cp;
            }
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Njit.Common.Win32.IsVistaOrLater)
            {  // get style
                int dw = Njit.Common.Win32.SendMessage(this.Handle,
                  Njit.Common.Win32.TVM_GETEXTENDEDSTYLE, 0, 0);

                // Update style
                dw |= Njit.Common.Win32.TVS_EX_AUTOHSCROLL;       // autoscroll horizontaly
                dw |= Njit.Common.Win32.TVS_EX_FADEINOUTEXPANDOS; // auto hide the +/- signs

                // set style
                Njit.Common.Win32.SendMessage(this.Handle,
                  Njit.Common.Win32.TVM_SETEXTENDEDSTYLE, 0, dw);

                // little black/empty arrows and blue highlight on treenodes
                Njit.Common.Win32.SetWindowTheme(this.Handle, "explorer", null);
            }
        }

    }
}
