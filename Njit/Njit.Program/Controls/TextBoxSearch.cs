using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace Njit.Program.Controls
{
    [ToolboxBitmap(typeof(TextBox))]
    [DefaultEvent("SelectedItemChanged")]
    [DefaultBindingProperty("SelectedValue")]
    public partial class TextBoxSearch : Njit.Program.Controls.TextBoxExtended
    {
        public TextBoxSearch()
        {
            InitializeComponent();
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(System.Windows.Forms.AutoCompleteMode), "Append")]
        public new AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return base.AutoCompleteMode;
            }
            set
            {
                base.AutoCompleteMode = value;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(System.Windows.Forms.AutoCompleteSource), "CustomSource")]
        public new AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return base.AutoCompleteSource;
            }
            set
            {
                base.AutoCompleteSource = value;
            }
        }

        private ISearchControl _SearchControl = null;
        [DefaultValue(null)]
        public ISearchControl SearchControl
        {
            get
            {
                return _SearchControl;
            }
            set
            {
                if (_SearchControl != null)
                    _SearchControl.ItemSelected -= SearchControl_ItemSelected;
                if (this.popup != null)
                    this.popup.Dispose();
                _SearchControl = value;
                if (_SearchControl != null)
                {
                    _SearchControl.TextBoxSearch = this;
                    _SearchControl.ItemSelected += SearchControl_ItemSelected;
                    Control c = _SearchControl as Control;
                    if (c != null)
                    {
                        this.popup = new Njit.Common.Popup.Popup(c, false, false, false, false, Njit.Common.Popup.PopupAnimations.Blend, 100, Njit.Common.Popup.PopupAnimations.Blend, 100);
                    }
                }
            }
        }

        private void SearchControl_ItemSelected(object sender, Njit.Common.ItemSelectedEventArgs e)
        {
            this.SelectedItem = e.SelectedItem;
        }

        private object _SelectedItem = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public object SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                if (value != _SelectedItem)
                {
                    if (this.DisplayMember == null)
                        throw new Exception("DisplayMember مقدار دهی نشده است");
                    _SelectedItem = value;

                    bool flag = this.SearchEnabled;
                    this.SearchEnabled = false;
                    if (value != null && this.DisplayMember != null)
                    {
                        object displayvalue = GetProperyValue(value, this.DisplayMember);
                        if (displayvalue != null)
                            this.Text = displayvalue.ToString();
                        else
                            this.Text = "";
                    }
                    else
                    {
                        if (EmptyTextWhenSelectedItemIsNull)
                            this.Text = "";
                    }
                    this.SearchEnabled = flag;

                    OnSelectedItemChanged(new SelectedItemChangedEventArgs(_SelectedItem));
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public object SelectedValue
        {
            get
            {
                if (this.ValueMember == null)
                    return null;
                if (this.SelectedItem == null)
                    return -1;
                return GetProperyValue(this.SelectedItem, this.ValueMember);
            }
            set
            {
                if (this.ValueMember == null)
                    return;
                this.SelectedItem = this.SearchControl.SearchByValueMember(value);
            }
        }

        private object GetProperyValue(object obj, string name)
        {
            Type type = obj.GetType();
            IEnumerable<System.Reflection.PropertyInfo> properties = type.GetProperties().Where(t => t.Name == name);
            if (properties.Count() == 1)
                return properties.Single().GetValue(obj, null);
            return null;
        }

        public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;
        protected virtual void OnSelectedItemChanged(SelectedItemChangedEventArgs e)
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(this, e);
        }

        public class SelectedItemChangedEventArgs : EventArgs
        {
            public SelectedItemChangedEventArgs(object SelectedItem)
            {
                this.SelectedItem = SelectedItem;
            }
            private object _SelectedItem;
            public object SelectedItem
            {
                get
                {
                    return _SelectedItem;
                }
                set
                {
                    _SelectedItem = value;
                }
            }
        }

        //private string _SelectedItemText;
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[DefaultValue(null)]
        //public string SelectedItemText
        //{
        //    get
        //    {
        //        return _SelectedItemText;
        //    }
        //    set
        //    {
        //        _SelectedItemText = value;
        //        this.SearchEnabled = false;
        //        this.Text = _SelectedItemText;
        //        this.SearchEnabled = true;
        //    }
        //}

        private object _DataSource = null;
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public object DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
                //if (value == null)
                //    this.AutoCompleteCustomSource.Clear();
                //else
                //{
                //    if (value is BindingSource)
                //        ((BindingSource)value).DataSourceChanged += BindingSource_DataSourceChanged;
                //    else
                //        SetCustomeSource(value);
                //}
            }
        }

        //void BindingSource_DataSourceChanged(object sender, EventArgs e)
        //{
        //BindingSource bs = _DataSource as BindingSource;
        //if (bs.DataSource != null)
        //    SetCustomeSource(bs.DataSource);
        //else
        //    this.AutoCompleteCustomSource.Clear();
        //}

        //private void SetCustomeSource(object value)
        //{
        //    this.AutoCompleteCustomSource.Clear();
        //    var listSource = value as System.Collections.IEnumerable;
        //    if (listSource != null)
        //        foreach (var item in listSource)
        //        {
        //            if (ObjectHasProperty(item, this.DisplayMember))
        //            {
        //                object v = GetProperyValue(item, this.DisplayMember);
        //                if (v != null)
        //                    this.AutoCompleteCustomSource.Add(v.ToString());
        //            }
        //            else
        //                this.AutoCompleteCustomSource.Add(item.ToString());
        //        }
        //}

        private bool ObjectHasProperty(object obj, string name)
        {
            Type type = obj.GetType();
            IEnumerable<System.Reflection.PropertyInfo> properties = type.GetProperties().Where(t => t.Name == name);
            if (properties.Count() == 1)
                return true;
            return false;
        }

        private string _DisplayMember = null;
        [DefaultValue(null)]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get
            {
                return _DisplayMember;
            }
            set
            {
                _DisplayMember = value;
            }
        }

        private string _ValueMember = null;
        [DefaultValue(null)]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get
            {
                return _ValueMember;
            }
            set
            {
                _ValueMember = value;
            }
        }

        Njit.Common.Popup.Popup popup;
        private bool _SearchEnabled = true;
        [DefaultValue(true)]
        public bool SearchEnabled
        {
            get
            {
                return _SearchEnabled;
            }
            set
            {
                _SearchEnabled = value;
            }
        }
        bool EmptyTextWhenSelectedItemIsNull = true;

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            ShowSearchControlPresentlyWithAllData();
        }

        private void ShowSearchControlPresentlyWithAllData()
        {
            if (this.SearchControl != null && SearchEnabled)
            {
                if (this.Text == "")
                    this.SearchControl.SearchAll();
                else
                    this.SearchControl.SearchAny(this.Text);
                ShowPopup();
            }
        }

        private void ShowSearchControlPresently()
        {
            if (this.SearchControl != null && SearchEnabled)
            {
                this.SearchControl.SearchAny(this.Text);
                ShowPopup();
            }
        }

        private void ShowSearchControl()
        {
            if (this.SearchControl != null && SearchEnabled)
            {
                int count = this.SearchControl.SearchAny(this.Text);
                if (count > 0)
                    ShowPopup();
                else
                    ClosePopup();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (this.Text != "")
                ShowSearchControl();
            else
                ClosePopup();
        }

        private void ShowPopup()
        {
            if (this.popup != null)
                if (!this.popup.Visible)
                    this.popup.Show(this, new Point(this.Width, this.Height + 3), ToolStripDropDownDirection.BelowLeft);
        }

        private void ClosePopup()
        {
            if (this.popup != null)
                if (this.popup.Visible)
                    this.popup.Close(ToolStripDropDownCloseReason.CloseCalled);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            ClosePopup();
            if (this.SearchControl != null)
            {
                EmptyTextWhenSelectedItemIsNull = false;
                this.SelectedItem = this.SearchControl.Search(this.Text);
                EmptyTextWhenSelectedItemIsNull = true;
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SearchControl.SelectCurrentRow();
            else if (e.KeyCode == Keys.Escape)
            {
                if (this.popup != null && this.popup.Visible)
                {
                    this.popup.Close(ToolStripDropDownCloseReason.CloseCalled);
                    dontCloseWithEscape = true;
                }
            }
            base.OnPreviewKeyDown(e);
        }

        bool dontCloseWithEscape = false;

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (!dontCloseWithEscape)
                    return base.ProcessDialogKey(keyData);
                else
                {
                    OnKeyDown(new KeyEventArgs(keyData));
                    dontCloseWithEscape = false;
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
            //else if (keyData == Keys.Tab | ModifierKeys == Keys.Shift | ModifierKeys == Keys.Alt | ModifierKeys == Keys.Control | keyData == Keys.Enter)
            //    return base.ProcessDialogKey(keyData);
            //else
            //{
            //    OnKeyDown(new KeyEventArgs(keyData));
            //    return true;
            //}
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.SearchControl != null)
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (this.popup.Visible)
                        this.SearchControl.GoNextRow();
                    else
                        ShowPopup();
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (this.popup.Visible)
                        this.SearchControl.GoPrevRow();
                    else
                        ShowPopup();
                    e.SuppressKeyPress = true;
                }
            }
            base.OnKeyDown(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.SearchControl != null)
            {
                if (e.Delta > 0)
                    this.SearchControl.GoPrevRow();
                else if (e.Delta < 0)
                    this.SearchControl.GoNextRow();
            }
        }
    }
}
