using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.PersonManageForms
{
    public partial class RightfulPersonList : Njit.Program.ComponentOne.Forms.ListFormWithoutSearch
    {
        public RightfulPersonList()
        {
            InitializeComponent();
        }

        private static RightfulPersonList _Instance;
        public static RightfulPersonList Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new RightfulPersonList();
                if (_Instance.IsDisposed)
                    _Instance = new RightfulPersonList();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshData();
        }

        public override void RefreshData()
        {
            rightfulPersonViewBindingSource.DataSource = Controller.Archive.RightfulPersonController.GetRightfulPersons();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (View.PersonManageForms.RightfulPersonAddEdit f = new View.PersonManageForms.RightfulPersonAddEdit())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                    var query = radGridView.Rows.Where(t => t.Cells["ID"] == f.Tag);
                    if (query.Count() == 1)
                        query.Single().IsCurrent = true;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            int originalID = int.Parse(radGridView.SelectedRows[0].Cells["ID"].Value.ToString());
            using (View.PersonManageForms.RightfulPersonAddEdit f = new View.PersonManageForms.RightfulPersonAddEdit(originalID))
            {
                f.ShowDialog();
                RefreshData();
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
                item.Text = "شخص حقیقی با نام " + row.Cells["Fullname"].Value.ToString();
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
                    Controller.Archive.RightfulPersonController.Delete(Controller.Archive.RightfulPersonController.GetRightfulPerson(int.Parse(item.Tag.ToString())));
                }
                catch (Exception ex)
                {
                    e.ErrorList.Add(ex.Message);
                }
            }
            RefreshData();
        }
    }
}
