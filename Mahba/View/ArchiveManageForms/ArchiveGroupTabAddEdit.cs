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
    public partial class ArchiveGroupTabAddEdit : View.BaseForms.TabAddEdit
    {
        bool EditMode;
        int _TypeCode;
        int _ID;
        int _ArchiveGroupID;
        
        public ArchiveGroupTabAddEdit(int archiveGroupID, int typeCode)
        {
            InitializeComponent();
            EditMode = false;
            _ArchiveGroupID = archiveGroupID;
            _TypeCode = typeCode;
        }

        public ArchiveGroupTabAddEdit(int typeCode, int iD, string tabName)
        {
            InitializeComponent();
            EditMode = true;
            _TypeCode = typeCode;
            _ID = iD;

            this.Text = "تغییر نام گروه اطلاعاتی";
            btnOK.Text = "ثبت";
            txtGroupName.Text = tabName;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!Controller.Common.ArchiveGroupTabController.TabExistNameCheck(txtGroupName.Text, _TypeCode))
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
                Model.Common.ArchiveGroupTab archiveGroupTab = Model.Common.ArchiveGroupTab.GetNewInstance(_ArchiveGroupID, _TypeCode, 0, txtGroupName.Text);
                Controller.Common.ArchiveGroupTabController.Insert(archiveGroupTab);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateTab()
        {
            String erroreMessage;
            if (Controller.Common.ArchiveGroupTabController.TabExistNameCheck_UsedArchive(txtGroupName.Text, _TypeCode, _ID, out erroreMessage))
            {
                PersianMessageBox.Show(erroreMessage, "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Model.Common.ArchiveGroupTab archiveGroupTab = Controller.Common.ArchiveGroupTabController.Select(_ID);
                archiveGroupTab.Title = txtGroupName.Text;
                Controller.Common.ArchiveGroupTabController.Update(archiveGroupTab);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
