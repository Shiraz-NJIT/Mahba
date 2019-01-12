using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace NjitSoftware.Setting
{
    public class Sql : Njit.Program.Setting.SqlSetting
    {
        private static Sql _ThisProgram;
        public static Sql ThisProgram
        {
            get
            {
                if (_ThisProgram == null)
                    _ThisProgram = new Sql();
                return _ThisProgram;
            }
        }

        SqlConnectionStringBuilder _DatabaseConnection;
        public override SqlConnectionStringBuilder DatabaseConnection
        {
            get
            {
                if (_DatabaseConnection == null)
                    _DatabaseConnection = new SqlConnectionStringBuilder(Properties.Settings.Default.ArchiveCommonConnectionString);
                if (_DatabaseConnection.InitialCatalog == "master")
                    _DatabaseConnection.InitialCatalog = "Njit";
                return _DatabaseConnection;
            }
            set
            {
                _DatabaseConnection = value;
                SetSettings();
            }
        }

        public SqlConnectionStringBuilder ArchiveConnection
        {
            get
            {
                if (Setting.Archive.ThisProgram.SelectedArchiveTree == null)
                    return null;
                SqlConnectionStringBuilder archiveConnection = new SqlConnectionStringBuilder(DatabaseConnection.ConnectionString);
                archiveConnection.InitialCatalog = Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name;
                return archiveConnection;
            }
        }

        public SqlConnectionStringBuilder GetDatabaseConnection(string archiveName)
        {
            SqlConnectionStringBuilder archiveConnection = new SqlConnectionStringBuilder(DatabaseConnection.ConnectionString);
            archiveConnection.InitialCatalog = archiveName;
            return archiveConnection;
        }

        [JsonIgnore]
        public override string SettingFile
        {
            get
            {
                return base.SettingFile;
            }
            set
            {
                base.SettingFile = value;
            }
        }

        public override void Load()
        {
            Njit.Sql.Connections connections = null;
            try
            {
                connections = Njit.Sql.Connections.ReadConnections(Setting.Sql.ThisProgram.SettingFile, "123456");
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن تنظیمات" + "\r\n\r\n" + ex.Message);
            }
            try
            {
                if (connections != null)
                {
                    Setting.Sql.ThisProgram.DatabaseConnection = new System.Data.SqlClient.SqlConnectionStringBuilder(connections.MainDBConnectionString);
                    Setting.Sql.ThisProgram.LockServer = connections.LockServer;
                }
                SetSettings();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در اعمال تنظیمات برنامه" + "\r\n\r\n" + ex.Message);
            }
        }

        public override void Save()
        {
            Njit.Sql.Connections.SaveConnections(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString, "", Setting.Sql.ThisProgram.LockServer, Setting.Sql.ThisProgram.SettingFile, "123456");
        }

        public override void SetSettings()
        {
            //DataClasses.MainDataAccess.Instance = new DataClasses.MainDataAccess(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            //DataClasses.MasterDataAccess.Instance = new DataClasses.MasterDataAccess();

            //Njit.Program.Options.MainDataAccess = DataClasses.MainDataAccess.Instance;
            //Njit.Program.Options.MasterDataAccess = DataClasses.MasterDataAccess.Instance;
            //Njit.Program.Options.LockServer = Setting.Sql.ThisProgram.LockServer;
        }

        private string _LoadedMainDBConnectionString = "";
        public string LoadedMainDBConnectionString
        {
            get
            {
                return _LoadedMainDBConnectionString;
            }
            set
            {
                _LoadedMainDBConnectionString = value;
            }
        }
    }
}
