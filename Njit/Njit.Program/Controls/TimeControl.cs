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
    /// دریافت ساعت
    /// </summary>
    [ToolboxBitmap(typeof(MaskedTextBox))]
    [Description("دریافت ساعت")]
    public partial class TimeControl : System.Windows.Forms.TextBox, IDataGridViewEditingControl
    {
        public TimeControl()
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextAlign = HorizontalAlignment.Right;
            toolStripMenuItemCopy.Click += ToolStripMenuItemCopyClick;
            toolStripMenuItemCut.Click += ToolStripMenuItemCutClick;
            toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
            toolStripMenuItemPaste.Click += ToolStripMenuItemPasteClick;
            toolStripMenuItemSelectAll.Click += ToolStripMenuItemSelectAllClick;
            this.Size = new Size(50, 20);
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(50, 20);
            }
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
            this.Text = FreeTime;
            SetCurrentLocation(0);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.Text == "")
                base.Text = this.FreeTime;
        }

        private void ToolStripMenuItemCutClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                Clipboard.SetText(this.Text);
                this.Text = FreeTime;
                SetCurrentLocation(0);
            }
        }

        private void ToolStripMenuItemCopyClick(object sender, EventArgs e)
        {
            Clipboard.SetText(this.Text);
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        [DefaultValue(typeof(System.Windows.Forms.RightToLeft), "No")]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }
        }

        [DefaultValue(typeof(System.Windows.Forms.HorizontalAlignment), "Right")]
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

        /// <summary>
        /// ساعت
        /// </summary>
        [Description("ساعت")]
        [Category("Njit")]
        public override string Text
        {
            get
            {
                if (base.Text == this.FreeTime)
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
            //valueChanged = true;
            //if (this.dataGridView != null)
            //{
            //    if (string.IsNullOrEmpty(oldText) && !string.IsNullOrEmpty(this.Text))
            //        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            //    oldText = this.Text;
            //}
            HideCaret(this.Handle);
            //if (this.Focused && this.Visible && this.Text.Length == 10)
            //{
            //    if (Njit.Common.PersianCalendar.TimeIsCorrect(this.Text, ':'))
            //    {
            //        TimeTime datetime = Njit.Common.PersianCalendar.ToTimeTime(this.Text);
            //        ShowTooltip(Njit.Common.PersianCalendar.GetDayOfWeekName(datetime) + " " + Njit.Common.PersianCalendar.GetTimeWithMonthName(datetime, " "));
            //    }
            //    else
            //    {
            //        this.toolTip.Hide(this);
            //    }
            //}
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta != 0)
            {
                if (Njit.Common.PersianCalendar.TimeIsCorrect(this.Text, ':'))
                {
                    this.Text = Njit.Common.PersianCalendar.AddMinutesToTime(this.Hour, this.Minute, e.Delta > 0 ? 1 : -1);
                    SetCurrentLocation(currentLocation);
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (KeyIsDigit(e.KeyCode) && this.SelectionLength == 0)
                e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Left)
            {
                GoPrevTimeLocation();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                GoNextTimeLocation();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (Njit.Common.PersianCalendar.TimeIsCorrect(this.Text, ':'))
                {
                    this.Text = Njit.Common.PersianCalendar.AddMinutesToTime(this.Hour, this.Minute, 1);
                    SetCurrentLocation(currentLocation);
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Njit.Common.PersianCalendar.TimeIsCorrect(this.Text, ':'))
                {
                    this.Text = Njit.Common.PersianCalendar.AddMinutesToTime(this.Hour, this.Minute, -1);
                    SetCurrentLocation(currentLocation);
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (PutChar("-"))
                    GoPrevTimeLocation();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (PutChar("-"))
                    GoNextTimeLocation();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Home)
            {
                SetCurrentLocation(0);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.End)
            {
                SetCurrentLocation(0);
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
                if (clipboardText.Length == 5 && Njit.Common.PersianCalendar.TimeIsCorrect(clipboardText, ':'))
                {
                    this.Text = clipboardText;
                    SetCurrentLocation(0);
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
            if (this.Text.Length == 5 && this.Text[4] == '-' && char.IsDigit(this.Text[3]))
            {
                this.Text = this.Text.Substring(0, 3) + "0" + this.Text[3].ToString();
                SetCurrentLocation(4);
                onEnterSetCurrentLocation3 = false;
                e.Cancel = true;
            }
            else if (this.Text.Length == 5 && this.Text[1] == '-' && char.IsDigit(this.Text[0]))
            {
                this.Text = "0" + this.Text[0].ToString() + this.Text.Substring(2, 3);
                SetCurrentLocation(1);
                onEnterSetCurrentLocation3 = false;
                e.Cancel = true;
            }
            else
            {
                if (!this.TimeIsCorrect && !this.TimeIsFree)
                {
                    this.SetError("ساعت صحیح وارد نشده است");
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
                    this.Text = "--:" + ch + "-";
                    if (ch == "-")
                        SetCurrentLocation(0);
                    else
                        SetCurrentLocation(4);
                    return false;
                }
                else if (this.SelectionLength == 2 && this.SelectionStart == 0)
                {
                    this.SelectedText = ch + "-";
                    SetCurrentLocation(1);
                    return false;
                }
                else if (this.SelectionLength == 2 && this.SelectionStart == 3)
                {
                    this.SelectedText = ch + "-";
                    SetCurrentLocation(4);
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

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //this.toolTip.Hide(this);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                SetError(e, "ساعت را به صورت صحیح وارد کنید");
            else if (char.IsDigit(e.KeyChar))
            {
                switch (this.currentLocation)
                {
                    case 3:
                        if (!(e.KeyChar >= '0' && e.KeyChar <= '5'))
                            SetError(e, "دقیقه را به صورت صحیح وارد کنید");
                        break;
                    case 1:
                        if (this.Text[0] == '2')
                            if (!(e.KeyChar >= '0' && e.KeyChar <= '3'))
                                SetError(e, "ساعت را به صورت صحیح وارد کنید");
                        break;
                    case 0:
                        if (!(e.KeyChar >= '0' && e.KeyChar <= '2'))
                            SetError(e, "ساعت را به صورت صحیح وارد کنید");
                        break;
                }
                if (e.KeyChar != Convert.ToChar(0))
                {
                    if (PutChar(e.KeyChar.ToString()))
                        GoNextTimeLocation();
                    e.Handled = true;
                }
            }
            base.OnKeyPress(e);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (this.SelectionLength == 0)
                if (this.TimeIsFree)
                    SetCurrentLocation(0);
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
                case 3:
                case 4:
                    return selectionStart;
                case 2:
                    return 3;
                default:
                    return 3;
            }
        }

        bool onEnterSetCurrentLocation3 = true;
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            HideCaret(this.Handle);
            //this.toolTip.Hide(this);
            if (base.Text == "")
                this.Text = this.FreeTime;
            if (onEnterSetCurrentLocation3)
                SetCurrentLocation(0);
            else
                onEnterSetCurrentLocation3 = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.toolTip.Hide(this);
        }

        [Browsable(false)]
        public string FreeTime
        {
            get
            {
                return "--:--";
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

        int currentLocation = 3;

        private void SetCurrentLocation(int currentLocation)
        {
            this.currentLocation = currentLocation;
            this.Select(this.currentLocation, 1);
        }

        public bool KeyIsDigit(Keys keys)
        {
            return (keys >= Keys.NumPad0 && keys <= Keys.NumPad9) || (keys >= Keys.D0 && keys <= Keys.D9);
        }

        private bool GoNextTimeLocation()
        {
            switch (this.currentLocation)
            {
                case 0:
                    SetCurrentLocation(1);
                    return true;
                case 1:
                    SetCurrentLocation(3);
                    return true;
                case 3:
                    SetCurrentLocation(4);
                    return true;
                default:
                    return false;
            }
        }

        private bool GoPrevTimeLocation()
        {
            switch (this.currentLocation)
            {
                case 4:
                    SetCurrentLocation(3);
                    return true;
                case 3:
                    SetCurrentLocation(1);
                    return true;
                case 1:
                    SetCurrentLocation(0);
                    return true;
                default:
                    return false;
            }
        }

        [Description("ساعت صحیح است یا خیر")]
        public bool TimeIsCorrect
        {
            get
            {
                return Njit.Common.PersianCalendar.TimeIsCorrect(this.Text, ':');
            }
        }

        [Description("ساعت خالی است یا خیر")]
        public bool TimeIsFree
        {
            get
            {
                return this.Text == this.FreeTime || this.Text == "";
            }
        }

        [Description("ساعت بصورت کامل وارد شده است یا خیر")]
        public bool TimeIsFullEntered
        {
            get
            {
                return FullTimeIsEntered(this.Text, ':');
            }
        }

        public bool FullTimeIsEntered(string date, char separator)
        {
            if (string.IsNullOrEmpty(date))
                return false;
            string[] arr = date.Split(separator);
            if (arr.Length != 2)
                return false;
            int h, m;
            try
            {
                h = int.Parse(arr[0]);
                m = int.Parse(arr[1]);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// مقدار دهی ساعت به ساعت فعلی
        /// </summary>
        [Description("مقدار دهی ساعت به ساعت فعلی")]
        public void SetTime()
        {
            SetTime(DateTime.Now);
        }

        /// <summary>
        /// مقدار دهی ساعت
        /// </summary>
        /// <param name="date">ساعت</param>
        [Description("مقدار دهی ساعت")]
        public void SetTime(DateTime date)
        {
            this.Text = Njit.Common.PersianCalendar.GetTime(date);
        }

        [Description("ساعت")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        public int Hour
        {
            get
            {
                if (this.TimeIsCorrect)
                    return int.Parse(this.Text.Substring(0, 2));
                return 0;
            }
            set
            {
                string hour = value.ToString();
                if (hour.Length == 1)
                    hour = "0" + hour;
                if (hour.Length == 2)
                    this.Text = hour + base.Text.Substring(2, 3);
            }
        }

        [Description("دقیقه")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(0)]
        public int Minute
        {
            get
            {
                if (this.TimeIsCorrect)
                    return int.Parse(this.Text.Substring(3, 2));
                return 0;
            }
            set
            {
                string minute = value.ToString();
                if (minute.Length == 1)
                    minute = "0" + minute;
                if (minute.Length == 2)
                    this.Text = base.Text.Substring(0, 3) + minute;
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            string text = Clipboard.GetText();
            toolStripMenuItemPaste.Enabled = Njit.Common.PersianCalendar.TimeIsCorrect(text, ':');
            toolStripMenuItemCopy.Enabled = toolStripMenuItemCut.Enabled = !TimeIsFree;
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
