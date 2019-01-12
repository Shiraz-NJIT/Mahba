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
    public partial class DossierNew : View.BaseForms.DosssierAddEdit2
    {
        public DossierNew()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            PersonnelNumberTextBox.KeyDown += txtPersonnelNumber_KeyDown;
        }

        private void txtPersonnelNumber_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData != Keys.Enter)
                return;
            if (PersonnelNumberTextBox.Text.IsNullOrEmpty())
                return;
            if (LoadPersonnelInfo(PersonnelNumberTextBox.Text))
                btnNewDossier.Enabled = btnImportFiles.Enabled = btnShowDocuments.Enabled = true;
            else
                btnNewDossier.Enabled = btnImportFiles.Enabled = btnShowDocuments.Enabled = true;
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
        public void EnableOrDisableThisForm(bool status, bool resetText)
        {
            if (resetText)
            {
                imageData = null;
                pictureBoxPersonnel.Image = Properties.Resources.Person;
                txtDocumentsCount.Text = "0";
            }
            //if (status)
            //    btnNewDossier.Text = "انصراف";
            //else
            //    btnNewDossier.Text = "ویرایش";
            status = true;
            btnSetImage.Enabled = status;
            //btnEditPersonnelNumber.Enabled = btnSaveDossier.Enabled = status;
            dossierTypeComboBoxExtended.Enabled = status;
            DossierFormHelper.EnableOrDisableTabcontrol(tabControlExtended, status, resetText);
            //PersonnelNumberTextBox.Enabled = !status;
            //Control lblPersonnelNumber = GetPersonnelNumberLabel();
            //if (lblPersonnelNumber != null)
            //    lblPersonnelNumber.Enabled = !status;
            //if (!status)
            //    PersonnelNumberTextBox.Focus();
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
        private static DossierNew _Instance;
        public static DossierNew Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DossierNew();
                if (_Instance.IsDisposed)
                    _Instance = new DossierNew();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetPersonnelNumberAutoComplate();
            EnableOrDisableForm(true, false);
        }

        private void btnNewDossier_Click(object sender, EventArgs e)
        {
            EnableOrDisableForm(true, true);
            PersonnelNumberTextBox.Focus();
            btnImportFiles.Enabled = btnShowDocuments.Enabled = true;
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
        {
            if (CheckValidationsForSave(null))
                SaveInformation();
        }

        private void SetPersonnelNumberAutoComplate()
        {
            PersonnelNumberTextBox.AutoCompleteList = Controller.Archive.DossierController.GetAllPersonnelNumbers().ToList();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.A))
            {
                btnImportFiles.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                btnSaveDossier_Click(btnSaveDossier, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.E))
            {
                btnNewDossier_Click(btnNewDossier, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                btnShowDocuments.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.Q))
            {
                btnExit.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void SaveInformation()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                Njit.Common.SystemUtility sysUtil;
                try
                {
                    sysUtil = Njit.Program.Options.GetSystemUtility(dc.Connection as System.Data.SqlClient.SqlConnection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                }
                catch (Exception ex)
                {
                    throw new Exception("خطا در اتصال به سرور" + "\r\n" + ex.Message);
                }
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase == false && !sysUtil.DirectoryExists(Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName))
                    throw new Exception("مسیر ذخیره اسناد نامعتبر است\r\nلطفا در قسمت تنظیمات برنامه مسیر ذخیره اسناد را انتخاب کنید" + "\r\n" + Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName);
                List<Model.Archive.ArchiveTab> archiveTabs = Controller.Archive.ArchiveTabController.GetActiveDossierTabs();
                Model.Archive.Dossier dossier = Model.Archive.Dossier.GetNewInstance(PersonnelNumberTextBox.Text, imageData.IsNullOrEmpty() ? null : new System.Data.Linq.Binary(imageData), Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase ? Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName : Path.Combine(Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName, Njit.Common.PublicMethods.ReplaceInvalidPathAndFileNameChars(PersonnelNumberTextBox.Text, "-")), int.Parse((dossierTypeComboBoxExtended.SelectedItem as Njit.Program.Controls.ComboBoxExtended.CustomItem).Value.ToString()));
                List<System.Data.SqlClient.SqlCommand> sqlCommandList = new List<System.Data.SqlClient.SqlCommand>();
                foreach (Model.Archive.ArchiveTab item in archiveTabs)
                {
                    List<System.Data.SqlClient.SqlCommand> sqlCommand = SqlHelper.GetDossierInsertCommands(tabControlExtended.TabPages[item.Name], item, PersonnelNumberTextBox.Text);
                    sqlCommandList.AddRange(sqlCommand);
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
                Controller.Archive.DossierController.Insert(dossier, sqlCommandList, contactView, addressView, info);
                EnableOrDisableForm(false, false);
                var result = PersianMessageBox.Show(this, "اطلاعات پرونده با موفقیت ثبت گردید", "اطلاعات ثبت شد", new Njit.MessageBox.VDialogButton[] { new Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.OK, "ثبت اسناد پرونده"), new Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Continue, "ثبت پرونده جدید"), new Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Cancel, "خروج") }, Njit.MessageBox.VDialogIcon.Question, Njit.MessageBox.VDialogDefaultButton.Button1, System.Windows.Forms.RightToLeft.Yes, false, null, null, null, null, null);
                if (result == Njit.MessageBox.VDialogResult.Cancel)
                    this.Close();
                else if (result == Njit.MessageBox.VDialogResult.Continue)
                    InvokeOnClick(btnNewDossier, EventArgs.Empty);
                else if (result == Njit.MessageBox.VDialogResult.OK)
                {
                    Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                    if (currentUser != null)
                    {
                        if (IsMembershipInAdministartorRole(currentUser))
                        {
                            using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(dossier.PersonnelNumber,0))
                            {
                                this.Close();
                                f.ShowDialog();
                            }
                        }
                        else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                        {

                            using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(dossier.PersonnelNumber, 0))
                            {
                                this.Close();
                                f.ShowDialog();
                            }
                        }
                        else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                        {

                            using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(dossier.PersonnelNumber,0))
                            {
                                this.Close();
                                f.ShowDialog(this);
                            }
                        }
                        else
                        {
                            PersianMessageBox.Show("شما به صفحه اضافه کردن اسناد دسترسی ندارید");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

       
    }
}
