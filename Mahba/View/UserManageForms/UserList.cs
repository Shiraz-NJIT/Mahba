using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.UserManageForms
{
    public partial class UserList : Njit.Program.Forms.UserList
    {
        public UserList()
        {
            InitializeComponent();
        }

        protected override void LoadUserRoles()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            userRoleBindingSource.DataSource = dc.UserRoles.Select(t => t);
        }

        protected override void LoadUsers()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            membershipBindingSource.DataSource = dc.Users.ToArray().Where(t => t.Visible == Setting.User.ThisProgram.GetUserVisible(t.Code, true));
        }

        protected override bool IsMembershipInAdministartorRole(object membership)
        {
            return Setting.User.ThisProgram.IsMembershipInAdministartorRole((Model.Common.User)membership);
        }

        protected override void SetValues(object membership)
        {
            Model.Common.User m = (Model.Common.User)membership;
            fullNameTextBox.Text = m.FullName;
            if (Setting.User.ThisProgram.GetMembershipStateCode(m) == (int)Setting.User.UserStates.Active)
                radioButtonActive.Checked = true;
            else
                radioButtonInactive.Checked = true;
            cbGuest.Checked = m.isGuest;
            if(m.isGuest){

                try
                {
                    if (m.Expire != null)
                        txtExpire.Text = ConvertTo_PersianOREnglish_Date.GetPersianDate(Convert.ToDateTime(m.Expire));
                }
                catch { }
            }
            roleComboBox.SelectedValue = Setting.User.ThisProgram.GetMembershipRoleCode(m);
        }

        protected override void SaveUserData(int code, string fullname, string roleCode, string stateCode,bool _isguest,bool isLogin,DateTime? _Expire)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            Model.Common.User originalMembership = dc.Users.Where(t => t.Code == code).Single();
            string originalFullName = originalMembership.FullName;
           
            Model.Common.User newInstance = Model.Common.User.GetNewInstance(code, fullname, originalMembership.Password, fullname, originalMembership.NikName, originalMembership.LastLogin, roleCode, stateCode, Setting.User.ThisProgram.GetUserVisible(code, true),_isguest,false,_Expire,Setting.Program.GetMacAddress().ToString());
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Common.User.Copy(originalMembership, newInstance);
                dc.SubmitChanges();
                try
                {
                    Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.کاربران, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش اطلاعات کاربر با نام '" + originalFullName + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + Environment.NewLine + Environment.NewLine + ex.Message);
                return;
            }
            dc.Transaction.Commit();
            dc.Connection.Close();

            Setting.User.ThisProgram.SetCurrentUser(dc.Users.Where(t => t.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code).Single());
        }

        protected override int GetActiveUsersCount()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.Users.ToArray().Where(t => Setting.User.ThisProgram.IsMembershipActiveAndVisible(t)).Count();
        }

        protected override int GetAdministratorUsersCount()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var allMembers = dc.Users.Select(t => t);
            int adminCount = 0;
            foreach (var item in allMembers)
            {
                if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(item))
                    adminCount++;
            }
            return adminCount;
        }

        protected override int GetMembershipStateCode(object membership)
        {
            return Setting.User.ThisProgram.GetMembershipStateCode((Model.Common.User)membership);
        }

        protected override void ValidateContent()
        {
            base.ValidateContent();
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            int count = dc.Users.Where(t => t.FullName == fullNameTextBox.Text && t.FullName != usersComboBox.Text).Select(t => t).Count();
            if (count > 0)
                throw new Njit.Common.ValidateException(fullNameTextBox, "کاربر با نام ' " + fullNameTextBox.Text + " ' قبلا ثبت شده است");
        }
    }
}
