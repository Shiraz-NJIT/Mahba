using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Njit.Program.DataGridViewColumn
{
    public class NjitCounterColumn : System.Windows.Forms.DataGridViewColumn
    {
        public NjitCounterColumn()
            : base(new NjitCounterCell())
        {
            this.ReadOnly = true;
            this.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private bool _AutoRefresh = true;
        [DefaultValue(true)]
        [Category("Njit")]
        public bool AutoRefresh
        {
            get
            {
                return _AutoRefresh;
            }
            set
            {
                _AutoRefresh = value;
                RefreshCellValues();
            }
        }

        public void ResetNumbers()
        {
            if (this.DataGridView != null && this.DataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in this.DataGridView.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    row.Cells[this.Name].Value = row.Cells[this.Name].RowIndex + 1;
                }
                this.DataGridView.Refresh();
            }
        }

        private void RefreshCellValues()
        {
            if (this.DataGridView != null && this.DataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in this.DataGridView.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    if (ValueIsEmpty(row.Cells[this.Name].Value) || this.AutoRefresh)
                        row.Cells[this.Name].Value = row.Cells[this.Name].RowIndex + 1;
                }
                this.DataGridView.Refresh();
            }
        }

        private bool ValueIsEmpty(object value)
        {
            if (value == null)
                return true;
            if (value == DBNull.Value)
                return true;
            if (value is string && value.ToString() == "")
                return true;
            return false;
        }

        public override object Clone()
        {
            NjitCounterColumn copy = base.Clone() as NjitCounterColumn;
            foreach (var property in copy.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(copy, property.GetValue(this, null), null);
            }
            return copy;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(true)]
        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(typeof(DataGridViewColumnSortMode), "NotSortable")]
        public new DataGridViewColumnSortMode SortMode
        {
            get
            {
                return base.SortMode;
            }
            set
            {
                base.SortMode = value;
            }
        }
    }
}
