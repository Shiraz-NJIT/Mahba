using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Njit.MessageBox;

namespace Njit.Program.Forms
{
    public partial class RestoreBackupForm : Njit.Program.Forms.BaseFormDialog
    {
        public RestoreBackupForm()
        {
            InitializeComponent();
        }
        public RestoreBackupForm(string BackupPath, string BackupExtension, string Database, string Title)
        {
            InitializeComponent();
            this.BackupPath = BackupPath;
            this.BackupExtension = BackupExtension;
            this.Database = Database;
            if (!string.IsNullOrEmpty(Title))
                this.Text = Title;
        }

        private string _Backup_Path;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BackupPath
        {
            get
            {
                if (string.IsNullOrEmpty(_Backup_Path))
                    _Backup_Path = @"C:\Backup";
                return _Backup_Path;
            }
            set
            {
                _Backup_Path = value;
            }
        }
        private string _BackupExtension;
        /// <summary>
        /// بدون نقطه
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BackupExtension
        {
            get
            {
                if (string.IsNullOrEmpty(_BackupExtension))
                    _BackupExtension = "bak";
                if (_BackupExtension.StartsWith("."))
                    _BackupExtension = _BackupExtension.Substring(1);
                return _BackupExtension;
            }
            set
            {
                _BackupExtension = value;
            }
        }
        private string _Database;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Database
        {
            get
            {
                if (string.IsNullOrEmpty(_Database))
                    throw new Exception("نام دیتابیس نادرست است");
                return _Database;
            }
            set
            {
                _Database = value;
            }
        }

        private void FormRestore_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            try
            {
                Options.SystemUtility.Hello();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در اتصال به سرور" + "\r\n\r\n" + ex.Message);
                return;
            }
            if (!Options.SystemUtility.DirectoryExists(this.BackupPath))
            {
                try
                {
                    Options.SystemUtility.CreateDirectory(this.BackupPath);
                }
                catch
                {
                    PersianMessageBox.Show(this, "خطا در دسترسی به فایل های پشتیبان\nمسیر فایل های پشتیبان را عوض کنید");
                    btnRestore.Enabled = false;
                    return;
                }
            }
            string[] files = null;
            try
            {
                if (Options.SystemUtility.DirectoryExists(this.BackupPath))
                    files = Options.SystemUtility.GetDirectoryFilesInfo(this.BackupPath, "*." + this.BackupExtension).Select(t => t.FullName).ToArray();
            }
            catch
            {
                PersianMessageBox.Show(this, "خطا در دسترسی به فایل های پشتیبان\nمسیر فایل های پشتیبان را عوض کنید");
                btnRestore.Enabled = false;
                return;
            }
            if (files != null)
                foreach (string filename in files)
                {
                    System.IO.FileInfo info = Options.SystemUtility.GetFileInfo(filename);
                    string date = Njit.Common.PersianCalendar.GetDate(info.LastWriteTime, "/");
                    string[] array_date = date.Split('/');
                    if (array_date.Length == 3)
                    {
                        switch (int.Parse(array_date[1]))
                        {
                            case 1:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "فروردین " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 2:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "اردیبهشت " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 3:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "خرداد " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 4:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "تیر " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 5:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "مرداد " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 6:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "شهریور " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 7:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "مهر " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 8:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "آبان " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 9:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "آذر " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 10:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "دی " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 11:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "بهمن " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                            case 12:
                                {
                                    if (!treeView.Nodes.ContainsKey(array_date[0] + " " + array_date[1]))
                                        treeView.Nodes.Add(array_date[0] + " " + array_date[1], "اسفند " + array_date[0]);
                                    treeView.Nodes[array_date[0] + " " + array_date[1]].Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(filename), System.IO.Path.GetFileNameWithoutExtension(filename));
                                    break;
                                }
                        }
                    }
                }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
                btnRestore.Enabled = false;
            else if (e.Node.Level == 1)
                btnRestore.Enabled = true;
        }

        public virtual void ExitApplication()
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string restore_file = System.IO.Path.Combine(this.BackupPath, treeView.SelectedNode.Text + "." + this.BackupExtension);
            this.Cursor = Cursors.WaitCursor;
            Njit.Sql.Backup.BackupResult backupResult = Njit.Sql.Backup.BackupDatabase(Options.SystemUtility, Options.MasterDataAccess, this, this.Database, System.IO.Path.Combine(this.BackupPath, "پشتیبان خودکار قبل از بازیابی اطلاعات (" + Njit.Common.PersianCalendar.GetDateWithMonthName(DateTime.Now, " ") + " " + Njit.Common.PersianCalendar.GetTimeReverced(DateTime.Now, "-", true) + ")" + "." + this.BackupExtension), false, false);
            switch (backupResult)
            {
                case Njit.Sql.Backup.BackupResult.Success:
                    break;
                case Njit.Sql.Backup.BackupResult.PathError:
                case Njit.Sql.Backup.BackupResult.SqlError:
                case Njit.Sql.Backup.BackupResult.Cancel:
                    PersianMessageBox.Show(this, "خطا در پشتیبان گیری خودکار قبل از بازیابی اطلاعات");
                    break;
            }
            Njit.Sql.Backup.RestoreResult result = Njit.Sql.Backup.RestoreDatabase(Options.MasterDataAccess, this, this.Database, restore_file, true, true);
            this.Cursor = Cursors.Default;
            if (result == Njit.Sql.Backup.RestoreResult.Success)
            {
                Close();
                ExitApplication();
            }
        }

        private void treeView_DoubleClick(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Level == 1 && btnRestore.Enabled)
                InvokeOnClick(btnRestore, EventArgs.Empty);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = string.Format("BackupFiles|*.{0}|AllFiles|*.*", this.BackupExtension);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                Njit.Sql.Backup.RestoreResult result = Njit.Sql.Backup.RestoreDatabase(Options.MasterDataAccess, this, this.Database, openFileDialog.FileName, true, true);
                this.Cursor = Cursors.Default;
                if (result == Njit.Sql.Backup.RestoreResult.Success)
                {
                    Close();
                    ExitApplication();
                }
            }
        }
    }
}