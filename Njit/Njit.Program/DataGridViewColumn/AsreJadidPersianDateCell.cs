using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Njit.Program.DataGridViewColumn
{
    class NjitPersianDateCell : DataGridViewTextBoxCell
    {
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            Controls.DateControl control = DataGridView.EditingControl as Controls.DateControl;
            NjitPersianDateColumn column = (this.OwningColumn as NjitPersianDateColumn);
            foreach (var property in column.DateControl.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(control, property.GetValue(column.DateControl, null), null);
            }
            if (this.Value == null || this.Value == DBNull.Value)
            {
                control.Text = (this.OwningColumn as NjitPersianDateColumn).DefaultValue;
            }
            else
            {
                control.Text = this.Value.ToString();
            }
            DataGridView.CellValidating += DataGridViewCellValidating;
        }

        private void DataGridViewCellValidating(object sender, System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            if (DataGridView[e.ColumnIndex, e.RowIndex].EditType == typeof(Controls.DateControl))
            {
                Controls.DateControl control = DataGridView.EditingControl as Controls.DateControl;
                control.CheckValidation(e);
            }
        }

        public override void DetachEditingControl()
        {
            base.DetachEditingControl();
            DataGridView.CellValidating -= DataGridViewCellValidating;
        }

        public override Type EditType
        {
            get
            {
                return typeof(Controls.DateControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                if (this.OwningColumn != null)
                    return (this.OwningColumn as NjitPersianDateColumn).DefaultValue;
                return null;
            }
        }
    }
}
