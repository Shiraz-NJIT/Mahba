using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Njit.MessageBox;

namespace Njit.Program.Forms
{
    public partial class BackupDatabaseForm : Njit.Program.Forms.BaseFormDialog
    {
        public BackupDatabaseForm()
        {
            InitializeComponent();
        }

        const string _ConstSecurityErrorMessage = "مجوز پشتیبان گیری برای شما صادر نشده است";
        private string _SecurityErrorMessage = _ConstSecurityErrorMessage;
        [DefaultValue(_ConstSecurityErrorMessage)]
        protected override string SecurityErrorMessage
        {
            get
            {
                return _SecurityErrorMessage;
            }
            set
            {
                _SecurityErrorMessage = value;
            }
        }

        public BackupDatabaseForm(string DatabaseName, string BackupPath, string FileName, string Title, string BackupExtension, bool AutoBackup, bool ShowAutoBackupCheckBox)
        {
            InitializeComponent();
            this.DatabaseName = DatabaseName;
            this.BackupPath = BackupPath;
            this.FileName = FileName;
            if (!string.IsNullOrEmpty(Title))
                this.Text = Title;
            else
                this.Text = "پشتیبان گیری از اطلاعات";
            this.AutoBackup = AutoBackup;
            this.BackupExtension = BackupExtension;
            txtBackupName.Text = this.FileName;
            txtBackupPath.Text = "بر روی سرور";
            if (!ShowAutoBackupCheckBox)
                checkBoxAuto.Visible = false;
        }

        Forms.BackupProgress backingUpForm;

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            if (this.AutoBackup)
            {
                using (backingUpForm = new Forms.BackupProgress())
                {
                    backingUpForm.Show();
                    this.ActiveControl = btnBackup;
                    InvokeOnClick(btnBackup, EventArgs.Empty);
                    backingUpForm.Close();
                }
                return System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                if (owner == null)
                    return base.ShowDialog();
                else
                    return base.ShowDialog(owner);
            }
        }

        public new DialogResult ShowDialog()
        {
            return this.ShowDialog(null);
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _AutoBackup = false;
        [DefaultValue(false)]
        [Browsable(false)]
        public bool AutoBackup
        {
            get
            {
                return _AutoBackup;
            }
            set
            {
                _AutoBackup = value;
                checkBoxAuto.Checked = value;
            }
        }

        private string _BackupExtension = ".bak";
        [DefaultValue(".bak")]
        [Browsable(false)]
        public string BackupExtension
        {
            get
            {
                return _BackupExtension;
            }
            set
            {
                _BackupExtension = value;
                if (!_BackupExtension.StartsWith("."))
                    _BackupExtension = "." + _BackupExtension;
            }
        }

        private string _BackupPath = @"C:\Backup";
        [DefaultValue(@"C:\Backup")]
        [Browsable(false)]
        public string BackupPath
        {
            get
            {
                return _BackupPath;
            }
            set
            {
                _BackupPath = value;
            }
        }

        private string _DatabaseName = null;
        [DefaultValue(null)]
        [Browsable(false)]
        public string DatabaseName
        {
            get
            {
                return _DatabaseName;
            }
            set
            {
                _DatabaseName = value;
            }
        }

        private string _FileName = null;
        [DefaultValue(null)]
        [Browsable(false)]
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(_FileName))
                    return Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true);
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }

        protected virtual void btnBackup_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == txtBackupName || this.ActiveControl == btnBackup))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            if (txtBackupName.Text == "")
            {
                string errorText = "نام پشتیبان را وارد کنید";
                PersianMessageBox.Show(this, errorText);
                txtBackupName.Focus();
                txtBackupName.SelectAll();
                return;
            }
            if (this.BackupPath == "")
            {
                string errorText = "مسیر فایل پشتیبان را انتخاب کنید";
                PersianMessageBox.Show(this, errorText);
                txtBackupPath.Focus();
                txtBackupPath.SelectAll();
                return;
            }
            Njit.Sql.Backup.BackupResult backupResult = Njit.Sql.Backup.BackupDatabase(Options.SystemUtility, Options.MasterDataAccess, backingUpForm != null ? (IWin32Window)backingUpForm : (IWin32Window)this, this.DatabaseName, Path.Combine(this.BackupPath, txtBackupName.Text + this.BackupExtension), true, true);
            if (backupResult == Njit.Sql.Backup.BackupResult.Success)
            {
                if ((txtBackupName.Tag as string) == "Local")
                {
                    try
                    {
                        string sourceFile = Path.Combine(this.BackupPath, txtBackupName.Text + this.BackupExtension);
                        Options.SystemUtility.CopyFileToClient(sourceFile, Path.Combine(txtBackupPath.Text, txtBackupName.Text + this.BackupExtension), Options.SystemUtility.GetIpAddress(System.Net.Dns.GetHostName()), Options.SettingInitializer.GetProgramSetting().NetworkName, Options.SettingInitializer.GetProgramSetting().NetworkPort);
                        try
                        {
                            Options.SystemUtility.DeleteFile(sourceFile);
                        }
                        catch { }
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در ذخیره فایل پشتیبان" + "\r\n\r\n" + ex.Message);
                        this.DialogResult = DialogResult.Abort;
                    }
                }
                else
                    this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        [Browsable(false)]
        public virtual string DatabaseBackupPath
        {
            get
            {
                return null;
            }
        }

        private int _MaxBackupFileCount = 30;
        [DefaultValue(30)]
        public virtual int MaxBackupFileCount
        {
            get
            {
                return _MaxBackupFileCount;
            }
            set
            {
                _MaxBackupFileCount = value;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.DesignMode)
                return;
            this.Refresh();
            LoadSetting();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Options.SystemUtility.Hello();
            }
            catch
            {
                PersianMessageBox.Show(this, "خطا در دسترسی به سرور", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            string windrive = Options.SystemUtility.GetSystemFolderPath().Substring(0, 2).ToLower();
            if (this.DatabaseBackupPath.ToLower().StartsWith("c:") || this.DatabaseBackupPath.ToLower().StartsWith(windrive))
            {
                string currrent_drive = this.DatabaseBackupPath.Substring(0, 2);
                currrent_drive = ":" + currrent_drive[0].ToString().ToUpper();
                PersianMessageBox.Show(this, string.Format("مسیر ذخیره فایل های پشتیبان در درایو\r\n{0}\r\n تعیین شده است\nتوصیه میشود مسیر ذخیره فایل های پشتیبان مسیری بجز درایو\r\n:C\r\nوهمچنین مسیری بجز درایوی که ویندوز در آن نصب شده است باشد\r\nلطفا به قسمت تنظیمات برنامه بروید و مسیر ذخیره فایل های پشتیبان را تغییر دهید", currrent_drive), "توصیه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            if (Options.SystemUtility.DirectoryExists(this.DatabaseBackupPath))
            {
                int countOfBackups = Options.SystemUtility.GetDirectoryFilesCount(this.DatabaseBackupPath, "*" + this.BackupExtension, SearchOption.TopDirectoryOnly);
                if (countOfBackups > MaxBackupFileCount)
                {
                    PersianMessageBox.Show(this, string.Format("تعداد فایل های پشتیبان بیشتر از {0} عدد شده است\r\nشما میتوانید فایل های پشتیبان قدیمی را حذف کنید", MaxBackupFileCount), "توصیه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        public virtual void SaveSetting()
        {

        }

        public virtual void LoadSetting()
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            SaveSetting();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupPath.Text = folderBrowserDialog.SelectedPath;
                txtBackupName.Tag = "Local";
                txtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }
        }

        private void commandLinkSchedule_Click(object sender, EventArgs e)
        {
            
        }
    }
}
