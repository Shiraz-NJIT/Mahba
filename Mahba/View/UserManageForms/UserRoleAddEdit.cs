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
    public partial class UserRoleAddEdit : Njit.Program.Forms.OKCancelForm
    {
        private UserRoleAddEdit(bool editMode)
        {
            InitializeComponent();
            this.EditMode = editMode;
        }

        bool EditMode;

        public UserRoleAddEdit()
            : this(false)
        {
            this.UserRole = new Model.Common.UserRole();
            this.userRoleBindingSource.DataSource = this.UserRole;
        }

        public UserRoleAddEdit(int originalKey)
            : this(true)
        {
            Model.Common.ArchiveCommonDataClassesDataContext mdc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            this.UserRole = mdc.UserRoles.Where(t => t.ID == originalKey).Single();
            this.OriginalUserRole = mdc.UserRoles.Where(t => t.ID == originalKey).Single();

            this.userRoleBindingSource.DataSource = this.UserRole;
        }

        private Model.Common.UserRole _UserRole;
        public Model.Common.UserRole UserRole
        {
            get
            {
                return _UserRole;
            }
            set
            {
                _UserRole = value;
            }
        }

        private Model.Common.UserRole _OriginalUserRole;
        public Model.Common.UserRole OriginalUserRole
        {
            get
            {
                return _OriginalUserRole;
            }
            set
            {
                _OriginalUserRole = value;
            }
        }

        private static UserRoleAddEdit _Instance;
        public static UserRoleAddEdit Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UserRoleAddEdit();
                if (_Instance.IsDisposed)
                    _Instance = new UserRoleAddEdit();
                return _Instance;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(btnOK.Focused || nameTextBox.Focused))
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
                ex.Control.TextChanged -= ControlTextChanged;
                PersianMessageBox.Show(ex.Message);
                ex.Control.Focus();
                ex.Control.TextChanged += ControlTextChanged;
                errorProvider.SetError(ex.Control, ex.Message);
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);

            Model.Common.UserRole newInstance = Model.Common.UserRole.GetNewInstance(nameTextBox.Text, false);
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                if (!EditMode)
                {
                    Model.Common.UserRole.Insert(dc, newInstance);
                    dc.SubmitChanges();
                    try
                    {
                        Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.کاربران, Setting.User.UserOparatesNames.ثبت, null, "ثبت گروه کاربران '" + newInstance.Name + "'");
                    }
                    catch
                    {
                        throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                    }
                }
                else
                {
                    Model.Common.UserRole originalInstance = dc.UserRoles.Where(t => t.ID == this.OriginalUserRole.ID).Single();
                    string originalName = originalInstance.Name;
                    Model.Common.UserRole.Copy(originalInstance, newInstance);
                    dc.SubmitChanges();
                    try
                    {
                        Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.کاربران, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش گروه کاربران '" + originalName + "'");
                    }
                    catch
                    {
                        throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                    }
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

            ProgramEvents.OnUserRolesChanged();

            if (EditMode)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                PersianMessageBox.Show(this, "اطلاعات ثبت شد");
                Model.Common.UserRole.Copy(this.UserRole, Model.Common.UserRole.GetNewInstance("", false));
                nameTextBox.Focus();
            }
        }

        private void ValidateContent()
        {
            if (nameTextBox.Text == "")
                throw new Njit.Common.ValidateException(nameTextBox, "نام گروه را وارد کنید");
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            int count;
            if (!EditMode)
                count = dc.UserRoles.Where(t => t.Name == nameTextBox.Text).Select(t => t).Count();
            else
                count = dc.UserRoles.Where(t => t.Name == nameTextBox.Text && t.ID != this.OriginalUserRole.ID).Select(t => t).Count();
            if (count > 0)
                throw new Njit.Common.ValidateException(nameTextBox, "گروه با نام ' " + nameTextBox.Text + " ' قبلا ثبت شده است");
        }

        void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
