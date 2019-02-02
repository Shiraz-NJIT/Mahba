using NjitSoftware.Controller.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace NjitSoftware.View
{
    public delegate void SendMsg(string Title, string Message, string DateSent);

    public partial class Main : Njit.Program.ComponentOne.Forms.MainForm
    {
        public SendMsg SendMessage;

        public Main()
        {
            InitializeComponent();
            Setting.User.ThisProgram.CurrentUserChanged += ThisProgram_CurrentUserChanged;
            Setting.Archive.ThisProgram.SelectedArchiveChanged += ThisProgram_SelectedArchiveChanged;
            ProgramEvents.ProgramSettingsChanged += ProgramEvents_ProgramSettingsChanged;
            NetworkStatus.AvailabilityChanged += NetworkStatus_AvailabilityChanged;
            mainRibbon.Tabs.Remove(ribbonTabExit);
            mainRibbon.Tabs.Add(ribbonTabExit);
            mainRibbon.SelectedTab = this.ribbonTabPageDossier;

            LoadSettings();
        }

        void NetworkStatus_AvailabilityChanged(object sender, NetworkStatusChangedArgs e)
        {
            if (NetworkStatus.IsAvailable)
            {
                MessageBox.Show("ارتباط با سرور برقرار شد");
            }
            else
            {
                PersianMessageBox.Show(string.Format("  ارتباط با سرور برقرار نیست لطفا بعد از کلیک بروی دکمه {0} تا زمانی که سیستم پیام برقرای ارتباط با سرور را نداده است منتظر بمانید.", "تایید"));
            }
        }

        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (!e.IsAvailable) { MessageBox.Show("ارتباط شما با سرور قطع شد"); }
        }

        private void ProgramEvents_ProgramSettingsChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Setting.Program.ThisProgram.BackgroundImage;
            SetToolstripValues();
        }

        private void ThisProgram_SelectedArchiveChanged(object sender, EventArgs e)
        {
            this.BackgroundImage = Setting.Program.ThisProgram.BackgroundImage;
        }

        protected override void LoadSettings()
        {
            System.Drawing.Size size = Properties.Settings.Default.MainFormSize;
            switch (Properties.Settings.Default.MainFormWindowState)
            {
                case (int)System.Windows.Forms.FormWindowState.Normal:
                    if (!(size.Width == 0 && size.Height == 0))
                    {
                        this.Width = size.Width;
                        this.Height = size.Height;
                    }
                    break;
                case (int)System.Windows.Forms.FormWindowState.Maximized:
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case (int)System.Windows.Forms.FormWindowState.Minimized:
                    break;
            }
        }

        protected override void SaveSettings()
        {
            Properties.Settings.Default.MainFormSize = this.Size;
            Properties.Settings.Default.MainFormWindowState = (int)this.WindowState;
            Properties.Settings.Default.Save();
        }

        protected override void InitilizeProgramSettings()
        {
            Njit.Program.Options.Initialize(SettingInitializer.Instance);
        }

        public override void UpdateDatabases()
        {
            //----------------------
            string mainUpdatesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DatabaseUpdates\\MainDatabase");
            if (!System.IO.Directory.Exists(mainUpdatesPath))
            {
                try
                { System.IO.Directory.CreateDirectory(mainUpdatesPath); }
                catch (Exception)
                { return; }
            }
            using (Njit.Program.Forms.DatabseUpdatesInstaller form = new Njit.Program.Forms.DatabseUpdatesInstaller(DataAccess.CommonDataAccess.GetNewInstance().Connection.ConnectionString, mainUpdatesPath))
                form.ShowDialog(this);
            //----------------------
            Model.Common.Archive[] archives = Controller.Common.ArchiveController.GetActiveArchives();
            string archiveUpdatesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DatabaseUpdates\\ArchiveDatabase");
            if (!System.IO.Directory.Exists(archiveUpdatesPath))
            {
                try
                { System.IO.Directory.CreateDirectory(archiveUpdatesPath); }
                catch (Exception)
                { return; }
            }
            foreach (var item in archives)
            {
                using (Njit.Program.Forms.DatabseUpdatesInstaller form = new Njit.Program.Forms.DatabseUpdatesInstaller(Setting.Sql.ThisProgram.GetDatabaseConnection(item.Name).ConnectionString, archiveUpdatesPath))
                    form.ShowDialog(this);
                //----------------------
                string archiveDocumentDB = Controller.Common.ArchiveController.GetArchiveDocumentsDatabaseName(item.Name);
                if (archiveDocumentDB != null)
                {
                    string archiveDocumentsUpdatesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DatabaseUpdates\\ArchiveDocumentDatabase");
                    if (!System.IO.Directory.Exists(archiveDocumentsUpdatesPath))
                    {
                        try
                        { System.IO.Directory.CreateDirectory(archiveDocumentsUpdatesPath); }
                        catch (Exception)
                        { return; }
                    }
                    using (Njit.Program.Forms.DatabseUpdatesInstaller form = new Njit.Program.Forms.DatabseUpdatesInstaller(Setting.Sql.ThisProgram.GetDatabaseConnection(archiveDocumentDB).ConnectionString, archiveDocumentsUpdatesPath))
                        form.ShowDialog(this);
                }
                //----------------------
            }
        }

        private void ThisProgram_CurrentUserChanged(object sender, Njit.Program.Setting.UserSetting.CurrentUserChangedEventArgs<object> e)
        {
            Model.Common.User membership = e.Membership as Model.Common.User;
            if (membership == null)
                lblUser.Text = "".PadRight(25);
            else
            {
                lblUser.Text = membership.FullName.PadRight(25);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                btnNewDossier_Click(btnNewDossier, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F3))
            {
                btnShowDossier_Click(this.btnShowDossier, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F4))
            {
                btnLendingAdd_Click(this.btnLendingAdd, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F5))
            {
                btnProgramSetting_Click(this.btnProgramSetting, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F6))
            {
                btnSetUserPermission_Click(this.btnSetUserPermission, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F7))
            {
                btnSetDossierPermission_Click(this.btnSetDossierPermission, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F8))
            {
                btnSetPermissionSecurity_Click(this.btnSetPermissionSecurity, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F9))
            {
                btnUsersAdd_Click(this.btnUsersAdd, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F10))
            {
                btnReports_Click(this.btnReports, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F11))
            {
                btnBackup_Click(this.btnBackup, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F12))
            {
                ScanerelegantButton_Click(this.ScanerelegantButton, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Control | Keys.D))
            {
                if (Setting.Archive.ThisProgram.SelectedArchiveTree != null)
                {
                    btnNewDossier_Click(btnNewDossier, EventArgs.Empty);
                    return true;
                }
                else
                {
                    PersianMessageBox.Show("بایگانی را انتخاب کنید");
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private static Main _Instance;
        public static Main Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Main();
                if (_Instance.IsDisposed)
                    _Instance = new Main();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Setting.Archive.ThisProgram.SelectedArchiveTree = null;
            base.OnLoad(e);
        }
        List<MessageViwModel> ListMessages;
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>() == null)
            {
                Setting.Program.ThisProgram.ShowExitDialog = false;
                this.Close();
                return;
            }
            ShowUpdateApp();
            ListMessages = MessageUserController.ListMessage(null, null);
            timerShowNonificationMessages.Enabled = true;
            //if (Setting.Program.ThisProgram.GetLastRunDate().CompareTo(DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString())) > 0)
            //{
            //    PersianMessageBox.Show(this, "تاریخ سیستم از تاریخ آخرین اجرای نرم افزار کوچکتر است و اینگونه به نظر میرسد که تاریخ سیستم نادرست است\r\nلطفا تاریخ سیستم خود را تنظیم کنید");
            //    Setting.Program.ThisProgram.ShowExitDialog = false;
            //    this.Close();
            //    return;
            //}

            //StartCheckLock();


            //View.ArchivesDiskSpaceManage f = new ArchivesDiskSpaceManage();
            //f.Show(this);
            //نمایش اینکه سندی دارد که بهش اعلام خرابی کرده باشند

        }

        private void ShowUpdateApp()
        {
            //اگر ورژن جدید در دیتابیس بود بررسی میکند که اگر برنامه جدید در کلاینت کاربر نصب نبود برنامه را میبندن و برنامه جدید را باز میکند
            if (NjitSoftware.Controller.Common.VerionAppController.Version() != Lbl_Version.Text)
            {
                var Result = PersianMessageBox.Show("ورژن جدید برنامه آماده دانلود است آیا مایل به آپدیت برنامه هستین؟", "پیام", MessageBoxButtons.YesNoCancel);
                if (Result == DialogResult.Yes)
                {
                    try
                    {
                        Model.Common.VersionClient vc = new Model.Common.VersionClient();
                        int userCode = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;
                        vc.userId = userCode;
                        vc.MashinPath = AppDomain.CurrentDomain.BaseDirectory;

                        NjitSoftware.Controller.Common.VersionClientController.Insert(vc);
                        //اجرا شدن برنامه برای بروزرسانی نرم افزار
                        string AppUpdatePathExe = AppDomain.CurrentDomain.BaseDirectory;
                        System.Diagnostics.Process.Start(AppUpdatePathExe + "Update\\MahbaUpdateApp.exe");//@"D:\WorkUpDareApp\MahbaUpdateApp.exe"
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

            }

        }
        public override void CloseUser()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            Model.Common.User membership = dc.Users.Where(t => t.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code).Single();
            membership.isLogin = false;
            membership.IPAddress = Setting.Program.GetMacAddress().ToString();
            dc.SubmitChanges();

        }

        //internal void StartCheckLock()
        //{
        //    System.ComponentModel.BackgroundWorker backgroundWorker = new BackgroundWorker();
        //    backgroundWorker.DoWork += backgroundWorker_DoWork;
        //    backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        //    backgroundWorker.RunWorkerAsync();
        //}

        //private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    CheckLock();
        //}

        //private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Error != null)
        //    {
        //        if (e.Error is Njit.Common.CheckLockException)
        //        {
        //            PersianMessageBox.Show(this, "خطا" + "\r\n" + e.Error.Message);
        //            Setting.Program.ThisProgram.ShowExitDialog = false;
        //            this.Close();
        //            return;
        //        }
        //        else
        //        {
        //            PersianMessageBox.Show(this, "خطا در بررسی قفل سخت افزاری");
        //            Setting.Program.ThisProgram.ShowExitDialog = false;
        //            this.Close();
        //            return;
        //        }
        //    }
        //    else if (e.Cancelled)
        //    {
        //        PersianMessageBox.Show(this, "خطا در بررسی قفل سخت افزاری");
        //        Setting.Program.ThisProgram.ShowExitDialog = false;
        //        this.Close();
        //        return;
        //    }
        //}

        //private void CheckLock()
        //{
        //    string fileName = "Tiny.ocx";
        //    if (!System.IO.File.Exists(fileName))
        //        fileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Tiny.ocx");
        //    if (!System.IO.File.Exists(fileName))
        //        throw new Njit.Common.CheckLockException(-1000);
        //    Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
        //    //if (md5.GetFileMD5(fileName) != "TJKM9pyOg+//raCCvG2UNw==")
        //    //    throw new Njit.Common.CheckLockException(-1001);
        //    TINYLib.TinyPlusCtrl tiny = new TINYLib.TinyPlusCtrl();
        //    short errorCode = 0;
        //    if (Njit.Common.PublicMethods.ServerIsLocal(Setting.Sql.ThisProgram.LockServer))
        //    {
        //        errorCode = tiny.FindFirstTPlus("6D2F77838D67E3BCC7C3261C737B9FF", "0F53C9F493D977FBA6453434FE9DB895D75F7A0FC33BF180AFEE569CBB4AAFD75D780B92CA40537EF068AEB15CBBE3697827", "AF4F19087B09B94B648D9E3EC0EB223C8C1A13308DCD8F68597F1F5D4C43737BC93417783EBEE91E9569EBD841258B17CCB1");
        //    }
        //    else
        //    {
        //        errorCode = tiny.FindNetTPlus(Setting.Sql.ThisProgram.LockServer, "6D2F77838D67E3BCC7C3261C737B9FF");
        //    }
        //    if (errorCode != 0)
        //        throw new Njit.Common.CheckLockException(errorCode);
        //    string[] request = new string[20] { "E81E98ABBAA0A842610C", "1666C4E3F2EE469CAF4A", "5F370D283B9547B75265", "1747C5D4F3054B33DEE1", "EF479DAC4BCB41F98A9D", "CD43FB8AA998E8627510", "9B13BD58075AD20837D2", "59A91718C7BAE2687B26", "B2CE60730296C6445772", "F767A5B453CF33E18CAB", "4C446E0D1CEA46984756", "E74F95B05FE53595A443", "2252D0FF9A3961E9F8A7", "1B4FCBDAF92C50DAF988", "D43E84A34E9D57BF5A79", "BFE76D7C0F8C50BA596A", "DD578BB655423A70032E", "3048D2F19C786C36D5E4", "7AE2283BE648F8060934", "204CC2E1F0F377A14C5F" };
        //    string[] response = new string[20] { "72E8724B644747352003", "954DF7E2D97F2F5D5843", "AE1E103B3230065E0940", "C2FA849BBEB5FBFB98B9", "5ECE80B7E2D95BDB3247", "199717F0D54F871514F7", "7202A0CB2624B4E2DFCC", "FC74BED39E4484021BD8", "5C883A33EC15ED776E59", "A21A647B1E99C57F7455", "6B6B59C4BB7420722F48", "920254772A94EC546B0E", "EC048AA7548B3BCBE40D", "67A32740258460DEC740", "D77537227D70BE9EC9F4", "8E6EF0E71E2460FE675E", "29ABE7DCC10CDC2AE300", "B727A590731125E78EC5", "0484C2DB980199D7DAF5", "C72BB5A0977D093F3449" };
        //    Random r = new Random((int)DateTime.Now.Ticks);
        //    int i = r.Next(20);
        //    if (tiny.GetTPlusQuery(request[i]) != response[i])
        //        throw new Njit.Common.CheckLockException(-1);
        //    string spid = tiny.GetTPlusData(TINYLib.EnumTPlusData.TPLUS_SPECIALID);
        //    if (spid != "SAM@MOJ!15153030")
        //        throw new Njit.Common.CheckLockException(-1003);
        //    string data = tiny.GetTPlusData(TINYLib.EnumTPlusData.TPLUS_DATAPARTITION);
        //    string exDate = Njit.Common.PublicMethods.GetStringData(data, "exd:", ';');
        //    if (!string.IsNullOrEmpty(exDate))
        //    {
        //        TimeSpan timeSpan = Njit.Common.PersianCalendar.ToDateTime(exDate).Subtract(DateTime.Now);
        //        if (timeSpan.TotalDays <= 0)
        //            throw new Njit.Common.CheckLockException(-1002);
        //    }
        //    //else if (string.IsNullOrEmpty(exDate))
        //    //    throw new Njit.Common.CheckLockException(-1002);
        //}

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>() != null)
            {
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.None, Setting.User.UserOparatesNames.خروج_از_برنامه, null, null);
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                Model.Common.User membership = dc.Users.Where(t => t.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code).Single();
                membership.isLogin = false;
                membership.IPAddress = Setting.Program.GetMacAddress().ToString();

                dc.SubmitChanges();
            }
            try
            {
                Setting.Program.ThisProgram.SetLastRunDate();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ذخیره تنظیمات" + "\r\n\r\n" + ex.Message);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("ghjk");
        }
        #region پیغام پیام
        //لیست کلی پیام را میگیرد وسپس در تایمر تعداد پیام ها را میگیرد اگر بیشتر بود پیام میدهد
        private void timerShowNonificationMessages_Tick(object sender, EventArgs e)
        {


            if (MessageUserController.GetCountMessageForUser() > ListMessages.Count)
            {
                PopupNotifier popupNotifier = new PopupNotifier();
                popupNotifier.TitleText = "پیام";
                popupNotifier.TitleFont = new Font("Arial", 20);
                popupNotifier.ContentFont = new Font("Arial", 10);
                popupNotifier.Image = global::NjitSoftware.Properties.Resources.AlertIcon;
                popupNotifier.ContentText = string.Format("شما یک پیام دارید");
                popupNotifier.Click += new EventHandler(NotifyIcon1_Click);
                popupNotifier.Popup();
                ListMessages = MessageUserController.ListMessage(null, null);
            }
        }
        #endregion
        #region بعد از کلیک روی نوتیوشن آخرین پیام را نمایش میدهد

        private void NotifyIcon1_Click(object sender, System.EventArgs e)
        {
            ShowDetailMessage f = new ShowDetailMessage();
            this.SendMessage += f.GetMessage;
            SendMessage(ListMessages.LastOrDefault().Title, ListMessages.LastOrDefault().Text, ConvertTo_PersianOREnglish_Date.GetPersianDate(ListMessages.LastOrDefault().DateSand));
            f.ShowDialog();
        }
        #endregion
        private void btnNewDossier_Click(object sender, EventArgs e)
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
        private void btnImportStudent_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (View.ImportStudentFromExcel f = new View.ImportStudentFromExcel())
            {
                f.ShowDialog();
            }
        }
        private void btnArchiveDocumnetShow_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (View.ArchiveDocumentShow f = new View.ArchiveDocumentShow("", 0))
            {
                f.ShowDialog(this);
            }
        }
        private void btnArchiveDocumnetManagement_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (View.ArchiverDocumentManagement f = new View.ArchiverDocumentManagement("", 0))
            {
                f.ShowDialog();
            }
        }
        private void btnShowDossier_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                (new View.DossierEdit(null)).Show(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDossierSearch_Click(object sender, EventArgs e)
        {
            if (View.DossierSearch.Instance.Visible)
            {
                if (View.DossierSearch.Instance.WindowState == FormWindowState.Minimized)
                    View.DossierSearch.Instance.WindowState = FormWindowState.Normal;
                View.DossierSearch.Instance.Activate();
            }
            else
                View.DossierSearch.Instance.Show(this);
        }

        private void btnDossierMove_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (View.DossierMove f = new View.DossierMove())
            {
                f.ShowDialog();
            }
        }
        private void btnDossierChangeDataField_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            using (View.DossierChangeDataField f = new View.DossierChangeDataField())
            {
                f.ShowDialog();
            }
        }
        private void btnSelectDisplayField_Click(object sender, EventArgs e)
        {
            using (View.LendingManageForms.SelectDisplayFields f = new View.LendingManageForms.SelectDisplayFields())
            {
                f.ShowDialog();
            }
        }
        private void btnSendgMessage_Click(object sender, EventArgs e)
        {
            SendMessage f = new SendMessage();
            f.ShowDialog();
        }
        private void btnShowMessage_Click(object sender, EventArgs e)
        {
            ShowMessage f = new ShowMessage();
            f.ShowDialog();
        }
        private void btnLendingAdd_Click(object sender, EventArgs e)
        {
            using (View.LendingManageForms.LendingAddEdit form = new LendingManageForms.LendingAddEdit(null))
            {
                form.ShowDialog(this);
            }
        }

        private void btnLendingList_Click(object sender, EventArgs e)
        {
            if (View.LendingManageForms.LendingList.Instance.Visible)
            {
                if (View.LendingManageForms.LendingList.Instance.WindowState == FormWindowState.Minimized)
                    View.LendingManageForms.LendingList.Instance.WindowState = FormWindowState.Normal;
                View.LendingManageForms.LendingList.Instance.Activate();
            }
            else
                View.LendingManageForms.LendingList.Instance.Show(this);
        }

        private void btnProgramSetting_Click(object sender, EventArgs e)
        {
            using (View.ProgramSettings form = new ProgramSettings())
            {
                form.ShowDialog();
            }
        }

        private void btnArchiveGroupManager_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                new View.ArchiveManageForms.ArchiveTab(1).ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnSetPermissionSecurity_Click(object sender, System.EventArgs e)
        {
            using (View.UserManageForms.SetPermissionSecurity f = new View.UserManageForms.SetPermissionSecurity())
            {
                f.ShowDialog();
            }
        }
        void btnSetPermissionTitle_Click(object sender, System.EventArgs e)
        {
            using (View.UserManageForms.SetPermissionTitle f = new View.UserManageForms.SetPermissionTitle())
            {
                f.ShowDialog();
            }
        }



        private void btnSetUserPermission_Click(object sender, EventArgs e)
        {
            using (View.UserManageForms.SetPermission f = new View.UserManageForms.SetPermission())
            {
                f.ShowDialog();
            }
        }
        private void btnSetDossierPermission_Click(object sender, EventArgs e)
        {
            using (View.UserManageForms.SetDossierPermission f = new View.UserManageForms.SetDossierPermission())
            {
                f.ShowDialog();
            }
        }
        private void btnUsersAdd_Click(object sender, EventArgs e)
        {
            using (View.UserManageForms.AddUser f = new View.UserManageForms.AddUser())
            {
                f.ShowDialog();
            }
        }

        private void btnUserRoles_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (View.UserManageForms.UserRoleList.Instance.Visible)
                {
                    if (View.UserManageForms.UserRoleList.Instance.WindowState == FormWindowState.Minimized)
                        View.UserManageForms.UserRoleList.Instance.WindowState = FormWindowState.Normal;
                    View.UserManageForms.UserRoleList.Instance.Activate();
                }
                else
                    View.UserManageForms.UserRoleList.Instance.Show(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using (View.UserManageForms.UserList f = new View.UserManageForms.UserList())
            {
                f.ShowDialog();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (View.UserManageForms.ChangePassword form = new View.UserManageForms.ChangePassword())
            {
                form.ShowDialog();
            }
        }
        void btnChangePasswordWithAdmin_Click(object sender, System.EventArgs e)
        {
            using (View.UserManageForms.ChangePasswordWithAdmin form = new View.UserManageForms.ChangePasswordWithAdmin())
            {
                form.ShowDialog();
            }
        }
        private void btnUserLog_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (View.UserManageForms.UserLog.Instance.Visible)
                {
                    if (View.UserManageForms.UserLog.Instance.WindowState == FormWindowState.Minimized)
                        View.UserManageForms.UserLog.Instance.WindowState = FormWindowState.Normal;
                    View.UserManageForms.UserLog.Instance.Activate();
                }
                else
                    View.UserManageForms.UserLog.Instance.Show(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnDossierLog_Click(object sender, EventArgs e)
        {
            using (UserManageForms.DossierAndDocumentLog f = new UserManageForms.DossierAndDocumentLog())
            {
                f.ShowDialog(this);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (View.DossierReport.Instance.Visible)
            {
                if (View.DossierReport.Instance.WindowState == FormWindowState.Minimized)
                    View.DossierReport.Instance.WindowState = FormWindowState.Normal;
                View.DossierReport.Instance.Activate();
            }
            else
                View.DossierReport.Instance.Show(this);
        }
        private void btnFailure_Click(object sender, EventArgs e)
        {
            using (View.DocumentFailure f = new DocumentFailure())
            {
                f.ShowDialog(this);
            }
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (View.About f = new About())
            {
                f.ShowDialog(this);
            }
        }

        private void ScanerelegantButton_Click(object sender, EventArgs e)
        {
            using (View.ImportFiles f = new ImportFiles())
            {
                f.ShowDialog();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            Setting.Program.ThisProgram.BackupDatabase(false, true);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Setting.Program.ThisProgram.RestoreDatabase();
        }

        internal void DisableTabPages()
        {
            foreach (C1.Win.C1Ribbon.RibbonTab item in this.mainRibbon.Tabs)
            {
                if (item.Name != ribbonTabExit.Name)
                    item.Enabled = false;
            }
        }

        internal void EnableTabPages()
        {
            foreach (C1.Win.C1Ribbon.RibbonTab item in this.mainRibbon.Tabs)
            {
                item.Enabled = true;
            }
        }

        internal void SetToolstripValues()
        {
            if (Setting.Archive.ThisProgram.SelectedArchiveTree == null)
                lblProgramTitle.Text = "                    ";
            else
                lblProgramTitle.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.OrganName + "     " + "بایگانی:" + Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Title + "       ";
        }

        private void btnManagerReports_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (View.DossiersAndDocumentsInfos.Instance.Visible)
                {
                    if (View.DossiersAndDocumentsInfos.Instance.WindowState == FormWindowState.Minimized)
                        View.DossiersAndDocumentsInfos.Instance.WindowState = FormWindowState.Normal;
                    View.DossiersAndDocumentsInfos.Instance.Activate();
                }
                else
                    View.DossiersAndDocumentsInfos.Instance.Show(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnBackupOfDocuments_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (View.BackupDocuments f = new BackupDocuments())
                {
                    f.ShowDialog(this);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPersonds_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (View.PersonManageForms.RightfulPersonList.Instance.Visible)
                {
                    if (View.PersonManageForms.RightfulPersonList.Instance.WindowState == FormWindowState.Minimized)
                        View.PersonManageForms.RightfulPersonList.Instance.WindowState = FormWindowState.Normal;
                    View.PersonManageForms.RightfulPersonList.Instance.Activate();
                }
                else
                    View.PersonManageForms.RightfulPersonList.Instance.Show(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnPersonCompanies_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (View.PersonManageForms.LegalPersonList.Instance.Visible)
                {
                    if (View.PersonManageForms.LegalPersonList.Instance.WindowState == FormWindowState.Minimized)
                        View.PersonManageForms.LegalPersonList.Instance.WindowState = FormWindowState.Normal;
                    View.PersonManageForms.LegalPersonList.Instance.Activate();
                }
                else
                    View.PersonManageForms.LegalPersonList.Instance.Show(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
