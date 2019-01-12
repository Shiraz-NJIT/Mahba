using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.BaseForms
{
    public partial class TabManage : Njit.Program.ComponentOne.Forms.ListFormWithoutSearch
    {
        public TabManage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.radGridView1.Rows.CollectionChanged += Rows_CollectionChanged;
            Telerik.WinControls.UI.GridViewImageColumn _GridViewImageColumn = new Telerik.WinControls.UI.GridViewImageColumn();
            _GridViewImageColumn.Name = "Image";
            _GridViewImageColumn.MaxWidth = 30;
            _GridViewImageColumn.MinWidth = 30;
            _GridViewImageColumn.HeaderText = "وضعیت";
            radGridView1.Columns.Add(_GridViewImageColumn);
        }

        internal bool SecondMove = false;

        protected virtual void Rows_CollectionChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Add || e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Remove)
            {
                for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                {
                    this.radGridView1.Rows[i].Cells["Row"].Value = i + 1;
                }
            }
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Move)
            {
                for (int i = 0; i < this.radGridView1.Rows.Count; i++)
                {
                    this.radGridView1.Rows[i].Cells["Row"].Value = i + 1;
                }
            }
        }

        protected virtual void SelectAllGroups()
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnCreate_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnRename_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected virtual void radbtnDossier_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
