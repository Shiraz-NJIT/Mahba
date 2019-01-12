using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Njit.Program.DataGridViewColumn
{
    public class NjitTextBoxColumn : System.Windows.Forms.DataGridViewColumn
    {
        public NjitTextBoxColumn()
            : base(new NjitTextBoxCell())
        {
            this.TextBoxExtended = new Controls.TextBoxExtended();
        }

        public override object Clone()
        {
            NjitTextBoxColumn copy = base.Clone() as NjitTextBoxColumn;
            foreach (var property in copy.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(copy, property.GetValue(this, null), null);
            }
            return copy;
        }

        private Njit.Program.Controls.TextBoxExtended _TextBoxExtended;
        [DefaultValue(null)]
        [Category("Njit")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Njit.Program.Controls.TextBoxExtended TextBoxExtended
        {
            get
            {
                return _TextBoxExtended;
            }
            set
            {
                _TextBoxExtended = value;
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

        public override System.Windows.Forms.DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NjitTextBoxCell)))
                {
                    throw new InvalidCastException("Must be a TextBoxCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
