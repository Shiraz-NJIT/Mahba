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
    public partial class UserAdd : Njit.Program.Forms.OKCancelForm
    {
        public UserAdd()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            LoadUserRoles();
        }

        public virtual void LoadUserRoles()
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
                    if (ex.Control is Njit.Common.ICustomizedControl)
                        (ex.Control as Njit.Common.ICustomizedControl).FocusAndSetError(ex.Message);
                }
                return;
            }
            DateTime? DateExpire=null;
            if (cbGuest.Checked)
            {
                try
                {
                    DateExpire = ConvertTo_PersianOREnglish_Date.GetEglishDate(txtExpire.Text);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(ex.Message);
                    return;
                }
            }
            int code = GetMaxCode();
            string stateCode = radioButtonActive.Checked ? (Options.SettingInitializer.GetUserSetting().HashData(code.ToString() + (int)Setting.UserSetting.UserStates.Active)) : ((Options.SettingInitializer.GetUserSetting().HashData(code.ToString() + (int)Setting.UserSetting.UserStates.Inactive)));
            string roleCode = Options.SettingInitializer.GetUserSetting().HashData(code.ToString() + roleComboBox.SelectedValue.ToString());
            SaveUserData(code, fullNameTextBox.Text, Options.SettingInitializer.GetUserSetting().HashData(code.ToString() + passwordTextBox.Text), roleCode, stateCode, cbGuest.Checked, false, DateExpire);

            PersianMessageBox.Show(this, "اطلاعات ثبت شد");
            fullNameTextBox.Text = passwordTextBox.Text = passwordConfirmTextBox.Text = "";
            fullNameTextBox.Focus();
        }

        protected virtual void SaveUserData(int code, string fullName, string password, string roleCode, string stateCode, bool isguest, bool isLogin, DateTime? expire)
        {
            throw new NotImplementedException();
        }

        protected virtual int GetMaxCode()
        {
            throw new NotImplementedException();
        }

        protected virtual bool IsMembershipInAdministartorRole(object membership)
        {
            throw new NotImplementedException();
        }

        protected virtual void ValidateContent()
        {
            if (fullNameTextBox.Text.Trim() == "")
                throw new Njit.Common.ValidateException(fullNameTextBox, "نام را وارد کنید");
            if (passwordTextBox.Text != passwordConfirmTextBox.Text)
                throw new Njit.Common.ValidateException(passwordConfirmTextBox, "رمز عبور و تکرار آن با یکدیگر برابر نیستند");
            if (radioButtonActive.Checked == false && radioButtonInactive.Checked == false)
                throw new Njit.Common.ValidateException(null, "وضعیت کاربر را مشخص کنید");
            if (roleComboBox.SelectedValue == null)
                throw new Njit.Common.ValidateException(null, "نقش کاربر را مشخص کنید");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
