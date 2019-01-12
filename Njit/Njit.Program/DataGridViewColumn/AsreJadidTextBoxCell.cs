using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Njit.Program.DataGridViewColumn
{
    class NjitTextBoxCell : System.Windows.Forms.DataGridViewTextBoxCell
    {
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, System.Windows.Forms.DataGridViewElementStates cellState, object value, object formattedValue, string errorText, System.Windows.Forms.DataGridViewCellStyle cellStyle, System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle, System.Windows.Forms.DataGridViewPaintParts paintParts)
        {
            if (this.OwningColumn != null && !value.IsNullOrEmpty())
            {
                NjitTextBoxColumn column = (this.OwningColumn as NjitTextBoxColumn);
                if (column.TextBoxExtended.AutoSeparateDigits)
                {
                    if (value.ToString().Contains(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString()))
                        value = value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), "");
                    formattedValue = Njit.Common.Helpers.NumbersHelper.InsertComma(value.ToString());
                }
            }
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            Controls.TextBoxExtended control = DataGridView.EditingControl as Controls.TextBoxExtended;
            NjitTextBoxColumn column = (this.OwningColumn as NjitTextBoxColumn);
            foreach (var property in column.TextBoxExtended.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(control, property.GetValue(column.TextBoxExtended, null), null);
            }
            if (this.Value == null || this.Value == DBNull.Value)
            {
                control.Text = (this.OwningColumn as NjitTextBoxColumn).DefaultValue;
            }
            else
            {
                control.Text = this.Value.ToString();
            }
            DataGridView.CellValidating += DataGridViewCellValidating;
        }

        private void DataGridViewCellValidating(object sender, System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            if (DataGridView[e.ColumnIndex, e.RowIndex].EditType == typeof(Controls.TextBoxExtended))
            {
                Controls.TextBoxExtended control = DataGridView.EditingControl as Controls.TextBoxExtended;
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
                return typeof(Controls.TextBoxExtended);
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
                    return (this.OwningColumn as NjitTextBoxColumn).DefaultValue;
                return null;
            }
        }
    }
}
