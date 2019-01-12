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
    public partial class ImportFiles : Njit.Program.ComponentOne.Forms.ImportFiles
    {
        public ImportFiles()
            : this(null, null, false)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public ImportFiles(string personnelNumber, int? documentID)
            : this(personnelNumber, documentID, false)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public ImportFiles(string personnelNumber, bool attachToDossier)
            : this(personnelNumber, null, attachToDossier)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public ImportFiles(string personnelNumber, int? documentID, bool attachToDossier)
            : base(personnelNumber == null, (Njit.Program.ComponentOne.Enums.SaveFormats)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? 0), (Njit.Program.ComponentOne.Enums.CompressionTypes)(Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? 0))
        {
            this.PersonnelNumber = personnelNumber;
            this.DocumentID = documentID;
            this.AttachToDossier = attachToDossier;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private string _PersonnelNumber = null;
        /// <summary>
        /// شماره پرونده ای که سندها به آن اضاف می شوند
        /// </summary>
        [DefaultValue(null)]
        protected string PersonnelNumber
        {
            get
            {
                return _PersonnelNumber;
            }
            set
            {
                _PersonnelNumber = value;
            }
        }

        private int? _DocumentID = null;
        /// <summary>
        /// کد سندی که سندهای جدید به آن ضمیمه میشوند
        /// </summary>
        [DefaultValue(null)]
        protected int? DocumentID
        {
            get
            {
                return _DocumentID;
            }
            set
            {
                _DocumentID = value;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                //OnPrint( EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool _AttachToDossier;
        /// <summary>
        /// آیا سندها به پرونده ضمیمه شوند
        /// </summary>
        protected bool AttachToDossier
        {
            get
            {
                return _AttachToDossier;
            }
            set
            {
                _AttachToDossier = value;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.DesignMode)
                return;
            if (this.PersonnelNumber != null && Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName.IsNullOrEmpty())
            {
                PersianMessageBox.Show("مسیر ذخیره اسناد در تنظیمات برنامه مشخص نشده است");
                this.Close();
                return;

                ////نمایش نام و نام خانوادگی
                //object obj = SqlHelper.GetArchiveFieldValue("Dossier1", "Field1", this.PersonnelNumber);
                //if (obj != null)
                //{

                //    txtName.Text = obj.ToString();
                //    object obj2 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field2", this.PersonnelNumber);
                //    if (obj2 != null)
                //    {
                //        txtName.Text += " " + obj2.ToString();
                //    }
                //}
            }
        }

        protected override void OnSaveComplete()
        {
            base.OnSaveComplete();
            if (this.PersonnelNumber != null)
                ProgramEvents.OnDocumentsChanged();
        }

        protected override void SaveFile(string file)
        {
            if (this.PersonnelNumber == null)
                base.SaveFile(file);
            else
                this.SaveDocument(file);
        }

        public void SaveDocument(string file)
        {
            Model.Archive.ArchiveTab archiveTab = Controller.Archive.ArchiveTabController.GetName("Document2");
            Controller.Archive.DocumentController.AddDocument(this.PersonnelNumber, file, this.DocumentID, this.AttachToDossier, (Njit.Program.ComponentOne.Enums.SaveFormats)this.SelectedSaveFormat, (Njit.Program.ComponentOne.Enums.CompressionTypes)this.SelectedCompressionType,archiveTab);
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.اضافه_کردن_سند_به_پرونده, _PersonnelNumber, file);
        }

        private void txtPersssonelNumber_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
