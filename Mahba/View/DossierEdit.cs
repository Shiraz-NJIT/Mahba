using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NjitSoftware.View
{
    public partial class DossierEdit : View.BaseForms.DosssierAddEdit
    {
        public DossierEdit()
            : this(null)
        {
        }

        public DossierEdit(string personnelNumber)
        {
            InitializeComponent();
            this.PersonnelNumberTextBox.Text = personnelNumber ?? "";
            if (!personnelNumber.IsNullOrEmpty())
                this.SelectedDossier = Controller.Archive.DossierController.Select(personnelNumber);
            PersonnelNumberTextBox.KeyDown += txtPersonnelNumber_KeyDown;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                btnImportFiles.PerformClick();
                return true;
            }
            if (keyData == Keys.F2)
            {
                buttonExtended1.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSaveDossier_Click(btnSaveDossier, EventArgs.Empty);
                return true;
            }
            if (keyData == Keys.F2)
            {
                btnNewDossier_Click(btnNewDossier, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                btnShowDocuments.PerformClick();
                return true;
            } if (keyData == (Keys.Control | Keys.E))
            {
                btnExit.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtPersonnelNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            if (PersonnelNumberTextBox.Text.IsNullOrEmpty())
                return;
            if (LoadPersonnelInfo(PersonnelNumberTextBox.Text))
                btnNewDossier.Enabled = btnImportFiles.Enabled = btnShowDocuments.Enabled =buttonExtended1.Enabled= true;
            else
                btnNewDossier.Enabled = btnImportFiles.Enabled = btnShowDocuments.Enabled = buttonExtended1.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EnableOrDisableThisForm(false, false);
            SetPersonnelNumberAutoComplate();
            if (!this.PersonnelNumberTextBox.Text.IsNullOrEmpty() && LoadPersonnelInfo(PersonnelNumberTextBox.Text))
                btnNewDossier.Enabled = btnImportFiles.Enabled = btnShowDocuments.Enabled = true;
            else
                btnNewDossier.Enabled = btnImportFiles.Enabled = btnShowDocuments.Enabled = false;
           
        }

        public void EnableOrDisableThisForm(bool status, bool resetText)
        {
            if (resetText)
            {
                imageData = null;
                pictureBoxPersonnel.Image = Properties.Resources.Person;
                txtDocumentsCount.Text = "0";
            }
            if (status)
                btnNewDossier.Text = "انصراف";
            else
                btnNewDossier.Text = "ویرایش";

            btnSetImage.Enabled = status;
            btnEditPersonnelNumber.Enabled = btnSaveDossier.Enabled = status;
            dossierTypeComboBoxExtended.Enabled = status;
            DossierFormHelper.EnableOrDisableTabcontrol(tabControlExtended, status, resetText);
            PersonnelNumberTextBox.Enabled = !status;
            Control lblPersonnelNumber = GetPersonnelNumberLabel();
            if (lblPersonnelNumber != null)
                lblPersonnelNumber.Enabled = !status;
            if (!status)
                PersonnelNumberTextBox.Focus();
        }

        private Control GetPersonnelNumberLabel()
        {
            foreach (TabPage tab in tabControlExtended.TabPages)
            {
                foreach (Control c in tab.Controls)
                {
                    if (c.Name == "PersonnelNumberLabel")
                        return c;
                }
            }
            return null;
        }

        private void SetPersonnelNumberAutoComplate()
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange(Controller.Archive.DossierController.GetAllPersonnelNumbers());
            PersonnelNumberTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            PersonnelNumberTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            PersonnelNumberTextBox.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.SelectedDossier.IsNullOrEmpty())
                return;
            if (!isAccessPermission(this.SelectedDossier))
            {
                PersianMessageBox.Show(this, string.Format("مجوز دسترسی به پرونده های با سطح دسترسی '{0}' برای شما صادر نشده است", this.SelectedDossier.DossierType.Title));
                this.Close();
                return;
            }
            SetDossierDocumentsCount(this.SelectedDossier);
            LoadPersonnelImage(this.SelectedDossier);
        }
        //مجوز دسترس به پرونده را دارد یا خیر 
        private bool isAccessPermission(Model.Archive.Dossier dossier)
        {
            //اگر ادمین باشد نیازی نیست
            if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
                return true;
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            //لیست نوع دسترسی
            List<Model.Common.PermissionDossier> listSecurity = dc.PermissionDossiers.Where(q => q.User.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code && q.PK_Archive == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID).ToList();
          return  listSecurity.Exists(q => q.DossierType == dossier.DossierSecurityID);
        }

        private Model.Archive.Dossier _SelectedDossier = null;
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        private bool LoadPersonnelInfo(string personelNumber)
        {
            this.SelectedDossier = Controller.Archive.DossierController.Select(personelNumber);
            if (!this.SelectedDossier.IsNullOrEmpty())
            {
                if (!isAccessPermission(this.SelectedDossier)) 
                {
                    PersianMessageBox.Show(this, string.Format("مجوز دسترسی به پرونده های با سطح دسترسی '{0}' برای شما صادر نشده است", this.SelectedDossier.DossierType.Title));
                    this.SelectedDossier = null;
                    EnableOrDisableThisForm(false, true);
                    return false;
                }
            }
            else
            {
                EnableOrDisableThisForm(false, true);
                return false;
            }
            dossierTypeComboBoxExtended.SelectedItem = dossierTypeComboBoxExtended.Items.Cast<Njit.Program.Controls.ComboBoxExtended.CustomItem>().Where(t => (int)t.Value == this.SelectedDossier.DossierSecurityID).Single();

            List<Model.Archive.ArchiveTab> allArchiveTabs = Controller.Archive.DossierCacheController.GetActiveDossierTabs();
            foreach (Model.Archive.ArchiveTab archiveTab in allArchiveTabs)
            {
                Controller.Archive.DossierController.LoadPersonnelDataToControl(tabControlExtended.TabPages[archiveTab.Name], archiveTab, personelNumber);
            }
            LoadContactInfo(this.SelectedDossier);
            SetDossierDocumentsCount(this.SelectedDossier);
            LoadPersonnelImage(this.SelectedDossier);
            //لاگ گیری برای مشاهده پرونده
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.مشاهده_پرونده, PersonnelNumberTextBox.Text, "");
             
            return true;
        }

        private void LoadPersonnelImage(Model.Archive.Dossier dossier)
        {
            if (dossier.PersonnelImage.IsNullOrEmpty())
            {
                imageData = null;
                pictureBoxPersonnel.Image = Properties.Resources.Person;
                return;
            }
            imageData = dossier.PersonnelImage.ToArray();
            MemoryStream ms = new MemoryStream(imageData);
            Image Img = Image.FromStream(ms);
            pictureBoxPersonnel.Image = Njit.Common.Helpers.ImageHelper.GetThumbnail(Img, pictureBoxPersonnel.Size, Color.White);
            Img.Dispose();
            ms.Close();
            ms.Dispose();
        }

        private void LoadContactInfo(Model.Archive.Dossier dossier)
        {
            if (!Setting.Archive.ThisProgram.LoadedArchiveSettings.InfoGroupTab)
                return;

            List<Model.Archive.ContactView> contactView = Controller.Archive.ContactController.Select(dossier.PersonnelNumber);
            contactViewBindingSource.DataSource = contactView;

            List<Model.Archive.AddressView> addressView = Controller.Archive.AddressController.Select(dossier.PersonnelNumber);
            addressViewBindingSource.DataSource = addressView;

            Model.Archive.Info info = Controller.Archive.InfoController.Select(dossier.PersonnelNumber);
            if (info.IsNullOrEmpty())
            {
                txtComment.Text = null;
                txtEmail.Text = null;
                txtWebsite.Text = null;
                return;
            }
            txtComment.Text = info.Comment;
            txtEmail.Text = info.Email;
            txtWebsite.Text = info.Website;
        }

        private void btnNewDossier_Click(object sender, EventArgs e)
        {
            if (btnNewDossier.Text == "ویرایش")
            {
                txtPersonnelNumber_KeyDown(this, new KeyEventArgs(Keys.Enter));
                EnableOrDisableThisForm(true, false);
            }
            else
            {
                string PersonNumber = PersonnelNumberTextBox.Text;
                EnableOrDisableThisForm(false, true);
                PersonnelNumberTextBox.Text = PersonNumber;
                txtPersonnelNumber_KeyDown(this, new KeyEventArgs(Keys.Enter));
            }
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
        {
            if (this.SelectedDossier == null)
            {
                PersianMessageBox.Show(this, "هیچ پرونده ای انتخاب نشده است");
                return;
            }
            if (CheckValidationsForSave(this.SelectedDossier.PersonnelNumber))
            {
                if (SaveInformation())
                    EnableOrDisableThisForm(false, false);
            }
        }

        private bool SaveInformation()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<Model.Archive.ArchiveTab> archiveTabs = Controller.Archive.ArchiveTabController.GetActiveDossierTabs();
                Model.Archive.Dossier dossier = Model.Archive.Dossier.GetNewInstance(PersonnelNumberTextBox.Text, imageData.IsNullOrEmpty() ? null : new System.Data.Linq.Binary(imageData), this.SelectedDossier.FilesPathOrDatabaseName, int.Parse((dossierTypeComboBoxExtended.SelectedItem as Njit.Program.Controls.ComboBoxExtended.CustomItem).Value.ToString()));
                List<System.Data.SqlClient.SqlCommand> sqlCommandList = new List<System.Data.SqlClient.SqlCommand>();
                foreach (Model.Archive.ArchiveTab tab in archiveTabs)
                {
                    sqlCommandList.Add(SqlHelper.GetDeleteCommandForArchiveTab(tab, PersonnelNumberTextBox.Text));
                    foreach (var archiveField in tab.ArchiveFields)
                    {
                        if (archiveField.FieldTypeCode == (int)Enums.FieldTypes.زیرگروه_جدولی)
                            sqlCommandList.Add(SqlHelper.GetDeleteCommandForArchiveField(archiveField, PersonnelNumberTextBox.Text));
                    }
                    List<System.Data.SqlClient.SqlCommand> sqlCommands = SqlHelper.GetDossierInsertCommands(tabControlExtended.TabPages[tab.Name], tab, PersonnelNumberTextBox.Text);
                    sqlCommandList.AddRange(sqlCommands);
                }
                //--------------- ذخیره اطلاعات تماس و آدرس
                List<Model.Archive.ContactView> contactView = new List<Model.Archive.ContactView>();
                List<Model.Archive.AddressView> addressView = new List<Model.Archive.AddressView>();
                Model.Archive.Info info = null;
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.InfoGroupTab)
                {
                    foreach (Model.Archive.ContactView item in contactViewBindingSource)
                    {
                        item.PersonnelNumber = PersonnelNumberTextBox.Text;
                        contactView.Add(item);
                    }
                    foreach (Model.Archive.AddressView item in addressViewBindingSource)
                    {
                        item.PersonnelNumber = PersonnelNumberTextBox.Text;
                        addressView.Add(item);
                    }
                    if (!(string.IsNullOrEmpty(txtComment.Text) && string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtWebsite.Text)))
                        info = Model.Archive.Info.GetNewInstance(PersonnelNumberTextBox.Text, txtComment.Text, txtEmail.Text, txtWebsite.Text);
                }
                Controller.Archive.DossierController.Update(dossier, sqlCommandList, contactView, addressView, info);
                EnableOrDisableForm(false, false);
                PersianMessageBox.Show("اطلاعات پرونده با موفقیت ثبت گردید");
                return true;
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEditPersonnelNumber_Click(object sender, EventArgs e)
        {
            if (SelectedDossier == null)
                return;
            using (View.PersonnelNumberEdit f = new PersonnelNumberEdit(SelectedDossier.PersonnelNumber))
            {
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PersonnelNumberTextBox.Text = f.Tag.ToString();
                    LoadPersonnelInfo(PersonnelNumberTextBox.Text);
                   
             
                }
            }
           
        }

        private void buttonExtended1_Click(object sender, EventArgs e)
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
    }
}
