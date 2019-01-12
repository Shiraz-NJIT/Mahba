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
    public partial class ArchiveGroupFieldManage : View.BaseForms.FieldManage
    {
        public ArchiveGroupFieldManage(int archiveGroupTabID, int archiveGroupID)
        {
            InitializeComponent();
            this.ArchiveGroupTabID = archiveGroupTabID;
            this.ArchiveGroupID = archiveGroupID;
        }

        private int ArchiveGroupTabID;
        private int ArchiveGroupID;

        protected override void OnLoad(EventArgs e)
        {
            btnEditFields.Enabled = false;
            base.OnLoad(e);
        }

        protected override IEnumerable<Field> LoadData()
        {
            return Controller.Common.ArchiveGroupTabController.GetFields(this.ArchiveGroupTabID, this.ArchiveGroupID);
        }

        protected override int AddField(Field field)
        {
            return Controller.Common.ArchiveGroupFieldController.AddField(field, this.ArchiveGroupTabID, this.ArchiveGroupID);
        }

        protected override void EditField(int originalID, Field field)
        {
            Controller.Common.ArchiveGroupFieldController.UpdateField(originalID, field, this.ArchiveGroupTabID, this.ArchiveGroupID);
        }

        protected override void DeleteField(Field field)
        {
            Controller.Common.ArchiveGroupFieldController.DeleteField(field.ID.Value, this.ArchiveGroupTabID);
        }

        protected override void UpdateFieldsIndex()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            for (int i = 0; i < radGridView.Rows.Count; i++)
                list.Add(int.Parse(radGridView.Rows[i].Cells["ID"].Value.ToString()), i + 1);
            Controller.Common.ArchiveGroupFieldController.UpdateFieldsIndex(list);
        }

        private void btnEditFields_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            if (int.Parse(radGridView.SelectedRows[0].Cells["FieldTypeCode"].Value.ToString()) != (int)Enums.FieldTypes.زیرگروه_جدولی)
                return;
            using (View.ArchiveManageForms.ArchiveGroupFieldManageForSubGroup f = new View.ArchiveManageForms.ArchiveGroupFieldManageForSubGroup(int.Parse(radGridView.SelectedRows[0].Cells["ID"].Value.ToString()), this.ArchiveGroupID))
            {
                f.ShowDialog();
            }
        }

        private void CheckFieldTypeCode()
        {
            if (radGridView.SelectedRows.Count == 1 && int.Parse(radGridView.SelectedRows[0].Cells["FieldTypeCode"].Value.ToString()) == (int)Enums.FieldTypes.زیرگروه_جدولی)
                btnEditFields.Enabled = true;
            else
                btnEditFields.Enabled = false;
        }

        protected override void OnGridViewSelectionChanged()
        {
            CheckFieldTypeCode();
        }

        public override void SetCounterFieldProperties(int fieldId, int fixedValueType, string fixedValue, string separator)
        {
            Controller.Common.ArchiveGroupFieldController.SetCounterFieldProperties(fieldId, fixedValueType, fixedValue, separator);
        }

        public override CounterFieldSetting GetCounterFieldProperties(int fieldID)
        {
            Model.Common.CounterFieldSetting counterFieldSetting = Controller.Common.ArchiveGroupFieldController.GetCounterFieldProperties(fieldID);
            if (counterFieldSetting == null)
                return null;
            return new CounterFieldSetting(counterFieldSetting.ArchiveGroupFieldID, (Enums.FixedValueTypes)counterFieldSetting.FixedValueType, counterFieldSetting.FixedValue, counterFieldSetting.Separator);
        }
    }
}
