using Njit.MessageBox;
using System;
using System.Windows.Forms;

namespace Njit.Sql
{
    /// <summary>
    /// پشتیبان گیری و بازگردانی پشتیبان پایگاه داده
    /// </summary>
    [Serializable]
    public class Backup
    {
        /// <summary>
        /// پشتیبان گیری از پایگاه داده
        /// </summary>
        /// <param name="dataAccess">کلاس دسترسی به داده ها</param>
        /// <param name="owner">فرمی که این کلاس در آن صدا زده شده است</param>
        /// <param name="databaseName">نام پایگاه داده</param>
        /// <param name="backupFile">آدرس فایل پشتیبان</param>
        /// <param name="showErrorMessageBox">پیام خطا نمایش داده شود؟</param>
        /// <param name="showQuestionMessageBox">در صورتی که فایل از قبل وجود داشته باشد سوال بازنویسی فایل پرسیده شود؟</param>
        public static BackupResult BackupDatabase(Njit.Common.SystemUtility systemUtility, Njit.Sql.IDataAccess dataAccess, IWin32Window owner, string databaseName, string backupFile, bool showErrorMessageBox, bool showQuestionMessageBox)
        {
            Form form = owner == null ? null : owner as Form;
            try
            {
                systemUtility.Hello();
            }
            catch
            {
                if (showErrorMessageBox)
                {
                    SetTopMost(form, false);
                    PersianMessageBox.Show(owner, "خطا در دسترسی به سرور", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                return BackupResult.ServerError;
            }
            if (!systemUtility.DirectoryExists(System.IO.Path.GetDirectoryName(backupFile)))
            {
                try
                {
                    systemUtility.CreateDirectory(System.IO.Path.GetDirectoryName(backupFile));
                }
                catch
                {
                    if (showErrorMessageBox)
                    {
                        SetTopMost(form, false);
                        PersianMessageBox.Show(owner, "خطا در دسترسی به فایل های پشتیبان\nمسیر فایل های پشتیبان را تغییر دهید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    return BackupResult.PathError;
                }
            }
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                if (System.IO.Path.GetFileName(backupFile).Contains(c.ToString()))
                {
                    if (showErrorMessageBox)
                    {
                        SetTopMost(form, false);
                        PersianMessageBox.Show(owner, "خطا در نام فایل پشتیبان" + Environment.NewLine + "نام فایل پشتیبان صحیح نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    return BackupResult.PathError;
                }
            }
            foreach (char c in System.IO.Path.GetInvalidPathChars())
            {
                if (System.IO.Path.GetDirectoryName(backupFile).Contains(c.ToString()))
                {
                    if (showErrorMessageBox)
                    {
                        SetTopMost(form, false);
                        PersianMessageBox.Show(owner, "خطا در مسیر فایل پشتیبان" + Environment.NewLine + "مسیر فایل پشتیبان صحیح نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    return BackupResult.PathError;
                }
            }
            if (systemUtility.FileExists(backupFile) && showQuestionMessageBox)
            {
                SetTopMost(form, false);
                DialogResult r = PersianMessageBox.Show(owner, "فایل" + Environment.NewLine + backupFile + Environment.NewLine + "از قبل وجود دارد" + ". " + "مایل به جایگزینی پشتیبان جدید روی فایل هستید؟", "تایید عملیات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r != DialogResult.Yes)
                {
                    return BackupResult.Cancel;
                }
            }
            try
            {
                dataAccess.Execute(System.Data.CommandType.Text, string.Format("BACKUP DATABASE [{0}] TO  DISK = N'{1}' WITH NOFORMAT, INIT,  NAME = N'{0}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", databaseName, backupFile));
            }
            catch (Exception ex)
            {
                if (showErrorMessageBox)
                {
                    SetTopMost(form, false);
                    PersianMessageBox.Show(owner, "خطا در پشتیبان گیری از اطلاعات" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
                return BackupResult.SqlError;
            }
            return BackupResult.Success;
        }

        private static void SetTopMost(Form form, bool value)
        {
            if (form != null)
                form.TopMost = value;
        }

        /// <summary>
        /// بازگردانی پشتیبان
        /// </summary>
        /// <param name="dataAccess">کلاس دسترسی به داده ها</param>
        /// <param name="owner">فرمی که این کلاس در آن صدا زده شده است</param>
        /// <param name="DatabaseName">نام پایگاه داده</param>
        /// <param name="BackupFile">آدرس فایل پشتیبان</param>
        /// <param name="ShowErrorMessageBox">پیام خطا نمایش داده شود؟</param>
        /// <param name="ShowQuestionMessageBox">پیام تایید بازگردانی نمایش داده شود؟</param>
        public static RestoreResult RestoreDatabase(Njit.Sql.IDataAccess dataAccess, IWin32Window owner, string DatabaseName, string BackupFile, bool ShowErrorMessageBox, bool ShowQuestionMessageBox)
        {
            if (ShowQuestionMessageBox)
            {
                DialogResult res;
                res = PersianMessageBox.Show(owner, "اطلاعات انتخاب شده جایگزین اطلاعات فعلی می شوند" + Environment.NewLine + "ایا از بازیابی اطلاعات انتخاب شده مطمئن هستید؟", "تایید عملیات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (res != DialogResult.Yes)
                    return RestoreResult.Cancel;
            }
            try
            {
                System.Data.DataTable backupFiles = dataAccess.GetData(string.Format("RESTORE FILELISTONLY FROM DISK = N'{0}'", BackupFile));
                string backupDataFile = backupFiles.Rows[0]["LogicalName"].ToString();
                string backupLogFile = backupFiles.Rows[1]["LogicalName"].ToString();

                dataAccess.Connection.Open();
                string script = "SELECT * FROM [sys].[database_files]";
                dataAccess.Connection.ChangeDatabase(DatabaseName);
                System.Data.DataTable databaseFiles = dataAccess.GetData(script);
                string physicalDataFile = databaseFiles.Rows[0]["physical_name"].ToString();
                string physicalLogFile = databaseFiles.Rows[1]["physical_name"].ToString();
                dataAccess.Connection.Close();

                dataAccess.Execute(System.Data.CommandType.Text, string.Format("ALTER DATABASE [{0}] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE", DatabaseName));
                dataAccess.Execute(System.Data.CommandType.Text, string.Format("RESTORE DATABASE [{0}] FROM  DISK = N'{1}' WITH  FILE = 1,  MOVE N'{2}' TO N'{3}',  MOVE N'{4}' TO N'{5}',  NOUNLOAD,  REPLACE, STATS = 10", DatabaseName, BackupFile, backupDataFile, physicalDataFile, backupLogFile, physicalLogFile));
                dataAccess.Execute(System.Data.CommandType.Text, string.Format("ALTER DATABASE [{0}] SET MULTI_USER", DatabaseName));
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.ErrorCode == -2146232060 && ex.Number == 3101)
                {
                    if (ShowErrorMessageBox)
                    {
                        PersianMessageBox.Show(owner, "خطا در بازیابی اطلاعات" + Environment.NewLine + "عملیات بازیابی باید در ابتدای شروع برنامه انجام شود", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    return RestoreResult.SqlError;
                }
                else
                {
                    if (ShowErrorMessageBox)
                    {
                        PersianMessageBox.Show(owner, "خطا در بازیابی اطلاعات" + Environment.NewLine + Environment.NewLine + ex.Message);
                    }
                    return RestoreResult.SqlError;
                }
            }
            catch (Exception ex)
            {
                if (ShowErrorMessageBox)
                {
                    PersianMessageBox.Show(owner, "خطا در بازیابی اطلاعات" + Environment.NewLine + Environment.NewLine + ex.Message);
                }
                return RestoreResult.SqlError;
            }
            finally
            {
                if ((dataAccess.Connection.State & System.Data.ConnectionState.Open) == System.Data.ConnectionState.Open)
                    dataAccess.Connection.Close();
            }
            return RestoreResult.Success;
        }

        /// <summary>
        /// نتیجه پشتیبان گیری
        /// </summary>
        public enum BackupResult
        {
            Success,
            PathError,
            SqlError,
            Cancel,
            ServerError
        }

        /// <summary>
        /// نتیجه بازگردانی
        /// </summary>
        public enum RestoreResult
        {
            Success,
            SqlError,
            Cancel
        }
    }
}
