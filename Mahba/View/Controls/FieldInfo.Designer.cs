namespace NjitSoftware.View.Controls
{
    partial class FieldInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fieldTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.boxTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.numericUpDownMinValue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxValue = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinLenght = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxLength = new System.Windows.Forms.NumericUpDown();
            this.cmbBoxType = new Njit.Program.Controls.ComboBoxExtended();
            this.label16 = new System.Windows.Forms.Label();
            this.chkAutocomplete = new System.Windows.Forms.CheckBox();
            this.cmbFieldStatus = new Njit.Program.Controls.ComboBoxExtended();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbFieldType = new Njit.Program.Controls.ComboBoxExtended();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFieldName = new Njit.Program.Controls.TextBoxExtended();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new Njit.Program.Controls.TextBoxExtended();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinLenght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLength)).BeginInit();
            this.SuspendLayout();
            // 
            // fieldTypeBindingSource
            // 
            this.fieldTypeBindingSource.DataSource = typeof(NjitSoftware.Model.Common.FieldType);
            // 
            // boxTypeBindingSource
            // 
            this.boxTypeBindingSource.DataSource = typeof(NjitSoftware.Model.Common.BoxType);
            // 
            // fieldStatusBindingSource
            // 
            this.fieldStatusBindingSource.DataSource = typeof(NjitSoftware.Model.Common.FieldStatus);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "کوچکترین مقدار:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(516, 89);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(69, 14);
            this.lblMax.TabIndex = 13;
            this.lblMax.Text = "حداکثر طول:";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "بزرگترین مقدار:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(682, 89);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(68, 14);
            this.lblMin.TabIndex = 11;
            this.lblMin.Text = "حداقل طول:";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownMinValue
            // 
            this.numericUpDownMinValue.Location = new System.Drawing.Point(211, 87);
            this.numericUpDownMinValue.Name = "numericUpDownMinValue";
            this.numericUpDownMinValue.Size = new System.Drawing.Size(115, 22);
            this.numericUpDownMinValue.TabIndex = 16;
            // 
            // numericUpDownMaxValue
            // 
            this.numericUpDownMaxValue.Location = new System.Drawing.Point(4, 87);
            this.numericUpDownMaxValue.Name = "numericUpDownMaxValue";
            this.numericUpDownMaxValue.Size = new System.Drawing.Size(115, 22);
            this.numericUpDownMaxValue.TabIndex = 18;
            // 
            // numericUpDownMinLenght
            // 
            this.numericUpDownMinLenght.Location = new System.Drawing.Point(591, 87);
            this.numericUpDownMinLenght.Name = "numericUpDownMinLenght";
            this.numericUpDownMinLenght.Size = new System.Drawing.Size(85, 22);
            this.numericUpDownMinLenght.TabIndex = 12;
            // 
            // numericUpDownMaxLength
            // 
            this.numericUpDownMaxLength.Location = new System.Drawing.Point(425, 87);
            this.numericUpDownMaxLength.Name = "numericUpDownMaxLength";
            this.numericUpDownMaxLength.Size = new System.Drawing.Size(85, 22);
            this.numericUpDownMaxLength.TabIndex = 14;
            // 
            // cmbBoxType
            // 
            this.cmbBoxType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBoxType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBoxType.DataSource = this.boxTypeBindingSource;
            this.cmbBoxType.DisplayMember = "Title";
            this.cmbBoxType.FormattingEnabled = true;
            this.cmbBoxType.Location = new System.Drawing.Point(334, 31);
            this.cmbBoxType.Name = "cmbBoxType";
            this.cmbBoxType.Size = new System.Drawing.Size(342, 22);
            this.cmbBoxType.TabIndex = 7;
            this.cmbBoxType.ValueMember = "Code";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(682, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 14);
            this.label16.TabIndex = 6;
            this.label16.Text = "نوع کادر:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAutocomplete
            // 
            this.chkAutocomplete.AutoSize = true;
            this.chkAutocomplete.Location = new System.Drawing.Point(511, 59);
            this.chkAutocomplete.Name = "chkAutocomplete";
            this.chkAutocomplete.Size = new System.Drawing.Size(165, 18);
            this.chkAutocomplete.TabIndex = 10;
            this.chkAutocomplete.Text = "به صورت خودکار تکمیل شود";
            this.chkAutocomplete.UseVisualStyleBackColor = true;
            // 
            // cmbFieldStatus
            // 
            this.cmbFieldStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFieldStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFieldStatus.DataSource = this.fieldStatusBindingSource;
            this.cmbFieldStatus.DisplayMember = "Title";
            this.cmbFieldStatus.FormattingEnabled = true;
            this.cmbFieldStatus.Location = new System.Drawing.Point(4, 3);
            this.cmbFieldStatus.Name = "cmbFieldStatus";
            this.cmbFieldStatus.Size = new System.Drawing.Size(272, 22);
            this.cmbFieldStatus.TabIndex = 5;
            this.cmbFieldStatus.ValueMember = "Code";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(480, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 14);
            this.label14.TabIndex = 2;
            this.label14.Text = "نوع فیلد:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFieldType
            // 
            this.cmbFieldType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFieldType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFieldType.DataSource = this.fieldTypeBindingSource;
            this.cmbFieldType.DisplayMember = "Title";
            this.cmbFieldType.FormattingEnabled = true;
            this.cmbFieldType.Location = new System.Drawing.Point(334, 3);
            this.cmbFieldType.Name = "cmbFieldType";
            this.cmbFieldType.Size = new System.Drawing.Size(140, 22);
            this.cmbFieldType.TabIndex = 3;
            this.cmbFieldType.ValueMember = "Code";
            this.cmbFieldType.SelectedValueChanged += new System.EventHandler(this.cmbFieldType_SelectedValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(282, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 14);
            this.label15.TabIndex = 4;
            this.label15.Text = "وضعیت:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(536, 3);
            this.txtFieldName.MaxLength = 30;
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFieldName.Size = new System.Drawing.Size(140, 22);
            this.txtFieldName.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(682, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "نام فیلد:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(4, 31);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(226, 22);
            this.txtDefaultValue.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "مقدار پیش فرض:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FieldInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtDefaultValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.numericUpDownMinValue);
            this.Controls.Add(this.numericUpDownMaxValue);
            this.Controls.Add(this.numericUpDownMinLenght);
            this.Controls.Add(this.numericUpDownMaxLength);
            this.Controls.Add(this.cmbBoxType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chkAutocomplete);
            this.Controls.Add(this.cmbFieldStatus);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbFieldType);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "FieldInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(754, 114);
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinLenght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.BindingSource fieldTypeBindingSource;
        protected System.Windows.Forms.BindingSource boxTypeBindingSource;
        protected System.Windows.Forms.BindingSource fieldStatusBindingSource;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label lblMax;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label lblMin;
        protected System.Windows.Forms.NumericUpDown numericUpDownMinValue;
        protected System.Windows.Forms.NumericUpDown numericUpDownMaxValue;
        protected System.Windows.Forms.NumericUpDown numericUpDownMinLenght;
        protected System.Windows.Forms.NumericUpDown numericUpDownMaxLength;
        protected Njit.Program.Controls.ComboBoxExtended cmbBoxType;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.CheckBox chkAutocomplete;
        protected Njit.Program.Controls.ComboBoxExtended cmbFieldStatus;
        protected System.Windows.Forms.Label label14;
        protected Njit.Program.Controls.ComboBoxExtended cmbFieldType;
        protected System.Windows.Forms.Label label15;
        protected Njit.Program.Controls.TextBoxExtended txtFieldName;
        protected System.Windows.Forms.Label label13;
        private Njit.Program.Controls.TextBoxExtended txtDefaultValue;
        protected System.Windows.Forms.Label label3;
    }
}
