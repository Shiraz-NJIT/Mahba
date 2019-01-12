using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Njit.Program.Controls
{
    /// <summary>
    /// دریافت تاریخ شمسی
    /// </summary>
    [ToolboxBitmap(typeof(MaskedTextBox))]
    [Description("دریافت تاریخ شمسی")]
    public partial class DateControl : System.Windows.Forms.TextBox, IDataGridViewEditingControl
    {
        public DateControl()
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextAlign = HorizontalAlignment.Right;
            toolStripMenuItemCopy.Click += ToolStripMenuItemCopyClick;
            toolStripMenuItemCut.Click += ToolStripMenuItemCutClick;
            toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
            toolStripMenuItemPaste.Click += ToolStripMenuItemPasteClick;
            toolStripMenuItemSelectAll.Click += ToolStripMenuItemSelectAllClick;
            toolStripMenuItemToday.Click += toolStripMenuItemToday_Click;
        }

        private void toolStripMenuItemToday_Click(object sender, EventArgs e)
        {
            this.SetDate();
            this.SetCurrentLocation(8);
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
            this.Text = FreeDate;
            SetCurrentLocation(8);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.Text == "")
                base.Text = this.FreeDate;
        }

        private void ToolStripMenuItemCutClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                Clipboard.SetText(this.Text);
                this.Text = FreeDate;
                SetCurrentLocation(8);
            }
        }

        private void ToolStripMenuItemCopyClick(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Text);
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        [DefaultValue(typeof(System.Windows.Forms.RightToLeft), "No")]
        [Category("Njit")]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [DefaultValue(typeof(System.Windows.Forms.HorizontalAlignment), "Right")]
        [Category("Njit")]
        public new HorizontalAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
            set
            {
                base.TextAlign = value;
            }
        }

        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Category("Njit")]
        public new bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }

        private char _PromptChar = '-';
        [DefaultValue('-')]
        [Category("Njit")]
        public char PromptChar
        {
            get
            {
                return _PromptChar;
            }
            set
            {
                char oldValue = _PromptChar;
                _PromptChar = value;
                base.Text = base.Text.Replace(oldValue, value);
            }
        }

        /// <summary>
        /// تاریخ
        /// </summary>
        [Description("تاریخ")]
        [Category("Njit")]
        public override string Text
        {
            get
            {
                if (base.Text == this.FreeDate)
                    return "";
                return base.Text;
            }
            set
            {
                string oldValue = base.Text;
                base.Text = value;
                if (value != oldValue && !(oldValue.IsNullOrEmpty() && value.IsNullOrEmpty()))
                {
                    this.EditingControlValueChanged = true;
                    if (this.dataGridView != null)
                        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (this.Focused && this.Visible && this.Text.Length == 10)
            {
                if (Njit.Common.PersianCalendar.DateIsCorrect(this.Text, '/'))
                {
                    DateTime datetime = Njit.Common.PersianCalendar.ToDateTime(this.Text);
                    ShowTooltip(Njit.Common.PersianCalendar.GetDayOfWeekName(datetime) + " " + Njit.Common.PersianCalendar.GetDateWithMonthName(datetime, " "));
                }
                else
                {
                    this.toolTip.Hide(this);
                }
            }
            HideCaret(this.Handle);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta != 0)
            {
                if (Njit.Common.PersianCalendar.DateIsCorrect(this.Text, '/'))
                {
                    this.Text = Njit.Common.PersianCalendar.AddDays(this.Text, e.Delta > 0 ? 1 : -1);
                    SetCurrentLocation(currentLocation);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (KeyIsDigit(e.KeyCode) && this.SelectionLength == 0)
                e.SuppressKeyPress = true;

            /*else*/
            if (e.KeyCode == Keys.Left)
            {
                GoPrevDateLocation();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                GoNextDateLocation(false);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (Njit.Common.PersianCalendar.DateIsCorrect(this.Text, '/'))
                {
                    this.Text = Njit.Common.PersianCalendar.AddDays(this.Text, 1);
                    SetCurrentLocation(currentLocation);
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Njit.Common.PersianCalendar.DateIsCorrect(this.Text, '/'))
                {
                    this.Text = Njit.Common.PersianCalendar.AddDays(this.Text, -1);
                    SetCurrentLocation(currentLocation);
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (PutChar(this.PromptChar.ToString()))
                    GoPrevDateLocation();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (PutChar(this.PromptChar.ToString()))
                    GoNextDateLocation(false);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Home)
            {
                SetCurrentLocation(8);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.End)
            {
                SetCurrentLocation(3);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                this.Paste();
                e.SuppressKeyPress = true;
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Replaces the current selection in the text box with the contents of the Clipboard.
        /// </summary>
        public new void Paste()
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                if (clipboardText.Length == 10 && Njit.Common.PersianCalendar.DateIsCorrect(clipboardText, '/'))
                {
                    this.Text = clipboardText;
                    SetCurrentLocation(8);
                }
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            CheckValidation(e);
            base.OnValidating(e);
        }

        public void CheckValidation(CancelEventArgs e)
        {
            if (this.Text.Length == 10 && this.Text.Substring(2, 2) == (this.PromptChar.ToString() + this.PromptChar.ToString()) && this.Text.Where(t => t == this.PromptChar).Count() == 2)
            {
                this.Text = "13" + this.Text.Substring(0, 2) + this.Text.Substring(4, 6);
                SetCurrentLocation(3);
                onEnterSetCurrentLocation8 = false;
                e.Cancel = true;
            }
            else if (this.Text.Length == 10 && this.Text[6] == this.PromptChar && char.IsDigit(this.Text[5]))
            {
                this.Text = this.Text.Substring(0, 5) + "0" + this.Text[5].ToString() + this.Text.Substring(7, 3);
                SetCurrentLocation(0);
                onEnterSetCurrentLocation8 = false;
                e.Cancel = true;
            }
            else if (this.Text.Length == 10 && this.Text[9] == this.PromptChar && char.IsDigit(this.Text[8]))
            {
                this.Text = this.Text.Substring(0, 8) + "0" + this.Text[8].ToString();
                SetCurrentLocation(5);
                onEnterSetCurrentLocation8 = false;
                e.Cancel = true;
            }
            else
            {
                if (!this.DateIsCorrect && !this.DateIsFree)
                {
                    this.SetError("تاریخ صحیح وارد نشده است");
                    e.Cancel = true;
                }
            }
        }

        private string GetNumberString(Keys keys)
        {
            if (keys == Keys.D0 || keys == Keys.NumPad0)
                return ("0");
            else if (keys == Keys.D1 || keys == Keys.NumPad1)
                return ("1");
            else if (keys == Keys.D2 || keys == Keys.NumPad2)
                return ("2");
            else if (keys == Keys.D3 || keys == Keys.NumPad3)
                return ("3");
            else if (keys == Keys.D4 || keys == Keys.NumPad4)
                return ("4");
            else if (keys == Keys.D5 || keys == Keys.NumPad5)
                return ("5");
            else if (keys == Keys.D6 || keys == Keys.NumPad6)
                return ("6");
            else if (keys == Keys.D7 || keys == Keys.NumPad7)
                return ("7");
            else if (keys == Keys.D8 || keys == Keys.NumPad8)
                return ("8");
            else if (keys == Keys.D9 || keys == Keys.NumPad9)
                return ("9");
            else
                throw new Exception();
        }

        private bool PutChar(string ch)
        {
            this.EditingControlValueChanged = true;
            if (this.dataGridView != null)
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            if (this.SelectionLength > 1)
            {
                if (this.SelectionLength == this.Text.Length)
                {
                    this.Text = this.GetPromptChar(4) + "/" + this.GetPromptChar(2) + "/" + ch + this.PromptChar.ToString();
                    if (ch == this.PromptChar.ToString())
                        SetCurrentLocation(8);
                    else
                        SetCurrentLocation(9);
                    return false;
                }
                else if (this.SelectionLength == 4 && this.SelectionStart == 0)
                {
                    this.SelectedText = ch + this.GetPromptChar(3);
                    SetCurrentLocation(1);
                    return false;
                }
                else if (this.SelectionLength == 2 && this.SelectionStart == 5)
                {
                    this.SelectedText = ch + this.PromptChar.ToString();
                    SetCurrentLocation(6);
                    return false;
                }
                else if (this.SelectionLength == 2 && this.SelectionStart == 8)
                {
                    this.SelectedText = ch + this.PromptChar.ToString();
                    SetCurrentLocation(9);
                    return false;
                }
                else
                    return false;
            }
            else
            {
                if (this.SelectionLength == 0)
                    SetCurrentLocation(currentLocation);
                this.SelectedText = ch;
                SetCurrentLocation(currentLocation);
                return true;
            }
        }

        private string GetPromptChar(int p)
        {
            string s = "";
            for (int i = 0; i < p; i++)
                s += this.PromptChar.ToString();
            return s;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //this.toolTip.Hide(this);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                SetError(e, "تاریخ را به صورت صحیح وارد کنید");
            else if (char.IsDigit(e.KeyChar))
            {
                switch (this.currentLocation)
                {
                    case 8:
                        if (!(e.KeyChar >= '0' && e.KeyChar <= '3'))
                            SetError(e, "روز را به صورت صحیح وارد کنید");
                        break;
                    case 9:
                        if (this.Text[8] == '3')
                        {
                            if (!(e.KeyChar >= '0' && e.KeyChar <= '1'))
                                SetError(e, "روز را به صورت صحیح وارد کنید");
                        }
                        else if (this.Text[8] == '0')
                        {
                            if (!(e.KeyChar >= '1' && e.KeyChar <= '9'))
                                SetError(e, "روز را به صورت صحیح وارد کنید");
                        }
                        break;
                    case 5:
                        if (!(e.KeyChar >= '0' && e.KeyChar <= '1'))
                            SetError(e, "ماه را به صورت صحیح وارد کنید");
                        break;
                    case 6:
                        if (this.Text[5] == '0')
                        {
                            if (!(e.KeyChar >= '1' && e.KeyChar <= '9'))
                                SetError(e, "ماه را به صورت صحیح وارد کنید");
                        }
                        else if (!(e.KeyChar >= '0' && e.KeyChar <= '2'))
                            SetError(e, "ماه را به صورت صحیح وارد کنید");
                        break;
                }
                if (e.KeyChar != Convert.ToChar(0))
                {
                    if (PutChar(e.KeyChar.ToString()))
                        GoNextDateLocation(true);
                    e.Handled = true;
                }
            }
            base.OnKeyPress(e);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (this.SelectionLength == 0)
                if (this.DateIsFree)
                    SetCurrentLocation(8);
                else
                    SetCurrentLocation(GetBestLocation(this.SelectionStart));
            HideCaret(this.Handle);
        }

        private int GetBestLocation(int selectionStart)
        {
            switch (selectionStart)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return selectionStart;
                case 4:
                    return 3;
                case 5:
                case 6:
                    return selectionStart;
                case 7:
                    return 6;
                case 8:
                case 9:
                    return selectionStart;
                case 10:
                    return 9;
                default:
                    return 8;
            }
        }

        bool onEnterSetCurrentLocation8 = true;
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            //this.toolTip.Hide(this);
            if (base.Text == "")
                this.Text = this.FreeDate;
            if (onEnterSetCurrentLocation8)
                SetCurrentLocation(8);
            else
                onEnterSetCurrentLocation8 = true;
            HideCaret(this.Handle);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.toolTip.Hide(this);
        }

        [Browsable(false)]
        public string FreeDate
        {
            get
            {
                return this.GetPromptChar(4) + "/" + this.GetPromptChar(2) + "/" + this.GetPromptChar(2);
            }
        }

        private void SetError(string ErrorText)
        {
            toolTip.Show(ErrorText, this, 0, -21, 5000);
        }

        private void SetError(KeyPressEventArgs e, string ErrorText)
        {
            toolTip.Show(ErrorText, this, 0, -21, 5000);
            e.KeyChar = Convert.ToChar(0);
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

        int currentLocation = 8;

        private void SetCurrentLocation(int currentLocation)
        {
            this.currentLocation = currentLocation;
            this.Select(this.currentLocation, 1);
        }

        public bool KeyIsDigit(Keys keys)
        {
            return (keys >= Keys.NumPad0 && keys <= Keys.NumPad9) || (keys >= Keys.D0 && keys <= Keys.D9);
        }

        private bool GoNextDateLocation(bool date)
        {
            if (!date)
            {
                switch (this.currentLocation)
                {
                    case 0:
                        SetCurrentLocation(1);
                        return true;
                    case 1:
                        SetCurrentLocation(2);
                        return true;
                    case 2:
                        SetCurrentLocation(3);
                        return true;
                    case 3:
                        SetCurrentLocation(5);
                        return true;
                    case 5:
                        SetCurrentLocation(6);
                        return true;
                    case 6:
                        SetCurrentLocation(8);
                        return true;
                    case 8:
                        SetCurrentLocation(9);
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                switch (this.currentLocation)
                {
                    case 8:
                        SetCurrentLocation(9);
                        return true;
                    case 9:
                        SetCurrentLocation(5);
                        return true;
                    case 5:
                        SetCurrentLocation(6);
                        return true;
                    case 6:
                        SetCurrentLocation(0);
                        return true;
                    case 0:
                        SetCurrentLocation(1);
                        return true;
                    case 1:
                        SetCurrentLocation(2);
                        return true;
                    case 2:
                        SetCurrentLocation(3);
                        return true;
                    default:
                        return false;
                }
            }
        }

        private bool GoPrevDateLocation()
        {
            switch (this.currentLocation)
            {
                case 9:
                    SetCurrentLocation(8);
                    return true;
                case 8:
                    SetCurrentLocation(6);
                    return true;
                case 6:
                    SetCurrentLocation(5);
                    return true;
                case 5:
                    SetCurrentLocation(3);
                    return true;
                case 3:
                    SetCurrentLocation(2);
                    return true;
                case 2:
                    SetCurrentLocation(1);
                    return true;
                case 1:
                    SetCurrentLocation(0);
                    return true;
                default:
                    return false;
            }
        }

        [Description("تاریخ صحیح است یا خیر")]
        [Category("Njit")]
        public bool DateIsCorrect
        {
            get
            {
                return Njit.Common.PersianCalendar.DateIsCorrect(this.Text, '/');
            }
        }

        [Description("تاریخ خالی است یا خیر")]
        [Category("Njit")]
        public bool DateIsFree
        {
            get
            {
                return this.Text == this.FreeDate || this.Text == "";
            }
        }

        [Description("تاریخ بصورت کامل وارد شده است یا خیر")]
        [Category("Njit")]
        public bool DateIsFullEntered
        {
            get
            {
                return FullDateIsEntered(this.Text, '/');
            }
        }

        public bool FullDateIsEntered(string date, char separator)
        {
            if (string.IsNullOrEmpty(date))
                return false;
            string[] arr = date.Split(separator);
            if (arr.Length != 3)
                return false;
            int y, m, d;
            try
            {
                y = int.Parse(arr[0]);
                m = int.Parse(arr[1]);
                d = int.Parse(arr[2]);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// مقدار دهی تاریخ به تاریخ امروز
        /// </summary>
        [Description("مقدار دهی تاریخ به تاریخ امروز")]
        public void SetDate()
        {
            SetDate(DateTime.Now);
        }

        /// <summary>
        /// مقدار دهی تاریخ
        /// </summary>
        /// <param name="date">تاریخ</param>
        [Description("مقدار دهی تاریخ")]
        public void SetDate(DateTime date)
        {
            this.Text = Njit.Common.PersianCalendar.GetDate(date);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            string text = Clipboard.GetText();
            toolStripMenuItemPaste.Enabled = Njit.Common.PersianCalendar.DateIsCorrect(text, '/');
            toolStripMenuItemCopy.Enabled = toolStripMenuItemCut.Enabled = !DateIsFree;
        }

        public enum CheckDateResult
        {
            Date1, Date2, Both, Free, Error
        }

        public static CheckDateResult CompareDate(string date1, string date2)
        {
            return CompareDate(date1, date2, "-");
        }

        public static CheckDateResult CompareDate(string date1, string date2, string separator)
        {
            if (date1.Replace(separator, "").Replace("/", "").Length == 0 && date2.Replace(separator, "").Replace("/", "").Length == 0)
            {
                return CheckDateResult.Free;
            }
            else if (date1.Replace(separator, "").Length == 10 && date2.Replace(separator, "").Length == 10)
            {
                return CheckDateResult.Both;
            }
            else if (date1.Replace(separator, "").Replace("/", "").Length == 0 && date2.Replace(separator, "").Length == 10)
            {
                return CheckDateResult.Date2;
            }
            else if (date1.Replace(separator, "").Length == 10 && date2.Replace(separator, "").Replace("/", "").Length == 0)
            {
                return CheckDateResult.Date1;
            }
            else
                return CheckDateResult.Error;
        }

        [Description("سال")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        [Category("Njit")]
        public int Year
        {
            get
            {
                if (this.DateIsCorrect)
                    return int.Parse(this.Text.Substring(0, 4));
                return 0;
            }
            set
            {
                string year = value.ToString();
                if (year.Length == 2)
                    year = "13" + year;
                if (year.Length == 4)
                    if (this.Text.Length == 10)
                        this.Text = year + this.Text.Substring(4);
            }
        }

        [Description("ماه")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        [Category("Njit")]
        public int Month
        {
            get
            {
                if (this.DateIsCorrect)
                    return int.Parse(this.Text.Substring(5, 2));
                return 0;
            }
            set
            {
                string month = value.ToString();
                if (month.Length == 1)
                    month = "0" + month;
                if (month.Length == 2)
                {
                    if (this.Text.Length == 10)
                        this.Text = this.Text.Substring(0, 5) + month + this.Text.Substring(7, 3);
                }
            }
        }

        [Description("روز")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        [Category("Njit")]
        public int Day
        {
            get
            {
                if (this.DateIsCorrect)
                    return int.Parse(this.Text.Substring(8, 2));
                return 0;
            }
            set
            {
                string day = value.ToString();
                if (day.Length == 1)
                    day = "0" + day;
                if (day.Length == 2)
                    if (this.Text.Length == 10)
                        this.Text = this.Text.Substring(0, 8) + day;
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
            this.SetCurrentLocation(8);
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public object Value { get; set; }
    }
}
