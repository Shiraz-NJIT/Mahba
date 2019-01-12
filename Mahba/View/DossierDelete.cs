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
    public partial class DossierDelete : Njit.Program.Forms.OKCancelForm
    {
        public DossierDelete(string personnelNumber)
        {
            InitializeComponent();
            this.PersonnelNumber = personnelNumber;
        }

        private string _PersonnelNumber;
        private string PersonnelNumber
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
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            System.Media.SystemSounds.Exclamation.Play();
            Model.Archive.Dossier dossier = Controller.Archive.DossierController.Select(this.PersonnelNumber);
            if (!isAccessPermission(dossier))
            {
                PersianMessageBox.Show(this, string.Format("مجوز دسترسی به پرونده های با سطح دسترسی '{0}' برای شما صادر نشده است", dossier.DossierType.Title));
                this.Close();
                return;
            }
            this.groupBoxDossier.PersonnelNumber = this.PersonnelNumber;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.Archive.DossierController.Delete(this.PersonnelNumber);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در حذف پرونده" + "\r\n\r\n" + ex.Message);
            }
            this.Close();
        }
    }
}
