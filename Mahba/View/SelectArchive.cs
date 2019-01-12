using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class SelectArchive : View.BaseForms.AlertBase
    {
        public SelectArchive()
        {
            InitializeComponent();
            SetSize();
            this.Resizable = true;
        }

        private static SelectArchive _Instance;
        public static SelectArchive Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SelectArchive();
                if (_Instance.IsDisposed)
                    _Instance = new SelectArchive();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CheckButtonEnable();
        }

        private void archiveTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (archiveTreeView.SelectedNode == null)
                return;
            LoadArchive();
        }

        private void LoadArchive()
        {
            Model.Common.ArchiveTree groupTree = archiveTreeView.SelectedNode.Tag as Model.Common.ArchiveTree;
            Model.Common.ArchiveTree.NodeTypes nodeType = groupTree.GetNodeType();
            switch (nodeType)
            {
                case Model.Common.ArchiveTree.NodeTypes.Node:
                case Model.Common.ArchiveTree.NodeTypes.ArchiveGroup:
                    return;
                case Model.Common.ArchiveTree.NodeTypes.Archive:
                case Model.Common.ArchiveTree.NodeTypes.Filter:
                case Model.Common.ArchiveTree.NodeTypes.GroupBy:
                    break;
                default:
                    throw new Exception();
            }
            if (!Setting.User.ThisProgram.CheckUserAccessPermission(Setting.User.AccessPermissionUnits.Archive, groupTree.Archive.ID.ToString()))
            {
                PersianMessageBox.Show(this, string.Format("مجوز دسترسی به بایگانی '{0}' برای شما صادر نشده است", groupTree.Archive.Title));
                return;
            }
            this.State = FormWindowState.Minimized;
            Setting.Archive.ThisProgram.SelectedArchiveTree = groupTree;

            //نمایش اینکه سندی دارد که بهش اعلام خرابی کرده باشند در این بایگانی
            int Count = checkDocumentFailure(groupTree.ArchiveID);
            if (Count != 0)
            {
                var dialogResult = PersianMessageBox.Show(this, "تعداد اسناد خراب گزارش شده برابر است با: " + Count + "مایل به مشاهده گزارش لیست اسناد خراب هستید؟", "تایید ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    View.DocumentFailure df = new DocumentFailure();
                    df.Show(this);
                }
            }
            //نمایش پروندهایی که به امانت رفته اما پس داده نشده است
            string _DossiersNumber = CheckLending();
            if (_DossiersNumber != "") {
                var dialogResult = PersianMessageBox.Show(this, "پرونده های شماره: " + _DossiersNumber + "زمان اتمام امانتشان به اتمام رسیده است  مایل به مشاهده لیست پرونده های امانت گرفته شده هستید؟", "تایید ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    View.LendingManageForms.LendingList df = new LendingManageForms.LendingList();
                    df.Show(this);
                }
            }
            //آیا اضافه کردن اطلاعات دانشجو را داشته باشد یا خیر ؟
        }

        private string CheckLending()
        {
            if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>())) { }
            //اگر سطح دسترسی نداشته باشد صفر رد می شود
            else if (!Setting.User.ThisProgram.CheckUserAccessPermission(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>(), "LendingList", null))
                return "";

            DataTable db = SqlHelper.LendingListNotBacked("Lending", "ReturnTime");
            string DossierNumber="";
            DateTime Today ;
            try { Today=ConvertTo_PersianOREnglish_Date.GetEglishDate(DataAccess.CommonDataAccess.GetNewInstance().Connection.GetServerPersianDate());}
            catch { return ""; }
            if (db != null)
                for (int i = 0; i < db.Rows.Count; i++)
                {
                    try { 
                    DateTime _DateLenidng=ConvertTo_PersianOREnglish_Date.GetEglishDate(db.Rows[i].ItemArray[4].ToString());
                    int DayLending=Convert.ToInt32( db.Rows[i].ItemArray[6].ToString());
                        if(_DateLenidng.AddDays(DayLending)<=Today){
                            int PersonID =Convert.ToInt32(db.Rows[i].ItemArray[2].ToString());
                            //زمانی که گیرنده است نمایش بدهد
                            if (Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().FullName == Controller.Archive.PersonController.GetPersonByID(PersonID).Name)
                                DossierNumber += db.Rows[i].ItemArray[1].ToString() + ",";
                                //زمانی که فرستنده هم خودش باشد نمایش بده
                            else if (Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code.ToString() == db.Rows[i].ItemArray[12].ToString())
                            { 
                                DossierNumber += db.Rows[i].ItemArray[1].ToString() + ","; }
                        }
                    }
                    catch {
                        continue;
                    }
                }
            return DossierNumber;
        }
        #region Document Failare
        private int checkDocumentFailure(int? ArchiveId)
        {
            if (ArchiveId == null) return 0;
            //اگر ادمین باشد نیازی نیست
            else if (Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                return (dc.DocumentsFailures.Count(q => q.isRead == false && q.ArchiveID == ArchiveId));
            }
            //اگر سطح دسترسی نداشته باشد صفر رد می شود
            else if (!Setting.User.ThisProgram.CheckUserAccessPermission(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>(), "DocumentFailure", null))
                return 0;
            else
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                return SetAccessPermission(dc.DocumentsFailures.Where(q => q.isRead == false && q.ArchiveID == ArchiveId).ToList());
            }
        }
        class DocumnetSecurity
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        private int SetAccessPermission(List<Model.Common.DocumentsFailure> documents)
        {

            //لیست نوع دسترسی
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
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
            return documents.Count;
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
        #endregion

        private void archiveTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckButtonEnable();
        }

        private void CheckButtonEnable()
        {
            if (archiveTreeView.SelectedNode == null)
            {
                btnSelect.Enabled = false;
                return;
            }
            btnSelect.Enabled = (archiveTreeView.SelectedNode.Tag as Model.Common.ArchiveTree).Archive != null;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadArchive();
        }
    }
}
