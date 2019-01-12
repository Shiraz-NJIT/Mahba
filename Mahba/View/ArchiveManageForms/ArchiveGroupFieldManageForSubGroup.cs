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
    public partial class ArchiveGroupFieldManageForSubGroup : View.BaseForms.FieldManage
    {
        public ArchiveGroupFieldManageForSubGroup(int archiveGroupFieldID, int archiveGroupID)
        {
            InitializeComponent();
            this.ArchiveGroupFieldID = archiveGroupFieldID;
            this.ArchiveGroupID = archiveGroupID;
            string archiveGroupFieldLabel = Controller.Common.ArchiveGroupFieldController.GetArchiveGroupFieldLabel(archiveGroupFieldID);
            if (!archiveGroupFieldLabel.IsNullOrEmpty())
                this.Text = "ویرایش فیلدهای " + archiveGroupFieldLabel;
        }

        public int ArchiveGroupFieldID;
        public int ArchiveGroupID;

        protected override IEnumerable<Field> LoadData()
        {
            return Controller.Common.ArchiveGroupSubGroupFieldController.GetSubGroupFields(ArchiveGroupFieldID, ArchiveGroupID);
        }

        protected override int AddField(Field field)
        {
            return Controller.Common.ArchiveGroupSubGroupFieldController.AddSubGroupField(field, ArchiveGroupFieldID);
        }

        protected override void EditField(int originalID, Field field)
        {
            Controller.Common.ArchiveGroupSubGroupFieldController.UpdateSubGroupField(originalID, field);
        }

        protected override void DeleteField(Field field)
        {
            Controller.Common.ArchiveGroupSubGroupFieldController.DeleteSubGroupField(field.ID.Value);
        }

        protected override void UpdateFieldsIndex()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            for (int i = 0; i < radGridView.Rows.Count; i++)
                list.Add(int.Parse(radGridView.Rows[i].Cells["ID"].Value.ToString()), i + 1);
            Controller.Common.ArchiveGroupSubGroupFieldController.UpdateSubGroupFieldsIndex(list);
        }
    }
}
