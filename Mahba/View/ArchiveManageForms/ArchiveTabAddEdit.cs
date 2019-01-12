using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class ArchiveTabAddEdit : View.BaseForms.TabAddEdit
    {
        bool EditMode;
        int _TypeCode;
        int _ID;

        public ArchiveTabAddEdit(int TypeCode)
        {
            InitializeComponent();
            EditMode = false;
            _TypeCode = TypeCode;
        }

        public ArchiveTabAddEdit(int ID, string TabName, int TypeCode)
        {
            InitializeComponent();
            EditMode = true;
            _ID = ID;
            _TypeCode = TypeCode;
            this.Text = "تغییر نام گروه اطلاعاتی";
            btnOK.Text = "ثبت";
            txtGroupName.Text = TabName;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!Controller.Archive.ArchiveTabController.TabNameExist(txtGroupName.Text, _TypeCode))
                {
                    if (EditMode)
                        UpdateTab();
                    else
                        CreateTab();
                }
                else
                    PersianMessageBox.Show(this, "نام گروه اطلاعاتی نمی تواند تکراری باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        private void CreateTab()
        {
            try
            {
                Model.Archive.ArchiveTab archiveTab = Model.Archive.ArchiveTab.GetNewInstance(_TypeCode, 0, null, txtGroupName.Text, false, false, null, false);
                Controller.Archive.ArchiveTabController.Insert(archiveTab);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        private void UpdateTab()
        {
            try
            {
                Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.Select(_ID);
                archiveTab.Title = txtGroupName.Text;
                Controller.Archive.ArchiveTabController.Update(archiveTab);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }
    }
}
