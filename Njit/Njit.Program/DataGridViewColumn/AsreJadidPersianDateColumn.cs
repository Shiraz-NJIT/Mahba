using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Njit.Program.DataGridViewColumn
{
    public class NjitPersianDateColumn : System.Windows.Forms.DataGridViewColumn
    {
        public NjitPersianDateColumn()
            : base(new NjitPersianDateCell())
        {
            this.DateControl = new Controls.DateControl();
        }

        public override object Clone()
        {
            NjitPersianDateColumn copy = base.Clone() as NjitPersianDateColumn;
            foreach (var property in copy.GetType().GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(System.ComponentModel.CategoryAttribute), true);
                if (attributes.Length == 1 && ((System.ComponentModel.CategoryAttribute)attributes[0]).Category == "Njit" && property.CanRead && property.CanWrite)
                    property.SetValue(copy, property.GetValue(this, null), null);
            }
            return copy;
        }

        private Njit.Program.Controls.DateControl _DateControl;
        [DefaultValue(null)]
        [Category("Njit")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Njit.Program.Controls.DateControl DateControl
        {
            get
            {
                return _DateControl;
            }
            set
            {
                _DateControl = value;
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
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NjitPersianDateCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
