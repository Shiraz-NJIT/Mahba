using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.Controls
{
    public partial class FieldInfo : UserControl
    {
        public FieldInfo()
        {
            InitializeComponent();
            numericUpDownMinValue.Maximum = numericUpDownMaxValue.Maximum = decimal.MaxValue;
            numericUpDownMinValue.Minimum = numericUpDownMaxValue.Minimum = decimal.MinValue;
        }

        public FieldInfo(NjitSoftware.Field field)
            : this()
        {
            SetData(field);
        }

        private bool _IsSubField = false;
        [DefaultValue(false)]
        public bool IsSubField
        {
            get
            {
                return _IsSubField;
            }
            set
            {
                _IsSubField = value;
            }
        }

        public void FillData()
        {
            cmbBoxType.SuspendLayout();
            cmbFieldStatus.SuspendLayout();
            cmbFieldType.SuspendLayout();
            this.boxTypeBindingSource.DataSource = Controller.Common.BoxTypeController.GetAllBoxTypes();
            this.fieldStatusBindingSource.DataSource = Controller.Common.FieldStatusController.GetAllFieldStatus();
            if (this.IsSubField)
                this.fieldTypeBindingSource.DataSource = Controller.Common.FieldTypeController.GetAllFieldTypesForSubField();
            else
                this.fieldTypeBindingSource.DataSource = Controller.Common.FieldTypeController.GetAllFieldTypes();
            cmbBoxType.ResumeLayout(false);
            cmbFieldStatus.ResumeLayout(false);
            cmbFieldType.ResumeLayout(false);
        }

        public NjitSoftware.Field GetData()
        {
            NjitSoftware.Field field = new NjitSoftware.Field(null, txtFieldName.Text, null, (int)cmbFieldType.SelectedValue, (cmbFieldType.SelectedItem as Model.Common.FieldType).Title, (int)cmbFieldStatus.SelectedValue, (cmbFieldStatus.SelectedItem as Model.Common.FieldStatus).Title, (int)cmbBoxType.SelectedValue, (cmbBoxType.SelectedItem as Model.Common.BoxType).Title, chkAutocomplete.Checked, numericUpDownMinLenght.Value == 0 ? null : (int?)numericUpDownMinLenght.Value, numericUpDownMaxLength.Value == 0 ? null : (int?)numericUpDownMaxLength.Value, numericUpDownMinValue.Value == 0 ? null : (double?)numericUpDownMinValue.Value, numericUpDownMaxValue.Value == 0 ? null : (double?)numericUpDownMaxValue.Value, null, 0, txtDefaultValue.Text);
            return field;
        }

        public void SetData(NjitSoftware.Field value)
        {
            txtFieldName.Text = value.Label;
            cmbFieldType.SelectedValue = value.FieldTypeCode;
            cmbFieldStatus.SelectedValue = value.StatusCode;
            cmbBoxType.SelectedValue = value.BoxTypeCode;
            numericUpDownMaxLength.Value = value.MaxLength ?? 0;
            numericUpDownMinLenght.Value = value.MinLength ?? 0;
            numericUpDownMaxValue.Value = (decimal)(value.MaxValue ?? 0);
            numericUpDownMinValue.Value = (decimal)(value.MinValue ?? 0);
            chkAutocomplete.Checked = value.AutoComplete;
            txtDefaultValue.Text = value.DefaultValue ?? "";
        }

        public void ValidateContents()
        {
            txtFieldName.Text = txtFieldName.Text.Trim();
            if (txtFieldName.Text == "")
                throw new Njit.Common.ValidateException(txtFieldName, "نام فیلد را وارد کنید");
            if (cmbFieldType.SelectedValue == null)
                throw new Njit.Common.ValidateException(cmbFieldType, "نوع فیلد را مشخص کنید");
            if (cmbFieldStatus.SelectedValue == null)
                throw new Njit.Common.ValidateException(cmbFieldStatus, "وضعیت را مشخص کنید");
            if (cmbBoxType.SelectedValue == null)
                throw new Njit.Common.ValidateException(cmbBoxType, "نوع کادر را مشخص کنید");
            if (numericUpDownMinValue.Value > numericUpDownMaxValue.Value)
                throw new Njit.Common.ValidateException(numericUpDownMinValue, "کوچکترین مقدار نمی تواند از بزرگترین مقدار بیشتر باشد");
            if (numericUpDownMinLenght.Value > numericUpDownMaxLength.Value)
                throw new Njit.Common.ValidateException(numericUpDownMinLenght, "حداقل طول نمی تواند از حداکثر طول بیشتر باشد");
            //if (txtWidth.Text == "")
            //    throw new Njit.Common.ValidateException(txtWidth, "پهنای فیلد را به صورت صحیح وارد کنید");
            //if (txtWidth.IntValue.HasValue == false)
            //    throw new Njit.Common.ValidateException(txtWidth, "پهنای فیلد را وارد کنید");
            //if (txtWidth.IntValue.Value < 20)
            //    throw new Njit.Common.ValidateException(txtWidth, "پهنای فیلد را بیشتر از 20 وارد کنید");
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Label
        {
            get
            {
                return txtFieldName.Text;
            }
            set
            {
                txtFieldName.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object FieldTypeCode
        {
            get
            {
                return cmbFieldType.SelectedValue;
            }
            set
            {
                cmbFieldType.SelectedValue = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object StatusCode
        {
            get
            {
                return cmbFieldStatus.SelectedValue;
            }
            set
            {
                cmbFieldStatus.SelectedValue = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object BoxTypeCode
        {
            get
            {
                return cmbBoxType.SelectedValue;
            }
            set
            {
                cmbBoxType.SelectedValue = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AutoComplete
        {
            get
            {
                return chkAutocomplete.Checked;
            }
            set
            {
                chkAutocomplete.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal MinLength
        {
            get
            {
                return numericUpDownMinLenght.Value;
            }
            set
            {
                numericUpDownMinLenght.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal MaxLength
        {
            get
            {
                return numericUpDownMaxLength.Value;
            }
            set
            {
                numericUpDownMaxLength.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal MinValue
        {
            get
            {
                return numericUpDownMinValue.Value;
            }
            set
            {
                numericUpDownMinValue.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal MaxValue
        {
            get
            {
                return numericUpDownMaxValue.Value;
            }
            set
            {
                numericUpDownMaxValue.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DefaultValue
        {
            get
            {
                return txtDefaultValue.Text;
            }
            set
            {
                txtDefaultValue.Text = value;
            }
        }

        private void cmbFieldType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbFieldType.SelectedValue == null)
                return;
            this.boxTypeBindingSource.DataSource = Controller.Common.BoxTypeController.GetBoxTypes((int)cmbFieldType.SelectedValue);
            this.fieldStatusBindingSource.DataSource = Controller.Common.FieldStatusController.GetFieldStatus((int)cmbFieldType.SelectedValue);
            SetMaxMinValueLengthEnable();
            SetAutocompleteEnable();
        }

        private void SetAutocompleteEnable()
        {
            switch (((Enums.FieldTypes)((int)cmbFieldType.SelectedValue)))
            {
                case Enums.FieldTypes.متن_طولانی_تک_خطی:
                case Enums.FieldTypes.متن:
                    chkAutocomplete.Enabled = true;
                    break;
                case Enums.FieldTypes.متن_طولانی:
                    chkAutocomplete.Enabled = false;
                    break;
                case Enums.FieldTypes.عدد_صحیح:
                case Enums.FieldTypes.عدد_صحیح_بزرگ:
                case Enums.FieldTypes.عدد_اعشاری:
                case Enums.FieldTypes.عدد_اعشاری_بزرگ:
                case Enums.FieldTypes.مبلغ:
                    chkAutocomplete.Enabled = true;
                    break;
                case Enums.FieldTypes.مقدار_صحیح_و_غلط:
                case Enums.FieldTypes.تاریخ:
                case Enums.FieldTypes.تاریخ_جاری:
                case Enums.FieldTypes.ساعت:
                case Enums.FieldTypes.شماره_موبایل:
                case Enums.FieldTypes.کد_ملی:
                case Enums.FieldTypes.پست_الکترونیک:
                case Enums.FieldTypes.زیرگروه_جدولی:
                case Enums.FieldTypes.شمارنده:
                case Enums.FieldTypes.شخص_حقیقی:
                case Enums.FieldTypes.شخص_حقوقی:
                    chkAutocomplete.Enabled = false;
                    break;
                default:
                    throw new Exception();
            }
        }

        private void SetMaxMinValueLengthEnable()
        {
            switch (((Enums.FieldTypes)((int)cmbFieldType.SelectedValue)))
            {
                case Enums.FieldTypes.متن:
                case Enums.FieldTypes.متن_طولانی_تک_خطی:
                case Enums.FieldTypes.متن_طولانی:
                    numericUpDownMaxValue.Value = numericUpDownMinValue.Value = 0;
                    numericUpDownMaxValue.Enabled = numericUpDownMinValue.Enabled = false;
                    numericUpDownMaxLength.Enabled = numericUpDownMinLenght.Enabled = true;
                    break;
                case Enums.FieldTypes.عدد_صحیح:
                case Enums.FieldTypes.عدد_صحیح_بزرگ:
                case Enums.FieldTypes.عدد_اعشاری:
                case Enums.FieldTypes.عدد_اعشاری_بزرگ:
                case Enums.FieldTypes.مبلغ:
                    numericUpDownMaxLength.Enabled = numericUpDownMinLenght.Enabled = true;
                    numericUpDownMaxValue.Enabled = numericUpDownMinValue.Enabled = true;
                    break;
                case Enums.FieldTypes.مقدار_صحیح_و_غلط:
                case Enums.FieldTypes.تاریخ:
                case Enums.FieldTypes.تاریخ_جاری:
                case Enums.FieldTypes.شماره_موبایل:
                case Enums.FieldTypes.کد_ملی:
                case Enums.FieldTypes.ساعت:
                case Enums.FieldTypes.پست_الکترونیک:
                case Enums.FieldTypes.زیرگروه_جدولی:
                case Enums.FieldTypes.شمارنده:
                case Enums.FieldTypes.شخص_حقیقی:
                case Enums.FieldTypes.شخص_حقوقی:
                    numericUpDownMaxValue.Value = numericUpDownMinValue.Value = 0;
                    numericUpDownMaxValue.Enabled = numericUpDownMinValue.Enabled = false;
                    numericUpDownMaxLength.Value = numericUpDownMinLenght.Value = 0;
                    numericUpDownMaxLength.Enabled = numericUpDownMinLenght.Enabled = false;
                    break;
                default:
                    throw new Exception();
            }
        }

        public void Reset()
        {
            txtFieldName.Text = "";
            txtDefaultValue.Text = "";
            txtFieldName.Focus();
        }

        internal Control GetComboBoxFieldType()
        {
            return this.cmbFieldType;
        }

        public bool LastControlFocused
        {
            get
            {
                return (numericUpDownMaxValue.Enabled ? numericUpDownMaxValue.Focused : (numericUpDownMaxLength.Enabled ? numericUpDownMaxLength.Focused : (chkAutocomplete.Enabled ? chkAutocomplete.Focused : cmbBoxType.Focused)));
            }
        }
    }
}
