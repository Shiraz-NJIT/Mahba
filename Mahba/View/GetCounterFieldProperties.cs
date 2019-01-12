using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class GetCounterFieldProperties : Njit.Program.Forms.OKCancelForm
    {
        public GetCounterFieldProperties()
        {
            InitializeComponent();
        }

        public GetCounterFieldProperties(int fixedValueType, string fixedValue, string separator)
            : this()
        {
            this.FixedValueType = (Enums.FixedValueTypes)fixedValueType;
            this.FixedValue = fixedValue;
            this.Separator = separator;
            switch (this.FixedValueType)
            {
                case Enums.FixedValueTypes.CurrentYear:
                    radioButtonUserCurrentYear.Checked = true;
                    break;
                case Enums.FixedValueTypes.UseCustomFixedValue:
                    radioButtonUseFixedValue.Checked = true;
                    break;
                case Enums.FixedValueTypes.WithoutFixedValue:
                    radioButtonDontUserFixedValue.Checked = true;
                    break;
            }
            txtFixedValue.Text = fixedValue ?? "";
            txtSeparator.Text = separator;
        }

        private Enums.FixedValueTypes _FixedValueType = Enums.FixedValueTypes.CurrentYear;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Enums.FixedValueTypes FixedValueType
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

        private string _FixedValue = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        private string _Separator = "/";
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        private void radioButtonUseFixedValue_CheckedChanged(object sender, EventArgs e)
        {
            txtFixedValue.Enabled = radioButtonUseFixedValue.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioButtonUserCurrentYear.Checked)
                this.FixedValueType = Enums.FixedValueTypes.CurrentYear;
            else if (radioButtonUseFixedValue.Checked)
            {
                this.FixedValueType = Enums.FixedValueTypes.UseCustomFixedValue;
                this.FixedValue = txtFixedValue.Text;
            }
            else if (radioButtonDontUserFixedValue.Checked)
                this.FixedValueType = Enums.FixedValueTypes.WithoutFixedValue;
            if (txtSeparator.Text.IsNullOrEmpty())
                txtSeparator.Text = "/";
            this.Separator = txtSeparator.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
