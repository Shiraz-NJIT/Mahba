using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.UserManageForms
{
    public partial class DossierAndDocumentLog : Form
    {
        public DossierAndDocumentLog()
        {
            InitializeComponent();
            Setting.Program.ThisProgram.LoadFormState(this);
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        Dictionary<int, string> ListArchive;
        private void DossierAndDocumentLog_Load(object sender, EventArgs e)
        {
            LoadArchives();
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Common.User> query = dc.Users.ToList().Where(q => q.Visible == Setting.User.ThisProgram.GetUserVisible(q.Code, true)).ToList();
            if (query.Any())
            {
                comboBoxUsers.DataSource = query;
                comboBoxUsers.DisplayMember = "FullName";
                comboBoxUsers.ValueMember = "Code";
            }
            dateFromTextBox.SetDate(DateTime.Now);
            dateFromTextBox.Month = dateFromTextBox.Month - 1;
            dateFromTextBox.Day = 1;
            dateToTextBox.SetDate(DateTime.Now);
            //this.RefreshData();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            radGridView.BestFitColumnsSmart();

        }

        private void LoadArchives()
        {
            ListArchive = new Dictionary<int, string>();
            foreach (var item in Controller.Common.ArchiveController.GetActiveArchives())
            {
                ListArchive.Add(item.ID, item.Title);
            }
        }
        private void RefreshDataForEditDoc()
        {
            //زمانی که کاربر مشخص نشده باشد 
            if (comboBoxUsers.SelectedValue == null)
            {
                this.radGridView.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            if (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text) == Njit.Program.Controls.DateControl.CheckDateResult.Error)
            {
                this.radGridView.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            IQueryable<Model.Common.UserLog> data;
            if (((int)comboBoxUsers.SelectedValue == -1))
                data = dc.UserLogs.Select(t => t);
            else
            {
                var des = Setting.User.ThisProgram.GetUserLogCryptoService((int)comboBoxUsers.SelectedValue);
                data = dc.UserLogs.Where(t => t.UserCode == (int)comboBoxUsers.SelectedValue && t.OperationPlaceCode == des.EncryptToBase64(((short)Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده).ToString())).Select(t => t).OrderByDescending(q => q.ID);
            }

            List<Report> userLogs = new List<Report>();
            List<Report> userLogs2 = new List<Report>();
            Dictionary<int, string> dicPersonnel = new Dictionary<int, string>();
            int i = 0;
            foreach (var item in data)
            {
                try
                {
                    NjitSoftware.UserLogView log = Setting.User.ThisProgram.GetUserLogView(item);
                    if (GetOperation(log.Operation).Contains("ویرایش اطلاعات سند"))
                    {
                        i++;
                        Report r = new Report();
                        r.ID = i;
                        r.Date1 = log.Date;
                        r.Description1 = log.Description;
                        r.FullName = log.UserFullName;
                        r.Operation1 = GetOperation(log.Operation);
                        r.Time1 = log.Time;
                        r.IP = log.IPAddress;
                        //if (log.Unit != null)
                        //{
                        //    userlog.Unit = GetUnit(userlog.Unit);

                        //

                        r.ArchiveName = ListArchive.FirstOrDefault(q => q.Key.ToString() == log.ArchiveID).Value;
                        r.PerssonelNumber = log.OperationCode;
                        dicPersonnel.Add(i, r.PerssonelNumber);
                        userLogs.Add(r);
                    }
                }

                catch (System.Security.Cryptography.CryptographicException)
                {
                    PersianMessageBox.Show(this, "داده نامعتبر پیدا شد");
                }
            }
            foreach (var item in userLogs)
            {
                if (userLogs2.Any())
                {
                    if (!userLogs2.Exists(q => q.PerssonelNumber == item.PerssonelNumber))
                    {
                        Report r = new Report();
                        r = item;
                        r.Description1 = "به تعداد:" + dicPersonnel.Count(q => q.Value == item.PerssonelNumber);
                        userLogs2.Add(r);
                    }
                }
                else
                {
                    Report r = new Report();
                    r = item;
                    r.Description1 = "به تعداد:" + dicPersonnel.Count(q => q.Value == item.PerssonelNumber);
                    userLogs2.Add(r);
                }
            }

            switch (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text))
            {
                case Njit.Program.Controls.DateControl.CheckDateResult.Both:
                    this.radGridView.DataSource = userLogs2.Where(t => t.Date1.CompareTo(dateFromTextBox.Text) >= 0 && t.Date1.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date1:
                    this.radGridView.DataSource = userLogs2.Where(t => t.Date1.CompareTo(dateFromTextBox.Text) >= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date2:
                    this.radGridView.DataSource = userLogs2.Where(t => t.Date1.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Error:
                    return;
                case Njit.Program.Controls.DateControl.CheckDateResult.Free:
                    this.radGridView.DataSource = userLogs2;
                    break;
            }
            //radGridView.BestFitColumnsSmart();
        }
        private void RefreshDataForAddDoc()
        {
            //زمانی که کاربر مشخص نشده باشد 
            if (comboBoxUsers.SelectedValue == null)
            {
                this.radGridView.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            if (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text) == Njit.Program.Controls.DateControl.CheckDateResult.Error)
            {
                this.radGridView.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            IQueryable<Model.Common.UserLog> data;
            if (((int)comboBoxUsers.SelectedValue == -1))
                data = dc.UserLogs.Select(t => t);
            else
            {
                var des = Setting.User.ThisProgram.GetUserLogCryptoService((int)comboBoxUsers.SelectedValue);
                data = dc.UserLogs.Where(t => t.UserCode == (int)comboBoxUsers.SelectedValue && t.OperationPlaceCode == des.EncryptToBase64(((short)Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده).ToString())).Select(t => t).OrderByDescending(q => q.ID);
            }

            List<Report> userLogs = new List<Report>();
            List<Report> userLogs2 = new List<Report>();
            Dictionary<int, string> dicPersonnel = new Dictionary<int, string>();
            int i = 0;
            foreach (var item in data)
            {
                try
                {
                    NjitSoftware.UserLogView log = Setting.User.ThisProgram.GetUserLogView(item);
                    if (GetOperation(log.Operation).Contains("اضافه کردن سند به پرونده"))
                    {
                        i++;
                        Report r = new Report();
                        r.ID = i;
                        r.Date1 = log.Date;
                        r.Description1 = log.Description;
                        r.FullName = log.UserFullName;
                        r.Operation1 = GetOperation(log.Operation);
                        r.Time1 = log.Time;
                        r.IP = log.IPAddress;
                        //if (log.Unit != null)
                        //{
                        //    userlog.Unit = GetUnit(userlog.Unit);

                        //

                        r.ArchiveName = ListArchive.FirstOrDefault(q => q.Key.ToString() == log.ArchiveID).Value;
                        r.PerssonelNumber = log.OperationCode;
                        dicPersonnel.Add(i, r.PerssonelNumber);
                        userLogs.Add(r);
                    }
                }

                catch (System.Security.Cryptography.CryptographicException)
                {
                    PersianMessageBox.Show(this, "داده نامعتبر پیدا شد");
                }
            }
            foreach (var item in userLogs)
            {
                if (userLogs2.Any())
                {
                    if (!userLogs2.Exists(q => q.PerssonelNumber == item.PerssonelNumber))
                    {
                        Report r = new Report();
                        r = item;
                        r.Description1 = "به تعداد:" + dicPersonnel.Count(q => q.Value == item.PerssonelNumber);
                        userLogs2.Add(r);
                    }
                }
                else
                {
                    Report r = new Report();
                    r = item;
                    r.Description1 = "به تعداد:" + dicPersonnel.Count(q => q.Value == item.PerssonelNumber);
                    userLogs2.Add(r);
                }
            }

            switch (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text))
            {
                case Njit.Program.Controls.DateControl.CheckDateResult.Both:
                    this.radGridView.DataSource = userLogs2.Where(t => t.Date1.CompareTo(dateFromTextBox.Text) >= 0 && t.Date1.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date1:
                    this.radGridView.DataSource = userLogs2.Where(t => t.Date1.CompareTo(dateFromTextBox.Text) >= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date2:
                    this.radGridView.DataSource = userLogs2.Where(t => t.Date1.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Error:
                    return;
                case Njit.Program.Controls.DateControl.CheckDateResult.Free:
                    this.radGridView.DataSource = userLogs2;
                    break;
            }
            //radGridView.BestFitColumnsSmart();
        }
        private void RefreshData()
        {
            //زمانی که کاربر مشخص نشده باشد 
            if (comboBoxUsers.SelectedValue == null)
            {
                this.radGridView.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            if (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text) == Njit.Program.Controls.DateControl.CheckDateResult.Error)
            {
                this.radGridView.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            IQueryable<Model.Common.UserLog> data;
            if (((int)comboBoxUsers.SelectedValue == -1))
                data = dc.UserLogs.Select(t => t);
            else
            {
                var des = Setting.User.ThisProgram.GetUserLogCryptoService((int)comboBoxUsers.SelectedValue);
                data = dc.UserLogs.Where(t => t.UserCode == (int)comboBoxUsers.SelectedValue && t.OperationPlaceCode == des.EncryptToBase64(((short)Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده).ToString())).Select(t => t).OrderByDescending(q => q.ID);
            }

            List<Report> userLogs = new List<Report>();
            int i = 0;

            foreach (var item in data)
            {
                i++;
                try
                {
                    NjitSoftware.UserLogView log = Setting.User.ThisProgram.GetUserLogView(item);
                    Report r = new Report();
                    r.ID = i;
                    r.Date1 = log.Date;
                    r.Description1 = log.Description;
                    r.FullName = log.UserFullName;
                    r.Operation1 = GetOperation(log.Operation);
                    r.Time1 = log.Time;
                    r.IP = log.IPAddress;
                    //if (log.Unit != null)
                    //{
                    //    userlog.Unit = GetUnit(userlog.Unit);

                    //

                    r.ArchiveName = ListArchive.FirstOrDefault(q => q.Key.ToString() == log.ArchiveID).Value;
                    r.PerssonelNumber = log.OperationCode;
                    userLogs.Add(r);
                }
                catch (System.Security.Cryptography.CryptographicException)
                {
                    PersianMessageBox.Show(this, "داده نامعتبر پیدا شد");
                }
            }

            switch (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text))
            {
                case Njit.Program.Controls.DateControl.CheckDateResult.Both:
                    this.radGridView.DataSource = userLogs.Where(t => t.Date1.CompareTo(dateFromTextBox.Text) >= 0 && t.Date1.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date1:
                    this.radGridView.DataSource = userLogs.Where(t => t.Date1.CompareTo(dateFromTextBox.Text) >= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date2:
                    this.radGridView.DataSource = userLogs.Where(t => t.Date1.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Error:
                    return;
                case Njit.Program.Controls.DateControl.CheckDateResult.Free:
                    this.radGridView.DataSource = userLogs;
                    break;
            }
            //radGridView.BestFitColumnsSmart();
        }
        public string GetUnit(string code)
        {
            try
            {
                return Enum.GetName(typeof(Setting.User.UserOparatesPlaceNames), short.Parse(code)).Replace("_", " ");
            }
            catch { return ""; }
        }

        public string GetOperation(string code)
        {
            try
            {
            return Enum.GetName(typeof(Setting.User.UserOparatesNames), short.Parse(code)).Replace("_", " ");
               }
            catch { return ""; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataForAddDoc();
        }

        private void dateFromTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateToTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        class Report
        {
            [DisplayName("شماره ")]
            public int ID { get; set; }
            [DisplayName("کاربر")]
            public string FullName { get; set; }
            [DisplayName("اسم بایگانی")]
            public string ArchiveName { get; set; }
            [DisplayName("عملکرد")]
            public string Operation1 { get; set; }

            [DisplayName("شماره پرونده")]
            public string PerssonelNumber { get; set; }

            [DisplayName("توضیحات")]
            public string Description1 { get; set; }
            [DisplayName("تاریخ")]
            public string Date1 { get; set; }
            [DisplayName("ساعت")]
            public string Time1 { get; set; }
            [DisplayName("IPAddress")]
            public string IP { get; set; }

        }
        //مخفی کردن شروط جدول
        private void radGridView_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
            for (int i = 0; i < e.ContextMenu.Items.Count; i++)
            {

                // hide the Conditional Formatting option from the header row context menu
                e.ContextMenu.Items[i].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                //// hide the separator below the CF option
                //e.ContextMenu.Items[i + 1].Visibility = Telerik.WinControls.ElementVisibility.Collapsed;

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

        private void radGridView_DoubleClick(object sender, EventArgs e)
        {
            string PessonelNumber = "";
            foreach (Telerik.WinControls.UI.GridViewRowInfo item in radGridView.SelectedRows)
            {
                PessonelNumber = item.Cells[4].Value.ToString();
            }
            if (PessonelNumber != "")
            {
                var dialogResult = PersianMessageBox.Show(this, "مایل به مشاهده پرونده : " + PessonelNumber + " هستید؟", "تایید ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
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

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshDataForEditDoc();
        }

      

        private void radGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string PessonelNumber = "";
                foreach (Telerik.WinControls.UI.GridViewRowInfo item in radGridView.SelectedRows)
                {
                    PessonelNumber = item.Cells[4].Value.ToString();
                }
                if (PessonelNumber != "")
                {
                    var dialogResult = PersianMessageBox.Show(this, "مایل به مشاهده پرونده : " + PessonelNumber + " هستید؟", "تایید ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
                        if (currentUser != null)
                        {
                            if (IsMembershipInAdministartorRole(currentUser))
                            {
                                using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(PessonelNumber, 0))
                                {
                                    f.ShowDialog();

                                }
                            }
                            else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiverDocumentManagement", null))
                            {
                                using (View.ArchiverDocumentManagement f = new ArchiverDocumentManagement(PessonelNumber, 0))
                                {
                                    f.ShowDialog();

                                }
                            }
                            else if (Setting.User.ThisProgram.CheckUserAccessPermission(currentUser, "ArchiveDocumentShow", null))
                            {

                                using (View.ArchiveDocumentShow f = new ArchiveDocumentShow(PessonelNumber, 0))
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
}
