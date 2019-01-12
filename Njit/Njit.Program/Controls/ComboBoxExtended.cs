using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Njit.MessageBox;

namespace Njit.Program.Controls
{
    [ToolboxBitmap(typeof(ComboBox))]
    public partial class ComboBoxExtended : System.Windows.Forms.ComboBox, Njit.Common.IAccessPermission, IDataGridViewEditingControl, IInputBox, Njit.Common.ICustomizedControl
    {
        public ComboBoxExtended()
        {
            InitializeComponent();
            toolStripMenuItemCopy.Click += ToolStripMenuItemCopyClick;
            toolStripMenuItemCut.Click += ToolStripMenuItemCutClick;
            toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
            toolStripMenuItemPaste.Click += ToolStripMenuItemPasteClick;
            toolStripMenuItemSelectAll.Click += ToolStripMenuItemSelectAllClick;
            toolStripMenuItemUndo.Click += ToolStripMenuItemUndoClick;
        }

        private void ToolStripMenuItemUndoClick(object sender, EventArgs e)
        {
            this.Undo();
        }

        private void Undo()
        {

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.EditItemsEnabled && RefreshDataInvoked == false)
                this.RefreshData();
        }

        private void ToolStripMenuItemSelectAllClick(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void ToolStripMenuItemPasteClick(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.SelectedText))
                this.SelectedText = "";
        }

        private void ToolStripMenuItemCutClick(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void Cut()
        {
            if (!string.IsNullOrEmpty(this.SelectedText))
            {
                Clipboard.SetText(this.SelectedText);
                this.SelectedText = "";
            }
        }

        private void ToolStripMenuItemCopyClick(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void Copy()
        {
            if (!string.IsNullOrEmpty(this.SelectedText))
                Clipboard.SetText(this.SelectedText);
        }

        /// <summary>
        /// Replaces the current selection in the text box with the contents of the Clipboard.
        /// </summary>
        public void Paste()
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                int t;
                string text = GetNewText(clipboardText ?? "", out t);
                this.Text = FormatTextValue(text);
                this.Select(t, 0);
            }
        }

        private string GetNewText(string text, out int selectionStart)
        {
            if (this.SelectionLength == 0)
            {
                selectionStart = this.SelectionStart + text.Length;
                return this.Text.Insert(this.SelectionStart, text);
            }
            else
            {
                int t = this.SelectionStart;
                selectionStart = t + text.Length;
                return this.Text.Remove(t, this.SelectionLength).Insert(t, text);
            }
        }
        private string GetNewText(string text)
        {
            if (this.SelectionLength == 0)
                return this.Text.Insert(this.SelectionStart, text);
            else
                return this.Text.Replace(this.SelectedText, text);
        }
        public string GetNewText(char keyChar)
        {
            if (this.SelectionLength == 0)
                return this.Text.Insert(this.SelectionStart, keyChar.ToString());
            else
                return this.Text.Replace(this.SelectedText, keyChar.ToString());
        }

        /// <summary>
        /// متن
        /// </summary>
        [Description("متن")]
        [Category("Njit")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = FormatTextValue(value);
            }
        }

        [Browsable(false)]
        [Category("Njit")]
        public string Words
        {
            get
            {
                if (this.LongValue.HasValue)
                    return Njit.Common.Helpers.NumbersHelper.GetWords(this.LongValue.Value);
                else
                    return null;
            }
        }

        [Browsable(false)]
        [Category("Njit")]
        public string TextWithoutComma
        {
            get
            {
                return this.Text.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), "");
            }
        }

        private string _IllegalCharacters = "";
        [DefaultValue("")]
        [Category("Njit")]
        [Description("کاراکتر های غیر مجاز")]
        public string IllegalCharacters
        {
            get
            {
                return _IllegalCharacters;
            }
            set
            {
                _IllegalCharacters = value;
            }
        }

        private bool _AllowEmptyText = true;
        [DefaultValue(true)]
        [Category("Njit")]
        public bool AllowEmptyText
        {
            get
            {
                return _AllowEmptyText;
            }
            set
            {
                _AllowEmptyText = value;
            }
        }

        private bool _AutoSeparateDigits = false;
        [DefaultValue(false)]
        [Category("Njit")]
        [Description("جدا کردن هر سه رقم با کاما")]
        public bool AutoSeparateDigits
        {
            get
            {
                return _AutoSeparateDigits;
            }
            set
            {
                _AutoSeparateDigits = value;
            }
        }

        private string FormatTextValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            if (this.ReplaceArabicCharsWithPersianChars)
                value = Njit.Common.PublicMethods.FixArabicChars(value);
            if (this.AutoSeparateDigits)
                value = Njit.Common.Helpers.NumbersHelper.InsertComma(value);
            value = InputBoxValidationHelper.FormatTextValueWithInputType(this, value);
            return value;
        }

        private Color _FocusForeColor = Color.Black;
        [DefaultValue(typeof(Color), "Black")]
        [Category("Njit")]
        [Description("رنگ متن هنگام فعال بودن")]
        public Color FocusForeColor
        {
            get
            {
                return _FocusForeColor;
            }
            set
            {
                _FocusForeColor = value;
            }
        }

        private Color _FocusBackColor = Color.White;
        [DefaultValue(typeof(Color), "White")]
        [Category("Njit")]
        [Description("رنگ پس زمینه هنگام فعال بودن")]
        public Color FocusBackColor
        {
            get
            {
                return _FocusBackColor;
            }
            set
            {
                _FocusBackColor = value;
            }
        }

        private Font _FocusFont = null;
        [DefaultValue(null)]
        [Category("Njit")]
        [Description("فونت هنگام فعال بودن")]
        public Font FocusFont
        {
            get
            {
                return _FocusFont;
            }
            set
            {
                _FocusFont = value;
            }
        }

        private bool _ReplaceArabicCharsWithPersianChars = true;
        [DefaultValue(true)]
        [Category("Njit")]
        [Description("جایگزین کردن حروف عربی با حروف فارسی")]
        public bool ReplaceArabicCharsWithPersianChars
        {
            get
            {
                return _ReplaceArabicCharsWithPersianChars;
            }
            set
            {
                _ReplaceArabicCharsWithPersianChars = value;
            }
        }

        Color? lastForeColor = null;
        Color? lastBackColor = null;
        Font lastFont = null;

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            lastForeColor = this.ForeColor;
            lastBackColor = this.BackColor;
            lastFont = this.Font;
            if (this.FocusFont != null)
                this.Font = this.FocusFont;
            if (this.FocusForeColor != this.ForeColor)
                this.ForeColor = this.FocusForeColor;
            if (this.FocusBackColor != this.BackColor)
                this.BackColor = this.FocusBackColor;
            switch (this.InputLanguage)
            {
                case InputLanguages.None:
                    break;
                case InputLanguages.Persian:
                    try
                    {
                        Application.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo.GetCultureInfo("fa-IR"));
                    }
                    catch { }
                    break;
                case InputLanguages.English:
                    try
                    {
                        Application.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo.GetCultureInfo("en-US"));
                    }
                    catch { }
                    break;
                default:
                    break;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.ClearError();
            if (this.lastFont != null)
                this.Font = lastFont;
            if (this.lastBackColor.HasValue)
                this.BackColor = this.lastBackColor.Value;
            if (lastForeColor.HasValue)
                this.ForeColor = lastForeColor.Value;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            toolTip.Hide(this);
            if (ReplaceArabicCharsWithPersianChars)
                Njit.Common.PublicMethods.FixArabicChars(e);
            string errorText;
            if (!InputBoxValidationHelper.CheckKeyPressed(e.KeyChar, this, out errorText))
            {
                e.KeyChar = Convert.ToChar(0);
                SetError(errorText);
            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (this.AutoSeparateDigits && InputBoxValidationHelper.KeyIsDigit(e.KeyCode))
            {
                try
                {
                    int selectionStart = this.SelectionStart;
                    int commaCount1 = this.Text.Substring(0, selectionStart).Where(t => t == CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0]).Count();
                    base.Text = Njit.Common.Helpers.NumbersHelper.InsertComma(this.Text);
                    int commaCount2 = this.Text.Substring(0, selectionStart).Where(t => t == CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0]).Count();
                    if (commaCount2 > commaCount1)
                        selectionStart++;
                    this.SelectionStart = selectionStart;
                }
                catch { }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                this.Paste();
                e.SuppressKeyPress = true;
            }
            base.OnKeyDown(e);
        }

        public void SetError(string ErrorText)
        {
            toolTip.Show(ErrorText, this, 0, -21, 5000);
        }

        public void ShowTooltip(string text)
        {
            ShowTooltip(text, 0, -21, 5000);
        }

        public void ShowTooltip(string text, int duration)
        {
            ShowTooltip(text, 0, -21, duration);
        }

        public void ShowTooltip(string text, int x, int y, int duration)
        {
            toolTip.Show(text, this, x, y, duration);
        }

        [Browsable(false)]
        public int? IntValue
        {
            get
            {
                int t;
                if (int.TryParse(this.Text, out t))
                    return t;
                return null;
            }
        }

        [Browsable(false)]
        public long? LongValue
        {
            get
            {
                long t;
                if (long.TryParse(this.Text, out t))
                    return t;
                return null;
            }
        }

        [Browsable(false)]
        public short? ShortValue
        {
            get
            {
                short t;
                if (short.TryParse(this.Text, out t))
                    return t;
                return null;
            }
        }

        [Browsable(false)]
        public float? FloatValue
        {
            get
            {
                float t;
                if (float.TryParse(this.Text, out t))
                    return t;
                return null;
            }
        }

        [Browsable(false)]
        public double? DoubleValue
        {
            get
            {
                double t;
                if (double.TryParse(this.Text, out t))
                    return t;
                return null;
            }
        }

        [Browsable(false)]
        public decimal? DecimalValue
        {
            get
            {
                decimal t;
                if (decimal.TryParse(this.Text, out t))
                    return t;
                return null;
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemDelete.Enabled = toolStripMenuItemCopy.Enabled = toolStripMenuItemCut.Enabled = this.SelectionLength > 0;
            toolStripMenuItemPaste.Enabled = Clipboard.ContainsText();
        }

        class CustomItemCoverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(string))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }
            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value.GetType() == typeof(string))
                {
                    string[] arr;
                    try
                    {
                        arr = value.ToString().Split(';');
                        return new CustomItem(int.Parse(arr[0].Trim()), arr[1].Trim());
                    }
                    catch
                    {
                        throw new Exception("مقدار و عنوان را با ; از یکدیگر جدا کنید");
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }
            public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string))
                    if (context == null)
                        return ((CustomItem)value).Caption;
                    else
                        return ((CustomItem)value).Value.ToString() + "; " + ((CustomItem)value).Caption;
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        [TypeConverter(typeof(CustomItemCoverter))]
        public class CustomItem
        {
            public CustomItem()
            {
                this.Value = null;
                this.Caption = "";
            }

            public CustomItem(object value, string caption)
            {
                this.Value = value;
                this.Caption = caption;
            }

            private object _Value;
            public object Value
            {
                get
                {
                    return _Value;
                }
                set
                {
                    _Value = value;
                }
            }

            private string _Caption;
            public string Caption
            {
                get
                {
                    return _Caption;
                }
                set
                {
                    _Caption = value;
                }
            }

            public override string ToString()
            {
                return this.Caption;// ?? base.ToString();
            }

            private static CustomItem _DefaultInstance;
            public static CustomItem DefaultInstance
            {
                get
                {
                    if (_DefaultInstance == null)
                        _DefaultInstance = new CustomItem(-1, editItemsText);
                    return _DefaultInstance;
                }
            }
        }

        const string editItemsText = "...";
        private string _EditItemsText = editItemsText;
        [DefaultValue(editItemsText)]
        [Category("Njit")]
        public string EditItemsText
        {
            get
            {
                return _EditItemsText;
            }
            set
            {
                _EditItemsText = value;
                CustomItem.DefaultInstance.Caption = value;
            }
        }

        private bool _EditItemsEnabled = false;
        [DefaultValue(false)]
        [Category("Njit")]
        public bool EditItemsEnabled
        {
            get
            {
                return _EditItemsEnabled;
            }
            set
            {
                _EditItemsEnabled = value;
            }
        }

        private Form _EditItemsForm = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public Form EditItemsForm
        {
            get
            {
                return _EditItemsForm;
            }
            set
            {
                _EditItemsForm = value;
            }
        }

        private string _Filter = null;
        [DefaultValue(null)]
        public string Filter
        {
            get
            {
                return _Filter;
            }
            set
            {
                _Filter = value;
            }
        }

        protected override void OnDropDown(EventArgs e)
        {
            CheckCustomItemDefaultInstance();
            base.OnDropDown(e);
        }

        private void CheckCustomItemDefaultInstance()
        {
            if (this.EditItemsEnabled)
            {
                if (this.Items.Contains(CustomItem.DefaultInstance))
                {
                    int index = this.Items.IndexOf(CustomItem.DefaultInstance);
                    if (index != this.Items.Count - 1)
                    {
                        this.Items.Remove(CustomItem.DefaultInstance);
                        this.Items.Add(CustomItem.DefaultInstance);
                    }
                }
                else
                {
                    this.Items.Add(CustomItem.DefaultInstance);
                }
            }
            else
            {
                if (this.Items.Contains(CustomItem.DefaultInstance))
                    this.Items.Remove(CustomItem.DefaultInstance);
            }
        }

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            base.OnSelectionChangeCommitted(e);
            if (this.SelectedItem == CustomItem.DefaultInstance)
            {
                if (this.DroppedDown)
                    ShowEditItemsForm();
                CheckCustomItemDefaultInstance();
                SelectDefualtItem();
            }
        }

        public event EventHandler<DataAccessRequestEventArgs> DataAccessRequest;
        protected virtual void OnDataAccessRequest(DataAccessRequestEventArgs e)
        {
            if (DataAccessRequest != null)
                DataAccessRequest(this, e);
        }

        public class DataAccessRequestEventArgs : EventArgs
        {
            private Njit.Sql.IDataAccess _DataAccess = null;
            public Njit.Sql.IDataAccess DataAccess
            {
                set
                {
                    _DataAccess = value;
                }
                get
                {
                    return _DataAccess;
                }
            }
        }

        private Njit.Sql.IDataAccess _DataAccess = null;
        [DefaultValue(null)]
        [Browsable(false)]
        [Category("Njit")]
        public Njit.Sql.IDataAccess DataAccess
        {
            get
            {
                DataAccessRequestEventArgs e = new DataAccessRequestEventArgs();
                OnDataAccessRequest(e);
                if (e.DataAccess != null)
                    return e.DataAccess;
                return _DataAccess;
            }
            set
            {
                _DataAccess = value;
            }
        }

        bool RefreshDataInvoked = false;
        public void RefreshData()
        {
            if (this.DesignMode)
                return;
            if (this.EditItemsEnabled && !string.IsNullOrEmpty(this.TableName) && !(string.IsNullOrEmpty(this.KeyField) && string.IsNullOrEmpty(this.CaptionField)))
            {
                RefreshDataInvoked = true;
                this.SuspendLayout();
                if (this.DataSource != null)
                {
                    this.DataSource = null;
                    //this.DisplayMember = "Caption";
                    //this.ValueMember = "Value";
                }
                if (string.IsNullOrEmpty(this.KeyField))
                    this.KeyField = this.CaptionField;
                if (string.IsNullOrEmpty(this.CaptionField))
                    this.CaptionField = this.KeyField;
                DataTable dt = (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).GetData(string.Format("SELECT * FROM [{0}]{1}", this.TableName, this.Filter.IsNullOrEmpty() ? "" : (" WHERE " + this.Filter)));
                //List<Njit.Program.Controls.ComboBoxExtended.CustomItem> list = new List<Controls.ComboBoxExtended.CustomItem>();
                this.Items.Clear();
                if (this.FirstItem != null)
                    this.Items.Add(FirstItem);
                foreach (DataRow row in dt.Rows)
                {
                    this.Items.Add(new Njit.Program.Controls.ComboBoxExtended.CustomItem(row[this.KeyField], row[this.CaptionField].ToString()));
                }
                SelectDefualtItem();
                //customItemBindingSource.DataSource = list;
                this.ResumeLayout(false);
            }
        }

        private void SelectDefualtItem()
        {
            if (this.IsDefaultField != null)
            {
                int? defaultId = GetDefaultItemID();
                if (defaultId.HasValue)
                    this.SelectedItem = this.Items.Cast<CustomItem>().Where(t => (t.Value as int?) == defaultId).Single();
            }
        }

        private int? GetDefaultItemID()
        {
            DataTable dt = (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).GetData(string.Format("SELECT * FROM [{0}]", this.TableName));
            foreach (DataRow row in dt.Rows)
            {
                if (!row[this.IsDefaultField].IsNullOrEmpty() && ((bool)row[this.IsDefaultField]) == true)
                    return (int)row[this.KeyField];
            }
            return null;
        }

        private CustomItem _FirstItem = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public CustomItem FirstItem
        {
            get
            {
                return _FirstItem;
            }
            set
            {
                _FirstItem = value;
            }
        }

        private string _TableName = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

        private string _KeyField = "Code";
        [DefaultValue("Code")]
        [Category("Njit")]
        public string KeyField
        {
            get
            {
                return _KeyField;
            }
            set
            {
                _KeyField = value;
            }
        }

        private string _CaptionField = "Name";
        [DefaultValue("Name")]
        [Category("Njit")]
        public string CaptionField
        {
            get
            {
                return _CaptionField;
            }
            set
            {
                _CaptionField = value;
            }
        }

        private string _IsDefaultField = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public string IsDefaultField
        {
            get
            {
                return _IsDefaultField;
            }
            set
            {
                _IsDefaultField = value;
            }
        }

        public event EventHandler EditItemsFormClosedAndDataRefreshed;
        protected virtual void OnEditItemsFormClosedAndDataRefreshed()
        {
            if (EditItemsFormClosedAndDataRefreshed != null)
                EditItemsFormClosedAndDataRefreshed(this, EventArgs.Empty);
        }

        public void ShowEditItemsForm()
        {
            if (this.AllowCheckAccessPermission && !this.DesignMode)
            {
                if (Njit.Program.Options.SettingInitializer != null)
                {
                    if (!Njit.Program.Options.SettingInitializer.GetUserSetting().CheckUserAccessPermission(this))
                    {
                        PersianMessageBox.Show(this.SecurityErrorMessage);
                        return;
                    }
                }
            }
            if (this.EditItemsForm != null)
            {
                this.EditItemsForm.ShowDialog();
                this.RefreshData();
                OnEditItemsFormClosedAndDataRefreshed();
            }
            else
            {
                using (Forms.ComboBoxEditItems form = new Forms.ComboBoxEditItems(this.DataAccess, this.TableName, this.KeyField, this.CaptionField, this.IsDefaultField))
                {
                    form.ShowDialog();
                    this.RefreshData();
                    OnEditItemsFormClosedAndDataRefreshed();
                }
            }
        }

        const string _ConstSecurityErrorMessage = "مجوز دسترسی به این قسمت برای شما صادر نشده است";
        private string _SecurityErrorMessage = _ConstSecurityErrorMessage;
        [DefaultValue(_ConstSecurityErrorMessage)]
        protected virtual string SecurityErrorMessage
        {
            get
            {
                return _SecurityErrorMessage;
            }
            set
            {
                _SecurityErrorMessage = value;
            }
        }

        private bool _AllowCheckAccessPermission = true;
        [DefaultValue(true)]
        public bool AllowCheckAccessPermission
        {
            get
            {
                if (this.DesignMode)
                    return _AllowCheckAccessPermission;
                else
                {
                    Control parent = this.Parent;
                    while (parent != null)
                    {
                        if (parent is Njit.Common.IAccessPermission)
                            if ((parent as Njit.Common.IAccessPermission).AllowCheckAccessPermission == false)
                                return false;
                        parent = parent.Parent;
                    }
                    return _AllowCheckAccessPermission;
                }
            }
            set
            {
                _AllowCheckAccessPermission = value;
            }
        }

        private InputBoxValidationHelper.InputTypes _InputType = InputBoxValidationHelper.InputTypes.AllCharacters;
        [DefaultValue(typeof(InputBoxValidationHelper.InputTypes), "AllCharacters")]
        [Category("Njit")]
        public InputBoxValidationHelper.InputTypes InputType
        {
            get
            {
                return _InputType;
            }
            set
            {
                _InputType = value;
            }
        }

        private int _MaxLength = 32767;
        [DefaultValue(32767)]
        [Category("Njit")]
        public new int MaxLength
        {
            get
            {
                return _MaxLength;
            }
            set
            {
                _MaxLength = value;
            }
        }

        private int _MinLength;
        [DefaultValue(0)]
        [Category("Njit")]
        public int MinLength
        {
            get
            {
                return _MinLength;
            }
            set
            {
                _MinLength = value;
            }
        }

        private double? _MinValue = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public double? MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                _MinValue = value;
            }
        }

        private double? _MaxValue = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public double? MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                _MaxValue = value;
            }
        }

        protected override void OnTextUpdate(EventArgs e)
        {
            base.OnTextUpdate(e);
            this.EditingControlValueChanged = true;
            if (this.dataGridView != null)
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            errorProvider.Clear();
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            this.EditingControlValueChanged = true;
            if (this.dataGridView != null)
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            this.CheckValidation(e);
            base.OnValidating(e);
        }

        public void CheckValidation(CancelEventArgs e)
        {
            string errorText;
            if (!InputBoxValidationHelper.CheckValidation(this, out errorText))
            {
                this.SetError(errorText);
                e.Cancel = true;
            }
        }

        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        [DefaultValue("")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value.ToString();
            }
        }

        [DefaultValue(0)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Enter:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (selectAll)
                this.SelectAll();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        public void SetText(string value)
        {
            base.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public object Value { get; set; }

        public string GetPath()
        {
            string name = this.Name;
            System.Windows.Forms.Control parent = this.Parent;
            while (parent != null)
            {
                name += " " + parent.Name;
                parent = parent.Parent;
            }
            return name;
        }

        public enum InputLanguages
        {
            None,
            Persian,
            English
        }


        private InputLanguages _InputLanguage = InputLanguages.None;
        [DefaultValue(typeof(InputLanguages), "None")]
        [Category("Njit")]
        [Description("زبان")]
        public InputLanguages InputLanguage
        {
            get
            {
                return _InputLanguage;
            }
            set
            {
                _InputLanguage = value;
            }
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            this.errorProvider.RightToLeft = (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes);
        }

        public void SetError(string errorText, bool showErrorIcon)
        {
            toolTip.Show(errorText, this, 0, -21, 5000);
            if (showErrorIcon)
                errorProvider.SetError(this, errorText);
        }

        public void ClearError()
        {
            errorProvider.Clear();
            toolTip.Hide(this);
        }

        public void FocusAndSetError(string errorText)
        {
            this.Focus();
            this.SetError(errorText, true);
        }
    }
}
