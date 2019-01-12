using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NjitSoftware.View.Controls
{
    public partial class DossierSearchBox : UserControl
    {
        public DossierSearchBox()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            this.archiveTabBindingSource.DataSource = Controller.Archive.ArchiveTabController.GetActiveDossierTabs();
            searchMethodBindingSource.DataSource = SearchMethod.GetAllSearchMethods();
            this.tabControl1.SelectedTab = tabPage3;
    
        }

        public class SearchRequestEventArgs : EventArgs
        {
            public SearchRequestEventArgs(DataTable data)
            {
                this.Data = data;
            }

            private DataTable _Data;
            public DataTable Data
            {
                get
                {
                    return _Data;
                }
                set
                {
                    _Data = value;
                }
            }
        }

        public event EventHandler<SearchRequestEventArgs> SearchRequest;
        protected virtual void OnSearchRequest(DataTable dataTable)
        {
            if (SearchRequest != null)
                SearchRequest(this, new SearchRequestEventArgs(dataTable));
        }

        private void comboBoxExtendedTab_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxExtendedTab_Simple.SelectedItem == null)
                this.archiveFieldBindingSource.DataSource = null;
            else
            {
                var list = Controller.Archive.ArchiveFieldController.GetArchiveFieldsThahIsNotSubGroup(comboBoxExtendedTab_Simple.SelectedItem as Model.Archive.ArchiveTab);
                if ((comboBoxExtendedTab_Simple.SelectedItem as Model.Archive.ArchiveTab).TypeCode == 1)
                {
                    Model.Archive.ArchiveField personnelNumberField = Model.Archive.ArchiveField.GetNewInstance((comboBoxExtendedTab_Simple.SelectedItem as Model.Archive.ArchiveTab).ID, Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label, "PersonnelNumber", (int)Enums.FieldTypes.متن, (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد, (int)Enums.BoxTypes.کادر_متن, true, null, null, null, null, null, null, 0);
                    personnelNumberField.ArchiveTab = (comboBoxExtendedTab_Simple.SelectedItem as Model.Archive.ArchiveTab);
                    list.Insert(0, personnelNumberField);
                }
                this.archiveFieldBindingSource.DataSource = list;
            }
        }

        private void btnAddOrSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxExtendedField_Simple.SelectedItem == null)
            {
                PersianMessageBox.Show(this, "فیلد به درستی انتخاب نشده است");
                comboBoxExtendedField_Simple.Focus();
                comboBoxExtendedField_Simple.SelectAll();
                comboBoxExtendedField_Simple.SetError("فیلد به درستی انتخاب نشده است");
                return;
            }
            if (textBoxExtendedValue_Simple.Text == "" && ((comboBoxExtendedField_Simple.SelectedItem as Model.Archive.ArchiveField).IsNumber()))
            {
                PersianMessageBox.Show(this, string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Simple.Text));
                textBoxExtendedValue_Simple.SelectAll();
                textBoxExtendedValue_Simple.SetError(string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Simple.Text), true);
                return;
            }
            if (textBoxExtendedValue_Simple.Text != "" && ((comboBoxExtendedField_Simple.SelectedItem as Model.Archive.ArchiveField).IsNumber() && !textBoxExtendedValue_Simple.Text.IsNumber()))
            {
                PersianMessageBox.Show(this, string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Simple.Text));
                textBoxExtendedValue_Simple.SelectAll();
                textBoxExtendedValue_Simple.SetError(string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Simple.Text), true);
                return;
            }
            radGridViewSimple.DataSource = Controller.Archive.DossierController.GetDossierList(Controller.Archive.ArchiveTabController.GetFirstDossierTab(), new SearchField(comboBoxExtendedField_Simple.SelectedItem as Model.Archive.ArchiveField, comboBoxExtendedMethod_Simple.SelectedItem as SearchMethod, textBoxExtendedValue_Simple.Text, SearchField.Relations.None));
            radGridViewSimple.ContextMenuOpening += radGridViewAdvanced_ContextMenuOpening;
            radGridViewSimple.BestFitColumnsSmart();
        }

        private void CheckAndOR()
        {
            if (listBoxSearch.Items.Count > 0)
                comboBoxExtendedAndOr_Advance.Enabled = true;
            else
                comboBoxExtendedAndOr_Advance.Enabled = false;
        }

        private void btnGroupSearch_Click(object sender, EventArgs e)
        {
            Model.Archive.ArchiveTab firstTab = Controller.Archive.ArchiveTabController.GetFirstDossierTab();
            if (firstTab == null)
                PersianMessageBox.Show(this, "هنوز هیچ گروه اطلاعاتی تعریف نشده است");
            else
            {
                SearchField[] searchFields = new SearchField[listBoxSearch.Items.Count];
                for (int i = 0; i < listBoxSearch.Items.Count; i++)
                    searchFields[i] = listBoxSearch.Items[i] as SearchField;
                radGridViewAdvanced.DataSource = Controller.Archive.DossierController.GetDossierList(firstTab, searchFields);
                radGridViewAdvanced.BestFitColumnsSmart();
                radGridViewAdvanced.ContextMenuOpening += radGridViewAdvanced_ContextMenuOpening;
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (listBoxSearch.SelectedItem != null)
            {
                listBoxSearch.Items.RemoveAt(listBoxSearch.SelectedIndex);
                CheckAndOR();
                if (listBoxSearch.Items.Count > 0)
                {
                    if ((listBoxSearch.Items[0] as SearchField).Relation != SearchField.Relations.None)
                    {
                        SearchField f = listBoxSearch.Items[0] as SearchField;
                        f.Relation = SearchField.Relations.None;
                        listBoxSearch.Items[0] = f;
                    }
                }
            }
        }

        private void contextMenuStripSearchField_Opening(object sender, CancelEventArgs e)
        {
            if (listBoxSearch.SelectedItem != null)
                toolStripMenuItemDelete.Enabled = true;
            else
                toolStripMenuItemDelete.Enabled = false;
        }

        private void listBoxSearch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int i = listBoxSearch.IndexFromPoint(e.Location);
                if (i >= 0)
                    listBoxSearch.SelectedIndex = i;
            }
        }

        private void comboBoxExtendedTab_Advance_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxExtendedTab_Advance.SelectedItem == null)
                this.archiveFieldBindingSource.DataSource = null;
            else
            {
                var list = Controller.Archive.ArchiveFieldController.GetArchiveFieldsThahIsNotSubGroup(comboBoxExtendedTab_Advance.SelectedItem as Model.Archive.ArchiveTab);
                if ((comboBoxExtendedTab_Advance.SelectedItem as Model.Archive.ArchiveTab).TypeCode == 1)
                {
                    Model.Archive.ArchiveField personnelNumberField = Model.Archive.ArchiveField.GetNewInstance((comboBoxExtendedTab_Advance.SelectedItem as Model.Archive.ArchiveTab).ID, Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label, "PersonnelNumber", (int)Enums.FieldTypes.متن, (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد, (int)Enums.BoxTypes.کادر_متن, true, null, null, null, null, null, null, 0);
                    personnelNumberField.ArchiveTab = (comboBoxExtendedTab_Advance.SelectedItem as Model.Archive.ArchiveTab);
                    list.Insert(0, personnelNumberField);
                }
                this.archiveFieldBindingSource.DataSource = list;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxExtendedField_Advance.SelectedItem == null)
            {
                PersianMessageBox.Show(this, "فیلد به درستی انتخاب نشده است");
                comboBoxExtendedField_Advance.Focus();
                comboBoxExtendedField_Advance.SelectAll();
                comboBoxExtendedField_Advance.SetError("فیلد به درستی انتخاب نشده است");
                return;
            }
            if (textBoxExtendedValue_Advance.Text == "" && ((comboBoxExtendedField_Advance.SelectedItem as Model.Archive.ArchiveField).IsNumber()))
            {
                PersianMessageBox.Show(this, string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Advance.Text));
                textBoxExtendedValue_Advance.SelectAll();
                textBoxExtendedValue_Advance.SetError(string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Advance.Text), true);
                return;
            }
            if (textBoxExtendedValue_Advance.Text != "" && ((comboBoxExtendedField_Advance.SelectedItem as Model.Archive.ArchiveField).IsNumber() && !textBoxExtendedValue_Advance.Text.IsNumber()))
            {
                PersianMessageBox.Show(this, string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Advance.Text));
                textBoxExtendedValue_Advance.SelectAll();
                textBoxExtendedValue_Advance.SetError(string.Format("برای فیلد '{0}' یک مقدار عددی وارد کنید", comboBoxExtendedField_Advance.Text), true);
                return;
            }
            SearchField.Relations relation = SearchField.Relations.None;
            if (comboBoxExtendedAndOr_Advance.Enabled == false)
                relation = SearchField.Relations.None;
            else if (comboBoxExtendedAndOr_Advance.SelectedIndex == 0)
                relation = SearchField.Relations.And;
            else if (comboBoxExtendedAndOr_Advance.SelectedIndex == 1)
                relation = SearchField.Relations.Or;

            listBoxSearch.Items.Add(new SearchField(comboBoxExtendedField_Advance.SelectedItem as Model.Archive.ArchiveField, comboBoxExtendedMethod_Advance.SelectedItem as SearchMethod, textBoxExtendedValue_Advance.Text, relation));
            CheckAndOR();
            textBoxExtendedValue_Advance.Text = "";
        }

        private void comboBoxExtendedMethod_SelectedValueChanged(object sender, EventArgs e)
        {
            Njit.Program.Controls.ComboBoxExtended c = sender as Njit.Program.Controls.ComboBoxExtended;
            if (c.SelectedItem != null)
            {
                SearchMethod method = c.SelectedItem as SearchMethod;
                textBoxExtendedValue_Advance.Enabled = textBoxExtendedValue_Simple.Enabled = method.RequiredValue;
            }
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            SearchAll();
        }

        public void SearchAll()
        {

            Model.Archive.ArchiveTab firstTab = Controller.Archive.ArchiveTabController.GetFirstDossierTab();
            if (firstTab == null)
                PersianMessageBox.Show(this, "هنوز هیچ گروه اطلاعاتی تعریف نشده است");
            else
            {
                radGridViewAll.DataSource = Controller.Archive.DossierController.GetDossierList(firstTab, null);
                radGridViewAll.ContextMenuOpening += radGridViewAdvanced_ContextMenuOpening;
                radGridViewAll.CellMouseMove += radGridViewExtended1_CellMouseMove;
                //مخفی کردن ستونهایی که نمی خواسته نمایش بده
                for (int i = 0; i < radGridViewAll.ColumnCount; i++)
                {

                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.WindowState == 9 && t.FormName == radGridViewAll.Columns[i].FieldName);
                    if (query.Count() == 1)
                    {
                        radGridViewAll.Columns[i].IsVisible = false;
                    }
                }
                radGridViewAll.BestFitColumnsSmart();
            }
        }
        void menuItem_Click(object sender, EventArgs e)
        {
            View.ArchiveDocumentShow af = new ArchiveDocumentShow(SelectedDossier, 0);
            af.ShowDialog(this);
        }
        void radGridViewAdvanced_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {

            RadDropDownMenu menu = new RadDropDownMenu();
            RadMenuItem menuItem = new RadMenuItem("مشاهده اسناد پرونده");
            menuItem.Click += new EventHandler(menuItem_Click);
            menu.Items.Add(menuItem);
            e.ContextMenu.Items.Add(menuItem);

            for (int i = 0; i < e.ContextMenu.Items.Count; i++)
            {
                if (e.ContextMenu.Items[i].Text == "مخفی کردن ستون")
                {
                    string name = e.ContextMenu.Items[i].Name;
                    e.ContextMenu.Items[i].Click += DossierDocumentsManage2_Click;
                    //// hide the Conditional Formatting option from the header row context menu
                    //e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                    //// hide the separator below the CF option
                    //e.ContextMenu.Items[i + 1].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                }
                if (e.ContextMenu.Items[i].Text == "قالب بندی مشروط")
                {
                    e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                }
                if (e.ContextMenu.Items[i].Text == "گروهبندی بر حسب این ستون")
                {
                    e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                }
                if (e.ContextMenu.Items[i].Text == "انتخابگر ستون")
                {
                    e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                }
                if (e.ContextMenu.Items[i].Text == "حالت ستون")
                {
                    e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                }
                if (e.ContextMenu.Items[i].Text == "اندازه بهینه ستون")
                {
                    e.ContextMenu.Items[i].Text = "بازیابی ستون ها";
                    e.ContextMenu.Items[i].Click += DossierDocumentsManage3_Click;

                }
            }
        }
        string _ColumnName = "";
        //اسم ستونی که انتخاب شده را ذخیره می کند
        void radGridViewExtended1_CellMouseMove(object sender, MouseEventArgs e)
        {
            GridCellElement cell = (GridCellElement)sender;
            if (cell.Value != null)
            {
                _ColumnName = null;
                _ColumnName = cell.ColumnInfo.FieldName;
            }
        }
        //مخفی کردن ستون
        private void DossierDocumentsManage2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_ColumnName);
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _ColumnName);
            if (query.Count() == 1)
            {
                if (query.FirstOrDefault().WindowState == 20)
                {
                    query.FirstOrDefault().WindowState = 9;
                    dc.SubmitChanges();
                }

            }
            else
            {
                //برای مخفی کردن باید Windowsstate=9
                //برای مخفی نکردن باید Windowsstate=20
                Model.Common.FormState state = Model.Common.FormState.GetNewInstance(Environment.MachineName, _ColumnName, 9, 0, 0, 0, 0);
                Model.Common.FormState.Insert(dc, state);
                dc.SubmitChanges();
            }
        }
        //بازیابی ستون
        private void DossierDocumentsManage3_Click(object sender, EventArgs e)
        {
            for (int j = 1; j <= radGridViewAll.ColumnCount; j++)
            {

                //نمایش تمام ستون های جدول
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == radGridViewAll.Columns[j - 1].FieldName);
                if (query.Count() == 1)
                {
                    //برای مخفی کردن باید Windowsstate=9
                    //برای مخفی نکردن باید Windowsstate=20
                    query.FirstOrDefault().WindowState = 20;
                    //منظور از ایگرگ همان ایندکس است
                    query.FirstOrDefault().Y = j;
                    query.FirstOrDefault().X = j;
                    dc.SubmitChanges();
                }
            }
            for (int i = 0; i < radGridViewAll.ColumnCount; i++)
            {
                radGridViewAll.Columns[i].IsVisible = true;
            }


        }

        internal void Search()
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                InvokeOnClick(btnSearch_Simple, EventArgs.Empty);
            }

            else if (tabControl1.SelectedTab == tabPage2)
            {
                InvokeOnClick(btnSearch_Advance, EventArgs.Empty);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            { SearchAll(); }
        }

        public string SelectedDossier
        {
            get
            {
                if (tabControl1.SelectedTab == tabPage1)
                    return GetSelectedDossier(radGridViewSimple);
                else if (tabControl1.SelectedTab == tabPage2)
                    return GetSelectedDossier(radGridViewAdvanced);
                else if (tabControl1.SelectedTab == tabPage3)
                    return GetSelectedDossier(radGridViewAll);
                return null;
            }
        }

        public string[] SelectedDossiers
        {
            get
            {
                if (tabControl1.SelectedTab == tabPage1)
                    return GetSelectedDossiers(radGridViewSimple);
                else if (tabControl1.SelectedTab == tabPage2)
                    return GetSelectedDossiers(radGridViewAdvanced);
                else if (tabControl1.SelectedTab == tabPage3)
                    return GetSelectedDossiers(radGridViewAll);
                return null;
            }
        }

        private string[] GetSelectedDossiers(Njit.Program.Telerik.Controls.RadGridViewExtended radGridView)
        {

            string[] items = new string[radGridView.SelectedRows.Count];
            for (int i = 0; i < radGridView.SelectedRows.Count; i++)
            {
                items[i] = radGridView.SelectedRows[i].Cells[Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label].Value.ToString();
            }
            return items;
        }

        private string GetSelectedDossier(Njit.Program.Telerik.Controls.RadGridViewExtended radGridView)
        {
            if (radGridView.SelectedRows.Count != 1)
                return null;
            return radGridView.SelectedRows[0].Cells[Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label].Value.ToString();
        }

        private EventHandler _DoubleClickAction = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventHandler DoubleClickAction
        {
            get
            {
                return _DoubleClickAction;
            }
            set
            {
                _DoubleClickAction = value;
            }
        }

        private void radGridViews_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (this.DoubleClickAction != null)
                DoubleClickAction(sender, EventArgs.Empty);
        }

        private bool _MultiSelect = true;
        [DefaultValue(true)]
        public bool MultiSelect
        {
            get
            {
                return _MultiSelect;
            }
            set
            {
                _MultiSelect = value;
                radGridViewAdvanced.MultiSelect = radGridViewAll.MultiSelect = radGridViewSimple.MultiSelect = value;
            }
        }

        
        private void textBoxExtendedValue_Advance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.PerformClick();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                textBoxExtendedValue_Simple.Focus();
            }

            else if (tabControl1.SelectedTab == tabPage2)
            {
                textBoxExtendedValue_Advance.Focus();
            }

        }

       
        private void textBoxExtendedValue_Simple_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddOrSearch_Click(this, new EventArgs());
            }
        }
        public virtual string HashData(string data)
        {
            Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
            return md5.ComputeHash(data);
        }

        internal bool IsMembershipInAdministartorRole(Model.Common.User membership)
        {
            string roleCode = this.HashData(membership.Code.ToString() + (1).ToString());
            return membership.RoleCode == roleCode;
        }

        #region اینتر کردن گرید ویو 
        
        private void radGridViewSimple_DoubleClick(object sender, EventArgs e)
        {
            if (GetSelectedDossier(radGridViewSimple) == null)
                return;

            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser != null)
            {
                if (IsMembershipInAdministartorRole(currentUser))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewSimple), 0))
                    {
                        f.ShowDialog();

                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewSimple), 0))
                    {
                        f.ShowDialog();

                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                {

                    using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(GetSelectedDossier(radGridViewSimple), 0))
                    {
                        f.ShowDialog(this);
                    }
                }
            }
        }

        private void radGridViewSimple_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GetSelectedDossier(radGridViewSimple) == null)
                    return;

                Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                if (currentUser != null)
                {
                    if (IsMembershipInAdministartorRole(currentUser))
                    {
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewSimple), 0))
                        {
                            f.ShowDialog();

                        }
                    }
                    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                    {
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewSimple), 0))
                        {
                            f.ShowDialog();

                        }
                    }
                    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                    {

                        using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(GetSelectedDossier(radGridViewSimple), 0))
                        {
                            f.ShowDialog(this);
                        }
                    }
                }
            }
        }

        private void radGridViewAdvanced_DoubleClick(object sender, EventArgs e)
        {
            if (GetSelectedDossier(radGridViewAdvanced) == null)
                return;

            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser != null)
            {
                if (IsMembershipInAdministartorRole(currentUser))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAdvanced), 0))
                    {
                        f.ShowDialog();

                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAdvanced), 0))
                    {
                        f.ShowDialog();

                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                {

                    using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(GetSelectedDossier(radGridViewAdvanced), 0))
                    {
                        f.ShowDialog(this);
                    }
                }
            }
        }

        private void radGridViewAdvanced_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GetSelectedDossier(radGridViewAdvanced) == null)
                    return;

                Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                if (currentUser != null)
                {
                    if (IsMembershipInAdministartorRole(currentUser))
                    {
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAdvanced), 0))
                        {
                            f.ShowDialog();

                        }
                    }
                    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                    {
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAdvanced), 0))
                        {
                            f.ShowDialog();

                        }
                    }
                    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                    {

                        using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(GetSelectedDossier(radGridViewAdvanced), 0))
                        {
                            f.ShowDialog(this);
                        }
                    }
                }
            }
        }

        private void radGridViewAll_DoubleClick(object sender, EventArgs e)
        {
            if (GetSelectedDossier(radGridViewAll) == null)
                return;

            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser != null)
            {
                if (IsMembershipInAdministartorRole(currentUser))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAll), 0))
                    {
                        f.ShowDialog();

                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAll), 0))
                    {
                        f.ShowDialog();

                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                {

                    using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(GetSelectedDossier(radGridViewAll), 0))
                    {
                        f.ShowDialog(this);
                    }
                }
            }
        }

        private void radGridViewAll_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GetSelectedDossier(radGridViewAll) == null)
                    return;

                Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                if (currentUser != null)
                {
                    if (IsMembershipInAdministartorRole(currentUser))
                    {
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAll), 0))
                        {
                            f.ShowDialog();

                        }
                    }
                    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                    {
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(GetSelectedDossier(radGridViewAll), 0))
                        {
                            f.ShowDialog();

                        }
                    }
                    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                    {

                        using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(GetSelectedDossier(radGridViewAll), 0))
                        {
                            f.ShowDialog(this);
                        }
                    }
                }
            }
        }
        #endregion

        private void textBoxExtendedValue_Advance_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(this, new EventArgs());
            }
        }


   












    }
}
