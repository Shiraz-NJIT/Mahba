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
    public partial class TabAddEdit : Njit.Program.Forms.OKCancelForm
    {
        public TabAddEdit()
        {
            InitializeComponent();
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateContent();
            }
            catch (Njit.Common.ValidateException ex)
            {
                ex.Control.TextChanged -= ControlTextChanged;
                //PersianMessageBox.Show(ex.Message);
                ex.Control.Focus();
                ex.Control.TextChanged += ControlTextChanged;
                errorProvider.SetError(ex.Control, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        protected void ValidateContent()
        {
            if (string.IsNullOrEmpty(txtGroupName.Text))
                throw new Njit.Common.ValidateException(txtGroupName, "نام گروه اطلاعاتی تکمیل نشده است");
        }

        protected void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
