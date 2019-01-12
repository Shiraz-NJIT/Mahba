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
    public partial class SetPermission : Njit.Program.Forms.OKCancelForm
    {
        public SetPermission()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTree();
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            comboBoxUserRole.SelectedValueChanged -= ComboBoxUserRoleSelectedValueChanged;
            userRoleBindingSource.DataSource = dc.UserRoles.Where(t => t.ID != 1);
            comboBoxUserRole.SelectedValueChanged += ComboBoxUserRoleSelectedValueChanged;
            ComboBoxUserRoleSelectedValueChanged(this, EventArgs.Empty);
        }

        private void LoadTree()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Njit.Program.Controls.AccessPermissionTreeView.AccessPermission> list = new List<Njit.Program.Controls.AccessPermissionTreeView.AccessPermission>();
            //Model.Common.Archive[] archives = Controller.Common.ArchiveController.GetActiveArchives();
            //list.Add(new Njit.Program.Controls.AccessPermissionTreeView.AccessPermission(
            foreach (var item in dc.AccessPermissionTrees.Where(t => t.Visible))
            {
                list.Add(new Njit.Program.Controls.AccessPermissionTreeView.AccessPermission(item.ID, item.Item, item.Group, item.Title, false));
            }
            accessPermissionTreeView.SetData(list);
        }

        private void ComboBoxUserRoleSelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxUserRole.SelectedValue == null)
            {
                //accessPermissionTreeView.LoadData(null);
                SetTreeValues(false);
            }
            else
            {
                //LoadTree();
                SetTreeValues();
            }
            //comboBoxUsers.SelectedValueChanged -= ComboBoxUsersSelectedValueChanged;
            //if (comboBoxUserRole.SelectedValue == null)
            //{
            //    this.membershipBindingSource.DataSource = null;
            //}
            //else
            //{
            //    this.membershipBindingSource.DataSource = Setting.User.ThisProgram.GetRoleMemberships((int)comboBoxUserRole.SelectedValue);
            //    this.membershipBindingSource.Insert(0, ArchiveCommonModel.User.GetNewInstance(-1, "", "", "همه کاربران", "", null, "", ""));
            //    comboBoxUsers.SelectedValue = -1;
            //}
            //comboBoxUsers.SelectedValueChanged += ComboBoxUsersSelectedValueChanged;
            //ComboBoxUsersSelectedValueChanged(sender, e);
        }

        //private void ComboBoxUsersSelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxUsers.SelectedValue == null)
        //    {
        //        //accessPermissionTreeView.LoadData(null);
        //        SetTreeValues(false);
        //    }
        //    else
        //    {
        //        //LoadTree();
        //        SetTreeValues();
        //    }
        //}

        private void SetTreeValues(bool value)
        {
            foreach (var item in accessPermissionTreeView.GetData())
            {
                item.Node.Checked = value;
            }
        }

        private void SetTreeValues()
        {
            foreach (var item in accessPermissionTreeView.GetData())
            {
                string itemCode = Setting.User.ThisProgram.HashData("mahba3905" + item.AccessPermissionTreeItem);
                //int userCode = (int)comboBoxUsers.SelectedValue;
                int roleCode = ((Model.Common.UserRole)comboBoxUserRole.SelectedValue).ID;
                //if (userCode == -1)
                //{
                item.Node.Checked = Setting.User.ThisProgram.GetRoleAccessPermission(roleCode, itemCode);
                //}
                //else
                //{
                //    item.Node.Checked = Setting.User.ThisProgram.GetMembershipAccessPermission(userCode, itemCode);
                //}
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var item in accessPermissionTreeView.GetData())
            {
                string itemCode = Setting.User.ThisProgram.HashData("mahba3905" + item.AccessPermissionTreeItem);
                //int userCode = (int)comboBoxUsers.SelectedValue;
                int roleCode = ((Model.Common.UserRole)comboBoxUserRole.SelectedValue).ID;
                //if (userCode == -1)
                //{
                Setting.User.ThisProgram.SetRoleAccessPermission(roleCode, itemCode, item.Node.Checked);
                //}
                //else
                //{
                //    Setting.User.ThisProgram.SetMembershipAccessPermission(userCode, itemCode, item.Node.Checked);
                //}
            }
            PersianMessageBox.Show(this, "سطح دسترسی اعمال شد");
        }

    }
}
