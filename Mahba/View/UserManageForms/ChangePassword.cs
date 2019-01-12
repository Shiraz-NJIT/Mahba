using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.UserManageForms
{
    public partial class ChangePassword : Njit.Program.Forms.OKCancelForm
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

      
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnOK || this.ActiveControl == txtConfirm))
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool ChangeCurrentUserPassword(string currentPassword, string newPassword)
        {
            Model.Common.ArchiveCommonDataClassesDataContext sdc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            int count = sdc.Users.Where(t => t.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && t.Password == HashData(currentPassword)).Count();
            if (count == 0)
                return false;
            try
            {
                Model.Common.User member = sdc.Users.Where(t => t.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code).Select(t => t).Single();
                member.Password = HashData(newPassword);
                Setting.User.ThisProgram.AddLog(sdc, Setting.User.UserOparatesPlaceNames.تغییر_رمز_عبور, Setting.User.UserOparatesNames.ویرایش, null, ": تغییر رمز عبور توسط '" + Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().FullName + "'");
                sdc.SubmitChanges();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return false;
            }
            return true;
        }

        string HashData(string data)
        {
            Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
            return Setting.User.ThisProgram.HashData(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code.ToString() + data);
        }
        string GetCurrentUserPassword()
        {
            return Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Password;
        }

        bool HasError()
        {
            Model.Common.ArchiveCommonDataClassesDataContext sdc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            int count = sdc.Users.Where(t => t.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && t.Password == HashData(txtCurrent.Text)).Count();
            if (count == 0)
            {
                string error_text = "رمز عبور فعلی اشتباه وارد شده است";
                PersianMessageBox.Show(this, error_text);
                txtCurrent.Focus();
                return true;
            }
            if (txtNew.Text != txtConfirm.Text)
            {
                string error_text = "رمز عبور جدید و تکرار آن با یکدیگر برابر نیستند";
                PersianMessageBox.Show(this, error_text);
                txtNew.Focus();
                return true;
            }
            return false;
        }

    }
}
