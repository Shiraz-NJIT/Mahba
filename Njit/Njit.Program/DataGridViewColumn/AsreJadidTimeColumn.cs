using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Njit.Program.DataGridViewColumn
{
    public class NjitTimeColumn : System.Windows.Forms.DataGridViewColumn
    {
        public NjitTimeColumn()
            : base(new NjitTimeCell())
        {
            this.TimeControl = new Controls.TimeControl();
        }

        public override object Clone()
        {
            NjitTimeColumn copy = base.Clone() as NjitTimeColumn;
            foreach (var property in copy.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(copy, property.GetValue(this, null), null);
            }
            return copy;
        }

        private Njit.Program.Controls.TimeControl _TimeControl;
        [DefaultValue(null)]
        [Category("Njit")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Njit.Program.Controls.TimeControl TimeControl
        {
            get
            {
                return _TimeControl;
            }
            set
            {
                _TimeControl = value;
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
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NjitTimeCell)))
                {
                    throw new InvalidCastException("Must be a TimeCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
