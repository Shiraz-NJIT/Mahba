using AutoCompleteTextBoxSample;
using AutoCompleteTextBoxSample2;
using AutoCompleteTextBoxSample3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware
{
    class DossierFormHelper
    {
        public static void EnableOrDisableTabcontrol(TabControl tabControl, bool status, bool resetValue)
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                    DisableOrEnableControl(control, status, resetValue);
            }
        }

        private static void DisableOrEnableControl(Control control, bool enabled, bool resetValue)
        {
            if (control is Njit.Program.Controls.ButtonExtended)
            {
                control.Enabled = enabled;
            }
            else if (control is Button)
            {
                control.Enabled = enabled;
            }
            else if (control is Label)
            {
                control.Enabled = enabled;
            }
            else if (control is CheckBox)
            {
                control.Enabled = enabled;
                if (resetValue)
                    ((CheckBox)control).Checked = false;
            }
            else if (control is Njit.Program.Controls.DataGridViewExtended)
            {
                Njit.Program.Controls.DataGridViewExtended gridView = (Njit.Program.Controls.DataGridViewExtended)control;
                gridView.ReadOnly = !enabled;
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    if (!(column is Njit.Program.DataGridViewColumn.NjitCounterColumn))
                        column.ReadOnly = !enabled;
                    else
                        column.ReadOnly = true;
                }
                //gridView.Enabled = enabled;
                if (resetValue)
                {
                    if (gridView.DataSource == null)
                        gridView.Rows.Clear();
                    else if (gridView.DataSource is BindingSource)
                        (gridView.DataSource as BindingSource).Clear();
                    else
                        gridView.DataSource = null;
                }
            }
            else if (control is DataGridView)
            {
                DataGridView gridView = (DataGridView)control;
                gridView.ReadOnly = !enabled;
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    column.ReadOnly = !enabled;
                }
                //gridView.Enabled = enabled;
                if (resetValue)
                {
                    if (gridView.DataSource == null)
                        gridView.Rows.Clear();
                    else if (gridView.DataSource is BindingSource)
                        (gridView.DataSource as BindingSource).Clear();
                    else
                        gridView.DataSource = null;
                }
            }
            else if (control is GroupBox)
            {
                GroupBox groupBox = (GroupBox)control;
                foreach (Control c in groupBox.Controls)
                {
                    DisableOrEnableControl(c, enabled, resetValue);
                }
            }
            else if (control is Panel)
            {
                Panel panel = (Panel)control;
                foreach (Control c in panel.Controls)
                {
                    DisableOrEnableControl(c, enabled, resetValue);
                }
            }
            else if (control is Njit.Program.Controls.TextBoxExtended)
            {
                Njit.Program.Controls.TextBoxExtended textbox = control as Njit.Program.Controls.TextBoxExtended;
                if (resetValue)
                {
                    if (textbox.Value != null && textbox.Value is Model.Archive.ArchiveField)
                    {
                        Model.Archive.ArchiveField field = textbox.Value as Model.Archive.ArchiveField;
                        if (field.FieldTypeCode == (int)Enums.FieldTypes.شمارنده)
                        {
                            Model.Archive.CounterFieldSetting counterFieldSetting = Controller.Archive.ArchiveFieldController.GetCounterFieldProperties(field.ID);
                            string newValue = SqlHelper.GetNewValueOfCounterFiled(field, counterFieldSetting);
                            textbox.Text = newValue;
                        }
                        else
                            textbox.Text = field.DefaultValue;
                    }
                    else
                        textbox.Text = "";
                }
                textbox.Enabled = enabled;
            }
            else if (control is Njit.Program.Controls.ComboBoxExtended)
            {
                Njit.Program.Controls.ComboBoxExtended comboBox = control as Njit.Program.Controls.ComboBoxExtended;
                if (resetValue)
                {
                    if (comboBox.Value != null && comboBox.Value is Model.Archive.ArchiveField)
                    {
                        Model.Archive.ArchiveField field = comboBox.Value as Model.Archive.ArchiveField;
                        if (field.DefaultValue.IsNullOrEmpty())
                        {
                            comboBox.Text = "";
                            comboBox.SelectedValue = -1;
                        }
                        else
                            comboBox.Text = field.DefaultValue;
                    }
                    else
                    {
                        comboBox.Text = "";
                        comboBox.SelectedValue = -1;
                    }
                }
                comboBox.Enabled = enabled;
            }
            else if (control is Njit.Program.Controls.DateControl)
            {
                Njit.Program.Controls.DateControl dateControl = control as Njit.Program.Controls.DateControl;
                if (resetValue)
                {
                    if (dateControl.Value != null && dateControl.Value is Model.Archive.ArchiveField)
                    {
                        Model.Archive.ArchiveField field = dateControl.Value as Model.Archive.ArchiveField;
                        dateControl.Text = field.DefaultValue;
                    }
                    else
                        dateControl.Text = "";
                }
                dateControl.Enabled = enabled;
            }
            else if (control is Njit.Program.Controls.TimeControl)
            {
                Njit.Program.Controls.TimeControl timeControl = control as Njit.Program.Controls.TimeControl;
                if (resetValue)
                {
                    if (timeControl.Value != null && timeControl.Value is Model.Archive.ArchiveField)
                    {
                        Model.Archive.ArchiveField field = timeControl.Value as Model.Archive.ArchiveField;
                        timeControl.Text = field.DefaultValue;
                    }
                    else
                        timeControl.Text = "";
                }
                timeControl.Enabled = enabled;
            }
            else
            {
                control.Enabled = enabled;
                if (resetValue)
                    if(control.Name!="PersonnelNumber")
                    control.Text = "";
            }
        }

        public static Label CreateLabel(string text, int x, int y)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.AutoSize = false;
            label.Size = new System.Drawing.Size(160, 20);
            label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            label.Text = text + ":";
            label.Location = new System.Drawing.Point(x, y);
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label.BringToFront();
            return label;
        }

        public static Label CreateLabelStar(int X, int Y)
        {
            Label label = new System.Windows.Forms.Label();
            label.AutoSize = false;
            label.Size = new System.Drawing.Size(14, 20);
            label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            label.TabIndex = 0;
            label.Name = "_LabelStar";
            label.Text = "*";
            label.ForeColor = System.Drawing.Color.Red;
            label.Location = new System.Drawing.Point(X + 165, Y);
            label.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            return label;
        }

        public static Njit.Program.Controls.TextBoxExtended CreateTextBox(Model.Archive.ArchiveField field, int x, int y, System.Windows.Forms.RightToLeft rightToLeft = RightToLeft.Yes)
        {
            Njit.Program.Controls.TextBoxExtended textBox = CreateTextBox(field.Label, field.FieldName, field.FieldTypeCode, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, x, y, rightToLeft);
            textBox.Value = field;
            return textBox;
        }
        public static Njit.Program.Controls.TextBoxExtended CreateTextBoxForDossierDocsManagement(string label, string fieldName, int fieldTypeCode, int? minLength, int? maxLength, double? minValue, double? maxValue, string defaultValue, int x, int y, System.Windows.Forms.RightToLeft rightToLeft = RightToLeft.Yes)
        {
            Njit.Program.Controls.TextBoxExtended textBox = new Njit.Program.Controls.TextBoxExtended();
            textBox.Tag = label; ;
            textBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Name = fieldName;
            textBox.RightToLeft = rightToLeft;
            textBox.Size = new System.Drawing.Size(160, 20);
            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            textBox.BackColor = System.Drawing.Color.White;
            textBox.ForeColor = System.Drawing.Color.Black;
            SetControlInputType(textBox, fieldTypeCode, minLength, maxLength, minValue, maxValue);
            textBox.Text = defaultValue ?? "";

            return textBox;
        }
        public static Njit.Program.Controls.TextBoxExtended CreateTextBox(string label, string fieldName, int fieldTypeCode, int? minLength, int? maxLength, double? minValue, double? maxValue, string defaultValue, int x, int y, System.Windows.Forms.RightToLeft rightToLeft = RightToLeft.Yes)
        {
            Njit.Program.Controls.TextBoxExtended textBox = new Njit.Program.Controls.TextBoxExtended();
            textBox.Tag = label; ;
            textBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Name = fieldName;
            textBox.RightToLeft = rightToLeft;
            textBox.Size = new System.Drawing.Size(160, 20);
            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            textBox.BackColor = System.Drawing.Color.White;
            textBox.ForeColor = System.Drawing.Color.Black;
            SetControlInputType(textBox, fieldTypeCode, minLength, maxLength, minValue, maxValue);
            textBox.Text = defaultValue ?? "";
            if (fieldTypeCode == (int)Enums.FieldTypes.متن_طولانی)
            {
                textBox.Size = new System.Drawing.Size(395, 50);
                textBox.Location = new System.Drawing.Point(225, y);
                textBox.Multiline = true;
                textBox.ScrollBars = ScrollBars.Vertical;
            }
            else if (fieldTypeCode == (int)Enums.FieldTypes.متن_طولانی_تک_خطی)
            {
                textBox.Size = new System.Drawing.Size(395, 20);
                textBox.Location = new System.Drawing.Point(225, y);
            }
            return textBox;
        }
        public static AutoCompleteTextbox CreateAutoTextBox(string label, string fieldName, int fieldTypeCode, int? minLength, int? maxLength, double? minValue, double? maxValue, string defaultValue, int x, int y, System.Windows.Forms.RightToLeft rightToLeft = RightToLeft.Yes)
        {
            AutoCompleteTextbox textBox = new AutoCompleteTextbox();
            textBox.Tag = label; ;
            textBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Name = fieldName;
            textBox.RightToLeft = rightToLeft;
            textBox.Size = new System.Drawing.Size(160, 20);
            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            textBox.BackColor = System.Drawing.Color.White;
            textBox.ForeColor = System.Drawing.Color.Black;
            // SetControlInputType(textBox, fieldTypeCode, minLength, maxLength, minValue, maxValue);
            textBox.Text = defaultValue ?? "";

            return textBox;
        }
        public static AutoCompleteTextbox3 CreateAutoTextBox3(string label, string fieldName, int fieldTypeCode, int? minLength, int? maxLength, double? minValue, double? maxValue, string defaultValue, int x, int y, System.Windows.Forms.RightToLeft rightToLeft = RightToLeft.Yes)
        {
            AutoCompleteTextbox3 textBox = new AutoCompleteTextbox3();
            textBox.Tag = label; ;
            textBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Name = fieldName;
            textBox.RightToLeft = rightToLeft;
            textBox.Size = new System.Drawing.Size(160, 20);
            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            textBox.BackColor = System.Drawing.Color.White;
            textBox.ForeColor = System.Drawing.Color.Black;
            // SetControlInputType(textBox, fieldTypeCode, minLength, maxLength, minValue, maxValue);
            textBox.Text = defaultValue ?? "";

            return textBox;
        }
        public static AutoCompleteTextbox2 CreateAutoTextBox2(string label, string fieldName, int fieldTypeCode, int? minLength, int? maxLength, double? minValue, double? maxValue, string defaultValue, int x, int y, System.Windows.Forms.RightToLeft rightToLeft = RightToLeft.Yes)
        {
            AutoCompleteTextbox2 textBox = new AutoCompleteTextbox2();
            textBox.Tag = label; ;
            textBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Name = fieldName;
            textBox.RightToLeft = rightToLeft;
            textBox.Size = new System.Drawing.Size(160, 20);
            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            textBox.BackColor = System.Drawing.Color.White;
            textBox.ForeColor = System.Drawing.Color.Black;
            // SetControlInputType(textBox, fieldTypeCode, minLength, maxLength, minValue, maxValue);
            textBox.Text = defaultValue ?? "";

            return textBox;
        }
        public static Njit.Program.Controls.ComboBoxExtended CreateComboBox(Model.Archive.ArchiveField field, int X, int Y)
        {
            Njit.Program.Controls.ComboBoxExtended comboBox = new Njit.Program.Controls.ComboBoxExtended();
            comboBox.Tag = field.Label;
            comboBox.EditItemsEnabled = true;
            comboBox.CaptionField = "Title";
            comboBox.KeyField = "ID";
            comboBox.TableName = field.FieldName;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.AutoCompleteMode = AutoCompleteMode.Append;
            comboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            comboBox.Location = new System.Drawing.Point(X, Y);
            comboBox.Name = field.FieldName;
            comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            comboBox.Size = new System.Drawing.Size(160, 20);
            comboBox.BackColor = System.Drawing.Color.White;
            comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            comboBox.DataAccess = DataAccess.ArchiveDataAccess.GetNewInstance();
            comboBox.Text = field.DefaultValue ?? "";
            comboBox.Value = field;
            SetControlInputType(comboBox, field.FieldTypeCode, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue);
            return comboBox;
        }

        public static Njit.Program.Controls.DateControl CreateDateBox(Model.Archive.ArchiveField field, int X, int Y)
        {
            Njit.Program.Controls.DateControl dateControl = new Njit.Program.Controls.DateControl();
            dateControl.Tag = field.Label;
            dateControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dateControl.Location = new System.Drawing.Point(X, Y);
            dateControl.Name = field.FieldName;
            dateControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dateControl.Size = new System.Drawing.Size(160, 20);
            dateControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateControl.BackColor = System.Drawing.Color.White;
            dateControl.ForeColor = System.Drawing.Color.Black;
            dateControl.Value = field;
            if (Njit.Common.PersianCalendar.DateIsCorrect(field.DefaultValue))
                dateControl.Text = field.DefaultValue;
            if (field.FieldTypeCode == (int)Enums.FieldTypes.تاریخ_جاری)
            {
                dateControl.ReadOnly = true;
                dateControl.SetDate(DataAccess.CommonDataAccess.GetNewInstance().Connection.GetServerDateTime());
            }
            return dateControl;
        }

        public static Njit.Program.Controls.TimeControl CreateTimeBox(Model.Archive.ArchiveField field, int X, int Y)
        {
            Njit.Program.Controls.TimeControl timeControl = new Njit.Program.Controls.TimeControl();
            timeControl.Tag = field.Label;
            timeControl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            timeControl.Location = new System.Drawing.Point(X, Y);
            timeControl.Name = field.FieldName;
            timeControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            timeControl.Size = new System.Drawing.Size(160, 20);
            timeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            timeControl.BackColor = System.Drawing.Color.White;
            timeControl.ForeColor = System.Drawing.Color.Black;
            timeControl.Value = field;
            if (Njit.Common.PersianCalendar.TimeIsCorrect(field.DefaultValue))
                timeControl.Text = field.DefaultValue;
            return timeControl;
        }

        public static CheckBox CreateChekBox(Model.Archive.ArchiveField field, int X, int Y)
        {
            CheckBox checkBox = new System.Windows.Forms.CheckBox();
            checkBox.Tag = field.Label;
            checkBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            checkBox.Location = new System.Drawing.Point(X, Y);
            checkBox.Name = field.FieldName;
            checkBox.Text = field.Label;
            checkBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            checkBox.Size = new System.Drawing.Size(160, 20);
            checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            checkBox.ForeColor = System.Drawing.Color.Black;
            //checkBox.Value = field;
            //if (!field.DefaultValue.IsNullOrEmpty() && (field.DefaultValue == "بله" || field.DefaultValue == "صحیح" || field.DefaultValue.ToLower() == "true" || field.DefaultValue == "درست"))
            //    checkBox.Checked = true;
            return checkBox;
        }

        public static GroupBox CreateGroupBox(Model.Archive.ArchiveField field, int Y)
        {
            GroupBox _GroupBox = new System.Windows.Forms.GroupBox();
            _GroupBox.Tag = field.Label;
            _GroupBox.Text = field.Label;
            _GroupBox.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            _GroupBox.Location = new System.Drawing.Point(20, Y);
            _GroupBox.Name = field.FieldName;
            _GroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            _GroupBox.Size = new System.Drawing.Size(768, 200);
            _GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            _GroupBox.Padding = new Padding(8, 3, 8, 8);
            return _GroupBox;
        }

        public static Njit.Program.Controls.DataGridViewExtended CreateDataGridView(Model.Archive.ArchiveField field)
        {
            List<Model.Archive.ArchiveSubGroupField> subGroupFields = Controller.Archive.DossierCacheController.GetSubGroupFields(field.ID);

            Njit.Program.Controls.DataGridViewExtended gridView = new Njit.Program.Controls.DataGridViewExtended();
            gridView.Text = field.Label;
            gridView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            gridView.Location = new System.Drawing.Point(10, 25);
            gridView.Name = field.FieldName;
            gridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            gridView.Size = new System.Drawing.Size(710, 100);
            gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            gridView.BackColor = System.Drawing.Color.White;
            gridView.AllowUserToOrderColumns = true;
            gridView.AllowUserToAddRows = true;
            gridView.AllowUserToDeleteRows = true;
            gridView.AllowUserToResizeColumns = true;
            gridView.AllowUserToResizeRows = true;
            gridView.ReadOnly = false;
            gridView.RowHeadersVisible = true;
            gridView.EditMode = DataGridViewEditMode.EditOnEnter;
            gridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            gridView.Dock = DockStyle.Fill;

            Njit.Program.DataGridViewColumn.NjitCounterColumn counterColumn = new Njit.Program.DataGridViewColumn.NjitCounterColumn();
            counterColumn.ReadOnly = true;
            counterColumn.HeaderText = "ردیف";
            counterColumn.MinimumWidth = 60;
            counterColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridView.Columns.Add(counterColumn);

            foreach (Model.Archive.ArchiveSubGroupField subGroupField in subGroupFields)
            {
                switch (subGroupField.FieldTypeCode)
                {
                    case (int)Enums.FieldTypes.متن:
                    case (int)Enums.FieldTypes.متن_طولانی:
                    case (int)Enums.FieldTypes.متن_طولانی_تک_خطی:
                    case (int)Enums.FieldTypes.عدد_صحیح:
                    case (int)Enums.FieldTypes.عدد_صحیح_بزرگ:
                    case (int)Enums.FieldTypes.عدد_اعشاری:
                    case (int)Enums.FieldTypes.عدد_اعشاری_بزرگ:
                    case (int)Enums.FieldTypes.پست_الکترونیک:
                    case (int)Enums.FieldTypes.کد_ملی:
                    case (int)Enums.FieldTypes.شماره_موبایل:
                    case (int)Enums.FieldTypes.شمارنده:
                    case (int)Enums.FieldTypes.مبلغ:
                        if (subGroupField.BoxTypeCode == (int)Enums.BoxTypes.کادر_بازشو)
                        {
                            Njit.Program.DataGridViewColumn.NjitComboBoxColumn comboBoxColumn = new Njit.Program.DataGridViewColumn.NjitComboBoxColumn();
                            comboBoxColumn.ComboBoxExtended.DataAccess = DataAccess.ArchiveDataAccess.GetNewInstance();
                            comboBoxColumn.ReadOnly = false;
                            comboBoxColumn.Name = subGroupField.FieldName;
                            comboBoxColumn.HeaderText = subGroupField.Label;
                            comboBoxColumn.ComboBoxExtended.EditItemsEnabled = true;
                            comboBoxColumn.ComboBoxExtended.CaptionField = "Title";
                            comboBoxColumn.ComboBoxExtended.KeyField = "ID";
                            comboBoxColumn.ComboBoxExtended.TableName = subGroupField.FieldName;
                            comboBoxColumn.ComboBoxExtended.AutoCompleteSource = AutoCompleteSource.ListItems;
                            comboBoxColumn.ComboBoxExtended.AutoCompleteMode = AutoCompleteMode.Append;
                            comboBoxColumn.DefaultValue = subGroupField.DefaultValue ?? "";
                            SetControlInputType(comboBoxColumn.ComboBoxExtended, subGroupField.FieldTypeCode, subGroupField.MinLength, subGroupField.MaxLength, subGroupField.MinValue, subGroupField.MaxValue);
                            gridView.Columns.Add(comboBoxColumn);
                        }
                        else
                        {
                            Njit.Program.DataGridViewColumn.NjitTextBoxColumn textBoxColumn = new Njit.Program.DataGridViewColumn.NjitTextBoxColumn();
                            textBoxColumn.ReadOnly = false;
                            textBoxColumn.Name = subGroupField.FieldName;
                            textBoxColumn.HeaderText = subGroupField.Label;
                            textBoxColumn.DefaultValue = subGroupField.DefaultValue ?? "";

                            SetControlInputType(textBoxColumn.TextBoxExtended, subGroupField.FieldTypeCode, subGroupField.MinLength, subGroupField.MaxLength, subGroupField.MinValue, subGroupField.MaxValue);
                            gridView.Columns.Add(textBoxColumn);
                        }
                        break;

                    case (int)Enums.FieldTypes.مقدار_صحیح_و_غلط:
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.Name = subGroupField.FieldName;
                        checkBoxColumn.HeaderText = subGroupField.Label;
                        gridView.Columns.Add(checkBoxColumn);
                        break;

                    case (int)Enums.FieldTypes.تاریخ:
                        Njit.Program.DataGridViewColumn.NjitPersianDateColumn dateColumn = new Njit.Program.DataGridViewColumn.NjitPersianDateColumn();
                        dateColumn.ReadOnly = false;
                        dateColumn.Name = subGroupField.FieldName;
                        dateColumn.HeaderText = subGroupField.Label;
                        if (Njit.Common.PersianCalendar.DateIsCorrect(subGroupField.DefaultValue))
                            dateColumn.DefaultValue = subGroupField.DefaultValue;
                        gridView.Columns.Add(dateColumn);
                        break;

                    case (int)Enums.FieldTypes.تاریخ_جاری:
                        Njit.Program.DataGridViewColumn.NjitPersianDateColumn currentDateColumn = new Njit.Program.DataGridViewColumn.NjitPersianDateColumn();
                        currentDateColumn.ReadOnly = false;
                        currentDateColumn.Name = subGroupField.FieldName;
                        currentDateColumn.HeaderText = subGroupField.Label;
                        currentDateColumn.DateControl.ReadOnly = true;
                        currentDateColumn.DateControl.SetDate(DataAccess.CommonDataAccess.GetNewInstance().Connection.GetServerDateTime());
                        gridView.Columns.Add(currentDateColumn);
                        break;

                    case (int)Enums.FieldTypes.ساعت:
                        Njit.Program.DataGridViewColumn.NjitTimeColumn timeColumn = new Njit.Program.DataGridViewColumn.NjitTimeColumn();
                        timeColumn.ReadOnly = false;
                        timeColumn.Name = subGroupField.FieldName;
                        timeColumn.HeaderText = subGroupField.Label;
                        if (Njit.Common.PersianCalendar.TimeIsCorrect(subGroupField.DefaultValue))
                            timeColumn.DefaultValue = subGroupField.DefaultValue;
                        gridView.Columns.Add(timeColumn);
                        break;
                    case (int)Enums.FieldTypes.شخص_حقیقی:
                        Njit.Program.DataGridViewColumn.NjitComboBoxColumn rightfulPersoncomboBoxColumn = new Njit.Program.DataGridViewColumn.NjitComboBoxColumn();
                        rightfulPersoncomboBoxColumn.ReadOnly = false;
                        rightfulPersoncomboBoxColumn.Name = subGroupField.FieldName;
                        rightfulPersoncomboBoxColumn.HeaderText = subGroupField.Label;
                        rightfulPersoncomboBoxColumn.ComboBoxExtended.AutoCompleteSource = AutoCompleteSource.ListItems;
                        rightfulPersoncomboBoxColumn.ComboBoxExtended.AutoCompleteMode = AutoCompleteMode.Append;
                        //rightfulPersoncomboBoxColumn.DefaultValue = subGroupField.DefaultValue ?? "";

                        //rightfulPersoncomboBoxColumn.ComboBoxExtended.DataAccess = DataAccess.ArchiveDataAccess.GetNewInstance();
                        //rightfulPersoncomboBoxColumn.ComboBoxExtended.EditItemsEnabled = true;
                        //rightfulPersoncomboBoxColumn.ComboBoxExtended.EditItemsForm = new View.PersonManageForms.RightfulPersonList();
                        //rightfulPersoncomboBoxColumn.ComboBoxExtended.CaptionField = "Fullname";
                        //rightfulPersoncomboBoxColumn.ComboBoxExtended.KeyField = "Id";
                        //rightfulPersoncomboBoxColumn.ComboBoxExtended.TableName = "RightfulPersonView";
                        var rightfulPersonList = Controller.Archive.RightfulPersonController.GetRightfulPersons();
                        rightfulPersonList.Insert(0, new Model.Archive.RightfulPersonView() { Id = -1, Fullname = "" });
                        rightfulPersoncomboBoxColumn.ComboBoxExtended.DataSource = rightfulPersonList;
                        rightfulPersoncomboBoxColumn.ComboBoxExtended.DisplayMember = "Fullname";
                        rightfulPersoncomboBoxColumn.ComboBoxExtended.ValueMember = "Id";

                        //if (!field.DefaultValue.IsNullOrEmpty())
                        //    rightfulPersoncomboBoxColumn.ComboBoxExtended.SelectedValue = field.DefaultValue.TryToInt();
                        gridView.Columns.Add(rightfulPersoncomboBoxColumn);
                        break;
                    case (int)Enums.FieldTypes.شخص_حقوقی:
                        Njit.Program.DataGridViewColumn.NjitComboBoxColumn legalPersoncomboBoxColumn = new Njit.Program.DataGridViewColumn.NjitComboBoxColumn();
                        legalPersoncomboBoxColumn.ReadOnly = false;
                        legalPersoncomboBoxColumn.Name = subGroupField.FieldName;
                        legalPersoncomboBoxColumn.HeaderText = subGroupField.Label;
                        legalPersoncomboBoxColumn.ComboBoxExtended.AutoCompleteSource = AutoCompleteSource.ListItems;
                        legalPersoncomboBoxColumn.ComboBoxExtended.AutoCompleteMode = AutoCompleteMode.Append;
                        //legalPersoncomboBoxColumn.DefaultValue = subGroupField.DefaultValue ?? "";

                        //legalPersoncomboBoxColumn.ComboBoxExtended.DataAccess = DataAccess.ArchiveDataAccess.GetNewInstance();
                        //legalPersoncomboBoxColumn.ComboBoxExtended.EditItemsEnabled = true;
                        //legalPersoncomboBoxColumn.ComboBoxExtended.EditItemsForm = new View.PersonManageForms.LegalPersonList();
                        //legalPersoncomboBoxColumn.ComboBoxExtended.CaptionField = "Name";
                        //legalPersoncomboBoxColumn.ComboBoxExtended.KeyField = "Id";
                        //legalPersoncomboBoxColumn.ComboBoxExtended.TableName = "LegalPersonView";

                        var legalPersonList = Controller.Archive.LegalPersonController.GetLegalPersons();
                        legalPersonList.Insert(0, new Model.Archive.LegalPersonView() { Id = -1, Name = "" });
                        legalPersoncomboBoxColumn.ComboBoxExtended.DataSource = legalPersonList;
                        legalPersoncomboBoxColumn.ComboBoxExtended.DisplayMember = "Name";
                        legalPersoncomboBoxColumn.ComboBoxExtended.ValueMember = "Id";

                        //if (!field.DefaultValue.IsNullOrEmpty())
                        //    legalPersoncomboBoxColumn.ComboBoxExtended.SelectedValue = field.DefaultValue.TryToInt();
                        gridView.Columns.Add(legalPersoncomboBoxColumn);
                        break;
                }
            }
            gridView.AutoBestFitColumns = true;
            return gridView;
        }

        public static string CheckControlData(string personnelNumber, string tableName, List<Model.Archive.ArchiveField> fields, Control control)
        {
            var query = fields.Where(t => t.FieldName == control.Name);
            if (query.Count() == 0)
                return null;
            Model.Archive.ArchiveField archiveField = query.Single();
            if (control is Njit.Program.Controls.ComboBoxExtended)
            {
                Njit.Program.Controls.ComboBoxExtended comboBoxExtended = (Njit.Program.Controls.ComboBoxExtended)control;
                string FieldName = comboBoxExtended.Name;
                if (archiveField.FieldName == comboBoxExtended.Name)
                {
                    if ((archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد || archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد) && comboBoxExtended.Text == "")
                        return comboBoxExtended.Tag + " تکمیل نشده است ";
                    if ((archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد || archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد) && (comboBoxExtended.Items.Count > 0 && comboBoxExtended.SelectedIndex < 0))
                        return comboBoxExtended.Tag + " از لیست انتخاب نشده است";
                    if (archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد ||
                       archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_بتواند_تهی_باشد)
                    {
                        if (comboBoxExtended.Text != "" && SqlHelper.FieldHaveData(tableName, archiveField.FieldName, comboBoxExtended.Text, personnelNumber))
                            return comboBoxExtended.Tag + " نباید تکراری باشد ";
                    }
                }
            }
            else if (control is Njit.Program.Controls.TextBoxExtended)
            {
                Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                if ((archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد || archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد) && textBoxExtended.Text == "")
                    return textBoxExtended.Tag + " تکمیل نشده است ";
                if (archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_بتواند_تهی_باشد || archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد)
                {
                    if (textBoxExtended.Text != "" && SqlHelper.FieldHaveData(tableName, archiveField.FieldName, textBoxExtended.AutoSeparateDigits ? textBoxExtended.TextWithoutComma : textBoxExtended.Text, personnelNumber))
                        return textBoxExtended.Tag + " نباید تکراری باشد ";
                }
            }
            else if (control is Njit.Program.Controls.DateControl)
            {
                Njit.Program.Controls.DateControl dateControl = (Njit.Program.Controls.DateControl)control;
                if ((archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد || archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد) && dateControl.Text == "")
                    return dateControl.Tag + " تکمیل نشده است ";
                else if (archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد ||
                    archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_بتواند_تهی_باشد)
                {
                    if (dateControl.Text != "" && SqlHelper.FieldHaveData(tableName, archiveField.FieldName, dateControl.Text, personnelNumber))
                        return dateControl.Tag + " نباید تکراری باشد ";
                }
            }
            else if (control is Njit.Program.Controls.TimeControl)
            {
                Njit.Program.Controls.TimeControl timeControl = (Njit.Program.Controls.TimeControl)control;
                if ((archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد || archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد) && timeControl.Text == "")
                    return timeControl.Tag + " تکمیل نشده است ";
                else if (archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد ||
                    archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_بتواند_تهی_باشد)
                {
                    if (timeControl.Text != "" && SqlHelper.FieldHaveData(tableName, archiveField.FieldName, timeControl.Text, personnelNumber))
                        return timeControl.Tag + " نباید تکراری باشد ";
                }
            }
            else if (control is GroupBox)
            {
                GroupBox groupBox = (GroupBox)control;
                foreach (Control c in groupBox.Controls)
                {
                    if (c is Njit.Program.Controls.DataGridViewExtended)
                    {
                        Njit.Program.Controls.DataGridViewExtended gridView = (Njit.Program.Controls.DataGridViewExtended)c;
                        if (archiveField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد && gridView.Rows.Count == 1)
                            return groupBox.Tag + " تکمیل نشده است ";
                        for (int i = 0; i < gridView.Rows.Count - 1; i++)
                        {
                            DataGridViewRow row = gridView.Rows[i];
                            foreach (Model.Archive.ArchiveSubGroupField archiveSubGroupField in Controller.Archive.DossierCacheController.GetSubGroupFields(archiveField.ID))
                            {
                                if (archiveSubGroupField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد || archiveSubGroupField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد)
                                {
                                    if (row.Cells[archiveSubGroupField.FieldName].Value.IsNullOrEmpty())
                                    {
                                        return " ستون " + archiveSubGroupField.Label + " در ردیف شماره " + (i + 1) + " تکمیل نشده است ";
                                    }
                                    else if (archiveSubGroupField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_بتواند_تهی_باشد ||
                                        archiveSubGroupField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد)
                                    {
                                        for (int j = 0; j < gridView.Rows.Count - 1; j++)
                                        {
                                            if (!row.Cells[archiveSubGroupField.FieldName].Value.IsNullOrEmpty())
                                                if (i != j && (gridView.Rows[j].Cells[archiveSubGroupField.FieldName].Value as string) == (row.Cells[archiveSubGroupField.FieldName].Value as string))
                                                {
                                                    return archiveSubGroupField.Label + " " + gridView.Rows[j].Cells[archiveSubGroupField.FieldName].Value.ToString() + " نباید تکراری باشد ";
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static void SetControlInputType(Njit.Program.IInputBox control, int fieldTypeCode, int? minLength, int? maxLength, double? minValue, double? maxValue)
        {
            SetControlInputType(control, fieldTypeCode);
            if (minLength != null)
                control.MinLength = minLength.Value;
            if (maxLength != null)
                control.MaxLength = maxLength.Value;
            if (minValue != null)
                control.MinValue = minValue.Value;
            if (maxValue != null)
                control.MaxValue = maxValue.Value;
        }

        public static void SetControlInputType(Njit.Program.IInputBox control, int fieldTypeCode)
        {
            switch (fieldTypeCode)
            {
                case (int)Enums.FieldTypes.متن:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.AllCharacters;
                    break;
                case (int)Enums.FieldTypes.متن_طولانی:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.AllCharacters;
                    break;
                case (int)Enums.FieldTypes.متن_طولانی_تک_خطی:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.AllCharacters;
                    break;
                case (int)Enums.FieldTypes.عدد_صحیح:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Int;
                    break;
                case (int)Enums.FieldTypes.عدد_صحیح_بزرگ:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.LongInt;
                    break;
                case (int)Enums.FieldTypes.عدد_اعشاری:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Double;
                    break;
                case (int)Enums.FieldTypes.عدد_اعشاری_بزرگ:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Decimal;
                    break;
                case (int)Enums.FieldTypes.پست_الکترونیک:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Email;
                    break;
                case (int)Enums.FieldTypes.کد_ملی:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.NationalCode;
                    break;
                case (int)Enums.FieldTypes.شماره_موبایل:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.Mobile;
                    break;
                case (int)Enums.FieldTypes.شمارنده:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.AllCharacters;
                    break;
                case (int)Enums.FieldTypes.مبلغ:
                    control.InputType = Njit.Program.InputBoxValidationHelper.InputTypes.LongInt;
                    control.AutoSeparateDigits = true;
                    break;
            }
        }

        public static void ResetControl(Control control)
        {
            if (control is Njit.Program.Controls.TextBoxExtended)
            {
                Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                textBoxExtended.Text = "";
                textBoxExtended.Enabled = true;
            }
            else if (control is Njit.Program.Controls.ComboBoxExtended)
            {
                Njit.Program.Controls.ComboBoxExtended comboBoxExtended = (Njit.Program.Controls.ComboBoxExtended)control;
                comboBoxExtended.Text = "";
                if (comboBoxExtended.Items.Count > 0)
                    comboBoxExtended.SelectedIndex = 0;
                comboBoxExtended.Enabled = true;
            }
            else if (control is Njit.Program.Controls.DateControl)
            {
                Njit.Program.Controls.DateControl dateControl = (Njit.Program.Controls.DateControl)control;
                dateControl.Text = "";
                dateControl.Enabled = true;
            }
            else if (control is Njit.Program.Controls.TimeControl)
            {
                Njit.Program.Controls.TimeControl timeControl = (Njit.Program.Controls.TimeControl)control;
                timeControl.Text = "";
                timeControl.Enabled = true;
            }
            else if (control is CheckBox)
            {
                CheckBox checkBox = (CheckBox)control;
                checkBox.Checked = false;
                checkBox.Enabled = true;
            }
            else if (control is Njit.Program.Controls.DataGridViewExtended)
            {
                Njit.Program.Controls.DataGridViewExtended dataGridViewExtended = (Njit.Program.Controls.DataGridViewExtended)control;
                if (dataGridViewExtended.DataSource.IsNullOrEmpty())
                    dataGridViewExtended.Rows.Clear();
                else
                {
                    if (dataGridViewExtended.DataSource is BindingSource)
                        (dataGridViewExtended.DataSource as BindingSource).Clear();
                    dataGridViewExtended.DataSource = null;
                }
                dataGridViewExtended.Refresh();
            }
            else if (control is GroupBox)
            {
                GroupBox groupBox = (GroupBox)control;
                foreach (Control c in groupBox.Controls)
                    ResetControl(c);
            }
            else if (control is Panel)
            {
                Panel panel = (Panel)control;
                foreach (Control c in panel.Controls)
                    ResetControl(c);
            }
        }

        internal static Njit.Program.Controls.ComboBoxExtended CreatePersonComboBox(Model.Archive.ArchiveField field, int X, int Y)
        {
            Njit.Program.Controls.ComboBoxExtended comboBox = new Njit.Program.Controls.ComboBoxExtended();
            comboBox.Tag = field.Label;
            comboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            comboBox.Location = new System.Drawing.Point(X, Y);
            comboBox.Name = field.FieldName;
            comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            comboBox.Size = new System.Drawing.Size(160, 20);
            comboBox.BackColor = System.Drawing.Color.White;
            comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            comboBox.Value = field;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox.AutoCompleteMode = AutoCompleteMode.Append;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            if (field.FieldTypeCode == (int)NjitSoftware.Enums.FieldTypes.شخص_حقیقی)
            {
                var list = Controller.Archive.RightfulPersonController.GetRightfulPersons();
                list.Insert(0, new Model.Archive.RightfulPersonView() { Id = -1, Fullname = "" });
                comboBox.DataSource = list;
                comboBox.DisplayMember = "Fullname";
                comboBox.ValueMember = "Id";
            }
            else if (field.FieldTypeCode == (int)NjitSoftware.Enums.FieldTypes.شخص_حقوقی)
            {
                var list = Controller.Archive.LegalPersonController.GetLegalPersons();
                list.Insert(0, new Model.Archive.LegalPersonView() { Id = -1, Name = "" });
                comboBox.DataSource = list;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";
            }
            //if (!field.DefaultValue.IsNullOrEmpty())
            //    comboBox.SelectedValue = field.DefaultValue.TryToInt();
            return comboBox;
        }
    }
}