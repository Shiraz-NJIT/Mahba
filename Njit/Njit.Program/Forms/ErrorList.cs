using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.Forms
{
    public partial class ErrorList : Njit.Program.Forms.BaseFormSizable
    {
        public ErrorList()
        {
            InitializeComponent();
        }
        public ErrorList(List<string> errorList)
        {
            InitializeComponent();
            foreach (var item in errorList)
            {
                listView.Items.Add(new ListViewItem(item));
            }
            listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
