using NjitSoftware.Model.Archive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NjitSoftware.View
{
    public partial class ArchiveDocumentShow : Njit.Program.ComponentOne.Forms.ListFormWithoutMainRibbon
    {
        private string PersonnelNumber;
        private int DocumentId;
        private Document _CurrentDocument;
        List<DossierWithNamNNFamilyPersonnelNumber> listNameNN;
        string _ColumnName = "";
        private Model.Archive.Dossier _SelectedDossier = null;
        [DefaultValue(null)]
        public Model.Archive.Dossier SelectedDossier
        {
            get
            {
                return _SelectedDossier;
            }
            set
            {
                _SelectedDossier = value;
            }
        }
        public ArchiveDocumentShow(string _personelNumber, int _documentid)
        {
            InitializeComponent();
            imageListView.SetRenderer(new ImageListViewRenderers.MahbaRenderer());
            this.PersonnelNumber = _personelNumber;

            this.DocumentId = _documentid;
            if (this.DocumentId != 0)
            {
                this._CurrentDocument = Controller.Archive.DocumentController.GetDocument(this.DocumentId);
                ShowImage_In_Center_Panel();
            }
            listNameNN = new List<DossierWithNamNNFamilyPersonnelNumber>();
            listNameNN = GetNameNN();

            colorSliderZoom.Value = Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom;
            pnlListView.Size = new Size(colorSliderZoom.Value, colorSliderZoom.Value);
            imageListView.ThumbnailSize = new Size(Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);


            //شروطی که برای ستونها در نظر گرفته شده است
            radGridViewExtended1.ContextMenuOpening += radGridViewExtended1_ContextMenuOpening;
            //اگر جای ستونها عوض شود
            radGridViewExtended1.ColumnIndexChanging += radGridViewExtended1_ColumnIndexChanging;
            //اگرعرض ستونها عوض شود
            radGridViewExtended1.ColumnWidthChanging += radGridViewExtended1_ColumnWidthChanging;
            radGridViewExtended1.CellMouseMove += radGridViewExtended1_CellMouseMove;


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D))
            {
                btnNewDossier_Click(btnNewDossier, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.A))
            {
                foreach (var item in imageListView.Items)
                {
                    item.Selected = true;
                    item.BackColor = System.Drawing.Color.Gray;

                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetPersonnelNumberAutoComplate();

            SetNameAndFamily();

            LoadDocumentsInRightPanel();
            if (this.PersonnelNumber != "")
                if (this.PersonnelNumber != null)
                {
                    this.SelectedDossier = Controller.Archive.DossierController.Select(this.PersonnelNumber);
                    txtPersonnelNumber.Text = this.PersonnelNumber;
                    DossierWithNamNNFamilyPersonnelNumber dc = listNameNN.Where(q => q.PersonnelNumber == txtPersonnelNumber.Text).FirstOrDefault();
                    if (dc != null)
                    {
                        this.PersonnelNumber = dc.PersonnelNumber;
                        txtNameFamily.Text = dc.NameAndFamily;
                        txtNameFamily.SelectItem();
                    }
                    ShowImage_In_Center_Panel();
                }
            txtPersonnelNumber.Focus();
        }
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
        //تغییر اندازه ستونها
        void radGridViewExtended1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            int i = e.ColumnIndex;
            
                string _FormName = "";
                if (radGridViewExtended1.Columns[i].Name == "ID")
                {
                    _FormName = "ID";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Radif")
                {
                    _FormName = "Radif";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Shomare")
                {
                    _FormName = "Shomare";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Date")
                {
                    _FormName = "Date";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Title")
                {
                    _FormName = "Title";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Mokhatab")
                {
                    _FormName = "Mokhatab";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Eghdam")
                {
                    _FormName = "Eghdam";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Virastar")
                {
                    _FormName = "Virastar";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
                if (radGridViewExtended1.Columns[i].Name == "Broooz")
                {
                    _FormName = "Broooz";
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                    if (query.Count() == 1)
                    {
                        query.FirstOrDefault().Width = e.NewWidth;
                        dc.SubmitChanges();
                    }
                }
            
            
        }

        void radGridViewExtended1_ColumnIndexChanging(object sender, ColumnIndexChangingEventArgs e)
        {
            //MessageBox.Show("Old:" + e.OldIndex + "New" + e.NewIndex);
            //نمایش تمام ستون های جدول
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _ColumnName);
            if (query.Count() == 1)
            {
                query.FirstOrDefault().WindowState = 1;
                //منظور از ایگرگ همان ایندکس است
                query.FirstOrDefault().Y = e.NewIndex;
                //ایکس ایندکس قبلی اش هست
                query.FirstOrDefault().X = e.OldIndex;
                dc.SubmitChanges();

            }
        }

        void radGridViewExtended1_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
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
        //بازیابی اطلاعات ستون ها
        private void DossierDocumentsManage3_Click(object sender, EventArgs e)
        {
            for (int j = 1; j <= 9; j++)
            {
                string _FormName = "";

                int _Index = 0;
                if (j == 1)
                {
                    _FormName = "Radif";
                    _Index = 0;
                }
                if (j == 2)
                {
                    _FormName = "ID";
                    _Index = 1;
                }
                if (j == 3)
                {
                    _FormName = "Shomare";
                    _Index = 2;
                }
                else if (j == 4)
                {
                    _FormName = "Date";
                    _Index = 3;
                }
                else if (j == 5)
                {
                    _FormName = "Title";
                    _Index = 4;
                }
                else if (j == 6)
                {
                    _FormName = "Mokhatab";
                    _Index = 5;
                }
                else if (j == 7)
                {
                    _FormName = "Eghdam";
                    _Index = 6;
                }
                else if (j == 8)
                {
                    _FormName = "Virastar";
                    _Index = 7;
                }
                else if (j == 9)
                {
                    _FormName = "Broooz";
                    _Index = 8;
                }
                //نمایش تمام ستون های جدول
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                if (query.Count() == 1)
                {
                    query.FirstOrDefault().WindowState = 1;
                    //منظور از ایگرگ همان ایندکس است
                    query.FirstOrDefault().Y = _Index;
                    query.FirstOrDefault().X = _Index;
                    dc.SubmitChanges();
                }
            }
            radGridViewExtended1.Columns[0].IsVisible = true;
            radGridViewExtended1.Columns[1].IsVisible = true;
            radGridViewExtended1.Columns[2].IsVisible = true;
            radGridViewExtended1.Columns[3].IsVisible = true;
            radGridViewExtended1.Columns[4].IsVisible = true;
            radGridViewExtended1.Columns[5].IsVisible = true;
            radGridViewExtended1.Columns[6].IsVisible = true;
            radGridViewExtended1.Columns[7].IsVisible = true;
         
        }
        //مخفی کردن ستون
        void DossierDocumentsManage2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_ColumnName);
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _ColumnName);
           
                if (query.Count() == 1)
                {
                    if (query.FirstOrDefault().WindowState == 1)
                    {
                        query.FirstOrDefault().WindowState = 0;
                        dc.SubmitChanges();
                    }
                    else
                    {
                        query.FirstOrDefault().WindowState = 1;
                        dc.SubmitChanges();
                    }
                }
                else
                {
                    Model.Common.FormState state = Model.Common.FormState.GetNewInstance(Environment.MachineName, _ColumnName, 0, 0, 0, 0, 0);
                    Model.Common.FormState.Insert(dc, state);
                    dc.SubmitChanges();
                }
            

        }

      





        #region Scroll
        ScrollEventType? _ScrollEventType = null;
        private void colorSliderZoom_Scroll(object sender, ScrollEventArgs e)
        {
            _ScrollEventType = e.Type;
            if (CanRefreshThumbs(e.Type))
            {
                Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom = e.NewValue;
                Setting.User.ThisProgram.SaveAndReload();
            }
            if (CanRefreshThumbs(e.Type) && imageListView.ThumbnailSize.Height == e.NewValue && imageListView.ThumbnailSize.Width == e.NewValue)
                imageListView.Refresh();
            imageListView.ThumbnailSize = new Size(e.NewValue, e.NewValue);
            pnlListView.Size = new Size(e.NewValue, e.NewValue);
        }

        private bool CanRefreshThumbs(ScrollEventType type)
        {
            return (type == ScrollEventType.EndScroll || type == ScrollEventType.LargeDecrement || type == ScrollEventType.LargeIncrement || type == ScrollEventType.SmallDecrement || type == ScrollEventType.SmallIncrement);
        }
        #endregion

        #region نمایش لیستی نام و نام خانوادگی و شماره پرسنلی
        private void SetNameAndFamily()
        {
            txtNameFamily.AutoCompleteList = listNameNN.Select(q => q.NameAndFamily).ToList();
            txtNameFamily.SelectItem();
        }
        public string SafeFarsiStr(string input)
        {
            return input.Replace("ی", "ی").Replace("ک", "ک");
        }
        private List<DossierWithNamNNFamilyPersonnelNumber> GetNameNN()
        {

            DataTable table = SqlHelper.GetArchiveFieldValue("Dossier1", "PersonnelNumber", "Field1", "Field2", "Field15");
            List<DossierWithNamNNFamilyPersonnelNumber> listNameNN = new List<DossierWithNamNNFamilyPersonnelNumber>();

            foreach (DataRow row in table.Rows)
            {
                DossierWithNamNNFamilyPersonnelNumber NameNN = new DossierWithNamNNFamilyPersonnelNumber();

                NameNN.PersonnelNumber = row.ItemArray[0].ToString();
                NameNN.NameAndFamily = SafeFarsiStr(row.ItemArray[1].ToString() + " " + row.ItemArray[2].ToString() + "_" + row.ItemArray[0].ToString());
                NameNN.NN = row.ItemArray[3].ToString();
                listNameNN.Add(NameNN);

            }
            return listNameNN;
        }
        //این برای این است که بتوان بروی نام و نام خانوادگی و کد ملی جسیجو انجام داد
        class DossierWithNamNNFamilyPersonnelNumber
        {
            public string PersonnelNumber { get; set; }
            public string NameAndFamily { get; set; }
            public string NN { get; set; }
        }
        #region لیست شماره پرسنلی ها را نمایش می دهد
        /// <summary>
        /// لیست شماره پرسنلی ها را نمایش می دهد
        /// </summary>
        private void SetPersonnelNumberAutoComplate()
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange(listNameNN.Select(q => q.PersonnelNumber).ToArray());
            txtPersonnelNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPersonnelNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPersonnelNumber.AutoCompleteCustomSource = autoCompleteStringCollection;
        }
        #endregion
        #endregion

        #region Change Box
        private void txtPersonnelNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DossierWithNamNNFamilyPersonnelNumber dc = listNameNN.Where(q => q.PersonnelNumber == txtPersonnelNumber.Text).FirstOrDefault();
                if (dc != null)
                {
                    this.PersonnelNumber = dc.PersonnelNumber;
                    this.SelectedDossier = Controller.Archive.DossierController.Select(PersonnelNumber);
                    radGridViewExtended1.DataSource = null;
                    txtNameFamily.Text = dc.NameAndFamily;
                    txtNameFamily.SelectItem();
                    Reset_Left_And_Center_Image();
                    LoadDocumentsInRightPanel();
                }
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void txtNameFamily_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DossierWithNamNNFamilyPersonnelNumber dc = listNameNN.Where(q => q.NameAndFamily == txtNameFamily.Text).FirstOrDefault();
                if (dc != null)
                {
                    this.SelectedDossier = Controller.Archive.DossierController.Select(PersonnelNumber);
                    txtPersonnelNumber.Text = dc.PersonnelNumber;
                    this.PersonnelNumber = dc.PersonnelNumber;
                    radGridViewExtended1.DataSource = null;
                    Reset_Left_And_Center_Image();
                    LoadDocumentsInRightPanel();
                }
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        #endregion
        private void Reset_Left_And_Center_Image()
        {
            imageListView.Items.Clear();
            _CurrentDocument = null;
            kpImageViewer1.Image = global::NjitSoftware.Properties.Resources.Document;

        }
        #region نمایش  جدولی اطلاعات پرونده

        private bool LoadDocumentsInRightPanel()
        {

            List<Model.Archive.Document> documents = new List<Document>();
            documents = Controller.Archive.DocumentController.GetDocumentsWithoutChilds(this.PersonnelNumber).ToList();
            documents = SetAccessPermission(documents.ToList());
            LoadInformationDocuments_InRightPanel(documents);
            lblDocNumber.Text = "تعداد اسناد پرونده:" + documents.Where(q => q.ParentDocumentID == null).Count().ToString();

            return true;


        }

        private void loadNumberofDocument(string personnelNumber)
        {
            if (_CurrentDocument == null)
                lblDocNumber.Text = "تعداد اسناد پرونده:" + Controller.Archive.DocumentController.GetNumberOfDocument(personnelNumber);

        }

        #endregion
        #region لود اطلاعات در سمت چپ
        /// <summary>
        /// لود اطلاعات در سمت چپ
        /// </summary>
        /// <returns></returns>
        private bool LoadDocuments_IN_Left_Panle()
        {
            if (this.PersonnelNumber != "")
                if (this.PersonnelNumber != null)
                {
                    if (!isAccessPermission(Controller.Archive.DossierController.Select(this.PersonnelNumber)))
                    {
                        PersianMessageBox.Show(this, string.Format("مجوز دسترسی به پرونده  برای شما صادر نشده است"));
                        return false;
                    }
                    imageListView.Items.Clear();
                    List<Model.Archive.Document> documents = new List<Document>();
                    if (_CurrentDocument != null)
                    {
                        documents = new List<Document>();
                        foreach (var itemChild in Controller.Archive.DocumentController.GetChildDocuments(_CurrentDocument.ID))
                        {
                            documents.Add(itemChild);
                        }

                        documents.Add(_CurrentDocument);
                        int documentsCount = documents.Count();
                        if (documentsCount > 0)
                        {
                            documents = SetAccessPermission(documents.ToList());
                            if (_CurrentDocument != null)
                            {
                                int i = 0;
                                int threadCount = 10;
                                do
                                {
                                    IEnumerable<Model.Archive.Document> list = documents.Skip(i).Take(i + threadCount < documentsCount ? threadCount : (documentsCount - i));
                                    LoadListOfDocuments(list);
                                    i += threadCount;
                                }
                                while (i < documentsCount);
                            }
                        }

                        if (documents.Count == 0)
                            lblDocNumber.Text = "تعداد اسناد پیوست شده:" + (documents.Count()).ToString();
                        else
                            lblDocNumber.Text = "تعداد اسناد پیوست شده:" + (documents.Count() - 1).ToString();
                        return true;
                    }
                    else
                    {
                        loadNumberofDocument(this.PersonnelNumber);
                    }
                }
            return false;
        }
        private void LoadListOfDocuments(IEnumerable<Model.Archive.Document> list)
        {
            List<IAsyncResult> results = new List<IAsyncResult>();
            list = list.OrderBy(q => q.Index);
            if (list.Count() > 0)
            {
                foreach (var doc in list)
                {
                    results.Add(this.BeginInvoke(new Action<Model.Archive.Document>(LoadDocument), doc));
                }
                foreach (IAsyncResult res in results)
                {
                    this.EndInvoke(res);
                }
            }
        }
        private void LoadDocument(Model.Archive.Document doc)
        {
            lock (imageListView)
            {
                imageListView.Items.Add(doc, doc.ParentDocumentID.HasValue ? Controller.Archive.DocumentController.GetDocument(doc.ParentDocumentID.Value).Index.ToString() + "_" + doc.Index : doc.Index.ToString());
            }
        }
        private void imageListView_RetrieveVirtualItemThumbnail(object sender, Njit.ImageListView.VirtualItemThumbnailEventArgs e)
        {
            if (_ScrollEventType == null || (_ScrollEventType.HasValue && CanRefreshThumbs(_ScrollEventType.Value)))
                e.ThumbnailImage = Controller.Archive.DocumentController.GetDocumentThumb(e.Key as Model.Archive.Document);
        }
        #endregion
        #region مجوز دسترسی
        //مجوز دسترس به پرونده را دارد یا خیر 
        private bool isAccessPermission(Model.Archive.Dossier dossier)
        {
            //اگر ادمین باشد نیازی نیست
            if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
                return true;
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            //لیست نوع دسترسی
            List<Model.Common.PermissionDossier> listSecurity = dc.PermissionDossiers.Where(q => q.User.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID).ToList();
            return listSecurity.Exists(q => q.DossierType == dossier.DossierSecurityID);
        }
        class DocumnetSecurity
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        private List<Model.Archive.Document> SetAccessPermission(List<Model.Archive.Document> documents)
        {
            //اگر ادمین باشد نیازی نیست
            if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
                return documents;
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            //لیست نوع دسترسی
            List<Model.Common.PermissionSecurity> listSecurity = dc.PermissionSecurities.Where(q => q.User.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID).ToList();
            List<DocumnetSecurity> listds = new List<DocumnetSecurity>();
            System.Data.DataTable listRow = SqlHelper.GetField("Field18");
            if (listRow.Rows.Count > 0)
            {

                for (int i = 0; i < listRow.Rows.Count; i++)
                {
                    DocumnetSecurity ds = new DocumnetSecurity();
                    ds.ID = Convert.ToInt32(listRow.Rows[i][0]);
                    ds.Name = listRow.Rows[i][1].ToString();
                    listds.Add(ds);
                }
            }
            //لیست دسترسی به عناوین
            List<Model.Common.PermissionTitle> listTitle = dc.PermissionTitles.Where(q => q.User.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID).ToList();
            foreach (var item in documents.ToList())
            {
                System.Data.DataTable tempDataTable = SqlHelper.GetDocuments("Document2", item);
                if (tempDataTable.Rows.Count > 0)
                {
                    //مشخص کردن سطح دسترسی بر اساس عناوین اسناد
                    if (tempDataTable.Rows[0]["Field11"].ToString() != "")
                    {
                        string name = tempDataTable.Rows[0]["Field11"].ToString();
                        //Access Permissinon title 
                        if (!listTitle.Any(q => tempDataTable.Rows[0]["Field11"].ToString() == q.PK_TitleORField11.ToString()))
                        {
                            MessageBox.Show(name);
                            documents.RemoveAll(q => q == item);
                        }
                    }
                    //مشخص کردن سطح دسترسی بر اساس نوع دسترسی اسناد
                    if (tempDataTable.Rows[0]["Field18"].ToString() != "")
                    {
                        if (listds.Any())
                        {
                            //Access Permissinon  Security
                            if (!listSecurity.Any(q => listds.Find(k => k.Name == tempDataTable.Rows[0]["Field18"].ToString()).ID == q.PK_SecurityORField18))
                            {
                                documents.RemoveAll(q => q == item);
                            }
                        }
                    }
                }

            }
            return documents;
        }

        #endregion

        #region Darg And Drop
        private void imageListView_DragDrop(object sender, DragEventArgs e)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            int index = Controller.Archive.DocumentController.GetMaxDocumentIndex(this.PersonnelNumber);
            foreach (Njit.ImageListView.ImageListViewItem item in imageListView.Items)
            {
                index++;
                Document d = new Document();
                d = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);

                d.Index = index;

                Controller.Archive.DocumentController.Update(dc, d);

            }
            LoadDocuments_IN_Left_Panle();
        }
        #endregion

        #region Full Screen Image
        View.ImageView documentView;
        string tempFile;
        //دوبار بروی عکس بزرگ کلیک کند وارد صفحه دیگری شود
        void kpImageViewer1_Mouse1Click()
        {
            if (documentView != null)
            {
                if (documentView.Visible)
                    documentView.Close();
                documentView.Dispose();
            }
            if (_CurrentDocument != null)
            {
                if (Controller.Archive.DocumentController.DocumentIsImage(this._CurrentDocument))
                {
                    documentView = new ImageView(this._CurrentDocument, this.PersonnelNumber);
                    documentView.Show(this);
                }
                else
                {
                    try
                    {
                        tempFile = Controller.Archive.DocumentController.CopyDocumentToTempPath(this._CurrentDocument);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = tempFile;
                        process.StartInfo.UseShellExecute = true;
                        process.Exited += process_Exited;
                        process.EnableRaisingEvents = true;
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در باز کردن فایل" + "\r\n\r\n" + ex.Message);
                    }
                }
            }
        }
        private void imageListView_ItemDoubleClick(object sender, Njit.ImageListView.ItemClickEventArgs e)
        {
            this._CurrentDocument = e.Item.VirtualItemKey as Model.Archive.Document;
            ShowImage_In_Center_Panel();

        }

        private void process_Exited(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(tempFile))
            {
                try
                {
                    System.IO.File.Delete(tempFile);
                }
                catch { }
            }
        }

        #endregion

        #region Select Image
        private void imageListView_ItemClick(object sender, Njit.ImageListView.ItemClickEventArgs e)
        {
            this._CurrentDocument = e.Item.VirtualItemKey as Model.Archive.Document;
            ShowImage_In_Center_Panel();

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        //نمایش عکسی که انتخاب شده است
        private void ShowImage_In_Center_Panel()
        {
            Image img = global::NjitSoftware.Properties.Resources.Document;
            if (_CurrentDocument != null)
            {
                this.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
                string file;
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                {
                    string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                    if (!System.IO.Directory.Exists(tempPath))
                        System.IO.Directory.CreateDirectory(tempPath);
                    file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(_CurrentDocument.FileName));
                    img = Image.FromFile(file);
                }
                else 
                    img = byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(_CurrentDocument));
                
                //اگر عکس باشد
                if (Controller.Archive.DocumentController.DocumentIsImage(_CurrentDocument))
                {

                    if (img != null)
                    {
                        Bitmap bm = new Bitmap(img);

                        kpImageViewer1.Image = bm;
                        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        kpImageViewer1.AutoSize = true;
                        kpImageViewer1.AutoSizeMode = AutoSizeMode.GrowOnly;

                    }
                }
                else
                {
                    try
                    {
                        //زمانی که فایل هست
                        tempFile = Controller.Archive.DocumentController.CopyDocumentToTempPath(_CurrentDocument);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = tempFile;
                        process.StartInfo.UseShellExecute = true;
                        process.Exited += process_Exited;
                        process.EnableRaisingEvents = true;
                        process.Start();
                        kpImageViewer1.Image = global::NjitSoftware.Properties.Resources.Document;


                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در باز کردن فایل" + "\r\n\r\n" + ex.Message);
                    }
                }
            }
            else
            {
                kpImageViewer1.Image = global::NjitSoftware.Properties.Resources.Document;
            }
        }

        #endregion


        #region LoadInfo
        class DocInfo
        {
            [DisplayName("ردیف")]
            public int Radif { get; set; } 
            [DisplayName("شماره سند")]
            public string ID { get; set; }
            [DisplayName("شماره نامه")]
            public string Shomare { get; set; }
            [DisplayName("تاریخ نامه")]
            public string Date { get; set; }
            [DisplayName("عنوان نامه")]
            public string Title { get; set; }
            [DisplayName("مخاطب نامه")]
            public string Mokhatab { get; set; }
            [DisplayName("اقدام کننده")]
            public string Eghdam { get; set; }
            [DisplayName("ویراستار")]
            public string Virastar { get; set; }
            [DisplayName("به روز رسانی")]
            public string Broooz { get; set; }
        }
        private void LoadInformationDocuments_InRightPanel(IEnumerable<Model.Archive.Document> listdoc)
        {
            DrowObjectsDossier(Controller.Archive.ArchiveTabController.GetName("Dossier1"));
            DrowObjects(Controller.Archive.ArchiveTabController.GetName("Document2"), listdoc);
            if (tabInfo.SelectedTab.Text == "اطلاعات پرونده")
                Controller.Archive.DossierController.LoadPersonnelDataToControl(tabDossier, Controller.Archive.ArchiveTabController.GetName("Dossier1"), this.PersonnelNumber);
        }

        private void DrowObjects(Model.Archive.ArchiveTab archiveTab, IEnumerable<Model.Archive.Document> listdoc)
        {
            if (listdoc.Count() == 0)
                return;
            CreateObject(archiveTab.Name, listdoc);

        }
        private void CreateObject(string TabPageName, IEnumerable<Model.Archive.Document> listdoc)
        {
            List<DocInfo> listdocinfo = new List<DocInfo>();
            try
            {
       
                foreach (var item in listdoc)
                {
                    if (item.ParentDocumentID == null)
                    {
                        System.Data.DataTable tempDataTable = SqlHelper.GetDocuments(TabPageName, item);
                        DocInfo di = new DocInfo();
                       
                        di.ID = item.Index.ToString();
                        di.Broooz = "";
                        if (tempDataTable.Rows.Count > 0)
                        {

                            System.Data.DataTable DocNumber = SqlHelper.GetDocuments("Document", Convert.ToInt32(tempDataTable.Rows[0]["DocumentID"]));
                          
                            di.Shomare = tempDataTable.Rows[0]["Field7"].ToString();
                            di.Date = tempDataTable.Rows[0]["Field8"].ToString();
                            di.Mokhatab = tempDataTable.Rows[0]["Field10"].ToString();
                            di.Title = tempDataTable.Rows[0]["Field12"].ToString();
                            di.Eghdam = tempDataTable.Rows[0]["Field14"].ToString();
                            di.Virastar = tempDataTable.Rows[0]["Field16"].ToString();
                            if (di.Virastar != null)
                            {
                                int _Code = 0;
                                try
                                {
                                    _Code = Convert.ToInt32(di.Virastar.Trim());
                                    di.Virastar = Setting.User.ThisProgram.GetUserByCode(_Code);
                                }
                                catch { }
                            }
                            di.Broooz = tempDataTable.Rows[0]["Field17"].ToString();
                        }
                        listdocinfo.Add(di);
                    }
                }
                if (listdocinfo.Any())
                {
                    var sortedList = listdocinfo.OrderByDescending(x => x.Broooz);
                    try
                    {
                        //اولین سند را نمایش بده
                        if (sortedList.Any())
                        {
                            int Count=1;
                            //foreach (var item in sortedList)
                            //{
                            //    item.ID = Count+"";
                            //        Count++;
                            //}
                            this._CurrentDocument = _CurrentDocument = Controller.Archive.DocumentController.GetDocument(this.PersonnelNumber, sortedList.FirstOrDefault().ID);
                            LoadDocuments_IN_Left_Panle();
                            ShowImage_In_Center_Panel();
                        }
                    }
                    catch { }
                    int index=0;
                    foreach (var item in sortedList)
                    {index++;
                    item.Radif = index;
                    }
                    radGridViewExtended1.DataSource = sortedList;
                    
                    for (int i = 0; i < 9; i++)
                    {
                        string _FormName = "";
                        if (i == 0)
                            _FormName = "Shomare";
                        else if (i == 1)
                            _FormName = "ID";
                        else if (i == 2)
                            _FormName = "Radif";
                        else if (i == 3)
                            _FormName = "Date";
                        else if (i == 4)
                            _FormName = "Title";
                        else if (i == 5)
                            _FormName = "Mokhatab";
                        else if (i == 6)
                            _FormName = "Eghdam";
                        else if (i == 7)
                            _FormName = "Virastar";
                        else if (i == 8)
                            _FormName = "Broooz";

                        Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                        var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == _FormName);
                        if (query.Count() == 1)
                        {
                            //مخفی کردن ستون هایی که می خواسته نمایش داده نشود
                            #region hidden Column
                            if (query.FirstOrDefault().FormName == "ID" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["ID"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Radif" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Radif"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Shomare" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Shomare"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Shomare" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Shomare"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Date" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Date"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Title" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Title"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Mokhatab" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Mokhatab"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Eghdam" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Eghdam"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Virastar" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Virastar"].IsVisible = false;
                            if (query.FirstOrDefault().FormName == "Broooz" && query.FirstOrDefault().WindowState == 0)
                                radGridViewExtended1.Columns["Broooz"].IsVisible = false;
                            #endregion
                            //تعویض جای ستونها
                            #region ChangeColumn
                            if (query.FirstOrDefault().FormName == "ID")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["ID"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Radif")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Radif"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Shomare")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Shomare"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Date")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Date"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Title")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Title"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Mokhatab")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Mokhatab"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Eghdam")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Eghdam"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Virastar")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Virastar"].Index, query.FirstOrDefault().Y);
                            if (query.FirstOrDefault().FormName == "Broooz")
                                radGridViewExtended1.Columns.Move(radGridViewExtended1.Columns["Broooz"].Index, query.FirstOrDefault().Y);
                            #endregion
                            //مشخص کردن عرض هر ستون
                            #region ChangeColumn
                            if (query.FirstOrDefault().FormName == "ID")
                                radGridViewExtended1.Columns["ID"].Width = query.FirstOrDefault().Width;
                            if (query.FirstOrDefault().FormName == "Radif")
                                radGridViewExtended1.Columns["Radif"].Width = query.FirstOrDefault().Width;

                            if (query.FirstOrDefault().FormName == "Shomare")
                                radGridViewExtended1.Columns["Shomare"].Width = query.FirstOrDefault().Width;
                            if (query.FirstOrDefault().FormName == "Date")
                                radGridViewExtended1.Columns["Date"].Width = query.FirstOrDefault().Width;
                            if (query.FirstOrDefault().FormName == "Title")
                                radGridViewExtended1.Columns["Title"].Width = query.FirstOrDefault().Width;
                            if (query.FirstOrDefault().FormName == "Mokhatab")
                                radGridViewExtended1.Columns["Mokhatab"].Width = query.FirstOrDefault().Width;
                            if (query.FirstOrDefault().FormName == "Eghdam")
                                radGridViewExtended1.Columns["Eghdam"].Width = query.FirstOrDefault().Width;
                            if (query.FirstOrDefault().FormName == "Virastar")
                                radGridViewExtended1.Columns["Virastar"].Width = query.FirstOrDefault().Width;
                            if (query.FirstOrDefault().FormName == "Broooz")
                                radGridViewExtended1.Columns["Broooz"].Width = query.FirstOrDefault().Width;
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا در بارگذاری اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }
        #endregion
        private void CreateObjectDossier(string TabPageName, Model.Archive.ArchiveField CurrentField, int XLabel, int YLabel, int XText, int YText)
        {
            try
            {
                if (CurrentField.BoxTypeCode != (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی && CurrentField.BoxTypeCode != (int)Enums.BoxTypes.کادر_انتخاب)
                {
                    //اگر کد کاربر و تاریخ امروز باشد نمایش نده
                    if (CurrentField.FieldName != "Field17" && CurrentField.FieldName != "Field16")
                    {
                        Label label = DossierFormHelper.CreateLabel(CurrentField.Label, XLabel, YLabel);
                        label.Size = new Size(100, 20);
                        tabDossier.Controls.Add(label);
                    }
                }
                else if (CurrentField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد)
                {
                    //اگر کد کاربر و تاریخ امروز باشد نمایش نده
                    if (CurrentField.FieldName != "Field17" && CurrentField.FieldName != "Field16")
                    {
                        Label label = DossierFormHelper.CreateLabelStar(XLabel, YLabel);
                        label.ForeColor = Color.Green;
                        tabDossier.Controls.Add(label);
                    }
                }
                switch (CurrentField.BoxTypeCode)
                {
                    case (int)Enums.BoxTypes.کادر_متن:
                        Njit.Program.Controls.TextBoxExtended textBoxExtended = DossierFormHelper.CreateTextBoxForDossierDocsManagement(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                        textBoxExtended.Size = new Size(350, 20);
                        textBoxExtended.Enabled = false;
                        tabDossier.Controls.Add(textBoxExtended);
                        if (CurrentField.AutoComplete)
                        {
                            textBoxExtended.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            textBoxExtended.AutoCompleteMode = AutoCompleteMode.Append;
                            textBoxExtended.AutoCompleteCustomSource.AddRange(SqlHelper.GetAllFieldValues(TabPageName, CurrentField.FieldName));
                        }
                        break;
                    case (int)Enums.BoxTypes.کادر_ورود_تاریخ:

                        Njit.Program.Controls.DateControl dateControl = DossierFormHelper.CreateDateBox(CurrentField, XText, YText);
                        dateControl.Size = new Size(350, 20);
                        dateControl.Enabled = false;
                        tabDossier.Controls.Add(dateControl);
                        break;

                    case (int)Enums.BoxTypes.کادر_بازشو:
                        Njit.Program.Controls.ComboBoxExtended comboBoxExtended = DossierFormHelper.CreateComboBox(CurrentField, XText, YText);
                        comboBoxExtended.Size = new Size(350, 20);
                        comboBoxExtended.Enabled = false;
                        tabDossier.Controls.Add(comboBoxExtended);
                        break;
                    case (int)Enums.BoxTypes.کادر_انتخاب:
                        CheckBox checkBox = DossierFormHelper.CreateChekBox(CurrentField, XText, YText);
                        checkBox.Size = new Size(350, 20);
                        checkBox.Enabled = false;
                        //checkBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        tabDossier.Controls.Add(checkBox);
                        break;
                    case (int)Enums.FieldTypes.ساعت:
                        Njit.Program.Controls.TimeControl timeControl = DossierFormHelper.CreateTimeBox(CurrentField, XText, YText);
                        timeControl.Size = new Size(350, 20);
                        timeControl.Enabled = false;
                        //timeControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        tabDossier.Controls.Add(timeControl);
                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی:
                        Njit.Program.Controls.DataGridViewExtended dataGridViewExtended = DossierFormHelper.CreateDataGridView(CurrentField);
                        dataGridViewExtended.Size = new Size(350, 120);
                        dataGridViewExtended.Location = new Point(5, 20);
                        dataGridViewExtended.Enabled = false;
                        GroupBox groupBox = DossierFormHelper.CreateGroupBox(CurrentField, YText);
                        groupBox.Size = new Size(350, 350);
                        groupBox.Padding = new System.Windows.Forms.Padding(8);
                        groupBox.Location = new Point(20, YText);
                        groupBox.Controls.Add(dataGridViewExtended);
                        dataGridViewExtended.Dock = DockStyle.Fill;
                        tabDossier.Controls.Add(groupBox);
                        break;
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا در بارگذاری اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }
        private void DrowObjectsDossier(Model.Archive.ArchiveTab archiveTab)
        {
            List<Model.Archive.ArchiveField> archiveFields = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
            if (archiveFields.Count == 0)
                return;
            int Distance = 0;
            int StartPointLabel_X = 370;
            int StartPointLabel_Y = 6;
            int StartPointControl_X = 1;
            int StartPointControl_Y = 5;
            foreach (Model.Archive.ArchiveField field in archiveFields)
            {
                CreateObjectDossier(archiveTab.Name, field, StartPointLabel_X, StartPointLabel_Y + Distance * 28, StartPointControl_X, StartPointControl_Y + Distance * 28);
                Distance++;
            }
        }

        private void tabInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabInfo.SelectedTab.Text == "اطلاعات پرونده")
                Controller.Archive.DossierController.LoadPersonnelDataToControl(tabDossier, Controller.Archive.ArchiveTabController.GetName("Dossier1"), this.PersonnelNumber);
            else
            {
                _CurrentDocument = null;
                LoadDocumentsInRightPanel();
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



        private void radGridViewExtended1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.radGridViewExtended1.SelectedRows.Count > 0)
                {
                    int index = Convert.ToInt32(this.radGridViewExtended1.SelectedRows[0].Cells["ID"].Value);
                    _CurrentDocument = Controller.Archive.DocumentController.GetDocument(this.PersonnelNumber, index);
                    Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                    if (currentUser != null)
                    {
                        if (IsMembershipInAdministartorRole(currentUser))
                        {

                            using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(this.PersonnelNumber, _CurrentDocument.ID))
                            {
                                f.ShowDialog(this);
                            }
                        }
                        else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                        {

                            using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(this.PersonnelNumber, _CurrentDocument.ID))
                            {
                                f.ShowDialog(this);
                            }
                        }
                        else
                        {

                            LoadDocuments_IN_Left_Panle();
                            ShowImage_In_Center_Panel();
                        }

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.radGridViewExtended1.SelectedRows.Count > 0)
            {
                int index = Convert.ToInt32(this.radGridViewExtended1.SelectedRows[0].Cells["ID"].Value);
                _CurrentDocument = Controller.Archive.DocumentController.GetDocument(this.PersonnelNumber, index);
                Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                if (currentUser != null)
                {
                    if (IsMembershipInAdministartorRole(currentUser))
                    {
                        this.Hide();
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(this.PersonnelNumber, _CurrentDocument.ID))
                        {

                            f.ShowDialog(this);
                        }
                        this.Close();
                    }
                    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                    {
                        this.Hide();
                        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(this.PersonnelNumber, _CurrentDocument.ID))
                        {
                            f.ShowDialog(this);
                        }
                        this.Close();
                    }
                    else
                    {
                        LoadDocuments_IN_Left_Panle();
                        ShowImage_In_Center_Panel();
                    }

                }
            }
        }

        #region New Dossier
        private void btnNewDossier_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (View.DossierNew.Instance.Visible)
                {
                    if (View.DossierNew.Instance.WindowState == FormWindowState.Minimized)
                        View.DossierNew.Instance.WindowState = FormWindowState.Normal;
                    View.DossierNew.Instance.Activate();
                }
                else
                    View.DossierNew.Instance.Show(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        #endregion

        private void btnNewDocument_Click(object sender, EventArgs e)
        {

            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser != null)
            {
                if (IsMembershipInAdministartorRole(currentUser))
                {
                    this.Hide();
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(this.PersonnelNumber, 0))
                    {
                        f.ShowDialog(this);
                    }
                    this.Close();
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                {
                    this.Hide();
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(this.PersonnelNumber, 0))
                    {
                        f.ShowDialog(this);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("شما با این دکمه دسترسی ندارید");
                }


            }
        }



        private void c1Button1_MouseClick(object sender, MouseEventArgs e)
        {

            this.Hide();
            using (View.DossierSearch f = new DossierSearch())
            {
                f.ShowDialog(this);
            }
            this.Close();
        }

     
        private void radGridViewExtended1_Click(object sender, EventArgs e)
        {
            if (this.radGridViewExtended1.SelectedRows.Count > 0)
            {
                try
                {
                    MouseEventArgs me = (MouseEventArgs)e;
                    if (me.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (this.radGridViewExtended1.SelectedRows.Count > 0)
                        {
                            int index = Convert.ToInt32(this.radGridViewExtended1.SelectedRows[0].Cells["ID"].Value);
                            _CurrentDocument = Controller.Archive.DocumentController.GetDocument(this.PersonnelNumber, index);
                            LoadDocuments_IN_Left_Panle();
                            ShowImage_In_Center_Panel();



                        }
                    }
                }
                catch { }
            }
        }
     

        private void radGridViewExtended1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
          
        }

    }
}
