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
    public partial class DossierSearch : Njit.Program.ComponentOne.Forms.ListFormWithoutSearch
    {
        public DossierSearch(string title, Operations operations, bool multiSelect)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(title))
                this.Text = title;
            CheckRibbonButtonsVisible(operations);
            dossierSearchBox.MultiSelect = multiSelect;
        }

        public DossierSearch()
            : this(null, Operations.Search, true)
        {
        }

        private void CheckRibbonButtonsVisible(Operations operations)
        {
            if (operations == Operations.SearchDialog)
            {
                mainRibbon.Tabs.Remove(ribbonTabOperations);
                mainRibbon.Minimized = true;
                btnSelect.Visible = true;
                this.AcceptButton = btnSelect;
                dossierSearchBox.DoubleClickAction = btnSelect_Click;
            }
            else if (operations == Operations.Search)
            {
                mainRibbon.Minimized = false;
                dossierSearchBox.DoubleClickAction = btnView_Click;
            }
            else
            {
                btnView.Visible = ((operations & Operations.ViewDossier) == Operations.ViewDossier);
                btnLend.Visible = ((operations & Operations.LendDossier) == Operations.LendDossier);
                btnPrintList.Visible = ((operations & Operations.PrintList) == Operations.PrintList);
                mainRibbon.Minimized = false;
            }
        }

        public enum Operations
        {
            SearchDialog = 0,
            Search = 1,
            ViewDossier = 2,
            EditDossier = 4,
            LendDossier = 8,
            PrintList = 16,
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private static DossierSearch _Instance;
        public static DossierSearch Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DossierSearch();
                if (_Instance.IsDisposed)
                    _Instance = new DossierSearch();
                return _Instance;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLend_Click(object sender, EventArgs e)
        {
            if (dossierSearchBox.SelectedDossier == null)
                return;
            using (View.LendingManageForms.LendingAddEdit f = new View.LendingManageForms.LendingAddEdit(dossierSearchBox.SelectedDossier))
            {
                f.ShowDialog();
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
        private void btnView_Click(object sender, EventArgs e)
        {
            //if (dossierSearchBox.SelectedDossier == null)
            //    return;

            //Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            //if (currentUser != null)
            //{
            //    if (IsMembershipInAdministartorRole(currentUser))
            //    {
            //        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(dossierSearchBox.SelectedDossier, 0))
            //        {
            //            f.ShowDialog();

            //        }
            //    }
            //    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
            //    {
            //        using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(dossierSearchBox.SelectedDossier, 0))
            //        {
            //            f.ShowDialog();

            //        }
            //    }
            //    else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
            //    {

            //        using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(dossierSearchBox.SelectedDossier, 0))
            //        {
            //            f.ShowDialog(this);
            //        }
            //    }
            //}
        }
        //دکمه های شورت کات ShortCutKeys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                btnView_Click(btnView, EventArgs.Empty);
                return true;
            }
           
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private string[] _SelectedDossiers;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] SelectedDossiers
        {
            get
            {
                if (_SelectedDossiers == null)
                    _SelectedDossiers = new string[0];
                return _SelectedDossiers;
            }
            set
            {
                _SelectedDossiers = value;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!btnSelect.Visible)
                return;
            if (this.AcceptButton == btnSelect && !(this.ActiveControl == btnSelect || btnSelect.Focused) && (!(sender is Telerik.WinControls.UI.GridDataCellElement)))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            this.SelectedDossiers = dossierSearchBox.SelectedDossiers;
            if (this.SelectedDossiers == null)
                return;
            this.Tag = dossierSearchBox.SelectedDossier;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnDocs_Click(object sender, EventArgs e)
        {
            if (dossierSearchBox.SelectedDossier == null)
                return;
            btnView_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (string item in dossierSearchBox.SelectedDossiers)
            {
                using (View.DossierDelete f = new DossierDelete(item))
                {
                    f.ShowDialog();
                }
            }
            dossierSearchBox.Search();
        }

        private void btnPrintDossiersBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Njit.Program.FastReportExtensions.Forms.PrintPreview form = new Njit.Program.FastReportExtensions.Forms.PrintPreview(Setting.Program.ThisProgram.GetReportPath("DossiersBarcode.frx"), Njit.Program.FastReportExtensions.Forms.PrintPreview.PrintSizes.A4, null, 1);
                form.ReportDocument.SetParameterValue("CompanyName", Setting.Archive.ThisProgram.LoadedArchiveSettings.OrganName);
                form.ReportDocument.SetParameterValue("ReportPrintDate", Njit.Common.PersianCalendar.GetDate(DateTime.Now));
                form.ReportDocument.SetParameterValue("ReportPrintTime", Njit.Common.PersianCalendar.GetTime());
                DataTable dt = new DataTable("MyDataSource");
                dt.Columns.Add("Barcode", typeof(string));
                dt.Columns.Add("Title", typeof(string));
                foreach (var item in this.dossierSearchBox.SelectedDossiers)
                {
                    dt.Rows.Add(new object[] { item, item });
                }
                form.ReportDocument.RegisterData(dt, "MyDataSource");
                form.ReportDocument.GetDataSource("MyDataSource").Enabled = true;
                form.ShowDialog(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
