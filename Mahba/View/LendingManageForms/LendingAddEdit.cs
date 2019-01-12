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
    public partial class LendingAddEdit : Njit.Program.Forms.OKCancelForm
    {
        private LendingAddEdit(bool editMode)
        {
            InitializeComponent();
            EditMode = editMode;
            LoadPerson();
            intentionComboBoxExtended.DataAccess = DataAccess.ArchiveDataAccess.GetNewInstance();
        }

        private void LoadPerson()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Common.User> query = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().Users.ToArray().Where(t => Setting.User.ThisProgram.IsMembershipActiveAndVisible(t)).Select(t => t).ToList();
            query.RemoveAll(q => q.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code);
            foreach (var item in query.ToList())
            {
                if (IsMembershipInAdministartorRole(item))
                {
                    query.RemoveAll(q => q.Code == item.Code);
                }
            }
            if (query.Any())
            {
                cmPerson.DataSource = query;
                cmPerson.DisplayMember = "FullName";
                cmPerson.ValueMember = "Code";
            }
        }
        public virtual string HashData(string data)
        {
            Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
            return md5.ComputeHash(data);
        }

        internal bool IsMembershipInAdministartorRole(Model.Common.User membership)
        {
            string roleCode = this.HashData(membership.Code.ToString() + (1).ToString());
            return membership.RoleCode == roleCode;
        }
        public LendingAddEdit(string personnelNumber)
            : this(false)
        {
            this.PersonnelNumber = groupBoxDossier.PersonnelNumber = personnelNumber;
            dateDateControl.SetDate();
            timeTimeControl.SetTime();
        }

        public LendingAddEdit(int originalLendingID)
            : this(true)
        {
            this.PersonnelNumber = groupBoxDossier.PersonnelNumber = GetPersonnelNumber(originalLendingID);
            this.lendingBindingSource.DataSource = Controller.Archive.LendingController.GetLending(originalLendingID);
            this.OriginalLending = Controller.Archive.LendingController.GetLending(originalLendingID);
        }

        private static string GetPersonnelNumber(int originalLendingID)
        {
            return Controller.Archive.LendingController.GetLending(originalLendingID).PersonnelNumber;
        }

        bool EditMode;

        private Model.Archive.Lending _OriginalLending;
        private Model.Archive.Lending OriginalLending
        {
            get
            {
                return _OriginalLending;
            }
            set
            {
                _OriginalLending = value;
            }
        }

        private string _PersonnelNumber;
        [DefaultValue(null)]
        public string PersonnelNumber
        {
            get
            {
                return _PersonnelNumber;
            }
            set
            {
                _PersonnelNumber = value;
            }
        }
        //مجوز دسترس به پرونده را دارد یا خیر 
        private bool isAccessPermission(Model.Archive.Dossier dossier)
        {
            //اگر ادمین باشد نیازی نیست
            if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
                return true;
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            //لیست نوع دسترسی
            List<Model.Common.PermissionDossier> listSecurity = dc.PermissionDossiers.Where(q => q.User.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID).ToList();
            return listSecurity.Exists(q => q.DossierType == dossier.DossierSecurityID);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnOK || this.ActiveControl == durationHourTextBoxExtended))
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
            Model.Archive.Dossier dossier = Controller.Archive.DossierController.Select(this.PersonnelNumber);
            if (!isAccessPermission(dossier))
            {
                PersianMessageBox.Show(this, string.Format("مجوز دسترسی به پرونده های با سطح دسترسی '{0}' برای شما صادر نشده است", dossier.DossierType.Title));
                this.Close();
                return;
            }
            int lendingID=0;
            try
            {
                Model.Archive.Person person = Controller.Archive.PersonController.SearchPersonByName(cmPerson.Text);
                if (person == null) { person = Controller.Archive.PersonController.AddPerson(cmPerson.Text); }
                if (person != null)
                {
                    if (!EditMode)
                        lendingID = Controller.Archive.LendingController.AddLending(Model.Archive.Lending.GetNewInstance(this.PersonnelNumber, person.ID, intentionComboBoxExtended.Text, dateDateControl.Text, timeTimeControl.Text, durationDayTextBoxExtended.IntValue.Value, durationHourTextBoxExtended.IntValue.Value, null, null, null, null,Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code.ToString()));
                    else
                        lendingID = Controller.Archive.LendingController.UpdateLending(this.OriginalLending.ID, Model.Archive.Lending.GetNewInstance(this.OriginalLending.ID, this.PersonnelNumber, person.ID, intentionComboBoxExtended.Text, dateDateControl.Text, timeTimeControl.Text, durationDayTextBoxExtended.IntValue.Value, durationHourTextBoxExtended.IntValue.Value, this.OriginalLending.ReturnDate, this.OriginalLending.ReturnTime, this.OriginalLending.RealDurationDay, this.OriginalLending.RealDurationHour, Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code.ToString()));
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
            if (lendingID != 0)
            {
                ProgramEvents.OnLendingsChanged();
                this.Tag = lendingID;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void ValidateContent()
        {
            if (this.PersonnelNumber == null)
                throw new Njit.Common.ValidateException(null, "هیچ پرونده ای انتخاب نشده است");
            if (cmPerson.SelectedItem == null && cmPerson.SelectedText.Trim() == "")
                throw new Njit.Common.ValidateException(cmPerson, "نام امانت گیرنده را مشخص کنید");
            if (dateDateControl.DateIsFree)
                throw new Njit.Common.ValidateException(dateDateControl, "تاریخ را وارد کنید");
            if (dateDateControl.DateIsCorrect == false)
                throw new Njit.Common.ValidateException(dateDateControl, "تاریخ وارد شده نامعتبر است");
            if (timeTimeControl.TimeIsFree)
                throw new Njit.Common.ValidateException(timeTimeControl, "ساعت را وارد کنید");
            if (timeTimeControl.TimeIsCorrect == false)
                throw new Njit.Common.ValidateException(timeTimeControl, "ساعت وارد شده نامعتبر است");
            if (durationDayTextBoxExtended.Text == "")
                throw new Njit.Common.ValidateException(durationDayTextBoxExtended, "مدت روز امانت را وارد کنید");
            if (durationHourTextBoxExtended.Text == "")
                throw new Njit.Common.ValidateException(durationHourTextBoxExtended, "مدت ساعت امانت را وارد کنید");
            if (durationDayTextBoxExtended.IntValue.Value == 0 && durationHourTextBoxExtended.IntValue.Value == 0)
                throw new Njit.Common.ValidateException(durationDayTextBoxExtended, "مدت روز امانت یا مدت ساعت امانت را بزرگتر از صفر وارد کنید");
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnSelectDossier_Click(object sender, EventArgs e)
        {
            View.DossierSearch f = new DossierSearch("یک پرونده را انتخاب کنید", DossierSearch.Operations.SearchDialog, false);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.PersonnelNumber = groupBoxDossier.PersonnelNumber = f.Tag as string;
            }
        }
    }
}
