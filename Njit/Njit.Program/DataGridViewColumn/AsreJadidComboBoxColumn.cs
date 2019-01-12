using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Njit.Program.DataGridViewColumn
{
    public class NjitComboBoxColumn : System.Windows.Forms.DataGridViewColumn
    {
        public NjitComboBoxColumn()
            : base(new NjitComboBoxCell())
        {
            this.ComboBoxExtended = new Controls.ComboBoxExtended();
        }

        private Njit.Program.Controls.ComboBoxExtended _ComboBoxExtended;
        [DefaultValue(null)]
        [Category("Njit")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Njit.Program.Controls.ComboBoxExtended ComboBoxExtended
        {
            get
            {
                return _ComboBoxExtended;
            }
            set
            {
                _ComboBoxExtended = value;
            }
        }

        private string _DefaultValue = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public string DefaultValue
        {
            get
            {
                return _DefaultValue;
            }
            set
            {
                _DefaultValue = value;
            }
        }

        public override object Clone()
        {
            NjitComboBoxColumn copy = base.Clone() as NjitComboBoxColumn;
            foreach (var property in copy.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(copy, property.GetValue(this, null), null);
            }
            return copy;
        }

        public override System.Windows.Forms.DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NjitComboBoxCell)))
                {
                    throw new InvalidCastException("Must be a ComboBoxCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
