using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AutoCompleteTextBoxSample;

namespace NjitSoftware.View.BaseForms
{
    public partial class DosssierAddEdit : Njit.Program.Forms.BaseFormSizable
    {
        public DosssierAddEdit()
        {
            InitializeComponent();
            callTypeComboBoxExtended.DataAccessRequest += ComboBoxExtendeds_DataAccessRequest;
            addressComboBoxExtended.DataAccessRequest += ComboBoxExtendeds_DataAccessRequest;
            provinceComboBoxExtended.DataAccessRequest += ComboBoxExtendeds_DataAccessRequest;
            areaComboBoxExtended.DataAccessRequest += ComboBoxExtendeds_DataAccessRequest;
           dossierTypeComboBoxExtended.DataAccessRequest += ComboBoxExtendeds_DataAccessRequest;
        }

        private void ComboBoxExtendeds_DataAccessRequest(object sender, Njit.Program.Controls.ComboBoxExtended.DataAccessRequestEventArgs e)
        {
            if (!this.DesignMode)
                e.DataAccess = DataAccess.ArchiveDataAccess.GetNewInstance();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
                LoadAllTabs();
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            try
            {
                SelectPersonnelPicture();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا" + "\r\n\r\n" + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public byte[] imageData;

        private void SelectPersonnelPicture()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                if (fileInfo.Exists & fileInfo.Length < (250 * 1024))
                {
                    imageData = System.IO.File.ReadAllBytes(openFileDialog.FileName);
                    if (pictureBoxPersonnel.Image != null)
                        pictureBoxPersonnel.Image.Dispose();
                    pictureBoxPersonnel.Image = Image.FromFile(openFileDialog.FileName);
                }
                else
                {
                    PersianMessageBox.Show(this, "حداکثر اندازه تصویر ورودی 250 KB می باشد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SelectPersonnelPicture();
                }
            }
        }

        private TextBox _PersonnelNumberTextBox;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected TextBox PersonnelNumberTextBox
        {
            get
            {
                if (_PersonnelNumberTextBox == null)
                {
                    _PersonnelNumberTextBox = DossierFormHelper.CreateTextBox(Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label, "PersonnelNumber", (int)Enums.FieldTypes.متن, Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_MinLength, Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_MaxLength, null, null, null, 0, 0, System.Windows.Forms.RightToLeft.No);
                    _PersonnelNumberTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
                    _PersonnelNumberTextBox.TextChanged += PersonnelNumberTextBox_TextChanged;
                }
                return _PersonnelNumberTextBox;
            }
            set
            {
                _PersonnelNumberTextBox = value;
            }
        }

        private void PersonnelNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as Control, null);
            if (PersonnelNumberTextBox.Text.IsNullOrEmpty())
                pictureBoxBarcode.Image = null;
            else
            {
                try
                {
                    Vintasoft.Barcode.BarcodeWriter b = new Vintasoft.Barcode.BarcodeWriter();
                    b.Settings.Barcode = Vintasoft.Barcode.BarcodeType.Code128;
                    b.Settings.SetWidth(pictureBoxBarcode.Width, Vintasoft.Barcode.UnitOfMeasure.Pixels);
                    b.Settings.SetHeight(pictureBoxBarcode.Height, Vintasoft.Barcode.UnitOfMeasure.Pixels);
                    b.Settings.Value = PersonnelNumberTextBox.Text;
                    pictureBoxBarcode.Image = b.GetBarcodeAsBitmap();
                }
                catch
                {
                    pictureBoxBarcode.Image = null;
                }
            }
        }

        public bool CheckPersonnelNumber(string originalPersonnelNumber)
        {
            if (PersonnelNumberTextBox.Text == "")
            {
                PersianMessageBox.Show(this, PersonnelNumberTextBox.Tag + " تکمیل نشده است ");
                errorProvider.SetError(PersonnelNumberTextBox, PersonnelNumberTextBox.Tag + " تکمیل نشده است ");
                PersonnelNumberTextBox.Focus();
                return false;
            }
            else
            {
                if (Controller.Archive.DossierController.CheckPersonnelNumberAlreadyExist(PersonnelNumberTextBox.Text, originalPersonnelNumber))
                {
                    PersianMessageBox.Show(this, PersonnelNumberTextBox.Tag + " نباید تکراری باشد ");
                    errorProvider.SetError(PersonnelNumberTextBox, PersonnelNumberTextBox.Tag + " نباید تکراری باشد ");
                    PersonnelNumberTextBox.Focus();
                    return false;
                }
                else
                    return true;
            }
        }

        public bool CheckTabFields(TabPage tabPage)
        {
            int archiveTabID = (int)tabPage.Tag;
            List<Model.Archive.ArchiveField> fields = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTabID);
            foreach (Control control in tabPage.Controls)
            {
                string errorMessage = DossierFormHelper.CheckControlData(PersonnelNumberTextBox.Text, tabPage.Name, fields, control);
                if (errorMessage != null)
                {
                    PersianMessageBox.Show(this, errorMessage);
                    errorProvider.SetError(control, errorMessage);
                    control.Focus();
                    tabControlExtended.SelectedTab = tabPage;
                    return false;
                }
            }
            return true;
        }

        private void CallMovebuttonExtended_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CallValidateContent())
                    return;
                Model.Archive.ContactView _ContactView = Model.Archive.ContactView.GetNewInstance(null, (int)((Njit.Program.Controls.ComboBoxExtended.CustomItem)(callTypeComboBoxExtended.SelectedItem)).Value, callTypeComboBoxExtended.SelectedItem.ToString(), NumbertextBoxExtended.Text, CommenttextBoxExtended.Text);
                contactViewBindingSource.Add(_ContactView);
                NumbertextBoxExtended.Text = "";
                CommenttextBoxExtended.Text = "";
                callTypeComboBoxExtended.Focus();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا" + "\r\n" + ex.Message);
            }
        }

        private void AddressMovebuttonExtended_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AddressValidateContent())
                    return;
                Model.Archive.AddressView addressView = Model.Archive.AddressView.GetNewInstance(0, null,
                    (int)((Njit.Program.Controls.ComboBoxExtended.CustomItem)(addressComboBoxExtended.SelectedItem)).Value,
                    addressComboBoxExtended.SelectedItem.ToString(), (int)((Njit.Program.Controls.ComboBoxExtended.CustomItem)(provinceComboBoxExtended.SelectedItem)).Value,
                    provinceComboBoxExtended.SelectedItem.ToString(), townshipTextBoxExtended.Text,
                   (int)((Njit.Program.Controls.ComboBoxExtended.CustomItem)(areaComboBoxExtended.SelectedItem)).Value, areaComboBoxExtended.SelectedItem.ToString(),
                    streetTextBoxExtended.Text, alleyTextBoxExtended.Text, postalCodeTextBoxExtended.Text);
                addressViewBindingSource.Add(addressView);
                townshipTextBoxExtended.Text = "";
                streetTextBoxExtended.Text = "";
                alleyTextBoxExtended.Text = "";
                postalCodeTextBoxExtended.Text = "";
                addressComboBoxExtended.Focus();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        private bool CallValidateContent()
        {
            if (callTypeComboBoxExtended.Text == "")
            {
                PersianMessageBox.Show(this, "نوع تماس تکمیل نشده است");
                errorProvider.SetError(callTypeComboBoxExtended, "نوع تماس تکمیل نشده است");
                callTypeComboBoxExtended.Focus();
                return false;
            }
            if (callTypeComboBoxExtended.SelectedIndex == -1)
            {
                PersianMessageBox.Show(this, "نوع تماس را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان تعریف نوع های تماس بیشتر فراهم میگردد");
                errorProvider.SetError(callTypeComboBoxExtended, "نوع تماس را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان تعریف نوع های تماس بیشتر فراهم میگردد");
                callTypeComboBoxExtended.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(NumbertextBoxExtended.Text))
            {
                PersianMessageBox.Show(this, "شماره تماس تکمیل نشده است");
                errorProvider.SetError(NumbertextBoxExtended, "شماره تماس تکمیل نشده است");
                NumbertextBoxExtended.Focus();
                return false;
            }
            return true;
        }

        private bool AddressValidateContent()
        {
            if (addressComboBoxExtended.Text == "")
            {
                PersianMessageBox.Show(this, "نوع آدرس تکمیل نشده است");
                errorProvider.SetError(addressComboBoxExtended, "نوع آدرس تکمیل نشده است");
                addressComboBoxExtended.Focus();
                return false;
            }
            if (addressComboBoxExtended.SelectedIndex == -1)
            {
                PersianMessageBox.Show(this, "نوع آدرس را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان تعریف نوع های آدرس بیشتر فراهم میگردد");
                errorProvider.SetError(addressComboBoxExtended, "نوع آدرس را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان تعریف نوع های آدرس بیشتر فراهم میگردد");
                addressComboBoxExtended.Focus();
                return false;
            }
            if (provinceComboBoxExtended.Text == "")
            {
                PersianMessageBox.Show(this, "استان تکمیل نشده است");
                errorProvider.SetError(provinceComboBoxExtended, "استان تکمیل نشده است");
                provinceComboBoxExtended.Focus();
                return false;
            }
            if (provinceComboBoxExtended.SelectedIndex == -1)
            {
                PersianMessageBox.Show(this, "استان را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان افزودن استان های بیشتر فراهم میگردد");
                errorProvider.SetError(provinceComboBoxExtended, "استان را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان افزودن استان های بیشتر فراهم میگردد");
                provinceComboBoxExtended.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(townshipTextBoxExtended.Text))
            {
                PersianMessageBox.Show(this, "شهرستان تکمیل نشده است");
                errorProvider.SetError(townshipTextBoxExtended, "شهرستان تکمیل نشده است");
                townshipTextBoxExtended.Focus();
                return false;
            }
            if (areaComboBoxExtended.Text == "")
            {
                PersianMessageBox.Show(this, "منطقه شهری تکمیل نشده است");
                errorProvider.SetError(areaComboBoxExtended, "منطقه شهری تکمیل نشده است");
                areaComboBoxExtended.Focus();
                return false;
            }
            if (areaComboBoxExtended.SelectedIndex == -1)
            {
                PersianMessageBox.Show(this, "منطقه شهری را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان افزودن منطقه های شهری بیشتر فراهم میگردد");
                errorProvider.SetError(areaComboBoxExtended, "منطقه شهری را از لیست انتخاب کنید\r\nبا کلیک بر روی آیتم ... امکان افزودن منطقه های شهری بیشتر فراهم میگردد");
                areaComboBoxExtended.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(streetTextBoxExtended.Text))
            {
                PersianMessageBox.Show(this, "خیابان تکمیل نشده است");
                errorProvider.SetError(streetTextBoxExtended, "خیابان تکمیل نشده است");
                streetTextBoxExtended.Focus();
                return false;
            }
            return true;
        }

        internal void LoadAllTabs()
        {
            try
            {
                List<Model.Archive.ArchiveTab> allTabs = Controller.Archive.ArchiveTabController.GetActiveDossierTabs();
                foreach (Model.Archive.ArchiveTab item in allTabs)
                {
                    CreateObjectsForTab(item);
                }
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.InfoGroupTab)
                {
                    tabControlExtended.TabPages.Remove(InfoTabPage);
                    tabControlExtended.TabPages.Add(InfoTabPage);
                }
                else
                {
                    tabControlExtended.TabPages.Remove(InfoTabPage);
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        private void CreateObjectsForTab(Model.Archive.ArchiveTab archiveTab)
        {
            try
            {
                if (archiveTab.Name != InfoTabPage.Name)
                {
                    List<Model.Archive.ArchiveField> fields = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
                    if (fields.Count == 0)
                        return;

                    tabControlExtended.TabPages.Add(archiveTab.Name, archiveTab.Title);
                    tabControlExtended.TabPages[archiveTab.Name].Tag = archiveTab.ID;
                    tabControlExtended.TabPages[archiveTab.Name].BackColor = Color.White;

                    int labelPoint_x = 650;
                    int labelPoint_y = 26;
                    int controlPoint_x = 460;
                    int controlPoint_y = 25;
                    int distance = -1;

                    if (archiveTab.Index == 1)
                    {
                        Label lblPersonnelNumber = DossierFormHelper.CreateLabel(Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label, 0, 0);
                        lblPersonnelNumber.Name = "PersonnelNumberLabel";
                        lblPersonnelNumber.Size = new Size(160, 20);
                        lblPersonnelNumber.Location = new Point(labelPoint_x, labelPoint_y);
                        lblPersonnelNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

                        PersonnelNumberTextBox.Size = new Size(160, 20);
                        PersonnelNumberTextBox.Location = new Point(controlPoint_x , controlPoint_y);
                        PersonnelNumberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        //PersonnelNumberTextBox.GetType = Njit.Program.InputBoxValidationHelper.InputTypes.AllCharacters;
                        PersonnelNumberTextBox.Tag = Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label;

                        Label lblStar = DossierFormHelper.CreateLabelStar(labelPoint_x , labelPoint_y);
                        lblStar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

                        tabControlExtended.TabPages[archiveTab.Name].Controls.Add(lblStar);
                        tabControlExtended.TabPages[archiveTab.Name].Controls.Add(lblPersonnelNumber);
                        tabControlExtended.TabPages[archiveTab.Name].Controls.Add(PersonnelNumberTextBox);

                        distance++;
                    }

                    int place = 0;
                    foreach (Model.Archive.ArchiveField archiveField in fields)
                    {
                        if ((((float)place) % 2) == 0 || archiveField.BoxTypeCode == (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی || archiveField.FieldTypeCode == (int)Enums.FieldTypes.متن_طولانی || archiveField.FieldTypeCode == (int)Enums.FieldTypes.متن_طولانی_تک_خطی)
                        {
                            distance++;
                            CreateObject(archiveTab.Name, archiveField, labelPoint_x , labelPoint_y + distance * 28, controlPoint_x, controlPoint_y + distance * 28);
                        }
                        else
                            CreateObject(archiveTab.Name, archiveField, labelPoint_x - 400, labelPoint_y + distance * 28, controlPoint_x - 400, controlPoint_y + distance * 28);

                        place++;
                        if (archiveField.BoxTypeCode == (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی)
                        {
                            distance += 7;
                            place = 0;
                        }
                        if (archiveField.FieldTypeCode == (int)Enums.FieldTypes.متن_طولانی)
                        {
                            distance += 1;
                            place = 0;
                        }
                        if (archiveField.FieldTypeCode == (int)Enums.FieldTypes.متن_طولانی_تک_خطی)
                        {
                            place = 0;
                        }
                    }
                }
                else
                {
                    InfoTabPage.Text = archiveTab.Title;
                }
                tabControlExtended.TabPages[archiveTab.Name].AutoScroll = true;
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا در بازگذاری اطلاعات" + "\r\n" + ex.Message);
            }
        }

        private void CreateObject(string tabPageName, Model.Archive.ArchiveField field, int xLabel, int yLabel, int xControl, int yControl)
        {
            try
            {
                if (field.BoxTypeCode != (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی && field.BoxTypeCode != (int)Enums.BoxTypes.کادر_انتخاب)
                {
                    Label label = DossierFormHelper.CreateLabel(field.Label, xLabel, yLabel);
                    tabControlExtended.TabPages[tabPageName].Controls.Add(label);
                }

                if (field.StatusCode == (int)Enums.StatusOfFields.مقدار_نتواند_تهی_باشد)
                {
                    Label labelStar = DossierFormHelper.CreateLabelStar(xLabel, yLabel);
                    tabControlExtended.TabPages[tabPageName].Controls.Add(labelStar);
                }
                else if (field.StatusCode == (int)Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد)
                {
                    Label labelStar = DossierFormHelper.CreateLabelStar(xLabel, yLabel);
                    labelStar.ForeColor = Color.Green;
                    tabControlExtended.TabPages[tabPageName].Controls.Add(labelStar);
                }
                switch (field.BoxTypeCode)
                {
                    case (int)Enums.BoxTypes.کادر_متن:
                        Njit.Program.Controls.TextBoxExtended textBox = DossierFormHelper.CreateTextBox(field, xControl, yControl);
                        if (field.FieldTypeCode != (int)Enums.FieldTypes.متن_طولانی)
                            textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        textBox.TextChanged += new EventHandler(Controls_TextChanged);
                        tabControlExtended.TabPages[tabPageName].Controls.Add(textBox);
                        if (field.AutoComplete)
                        {
                            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            textBox.AutoCompleteMode = AutoCompleteMode.Append;
                            textBox.AutoCompleteCustomSource.AddRange(SqlHelper.GetAllFieldValues(tabPageName, field.FieldName));
                        }
                        if (field.FieldTypeCode == (int)Enums.FieldTypes.شمارنده)
                        {
                            textBox.ReadOnly = true;
                            Model.Archive.CounterFieldSetting counterFieldSetting = Controller.Archive.ArchiveFieldController.GetCounterFieldProperties(field.ID);
                            string newValue = SqlHelper.GetNewValueOfCounterFiled(field, counterFieldSetting);
                            textBox.Text = newValue;
                        }
                        break;
                    case (int)Enums.BoxTypes.کادر_ورود_تاریخ:
                        Njit.Program.Controls.DateControl dateControl = DossierFormHelper.CreateDateBox(field, xControl, yControl);
                        dateControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        dateControl.TextChanged += new EventHandler(Controls_TextChanged);
                        tabControlExtended.TabPages[tabPageName].Controls.Add(dateControl);
                        break;
                    case (int)Enums.BoxTypes.کادر_بازشو:
                        Njit.Program.Controls.ComboBoxExtended comboBoxExtended = DossierFormHelper.CreateComboBox(field, xControl, yControl);
                        comboBoxExtended.TextChanged += new EventHandler(Controls_TextChanged);
                        comboBoxExtended.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        tabControlExtended.TabPages[tabPageName].Controls.Add(comboBoxExtended);
                        break;
                    case (int)Enums.BoxTypes.کادر_انتخاب:
                        CheckBox checkBox = DossierFormHelper.CreateChekBox(field, xLabel, yLabel);
                        checkBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        tabControlExtended.TabPages[tabPageName].Controls.Add(checkBox);
                        break;
                    case (int)Enums.BoxTypes.کادر_ورود_ساعت:
                        Njit.Program.Controls.TimeControl timeControl = DossierFormHelper.CreateTimeBox(field, xControl, yControl);
                        timeControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        tabControlExtended.TabPages[tabPageName].Controls.Add(timeControl);
                        break;
                    case (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی:
                        Njit.Program.Controls.DataGridViewExtended dataGridViewExtended = DossierFormHelper.CreateDataGridView(field);
                        dataGridViewExtended.Rows.CollectionChanged += Rows_CollectionChanged;
                        dataGridViewExtended.CurrentCellChanged += DataGridView_CurrentCellChanged;
                        GroupBox groupBox = DossierFormHelper.CreateGroupBox(field, yControl);
                        groupBox.Controls.Add(dataGridViewExtended);
                        tabControlExtended.TabPages[tabPageName].Controls.Add(groupBox);
                        break;
                    case (int)Enums.BoxTypes.کادر_انتخاب_اشخاص:
                        Njit.Program.Controls.ComboBoxExtended personComboBoxExtended = DossierFormHelper.CreatePersonComboBox(field, xControl, yControl);
                        personComboBoxExtended.TextChanged += new EventHandler(Controls_TextChanged);
                        personComboBoxExtended.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controls_KeyDown);
                        personComboBoxExtended.SelectedIndexChanged += personComboBoxExtended_SelectedIndexChanged;
                        tabControlExtended.TabPages[tabPageName].Controls.Add(personComboBoxExtended);
                        break;
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }

        private void personComboBoxExtended_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as Control, null);
        }

        public void SetDossierDocumentsCount(Model.Archive.Dossier dossier)
        {
            txtDocumentsCount.Text = Controller.Archive.DocumentController.GetDocumentsCount(dossier.PersonnelNumber).ToString();
        }

        public void SetDossierDocumentsCount(string personnelNumber)
        {
            txtDocumentsCount.Text = Controller.Archive.DocumentController.GetDocumentsCount(personnelNumber).ToString();
        }

        public bool CheckValidationsForSave(string originalPersonnelNumber)
        {
            if (dossierTypeComboBoxExtended.SelectedIndex == -1)
            {
                PersianMessageBox.Show(this, "نوع پرونده انتخاب نشده است");
                errorProvider.SetError(dossierTypeComboBoxExtended, "نوع پرونده انتخاب نشده است");
                dossierTypeComboBoxExtended.Focus();
                return false;
            }
            foreach (TabPage tabPage in tabControlExtended.TabPages)
            {
                if (tabPage.Name != InfoTabPage.Name)
                {
                    if (tabPage.Contains(PersonnelNumberTextBox))
                    {
                        if (CheckPersonnelNumber(originalPersonnelNumber) == false)
                        {
                            tabControlExtended.SelectedTab = tabPage;
                            return false;
                        }
                    }
                    if (CheckTabFields(tabPage) == false)
                    {
                        tabControlExtended.SelectedTab = tabPage;
                        return false;
                    }
                }
            }
            return true;
        }

        public void EnableOrDisableForm(bool status, bool resetText)
        {
            if (resetText)
            {
                imageData = null;
                pictureBoxPersonnel.Image = Properties.Resources.Person;
                txtDocumentsCount.Text = "0";
            }
            btnSetImage.Enabled = status;
            btnSaveDossier.Enabled = status;
            btnImportFiles.Enabled = !status;
            btnShowDocuments.Enabled = !status;
            dossierTypeComboBoxExtended.Enabled = status;
            DossierFormHelper.EnableOrDisableTabcontrol(tabControlExtended, status, resetText);
        }

        #region رویداد های مربوط به طراحی بخش پویای فرم
        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void Controls_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as Control, null);
        }

        private void Controls_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as Control, null);
        }

        private void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            // if (e.Action == CollectionChangeAction.Add||e.Action== CollectionChangeAction.Remove)
            //  errorProvider1.SetError(sender as Control, null);
        }

        private void DataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((sender as Njit.Program.Controls.DataGridViewExtended).Parent as Control, null);
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public virtual string HashData(string data)
        {
            Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
            return md5.ComputeHash(data);
        }

        internal bool IsMembershipInAdministartorRole(Model.Common.User membership)
        {
            string roleCode =this.HashData(membership.Code.ToString() + (1).ToString());
            return membership.RoleCode == roleCode;
        }
        private void btnShowDocuments_Click(object sender, EventArgs e)
        {
            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser != null)
            {
                if (IsMembershipInAdministartorRole(currentUser))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(PersonnelNumberTextBox.Text,0))
                    {
                        f.ShowDialog(this);
                        SetDossierDocumentsCount(PersonnelNumberTextBox.Text);
                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                {
                    using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(PersonnelNumberTextBox.Text,0))
                    {
                        f.ShowDialog(this);
                        SetDossierDocumentsCount(PersonnelNumberTextBox.Text);
                    }
                }
                else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                {

                    using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(PersonnelNumberTextBox.Text,0))
                    {
                        f.ShowDialog(this);
                        SetDossierDocumentsCount(PersonnelNumberTextBox.Text);
                    }
                }
            }
        }

        private void btnImportFiles_Click(object sender, EventArgs e)
        {
            using (View.ImportFiles f = new ImportFiles(PersonnelNumberTextBox.Text, null))
            {
                f.ShowDialog(this);
                SetDossierDocumentsCount(PersonnelNumberTextBox.Text);
            }
        }

        private void dossierTypeComboBoxExtended_EditItemsFormClosedAndDataRefreshed(object sender, EventArgs e)
        {
            Controller.Common.AccessPermissionTree.SaveDossierTypeTrees();
        }
    }
}