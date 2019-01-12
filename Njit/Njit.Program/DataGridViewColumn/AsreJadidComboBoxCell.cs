using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Njit.Program.DataGridViewColumn
{
    public class NjitComboBoxCell : System.Windows.Forms.DataGridViewTextBoxCell
    {
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            Controls.ComboBoxExtended control = DataGridView.EditingControl as Controls.ComboBoxExtended;
            NjitComboBoxColumn column = (this.OwningColumn as NjitComboBoxColumn);
            foreach (var property in column.ComboBoxExtended.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(control, property.GetValue(column.ComboBoxExtended, null), null);
            }
            if (control.EditItemsEnabled == false)
            {
                if (control.DataSource == null)
                {
                    control.Items.Clear();
                    foreach (object item in column.ComboBoxExtended.Items)
                        control.Items.Add(item);
                }
            }
            else
                control.RefreshData();
            control.DropDownStyle = column.ComboBoxExtended.DropDownStyle;
            control.AutoCompleteMode = column.ComboBoxExtended.AutoCompleteMode;
            control.AutoCompleteSource = column.ComboBoxExtended.AutoCompleteSource;
            control.AutoCompleteCustomSource = column.ComboBoxExtended.AutoCompleteCustomSource;

            control.DataSource = column.ComboBoxExtended.DataSource;
            control.DisplayMember = column.ComboBoxExtended.DisplayMember;
            control.ValueMember = column.ComboBoxExtended.ValueMember;
            if (control.DataSource != null && control.Items.Count > 0 && this.SelectedValue != null)
            {
                control.SelectedValue = this.SelectedValue;
                this.RaiseCellValueChanged(new System.Windows.Forms.DataGridViewCellEventArgs(this.ColumnIndex, this.RowIndex));
            }
            else
            {
                if (this.Value == null || this.Value == DBNull.Value)
                {
                    if ((this.OwningColumn as NjitComboBoxColumn).DefaultValue.IsNullOrEmpty() == false)
                        control.Text = (this.OwningColumn as NjitComboBoxColumn).DefaultValue;
                }
                else
                {
                    control.Text = this.Value.ToString();
                }
            }
            DataGridView.CellValidating += DataGridViewCellValidating;
            control.SelectedValueChanged += control_SelectedValueChanged;
        }

        private void control_SelectedValueChanged(object sender, EventArgs e)
        {
            this.SelectedValue = (sender as Controls.ComboBoxExtended).SelectedValue;
        }

        private object _SelectedValue = null;
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedValue
        {
            get
            {
                return _SelectedValue;
            }
            set
            {
                _SelectedValue = value;
            }
        }

        private void DataGridViewCellValidating(object sender, System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            if (DataGridView[e.ColumnIndex, e.RowIndex].EditType == typeof(Controls.ComboBoxExtended))
            {
                Controls.ComboBoxExtended control = DataGridView.EditingControl as Controls.ComboBoxExtended;
                control.CheckValidation(e);
            }
        }

        public override void DetachEditingControl()
        {
            base.DetachEditingControl();
            DataGridView.CellValidating -= DataGridViewCellValidating;
            Controls.ComboBoxExtended control = DataGridView.EditingControl as Controls.ComboBoxExtended;
            if (control != null)
                control.SelectedValueChanged -= control_SelectedValueChanged;
        }

        public override Type EditType
        {
            get
            {
                return typeof(Controls.ComboBoxExtended);
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
                    return (this.OwningColumn as NjitComboBoxColumn).DefaultValue;
                return null;
            }
        }
    }
}
