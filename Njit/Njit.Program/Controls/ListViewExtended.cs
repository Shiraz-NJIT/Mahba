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
    public partial class ListViewExtended : System.Windows.Forms.ListView
    {
        public ListViewExtended()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Njit.Common.Win32.IsVistaOrLater)
                Njit.Common.Win32.SetWindowTheme(this.Handle, "explorer", null);
        }
    }
}
