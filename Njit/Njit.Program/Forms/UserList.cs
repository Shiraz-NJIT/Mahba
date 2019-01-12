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
    public partial class UserList : Njit.Program.Forms.OKCancelForm
    {
        public UserList()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            LoadUsers();
            LoadUserRoles();
        }

        protected virtual void LoadUserRoles()
        {
            throw new NotImplementedException();
        }

        protected virtual void LoadUsers()
        {
            throw new NotImplementedException();
        }

        private void usersComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (usersComboBox.SelectedValue == null)
            {
                fullNameTextBox.Text = "";
                radioButtonActive.Checked = true;
            }
            else
            {
                SetValues(usersComboBox.SelectedItem);
            }
        }

        protected virtual void SetValues(object membership)
        {
            throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual bool IsMembershipInAdministartorRole(object membership)
        {
            throw new NotImplementedException();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(btnOK.Focused || roleComboBox.Focused))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            if (!IsMembershipInAdministartorRole(Options.SettingInitializer.GetUserSetting().GetCurrentUser<object>()))
            {
                PersianMessageBox.Show(this, "مجوز ثبت اطلاعات کاربران برای شما وجود ندارد");
                return;
            }
            try
            {
                ValidateContent();
            }
            catch (Njit.Common.ValidateException ex)
            {
                PersianMessageBox.Show(ex.Message);
                if (ex.Control != null)
                {
                    ex.Control.TextChanged -= ControlTextChanged;
                    ex.Control.Focus();
                    ex.Control.TextChanged += ControlTextChanged;
                    errorProvider.SetError(ex.Control, ex.Message);
                }
                return;
            }
            int code = (int)usersComboBox.SelectedValue;
            string stateCode = radioButtonActive.Checked ? (Options.SettingInitializer.GetUserSetting().HashData(code.ToString() + (int)Setting.UserSetting.UserStates.Active)) : ((Options.SettingInitializer.GetUserSetting().HashData(code.ToString() + (int)Setting.UserSetting.UserStates.Inactive)));
            string roleCode = Options.SettingInitializer.GetUserSetting().HashData(code.ToString() + roleComboBox.SelectedValue.ToString());
            DateTime? Expire=null;
            if (cbGuest.Checked)
            {
                try
                {
                    Expire = ConvertTo_PersianOREnglish_Date.GetEglishDate(txtExpire.Text);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(ex.Message);
                    return;
                }
            }
            if (IsMembershipInAdministartorRole(usersComboBox.SelectedItem) && ((int)roleComboBox.SelectedValue) != 1)
            {
                int adminCount = GetAdministratorUsersCount();
                if (adminCount < 2)
                {
                    PersianMessageBox.Show(this, "امکان ثبت این کاربر به عنوان کاربر عادی وجود ندارد" + "\r\n" + "حداقل یک کاربر با نقش 'مدیر سیستم' باید وجود داشته باشد");
                    return;
                }
            }
            if (GetMembershipStateCode(usersComboBox.SelectedItem) == (int)Setting.UserSetting.UserStates.Active && radioButtonInactive.Checked)
            {
                int activeCount = GetActiveUsersCount();
                if (activeCount < 2)
                {
                    PersianMessageBox.Show(this, "امکان ثبت این کاربر به عنوان کاربر غیرفعال وجود ندارد" + "\r\n" + "حداقل یک کاربر با وضعیت فعال باید وجود داشته باشد");
                    return;
                }
            }

            SaveUserData(code, fullNameTextBox.Text, roleCode, stateCode,cbGuest.Checked,false,Expire);

            //Options.SettingInitializer.GetUserSetting().SetCurrentUser(dc.Memberships.Where(t => t.Code == Options.SettingInitializer.GetUserSetting().GetCurrentUser<Model.Membership>().Code).Single());

            PersianMessageBox.Show(this, "اطلاعات ثبت شد");
            LoadUsers();
        }

        protected virtual void SaveUserData(int code, string fullname, string roleCode, string stateCode,bool isguest,bool isLogin,DateTime? Expire)
        {
            throw new NotImplementedException();
        }

        protected virtual int GetActiveUsersCount()
        {
            throw new NotImplementedException();
        }

        protected virtual int GetMembershipStateCode(object membership)
        {
            throw new NotImplementedException();
        }

        protected virtual int GetAdministratorUsersCount()
        {
            throw new NotImplementedException();
        }

        protected virtual void ValidateContent()
        {
            if (usersComboBox.SelectedItem == null)
                throw new Njit.Common.ValidateException(usersComboBox, "هیچ کاربری انتخاب نشده است");
            if (fullNameTextBox.Text.Trim() == "")
                throw new Njit.Common.ValidateException(fullNameTextBox, "نام را وارد کنید");
            if (radioButtonActive.Checked == false && radioButtonInactive.Checked == false)
                throw new Njit.Common.ValidateException(null, "وضعیت کاربر را مشخص کنید");
            if (roleComboBox.SelectedValue == null)
                throw new Njit.Common.ValidateException(null, "نقش کاربر را مشخص کنید");
        }

        void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void cbGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGuest.Checked)
            {
                txtExpire.Visible = true;
                txtExpire.Enabled = true;
                lblExpire.Visible = true;
                lblExpire.Enabled = true;
            }
            else
            {
                txtExpire.Visible = false;
                txtExpire.Enabled = false;
                lblExpire.Visible = false;
                lblExpire.Enabled = false;
            }
        }

    }
}
