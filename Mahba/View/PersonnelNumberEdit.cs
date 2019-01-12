using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class PersonnelNumberEdit : Njit.Program.Forms.OKCancelForm
    {
        public PersonnelNumberEdit(string personnelNumber)
        {
            InitializeComponent();
            this.OriginalPersonnelNumber = personnelNumber;
            lblTitle.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + ":" + personnelNumber;
            textBoxLabel.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + "جدید" + ":";
        }

        private string _OriginalPersonnelNumber;
        private string OriginalPersonnelNumber
        {
            get
            {
                return _OriginalPersonnelNumber;
            }
            set
            {
                _OriginalPersonnelNumber = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "")
            {
                PersianMessageBox.Show(this, "هیچ مقداری وارد نشده است");
                textBox.FocusAndSetError("هیچ مقداری وارد نشده است");
                return;
            }
            try
            {
                Controller.Archive.DossierController.ChangePersonnelNumber(this.OriginalPersonnelNumber, textBox.Text);
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش, null, "تغییر شماره پرسنلی:" + this.OriginalPersonnelNumber + "به شماره پرسنلی" + textBox.Text + "توسط کاربر: " + Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().FullName + "'");
             
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                textBox.Focus();
                textBox.SelectAll();
                return;
            }
            this.Tag = textBox.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
