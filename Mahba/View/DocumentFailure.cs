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
    public partial class DocumentFailure : Njit.Program.Forms.OKCancelForm
    {
        public DocumentFailure()
        {
            InitializeComponent();
            ShowDataBinding();
        }

        private void cbNotSee_CheckedChanged(object sender, EventArgs e)
        {
            ShowDataBinding();
        }

        private void cbSee_CheckedChanged(object sender, EventArgs e)
        {
            ShowDataBinding();
        }
        void radGridViewExtended1_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
            for (int i = 0; i < e.ContextMenu.Items.Count; i++)
            {

                // hide the Conditional Formatting option from the header row context menu
                e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                //// hide the separator below the CF option
                //e.ContextMenu.Items[i + 1].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

            }
        }

        private void ShowDataBinding()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Common.DocumentsFailure> listdf = new List<Model.Common.DocumentsFailure>();
            if (cbNotSee.Checked)
                listdf.AddRange(NotSee(dc));
            if (cbSee.Checked)
                listdf.AddRange(See(dc));
            if (listdf.Any())
            {
                SetAccessPermission(listdf, dc);
                List<ReportFail> ListRf = new List<ReportFail>();

                int index = 0;
                foreach (var item in listdf)
                {
                    ReportFail rf = new ReportFail();
                    rf.Radif = ++index;
                    rf.ID = item.ID;
                    Model.Common.User MemberSender = dc.Users.Where(q => q.Code == item.UserSender).FirstOrDefault();
                    Model.Common.User MemberResiver = dc.Users.Where(q => q.Code == item.Userchecker).FirstOrDefault();
                    rf.NameSeneder = MemberSender.FullName;
                    rf.NameResiver = MemberResiver != null ? MemberResiver.FullName : "اقدام نشده";
                    rf.SenderDate = ConvertTo_PersianOREnglish_Date.GetPersianDate(item.DateSender) + "ساعت:" + item.DateSender.ToString().Substring(10);
                    rf.ResiverDate = item.DateChecker != null ? ConvertTo_PersianOREnglish_Date.GetPersianDate(Convert.ToDateTime(item.DateChecker)) + "ساعت:" + item.DateChecker.ToString().Substring(10) : "#";
                    rf.State = item.isRead == true ? "مشاهده شده" : "مشاهده نشده";
                    rf.Title = getTitle(item.Title);
                    rf.Des = item.Description;
                    rf.DossierNumber = item.PerssonelNumber;
                    rf.DocumentNumber = item.DocumnetNumber;
                    ListRf.Add(rf);
                }
                radGridViewExtended1.DataSource = ListRf;
            }
            else
            {
                radGridViewExtended1.DataSource = null;
            }
        }

        private string getTitle(int p)
        {
            switch (p)
            {
                case 0:
                    return "شماره نامه";
                case 1:
                    return "تاریخ نامه";
                case 2:
                    return "مخاطب نامه";
                case 3:
                    return "عنوان نامه";
                case 4:
                    return "اقدام کننده";
                case 5:
                    return "متفرقه";
                default :
                    return "#";

            }
        }

        private List<Model.Common.DocumentsFailure> See(Model.Common.ArchiveCommonDataClassesDataContext dc)
        {
            return (dc.DocumentsFailures.Where(q => q.ArchiveID == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID && q.isRead == true).ToList());
        }

        private List<Model.Common.DocumentsFailure> NotSee(Model.Common.ArchiveCommonDataClassesDataContext dc)
        {
            return (dc.DocumentsFailures.Where(q => q.ArchiveID == Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID && q.isRead == false).ToList());
        }
        class DocumnetSecurity
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        class ReportFail
        {
            [DisplayName("ردیف ")]
            public int Radif { get; set; }
            [DisplayName("شماره ")]
            public int ID { get; set; }
            [DisplayName("شماره پرونده")]
            public string DossierNumber { get; set; }
            [DisplayName("شماره سند")]
            public string DocumentNumber { get; set; }
            [DisplayName("ارسال کننده ")]
            public string NameSeneder { get; set; }
            [DisplayName("تاریخ ارسال")]
            public string SenderDate { get; set; }
            [DisplayName("عنوان")]
            public string Title { get; set; }
            [DisplayName("توضیحات")]
            public string Des { get; set; }
            [DisplayName("اقدام کننده")]
            public string NameResiver { get; set; }
            [DisplayName("تاریخ اقدام")]
            public string ResiverDate { get; set; }
            [DisplayName("وضعیت")]
            public string State { get; set; }
        }

        private List<Model.Common.DocumentsFailure> SetAccessPermission(List<Model.Common.DocumentsFailure> documents, Model.Common.ArchiveCommonDataClassesDataContext dc)
        {
            //اگر ادمین باشد نیازی نیست
            if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
                return documents;
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
                System.Data.DataTable tempDataTable = SqlHelper.GetDocumentsForFailures("Document2", item.documentID);
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
            string PessonelNumber = "";
            int ID = 0;
            foreach (Telerik.WinControls.UI.GridViewRowInfo item in radGridViewExtended1.SelectedRows)
            {
                PessonelNumber = item.Cells[1].Value.ToString();
                try
                {
                    ID = Convert.ToInt32(item.Cells[0].Value.ToString());
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            if (PessonelNumber != "")
            {
                var dialogResult = PersianMessageBox.Show(this, "مایل به مشاهده پرونده : " + PessonelNumber + " هستید؟", "تایید ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    var df = dc.DocumentsFailures.Where(q => q.ID == ID).FirstOrDefault();
                    if (df != null)
                    {
                        df.isRead = true;
                        df.DateChecker = System.DateTime.Now;
                        df.Userchecker = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;
                        dc.SubmitChanges();
                    }
                    else { return; }
                    Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                    if (currentUser != null)
                    {
                        if (IsMembershipInAdministartorRole(currentUser))
                        {
                            using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(PessonelNumber,0))
                            {
                                f.ShowDialog();

                            }
                        }
                        else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                        {
                            using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(PessonelNumber,0))
                            {
                                f.ShowDialog();

                            }
                        }
                        else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                        {

                            using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(PessonelNumber,0))
                            {
                                f.ShowDialog();

                            }
                        }
                    }
                }

            }
        }


    }
}
