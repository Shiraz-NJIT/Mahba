using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.PersonManageForms
{
    public partial class RightfulPersonAddEdit : Njit.Program.Forms.OKCancelForm
    {
        public RightfulPersonAddEdit()
        {
            InitializeComponent();
            rightfulPersonBindingSource.DataSource = RightfulPerson = new Model.Archive.RightfulPerson();
        }

        public RightfulPersonAddEdit(int id)
        {
            InitializeComponent();
            EditMode = true;
            rightfulPersonBindingSource.DataSource = RightfulPerson = Controller.Archive.RightfulPersonController.GetRightfulPerson(id);
            OriginalRightfulPerson = Controller.Archive.RightfulPersonController.GetRightfulPerson(id);
        }

        bool EditMode;

        private Model.Archive.RightfulPerson _RightfulPerson;
        private Model.Archive.RightfulPerson RightfulPerson
        {
            get
            {
                return _RightfulPerson;
            }
            set
            {
                _RightfulPerson = value;
            }
        }

        private Model.Archive.RightfulPerson _OriginalRightfulPerson;
        private Model.Archive.RightfulPerson OriginalRightfulPerson
        {
            get
            {
                return _OriginalRightfulPerson;
            }
            set
            {
                _OriginalRightfulPerson = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnOK))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            try
            {
                ValidateContent();
            }
            catch (Njit.Common.ValidateException ex)
            {
                if (ex.Control != null)
                {
                    ex.Control.TextChanged -= ControlTextChanged;
                    ex.Control.Leave -= ControlLeave;
                }
                PersianMessageBox.Show(ex.Message);
                if (ex.Control != null)
                {
                    ex.Control.Focus();
                    ex.Control.TextChanged += ControlTextChanged;
                    ex.Control.Leave += ControlLeave;
                    errorProvider.SetError(ex.Control, ex.Message);
                }
                return;
            }
            int personID;
            try
            {
                if (!EditMode)
                    personID = Controller.Archive.RightfulPersonController.Add(this.RightfulPerson);
                else
                    personID = Controller.Archive.RightfulPersonController.Update(this.RightfulPerson, this.OriginalRightfulPerson.Id);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
            this.Tag = personID;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ValidateContent()
        {
            if (firstnameTextBox.Text == "")
                throw new Njit.Common.ValidateException(firstnameTextBox, "نام را وارد کنید");
            if (lastnameTextBox.Text == "")
                throw new Njit.Common.ValidateException(lastnameTextBox, "نام خانوادگی را وارد کنید");
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
