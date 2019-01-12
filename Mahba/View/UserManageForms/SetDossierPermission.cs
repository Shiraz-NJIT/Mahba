using Njit.Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.UserManageForms
{
    public partial class SetDossierPermission  : Njit.Program.Forms.OKCancelForm
    {
        public SetDossierPermission()
        {
            InitializeComponent();
        }

        SqlConnectionStringBuilder _Connection;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual SqlConnectionStringBuilder Connection
        {
            get
            {
                if (_Connection == null)
                    _Connection = Options.SettingInitializer.GetSqlSetting().DatabaseConnection;
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }
        private Njit.Sql.DataAccess _DataAccess;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected Njit.Sql.DataAccess DataAccess
        {
            get
            {
                if (_DataAccess == null)
                    _DataAccess = new Njit.Sql.DataAccess(this.Connection.ConnectionString);
                return _DataAccess;
            }
            set
            {
                _DataAccess = value;
            }
        }

    
        private void btnOK_Click(object sender, EventArgs e)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            //ابتدا تمامی سطوح دسترسی قبلی کاربر را پاک  تمامی کنیم
            foreach (var item in dc.PermissionDossiers.Where(q => q.PK_User == Convert.ToInt32(cmUsers.SelectedValue) && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID))
            {
                this.DataAccess.DeleteObject(item);
            }
            //سطح دسترسی جدید کاربر را وارد می کنیم
            foreach (DataRowView checkedItem in cblTitle.CheckedItems)
            {
                Model.Common.PermissionDossier df = new Model.Common.PermissionDossier();
                df.PK_Archive = Convert.ToInt32(Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID);
                df.PK_User = Convert.ToInt32(cmUsers.SelectedValue);
                df.DossierType = Convert.ToInt32(checkedItem[cblTitle.ValueMember].ToString());
                this.DataAccess.InsertObject(df);
            }


            Model.Common.User member = dc.Users.Where(t => t.Code == Convert.ToInt32(cmUsers.SelectedValue)).Single();
            Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.سطح_دسترسی, Setting.User.UserOparatesNames.ویرایش, null, "تنطیم سطح دسترسی کاربر : " + member.FullName + "  در سطح پرونده توسط : " + Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().FullName + "'");
            MessageBox.Show("سطح دسترسی " + "'" + member.FullName + "'ویرایش شد.");
        }

        //برای انتخاب و عدم انتخاب همه هست
        private void cbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelect.Checked)
                for (int i = 0; i < cblTitle.Items.Count; i++)
                {
                    cblTitle.SetItemChecked(i, true);
                }

            else
                for (int i = 0; i < cblTitle.Items.Count; i++)
                {
                    cblTitle.SetItemChecked(i, false);
                }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SetItemChecked(txtSearch.Text);
        }
        private void SetItemChecked(string item)
        {
            List<int> lf = GetItemsIndex(item);
            if (lf.Any())
                for (int i = 0; i < cblTitle.Items.Count; i++)
                {
                    if (lf.Exists(q => q.Equals(i)))
                        cblTitle.SetItemChecked(i, true);
                    else
                        cblTitle.SetItemChecked(i, false);
                }

        }
        private List<int> GetItemsIndex(string item)
        {
            int index = 0;
            List<int> listFind = new List<int>();
            foreach (DataRowView o in cblTitle.Items)
            {
                if (o.Row.ItemArray[1].ToString().Contains(txtSearch.Text))
                    listFind.Add(index);
                index++;
            }

            return listFind;
        }

        private void cmUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(cmUsers.SelectedValue);
                ChangePermission(Convert.ToInt32(cmUsers.SelectedValue));
            }
            catch { }


        }

        private void ChangePermission(int _userid)
        {
            //ابتدا تمامی سطحوح دسترسی انتخابی را پاک می کنم
            for (int i = 0; i < cblTitle.Items.Count; i++)
            {
                cblTitle.SetItemChecked(i, false);
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            //انتخاب تمامی سطحوح دسترسی
            foreach (var item in dc.PermissionDossiers.Where(q => q.PK_User == _userid && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID))
            {
                cblTitle.SetItemChecked(GetItemIndexWithValue(item.DossierType), true);
            }
        }
        private int GetItemIndexWithValue(int value)
        {
            int index = 0;
            foreach (DataRowView o in cblTitle.Items)
            {
                if (o.Row.ItemArray[0].ToString() == value.ToString())
                    return index;
                index++;
            }

            return -1;
        }

        private void SetDossierPermission_Load(object sender, EventArgs e)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Common.User> query = dc.Users.ToList().Where(q => q.Visible == Setting.User.ThisProgram.GetUserVisible(q.Code, true)).ToList();
            if (query.Any())
                foreach (var item in query.ToList())
                {
                    if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(item))
                    {
                        query.RemoveAll(q => q.Code == item.Code);
                    }
                }

            if (query.Any())
            {
                cmUsers.DataSource = query;
                cmUsers.DisplayMember = "FullName";
                cmUsers.ValueMember = "Code";

                System.Data.DataTable tempDataTable = SqlHelper.GetField("DossierType");
                if (tempDataTable.Rows.Count > 0)
                {
                    cblTitle.DataSource = tempDataTable;
                    cblTitle.DisplayMember = "Title";
                    cblTitle.ValueMember = "ID";
                    ChangePermission(Convert.ToInt32(cmUsers.SelectedValue));
                }
                else
                {
                    MessageBox.Show(" نوع دسترسی برای پرونده های این بایگانی در نظر گرفته نشده است");
                }
            }

        }

        
    }
}
