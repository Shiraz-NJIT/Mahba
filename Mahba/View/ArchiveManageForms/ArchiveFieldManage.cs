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
    public partial class ArchiveFieldManage : View.BaseForms.FieldManage
    {
        public ArchiveFieldManage(int archiveTabID)
        {
            InitializeComponent();
            this.ArchiveTabID = archiveTabID;
        }

        private int ArchiveTabID;

        protected override void OnLoad(EventArgs e)
        {
            btnEditFields.Enabled = false;
            base.OnLoad(e);
        }

        protected override IEnumerable<Field> LoadData()
        {
            return Controller.Archive.ArchiveTabController.GetFields(this.ArchiveTabID);
        }

        private void btnEditFields_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            if (int.Parse(radGridView.SelectedRows[0].Cells["FieldTypeCode"].Value.ToString()) != (int)Enums.FieldTypes.زیرگروه_جدولی)
                return;
            using (View.ArchiveManageForms.ArchiveFieldManageForSubGroup f = new View.ArchiveManageForms.ArchiveFieldManageForSubGroup(int.Parse(radGridView.SelectedRows[0].Cells["ID"].Value.ToString())))
            {
                f.ShowDialog();
            }
        }

        protected override int AddField(Field field)
        {
            return Controller.Archive.ArchiveFieldController.AddField(field, this.ArchiveTabID);
        }

        protected override void EditField(int originalID, Field field)
        {
            Controller.Archive.ArchiveFieldController.UpdateField(originalID, field);
        }

        protected override void DeleteField(Field field)
        {
            Controller.Archive.ArchiveFieldController.DeleteField(field.ID.Value);
        }

        protected override void UpdateFieldsIndex()
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            for (int i = 0; i < radGridView.Rows.Count; i++)
                list.Add(int.Parse(radGridView.Rows[i].Cells["ID"].Value.ToString()), i + 1);
            Controller.Archive.ArchiveFieldController.UpdateFieldsIndex(list);
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
            Controller.Archive.ArchiveFieldController.SetCounterFieldProperties(fieldId, fixedValueType, fixedValue, separator);
        }

        public override CounterFieldSetting GetCounterFieldProperties(int fieldID)
        {
            Model.Archive.CounterFieldSetting counterFieldSetting = Controller.Archive.ArchiveFieldController.GetCounterFieldProperties(fieldID);
            if (counterFieldSetting == null)
                return null;
            return new CounterFieldSetting(counterFieldSetting.ArchiveFieldID, (Enums.FixedValueTypes)counterFieldSetting.FixedValueType, counterFieldSetting.FixedValue, counterFieldSetting.Separator);
        }
    }
}
