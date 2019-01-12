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
    public partial class UserRoleList : Njit.Program.ComponentOne.Forms.ListFormWithoutSearch
    {
        public UserRoleList()
        {
            InitializeComponent();
            Setting.Program.ThisProgram.LoadFormState(this);
            ProgramEvents.UserRolesChanged += ProgramEvents_UserRolesChanged;
        }

        private void ProgramEvents_UserRolesChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private static UserRoleList _Instance;
        public static UserRoleList Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UserRoleList();
                if (_Instance.IsDisposed)
                    _Instance = new UserRoleList();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.RefreshData();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            ProgramEvents.UserRolesChanged -= ProgramEvents_UserRolesChanged;
        }

        public override void RefreshData()
        {
            base.RefreshData();
            Model.Common.ArchiveCommonDataClassesDataContext mdc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            this.userRoleReportBindingSource.DataSource = mdc.UserRoleReports;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (View.UserManageForms.UserRoleAddEdit f = new View.UserManageForms.UserRoleAddEdit())
            {
                f.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            Model.Common.UserRoleReport userRoleReport = (radGridView.SelectedRows[0].DataBoundItem as Model.Common.UserRoleReport);
            if (userRoleReport.Locked)
            {
                PersianMessageBox.Show(this, "امکان ویرایش اطلاعات این گروه وجود ندارد");
                return;
            }
            using (View.UserManageForms.UserRoleAddEdit f = new View.UserManageForms.UserRoleAddEdit(userRoleReport.Code))
            {
                f.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (var row in radGridView.SelectedRows)
            {
                ListViewItem item = new ListViewItem();
                Model.Common.UserRoleReport obj = (Model.Common.UserRoleReport)row.DataBoundItem;
                item.Text = obj.Name;
                item.Tag = obj;
                items.Add(item);
            }
            if (items.Count > 0)
            {
                using (Njit.Program.Forms.DeleteForm deleteForm = new Njit.Program.Forms.DeleteForm(items, "از حذف گروه های زیر اطمینان دارد؟"))
                {
                    deleteForm.DeleteAll += deleteForm_DeleteAll;
                    deleteForm.ShowDialog(this);
                }
            }
        }

        void deleteForm_DeleteAll(object sender, Njit.Program.Forms.DeleteForm.DeleteAllEventArgs e)
        {
            foreach (ListViewItem item in e.Items)
            {
                Model.Common.UserRoleReport obj = (Model.Common.UserRoleReport)item.Tag;

                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {
                    if (obj.Locked)
                        throw new Exception("این گروه را نمیتوانید حذف کنید");
                    int userCount = Setting.User.ThisProgram.GetRoleMembershipCount(obj.Code);
                    if (userCount > 0)
                        throw new Exception("در این گروه " + userCount + " کاربر ثبت شده است");
                    var query = from temp in dc.UserRoles where temp.ID == obj.Code select temp;
                    var userRole = query.Single();
                    string originalName = userRole.Name;
                    Model.Common.UserRole.Delete(dc, userRole);
                    dc.SubmitChanges();
                    try
                    {
                        Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.کاربران, Setting.User.UserOparatesNames.حذف, null, "حذف گروه کاربران '" + originalName + "'");
                    }
                    catch
                    {
                        throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    if (ex.ErrorCode == -2146232060 && ex.Number == 547)
                    {
                        e.ErrorList.Add("اطلاعات گروه  '" + obj.Name + "' قابل حذف نیست. از این اطلاعات در جای دیگر استفاده شده است");
                    }
                    else
                    {
                        e.ErrorList.Add("خطا در حذف اطلاعات گروه '" + obj.Name + "'" + Environment.NewLine + Environment.NewLine + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    e.ErrorList.Add("خطا در حذف اطلاعات گروه '" + obj.Name + "'" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
                if (dc.Connection.State != ConnectionState.Closed)
                {
                    dc.Transaction.Commit();
                    dc.Connection.Close();
                }
            }
            ProgramEvents.OnUserRolesChanged();
        }

        private void radGridView_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (btnEdit.Enabled)
                btnEdit_Click(btnEdit, EventArgs.Empty);
        }

        private void radGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count == 0)
                btnDelete.Enabled = false;
            else
                btnDelete.Enabled = true;
            if (radGridView.SelectedRows.Count == 1)
                btnEdit.Enabled = true;
            else
                btnEdit.Enabled = false;
        }
    }
}
