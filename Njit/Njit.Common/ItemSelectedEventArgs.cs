using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public class ItemSelectedEventArgs : EventArgs
    {
        public ItemSelectedEventArgs(object SelectedItem)
        {
            this.SelectedItem = SelectedItem;
        }

        private object _SelectedItem;
        public object SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
            }
        }
    }
}
