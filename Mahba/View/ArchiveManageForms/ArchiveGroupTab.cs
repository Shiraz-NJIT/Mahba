using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.ArchiveManageForms
{
    public partial class ArchiveGroupTab : BaseForms.TabManage
    {
        int _ArchiveGroupID;
        int TypeCode;

        public ArchiveGroupTab(int ArchiveGroupID, int typeCode)
        {
            _ArchiveGroupID = ArchiveGroupID;
            this.TypeCode = typeCode;
            InitializeComponent();
        }

        protected override void radbtnDossier_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SelectAllGroups();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.TypeCode == 1)
                radbtnDossier.Checked = true;
            else
                radbtnDocument.Checked = true;
        }

        protected override void SelectAllGroups()
        {
            try
            {
                radGridView1.Rows.Clear();
                List<Model.Common.ArchiveGroupTab> _AllArchiveGroupTabs = Controller.Common.ArchiveGroupTabController.GetAllSelfAndBaseArchiveGroupTabs(_ArchiveGroupID);
                if (_AllArchiveGroupTabs == null)
                    return;
                if (radbtnDossier.Checked == true)
                {
                    foreach (Model.Common.ArchiveGroupTab item in _AllArchiveGroupTabs.Where(t => t.TypeCode == 1))
                    {
                        radGridView1.Rows.Add(item.ID, item.ArchiveGroupID, 0, item.Title);
                        if (radGridView1.RowCount > 0)
                        {
                            if (item.ArchiveGroupID == _ArchiveGroupID)
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells["Image"].Value = NjitSoftware.Properties.Resources.unlock;
                            else
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells["Image"].Value = NjitSoftware.Properties.Resources._lock;
                        }
                    }
                }
                else
                {
                    foreach (Model.Common.ArchiveGroupTab item in _AllArchiveGroupTabs.Where(t => t.TypeCode == 2))
                    {
                        radGridView1.Rows.Add(item.ID, item.ArchiveGroupID, 0, item.Title);
                        if (radGridView1.RowCount > 0)
                        {
                            if (item.ArchiveGroupID == _ArchiveGroupID)
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells["Image"].Value = NjitSoftware.Properties.Resources.unlock;
                            else
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells["Image"].Value = NjitSoftware.Properties.Resources._lock;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        protected override void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnCreate_Click(sender, e);

                if (DialogResult.OK == (new View.ArchiveGroupTabAddEdit(_ArchiveGroupID, ReturnTypeCode()).ShowDialog()))
                {
                    SelectAllGroups();
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        protected override void btnRename_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnRename_Click(sender, e);

                if (radGridView1.RowCount == 0)
                    return;
                if (radGridView1.SelectedRows == null)
                    return;
                string Title = radGridView1.CurrentRow.Cells["Label"].Value.ToString();
                int ID = int.Parse(radGridView1.CurrentRow.Cells["ID"].Value.ToString());
                int? IDParent = radGridView1.CurrentRow.Cells["IDParent"].Value.IsNullOrEmpty() ? (int?)null : int.Parse(radGridView1.CurrentRow.Cells["IDParent"].Value.ToString());
                if (IDParent != _ArchiveGroupID)
                {
                    PersianMessageBox.Show(this, "تغییر نام گروه اطلاعاتی " + Title + " از این سطح امکان پذیر نمی باشد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (DialogResult.OK == new View.ArchiveGroupTabAddEdit(ReturnTypeCode(), ID, Title).ShowDialog())
                {
                    SelectAllGroups();
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount == 0)
                return;
            if (radGridView1.SelectedRows.Count == 0)
                return;
            using (View.ArchiveGroupFieldManage f = new ArchiveGroupFieldManage(int.Parse(radGridView1.SelectedRows[0].Cells["ID"].Value.ToString()), _ArchiveGroupID))
            {
                f.ShowDialog();
            }
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnDelete_Click(sender, e);

                if (radGridView1.RowCount == 0)
                    return;
                if (radGridView1.CurrentRow == null)
                    return;
                int? IDParent = radGridView1.CurrentRow.Cells["IDParent"].Value.IsNullOrEmpty() ? (int?)null : int.Parse(radGridView1.CurrentRow.Cells["IDParent"].Value.ToString());
                string Title = radGridView1.CurrentRow.Cells["Label"].Value.ToString();
                if (IDParent != _ArchiveGroupID)
                {
                    PersianMessageBox.Show(this, "تغییر نام گروه اطلاعاتی " + Title + " از این سطح امکان پذیر نمی باشد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (DialogResult.Yes == PersianMessageBox.Show(this, "می خواهید گروه اطلاعاتی " + Title + " حذف شود و بایگانی ها به صورت مستقل از این گروه اطلاعاتی استفاده کنند؟ ", "تاییدیه حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int ID = int.Parse(radGridView1.CurrentRow.Cells["ID"].Value.ToString());
                    Controller.Common.ArchiveGroupTabController.Delete(ID);
                    SelectAllGroups();
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        private int ReturnTypeCode()
        {
            if (radbtnDossier.Checked)
                return 1;
            else
                return 2;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                for (int i = 0; i < radGridView1.RowCount; i++)
                {
                    int ID = int.Parse(radGridView1.Rows[i].Cells["ID"].Value.ToString());
                    Model.Common.ArchiveGroupTab CurrentArchiveGroupTab = Controller.Common.ArchiveGroupTabController.Select(ID);
                    CurrentArchiveGroupTab.Index = (i + 1);
                    Controller.Common.ArchiveGroupTabController.Update_ArchiveTabIndex(CurrentArchiveGroupTab);
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
