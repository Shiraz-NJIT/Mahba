using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.LendingManageForms
{
    public partial class LendingList : Njit.Program.ComponentOne.Forms.ListFormWithoutSearch
    {
        public LendingList()
        {
            InitializeComponent();
        }

        private static LendingList _Instance;
        public static LendingList Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new LendingList();
                if (_Instance.IsDisposed)
                    _Instance = new LendingList();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            List<Model.Archive.ArchiveField> displayFields = Controller.Archive.DisplayFieldController.GetDisplayFields(Enums.DisplayFieldCodes.امانت);
            if (displayFields.Count == 0)
            {
                var result = PersianMessageBox.Show(this, "هیچ فیلدی برای نمایش انتخاب نشده است\r\nآیا مایل هستید ابتدا فیلد ها را انتخاب کنید؟", "انتخاب فیلدها", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    View.LendingManageForms.SelectDisplayFields f = new SelectDisplayFields();
                    f.ShowDialog();
                }
            }
            RefreshData();
            ProgramEvents.LendingsChanged += ProgramEvents_LendingsChanged;
            this.WindowState = FormWindowState.Maximized;
            radGridView.BestFitColumnsSmart();
            cbBacked.CheckedChanged += cbBacked_CheckedChanged;
            cbNotBack.CheckedChanged += cbnNotBacked_CheckedChanged;
        }

        private void ProgramEvents_LendingsChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ProgramEvents.LendingsChanged -= ProgramEvents_LendingsChanged;
            base.OnFormClosed(e);
        }

        public override void RefreshData()
        {

            var listlinding = Controller.Archive.LendingController.GetLendingList();
            DataTable ListShow = new DataTable();

            //فقط لیست اونهایی که برگشته را می خواهد
            if (cbBacked.Checked == false && cbNotBack.Checked == true)
                for (int i = 0; i < listlinding.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(listlinding.Rows[i].ItemArray[12].ToString()))
                        listlinding.Rows[i].Delete();
                    
                }
            //فقط لیست اونهایی که برنگشته است
            if (cbBacked.Checked == true && cbNotBack.Checked == false)
                for (int i = 0; i < listlinding.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(listlinding.Rows[i].ItemArray[12].ToString()))
                        listlinding.Rows[i].Delete();
                }
            //هیچکدام  انتخاب نشده است
            if (cbBacked.Checked == false && cbNotBack.Checked == false)
                radGridView.DataSource = null;
            else
            {
                radGridView.DataSource = listlinding;
                radGridView.BestFitColumnsSmart();
                if (radGridView.Columns.Where(t => t.Name == "ID").Count() == 1)
                    radGridView.Columns["ID"].IsVisible = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            int originalID = int.Parse(radGridView.SelectedRows[0].Cells["ID"].Value.ToString());
            using (View.LendingManageForms.LendingAddEdit f = new View.LendingManageForms.LendingAddEdit(originalID))
            {
                f.ShowDialog();
                var query = radGridView.Rows.Where(t => t.Cells["ID"] == f.Tag);
                if (query.Count() == 1)
                    query.Single().IsCurrent = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (var row in radGridView.SelectedRows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + row.Cells[1].Value.ToString();
                item.Tag = row.Cells["ID"].Value.ToString();
                items.Add(item);
            }
            if (items.Count > 0)
            {
                using (Njit.Program.Forms.DeleteForm deleteForm = new Njit.Program.Forms.DeleteForm(items, "از حذف اطلاعات زیر اطمینان دارید؟"))
                {
                    deleteForm.DeleteAll += deleteForm_DeleteAll;
                    deleteForm.ShowDialog(this);
                }
            }
        }

        private void deleteForm_DeleteAll(object sender, Njit.Program.Forms.DeleteForm.DeleteAllEventArgs e)
        {
            foreach (var item in e.Items)
            {
                try
                {
                    Controller.Archive.LendingController.DeleteLending(Controller.Archive.LendingController.GetLending(int.Parse(item.Tag.ToString())));
                }
                catch (Exception ex)
                {
                    e.ErrorList.Add(ex.Message);
                }
            }
            RefreshData();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            Model.Archive.Lending lending = Controller.Archive.LendingController.GetLending(int.Parse(radGridView.SelectedRows[0].Cells["ID"].Value.ToString()));
            //if (lending.ReturnDate != null)
            //{
            //    PersianMessageBox.Show(this, "این پرونده بازگشت داده شده است");
            //    return;
            //}
            using (View.LendingManageForms.LendingReturn f = new View.LendingManageForms.LendingReturn(lending.ID))
            {
                f.ShowDialog();
            }
        }

        private void cbnNotBacked_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }


        private void cbBacked_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
