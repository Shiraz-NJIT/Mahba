using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Njit.Sql
{
    public class DatabaseHelper
    {
        public DatabaseHelper(string connectionString)
        {
            this.dataAccess = new DataAccess(connectionString);
        }
        public DatabaseHelper(SqlConnection connection, SqlTransaction transaction)
        {
            this.dataAccess = new DataAccess(connection, transaction);
        }
        public DatabaseHelper(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            this.dataAccess = new DataAccess(connection, transaction);
        }

        public void CreateDatabase(string name, string path)
        {
            string file1 = System.IO.Path.Combine(path, name + ".mdf");
            string file2 = System.IO.Path.Combine(path, name + "_log.ldf");
            if (System.IO.File.Exists(file1))
                throw new Exception("فایل زیر از قبل وجود دارد. لطفا قبل از ساخت پایگاه داده جدید این فایل را جابجا یا پاک کنید" + "\r\n" + file1);
            if (System.IO.File.Exists(file2))
                throw new Exception("فایل زیر از قبل وجود دارد. لطفا قبل از ساخت پایگاه داده جدید این فایل را جابجا یا پاک کنید" + "\r\n" + file2);
            string createQuery = string.Format("CREATE DATABASE [{0}] ON  PRIMARY ( NAME = N'{0}', FILENAME = N'{1}' , SIZE = 3072KB , FILEGROWTH = 1024KB ) LOG ON ( NAME = N'{0}_log', FILENAME = N'{2}' , SIZE = 1024KB , FILEGROWTH = 10%)", name, file1, file2);
            try
            {
                this.dataAccess.Connection.Open();
                this.dataAccess.Connection.ChangeDatabase("master");
                this.dataAccess.Execute(createQuery);
            }
            finally
            {
                this.dataAccess.Connection.Close();
            }
        }

        public void DropDatabase(string name)
        {
            try
            {
                this.dataAccess.Connection.Open();
                this.dataAccess.Connection.ChangeDatabase("master");
                this.dataAccess.Execute(string.Format("EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'{0}'", name));
                this.dataAccess.Execute(string.Format("DROP DATABASE [{0}]", name));
            }
            finally
            {
                this.dataAccess.Connection.Close();
            }
        }

        public string GetDatabaseName()
        {
            return dataAccess.Connection.Database;
        }

        public string[] GetPhysicalFileNames()
        {
            string script = "SELECT * FROM [sys].[database_files]";
            System.Data.DataTable databaseFiles = dataAccess.GetData(script);
            string[] list = new string[databaseFiles.Rows.Count];
            for (int i = 0; i < databaseFiles.Rows.Count; i++)
            {
                list[i] = databaseFiles.Rows[i]["physical_name"].ToString();
            }
            return list;
        }

        public string[] GetLogicalFileNames()
        {
            string script = "SELECT * FROM [sys].[database_files]";
            System.Data.DataTable databaseFiles = dataAccess.GetData(script);
            string[] list = new string[databaseFiles.Rows.Count];
            for (int i = 0; i < databaseFiles.Rows.Count; i++)
            {
                list[i] = databaseFiles.Rows[i]["name"].ToString();
            }
            return list;
        }

        public long GetDatabaseSize()
        {
            string script = "SELECT * FROM [sys].[database_files]";
            System.Data.DataTable databaseFiles = dataAccess.GetData(script);
            long value = 0;
            for (int i = 0; i < databaseFiles.Rows.Count; i++)
            {
                value += long.Parse(databaseFiles.Rows[i]["size"].ToString());
            }
            return value;
        }

        public string[] GetDatabaseList()
        {
            string script = "SELECT * FROM [sys].[databases]";
            System.Data.DataTable databases = dataAccess.GetData(script);
            string[] arr = new string[databases.Rows.Count];
            for (int i = 0; i < databases.Rows.Count; i++)
            {
                arr[i] = databases.Rows[i]["name"].ToString();
            }
            return arr;
        }

        private DataAccess dataAccess;
    }
}
