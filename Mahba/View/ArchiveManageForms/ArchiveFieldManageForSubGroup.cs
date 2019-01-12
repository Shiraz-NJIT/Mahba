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
    public partial class ArchiveFieldManageForSubGroup : View.BaseForms.FieldManage
    {
        public ArchiveFieldManageForSubGroup(int archiveFieldID)
        {
            InitializeComponent();
            this.ArchiveFieldID = archiveFieldID;
            string archiveFieldLabel = Controller.Archive.ArchiveFieldController.GetArchiveFieldLabel(archiveFieldID);
            if (!archiveFieldLabel.IsNullOrEmpty())
                this.Text = "ویرایش فیلدهای " + archiveFieldLabel;
        }

        public int ArchiveFieldID;

        protected override IEnumerable<Field> LoadData()
        {
            return Controller.Archive.ArchiveSubGroupFieldController.GetSubGroupFields(ArchiveFieldID);
        }

        protected override int AddField(Field field)
        {
            return Controller.Archive.ArchiveSubGroupFieldController.AddSubGroupField(field, ArchiveFieldID);
        }

        protected override void EditField(int originalID, Field field)
        {
            Controller.Archive.ArchiveSubGroupFieldController.UpdateSubGroupField(originalID, field);
        }

        protected override void DeleteField(Field field)
        {
            Controller.Archive.ArchiveSubGroupFieldController.DeleteSubGroupField(field.ID.Value);
        }

        protected override void UpdateFieldsIndex()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            for (int i = 0; i < radGridView.Rows.Count; i++)
                list.Add(int.Parse(radGridView.Rows[i].Cells["ID"].Value.ToString()), i + 1);
            Controller.Archive.ArchiveSubGroupFieldController.UpdateSubGroupFieldsIndex(list);
        }
    }
}
