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
    public partial class SelectDisplayFields : Njit.Program.Forms.CancelableDialogForm
    {
        public SelectDisplayFields()
        {
            InitializeComponent();
            this.archiveTabBindingSource.DataSource = Controller.Archive.ArchiveTabController.GetActiveDossierTabs();
        }

        private void comboBoxExtended_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void RefreshFields()
        {
            checkedListBox.Items.Clear();
            if (comboBoxExtended.SelectedValue != null)
            {
                foreach (var item in Controller.Archive.ArchiveTabController.GetArchiveFieldsThatIsNotSubGroup((int)comboBoxExtended.SelectedValue))
                {
                    checkedListBox.Items.Add(item, Controller.Archive.DisplayFieldController.IsDisplayField(item.ID, Enums.DisplayFieldCodes.امانت));
                }
            }
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                Controller.Archive.DisplayFieldController.SetDisplayField((checkedListBox.Items[e.Index] as Model.Archive.ArchiveField).ID, (e.NewValue == CheckState.Checked || e.NewValue == CheckState.Indeterminate), Enums.DisplayFieldCodes.امانت);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }
    }
}
