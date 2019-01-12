using Njit.MessageBox;
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
    public partial class GetValue : Njit.Program.Forms.OKCancelForm
    {
        public GetValue()
        {
            InitializeComponent();
        }

        public GetValue(string title, string label)
        {
            InitializeComponent();
            this.Text = title;
            lblTitle.Text = label;
        }

        public GetValue(string title, string label, object defaultValue)
        {
            InitializeComponent();
            this.Text = title;
            lblTitle.Text = label;
            txtName.Text = defaultValue.IsNullOrEmpty() ? "" : defaultValue.ToString();
        }

        private string _Value;
        [DefaultValue(null)]
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                txtName.Text = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(btnOK.Focused || txtName.Focused))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            if (txtName.Text == "")
            {
                PersianMessageBox.Show(this, "هیچ مقداری وارد نشده است");
                txtName.FocusAndSetError("هیچ مقداری وارد نشده است");
                return;
            }
            this._Value = txtName.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
