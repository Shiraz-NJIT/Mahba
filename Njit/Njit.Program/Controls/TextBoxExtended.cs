using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Njit.Program.Controls
{
    [ToolboxBitmap(typeof(TextBox))]
    public partial class TextBoxExtended : System.Windows.Forms.TextBox, IDataGridViewEditingControl, IInputBox, Njit.Common.ICustomizedControl
    {
        public TextBoxExtended()
        {
            InitializeComponent();
            toolStripMenuItemCopy.Click += ToolStripMenuItemCopyClick;
            toolStripMenuItemCut.Click += ToolStripMenuItemCutClick;
            toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
            toolStripMenuItemPaste.Click += ToolStripMenuItemPasteClick;
            toolStripMenuItemSelectAll.Click += ToolStripMenuItemSelectAllClick;
            toolStripMenuItemUndo.Click += ToolStripMenuItemUndoClick;
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

        [DefaultValue(32767)]
        [Category("Njit")]
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
                base.MaxLength = value;
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

        private bool waterMarkTextEnabled = false;

        private Color _WaterMarkColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray")]
        [Category("Njit")]
        public Color WaterMarkColor
        {
            get
            {
                return _WaterMarkColor;
            }
            set
            {
                _WaterMarkColor = value;
                Invalidate();
            }
        }

        private string _WaterMark = null;
        [DefaultValue(null)]
        [Category("Njit")]
        public string WaterMark
        {
            get
            {
                return _WaterMark;
            }
            set
            {
                _WaterMark = value;
                Invalidate();
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            WaterMarkToggel();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.WaterMark != null)
            {
                SolidBrush drawBrush = new SolidBrush(WaterMarkColor);
                StringFormat sf = new StringFormat();
                if (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                    sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                e.Graphics.DrawString((waterMarkTextEnabled ? _WaterMark : this.Text), this.Font, drawBrush, this.ClientRectangle, sf);
                sf.Dispose();
                drawBrush.Dispose();
            }
            base.OnPaint(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            WaterMarkToggel();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.EditingControlValueChanged = true;
            if (this.dataGridView != null)
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            WaterMarkToggel();
            errorProvider.Clear();
        }

        private void WaterMarkToggel()
        {
            if (this.Text.Length <= 0 && this.WaterMark != null)
                EnableWaterMark();
            else
                DisbaleWaterMark();
        }

        private void EnableWaterMark()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.waterMarkTextEnabled = true;
            Refresh();
        }

        private void DisbaleWaterMark()
        {
            this.waterMarkTextEnabled = false;
            this.SetStyle(ControlStyles.UserPaint, false);
        }

        private void ToolStripMenuItemUndoClick(object sender, EventArgs e)
        {
            this.Undo();
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
            this.Text = this.Text.Remove(this.SelectionStart, this.SelectionLength);
        }

        private void ToolStripMenuItemCutClick(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void ToolStripMenuItemCopyClick(object sender, EventArgs e)
        {
            this.Copy();
        }

        /// <summary>
        /// Replaces the current selection in the text box with the contents of the Clipboard.
        /// </summary>
        public new void Paste()
        {
            if (!this.ReadOnly && this.Enabled && Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                int t;
                string text = GetNewText(clipboardText ?? "", out t);
                this.Text = FormatInputText(text);
                this.Select(t, 0);
            }
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

        Color? lastForeColor = null;
        Color? lastBackColor = null;
        Font lastFont = null;

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.Enabled && !this.ReadOnly)
            {
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

        public void CheckValidation(CancelEventArgs e)
        {
            string errorText;
            if (!InputBoxValidationHelper.CheckValidation(this, out errorText))
            {
                this.SetError(errorText, true);
                e.Cancel = true;
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            CheckValidation(e);
            base.OnValidating(e);
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            this.errorProvider.RightToLeft = (this.RightToLeft == System.Windows.Forms.RightToLeft.Yes);
        }

        /// <summary>
        /// Gets or sets the current text in the TextBox.
        /// </summary>
        [Category("Njit")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = FormatInputText(value);
            }
        }

        private string FormatInputText(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            if (this.ReplaceArabicCharsWithPersianChars)
                value = Njit.Common.PublicMethods.FixArabicChars(value);
            value = InputBoxValidationHelper.FormatTextValueWithInputType(this, value);
            if (this.AutoSeparateDigits)
                value = Njit.Common.Helpers.NumbersHelper.InsertComma(value);
            return value;
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

        public void HideTooltip()
        {
            toolTip.Hide(this);
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
                SetError(errorText, false);
            }
            base.OnKeyPress(e);
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

        public void SetError(string errorText, bool showErrorIcon)
        {
            toolTip.Show(errorText, this, 0, -21, 5000);
            if (showErrorIcon)
                errorProvider.SetError(this, errorText);
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
        public int? IntValue
        {
            get
            {
                int t;
                if (int.TryParse(this.TextWithoutComma, out t))
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
                if (long.TryParse(this.TextWithoutComma, out t))
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
                if (short.TryParse(this.TextWithoutComma, out t))
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
                if (float.TryParse(this.TextWithoutComma, out t))
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
                if (double.TryParse(this.TextWithoutComma, out t))
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
                if (decimal.TryParse(this.TextWithoutComma, out t))
                    return t;
                return null;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                this.Paste();
                e.SuppressKeyPress = true;
            }
            //else if (e.KeyCode == Keys.ShiftKey)
            //{
            //    this.EditingControlValueChanged = true;
            //    if (this.dataGridView != null)
            //        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            //}
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (this.AutoSeparateDigits && (InputBoxValidationHelper.KeyIsDigit(e.KeyCode) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
            {
                try
                {
                    int selectionStart = this.SelectionStart;
                    int commaCount1 = this.Text.Substring(0, selectionStart).Where(t => t == CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0]).Count();
                    base.Text = Njit.Common.Helpers.NumbersHelper.InsertComma(this.Text);
                    int commaCount2 = this.Text.Substring(0, selectionStart > this.Text.Length ? this.Text.Length : selectionStart).Where(t => t == CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0]).Count();
                    if (commaCount2 > commaCount1)
                        selectionStart++;
                    else if (commaCount2 < commaCount1)
                        selectionStart--;
                    this.SelectionStart = selectionStart;
                }
                catch { }
            }
            InputBoxValidationHelper.FormatTextValueAfterKeyUp(this, e.KeyCode);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemUndo.Enabled = this.CanUndo;
            toolStripMenuItemDelete.Enabled = toolStripMenuItemCopy.Enabled = toolStripMenuItemCut.Enabled = this.SelectionLength > 0;
            toolStripMenuItemPaste.Enabled = Clipboard.ContainsText() && this.Enabled && !this.ReadOnly;
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

        private object _Value;
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        //public string GetNewValue(string connectionString, string table, string field, string defaultValue)
        //{
        //    if (Options.SettingInitializer == null)
        //        return "";
        //    Njit.Sql.DataAccess da = new Sql.DataAccess(connectionString);
        //    object obj = da.ExecuteScalar(string.Format("SELECT MAX([{0}]) FROM [{1}]", field, table));
        //    if (obj.IsNullOrEmpty())
        //        return (defaultValue.IsNullOrEmpty() ? "1" : defaultValue);
        //    else
        //        return (long.Parse(obj.ToString()) + 1).ToString();
        //}

        public void SetText(string value)
        {
            base.Text = value;
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
