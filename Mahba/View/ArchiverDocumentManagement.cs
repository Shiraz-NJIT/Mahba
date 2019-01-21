using AutoCompleteTextBoxSample;
using AutoCompleteTextBoxSample3;
using KaupischITC.ScanWIA;
using Njit.ImageListView;
using NjitSoftware.Model.Archive;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public delegate void SendDataToDocumentField(Dictionary<string, string> Data, string type);

    public partial class ArchiverDocumentManagement : Njit.Program.ComponentOne.Forms.ListFormWithoutMainRibbon
    {
        public SendDataToDocumentField SendDataToFormDocumentField;

        private string PersonnelNumber;
        private Model.Archive.Document _CurrentDocument = null;
        [DefaultValue(null)]
        string tempDirectory;
        private int _FieldSelect;
        List<DossierWithNamNNFamilyPersonnelNumber> listNameNN;
        public Model.Archive.Document CurrentDocument
        {
            get
            {
                return _CurrentDocument;
            }
            set
            {
                _CurrentDocument = value;
            }
        }

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
        public ArchiverDocumentManagement(string PersonnelNumber, long Documentid)
        {
            InitializeComponent();
            //اگر که پیوست داشت نشان می دهد
            imageListView.SetRenderer(new ImageListViewRenderers.MahbaRenderer());
            // TODO: Complete member initialization
            this.PersonnelNumber = PersonnelNumber;
            this.SelectedDossier = Controller.Archive.DossierController.Select(PersonnelNumber);
            if (Documentid != 0)
            {
                _CurrentDocument = Controller.Archive.DocumentController.GetDocument(Convert.ToInt32(Documentid));
                ShowImage_In_Center_Panel();
            }
            //گرفتن اطلاعات تمام پرونده ها
            listNameNN = new List<DossierWithNamNNFamilyPersonnelNumber>();
            listNameNN = GetNameNN();
            colorSliderZoom.Value = Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom;
            pnlListView.Size = new Size(colorSliderZoom.Value, colorSliderZoom.Value);
            imageListView.ThumbnailSize = new Size(Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
            kpImageViewer1.Mouse1Click += kpImageViewer1_Mouse1Click;
            tempDirectory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
            //درست کردن اندازه سایز پنل 
            SetPanelFieldSize();
        }



        //این برای این است که بتوان بروی نام و نام خانوادگی و کد ملی جسیجو انجام داد
        class DossierWithNamNNFamilyPersonnelNumber
        {
            public string PersonnelNumber { get; set; }
            public string NameAndFamily { get; set; }
            public string NN { get; set; }
        }

        #region گرفتن اطلاعات از فرم DocumentField

        public void GetDataFromFormDocumentField(Dictionary<string, string> value,Dictionary<string, string> NewData,string type)
        {
            switch (type)
            {
                case "Field10":
                    AutoCompleteTextbox3 textBoxExtended10 = (AutoCompleteTextbox3)pnlInfo.Controls["Field10"];
                    Njit.Program.Controls.TextBoxExtended textBoxExtended9 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field9"];
                    textBoxExtended9.Text = value.FirstOrDefault().Key.ToString();
                    textBoxExtended10.Text = value.FirstOrDefault().Value.ToString();

                    ListMokhatab = NewData;

                    textBoxExtended10.AutoCompleteList = ListMokhatab.Values.ToList();
                    textBoxExtended10.SelectItem();
                    textBoxExtended10.SelectionStart = textBoxExtended10.SelectionStart;
                    textBoxExtended10.SelectionLength = 0;
                    
                    break;
                case "Field12":
                    AutoCompleteTextbox3 textBoxExtended12 = (AutoCompleteTextbox3)pnlInfo.Controls["Field12"];
                    Njit.Program.Controls.TextBoxExtended textBoxExtended11 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field11"];
                    textBoxExtended11.Text = value.FirstOrDefault().Key.ToString();
                    textBoxExtended12.Text = value.FirstOrDefault().Value.ToString();
                    ListOnvan = NewData;

                    textBoxExtended12.AutoCompleteList = ListOnvan.Values.ToList();
                    textBoxExtended12.SelectItem();
                    textBoxExtended12.SelectionStart = textBoxExtended12.SelectionStart;
                    textBoxExtended12.SelectionLength = 0;
                    
                    break;
                case "Field14":
                    AutoCompleteTextbox3 textBoxExtended14 = (AutoCompleteTextbox3)pnlInfo.Controls["Field14"];
                    Njit.Program.Controls.TextBoxExtended textBoxExtended13 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field13"];
                    textBoxExtended13.Text = value.FirstOrDefault().Key.ToString();
                    textBoxExtended14.Text = value.FirstOrDefault().Value.ToString();
                    ListEghdam = NewData;

                    textBoxExtended14.AutoCompleteList = ListEghdam.Values.ToList();
                    textBoxExtended14.SelectItem();
                    textBoxExtended14.SelectionStart = textBoxExtended14.SelectionStart;
                    textBoxExtended14.SelectionLength = 0;
                    
                    break;
                default:
                    break;
            }

        }
        #endregion
        //دکمه های شورت کات ShortCutKeys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                btnPrint_Click(c1SplitButton1, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F1))
            {
                AutoCompleteTextbox3 textBoxExtended10 = (AutoCompleteTextbox3)pnlInfo.Controls["Field10"];
                Njit.Program.Controls.TextBoxExtended textBoxExtended9 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field9"];
                if (textBoxExtended10.Focused || textBoxExtended9.Focused)
                {
                    DocumentField f = new DocumentField();
                    this.SendDataToFormDocumentField += new SendDataToDocumentField(f.getData);
                    SendDataToFormDocumentField(ListMokhatab, "Field10");//Field10=مخاطب
                    f.SentDataToForm += GetDataFromFormDocumentField;
                    f.ShowDialog();
                    SendDataToFormDocumentField = null;

                    //MokhatabinDataGridView();
                    _FieldSelect = 1;
                    return true;
                }
                AutoCompleteTextbox3 textBoxExtended12 = (AutoCompleteTextbox3)pnlInfo.Controls["Field12"];
                Njit.Program.Controls.TextBoxExtended textBoxExtended11 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field11"];
                if (textBoxExtended12.Focused || textBoxExtended11.Focused)
                {
                    DocumentField f = new DocumentField();
                    this.SendDataToFormDocumentField += new SendDataToDocumentField(f.getData);
                    SendDataToFormDocumentField(ListOnvan, "Field12");//Field12=عنوان نامه
                    f.SentDataToForm += GetDataFromFormDocumentField;
                    f.ShowDialog();
                    SendDataToFormDocumentField = null;


                    _FieldSelect = 2;
                    return true;
                }
                AutoCompleteTextbox3 textBoxExtended14 = (AutoCompleteTextbox3)pnlInfo.Controls["Field14"];
                Njit.Program.Controls.TextBoxExtended textBoxExtended13 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field13"];
                if (textBoxExtended14.Focused || textBoxExtended13.Focused)
                {
                    DocumentField f = new DocumentField();
                    this.SendDataToFormDocumentField += new SendDataToDocumentField(f.getData);
                    SendDataToFormDocumentField(ListEghdam, "Field14");//Field14=اقدام کننده
                    f.SentDataToForm += GetDataFromFormDocumentField;
                    f.ShowDialog();
                    SendDataToFormDocumentField = null;

                    //  EghdamDataGridView3();
                    _FieldSelect = 3;
                    return true;
                }
            }
            //if (keyData == (Keys.F2))
            //{
            //    if (btnSaveInfo.Visible == false)
            //    {
            //        PersianMessageBox.Show("برای دسترسی به این دکمه باید ابتدا یک سند را 'انتخاب' و سپس دکمه 'ویرایش اطلاعات' را انتخاب کنید");
            //        return true;
            //    }
            //    else
            //    {
            //        _FieldSelect = 2;
            //        OnvanDataGridView2();
            //        return true;
            //    }
            //}
            //if (keyData == (Keys.F3))
            //{
            //    if (btnSaveInfo.Visible == false)
            //    {
            //        PersianMessageBox.Show("برای دسترسی به این دکمه باید ابتدا یک سند را 'انتخاب' و سپس دکمه 'ویرایش اطلاعات' را انتخاب کنید");
            //        return true;
            //    }
            //    else
            //    {
            //        _FieldSelect = 3;
            //        EghdamDataGridView3();
            //        return true;
            //    }
            //}
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSaveInfo_Click(btnSaveInfo, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.E))
            {
                btnScan_Click(btnScan, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                btnNewDossier_Click(btnNewDossier, EventArgs.Empty);
                return true;
            }
            //if (keyData == (Keys.Control | Keys.C))
            //{
            //    btnCopyDocument_Click(btnCopyDocument, EventArgs.Empty);
            //    return true;
            //}
            //if (keyData == (Keys.Control | Keys.X))
            //{
            //    btnMoveDocument_Click(btnMoveDocument, EventArgs.Empty);
            //    return true;
            //}
            //if (keyData == Keys.F4)
            //{
            //    btnNewDossier_Click(btnNewDossier, EventArgs.Empty);
            //    return true;
            //}
            if (keyData == (Keys.Control | Keys.Q))
            {
                c1SplitButton3.PerformClick();
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
            ////لیست مخاطب نامه اقدام کننده و عنوان نامه 
            GetDataFromDatabase_Shomare_Mokhatabt_Onvan();
            //اطلاعات سمت راست را نمایش می دهد
            Insert_DocumentsFileds_In_Panel_Right();

            Insert_Data_Mokhatabin_Onvan_Eghdam();
            //نمایش اسناد این پرونده
            LoadDocuments_IN_Left_Panle();
            //فوکوس کردن بروی شماره پرونده
            Njit.Program.Controls.TextBoxExtended textBoxExtended = pnlInfo.Controls.Find("Field4", true).FirstOrDefault() as Njit.Program.Controls.TextBoxExtended;
            textBoxExtended.Focus();
            //نمایش شماره اسناد 
            LoadShomareName();
            //نمایش اطلاعات سند انتخاب شده
            ShowCurrentDocumentInfo();
        }



        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            ProgramEvents.DocumentsChanged -= ProgramEvents_DocumentsChanged;
        }
        private void ProgramEvents_DocumentsChanged(object sender, EventArgs e)
        {
            LoadDocuments_IN_Left_Panle();
            SetCurrentDocument();
        }

        #region create objects in Panle info
        private void Insert_DocumentsFileds_In_Panel_Right()
        {
            foreach (Control item in pnlInfo.Controls)
            {
                item.Dispose();
            }

            DrowObjects(Controller.Archive.ArchiveTabController.GetName("Document2"));

        }
        //نمایش مخاطب ، عنوان و اقدام کننده
        private void Insert_Data_Mokhatabin_Onvan_Eghdam()
        {
            foreach (Control control in pnlInfo.Controls)
            {


                if (control.Name == "Field10")
                {
                    AutoCompleteTextbox3 textBoxAuto = (AutoCompleteTextbox3)control;
                    textBoxAuto.AutoCompleteList = ListMokhatab.Values.ToList();
                    textBoxAuto.SelectItem();
                    textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
                    textBoxAuto.SelectionLength = 0;
                }
                else if (control.Name == "Field12")
                {
                    AutoCompleteTextbox3 textBoxAuto = (AutoCompleteTextbox3)control;
                    textBoxAuto.AutoCompleteList = ListOnvan.Values.ToList();
                    textBoxAuto.SelectItem();
                    textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
                    textBoxAuto.SelectionLength = 0;
                }
                else if (control.Name == "Field14")
                {
                    AutoCompleteTextbox3 textBoxAuto = (AutoCompleteTextbox3)control;
                    textBoxAuto.AutoCompleteList = ListEghdam.Values.ToList();
                    textBoxAuto.SelectItem();
                    textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
                    textBoxAuto.SelectionLength = 0;
                }
                else if (control.Name == "Field9")
                {
                    Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                    textBoxExtended.KeyDown += textBoxExtended_TextChanged9;
                }
                else if (control.Name == "Field11")
                {
                    Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                    textBoxExtended.KeyDown += textBoxExtended_TextChanged11;
                }
                else if (control.Name == "Field13")
                {
                    Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                    textBoxExtended.KeyDown += textBoxExtended_TextChanged13;
                }
            }
        }
        private void DrowObjects(Model.Archive.ArchiveTab archiveTab)
        {
            List<Model.Archive.ArchiveField> archiveFields = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
            if (archiveFields.Count == 0)
                return;
            int Distance = 0;
            int StartPointLabel_X = 280;
            int StartPointLabel_Y = 10;
            int StartPointControl_X = 1;
            int StartPointControl_Y = 5;
            foreach (Model.Archive.ArchiveField field in archiveFields)
            {
                CreateObject(archiveTab.Name, field, StartPointLabel_X, StartPointLabel_Y + Distance * 35, StartPointControl_X, StartPointControl_Y + Distance * 35);
                Distance++;
                if (field.BoxTypeCode == (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی)
                {
                    Distance += 4;
                }
                if (field.FieldTypeCode == (int)Enums.FieldTypes.متن_طولانی)
                {
                    Distance += 3;
                }
            }
        }
        private void CreateObject(string TabPageName, Model.Archive.ArchiveField CurrentField, int XLabel, int YLabel, int XText, int YText)
        {
            try
            {
                #region CreateLable
                if (CurrentField.BoxTypeCode != (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی && CurrentField.BoxTypeCode != (int)Enums.BoxTypes.کادر_انتخاب)
                {
                    //اگر کد کاربربود نمایش نده
                    if (CurrentField.FieldName != "Field17" && CurrentField.FieldName != "Field16" && CurrentField.FieldName != "Field10" && CurrentField.FieldName != "Field12" && CurrentField.FieldName != "Field14")
                    {
                        Label label = DossierFormHelper.CreateLabel(CurrentField.Label, XLabel, YLabel);
                        if (CurrentField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد)
                        { label.ForeColor = Color.Red; }
                        label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        label.Size = new Size(80, 20);
                        pnlInfo.Controls.Add(label);
                    }
                }
                if (CurrentField.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد)
                {

                    //اگر کد کاربربود نمایش نده
                    if (CurrentField.FieldName != "Field17" && CurrentField.FieldName != "Field16" && CurrentField.FieldName != "Field10" && CurrentField.FieldName != "Field12" && CurrentField.FieldName != "Field14")
                    {
                        Label label = DossierFormHelper.CreateLabelStar(XLabel - 70, YLabel);
                        label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        pnlInfo.Controls.Add(label);
                    }

                }
                else if (CurrentField.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد)
                {
                    //اگر کد کاربر و تاریخ بروزرسانی باشد نمایش نده
                    if (CurrentField.FieldName != "Field17" && CurrentField.FieldName != "Field16" && CurrentField.FieldName != "Field10" && CurrentField.FieldName != "Field12" && CurrentField.FieldName != "Field14")
                    {
                        Label label = DossierFormHelper.CreateLabelStar(XLabel, YLabel);
                        label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        label.ForeColor = Color.Green;
                        pnlInfo.Controls.Add(label);
                    }
                }
                #endregion End CretaeLable

                switch (CurrentField.BoxTypeCode)
                {
                    case (int)Enums.BoxTypes.کادر_متن:
                        Njit.Program.Controls.TextBoxExtended textBoxExtended = DossierFormHelper.CreateTextBox(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                        textBoxExtended.Size = new Size(270, 20);

                        textBoxExtended.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        //اگر کد کاربر و تاریخ بروزرسانی باشد
                        if (CurrentField.FieldName == "Field17" || CurrentField.FieldName == "Field16")
                        {
                            textBoxExtended.Visible = false;
                        }

                        #region شماره پرونده

                        if (CurrentField.FieldName == "Field4")
                        {
                            textBoxExtended.Text = this.PersonnelNumber;
                            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                            autoCompleteStringCollection.AddRange(Controller.Archive.DossierController.GetAllPersonnelNumbers());
                            textBoxExtended.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            textBoxExtended.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            textBoxExtended.AutoCompleteCustomSource = autoCompleteStringCollection;
                            textBoxExtended.KeyDown += txtPersonnelNumber_KeyDown;
                            pnlInfo.Controls.Add(textBoxExtended);
                            break;

                        }
                        #endregion
                        #region نام_و_نام_خانوادگی
                        if (CurrentField.FieldName == "Field5")
                        {
                            AutoCompleteTextbox3 txtName = DossierFormHelper.CreateAutoTextBox3(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                            //اضافه کردن تمام نام و نام خانوادگی ها
                            txtName.AutoCompleteList = listNameNN.Select(q => q.NameAndFamily).ToList();

                            txtName.Size = new Size(270, 20);
                            txtName.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            object obj = SqlHelper.GetArchiveFieldValue("Dossier1", "Field1", this.PersonnelNumber);
                            if (obj != null)
                            {
                                txtName.Text = obj.ToString();
                                object obj2 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field2", this.PersonnelNumber);
                                if (obj2 != null)
                                {
                                    txtName.Text += " " + obj2.ToString();
                                }
                            }
                            txtName.KeyDown += txtName_KeyDown;
                            pnlInfo.Controls.Add(txtName);
                            break;
                        }
                        #endregion
                        #region کد ملی
                        if (CurrentField.FieldName == "Field6")
                        {
                            AutoCompleteTextbox3 txtNN = DossierFormHelper.CreateAutoTextBox3(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                            txtNN.AutoCompleteList = listNameNN.Select(q => q.NN).ToList();
                            txtNN.Size = new Size(270, 20);
                            txtNN.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            txtNN.KeyDown += keyDown_NN;
                            object obj = SqlHelper.GetArchiveFieldValue("Dossier1", "Field15", this.PersonnelNumber);
                            if (obj != null)
                            {
                                txtNN.Text = obj.ToString();
                            }
                            pnlInfo.Controls.Add(txtNN);
                            break;
                        }
                        #endregion
                        #region شماره نامه
                        //شماره نامه
                        if (CurrentField.FieldName == "Field7")
                        {

                            AutoCompleteTextbox textBoxAuto = DossierFormHelper.CreateAutoTextBox(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                            textBoxAuto.Size = new Size(270, 20);
                            textBoxAuto.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            textBoxAuto.KeyDown += KeyDown_ShomareName;
                            pnlInfo.Controls.Add(textBoxAuto);
                            break;
                        }
                        #endregion
                        //اگر مخاطب نامه و اقدام کننده و عنوان نامه باشد اندازش کوجک بشه
                        if (CurrentField.FieldName == "Field9" || CurrentField.FieldName == "Field11" || CurrentField.FieldName == "Field13")
                        {
                            textBoxExtended.Size = new Size(100, 100);
                            textBoxExtended.Anchor = AnchorStyles.Left;
                            textBoxExtended.Location = new System.Drawing.Point(171, YText);
                        }
                        textBoxExtended.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        if (CurrentField.AutoComplete)
                        {
                            textBoxExtended.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            textBoxExtended.AutoCompleteMode = AutoCompleteMode.Append;
                            textBoxExtended.AutoCompleteCustomSource.AddRange(SqlHelper.GetAllFieldValues(TabPageName, CurrentField.FieldName));
                        }
                        pnlInfo.Controls.Add(textBoxExtended);
                        break;
                    case (int)Enums.BoxTypes.کادر_ورود_تاریخ:

                        Njit.Program.Controls.DateControl dateControl = DossierFormHelper.CreateDateBox(CurrentField, XText, YText);
                        dateControl.Size = new Size(270, 20);
                        dateControl.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                        dateControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        //dateControl.TextChanged += new EventHandler(Controls_TextChanged);
                        //اگر کد کاربر و تاریخ امروز باشد نمایش نده
                        if (CurrentField.FieldName == "Field17" || CurrentField.FieldName == "Field16")
                        {
                            dateControl.Visible = false;
                        }
                        pnlInfo.Controls.Add(dateControl);

                        break;

                    case (int)Enums.BoxTypes.کادر_بازشو:

                        if (CurrentField.FieldName == "Field10")
                        {
                            //زمانی که مخاطب نامه باشد
                            AutoCompleteTextbox3 textBoxAuto = DossierFormHelper.CreateAutoTextBox3(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                            textBoxAuto.Size = new Size(270, 20);
                            textBoxAuto.ForeColor = System.Drawing.Color.Blue;
                            textBoxAuto.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            textBoxAuto.KeyDown += textBox_SelectedIndexChanged10;
                            textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
                            textBoxAuto.SelectionLength = 0;
                            pnlInfo.Controls.Add(textBoxAuto);
                        }
                        else if (CurrentField.FieldName == "Field12")
                        {
                            //عنوان نامه باشد
                            AutoCompleteTextbox3 textBoxAuto = DossierFormHelper.CreateAutoTextBox3(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                            textBoxAuto.Size = new Size(270, 20);
                            textBoxAuto.ForeColor = System.Drawing.Color.Blue;
                            textBoxAuto.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            textBoxAuto.KeyDown += comboBoxExtended_SelectedIndexChanged12;
                            textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
                            textBoxAuto.SelectionLength = 0;
                            pnlInfo.Controls.Add(textBoxAuto);
                        }
                        else if (CurrentField.FieldName == "Field14")
                        {
                            //افدام کننده
                            AutoCompleteTextbox3 textBoxAuto = DossierFormHelper.CreateAutoTextBox3(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                            textBoxAuto.Size = new Size(270, 20);
                            textBoxAuto.ForeColor = System.Drawing.Color.Blue;
                            textBoxAuto.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            textBoxAuto.KeyDown += comboBoxExtended_SelectedIndexChanged14;
                            textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
                            textBoxAuto.SelectionLength = 0;
                            pnlInfo.Controls.Add(textBoxAuto);
                        }
                        else
                        {
                            Njit.Program.Controls.ComboBoxExtended comboBoxExtended = DossierFormHelper.CreateComboBox(CurrentField, XText, YText);
                            comboBoxExtended.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                            comboBoxExtended.Size = new Size(270, 20);
                            //comboBoxExtended.TextChanged += new EventHandler(Controls_TextChanged);
                            //زمانی که بروی دکمه دسترسی کلیک بکند باید دکمه ذخیره عملگرها بزند
                            if (CurrentField.FieldName == "Field18")
                            {
                                comboBoxExtended.KeyDown += comboBoxExtended_KeyDown;
                            }
                            pnlInfo.Controls.Add(comboBoxExtended);
                        }
                        break;
                    case (int)Enums.BoxTypes.کادر_انتخاب:
                        CheckBox checkBox = DossierFormHelper.CreateChekBox(CurrentField, XLabel, YLabel);
                        checkBox.Size = new Size(270, 20);
                        pnlInfo.Controls.Add(checkBox);
                        break;
                    case (int)Enums.FieldTypes.ساعت:
                        Njit.Program.Controls.TimeControl timeControl = DossierFormHelper.CreateTimeBox(CurrentField, XText, YText);
                        timeControl.Size = new Size(270, 20);
                        pnlInfo.Controls.Add(timeControl);
                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی:
                        Njit.Program.Controls.DataGridViewExtended dataGridViewExtended = DossierFormHelper.CreateDataGridView(CurrentField);
                        dataGridViewExtended.Size = new Size(270, 120);
                        dataGridViewExtended.Location = new Point(5, 20);
                        dataGridViewExtended.Rows.CollectionChanged += Rows_CollectionChanged;
                        dataGridViewExtended.CurrentCellChanged += DataGridView_CurrentCellChanged;

                        GroupBox groupBox = DossierFormHelper.CreateGroupBox(CurrentField, YText);
                        groupBox.Size = new Size(270, 270);
                        groupBox.Padding = new System.Windows.Forms.Padding(8);
                        groupBox.Location = new Point(20, YText);
                        groupBox.Controls.Add(dataGridViewExtended);
                        dataGridViewExtended.Dock = DockStyle.Fill;
                        pnlInfo.Controls.Add(groupBox);
                        break;
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا در بارگذاری اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        public string SafeFarsiStr(string input)
        {
            return input.Replace("ی", "ی").Replace("ک", "ک").Replace("ي", "ی");
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
        #endregion

        #region Show List<Mokhatabin,Eghdam,Onvan>
        private Dictionary<string, string> ListMokhatab;
        private Dictionary<string, string> ListEghdam;
        private Dictionary<string, string> ListOnvan;
        private Dictionary<string, string> ListShomareName;
        /// <summary>
        /// لیست مخاطب نامه و اقدام کننده و شماره نامه را به ما میدهد
        /// </summary>
        private void GetDataFromDatabase_Shomare_Mokhatabt_Onvan()
        {
            ListMokhatab = new Dictionary<string, string>();
            ListOnvan = new Dictionary<string, string>();
            ListEghdam = new Dictionary<string, string>();

            System.Data.DataTable listRow = SqlHelper.GetField("Field10");
            if (listRow.Rows.Count > 0)
            {

                for (int i = 0; i < listRow.Rows.Count; i++)
                {
                    ListMokhatab.Add(listRow.Rows[i][0].ToString(), SafeFarsiStr(listRow.Rows[i][1].ToString()));
                }
            }
            System.Data.DataTable listRow2 = SqlHelper.GetField("Field12");
            if (listRow2.Rows.Count > 0)
            {

                for (int i = 0; i < listRow2.Rows.Count; i++)
                {
                    ListOnvan.Add(listRow2.Rows[i][0].ToString(), SafeFarsiStr(listRow2.Rows[i][1].ToString()));
                }
            }
            System.Data.DataTable listRow3 = SqlHelper.GetField("Field14");
            if (listRow3.Rows.Count > 0)
            {

                for (int i = 0; i < listRow3.Rows.Count; i++)
                {
                    ListEghdam.Add(listRow3.Rows[i][0].ToString(), SafeFarsiStr(listRow3.Rows[i][1].ToString()));
                }
            }
        }
        #endregion

        #region Show Left images
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
        /// <summary>
        /// لود اطلاعات در سمت چپ
        /// </summary>
        /// <returns></returns>
        private bool LoadDocuments_IN_Left_Panle()
        {
            if (this.PersonnelNumber != "")
                if (this.PersonnelNumber != null)
                {
                    this.SelectedDossier = Controller.Archive.DossierController.Select(this.PersonnelNumber);
                    if (!isAccessPermission(this.SelectedDossier))
                    {
                        PersianMessageBox.Show(this, string.Format("مجوز دسترسی به پرونده های با سطح دسترسی '{0}' برای شما صادر نشده است", SelectedDossier.DossierType.Title));
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



        private void loadNameFamilyNN()
        {
            Njit.Program.Controls.TextBoxExtended txtPN = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field4"];
            AutoCompleteTextbox3 txtName = (AutoCompleteTextbox3)pnlInfo.Controls["Field5"];
            AutoCompleteTextbox3 txtNN = (AutoCompleteTextbox3)pnlInfo.Controls["Field6"];
            txtName.Text = "";
            txtNN.Text = "";
            txtPN.Text = "";
            DossierWithNamNNFamilyPersonnelNumber dn = listNameNN.Where(q => q.PersonnelNumber == this.PersonnelNumber).FirstOrDefault();
            if (dn != null)
            {
                txtName.Text = dn.NameAndFamily;
                txtName.SelectItem();

                txtNN.Text = dn.NN;
                txtNN.SelectItem();

                txtPN.Text = dn.PersonnelNumber;
            }

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
        private void imageListView_RetrieveVirtualItemThumbnail(object sender, Njit.ImageListView.VirtualItemThumbnailEventArgs e)
        {
            if (_ScrollEventType == null || (_ScrollEventType.HasValue && CanRefreshThumbs(_ScrollEventType.Value)))
                e.ThumbnailImage = Controller.Archive.DocumentController.GetDocumentThumb(e.Key as Model.Archive.Document);
        }
        //مجوز دسترس به پرونده را دارد یا خیر 
        private bool isAccessPermission(Model.Archive.Dossier dossier)
        {
            if (dossier != null)
            {
                //اگر ادمین باشد نیازی نیست
                if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
                    return true;
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                //لیست نوع دسترسی
                List<Model.Common.PermissionDossier> listSecurity = dc.PermissionDossiers.Where(q => q.User.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID).ToList();
                return listSecurity.Exists(q => q.DossierType == dossier.DossierSecurityID);
            }
            else { return false; }
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
                        //Access Permissinon title 
                        if (!listTitle.Any(q => tempDataTable.Rows[0]["Field11"].ToString() == q.PK_TitleORField11.ToString()))
                        {
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
        private void LoadDocument(Model.Archive.Document doc)
        {
            lock (imageListView)
            {
                imageListView.Items.Add(doc, doc.ParentDocumentID.HasValue ? Controller.Archive.DocumentController.GetDocument(doc.ParentDocumentID.Value).Index.ToString() + "_" + doc.Index : doc.Index.ToString());
            }
        }
        #endregion

        #region Full Screen Image
        View.ImageView documentView;
        string tempFile;
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
            if (CurrentDocument != null)
            {
                //پاک کردن اطلاعات قبلی
                errorProvider.Clear();
                ResetValuePnlInfo();
                Document doc = new Document();
                doc = this._CurrentDocument;
                LoadDocuments_IN_Left_Panle();
                this._CurrentDocument = doc;
                if (doc.ParentDocumentID != null)
                {
                    _CurrentDocument = doc.Document1;
                }
                //لود اطلاعات
                ShowCurrentDocumentInfo();
                ////انتخاب منوی آبشاری 
                SelectItem_Mokhatab_Eghdam_Onvan();

            }

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

            this.CurrentDocument = e.Item.VirtualItemKey as Model.Archive.Document;
            ShowImage_In_Center_Panel();

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
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void Reset_Left_And_Center_Image()
        {
            imageListView.Items.Clear();
            _CurrentDocument = null;
            kpImageViewer1.Image = global::NjitSoftware.Properties.Resources.Document;

        }
        private void ResetValuePnlInfo()
        {

            lblDocNumber.Text = "0:تعداد اسناد پرونده:";
            foreach (Control control in pnlInfo.Controls)
            {
                if (control.Name != "Field4" && control.Name != "Field5" && control.Name != "Field6" && control.Name != "Field16" && control.Name != "Field17")
                {
                    if (control is Njit.Program.Controls.TextBoxExtended)
                    {

                        Njit.Program.Controls.TextBoxExtended textbox = control as Njit.Program.Controls.TextBoxExtended;

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
                    else if (control is Njit.Program.Controls.ComboBoxExtended)
                    {
                        Njit.Program.Controls.ComboBoxExtended comboBox = control as Njit.Program.Controls.ComboBoxExtended;

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
                    else if (control is Njit.Program.Controls.DateControl)
                    {
                        Njit.Program.Controls.DateControl dateControl = control as Njit.Program.Controls.DateControl;

                        if (dateControl.Value != null && dateControl.Value is Model.Archive.ArchiveField)
                        {
                            Model.Archive.ArchiveField field = dateControl.Value as Model.Archive.ArchiveField;
                            dateControl.Text = field.DefaultValue;

                        }
                        else
                            dateControl.Text = "";

                    }
                    else if (control is Njit.Program.Controls.TimeControl)
                    {
                        Njit.Program.Controls.TimeControl timeControl = control as Njit.Program.Controls.TimeControl;

                        if (timeControl.Value != null && timeControl.Value is Model.Archive.ArchiveField)
                        {
                            Model.Archive.ArchiveField field = timeControl.Value as Model.Archive.ArchiveField;
                            timeControl.Text = field.DefaultValue;
                        }
                        else
                            timeControl.Text = "";

                    }
                    else if (control is AutoCompleteTextbox)
                    {
                        AutoCompleteTextbox textBoxAuto = (AutoCompleteTextbox)control;
                        textBoxAuto.Text = "";
                        textBoxAuto.SelectedIndex = -1;
                    }
                    else if (control is AutoCompleteTextbox3)
                    {
                        AutoCompleteTextbox3 textBoxAuto = (AutoCompleteTextbox3)control;
                        textBoxAuto.Text = "";
                        textBoxAuto.SelectedIndex = -1;
                    }
                }

            }
        }

        private void SelectItem_Mokhatab_Eghdam_Onvan()
        {
            //foreach (Control control in pnlInfo.Controls)
            //{
            //    if (control.Name == "Field10")
            //    {
            //        AutoCompleteTextbox3 textBoxAuto = (AutoCompleteTextbox3)control;
            //        textBoxAuto.SelectItem();
            //        textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
            //        textBoxAuto.SelectionLength = 0;
            //    }
            //    else if (control.Name == "Field12")
            //    {
            //        AutoCompleteTextbox3 textBoxAuto = (AutoCompleteTextbox3)control;
            //        textBoxAuto.SelectItem();
            //        textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
            //        textBoxAuto.SelectionLength = 0;
            //    }
            //    else if (control.Name == "Field14")
            //    {
            //        AutoCompleteTextbox3 textBoxAuto = (AutoCompleteTextbox3)control;
            //        textBoxAuto.SelectItem();
            //        textBoxAuto.SelectionStart = textBoxAuto.SelectionStart;
            //        textBoxAuto.SelectionLength = 0;
            //    }
            //}
        }
        private void SetCurrentDocument()
        {
            if (imageListView.SelectedItems.Count == 1)
                _CurrentDocument = Controller.Archive.DocumentController.GetDocument((imageListView.SelectedItems[0].VirtualItemKey as Model.Archive.Document).ID);
            else
                _CurrentDocument = null;
        }
        private void ShowCurrentDocumentInfo()
        {

            if (CurrentDocument == null)
                return;
            if (CurrentDocument.ArchiveTabID.IsNullOrEmpty())
                return;
            Controller.Archive.DocumentController.LoadArchiveTabDataToControls(pnlInfo, Controller.Archive.ArchiveTabController.GetName("Document2"), CurrentDocument);

        }
        #endregion

        #region Change Boxes


        private void loadNumberofDocument(string personnelNumber)
        {
            if (_CurrentDocument == null)
                lblDocNumber.Text = "تعداد اسناد پرونده:" + Controller.Archive.DocumentController.GetNumberOfDocument(personnelNumber);

        }
        /// <summary>
        /// لود کردن شماره نامه
        /// </summary>
        private void LoadShomareName()
        {
            if (this.PersonnelNumber != "")
                if (this.PersonnelNumber != null)
                {

                    //نمایش اوتو کامپلیت شماره اسناد
                    ListShomareName = new Dictionary<string, string>();

                    System.Data.DataTable listRow = SqlHelper.GetListShomareName(this.PersonnelNumber);
                    if (listRow.Rows.Count > 0)
                    {

                        for (int i = 0; i < listRow.Rows.Count; i++)
                        {
                            ListShomareName.Add(listRow.Rows[i][0].ToString(), listRow.Rows[i][1].ToString());
                        }
                    }
                    //نمایش لیست شماره نامه های این پرونده
                    AutoCompleteTextbox textBoxAuto = (AutoCompleteTextbox)pnlInfo.Controls["Field7"];
                    textBoxAuto.AutoCompleteList = ListShomareName.Values.ToList();
                    textBoxAuto.SelectItem();
                }
        }
        private void LoadShomareName2()
        {
            if (this.PersonnelNumber != "")
                if (this.PersonnelNumber != null)
                {

                    //نمایش اوتو کامپلیت شماره اسناد
                    ListShomareName = new Dictionary<string, string>();

                    System.Data.DataTable listRow = SqlHelper.GetListShomareName(this.PersonnelNumber);
                    if (listRow.Rows.Count > 0)
                    {

                        for (int i = 0; i < listRow.Rows.Count; i++)
                        {
                            ListShomareName.Add(listRow.Rows[i][0].ToString(), listRow.Rows[i][1].ToString());
                        }
                    }

                }
        }
        private void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((sender as Njit.Program.Controls.DataGridViewExtended).Parent as Control, null);
        }
        private void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Add || e.Action == CollectionChangeAction.Remove)
                errorProvider.SetError(sender as Control, null);
        }


        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        void textBoxExtended_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Control control in pnlInfo.Controls)
            {
                if (control.Name == "Field8")
                {

                    foreach (Control control2 in pnlInfo.Controls)
                    {
                        if (control2.Name == "Field9")
                        {
                            control.Focus();
                        }
                    }
                }
            }
        }

        //زمانی که کد دسترسی تغییر پیدا کند باید روی دکمه ذخیره برود
        void comboBoxExtended_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveInfo.PerformClick();
            }
        }
        //شماره نامه تغییر کند
        void KeyDown_ShomareName(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoCompleteTextbox txtShomareName = (AutoCompleteTextbox)pnlInfo.Controls["Field7"];
                if (txtShomareName.Text != "")
                {
                    string docId = "";
                    try
                    {
                        docId = ListShomareName.Where(q => q.Value == txtShomareName.Text && q.Value.Length == txtShomareName.Text.Length).FirstOrDefault().Key;

                        if (!string.IsNullOrEmpty(docId))
                        {
                            //پاک کردن اطلاعات قبلی
                            ResetValuePnlInfo();
                            Reset_Left_And_Center_Image();

                            errorProvider.Clear();
                            //گرفتن سند انتخابی
                            _CurrentDocument = Controller.Archive.DocumentController.GetDocument(Convert.ToInt32(docId));
                            Document doc = new Document();
                            doc = this._CurrentDocument;
                            this._CurrentDocument = doc;
                            if (doc.ParentDocumentID != null)
                            {
                                _CurrentDocument = doc.Document1;
                            }

                            LoadDocuments_IN_Left_Panle();
                            ShowImage_In_Center_Panel();
                            //لود اطلاعات
                            ShowCurrentDocumentInfo();
                            ////انتخاب منوی آبشاری 
                            SelectItem_Mokhatab_Eghdam_Onvan();
                            //برود سراغ بعدی
                            Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                            e.SuppressKeyPress = true;
                            e.Handled = true;
                        }
                        else
                        {
                            if (_CurrentDocument == null)
                            {
                                ResetValuePnlInfo();
                                Reset_Left_And_Center_Image();
                            }
                        }
                    }
                    catch { }
                }


            }
        }
        //شماره پرونده تغییر کند

        private void txtPersonnelNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _CurrentDocument = null;
                //ابتدا شماره پرونده ارسال شده را مشخص می کنم
                var Field4 = "";
                Njit.Program.Controls.TextBoxExtended txtPersonnelNumber = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field4"];
                if (txtPersonnelNumber.Text != "")
                    Field4 = txtPersonnelNumber.Text;

                //لود اطلاعات پرونده دیگر
                if (listNameNN.Any(q => q.PersonnelNumber == Field4))
                {
                    ResetValuePnlInfo();
                    Reset_Left_And_Center_Image();
                    //رفتن سراغ نام خانوادگی
                    AutoCompleteTextbox3 txt5 = (AutoCompleteTextbox3)pnlInfo.Controls["Field5"];
                    txt5.Focus();
                    this.PersonnelNumber = Field4;
                    this.SelectedDossier = Controller.Archive.DossierController.Select(this.PersonnelNumber);
                    //نمایش نام و نام خانوادگی و کد ملی
                    loadNameFamilyNN();
                    //نمایش تعداد اسناد پرونده
                    loadNumberofDocument(this.PersonnelNumber);
                    //نمایش شماره اسناد 
                    LoadShomareName();
                }
                // اگر پرونده مورد نظر پیدا نشد
                else
                {
                    //رفتن سراغ نام خانوادگی
                    AutoCompleteTextbox3 txt5 = (AutoCompleteTextbox3)pnlInfo.Controls["Field5"];
                    txt5.Focus();
                    txtPersonnelNumber.Text = "";
                    this.PersonnelNumber = "";
                    ResetValuePnlInfo();
                    Reset_Left_And_Center_Image();
                    AutoCompleteTextbox3 txtName = (AutoCompleteTextbox3)pnlInfo.Controls["Field5"];
                    AutoCompleteTextbox3 txtNN = (AutoCompleteTextbox3)pnlInfo.Controls["Field6"];
                    txtName.Text = "";
                    txtNN.Text = "";

                }
            }
        }
        //نام و نام خانوادگی تغییر کند
        void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                AutoCompleteTextbox3 txtName = (AutoCompleteTextbox3)pnlInfo.Controls["Field5"];
                DossierWithNamNNFamilyPersonnelNumber dn = listNameNN.Where(q => q.NameAndFamily == txtName.Text).FirstOrDefault();
                if (dn != null)
                {
                    ResetValuePnlInfo();
                    Reset_Left_And_Center_Image();
                    this.PersonnelNumber = dn.PersonnelNumber;
                    this.SelectedDossier = Controller.Archive.DossierController.Select(this.PersonnelNumber);
                    //نمایش نام و نام خانوادگی و کد ملی
                    loadNameFamilyNN();
                    //نمایش تعداد اسناد پرونده
                    loadNumberofDocument(this.PersonnelNumber);
                    //نمایش شماره اسناد 
                    LoadShomareName();
                    //رفتن سراغ شماره نامه
                    AutoCompleteTextbox3 txtSh_Name = (AutoCompleteTextbox3)pnlInfo.Controls["Field6"];
                    txtSh_Name.Focus();
                }
                // اگر پرونده مورد نظر پیدا نشد
                else
                {

                    this.PersonnelNumber = "";
                    //نمایش نام و نام خانوادگی و کد ملی
                    loadNameFamilyNN();

                    ResetValuePnlInfo();
                    Reset_Left_And_Center_Image();
                    txtName.Focus();

                }


            }
        }
        //کد ملی تغییر کند
        void keyDown_NN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AutoCompleteTextbox3 txtNN = (AutoCompleteTextbox3)pnlInfo.Controls["Field6"];

                if (!string.IsNullOrEmpty(txtNN.Text.Trim()))
                {
                    DossierWithNamNNFamilyPersonnelNumber dn = listNameNN.Where(q => q.NN == txtNN.Text).FirstOrDefault();
                    if (dn != null)
                    {

                        ResetValuePnlInfo();
                        Reset_Left_And_Center_Image();
                        this.PersonnelNumber = dn.PersonnelNumber;
                        this.SelectedDossier = Controller.Archive.DossierController.Select(this.PersonnelNumber);
                        //نمایش نام و نام خانوادگی و کد ملی
                        loadNameFamilyNN();
                        //نمایش تعداد اسناد پرونده
                        loadNumberofDocument(this.PersonnelNumber);
                        //نمایش شماره اسناد 
                        LoadShomareName();
                        //رفتن سراغ شماره نامه
                        AutoCompleteTextbox txtSh_Name = (AutoCompleteTextbox)pnlInfo.Controls["Field7"];
                        txtSh_Name.Focus();
                    }
                    // اگر پرونده مورد نظر پیدا نشد
                    else
                    {

                        this.PersonnelNumber = "";
                        //نمایش نام و نام خانوادگی و کد ملی
                        loadNameFamilyNN();
                        ResetValuePnlInfo();
                        Reset_Left_And_Center_Image();
                        txtNN.Focus();

                    }
                }

            }
        }
        //متن مخاطب را می خواهیم
        void textBoxExtended_TextChanged9(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Field9 = "";
                bool set = false;
                foreach (Control control in pnlInfo.Controls)
                {
                    if (!set)
                        if (control.Name == "Field9")
                        {

                            Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                            if (textBoxExtended.Text != "")
                                Field9 = textBoxExtended.Text;
                            set = true;

                        }
                }
                foreach (Control control in pnlInfo.Controls)
                {
                    if (control.Name == "Field10")
                    {
                        AutoCompleteTextbox3 textBoxExtended = (AutoCompleteTextbox3)control;
                        textBoxExtended.Text = ListMokhatab.FirstOrDefault(x => x.Key == Field9 && x.Key.Length == Field9.Length).Value;
                        textBoxExtended.SelectionStart = textBoxExtended.SelectionStart;
                        textBoxExtended.SelectionLength = 0;
                    }
                }
            }
        }
        // کلید مخاطب را می خواهیم
        void textBox_SelectedIndexChanged10(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Field10 = "";
                bool set = false;
                foreach (Control control in pnlInfo.Controls)
                {
                    if (!set)
                        if (control.Name == "Field10")
                        {

                            AutoCompleteTextbox3 textBoxExtended = (AutoCompleteTextbox3)control;
                            if (textBoxExtended.Text != "")
                                Field10 = textBoxExtended.Text;
                            set = true;

                        }
                }
                foreach (Control control in pnlInfo.Controls)
                {
                    if (control.Name == "Field9")
                    {
                        Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                        textBoxExtended.Text = ListMokhatab.FirstOrDefault(x => x.Value == Field10 && x.Value.Length == Field10.Length).Key;
                    }
                }
            }
        }

        //زمانی که عنوان نامه باشد
        void textBoxExtended_TextChanged11(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Field11 = "";
                bool set = false;
                foreach (Control control in pnlInfo.Controls)
                {
                    if (!set)
                        if (control.Name == "Field11")
                        {

                            Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                            if (textBoxExtended.Text != "")
                                Field11 = textBoxExtended.Text;
                            set = true;

                        }
                }
                foreach (Control control in pnlInfo.Controls)
                {
                    if (control.Name == "Field12")
                    {
                        AutoCompleteTextbox3 textBoxExtended = (AutoCompleteTextbox3)control;
                        textBoxExtended.Text = ListOnvan.FirstOrDefault(x => x.Key == Field11 && x.Key.Length == Field11.Length).Value;
                    }
                }
            }
        }
        void comboBoxExtended_SelectedIndexChanged12(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Field12 = "";
                bool set = false;
                foreach (Control control in pnlInfo.Controls)
                {
                    if (!set)
                        if (control.Name == "Field12")
                        {

                            AutoCompleteTextbox3 textBoxExtended = (AutoCompleteTextbox3)control;
                            if (textBoxExtended.Text != "")
                                Field12 = textBoxExtended.Text;
                            set = true;

                        }
                }
                foreach (Control control in pnlInfo.Controls)
                {
                    if (control.Name == "Field11")
                    {
                        Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                        textBoxExtended.Text = ListOnvan.FirstOrDefault(x => x.Value == Field12 && x.Value.Length == Field12.Length).Key;
                    }
                }
            }
        }

        //زمانی که اقدام کننده باشد
        void textBoxExtended_TextChanged13(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Field13 = "";
                bool set = false;
                foreach (Control control in pnlInfo.Controls)
                {
                    if (!set)
                        if (control.Name == "Field13")
                        {

                            Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                            if (textBoxExtended.Text != "")
                                Field13 = textBoxExtended.Text;
                            set = true;

                        }
                }
                foreach (Control control in pnlInfo.Controls)
                {
                    if (control.Name == "Field14")
                    {
                        AutoCompleteTextbox3 textBoxExtended = (AutoCompleteTextbox3)control;
                        textBoxExtended.Text = ListEghdam.FirstOrDefault(x => x.Key == Field13 && x.Key.Length == Field13.Length).Value;
                        textBoxExtended.SelectionStart = textBoxExtended.SelectionStart;
                        textBoxExtended.SelectionLength = 0;
                    }
                }
            }
        }
        void comboBoxExtended_SelectedIndexChanged14(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Field14 = "";
                bool set = false;
                foreach (Control control in pnlInfo.Controls)
                {
                    if (!set)
                        if (control.Name == "Field14")
                        {

                            AutoCompleteTextbox3 textBoxExtended = (AutoCompleteTextbox3)control;
                            if (textBoxExtended.Text != "")
                                Field14 = textBoxExtended.Text;
                            set = true;

                        }
                }
                foreach (Control control in pnlInfo.Controls)
                {
                    if (control.Name == "Field13")
                    {
                        Njit.Program.Controls.TextBoxExtended textBoxExtended = (Njit.Program.Controls.TextBoxExtended)control;
                        textBoxExtended.Text = ListEghdam.FirstOrDefault(x => x.Value == Field14 && x.Value.Length == Field14.Length).Key;

                    }
                }
            }
        }
        #endregion

        # region Save Info
        private void EnableOrDisableControls(bool status)
        {
            imageListView.Enabled = !status;
            foreach (Control c in pnlInfo.Controls)
            {
                if (c.Name == "Field4")
                {
                    c.Enabled = true;
                    c.Visible = true;
                }
                else if (c.Name == "Field16" || c.Name == "Field17")
                    c.Visible = status;
            }
        }
        private void btnSaveInfo_Click(object sender, EventArgs e)
        {

            try
            {
                if (_CurrentDocument == null)
                {
                    throw new Exception("هیچ سندی انتخاب نشده است");
                }
                AutoCompleteTextbox textBoxExtended7 = (AutoCompleteTextbox)pnlInfo.Controls["Field7"];
                if (string.IsNullOrEmpty(textBoxExtended7.Text))
                {
                    var dialogResult = PersianMessageBox.Show("مقدار شماره نامه وارد نشده است آیا می خواهید مقدار'بدون شماره' ثبت شود", "شماره نامه", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        textBoxExtended7.Text = "بدون شماره";
                    }
                }

                if (ListShomareName.Any(q => q.Value == textBoxExtended7.Text && q.Value.Length == textBoxExtended7.Text.Length))
                {
                    if (ListShomareName.Count(q => q.Value == textBoxExtended7.Text && q.Value.Length == textBoxExtended7.Text.Length) > 1)
                        throw new Exception("شماره نامه ثبت شده تکراری است.");
                    else
                    {
                        if (ListShomareName.Any(q => q.Value == textBoxExtended7.Text && q.Value.Length == textBoxExtended7.Text.Length && q.Key != _CurrentDocument.ID.ToString()))
                            throw new Exception("شماره نامه ثبت شده تکراری است.");
                    }
                }
                Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.GetName("Document2");
                List<Model.Archive.ArchiveField> archiveTabFields = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
                List<System.Data.SqlClient.SqlCommand> sqlCommands = new List<System.Data.SqlClient.SqlCommand>();
                foreach (Control control in pnlInfo.Controls)
                {
                    string ErroreMessage = DossierFormHelper.CheckControlData(this.PersonnelNumber, archiveTab.Name, archiveTabFields, control);
                    if (ErroreMessage != null)
                    {
                        errorProvider.SetError(control, ErroreMessage);
                        return;
                    }
                }
                if (_CurrentDocument.ParentDocumentID != null)
                {
                    _CurrentDocument = Controller.Archive.DocumentController.GetDocument(Convert.ToInt32(_CurrentDocument.ParentDocumentID));
                }
                Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument(this.PersonnelNumber, CurrentDocument.Number);
                if (!document.ArchiveTabID.IsNullOrEmpty())
                {
                    Model.Archive.ArchiveTab ArchiveTabTemp = Controller.Archive.ArchiveTabController.Select(document.ArchiveTabID.Value);
                    if (ArchiveTabTemp.Name != null)
                        sqlCommands.Add(SqlHelper.GetDeleteCommandForArchiveTab(ArchiveTabTemp, document.ID));
                    foreach (var field in Controller.Archive.DossierCacheController.GetArchiveFields(ArchiveTabTemp.ID))
                    {
                        if (field.FieldTypeCode == (int)(Enums.FieldTypes.زیرگروه_جدولی))
                            sqlCommands.Add(SqlHelper.GetDeleteCommandForArchiveField(field, document.ID));
                    }
                }
                document.ArchiveTabID = archiveTab.ID;

                sqlCommands.AddRange(SqlHelper.GetDocumentInsertCommands(pnlInfo, archiveTab, document, this.PersonnelNumber));

                Controller.Archive.DocumentController.UpdateDocument(document, sqlCommands);
                CurrentDocument = document;
                LoadShomareName();
                ShowCurrentDocumentInfo();
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش_اطلاعات_سند, this.PersonnelNumber, "سند شماره:" + textBoxExtended7.Text);

                PersianMessageBox.Show("اطلاعات با موفقیت ویرایش شد");
                EnableOrDisableControls(false);

            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
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
            _CurrentDocument = null;
            //LoadDocuments_IN_Left_Panle();
        }
        #endregion

        #region Add Document
        private void c1SplitButton3_Click(object sender, EventArgs e)
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show("شماره پرونده وارد نشده است");
            }
            else
            {

                AddFiels();
            }
        }
        private void AddDocumentPeyvast_Click(object sender, EventArgs e)
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show("شماره پرونده وارد نشده است");
            }
            else
            {

                if (_CurrentDocument != null)
                {
                    AddPeyvast();
                }
                else
                    PersianMessageBox.Show("سند انتخاب نشده است");
            }
        }

        private void AddFiels()
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.Text.StringBuilder Error = new StringBuilder();
                    foreach (string file in openFileDialog.FileNames)
                    {
                        try
                        {
                            this.SelectedSaveFormat = getFormat(file);
                            SaveDocument(file);
                        }
                        catch (Exception ex)
                        {
                            Error.Append(ex.Message);
                            Error.Append("_");
                        }
                    }
                    NotDataDocument();
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در افزودن اسناد" + "\r\n\r\n" + ex.Message);
                }
            }
        }

        private SaveFormats getFormat(string file)
        {
            System.IO.FileInfo fileInfo = new FileInfo(file);
            switch (fileInfo.Extension)
            {
                case ".pdf":
                    return SaveFormats.OnePdf;
                case ".tif":
                    return SaveFormats.Tiff;
                case ".tiff":
                    return SaveFormats.OneMultiTiff;
                case ".jpg":
                    return SaveFormats.JPEG;
                case ".jpeg":
                    return SaveFormats.JPEG;
                case ".png":
                    return SaveFormats.PNG;
                case ".bmp":
                    return SaveFormats.BMP;
                default:
                    return SaveFormats.JPEG;
            }
        }
        public void SaveDocument(string file)
        {
            Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.GetName("Document2");
            Controller.Archive.DocumentController.AddDocument(this.PersonnelNumber, file, null, false, (Njit.Program.ComponentOne.Enums.SaveFormats)this.SelectedSaveFormat, Njit.Program.ComponentOne.Enums.CompressionTypes.None, archiveTab);
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.اضافه_کردن_سند_به_پرونده, this.PersonnelNumber, file);
        }
        public enum SaveFormats
        {
            None = 0,
            OnePdf = 1,
            Pdf = 2,
            OneMultiTiff = 3,
            Tiff = 4,
            JPEG = 5,
            PNG = 6,
            BMP = 7
        }
        string[] imageExtensions = new string[] { ".bmp", ".jpg", ".jpeg", ".png", ".gif", ".tif", ".tiff" };
        protected SaveFormats SelectedSaveFormat { get; set; }

        #endregion

        #region هنوز اطلاعاتی بهشون داده نشده است
        public void NotDataDocument()
        {
            try
            {
                if (this.SelectedDossier != null)
                    if (!isAccessPermission(this.SelectedDossier))
                    {
                        PersianMessageBox.Show(this, string.Format("مجوز دسترسی به پرونده های با سطح دسترسی '{0}' برای شما صادر نشده است", SelectedDossier.DossierType.Title));
                    }
                imageListView.Items.Clear();
                List<Model.Archive.Document> documents;

                documents = Controller.Archive.DocumentController.GetDocuments(this.PersonnelNumber).ToList();
                documents.RemoveAll(q => q.ParentDocumentID != null);
                foreach (var item in documents.ToList())
                {
                    System.Data.DataTable tempDataTable = SqlHelper.GetDocuments("Document2", item);
                    if (tempDataTable.Rows.Count > 0)
                    {
                        documents.RemoveAll(q => q.ID == item.ID);
                    }
                }
                int documentsCount = documents.Count();
                if (documentsCount > 0)
                {
                    documents = SetAccessPermission(documents.ToList());

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
                this.CurrentDocument = documents.FirstOrDefault();
                ShowImage_In_Center_Panel();
                lblDocNumber.Text = "تعداد اسناد فاقد اطلاعات پرونده:" + documents.Where(q => q.ParentDocumentID == null).Count().ToString();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region AddDocument Menu
        private void c1SplitButton3_DropDownItemClicked(object sender, C1.Win.C1Input.DropDownItemClickedEventArgs e)
        {

            if (e.ClickedItem.Text == "افزودن پیوست به سند انتخابی")
            {
                AddDocumentPeyvast_Click(sender, e);
            }
            else if (e.ClickedItem.Text == "افزودن اسناد")
            {
                btnAdd_Click(sender, e);
            }

            else if (e.ClickedItem.Text == "افزودن فایل جدید به عنوان ضمیمه سند انتخاب شده")
            {
                btnAddAttachmentToDocumnet_Click(sender, e);
            }
            else if (e.ClickedItem.Text == "افزودن فایل جدید به عنوان ضمیمه پرونده")
            {
                btnAddAttachmentToDossier_Click(sender, e);
            }
        }
        private void btnAddAttachmentToDocumnet_Click(object sender, EventArgs e)
        {
            if (imageListView.SelectedItems.Count != 1)
            {
                PersianMessageBox.Show(this, "لطفا یک سند را انتخاب کنید");
                return;
            }
            using (View.ImportFiles f = new ImportFiles(this.PersonnelNumber, (imageListView.SelectedItems[0].VirtualItemKey as Model.Archive.Document).ID))
            {
                f.ShowDialog(this);
            }
        }
        private void btnAddAttachmentToDossier_Click(object sender, EventArgs e)
        {
            using (View.ImportFiles f = new ImportFiles(this.PersonnelNumber, true))
            {
                f.ShowDialog(this);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (View.ImportFiles f = new ImportFiles(this.PersonnelNumber, null))
            {
                f.ShowDialog(this);
            }
        }
        #endregion

        #region Start Peyvast
        //نمایش اسناد پیوست شده به صورت مستقیم
        private void AddPeyvast()
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show("شماره پرونده وارد نشده است");
            }

            else
            {
                if (_CurrentDocument != null)
                {
                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            System.Text.StringBuilder Error = new StringBuilder();
                            foreach (string file in openFileDialog.FileNames)
                            {


                                try
                                {
                                    this.SelectedSaveFormat = getFormat(file);
                                    SaveDocument2(file);
                                }
                                catch (Exception ex)
                                {
                                    Error.Append(ex.Message);
                                    Error.Append("_");
                                }
                            }

                            //نمایش خودش به همراه فرزندانش
                            LoadDocuments_IN_Left_Panle();
                        }
                        catch (Exception ex)
                        {
                            PersianMessageBox.Show(this, "خطا در افزودن اسناد" + "\r\n\r\n" + ex.Message);
                        }
                    }
                    else
                    {
                        LoadDocuments_IN_Left_Panle();
                    }
                }
            }
        }
        public void SaveDocument2(string file)
        {
            Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.GetName("Document2");
            Controller.Archive.DocumentController.AddDocument(this.PersonnelNumber, file, _CurrentDocument.ID, false, (Njit.Program.ComponentOne.Enums.SaveFormats)this.SelectedSaveFormat, Njit.Program.ComponentOne.Enums.CompressionTypes.None, archiveTab);
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.اضافه_کردن_سند_به_پرونده, this.PersonnelNumber, file);
        }
        //پایان اسناد پیوست شده به صورت مستقیم
        #endregion

        #region Print
        private void c1SplitButton1_Click(object sender, EventArgs e)
        {
            btnPrint_Click(sender, e);
        }

        private void c1SplitButton1_DropDownItemClicked(object sender, C1.Win.C1Input.DropDownItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "چاپ اسناد انتخابی")
            {
                btnPrint_Click(sender, e); ;
            }

            else if (e.ClickedItem.Text == "چاپ تمام اسناد نمایش داده شده")
            {
                btnPrintAll_Click(sender, e); ;
            }
            else
            {
                btnPrintAll2_Click(sender, e); ;
            }
        }
        private void btnPrintAll2_Click(object sender, EventArgs e)
        {


            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show(this, "هیچ پرونده ای انتخاب نشده است");
                return;
            }
            List<Document> listdoc = Controller.Archive.DocumentController.GetDocuments(this.PersonnelNumber).ToList();
            string _path = "";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog.SelectedPath;
                _path = folderName + "\\" + this.PersonnelNumber;
                System.IO.Directory.CreateDirectory(_path);
                foreach (var item in listdoc.Where(q => q.ParentDocumentID == null).ToList())
                {
                    try
                    {
                        List<Document> listchilds = new List<Document>();
                        listchilds.Add(item);
                        listchilds.AddRange(listdoc.Where(q => q.ParentDocumentID == item.ID).ToList());
                        Image[] images = new Image[listchilds.Count];
                        int i = 0;
                        this.Cursor = Cursors.WaitCursor;
                        string documentPath = _path + "\\" + item.Index.ToString() + ".Pdf";
                        object obj2 = SqlHelper.GetArchiveFieldValueFoDocument2("Document2", "Field12", item.ID);
                        if (obj2 != null)
                        {
                            documentPath = _path + "\\" + obj2.ToString() + "_" + item.Index.ToString() + ".Pdf";
                        }

                        List<string> documnetNumbers = new List<string>();
                        foreach (var itemchild in listchilds)
                        {
                            documnetNumbers.Add(itemchild.Number);
                            string file;
                            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                            {
                                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                if (!System.IO.Directory.Exists(tempPath))
                                    System.IO.Directory.CreateDirectory(tempPath);
                                file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(itemchild.FileName));
                                System.IO.File.WriteAllBytes(file, Controller.ArchiveDocument.ArchiveDocumentController.GetDocumentData(itemchild.ID));
                                images[i] = Image.FromFile(file);
                            }
                            else
                            {
                                images[i] = byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(itemchild));
                            }

                            i++;
                        }

                        Njit.Pdf.CreatePDF.FromImages(images, documentPath, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.OriginalSize);
                    }
                    catch { continue; }
                }


            }


            MessageBox.Show(" ذخیره شد." + _path + "فایل پی دی اف در مسیر");
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ذخیره_سند, this.PersonnelNumber, "ذخیره تمام اسناد در یک پرونده");

        }
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Njit.Program.FastReportExtensions.Forms.PrintPreview form = new Njit.Program.FastReportExtensions.Forms.PrintPreview(Setting.Program.ThisProgram.GetReportPath("Document.frx"), Njit.Program.FastReportExtensions.Forms.PrintPreview.PrintSizes.A4, null, 1);
                form.ReportDocument.SetParameterValue("CompanyName", Setting.Archive.ThisProgram.LoadedArchiveSettings.OrganName);
                form.ReportDocument.SetParameterValue("ReportPrintDate", Njit.Common.PersianCalendar.GetDate(DateTime.Now));
                form.ReportDocument.SetParameterValue("ReportPrintTime", Njit.Common.PersianCalendar.GetTime());
                DataTable dt = new DataTable("Images");
                dt.Columns.Add("img", typeof(byte[]));
                List<string> documnetNumbers = new List<string>();
                foreach (var item in imageListView.Items)
                {
                    documnetNumbers.Add((item.VirtualItemKey as Model.Archive.Document).Number);
                    dt.Rows.Add(Controller.Archive.DocumentController.GetDocumentImageBytes(Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID)));
                }
                form.ReportDocument.RegisterData(dt, "Images");
                form.ReportDocument.GetDataSource("Images").Enabled = true;
                form.ShowDialog(this);
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.چاپ_سند, this.PersonnelNumber, string.Format("چاپ اسناد شماره {0} از پرونده {1} در بایگانی ", documnetNumbers.Aggregate((a, b) => a + "," + b), this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (imageListView.SelectedItems.Count == 0)
            {
                PersianMessageBox.Show(this, "هیچ سندی انتخاب نشده است");
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Njit.Program.FastReportExtensions.Forms.PrintPreview form = new Njit.Program.FastReportExtensions.Forms.PrintPreview(Setting.Program.ThisProgram.GetReportPath("Document.frx"), Njit.Program.FastReportExtensions.Forms.PrintPreview.PrintSizes.A4, null, 1);
                form.ReportDocument.SetParameterValue("CompanyName", Setting.Archive.ThisProgram.LoadedArchiveSettings.OrganName);
                form.ReportDocument.SetParameterValue("ReportPrintDate", Njit.Common.PersianCalendar.GetDate(DateTime.Now));
                form.ReportDocument.SetParameterValue("ReportPrintTime", Njit.Common.PersianCalendar.GetTime());
                DataTable dt = new DataTable("Images");
                dt.Columns.Add("img", typeof(byte[]));
                List<string> documnetNumbers = new List<string>();
                foreach (var item in imageListView.SelectedItems)
                {
                    documnetNumbers.Add((item.VirtualItemKey as Model.Archive.Document).Number);
                    dt.Rows.Add(Controller.Archive.DocumentController.GetDocumentImageBytes(Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID)));
                }
                form.ReportDocument.RegisterData(dt, "Images");
                form.ReportDocument.GetDataSource("Images").Enabled = true;
                form.ShowDialog(this);
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.چاپ, null, string.Format("چاپ اسناد شماره {0} از پرونده {1} در بایگانی ", documnetNumbers.Aggregate((a, b) => a + "," + b), this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        #endregion

        #region Copy
        private void btnCopyDocument_Click(object sender, EventArgs e)
        {

            if (imageListView.SelectedItems.Count == 0)
            {
                PersianMessageBox.Show(this, "هیچ سندی انتخاب نشده است");
                return;
            }
            try
            {
                View.DossierSearch form = new DossierSearch("لطفا پرونده های مورد نظر برای کپی اسناد به آنها را انتخاب کنید", DossierSearch.Operations.SearchDialog, true);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    foreach (var item in this.imageListView.SelectedItems)
                    {
                        Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                        try
                        {
                            string file;
                            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                            {
                                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                if (!System.IO.Directory.Exists(tempPath))
                                    System.IO.Directory.CreateDirectory(tempPath);
                                file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                                System.IO.File.WriteAllBytes(file, Controller.ArchiveDocument.ArchiveDocumentController.GetDocumentData(document.ID));
                            }
                            else
                            {
                                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                if (!System.IO.Directory.Exists(tempPath))
                                    System.IO.Directory.CreateDirectory(tempPath);
                                file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                                byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(file);

                            }
                            foreach (string personnelNumber in form.SelectedDossiers)
                            {
                                if (personnelNumber != this.PersonnelNumber)
                                {
                                    Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.GetName("Document2");
                                    Document newDocument = Controller.Archive.DocumentController.AddDocument(personnelNumber, file, null, false, (Njit.Program.ComponentOne.Enums.SaveFormats)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? ((int)Njit.Program.ComponentOne.Enums.SaveFormats.None)), (Njit.Program.ComponentOne.Enums.CompressionTypes)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? ((int)Njit.Program.ComponentOne.Enums.CompressionTypes.None)), archiveTab);
                                    //.........................................
                                    if (document.ParentDocumentID == null)
                                    {
                                        List<System.Data.SqlClient.SqlCommand> sqlCommands = new List<System.Data.SqlClient.SqlCommand>();
                                        _CurrentDocument = document;
                                        ShowCurrentDocumentInfo();
                                        try
                                        {
                                            sqlCommands.AddRange(SqlHelper.GetDocumentInsertCommands(pnlInfo, archiveTab, newDocument, personnelNumber));
                                            Controller.Archive.DocumentController.UpdateDocument(newDocument, sqlCommands);
                                        }
                                        catch { continue; }

                                    }
                                    //.........................................
                                    foreach (var itemchild in Controller.Archive.DocumentController.GetChildDocuments(document.ID))
                                    {
                                        string filechild;
                                        if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                                        {
                                            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                            if (!System.IO.Directory.Exists(tempPath))
                                                System.IO.Directory.CreateDirectory(tempPath);
                                            filechild = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(itemchild.FileName));
                                            System.IO.File.WriteAllBytes(filechild, Controller.ArchiveDocument.ArchiveDocumentController.GetDocumentData(itemchild.ID));
                                        }
                                        else
                                        {
                                            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                            if (!System.IO.Directory.Exists(tempPath))
                                                System.IO.Directory.CreateDirectory(tempPath);
                                            filechild = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(itemchild.FileName));
                                            byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(itemchild)).Save(filechild);
                                        }
                                        Controller.Archive.DocumentController.AddDocument(personnelNumber, filechild, newDocument.ID, false, (Njit.Program.ComponentOne.Enums.SaveFormats)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? ((int)Njit.Program.ComponentOne.Enums.SaveFormats.None)), (Njit.Program.ComponentOne.Enums.CompressionTypes)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? ((int)Njit.Program.ComponentOne.Enums.CompressionTypes.None)), archiveTab);
                                    }
                                }
                            }
                            PersianMessageBox.Show("اطلاعات با موفقیت کپی شد.");
                        }
                        catch (Exception ex)
                        {
                            PersianMessageBox.Show(this, "خطا در کپی سند شماره " + document.Number + "\r\n\r\n" + ex.Message);
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        #endregion

        #region Move
        private void btnMoveDocument_Click(object sender, EventArgs e)
        {

            if (imageListView.SelectedItems.Count == 0)
            {
                PersianMessageBox.Show(this, "هیچ سندی انتخاب نشده است");
                return;
            }
            try
            {
                View.DossierSearch form = new DossierSearch("لطفا پرونده های مورد نظر برای انتقال اسناد به آنها را انتخاب کنید", DossierSearch.Operations.SearchDialog, true);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    foreach (var item in this.imageListView.SelectedItems)
                    {
                        Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                        try
                        {
                            #region GetPath
                            string file;
                            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                            {
                                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                if (!System.IO.Directory.Exists(tempPath))
                                    System.IO.Directory.CreateDirectory(tempPath);
                                file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                                System.IO.File.WriteAllBytes(file, Controller.ArchiveDocument.ArchiveDocumentController.GetDocumentData(document.ID));
                            }
                            else
                            {
                                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                if (!System.IO.Directory.Exists(tempPath))
                                    System.IO.Directory.CreateDirectory(tempPath);
                                file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                                byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(file);
                            }
                            #endregion
                            foreach (string personnelNumber in form.SelectedDossiers)
                            {

                                #region Add New Doc
                                Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.GetName("Document2");
                                Document newDocument = Controller.Archive.DocumentController.AddDocument(personnelNumber, file, null, false, (Njit.Program.ComponentOne.Enums.SaveFormats)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? ((int)Njit.Program.ComponentOne.Enums.SaveFormats.None)), (Njit.Program.ComponentOne.Enums.CompressionTypes)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? ((int)Njit.Program.ComponentOne.Enums.CompressionTypes.None)), archiveTab);
                                #endregion
                                #region Add Information
                                //.................................................اضافه اطلاعات سند 
                                if (document.ParentDocumentID == null)
                                {
                                    List<System.Data.SqlClient.SqlCommand> sqlCommands = new List<System.Data.SqlClient.SqlCommand>();
                                    _CurrentDocument = document;
                                    ShowCurrentDocumentInfo();
                                    try
                                    {
                                        sqlCommands.AddRange(SqlHelper.GetDocumentInsertCommands(pnlInfo, archiveTab, newDocument, personnelNumber));
                                        Controller.Archive.DocumentController.UpdateDocument(newDocument, sqlCommands);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                                #endregion
                                #region Add Payvast
                                //.........................................اضافه کردن سند پیوست ها 
                                foreach (var itemchild in Controller.Archive.DocumentController.GetChildDocuments(document.ID))
                                {
                                    string filechild;
                                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                                    {
                                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                        if (!System.IO.Directory.Exists(tempPath))
                                            System.IO.Directory.CreateDirectory(tempPath);
                                        filechild = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(itemchild.FileName));
                                        System.IO.File.WriteAllBytes(filechild, Controller.ArchiveDocument.ArchiveDocumentController.GetDocumentData(itemchild.ID));
                                    }
                                    else
                                    {
                                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                                        if (!System.IO.Directory.Exists(tempPath))
                                            System.IO.Directory.CreateDirectory(tempPath);
                                        filechild = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(itemchild.FileName));
                                        byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(itemchild)).Save(filechild);
                                    }
                                    Controller.Archive.DocumentController.AddDocument(personnelNumber, filechild, newDocument.ID, false, (Njit.Program.ComponentOne.Enums.SaveFormats)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? ((int)Njit.Program.ComponentOne.Enums.SaveFormats.None)), (Njit.Program.ComponentOne.Enums.CompressionTypes)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? ((int)Njit.Program.ComponentOne.Enums.CompressionTypes.None)), archiveTab);
                                }
                                #endregion
                            }
                            #region Delete
                            //حذف پیوست های سند انتخابی
                            foreach (var itemchild in Controller.Archive.DocumentController.GetChildDocuments(document.ID))
                            {
                                Controller.Archive.DocumentController.Delete(itemchild.ID);

                            }
                            //حذف خود سند
                            imageListView.Items.Remove(item);
                            Controller.Archive.DocumentController.Delete(document.ID);
                            #endregion

                        }

                        catch (Exception ex)
                        {
                            PersianMessageBox.Show(this, "خطا در کپی سند شماره " + document.Number + "\r\n\r\n" + ex.Message);
                        }
                    }
                    kpImageViewer1.Image = global::NjitSoftware.Properties.Resources.Document;
                    PersianMessageBox.Show("سند با موفقیت انتقال یافت.");
                }
            }
            finally
            {
                _CurrentDocument = null;
                LoadDocuments_IN_Left_Panle();
                this.Cursor = Cursors.Default;

            }

        }
        #endregion

        #region Save
        private void btnSaveDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageListView.SelectedItems.Count == 0)
                {
                    PersianMessageBox.Show(this, "هیچ سندی انتخاب نشده است");
                    return;
                }
                ConverAllImagesToOnePDFFile();
            }
            catch { return; }

        }
        public string GetUniqFileName2(string extension)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save pdf Files";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "Text files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string tempDirectory = Path.Combine(saveFileDialog1.InitialDirectory, "");
                string fileName = saveFileDialog1.FileName;
                string documentPath = Path.Combine(tempDirectory, fileName + extension).ToString();
                int i = 0;
                while (System.IO.File.Exists(documentPath))
                {
                    documentPath = Path.Combine(tempDirectory, fileName + "(" + (++i).ToString() + ")" + extension).ToString();
                }
                return documentPath;
            }

            return "";
        }
        private void ConverAllImagesToOnePDFFile()
        {

            Image[] images = new Image[imageListView.SelectedItems.Count];
            int i = 0;
            this.Cursor = Cursors.WaitCursor;

            string documentPath = GetUniqFileName2(".pdf");
            List<string> documnetNumbers = new List<string>();
            foreach (var item in this.imageListView.SelectedItems)
            {
                Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                documnetNumbers.Add(document.Number);
                string file;
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                {
                    string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                    if (!System.IO.Directory.Exists(tempPath))
                        System.IO.Directory.CreateDirectory(tempPath);
                    file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                    System.IO.File.WriteAllBytes(file, Controller.ArchiveDocument.ArchiveDocumentController.GetDocumentData(document.ID));
                    images[i] = Image.FromFile(file);
                }
                else
                {
                    images[i] = byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document));
                }

                i++;
            }
            Njit.Pdf.CreatePDF.FromImages(images, documentPath, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.OriginalSize);
            MessageBox.Show(" ذخیره شد." + documentPath + "فایل پی دی اف در مسیر");
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ذخیره_سند, this.PersonnelNumber, string.Format("ذخیره اسناد شماره {0} از پرونده {1} در بایگانی ", documnetNumbers.Aggregate((a, b) => a + "," + b), this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));


        }
        #endregion

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

        #region NotData
        private void btnNotData_Click(object sender, EventArgs e)
        {
            ResetValuePnlInfo();
            NotDataDocument();
        }
        #endregion

        #region شدت روشنایی چپ و راست و روشنایی
        private int _Brightness = 10;
        [DefaultValue(0)]
        public int Brightness
        {
            get
            {
                return _Brightness;
            }
            set
            {
                if (value >= -255 && value <= 255 && _Brightness != value)
                {
                    _Brightness = value;

                }
            }
        }

        List<int> indexListSelected;
        private void Right_Click()
        {
            try
            {
                SetLoading(true);
                indexListSelected = new List<int>();
                string _Docsid = "";
                foreach (var item in imageListView.SelectedItems)
                {
                    indexListSelected.Add(item.Index);
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                    _Docsid += document.ID + ",";
                    string file, destinationFile;
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                    {
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        destinationFile = file;
                    }
                    else
                    {
                        file = System.IO.Path.Combine(document.Dossier.FilesPathOrDatabaseName, document.FileName);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        destinationFile = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(destinationFile);

                    }
                    Njit.Common.Helpers.ImageHelper.RotateImage(destinationFile, RotateFlipType.Rotate90FlipNone);
                    AddFileINServer(destinationFile, file);
                }
                if (imageListView.SelectedItems.Count > 0)
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.چرخش_به_راست, this.PersonnelNumber, string.Format("چرخش به راست اسناد شماره {0} از پرونده {1} در بایگانی ", _Docsid, this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
                    ShowImage_In_Center_Panel();
                }
                PersianMessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                SetLoading(false);
            }
            catch (Exception ex)
            {
                SetLoading(false);
                PersianMessageBox.Show("لطفا بعد از چند ثانیه ، دوباره امتحان کنید:" + ex.Message);
            }

        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(Right_Click);
            threadInput.Start();



        }

        private void Left_Click()
        {
            try
            {
                SetLoading(true);
                indexListSelected = new List<int>();
                string _Docsid = "";
                foreach (var item in imageListView.SelectedItems)
                {
                    indexListSelected.Add(item.Index);
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                    _Docsid += document.ID + ",";
                    string file, destinationFile;
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                    {
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        destinationFile = file;
                    }
                    else
                    {
                        file = System.IO.Path.Combine(document.Dossier.FilesPathOrDatabaseName, document.FileName);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        destinationFile = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(destinationFile);

                    }
                    Njit.Common.Helpers.ImageHelper.RotateImage(destinationFile, RotateFlipType.Rotate270FlipNone);
                    AddFileINServer(destinationFile, file);
                }
                if (imageListView.SelectedItems.Count > 0)
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.چرخش_به_چپ, PersonnelNumber, string.Format("چرخش به چپ اسناد شماره {0} از پرونده {1} در بایگانی ", _Docsid, this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));

                    ShowImage_In_Center_Panel();
                }
                PersianMessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                SetLoading(false);
            }
            catch (Exception ex)
            {
                SetLoading(false);
                PersianMessageBox.Show("لطفا بعد از چند ثانیه ، دوباره امتحان کنید:" + ex.Message);
            }
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(Left_Click);
            threadInput.Start();

        }
        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    this.Cursor = Cursors.Default;
                });
            }
        }
        private void BrightsUP()
        {
            SetLoading(true);
            try
            {
                indexListSelected = new List<int>();
                string _Docsid = "";
                foreach (var item in imageListView.SelectedItems)
                {
                    indexListSelected.Add(item.Index);
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                    _Docsid += document.ID + ",";
                    string file, destinationFile;
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                    {
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        destinationFile = file;
                    }
                    else
                    {
                        file = System.IO.Path.Combine(document.Dossier.FilesPathOrDatabaseName, document.FileName);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        destinationFile = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(destinationFile);

                    }

                    Njit.Common.Helpers.ImageHelper.SetBrightness(destinationFile, 30);
                    AddFileINServer(destinationFile, file);
                }
                if (imageListView.SelectedItems.Count > 0)
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.افزایش_روشنایی, this.PersonnelNumber, string.Format("افزایش روشنایی اسناد شماره {0} از پرونده {1} در بایگانی ", _Docsid, this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
                    ShowImage_In_Center_Panel();
                }
                PersianMessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                SetLoading(false);
            }
            catch (Exception ex)
            {
                SetLoading(false);
                PersianMessageBox.Show("لطفا بعد از چند ثانیه ، دوباره امتحان کنید:" + ex.Message);
            }

        }
        private void btnBrightsUP_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(BrightsUP);
            threadInput.Start();

        }
        private void AddFileINServer(string file, string destinationFile)
        {
            FileStream serverFileStream = null;
            FileStream clientFileStream = null;
            try
            {
                Njit.Common.SystemUtility sysUtility = Njit.Program.Options.GetSystemUtility(DataAccess.ArchiveDataAccess.GetNewInstance().Connection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                if (!sysUtility.DirectoryExists(this.SelectedDossier.FilesPathOrDatabaseName))
                    sysUtility.CreateDirectory(this.SelectedDossier.FilesPathOrDatabaseName);
                serverFileStream = sysUtility.CreateFile(destinationFile);
                clientFileStream = File.OpenRead(file);
                byte[] buffre = new byte[1 * 1024 * 1024];
                int readCount = 0;
                do
                {
                    readCount = clientFileStream.Read(buffre, 0, buffre.Length);
                    serverFileStream.Write(buffre, 0, readCount);
                }
                while (readCount > 0);
                clientFileStream.Close();
                serverFileStream.Close();
                clientFileStream.Dispose();
                serverFileStream.Dispose();
            }
            catch (Exception ex)
            {
                if (clientFileStream != null)
                    clientFileStream.Dispose();
                if (serverFileStream != null)
                    serverFileStream.Dispose();
                throw new Exception("خطا در ذخیره فایل" + "\r\n" + file + "\r\n\r\n" + ex.Message);
            }
        }
        private void BrightsDown()
        {
            try
            {
                SetLoading(true);
                indexListSelected = new List<int>();
                string _Docsid = "";
                foreach (var item in imageListView.SelectedItems)
                {
                    indexListSelected.Add(item.Index);
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                    _Docsid += document.ID + ",";
                    string file, destinationFile;
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                    {
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        destinationFile = file;
                    }
                    else
                    {
                        file = System.IO.Path.Combine(document.Dossier.FilesPathOrDatabaseName, document.FileName);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        destinationFile = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(destinationFile);

                    }
                    Njit.Common.Helpers.ImageHelper.SetBrightness(destinationFile, -30);
                    AddFileINServer(destinationFile, file);
                }
                if (imageListView.SelectedItems.Count > 0)
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.کاهش_روشنایی, this.PersonnelNumber, string.Format("کاهش روشنایی اسناد شماره {0} از پرونده {1} در بایگانی ", _Docsid, this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
                    ShowImage_In_Center_Panel();
                }
                PersianMessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                SetLoading(false);
            }
            catch (Exception ex)
            {
                SetLoading(false);
                PersianMessageBox.Show("لطفا بعد از چند ثانیه ، دوباره امتحان کنید:" + ex.Message);
            }
        }
        private void btnBrightsDown_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(BrightsDown);
            threadInput.Start();
        }

        private void ContrastDown()
        {
            try
            {
                SetLoading(true);
                indexListSelected = new List<int>();
                string _Docsid = "";
                foreach (var item in imageListView.SelectedItems)
                {
                    indexListSelected.Add(item.Index);
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                    _Docsid += document.ID + ",";
                    string file, destinationFile;
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                    {
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        destinationFile = file;
                    }
                    else
                    {
                        file = System.IO.Path.Combine(document.Dossier.FilesPathOrDatabaseName, document.FileName);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        destinationFile = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(destinationFile);

                    }
                    Njit.Common.Helpers.ImageHelper.SetContrast(destinationFile, -30);
                    AddFileINServer(destinationFile, file);
                }
                if (imageListView.SelectedItems.Count > 0)
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.کاهش_کنتراست, this.PersonnelNumber, string.Format("کاهش کنتراست اسناد شماره {0} از پرونده {1} در بایگانی ", _Docsid, this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
                    ShowImage_In_Center_Panel();
                }
                PersianMessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                SetLoading(false);
            }
            catch (Exception ex)
            {
                SetLoading(false);
                PersianMessageBox.Show("لطفا بعد از چند ثانیه ، دوباره امتحان کنید:" + ex.Message);
            }
        }
        private void btnContrastDown_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(ContrastDown);
            threadInput.Start();
        }

        private void ContrastUP()
        {

            try
            {
                SetLoading(true);
                indexListSelected = new List<int>();
                string _Docsid = "";
                foreach (var item in imageListView.SelectedItems)
                {
                    indexListSelected.Add(item.Index);
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                    _Docsid += document.ID + ",";
                    string file, destinationFile;
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                    {
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        file = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        destinationFile = file;
                    }
                    else
                    {
                        file = System.IO.Path.Combine(document.Dossier.FilesPathOrDatabaseName, document.FileName);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        if (!System.IO.Directory.Exists(tempPath))
                            System.IO.Directory.CreateDirectory(tempPath);
                        destinationFile = System.IO.Path.Combine(tempPath, System.IO.Path.GetFileName(document.FileName));
                        byteArrayToImage(Controller.Archive.DocumentController.GetDocumentImageBytes(document)).Save(destinationFile);

                    }
                    Njit.Common.Helpers.ImageHelper.SetContrast(destinationFile, 30);
                    AddFileINServer(destinationFile, file);
                }
                if (imageListView.SelectedItems.Count > 0)
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.افزایش_کنتراست, this.PersonnelNumber, string.Format("افزایش کنتراست اسناد شماره {0} از پرونده {1} در بایگانی ", _Docsid, this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
                    ShowImage_In_Center_Panel();
                }
                PersianMessageBox.Show("اطلاعات با موفقیت ذخیره شد");
                SetLoading(false);
            }
            catch (Exception ex)
            {
                SetLoading(false);
                PersianMessageBox.Show("لطفا بعد از چند ثانیه ، دوباره امتحان کنید:" + ex.Message);
            }
        }
        private void btnContrastUP_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(ContrastUP);
            threadInput.Start();

        }
        #endregion

        #region Delete Document
        private void c1SplitButton2_Click(object sender, EventArgs e)
        {

            if (imageListView.SelectedItems.Count == 0)
            {
                PersianMessageBox.Show(this, "هیچ سندی انتخاب نشده است");
                return;
            }
            btnDelete_Click(c1SplitButton2, e);
        }

        private void c1SplitButton2_DropDownItemClicked(object sender, C1.Win.C1Input.DropDownItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "حذف سند انتخابی")
            {
                btnDelete_Click(sender, e); ;
            }

            else
            {
                btnDeleteAll_Click(sender, e); ;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (imageListView.SelectedItems.Count > 0)
            {
                foreach (var item in imageListView.SelectedItems)
                {
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);
                    var dialogResult = PersianMessageBox.Show(this, "مایل به حذف سند شماره " + document.Index + " هستید؟", "تایید حذف سند", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            string _Number = document.Index.ToString();
                            Controller.Archive.DocumentController.Delete(document.ID);
                            imageListView.Items.Remove(item);

                            //لاگ گیری برای حذف سند
                            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.حذف_سند, this.PersonnelNumber.ToString(), "حذف سند شماره:" + _Number);
                        }
                        catch (Exception ex)
                        {
                            PersianMessageBox.Show(this, "خطا در حذف سند شماره " + document.Index + "\r\n\r\n" + ex.Message);
                        }
                    }
                    else if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                        break;
                }
                kpImageViewer1.Image = global::NjitSoftware.Properties.Resources.Document;
                _CurrentDocument = null;
                //Reset_Left_And_Center_Image();
                //NotDataDocument();


            }
            else
            {
                PersianMessageBox.Show("لطفا سندی که می خواهید حذف کنید را انتخاب کنید");
            }

        }



        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var dialogResult = PersianMessageBox.Show(this, "مایل به حذف تمام اسناد هستید", "تایید حذف سند", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (var item in imageListView.Items)
                {
                    Model.Archive.Document document = Controller.Archive.DocumentController.GetDocument((item.VirtualItemKey as Model.Archive.Document).ID);

                    try
                    {
                        string _Number = document.Number.ToString();
                        Controller.Archive.DocumentController.Delete(document.ID);
                        //لاگ گیری برای حذف سند
                        Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.حذف_سند, this.PersonnelNumber.ToString(), "حذف سند شماره:" + _Number);

                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در حذف سند شماره " + document.Number + "\r\n\r\n" + ex.Message);
                    }

                }
            }
            _CurrentDocument = null;
            LoadDocuments_IN_Left_Panle();

        }
        #endregion

        #region وارد صفحه کارشناس شدن
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
        private void btnShowDocInformation_Click(object sender, EventArgs e)
        {
            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser != null)
            {
                if (IsMembershipInAdministartorRole(currentUser))
                {
                    this.Hide();
                    using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(this.PersonnelNumber, 0))
                    {
                        f.ShowDialog(this);
                    }
                    this.Close();
                }

                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                {
                    this.Hide();
                    using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(this.PersonnelNumber, 0))
                    {
                        f.ShowDialog(this);
                    }
                    this.Close();
                }
                else
                {
                    PersianMessageBox.Show("شما به صفحه اطلاعات اسناد کارشناس بایگانی دسترسی ندارید");
                }
            }
        }
        #endregion

        #region جستجوی پرونده ها
        private void c1Button1_Click(object sender, EventArgs e)
        {
            View.DossierSearch ds = new DossierSearch();
            ds.ShowDialog(this);
        }
        #endregion

        #region Scan
        public int _Resolution { get; set; }
        public DocumentHandlingSelect _DocumentHandlingSelect { set; get; }
        public CurrentIntent _CurrentIntent { set; get; }
        public SizeF _DocumentSize { set; get; }
        public string _DocumentSizeName { set; get; }
        public ScannerDevice _ScannerDevice { set; get; }
        public static float MmToInch(int mm)
        {
            return 0.03937f * mm;
        }
        private void SetDefultScanSetting(int type, int dpi, int imageType)
        {

            _DocumentSize = new SizeF(ArchiverDocumentManagement.MmToInch(210), ArchiverDocumentManagement.MmToInch(297));
            _DocumentSizeName = "A4";
            switch (dpi)
            {
                case 0:
                    this._Resolution = 75;
                    break;
                case 1:
                    this._Resolution = 100;
                    break;
                case 2:
                    this._Resolution = 200;
                    break;
                case 3:
                    this._Resolution = 300;
                    break;
                case 4:
                    this._Resolution = 600;
                    break;
                case 5:
                    this._Resolution = 1200;
                    break;
                default:
                    this._Resolution = 200;
                    break;
            }
            switch (type)
            {
                case 0:
                    this._DocumentHandlingSelect = DocumentHandlingSelect.Feeder;
                    break;
                case 1:
                    this._DocumentHandlingSelect = DocumentHandlingSelect.Flatbed;
                    break;
                default:
                    this._DocumentHandlingSelect = DocumentHandlingSelect.Feeder;
                    break;
            }

            switch (imageType)
            {
                case 0:
                    this._CurrentIntent = CurrentIntent.ImageTypeText;
                    break;
                case 1:
                    this._CurrentIntent = CurrentIntent.ImageTypeGrayscale;
                    break;
                case 2:
                    this._CurrentIntent = CurrentIntent.ImageTypeColor;
                    break;
                default:
                    this._CurrentIntent = CurrentIntent.ImageTypeText;
                    break;
            }

        }



        #endregion


        #region RefreshButton
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _CurrentDocument = null;
            LoadDocuments_IN_Left_Panle();
        }
        #endregion


        #region F1
        //اقدام کننده
        private void EghdamDataGridView3()
        {
            if (btnSaveInfo.Visible)
            {
                pnlFields.Visible = true;
                radGridViewFields.DataSource = null;
                radGridViewFields.DataSource = ListEghdam.OrderBy(q => q.Value).ToList();
                radGridViewFields.Columns[0].Width = 100;
                radGridViewFields.Columns[0].HeaderText = "شماره";
                radGridViewFields.Columns[1].HeaderText = "نام";
                FieldstxtName.Focus();
                txtName.Text = "لیست اقدام کنندگان";
            }
            else
            {
                pnlFields.Visible = false;
            }
        }

        private void OnvanDataGridView2()
        {
            if (btnSaveInfo.Visible)
            {
                pnlFields.Visible = true;
                radGridViewFields.DataSource = null;
                radGridViewFields.DataSource = ListOnvan.OrderBy(q => q.Value).ToList();
                radGridViewFields.Columns[0].Width = 100;
                radGridViewFields.Columns[0].HeaderText = "شماره";
                radGridViewFields.Columns[1].HeaderText = "نام";
                FieldstxtName.Focus();
                txtName.Text = "لیست عناوین ";
            }
            else
            {
                pnlFields.Visible = false;
            }

        }

        private void MokhatabinDataGridView()
        {
            if (btnSaveInfo.Visible)
            {
                pnlFields.Visible = true;
                radGridViewFields.DataSource = null;
                radGridViewFields.DataSource = ListMokhatab.OrderBy(q => q.Value).ToList();
                radGridViewFields.Columns[0].Width = 100;
                radGridViewFields.Columns[0].HeaderText = "شماره";
                radGridViewFields.Columns[1].HeaderText = "نام";
                FieldstxtName.Focus();
                txtName.Text = "لیست مخاطبین ";
            }
            else
            {
                pnlFields.Visible = false;
            }
        }




        private void FieldsdataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            MessageBox.Show(e.RowIndex.ToString());
        }

        private void FieldsdataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            MessageBox.Show(e.RowIndex.ToString());
        }
        private string _KeyField = null;
        [DefaultValue(null)]
        protected string KeyField
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

        private void FieldsbtnEdit_Click(object sender, EventArgs e)
        {
            if (FieldstxtName.Text.Trim() != "")
            {
                try
                {
                    this.CaptionField = "Title";
                    this.KeyField = "ID";
                    int _Id = 0;
                    if (_FieldSelect == 1)
                    {
                        this.TableName = "Field10";
                        _Id = Convert.ToInt32(this.TableValue);
                    }
                    else if (_FieldSelect == 2)
                    {
                        this.TableName = "Field12";
                        _Id = Convert.ToInt32(this.TableValue);
                    }
                    else if (_FieldSelect == 3)
                    {
                        this.TableName = "Field14";
                        _Id = Convert.ToInt32(this.TableValue);
                    }
                    Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                    if (_Id != 0)
                    {
                        (da ?? (Njit.Program.Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("UPDATE [{0}] SET [{1}]=@p1 WHERE [{2}]=@p2", this.TableName, this.CaptionField, this.KeyField), "@p1", FieldstxtName.Text, "@p2", _Id);
                        GetDataFromDatabase_Shomare_Mokhatabt_Onvan();
                        Insert_Data_Mokhatabin_Onvan_Eghdam();
                        if (_FieldSelect == 1)
                        {
                            MokhatabinDataGridView();
                        }
                        else if (_FieldSelect == 2)
                        {
                            OnvanDataGridView2();
                        }
                        else if (_FieldSelect == 3)
                        {
                            EghdamDataGridView3();
                        }
                        Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش, this.PersonnelNumber, "ویرایش فیلد اطلاعاتی" + FieldstxtName.Text);

                        PersianMessageBox.Show("اطلاعات با موفقیت ویرایش شد.");
                    }
                    else
                    {
                        throw new Exception("فیلد مورد نظر وجود ندارد");
                    }
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }

            }

        }

        private void FieldsbtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = PersianMessageBox.Show("آیا از حذف اطلاعات اطمینان دارید؟", "حذف اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                if (FieldstxtName.Text != null)
                {

                    try
                    {
                        this.CaptionField = "Title";
                        this.KeyField = "ID";
                        int _Id = 0;
                        if (_FieldSelect == 1)
                        {
                            this.TableName = "Field10";
                            _Id = Convert.ToInt32(this.TableValue);
                        }
                        else if (_FieldSelect == 2)
                        {
                            this.TableName = "Field12";
                            _Id = Convert.ToInt32(this.TableValue);
                        }
                        else if (_FieldSelect == 3)
                        {
                            this.TableName = "Field14";
                            _Id = Convert.ToInt32(this.TableValue);
                        }
                        Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                        if (_Id != 0)
                        {
                            (da ?? (Njit.Program.Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("DELETE FROM [{0}] WHERE [{1}]=@p", this.TableName, this.KeyField), "@p", _Id);
                            GetDataFromDatabase_Shomare_Mokhatabt_Onvan();
                            Insert_Data_Mokhatabin_Onvan_Eghdam();
                            if (_FieldSelect == 1)
                            {
                                MokhatabinDataGridView();
                            }
                            else if (_FieldSelect == 2)
                            {
                                OnvanDataGridView2();
                            }
                            else if (_FieldSelect == 3)
                            {
                                EghdamDataGridView3();
                            }
                            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.حذف, this.PersonnelNumber, "حذف فیلد اطلاعاتی" + FieldstxtName.Text);

                            PersianMessageBox.Show("اطلاعات با موفقیت حذف شد.");
                        }
                        else
                        {
                            throw new Exception("فیلد مورد نظر وجود ندارد");
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        if (ex.ErrorCode == -2146232060 && ex.Number == 547)
                        {
                            PersianMessageBox.Show(this, "'" + this.TableValue + "' قابل حذف نیست. از این اطلاعات در جای دیگر استفاده شده است");
                        }
                        else
                        {
                            PersianMessageBox.Show(this, "خطا در حذف '" + this.TableValue + "'" + Environment.NewLine + Environment.NewLine + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در حذف '" + this.TableValue + "'" + Environment.NewLine + Environment.NewLine + ex.Message);
                        return;
                    }

                }
            }
        }


        private string _TableName = null;
        [DefaultValue(null)]
        protected string TableName
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
        private string _TableValue = null;
        [DefaultValue(null)]
        protected string TableValue
        {
            get
            {
                return _TableValue;
            }
            set
            {
                _TableValue = value;
            }
        }
        private string _CaptionField = null;
        [DefaultValue(null)]
        protected string CaptionField
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
        private void FieldsbtnAdd_Click(object sender, EventArgs e)
        {
            if (FieldstxtName.Text.Trim() == "")
            {
                PersianMessageBox.Show(this, "مقدار وارد نشده است");
                errorProvider.SetError(FieldstxtName, "مقدار وارد نشده است");
                FieldstxtName.Focus();
                return;
            }
            try
            {
                this.CaptionField = "Title";
                if (_FieldSelect == 1)
                {
                    this.TableName = "Field10";
                    if (ListMokhatab.Any(q => q.Value == FieldstxtName.Text && q.Value.Length == FieldstxtName.Text.Length))
                    {
                        throw new Exception(string.Format("در لیست مخاطبین' {0} ' وجود دارد", FieldstxtName.Text));
                    }
                }
                else if (_FieldSelect == 2)
                {
                    this.TableName = "Field12";
                    if (ListOnvan.Any(q => q.Value == FieldstxtName.Text && q.Value.Length == FieldstxtName.Text.Length))
                    {
                        throw new Exception(string.Format("در لیست عناوین' {0} ' وجود دارد", FieldstxtName.Text));
                    }
                }
                else if (_FieldSelect == 3)
                {
                    this.TableName = "Field14";
                    if (ListEghdam.Any(q => q.Value == FieldstxtName.Text && q.Value.Length == FieldstxtName.Text.Length))
                    {
                        throw new Exception(string.Format("در لیست اقدام کنندگان ' {0} ' وجود دارد", FieldstxtName.Text));
                    }
                }
                Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                (da ?? (Njit.Program.Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("INSERT INTO [{0}] ([{1}]) VALUES(@p)", this.TableName, this.CaptionField), "@p", FieldstxtName.Text);
                GetDataFromDatabase_Shomare_Mokhatabt_Onvan();
                Insert_Data_Mokhatabin_Onvan_Eghdam();
                if (_FieldSelect == 1)
                {
                    MokhatabinDataGridView();
                }
                else if (_FieldSelect == 2)
                {
                    OnvanDataGridView2();
                }
                else if (_FieldSelect == 3)
                {
                    EghdamDataGridView3();
                }
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ثبت, this.PersonnelNumber, "اضافه کردن فیلد اطلاعاتی" + FieldstxtName.Text);
                PersianMessageBox.Show("اطلاعات با موفقیت اضافه شد.");
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
        }

        private void radGridViewFields_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            foreach (Telerik.WinControls.UI.GridViewRowInfo item in radGridViewFields.SelectedRows)
            {
                FieldstxtName.Text = item.Cells[1].Value.ToString();
                this.TableValue = item.Cells[0].Value.ToString();
            }

        }

        private void radGridViewFields_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            foreach (Telerik.WinControls.UI.GridViewRowInfo item in radGridViewFields.SelectedRows)
            {
                FieldstxtName.Text = item.Cells[1].Value.ToString();
                this.TableValue = item.Cells[0].Value.ToString();
            }
            if (_FieldSelect == 1)
            {
                AutoCompleteTextbox3 textBoxExtended10 = (AutoCompleteTextbox3)pnlInfo.Controls["Field10"];
                Njit.Program.Controls.TextBoxExtended textBoxExtended9 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field9"];
                textBoxExtended9.Text = TableValue;
                textBoxExtended10.Text = FieldstxtName.Text;
                textBoxExtended10.SelectItem();

            }
            else if (_FieldSelect == 2)
            {
                AutoCompleteTextbox3 textBoxExtended12 = (AutoCompleteTextbox3)pnlInfo.Controls["Field12"];
                Njit.Program.Controls.TextBoxExtended textBoxExtended11 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field11"];
                textBoxExtended11.Text = TableValue;
                textBoxExtended12.Text = FieldstxtName.Text;
                textBoxExtended12.SelectItem();


            }
            else if (_FieldSelect == 3)
            {
                AutoCompleteTextbox3 textBoxExtended14 = (AutoCompleteTextbox3)pnlInfo.Controls["Field14"];
                Njit.Program.Controls.TextBoxExtended textBoxExtended13 = (Njit.Program.Controls.TextBoxExtended)pnlInfo.Controls["Field13"];
                textBoxExtended13.Text = TableValue;
                textBoxExtended14.Text = FieldstxtName.Text;
                textBoxExtended14.SelectItem();


            }
            pnlFields.Visible = false;
        }
        //دکمه خروج
        private void button2_Click(object sender, EventArgs e)
        {
            pnlFields.Visible = false;
        }

        #endregion

        private void colorSlider1_Scroll(object sender, ScrollEventArgs e)
        {
            if (CanRefreshThumbs(e.Type))
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "FieldPanel");
                if (query.Count() == 1)
                {
                    query.FirstOrDefault().Width = e.NewValue;
                    dc.SubmitChanges();
                }
                else
                {
                    Model.Common.FormState state = Model.Common.FormState.GetNewInstance(Environment.MachineName, "FieldPanel", 0, e.NewValue, 100, 0, 0);
                    Model.Common.FormState.Insert(dc, state);
                    dc.SubmitChanges();
                    query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "FieldPanel");
                }
                pnlFields.Size = new Size(e.NewValue, query.FirstOrDefault().Height);
            }

        }
        private void SetPanelFieldSize()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "FieldPanel");
            if (query.Count() == 1)
            {
                pnlFields.Size = new Size(query.FirstOrDefault().Width, query.FirstOrDefault().Height);
            }
        }
        #region Start Sacnner
        private void btnScan_DropDownItemClicked(object sender, C1.Win.C1Input.DropDownItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "تنظیمات اسکنر سریع")
            {
                using (View.ScannerSetting f = new ScannerSetting())
                {
                    f.ShowDialog(this);
                }
            }
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show("شماره پرونده وارد نشده است");
            }
            else
            {
                if (e.ClickedItem.Text == "FlatBed(افزودن سند جدید)")
                {
                    btnScanFlat_Click(sender, null);
                }
                else if (e.ClickedItem.Text == "FlatBed(افزودن پیوست به سند انتخابی")
                {
                    btnScanFlatPeyvast_Click(sender, null);
                }
                else if (e.ClickedItem.Text == "Feeder(افزودن سند جدید)")
                {
                    btnScanFeeder_Click(sender, null);
                }
                else if (e.ClickedItem.Text == "Feeder(افزودن پیوست به سند انتخابی")
                {
                    btnScanFeederPeyvast_Click(sender, null);
                }
            }


        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show(this, "هیچ پرونده ای انتخاب نشده است");
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "Scanner");
            if (query.Count() == 1)
            {
                SetDefultScanSetting(query.FirstOrDefault().Y, query.FirstOrDefault().Width, query.FirstOrDefault().X);
            }
            else
            {
                SetDefultScanSetting(0, 0, 0);
            }

            try { this._ScannerDevice = WiaDevice.GetFirstScannerDevice().AsScannerDevice(); }
            catch (COMException comException) { MessageBox.Show(WiaException.GetMessageFromComException(comException) + "لطفا یو اس پی اتصال به اسکن راچک کنید", "خطای ارتباط با یو اس پی", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.UseWaitCursor = true;
            SetLoading(true);
            DocumentHandlingSelect documentHandlingSelect = this._DocumentHandlingSelect;
            CurrentIntent currentIntent = this._CurrentIntent;
            SizeF documentSize = this._DocumentSize;

            int threshold = 128;
            bool hasmorePage = true;
            bool isScaned = false;
            while (hasmorePage)
            {
                try
                {
                    // Einstellungen für das Scanner-Gerät
                    this._ScannerDevice.DeviceSettings.DocumentHandlingSelect = documentHandlingSelect;

                    // تنظیمات اسکنر
                    this._ScannerDevice.PictureSettings.CurrentIntent = currentIntent;
                    this._ScannerDevice.PictureSettings.HorizontalResolution = this._Resolution;
                    this._ScannerDevice.PictureSettings.VerticalResolution = this._Resolution;
                    this._ScannerDevice.PictureSettings.HorizontalExtent = (int)(documentSize.Width * this._Resolution);
                    this._ScannerDevice.PictureSettings.VerticalExtent = (int)(documentSize.Height * this._Resolution);
                    this._ScannerDevice.PictureSettings.Threshold = threshold;

                    //گرفتن اسکن
                    List<Image> images = this._ScannerDevice.PerformScan().ToList();

                    isScaned = true;

                    for (int j = 0; j < images.Count; j++)
                    {



                        string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        string documentPath = Path.Combine(tempPath, fileName + ".jpg").ToString();
                        int i = 0;
                        while (System.IO.File.Exists(documentPath))
                        {
                            documentPath = Path.Combine(tempPath, fileName + "(" + (++i).ToString() + ")" + ".jpg").ToString();
                        }
                        try
                        {
                            Njit.Common.Helpers.ImageHelper.ConvertImage(images[j], System.Drawing.Imaging.ImageFormat.Jpeg, Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionNone, documentPath);
                            SaveDocument(documentPath);

                        }
                        catch (Exception ex)
                        {
                            this.UseWaitCursor = false;
                            SetLoading(false);
                            hasmorePage = false;
                            PersianMessageBox.Show(this, "خطا در ذخیره فایل اسکن شده" + "\r\n\r\n" + ex.Message);
                            return;
                        }


                    }

                }
                catch (COMException ex)
                {
                    this.UseWaitCursor = false;
                    SetLoading(false);
                    hasmorePage = false;
                    string message = WiaException.GetMessageFromComException(ex);
                    if (message == "PaperEmpty." && isScaned)
                    {
                        NotDataDocument();
                        return;
                    }
                    else
                    {
                        NotDataDocument();

                        MessageBox.Show(message, "خطای اسکنر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.UseWaitCursor = false;
                    SetLoading(false);
                    hasmorePage = false;
                    if (ex.Message == "Value does not fall within the expected range." && isScaned)
                    {
                        NotDataDocument();
                        return;
                    }
                    else
                    {
                        NotDataDocument();
                        MessageBox.Show(ex.ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            NotDataDocument();
        }
        private void btnScanFlat_Click(object sender, EventArgs e)
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show(this, "هیچ پرونده ای انتخاب نشده است");
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "Scanner");
            if (query.Count() == 1)
            {
                SetDefultScanSetting(1, query.FirstOrDefault().Width, query.FirstOrDefault().X);
            }
            else
            {
                SetDefultScanSetting(1, 0, 0);
            }

            try { this._ScannerDevice = WiaDevice.GetFirstScannerDevice().AsScannerDevice(); }
            catch (COMException comException) { MessageBox.Show(WiaException.GetMessageFromComException(comException), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            SetLoading(true);
            this.UseWaitCursor = true;

            DocumentHandlingSelect documentHandlingSelect = this._DocumentHandlingSelect;
            CurrentIntent currentIntent = this._CurrentIntent;
            SizeF documentSize = this._DocumentSize;

            int threshold = 128;

            try
            {
                // Einstellungen für das Scanner-Gerät
                this._ScannerDevice.DeviceSettings.DocumentHandlingSelect = documentHandlingSelect;
                this._ScannerDevice.DeviceSettings.Pages = (this._ScannerDevice.DeviceSettings.DocumentHandlingSelect == DocumentHandlingSelect.Duplex) ? 2 : 1;

                // Einstellungen für das Scandokument
                this._ScannerDevice.PictureSettings.CurrentIntent = currentIntent;
                this._ScannerDevice.PictureSettings.HorizontalResolution = this._Resolution;
                this._ScannerDevice.PictureSettings.VerticalResolution = this._Resolution;
                this._ScannerDevice.PictureSettings.HorizontalExtent = (int)(documentSize.Width * this._Resolution);
                this._ScannerDevice.PictureSettings.VerticalExtent = (int)(documentSize.Height * this._Resolution);
                this._ScannerDevice.PictureSettings.Threshold = threshold;

                // Scanvorgang durchführen
                List<Image> images = this._ScannerDevice.PerformScan().ToList();

                // Bild in Fenster anzeigen

                string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                string documentPath = Path.Combine(tempPath, fileName + ".jpg").ToString();
                int i = 0;
                while (System.IO.File.Exists(documentPath))
                {
                    documentPath = Path.Combine(tempPath, fileName + "(" + (++i).ToString() + ")" + ".jpg").ToString();
                }
                try
                {
                    Njit.Common.Helpers.ImageHelper.ConvertImage(images[0], System.Drawing.Imaging.ImageFormat.Jpeg, Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionNone, documentPath);

                }
                catch (Exception ex)
                {
                    this.UseWaitCursor = false;
                    SetLoading(false);

                    PersianMessageBox.Show(this, "خطا در ذخیره فایل اسکن شده" + "\r\n\r\n" + ex.Message);
                    return;
                }

                SaveDocument(documentPath);
                NotDataDocument();
            }
            catch (COMException ex)
            {
                this.UseWaitCursor = false;
                SetLoading(false);
                string message = WiaException.GetMessageFromComException(ex);
                MessageBox.Show(message, "خطای اسکنر", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SetLoading(false);
                this.UseWaitCursor = false;
                MessageBox.Show(ex.ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.UseWaitCursor = false;
            SetLoading(false);

        }
        private void btnScanFlatPeyvast_Click(object sender, EventArgs e)
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show(this, "هیچ پرونده ای انتخاب نشده است");
                return;
            }
            if (_CurrentDocument != null)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "Scanner");
                if (query.Count() == 1)
                {
                    SetDefultScanSetting(1, query.FirstOrDefault().Width, query.FirstOrDefault().X);
                }
                else
                {
                    SetDefultScanSetting(1, 0, 0);
                }

                try { this._ScannerDevice = WiaDevice.GetFirstScannerDevice().AsScannerDevice(); }
                catch (COMException comException) { MessageBox.Show(WiaException.GetMessageFromComException(comException), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error); }



                // UI in den Beschäftigt-Modus versetzen
                this.UseWaitCursor = true;
                SetLoading(true);
                DocumentHandlingSelect documentHandlingSelect = this._DocumentHandlingSelect;
                CurrentIntent currentIntent = this._CurrentIntent;
                SizeF documentSize = this._DocumentSize;

                int threshold = 128;

                try
                {
                    // Einstellungen für das Scanner-Gerät
                    this._ScannerDevice.DeviceSettings.DocumentHandlingSelect = documentHandlingSelect;
                    this._ScannerDevice.DeviceSettings.Pages = (this._ScannerDevice.DeviceSettings.DocumentHandlingSelect == DocumentHandlingSelect.Duplex) ? 2 : 1;

                    // Einstellungen für das Scandokument
                    this._ScannerDevice.PictureSettings.CurrentIntent = currentIntent;
                    this._ScannerDevice.PictureSettings.HorizontalResolution = this._Resolution;
                    this._ScannerDevice.PictureSettings.VerticalResolution = this._Resolution;
                    this._ScannerDevice.PictureSettings.HorizontalExtent = (int)(documentSize.Width * this._Resolution);
                    this._ScannerDevice.PictureSettings.VerticalExtent = (int)(documentSize.Height * this._Resolution);
                    this._ScannerDevice.PictureSettings.Threshold = threshold;

                    // Scanvorgang durchführen
                    List<Image> images = this._ScannerDevice.PerformScan().ToList();

                    // Bild in Fenster anzeigen

                    string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
                    string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                    string documentPath = Path.Combine(tempPath, fileName + ".jpg").ToString();
                    int i = 0;
                    while (System.IO.File.Exists(documentPath))
                    {
                        documentPath = Path.Combine(tempPath, fileName + "(" + (++i).ToString() + ")" + ".jpg").ToString();
                    }
                    try
                    {
                        Njit.Common.Helpers.ImageHelper.ConvertImage(images[0], System.Drawing.Imaging.ImageFormat.Jpeg, Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionNone, documentPath);

                    }
                    catch (Exception ex)
                    {
                        this.UseWaitCursor = false;
                        SetLoading(false);
                        PersianMessageBox.Show(this, "خطا در ذخیره فایل اسکن شده" + "\r\n\r\n" + ex.Message);
                        return;
                    }



                    SaveDocument2(documentPath);

                    LoadDocuments_IN_Left_Panle();



                }
                catch (COMException ex)
                {
                    this.UseWaitCursor = false;
                    SetLoading(false);
                    string message = WiaException.GetMessageFromComException(ex);
                    MessageBox.Show(message, "خطای اسکنر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    this.UseWaitCursor = false;
                    SetLoading(false);
                    MessageBox.Show(ex.ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                PersianMessageBox.Show("هیچ سندی انتخاب نشده است");
            }
            this.UseWaitCursor = false;
            SetLoading(false);
        }

        private void btnScanFeeder_Click(object sender, EventArgs e)
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show(this, "هیچ پرونده ای انتخاب نشده است");
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "Scanner");
            if (query.Count() == 1)
            {
                SetDefultScanSetting(0, query.FirstOrDefault().Width, query.FirstOrDefault().X);
            }
            else
            {
                SetDefultScanSetting(0, 0, 0);
            }

            try { this._ScannerDevice = WiaDevice.GetFirstScannerDevice().AsScannerDevice(); }
            catch (COMException comException) { MessageBox.Show(WiaException.GetMessageFromComException(comException), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error); }



            this.UseWaitCursor = true;
            SetLoading(true);

            DocumentHandlingSelect documentHandlingSelect = this._DocumentHandlingSelect;
            CurrentIntent currentIntent = this._CurrentIntent;
            SizeF documentSize = this._DocumentSize;

            int threshold = 128;
            bool hasmorePage = true;
            bool isScaned = false;
            while (hasmorePage)
            {
                try
                {
                    // Einstellungen für das Scanner-Gerät
                    this._ScannerDevice.DeviceSettings.DocumentHandlingSelect = documentHandlingSelect;
                    //this._ScannerDevice.DeviceSettings.Pages = (this._ScannerDevice.DeviceSettings.DocumentHandlingSelect == DocumentHandlingSelect.Duplex) ? 2 : 1;

                    // Einstellungen für das Scandokument
                    this._ScannerDevice.PictureSettings.CurrentIntent = currentIntent;
                    this._ScannerDevice.PictureSettings.HorizontalResolution = this._Resolution;
                    this._ScannerDevice.PictureSettings.VerticalResolution = this._Resolution;
                    this._ScannerDevice.PictureSettings.HorizontalExtent = (int)(documentSize.Width * this._Resolution);
                    this._ScannerDevice.PictureSettings.VerticalExtent = (int)(documentSize.Height * this._Resolution);
                    this._ScannerDevice.PictureSettings.Threshold = threshold;

                    // Scanvorgang durchführen
                    List<Image> images = this._ScannerDevice.PerformScan().ToList();
                    isScaned = true;
                    for (int j = 0; j < images.Count; j++)
                    {



                        string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
                        string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                        string documentPath = Path.Combine(tempPath, fileName + ".jpg").ToString();
                        int i = 0;
                        while (System.IO.File.Exists(documentPath))
                        {
                            documentPath = Path.Combine(tempPath, fileName + "(" + (++i).ToString() + ")" + ".jpg").ToString();
                        }
                        try
                        {
                            Njit.Common.Helpers.ImageHelper.ConvertImage(images[j], System.Drawing.Imaging.ImageFormat.Jpeg, Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionNone, documentPath);
                            SaveDocument(documentPath);
                        }
                        catch (Exception ex)
                        {
                            this.UseWaitCursor = false;
                            SetLoading(false);
                            hasmorePage = false;
                            PersianMessageBox.Show(this, "خطا در ذخیره فایل اسکن شده" + "\r\n\r\n" + ex.Message);
                            return;
                        }


                    }

                }
                catch (COMException ex)
                {
                    this.UseWaitCursor = false;
                    SetLoading(false);
                    hasmorePage = false;
                    string message = WiaException.GetMessageFromComException(ex);
                    if (message == "PaperEmpty." && isScaned)
                    {
                        NotDataDocument();
                        return;
                    }
                    else
                    {
                        NotDataDocument();
                        MessageBox.Show(message, "خطای اسکنر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.UseWaitCursor = false;
                    SetLoading(false);
                    hasmorePage = false;
                    if (ex.Message == "Value does not fall within the expected range." && isScaned)
                    {
                        NotDataDocument();
                        return;
                    }
                    else
                    {
                        NotDataDocument();
                        MessageBox.Show(ex.ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            NotDataDocument();
            this.UseWaitCursor = false;
            SetLoading(false);
        }

        private void btnScanFeederPeyvast_Click(object sender, EventArgs e)
        {
            if (this.PersonnelNumber == "")
            {
                PersianMessageBox.Show(this, "هیچ پرونده ای انتخاب نشده است");
                return;
            }
            if (_CurrentDocument != null)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "Scanner");
                if (query.Count() == 1)
                {
                    SetDefultScanSetting(0, query.FirstOrDefault().Width, query.FirstOrDefault().X);
                }
                else
                {
                    SetDefultScanSetting(0, 0, 0);
                }

                try { this._ScannerDevice = WiaDevice.GetFirstScannerDevice().AsScannerDevice(); }
                catch (COMException comException) { MessageBox.Show(WiaException.GetMessageFromComException(comException), "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error); }



                this.UseWaitCursor = true;
                SetLoading(true);

                DocumentHandlingSelect documentHandlingSelect = this._DocumentHandlingSelect;
                CurrentIntent currentIntent = this._CurrentIntent;
                SizeF documentSize = this._DocumentSize;

                int threshold = 128;
                bool hasmorePage = true;
                bool isScaned = false;
                while (hasmorePage)
                {
                    try
                    {
                        // Einstellungen für das Scanner-Gerät
                        this._ScannerDevice.DeviceSettings.DocumentHandlingSelect = documentHandlingSelect;
                        //this._ScannerDevice.DeviceSettings.Pages = (this._ScannerDevice.DeviceSettings.DocumentHandlingSelect == DocumentHandlingSelect.Duplex) ? 2 : 1;

                        // Einstellungen für das Scandokument
                        this._ScannerDevice.PictureSettings.CurrentIntent = currentIntent;
                        this._ScannerDevice.PictureSettings.HorizontalResolution = this._Resolution;
                        this._ScannerDevice.PictureSettings.VerticalResolution = this._Resolution;
                        this._ScannerDevice.PictureSettings.HorizontalExtent = (int)(documentSize.Width * this._Resolution);
                        this._ScannerDevice.PictureSettings.VerticalExtent = (int)(documentSize.Height * this._Resolution);
                        this._ScannerDevice.PictureSettings.Threshold = threshold;

                        // Scanvorgang durchführen
                        List<Image> images = this._ScannerDevice.PerformScan().ToList();
                        isScaned = true;
                        for (int j = 0; j < images.Count; j++)
                        {
                            // Bild in Fenster anzeigen

                            string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
                            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "~Mahba");
                            string documentPath = Path.Combine(tempPath, fileName + ".jpg").ToString();
                            int i = 0;
                            while (System.IO.File.Exists(documentPath))
                            {
                                documentPath = Path.Combine(tempPath, fileName + "(" + (++i).ToString() + ")" + ".jpg").ToString();
                            }
                            try
                            {
                                Njit.Common.Helpers.ImageHelper.ConvertImage(images[j], System.Drawing.Imaging.ImageFormat.Jpeg, Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionNone, documentPath);
                                SaveDocument2(documentPath);
                            }
                            catch (Exception ex)
                            {
                                this.UseWaitCursor = false;
                                SetLoading(false);
                                hasmorePage = false;
                                PersianMessageBox.Show(this, "خطا در ذخیره فایل اسکن شده" + "\r\n\r\n" + ex.Message);
                                return;
                            }


                        }

                    }
                    catch (COMException ex)
                    {
                        this.UseWaitCursor = false;
                        SetLoading(false);
                        hasmorePage = false;
                        string message = WiaException.GetMessageFromComException(ex);
                        if (message == "PaperEmpty." && isScaned)
                        {
                            LoadDocuments_IN_Left_Panle();
                            return;
                        }
                        else
                        {
                            LoadDocuments_IN_Left_Panle();
                            MessageBox.Show(message, "خطای اسکنر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        this.UseWaitCursor = false;
                        hasmorePage = false;
                        SetLoading(false);
                        if (ex.Message == "Value does not fall within the expected range." && isScaned)
                        {
                            LoadDocuments_IN_Left_Panle();
                            return;
                        }
                        else
                        {
                            LoadDocuments_IN_Left_Panle();
                            MessageBox.Show(ex.ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                // UI in den Bereit-zum-SpeichernOderWiederholen-Modus versetzen

                LoadDocuments_IN_Left_Panle();
            }
            else
            {
                PersianMessageBox.Show("هیچ سندی انتخاب نشده است");
            }
            this.UseWaitCursor = false;
            SetLoading(false);
        }

        #endregion

        private void colorSlider2_Scroll(object sender, ScrollEventArgs e)
        {
            if (CanRefreshThumbs(e.Type))
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "FieldPanel");
                if (query.Count() == 1)
                {
                    query.FirstOrDefault().Height = e.NewValue;
                    dc.SubmitChanges();
                }
                else
                {
                    Model.Common.FormState state = Model.Common.FormState.GetNewInstance(Environment.MachineName, "FieldPanel", 0, 400, e.NewValue, 0, 0);
                    Model.Common.FormState.Insert(dc, state);
                    dc.SubmitChanges();
                    query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "FieldPanel");
                }
                pnlFields.Size = new Size(query.FirstOrDefault().Width, e.NewValue);
            }
        }

        private void ArchiverDocumentManagement_Load(object sender, EventArgs e)
        {

        }
    }

}
