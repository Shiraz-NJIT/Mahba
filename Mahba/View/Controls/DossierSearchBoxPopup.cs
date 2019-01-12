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
    public partial class DossierSearchBoxPopup : UserControl
    {
        public DossierSearchBoxPopup(Model.Archive.ArchiveField archiveField, bool allowSelectRelation)
        {
            InitializeComponent();
            this.ArchiveField = archiveField;
            comboBoxExtendedAndOr.Visible = allowSelectRelation;
            comboBoxExtendedAndOr.Location = new Point(lblField.Location.X + lblField.Width + 5, comboBoxExtendedAndOr.Location.Y);
            this.Width = comboBoxExtendedAndOr.Location.X + comboBoxExtendedAndOr.Width + 50;
            if (comboBoxExtendedAndOr.Visible == false)
                this.Width -= comboBoxExtendedAndOr.Width;
            contextMenuStripSelect.Enabled = allowSelectRelation;
            searchMethodBindingSource.DataSource = SearchMethod.GetAllSearchMethods();
        }

        public DossierSearchBoxPopup(SearchField searchField)
        {
            InitializeComponent();
            this.ArchiveField = searchField.Field;
            comboBoxExtendedAndOr.Visible = searchField.Relation != SearchField.Relations.None;
            comboBoxExtendedAndOr.Location = new Point(lblField.Location.X + lblField.Width + 5, comboBoxExtendedAndOr.Location.Y);
            this.Width = comboBoxExtendedAndOr.Location.X + comboBoxExtendedAndOr.Width + 50;
            if (comboBoxExtendedAndOr.Visible == false)
                this.Width -= comboBoxExtendedAndOr.Width;
            contextMenuStripSelect.Enabled = false;
            searchMethodBindingSource.DataSource = SearchMethod.GetAllSearchMethods();
            switch (searchField.Relation)
            {
                case SearchField.Relations.None:
                    break;
                case SearchField.Relations.And:
                    comboBoxExtendedAndOr.SelectedIndex = 0;
                    break;
                case SearchField.Relations.Or:
                    comboBoxExtendedAndOr.SelectedIndex = 1;
                    break;
            }
            comboBoxExtendedMethod.SelectedValue = searchField.Method.Code;
            textBoxExtendedValue.Text = searchField.Value;
            btnAdd.Text = "ثبت";
        }

        private Model.Archive.ArchiveField _ArchiveField;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Model.Archive.ArchiveField ArchiveField
        {
            get
            {
                return _ArchiveField;
            }
            set
            {
                _ArchiveField = value;
                lblField.Text = _ArchiveField.Label + ":";
            }
        }

        public class OkEventArgs : EventArgs
        {
            public OkEventArgs(SearchField field, bool createNewFilter)
            {
                this.SearchField = field;
                this.CreateNewFilter = createNewFilter;
            }

            private SearchField _SearchField;
            public SearchField SearchField
            {
                get
                {
                    return _SearchField;
                }
                set
                {
                    _SearchField = value;
                }
            }

            private bool _CreateNewFilter;
            public bool CreateNewFilter
            {
                get
                {
                    return _CreateNewFilter;
                }
                set
                {
                    _CreateNewFilter = value;
                }
            }
        }

        public event EventHandler<OkEventArgs> OK;
        protected void OnOK(OkEventArgs okEventArgs)
        {
            if (OK != null)
                OK(this, okEventArgs);
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            if (this.Parent is ToolStripDropDown)
                ((ToolStripDropDown)this.Parent).Close();
        }

        private void menuAddToCurrent_Click(object sender, EventArgs e)
        {
            if (textBoxExtendedValue.Enabled && textBoxExtendedValue.Text == "")
            {
                textBoxExtendedValue.SetError("هیچ مقداری وارد نشده است", true);
                textBoxExtendedValue.Focus();
                return;
            }
            SearchField.Relations relation = SearchField.Relations.None;
            if (comboBoxExtendedAndOr.Enabled == false || comboBoxExtendedAndOr.Visible == false)
                relation = SearchField.Relations.None;
            else if (comboBoxExtendedAndOr.SelectedIndex == 0)
                relation = SearchField.Relations.And;
            else if (comboBoxExtendedAndOr.SelectedIndex == 1)
                relation = SearchField.Relations.Or;
            SearchField f = new SearchField(this.ArchiveField, (SearchMethod)comboBoxExtendedMethod.SelectedItem, textBoxExtendedValue.Text, relation);
            OnOK(new OkEventArgs(f, false));
            if (this.Parent is ToolStripDropDown)
                ((ToolStripDropDown)this.Parent).Close();
        }

        private void menuMakeNew_Click(object sender, EventArgs e)
        {
            if (textBoxExtendedValue.Enabled && textBoxExtendedValue.Text == "")
            {
                textBoxExtendedValue.SetError("هیچ مقداری وارد نشده است", true);
                textBoxExtendedValue.Focus();
                return;
            }
            SearchField.Relations relation = SearchField.Relations.None;
            if (comboBoxExtendedAndOr.Enabled == false || comboBoxExtendedAndOr.Visible == false)
                relation = SearchField.Relations.None;
            else if (comboBoxExtendedAndOr.SelectedIndex == 0)
                relation = SearchField.Relations.And;
            else if (comboBoxExtendedAndOr.SelectedIndex == 1)
                relation = SearchField.Relations.Or;
            SearchField f = new SearchField(this.ArchiveField, (SearchMethod)comboBoxExtendedMethod.SelectedItem, textBoxExtendedValue.Text, relation);
            OnOK(new OkEventArgs(f, true));
            if (this.Parent is ToolStripDropDown)
                ((ToolStripDropDown)this.Parent).Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (contextMenuStripSelect.Enabled == false)
            {
                if (textBoxExtendedValue.Enabled && textBoxExtendedValue.Text == "")
                {
                    textBoxExtendedValue.Focus();
                    textBoxExtendedValue.SetError("هیچ مقداری وارد نشده است", true);
                    return;
                }
                if (textBoxExtendedValue.Text != "" && ((this.ArchiveField).IsNumber() && !textBoxExtendedValue.Text.IsNumber()))
                {
                    textBoxExtendedValue.Focus();
                    textBoxExtendedValue.SelectAll();
                    textBoxExtendedValue.SetError(string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", this.ArchiveField.Label), true);
                    return;
                }
                SearchField.Relations relation = SearchField.Relations.None;
                if (comboBoxExtendedAndOr.Enabled == false || comboBoxExtendedAndOr.Visible == false)
                    relation = SearchField.Relations.None;
                else if (comboBoxExtendedAndOr.SelectedIndex == 0)
                    relation = SearchField.Relations.And;
                else if (comboBoxExtendedAndOr.SelectedIndex == 1)
                    relation = SearchField.Relations.Or;
                SearchField f = new SearchField(this.ArchiveField, (SearchMethod)comboBoxExtendedMethod.SelectedItem, textBoxExtendedValue.Text, relation);
                OnOK(new OkEventArgs(f, true));
                if (this.Parent is ToolStripDropDown)
                    ((ToolStripDropDown)this.Parent).Close();
            }
        }

        private void comboBoxExtendedMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxExtendedMethod.SelectedIndex >= 0)
            {
                SearchMethod method = comboBoxExtendedMethod.SelectedItem as SearchMethod;
                if (!string.IsNullOrEmpty(method.Explain))
                    textBoxExtendedValue.ShowTooltip(method.Explain);
                else
                    textBoxExtendedValue.HideTooltip();
                textBoxExtendedValue.Enabled = method.RequiredValue;
            }
        }
    }
}
