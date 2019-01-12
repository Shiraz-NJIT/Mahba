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
    public partial class LegalPersonAddEdit : Njit.Program.Forms.OKCancelForm
    {
        public LegalPersonAddEdit()
        {
            InitializeComponent();
            legalPersonBindingSource.DataSource = LegalPerson = new Model.Archive.LegalPerson();
        }

        public LegalPersonAddEdit(int id)
        {
            InitializeComponent();
            EditMode = true;
            legalPersonBindingSource.DataSource = LegalPerson = Controller.Archive.LegalPersonController.GetLegalPerson(id);
            OriginalLegalPerson = Controller.Archive.LegalPersonController.GetLegalPerson(id);
        }

        bool EditMode;

        private Model.Archive.LegalPerson _LegalPerson;
        private Model.Archive.LegalPerson LegalPerson
        {
            get
            {
                return _LegalPerson;
            }
            set
            {
                _LegalPerson = value;
            }
        }

        private Model.Archive.LegalPerson _OriginalLegalPerson;
        private Model.Archive.LegalPerson OriginalLegalPerson
        {
            get
            {
                return _OriginalLegalPerson;
            }
            set
            {
                _OriginalLegalPerson = value;
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
                    personID = Controller.Archive.LegalPersonController.Add(this.LegalPerson);
                else
                    personID = Controller.Archive.LegalPersonController.Update(this.LegalPerson, this.OriginalLegalPerson.Id);
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
            if (nameTextBox.Text == "")
                throw new Njit.Common.ValidateException(nameTextBox, "نام را وارد کنید");
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
