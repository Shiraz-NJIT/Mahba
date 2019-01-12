using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Njit.Program.DataGridViewColumn
{
    class NjitCounterCell : DataGridViewTextBoxCell
    {
        protected override object GetValue(int rowIndex)
        {
            if (this.OwningColumn != null && (this.OwningColumn as NjitCounterColumn).AutoRefresh /*&& this.DataGridView != null && this.DataGridView.Rows[rowIndex].IsNewRow == false*/)
                return rowIndex + 1;
            return base.GetValue(rowIndex);
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            if (this.OwningColumn != null && (this.OwningColumn as NjitCounterColumn).AutoRefresh /*&& this.DataGridView != null && this.DataGridView.Rows[rowIndex].IsNewRow == false*/)
                return base.SetValue(rowIndex, rowIndex + 1);
            return base.SetValue(rowIndex, value);
        }
    }
}
