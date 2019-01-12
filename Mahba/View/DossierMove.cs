using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class DossierMove : Njit.Program.Forms.OKCancelForm
    {
        public DossierMove()
        {
            InitializeComponent();
            txtArchive1.Text = Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Title;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (!Setting.User.ThisProgram.CheckUserAccessPermission(Setting.User.AccessPermissionUnits.Archive, cmArchive.SelectedValue.ToString()))
                {
                    PersianMessageBox.Show(this, string.Format("مجوز دسترسی به بایگانی '{0}' برای شما صادر نشده است", cmArchive.SelectedText));
                    return;
                }
                int thisArchive = Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.ID;
                //نام و نام خانوادگی و کد ملی به همراه تمام اسناد آنرا کپی می کنیم
                string Name = "", Family = "", NN = "";
                Model.Archive.Dossier Dossier1 = Controller.Archive.DossierController.Get(txtDossier1.Text);
                if (Dossier1 != null)
                {
                    object obj = SqlHelper.GetArchiveFieldValue("Dossier1", "Field1", this.txtDossier1.Text);
                    if (obj != null)
                    {

                        Name = obj.ToString();
                        object obj2 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field2", txtDossier1.Text);
                        if (obj2 != null)
                        {
                            Family = obj2.ToString();
                        }
                    }
                    //کد ملی
                    object obj3 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field15", this.txtDossier1.Text);
                    if (obj3 != null)
                    {
                        NN = obj3.ToString();
                    }
                    //لیست اسناد
                    List<Model.Archive.Document> listdoc = Controller.Archive.DocumentController.GetDocuments(txtDossier1.Text).ToList();

                    //رفتن به بایگانی انتخابی
                    Setting.Archive.ThisProgram.SelectedArchiveTree.Archive = Controller.Common.ArchiveController.GetActiveArchives().Where(q => q.ID.ToString() == cmArchive.SelectedValue.ToString()).FirstOrDefault();

                    try
                    {
                        Model.Archive.Dossier dossier = new Model.Archive.Dossier();
                        dossier.PersonnelNumber = txtDossier2.Text;
                        dossier.PersonnelImage = Dossier1.PersonnelImage;
                        dossier.FilesPathOrDatabaseName = Dossier1.FilesPathOrDatabaseName;
                        dossier.DossierSecurityID = Dossier1.DossierSecurityID;
                        //اضافه کردن سند جدید
                        Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                        dc.Connection.Open();
                        dc.Transaction = dc.Connection.BeginTransaction();
                        try
                        {
                            Controller.Archive.DossierController.Insret(dossier, dc);
                            //------------

                            try
                            {
                                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.پرونده, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + txtDossier2.Text);
                            }
                            catch
                            {
                                throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                            }
                            dc.Transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dc.Transaction.Rollback();
                            throw new Exception(ex.Message);
                        }
                        finally
                        {
                            dc.Connection.Close();
                        }
                            //اضافه کردن نام  نام خانوادگی و کد ملی
                            SqlHelper.InsertDossier1(txtDossier2.Text, Name, Family, NN);
                        //اضافه کردن سند ها به پرونده جدید
                      
                        foreach (var item in listdoc)
                        {
                            Model.Archive.Document document = item;
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
                                    file = System.IO.Path.Combine(document.Dossier.FilesPathOrDatabaseName, document.FileName);
                                }
                                Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.GetName("Document2");
                                Controller.Archive.DocumentController.AddDocument(txtDossier2.Text, file, null, false, (Njit.Program.ComponentOne.Enums.SaveFormats)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? ((int)Njit.Program.ComponentOne.Enums.SaveFormats.None)), (Njit.Program.ComponentOne.Enums.CompressionTypes)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? ((int)Njit.Program.ComponentOne.Enums.CompressionTypes.None)), archiveTab);

                                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.کپی_سند, txtDossier2.Text, "کپی سند شماره:" + document.Number);
                            }
                            catch (Exception ex)
                            {
                                PersianMessageBox.Show(this, "خطا در کپی سند شماره " + document.Number + "\r\n\r\n" + ex.Message);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Setting.Archive.ThisProgram.SelectedArchiveTree.Archive = Controller.Common.ArchiveController.GetActiveArchives().Where(q => q.ID == thisArchive).FirstOrDefault();
                        MessageBox.Show(ex.Message);
                    }
                }
                //برگشت به بایگانی اولیه
                Setting.Archive.ThisProgram.SelectedArchiveTree.Archive = Controller.Common.ArchiveController.GetActiveArchives().Where(q => q.ID == thisArchive).FirstOrDefault();
                MessageBox.Show("پرونده با موفقیت انتقال پیدا کرد.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtDossier1_Leave(object sender, EventArgs e)
        {
            txtDossier2.Text = txtDossier1.Text;
            if (!txtDossier1.Text.IsNullOrEmpty())
            {
                Validation();
                
            }
            string Name="",Family="";
                object obj = SqlHelper.GetArchiveFieldValue("Dossier1", "Field1", this.txtDossier1.Text);
                if (obj != null)
                {

                    Name = obj.ToString();
                    object obj2 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field2", txtDossier1.Text);
                    if (obj2 != null)
                    {
                        Family = obj2.ToString();
                    }
                }
                MessageBox.Show("نام و نام خانوادگی پرونده انتخابی :"+Name+" "+Family);
        }

        private bool Validation()
        {
            if (!Controller.Archive.DossierController.CheckExistPersonnelNumber(txtDossier1.Text))
            {
                MessageBox.Show("شماره پرونده" + "'" + txtDossier1.Text + "'" + "دربایگانی" + "'" + txtArchive1.Text + "'" + " وجود ندارد.");
                return false;
            }

            int thisArchive = Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.ID;
            //رفتن به بایگانی انتخابی
            Setting.Archive.ThisProgram.SelectedArchiveTree.Archive = Controller.Common.ArchiveController.GetActiveArchives().Where(q => q.ID.ToString() == cmArchive.SelectedValue.ToString()).FirstOrDefault();
            //چک کردن اینکه ایا در بایگانی انتخابی شماره پرونده انتخابی وجود دارد ایا خیر
            if (Controller.Archive.DossierController.CheckExistPersonnelNumber(txtDossier2.Text))
            {
                MessageBox.Show("شماره پرونده" + "'" + txtDossier2.Text + "'" + "دربایگانی" + "'" + Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Title + "'" + " وجود دارد لطفا یک شماره پرونده دیگر انتخاب کنید.");
                Setting.Archive.ThisProgram.SelectedArchiveTree.Archive = Controller.Common.ArchiveController.GetActiveArchives().Where(q => q.ID == thisArchive).FirstOrDefault();
                return false;
            }
            //برگشت به بایگانی اولیه
            Setting.Archive.ThisProgram.SelectedArchiveTree.Archive = Controller.Common.ArchiveController.GetActiveArchives().Where(q => q.ID == thisArchive).FirstOrDefault();
            return true;
        }

        private void DossierMove_Load(object sender, EventArgs e)
        {
            List<Model.Common.Archive> listArchive = Controller.Common.ArchiveController.GetActiveArchives().ToList();
            listArchive.RemoveAll(q => q.ID == Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.ID);
            cmArchive.DataSource = listArchive;
            cmArchive.ValueMember = "ID";
            cmArchive.DisplayMember = "Title";
        }
    }
}
