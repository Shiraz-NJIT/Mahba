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
    public partial class ArchiveTab : BaseForms.TabManage
    {
        int TypeCode;

        public ArchiveTab(int typeCode)
        {
            this.TypeCode = typeCode;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Setting.User.ThisProgram.CloseForms(View.Main.Instance.Name, this.Name, View.SelectArchive.Instance.Name);
            Controller.Archive.DossierCacheController.ClearCachedData();
        }

        protected override void radbtnDossier_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SelectAllGroups();
            Cursor.Current = Cursors.Default;
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
                List<Model.Archive.ArchiveTab> _ArchiveTab = Controller.Archive.ArchiveTabController.GetActiveArchiveTabs();
                if (_ArchiveTab == null)
                    return;
                if (radbtnDossier.Checked == true)
                {
                    foreach (Model.Archive.ArchiveTab item in _ArchiveTab.Where(t => t.TypeCode == 1))
                    {
                        radGridView1.Rows.Add(item.ID, item.IDParent, 0, item.Title);
                        if (radGridView1.RowCount > 0)
                        {
                            if (item.IDParent.IsNullOrEmpty())
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells["Image"].Value = NjitSoftware.Properties.Resources.unlock;
                            else
                                radGridView1.Rows[radGridView1.Rows.Count - 1].Cells["Image"].Value = NjitSoftware.Properties.Resources._lock;
                        }
                    }
                    //radGridView1.Rows.Add(0, 0, 0, "اطلاعات تماس");
                    //radGridView1.Rows[radGridView1.Rows.Count - 1].Cells["Image"].Value = NjitSoftware.Properties.Resources.Lock;
                }
                else
                {
                    foreach (Model.Archive.ArchiveTab item in _ArchiveTab.Where(t => t.TypeCode == 2))
                    {
                        radGridView1.Rows.Add(item.ID, item.IDParent, 0, item.Title);
                        if (radGridView1.RowCount > 0)
                        {
                            if (item.IDParent.IsNullOrEmpty())
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

        //protected override void UpdateGroupTab_Sort(int ID, int NewIndex)
        //{
        //    base.UpdateGroupTab_Sort(ID, NewIndex);
        //}

        protected override void btnCreate_Click(object sender, EventArgs e)
        {
            base.btnCreate_Click(sender, e);

            if (DialogResult.OK == (new View.ArchiveTabAddEdit(ReturnTypeCode()).ShowDialog()))
            {
                SelectAllGroups();
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
                if (int.Parse(radGridView1.SelectedRows[0].Cells["ID"].Value.ToString()) == 0)
                {
                    PersianMessageBox.Show("گروه اطلاعاتی 'اطلاعات تماس' قابل تغییر نام نمی باشد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string Title = radGridView1.CurrentRow.Cells["Label"].Value.ToString();
                    int ID = int.Parse(radGridView1.CurrentRow.Cells["ID"].Value.ToString());
                    int? IDParent = radGridView1.CurrentRow.Cells["IDParent"].Value.IsNullOrEmpty() ? (int?)null : int.Parse(radGridView1.CurrentRow.Cells["IDParent"].Value.ToString());
                    if (!IDParent.IsNullOrEmpty())
                    {
                        PersianMessageBox.Show(this, "تغییر نام گروه اطلاعاتی " + Title + " از داخل بایگانی امکان پذیر نمی باشد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (DialogResult.OK == new View.ArchiveTabAddEdit(ID, Title, ReturnTypeCode()).ShowDialog())
                    {
                        SelectAllGroups();
                    }
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (radGridView1.RowCount == 0)
                    return;
                if (radGridView1.SelectedRows.Count != 1)
                    return;
                if (int.Parse(radGridView1.SelectedRows[0].Cells["ID"].Value.ToString()) != 0)
                {
                    View.ArchiveFieldManage f = new View.ArchiveFieldManage(int.Parse(radGridView1.SelectedRows[0].Cells["ID"].Value.ToString()));
                    f.ShowDialog();
                }
                else
                {
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.InfoGroupTab)
                    {
                        if (DialogResult.Yes == PersianMessageBox.Show("گروه اطلاعات تماس نمایش داده نشود؟", "عدم نمایش گروه اطلاعاتی", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Setting.Archive.ThisProgram.LoadedArchiveSettings.InfoGroupTab = false;
                        }
                    }
                    else
                    {
                        if (DialogResult.Yes == PersianMessageBox.Show("گروه اطلاعات تماس نمایش داده شود؟", "نمایش", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Setting.Archive.ThisProgram.LoadedArchiveSettings.InfoGroupTab = true;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
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
                if (int.Parse(radGridView1.SelectedRows[0].Cells["ID"].Value.ToString()) == 0)
                {
                    PersianMessageBox.Show("گروه اطلاعاتی 'اطلاعات تماس' قابل حذف نمی باشد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string title = radGridView1.CurrentRow.Cells["Label"].Value.ToString();
                    if (!radGridView1.CurrentRow.Cells["IDParent"].Value.IsNullOrEmpty())
                    {
                        PersianMessageBox.Show(this, "حذف گروه اطلاعاتی " + title + " از داخل بایگانی امکان پذیر نمی باشد", "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (DialogResult.Yes == PersianMessageBox.Show(this, "می خواهید گروه اطلاعاتی " + title + " با همه اطلاعات آن حذف شود ", "تاییدیه حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        int id = int.Parse(radGridView1.CurrentRow.Cells["ID"].Value.ToString());
                        Controller.Archive.ArchiveTabController.Delete(id);
                        SelectAllGroups();
                    }
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
                    if (ID != 0)
                    {
                        Controller.Archive.ArchiveTabController.SetIndex(ID, (i + 1));
                    }
                }
            }
            catch (Exception ex)
            {

                PersianMessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected override void Rows_CollectionChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {
            base.Rows_CollectionChanged(sender, e);
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Move)
            {
                if (radbtnDossier.Checked)
                {
                    if ((e.NewStartingIndex == radGridView1.Rows.Count - 1 || e.OldStartingIndex == radGridView1.Rows.Count - 1) && !SecondMove)
                    {
                        SecondMove = true;
                        radGridView1.Rows.Move(e.NewStartingIndex, e.OldStartingIndex);
                    }
                    else if (SecondMove)
                    {
                        SecondMove = false;
                    }
                    else
                    {
                        for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                        {
                            this.radGridView1.Rows[i].Cells["Row"].Value = i + 1;
                        }
                    }
                }
            }
        }
    }
}
