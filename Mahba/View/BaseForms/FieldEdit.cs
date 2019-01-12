using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.BaseForms
{
    public partial class FieldEdit : Njit.Program.Forms.OKCancelForm
    {
        public FieldEdit()
        {
            InitializeComponent();
        }

        public FieldEdit(Field field)
        {
            InitializeComponent();
            this.Field = field;
            fieldInfo.FillData();
            fieldInfo.SetData(field);
        }

        private Field _Field;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Field Field
        {
            get
            {
                return _Field;
            }
            set
            {
                _Field = value;
            }
        }

        public class FieldEventArgs : EventArgs
        {
            public FieldEventArgs(Field OriginalField, Field NewField)
            {
                this.OriginalField = OriginalField;
                this.NewField = NewField;
            }
            private Field _OriginalField;
            public Field OriginalField
            {
                get
                {
                    return _OriginalField;
                }
                set
                {
                    _OriginalField = value;
                }
            }
            private Field _NewField;
            public Field NewField
            {
                get
                {
                    return _NewField;
                }
                set
                {
                    _NewField = value;
                }
            }
        }

        public class CounterFieldEventArgs : EventArgs
        {
            public CounterFieldEventArgs(int fieldID, int fixedValueType, string fixedValue, string separator)
            {
                this.FieldID = fieldID;
                this.FixedValueType = fixedValueType;
                this.FixedValue = fixedValue;
                this.Separator = separator;

            }
            private int _FieldID;
            public int FieldID
            {
                get
                {
                    return _FieldID;
                }
                set
                {
                    _FieldID = value;
                }
            }
            private int _FixedValueType;
            public int FixedValueType
            {
                get
                {
                    return _FixedValueType;
                }
                set
                {
                    _FixedValueType = value;
                }
            }
            private string _FixedValue;
            public string FixedValue
            {
                get
                {
                    return _FixedValue;
                }
                set
                {
                    _FixedValue = value;
                }
            }
            private string _Separator;
            public string Separator
            {
                get
                {
                    return _Separator;
                }
                set
                {
                    _Separator = value;
                }
            }
        }

        public class GetCounterFieldEventArgs : EventArgs
        {
            public GetCounterFieldEventArgs(int fieldID)
            {
                this.FieldID = fieldID;
            }
            private int _FieldID;
            public int FieldID
            {
                get
                {
                    return _FieldID;
                }
                set
                {
                    _FieldID = value;
                }
            }
            private CounterFieldSetting _CounterFieldSetting = null;
            public CounterFieldSetting CounterFieldSetting
            {
                get
                {
                    return _CounterFieldSetting;
                }
                set
                {
                    _CounterFieldSetting = value;
                }
            }
        }

        public event EventHandler<FieldEventArgs> EditField;
        public virtual void OnEditField(Field OriginalField, Field NewField)
        {
            if (EditField != null)
                EditField(this, new FieldEventArgs(OriginalField, NewField));
        }

        public event EventHandler<CounterFieldEventArgs> SetCounterFieldProperties;
        public virtual void OnSetCounterFieldProperties(int fieldID, int fixedValueType, string fixedValue, string separator)
        {
            if (SetCounterFieldProperties != null)
                SetCounterFieldProperties(this, new CounterFieldEventArgs(fieldID, fixedValueType, fixedValue, separator));
        }

        public event EventHandler<GetCounterFieldEventArgs> GetCounterFieldProperties;
        public virtual void OnGetCounterFieldProperties(GetCounterFieldEventArgs e)
        {
            if (GetCounterFieldProperties != null)
                GetCounterFieldProperties(this, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!btnOK.Focused)
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            try
            {
                fieldInfo.ValidateContents();
                this.ValidateContents();
            }
            catch (Njit.Common.ValidateException ex)
            {
                ex.Control.TextChanged -= ControlTextChanged;
                ex.Control.Leave -= ControlLeave;
                PersianMessageBox.Show(ex.Message);
                ex.Control.Focus();
                ex.Control.TextChanged += ControlTextChanged;
                ex.Control.Leave += ControlLeave;
                errorProvider.SetError(ex.Control, ex.Message);
                return;
            }
            try
            {
                NjitSoftware.Field field = fieldInfo.GetData();
                View.GetCounterFieldProperties counterFieldPropertiesForm = null;
                if (field.FieldTypeCode == (int)Enums.FieldTypes.شمارنده)
                {
                    GetCounterFieldEventArgs _eventArgs = new GetCounterFieldEventArgs(this.Field.ID.Value);
                    OnGetCounterFieldProperties(_eventArgs);
                    if (_eventArgs.CounterFieldSetting != null)
                        counterFieldPropertiesForm = new GetCounterFieldProperties((int)_eventArgs.CounterFieldSetting.FixedValueType, _eventArgs.CounterFieldSetting.FixedValue, _eventArgs.CounterFieldSetting.Separator);
                    else
                        counterFieldPropertiesForm = new GetCounterFieldProperties();
                    if (counterFieldPropertiesForm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                        return;
                }
                OnEditField(this.Field, field);
                this.Tag = this.Field.ID.Value;
                if (field.FieldTypeCode == (int)Enums.FieldTypes.شمارنده)
                {
                    OnSetCounterFieldProperties(this.Field.ID.Value, (int)counterFieldPropertiesForm.FixedValueType, counterFieldPropertiesForm.FixedValue, counterFieldPropertiesForm.Separator);
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ValidateContents()
        {
            if (this.Field.FieldTypeCode == (int)Enums.FieldTypes.زیرگروه_جدولی)
            {
                if (((int)fieldInfo.FieldTypeCode) != (int)Enums.FieldTypes.زیرگروه_جدولی)
                    throw new Njit.Common.ValidateException(fieldInfo.GetComboBoxFieldType(), "نوع زیرگروه جدولی را نمی توانید به نوع های دیگر تغییر دهید");
            }
            if (((int)fieldInfo.FieldTypeCode) == (int)Enums.FieldTypes.زیرگروه_جدولی)
            {
                if (this.Field.FieldTypeCode != (int)Enums.FieldTypes.زیرگروه_جدولی)
                    throw new Njit.Common.ValidateException(fieldInfo.GetComboBoxFieldType(), "نوع های دیگر را نمیتوانید به نوع زیرگروه جدولی تبدیل کنید");
            }
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
