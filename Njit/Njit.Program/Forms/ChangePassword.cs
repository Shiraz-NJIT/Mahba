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
    public partial class ChangePassword : Njit.Program.Forms.BaseFormDialog 
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(bool FirstRun)
        {
            InitializeComponent();
            if (this.DesignMode)
                return;
            if (FirstRun)
            {
                if (GetCurrentUserPassword() == HashData(""))
                    txtCurrent.Enabled = lblCurrent.Enabled = false;
            }
        }

        protected virtual string HashData(string data)
        {
            return null;
        }

        protected virtual string GetCurrentUserPassword()
        {
            return null;
        }

        protected virtual void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnOk || this.ActiveControl == txtConfirm))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            if (HasError())
                return;
            if (!ChangeCurrentUserPassword(txtCurrent.Text, txtNew.Text))
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        protected virtual bool ChangeCurrentUserPassword(string currentPassword, string newPassword)
        {
            return false;
        }

        protected virtual bool HasError()
        {
            return false;
        }
    }
}
