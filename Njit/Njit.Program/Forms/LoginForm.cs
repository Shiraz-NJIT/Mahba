using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Njit.Program.Forms
{
    public partial class LoginForm : BaseFormDialog
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                if (Options.SettingInitializer != null)
                    Options.SettingInitializer.GetSqlSetting().Load();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در بارگذاری تنظیمات سرور" + "\r\n\r\n" + ex.Message);
            }
            if (CheckSqlConnection())
                LoadUsers();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastUser))
            {
                usersComboBox.Text = Njit.Common.PublicMethods.FixArabicChars(Properties.Settings.Default.LastUser);
                usersComboBox.SelectAll();
            }
        }

        public virtual bool CheckSqlConnection()
        {
            return true;
        }

        public virtual void LoadUsers()
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(btnOK.Focused || passwordTextBox.Focused))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            try
            {
                ValidateContent();
            }
            catch (Njit.Common.ValidateException ex)
            {
                PersianMessageBox.Show(ex.ErrorMessage);
                if (ex.Control != null)
                {
                    ex.Control.Focus();
                    if (ex.Control is TextBox)
                        (ex.Control as TextBox).SelectAll();
                    errorProvider.SetError(ex.Control, ex.ErrorMessage);
                    ex.Control.TextChanged -= Control_TextChanged;
                    ex.Control.TextChanged += Control_TextChanged;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            Options.SettingInitializer.GetUserSetting().SetCurrentUser(usersComboBox.SelectedItem ?? Options.SettingInitializer.GetUserSetting().GetUserByUserName(usersComboBox.Text));
            Properties.Settings.Default.LastUser = usersComboBox.Text;
            Properties.Settings.Default.Save();
        }

        private void Control_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        public virtual void ValidateContent()
        {
            if (usersComboBox.SelectedValue == null && usersComboBox.Text == "")
                throw new Njit.Common.ValidateException(usersComboBox, "هیچ کاربری انتخاب نشده است");

            if (usersComboBox.SelectedValue == null)
            {
                if (!Options.SettingInitializer.GetUserSetting().Authenticate(usersComboBox.Text, passwordTextBox.Text))
                    throw new Njit.Common.ValidateException(usersComboBox, "رمز عبور یا نام کاربری نادرست است");
            }
            else if (!Options.SettingInitializer.GetUserSetting().Authenticate((int)usersComboBox.SelectedValue, passwordTextBox.Text))
                throw new Njit.Common.ValidateException(passwordTextBox, "رمز عبور نادرست است");
         
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Options.SettingInitializer.GetUserSetting().GetCurrentUser<object>() == null)
            {
                System.Windows.Forms.DialogResult result = PersianMessageBox.Show(this, "آیا از برنامه خارج می شوید؟", "خروج از برنامه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void linkLabelNetwork_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeNetworkSettings();
        }

        public virtual void ChangeNetworkSettings()
        {

        }
    }
}
