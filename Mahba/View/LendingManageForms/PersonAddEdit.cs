using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.LendingManageForms
{
    public partial class PersonAddEdit : Njit.Program.Forms.OKCancelForm
    {
        private PersonAddEdit(bool editMode)
        {
            InitializeComponent();
            this.EditMode = editMode;
        }

        public PersonAddEdit()
            : this(false)
        {

        }

        public PersonAddEdit(int originalID)
            : this(true)
        {
            this.personBindingSource.DataSource = this.OriginalPerson = Controller.Archive.PersonController.GetPersonByID(originalID);
        }

        bool EditMode;

        private Model.Archive.Person _OriginalPerson;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [DefaultValue(null)]
        public Model.Archive.Person OriginalPerson
        {
            get
            {
                return _OriginalPerson;
            }
            set
            {
                _OriginalPerson = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnOK || this.ActiveControl == nameTextBox))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            try
            {
                ValidateContents();
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
            if (!EditMode)
            {
                try
                {
                    Controller.Archive.PersonController.AddPerson(nameTextBox.Text);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    Controller.Archive.PersonController.UpdatePerson(this.OriginalPerson.ID, nameTextBox.Text);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + ex.Message);
                    return;
                }
            }
            ProgramEvents.OnPersonsChanged();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ValidateContents()
        {
            if (nameTextBox.Text.Trim() == "")
                throw new Njit.Common.ValidateException(nameTextBox, "نام را وارد کنید");
            if (!EditMode)
            {
                if (Controller.Archive.PersonController.SearchPersonByName(nameTextBox.Text) != null)
                    throw new Njit.Common.ValidateException(nameTextBox, "نام وارد شده قبلا ثبت شده است");
            }
            else
            {
                if (OriginalPerson.Name != nameTextBox.Text && Controller.Archive.PersonController.SearchPersonByName(nameTextBox.Text) != null)
                    throw new Njit.Common.ValidateException(nameTextBox, "نام وارد شده قبلا ثبت شده است");
            }
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
