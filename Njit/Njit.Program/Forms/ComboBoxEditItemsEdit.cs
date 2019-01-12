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
    internal partial class ComboBoxEditItemsEdit : OKCancelForm
    {
        public ComboBoxEditItemsEdit(string value)
        {
            InitializeComponent();
            textBox.Text = value;
        }

        private string _Value;
        public string Value
        {
            get
            {
                return _Value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this._Value = textBox.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
