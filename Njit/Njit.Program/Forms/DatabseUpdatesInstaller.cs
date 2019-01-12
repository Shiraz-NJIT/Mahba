using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Njit.Program.Forms
{
    public partial class DatabseUpdatesInstaller : Form
    {
        public DatabseUpdatesInstaller(string connectionString, string updateFilesPath, string updateFilesExtension = "sql", bool closeImmadiate = false)
        {
            InitializeComponent();
            this.ConnectionString = connectionString;
            this.DataAccess = new Njit.Sql.DataAccess(connectionString);
            this.UpdateFilesPath = updateFilesPath;
            this.UpdateFilesExtension = updateFilesExtension;
            this.CloseImmadiate = closeImmadiate;
        }

        private string _UpdateFilesExtension;
        /// <summary>
        /// بدون نقطه
        /// </summary>
        public string UpdateFilesExtension
        {
            get
            {
                return _UpdateFilesExtension;
            }
            set
            {
                if (value.StartsWith("."))
                    _UpdateFilesExtension = value.Substring(1);
                else
                    _UpdateFilesExtension = value;
            }
        }

        private string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        private string _UpdateFilesPath;
        public string UpdateFilesPath
        {
            get
            {
                return _UpdateFilesPath;
            }
            set
            {
                _UpdateFilesPath = value;
            }
        }

        Njit.Sql.IDataAccess _DataAccess;
        public Njit.Sql.IDataAccess DataAccess
        {
            get
            {
                return _DataAccess;
            }
            set
            {
                _DataAccess = value;
            }
        }

        private bool _CloseImmadiate;
        public bool CloseImmadiate
        {
            get
            {
                return _CloseImmadiate;
            }
            set
            {
                _CloseImmadiate = value;
            }
        }

        public virtual void InitDatabaseVersion()
        {
            string query = "SET ANSI_NULLS ON";
            query += Environment.NewLine + "GO" + Environment.NewLine;
            query += Environment.NewLine + "SET QUOTED_IDENTIFIER ON" + Environment.NewLine;
            query += Environment.NewLine + "GO" + Environment.NewLine;
            query += Environment.NewLine + "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DatabaseVersion]') AND type in (N'U'))" + Environment.NewLine;
            query += Environment.NewLine + "BEGIN" + Environment.NewLine;
            query += Environment.NewLine + "CREATE TABLE [dbo].[DatabaseVersion](" + Environment.NewLine;
            query += Environment.NewLine + "	[ID] [int] IDENTITY(1,1) NOT NULL," + Environment.NewLine;
            query += Environment.NewLine + "	[Version] [nvarchar](50) NOT NULL," + Environment.NewLine;
            query += Environment.NewLine + "	[ApplicationID] [uniqueidentifier] NULL," + Environment.NewLine;
            query += Environment.NewLine + " CONSTRAINT [PK_DatabaseVersion] PRIMARY KEY CLUSTERED " + Environment.NewLine;
            query += Environment.NewLine + "(" + Environment.NewLine;
            query += Environment.NewLine + "	[ID] ASC" + Environment.NewLine;
            query += Environment.NewLine + ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" + Environment.NewLine;
            query += Environment.NewLine + ") ON [PRIMARY]" + Environment.NewLine;
            query += Environment.NewLine + "END" + Environment.NewLine;
            query += Environment.NewLine + "GO" + Environment.NewLine;
            query += Environment.NewLine + "IF NOT EXISTS (SELECT * FROM [dbo].[DatabaseVersion])" + Environment.NewLine;
            query += Environment.NewLine + "BEGIN" + Environment.NewLine;
            query += Environment.NewLine + "SET IDENTITY_INSERT [dbo].[DatabaseVersion] ON" + Environment.NewLine;
            query += Environment.NewLine + "INSERT [dbo].[DatabaseVersion] ([ID], [Version], [ApplicationID]) VALUES (1, N'1.0.0.0', NULL)" + Environment.NewLine;
            query += Environment.NewLine + "SET IDENTITY_INSERT [dbo].[DatabaseVersion] OFF" + Environment.NewLine;
            query += Environment.NewLine + "END";
            string error;
            if (!Njit.Sql.SqlHelper.RunQueryWithRollback(query, this.ConnectionString, out error))
                throw new Exception(error);
        }

        public virtual Version GetDatabaseVersion()
        {
            DataTable dt = null;
            string query = "SELECT * FROM [DatabaseVersion]";
            try
            {
                dt = this.DataAccess.GetData(query);
            }
            catch
            {
                InitDatabaseVersion();
                dt = this.DataAccess.GetData(query);
            }
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    InitDatabaseVersion();
                    return new Version(1, 0, 0, 0);
                }
                else
                {
                    return new Version(dt.Rows[0]["Version"].ToString());
                }
            }
            else
                return new Version(1, 0, 0, 0);
        }

        public void CheckForUpdate()
        {
            this.ShowDialog();
        }

        public new System.Windows.Forms.DialogResult ShowDialog()
        {
            return this.ShowDialog(null);
        }

        public new System.Windows.Forms.DialogResult ShowDialog(IWin32Window owner)
        {
            Version databaseVersion = GetDatabaseVersion();
            string[] updateFiles = System.IO.Directory.GetFiles(this.UpdateFilesPath, "*." + this.UpdateFilesExtension, System.IO.SearchOption.TopDirectoryOnly);
            if (updateFiles.Length == 0)
                return System.Windows.Forms.DialogResult.OK;
            for (int i = 0; i < updateFiles.Length; i++)
            {
                updateFiles[i] = System.IO.Path.GetFileNameWithoutExtension(updateFiles[i]);
            }
            Array.Sort(updateFiles, Njit.Common.VersionComparer.Instance);
            foreach (string item in updateFiles)
            {
                Version version = new Version(item);
                if (version.CompareTo(databaseVersion) > 0)
                    this.UpdateFiles.Add(item);
            }
            if (this.UpdateFiles.Count == 0)
                return System.Windows.Forms.DialogResult.OK;
            if (owner == null)
                return base.ShowDialog();
            else
                return base.ShowDialog(owner);
        }

        private List<string> _UpdateFiles = new List<string>();
        public List<string> UpdateFiles
        {
            get
            {
                return _UpdateFiles;
            }
            set
            {
                _UpdateFiles = value;
            }
        }

        public bool IsCurrectVersion(string version)
        {
            if (version == null)
                return false;
            string[] strArray = version.Split(new char[1] { '.' });
            int length = strArray.Length;
            if (length < 2 || length > 4)
                return false;
            int _Major = int.Parse(strArray[0], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Major < 0)
                return false;
            int _Minor = int.Parse(strArray[1], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Minor < 0)
                return false;
            int num = length - 2;
            if (num <= 0)
                return true;
            int _Build = int.Parse(strArray[2], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Build < 0)
                return false;
            if (num - 1 <= 0)
                return true;
            int _Revision = int.Parse(strArray[3], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Revision < 0)
                return false;
            return true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Refresh();
            backgroundWorker.RunWorkerAsync();
            this.Refresh();
        }

        private void SetStatus(string text)
        {
            listBoxStatus.Items.Add(text);
            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
            listBoxStatus.Refresh();
        }

        private void SetMessage(string text)
        {
            SetStatus(text);
        }

        private void SetError(string text)
        {
            SetStatus("خطا --> " + text);
        }

        int closeTime = 6;

        public int CloseTime
        {
            get { return closeTime; }
            set
            {
                closeTime = value;
                lblTitle.Text = "بروزرسانی با موفقیت به پایان رسید." + Environment.NewLine + value.ToString();
            }
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.CloseTime -= 1;
            if (this.CloseTime == 0)
            {
                timerClose.Stop();
                this.Close();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int errorCount = 0;
            Version databaseVersion = GetDatabaseVersion();
            foreach (string updateFile in this.UpdateFiles)
            {
                Version updateVersion = new Version(updateFile);
                if (updateVersion.CompareTo(databaseVersion) > 0)
                {
                    backgroundWorker.ReportProgress(-1, "در حال به روز رسانی پایگاه داده به نسخه " + updateFile + " ...");
                    this.DataAccess.Connection.Open();
                    System.Data.SqlClient.SqlTransaction tr = this.DataAccess.Connection.BeginTransaction();
                    this.DataAccess.Transaction = tr;

                    string filePath = System.IO.Path.Combine(this.UpdateFilesPath, updateFile + "." + this.UpdateFilesExtension);
                    string query = System.IO.File.ReadAllText(filePath);
                    try
                    {
                        Njit.Sql.SqlHelper.RunQuery(query, this.DataAccess);
                        this.DataAccess.Execute("UPDATE [DatabaseVersion] SET [Version]=@Version", "@Version", updateVersion.ToString());
                    }
                    catch
                    {
                        tr.Rollback();
                        this.DataAccess.Connection.Close();
                        errorCount++;
                        backgroundWorker.ReportProgress(-2, "خطا در اجرای اسکریپ به روز رسانی نسخه " + updateFile);
                        e.Result = errorCount;
                        return;
                    }

                    tr.Commit();
                    this.DataAccess.Connection.Close();
                    backgroundWorker.ReportProgress(-1, "اسکریپ به روز رسانی نسخه " + updateFile + " با موفقیت نصب شد");
                }
            }
            e.Result = errorCount;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
                SetMessage(e.UserState.ToString());
            else if (e.ProgressPercentage == -2)
                SetError(e.UserState.ToString());
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                SetMessage("عملیات بروز رسانی کنسل شد.");
            else if (e.Error != null)
                SetError("در اجرای عملیات بروز رسانی خطا رخ داده است.");
            else
            {
                if (((int)e.Result) == 0)
                {
                    SetMessage("عملیات بروز رسانی با موفقیت به پایان رسید.");
                    if (this.CloseImmadiate)
                        this.Close();
                    else
                        timerClose.Start();
                }
            }
        }
    }
}
