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
    public partial class AddUser : Njit.Program.Forms.UserAdd
    {
        public AddUser()
        {
            InitializeComponent();
        }

        public override void LoadUserRoles()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            userRoleBindingSource.DataSource = dc.UserRoles.Select(t => t);
        }

        protected override void SaveUserData(int code, string fullName, string password, string roleCode, string stateCode,bool isGuest,bool isLogin,DateTime? Expire)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);

            Model.Common.User newInstance = Model.Common.User.GetNewInstance(code, fullName, password, fullName, "", null, roleCode, stateCode, Setting.User.ThisProgram.GetUserVisible(code, true), isGuest, isLogin, Expire, Setting.Program.GetMacAddress().ToString());
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Common.User.Insert(dc, newInstance);
                dc.SubmitChanges();
                try
                {
                    Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.کاربران, Setting.User.UserOparatesNames.ثبت, null, "ثبت اطلاعات کاربر با نام '" + newInstance.FullName + "'");
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
        }

        protected override void ValidateContent()
        {
            base.ValidateContent();
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            int count = dc.Users.Where(t => t.FullName == fullNameTextBox.Text).Select(t => t).Count();
            if (count > 0)
                throw new Njit.Common.ValidateException(fullNameTextBox, "کاربر با نام ' " + fullNameTextBox.Text + " ' قبلا ثبت شده است");
        }

        protected override int GetMaxCode()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.Users.Max(t => t.Code) + 1;
        }

        protected override bool IsMembershipInAdministartorRole(object membership)
        {
            return Setting.User.ThisProgram.IsMembershipInAdministartorRole((Model.Common.User)membership);
        }

    
    }
}
