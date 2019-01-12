using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Njit.Sql
{
    public class TableHelper
    {
        public TableHelper(string connectionString, string tableName)
        {
            this.dataAccess = new DataAccess(connectionString);
            this.tableName = tableName;
        }
        public TableHelper(SqlConnection connection, SqlTransaction transaction, string tableName)
        {
            this.dataAccess = new DataAccess(connection, transaction);
            this.tableName = tableName;
        }
        public TableHelper(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction, string tableName)
        {
            this.dataAccess = new DataAccess(connection, transaction);
            this.tableName = tableName;
        }

        private string _TableID;
        public string TableID
        {
            get
            {
                if (_TableID == null)
                    _TableID = GetTableID();
                return _TableID;
            }
        }

        public string GetTableID()
        {
            try
            {
                return dataAccess.ExecuteScalar("SELECT [object_id] FROM [sys].[all_objects] WHERE [name]=@name", "@name", tableName).ToString();
            }
            catch
            {
                return null;
            }
        }

        public string[] GetColumnNames()
        {
            DataTable dt = GetColumns();
            string[] arr = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                arr[i] = dt.Rows[i]["name"].ToString();
            return arr;
        }

        public List<string> GetColumnNames(string extendedProperty, string value)
        {
            DataTable dt = GetColumns();
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (GetColumnExtendedProperty(dt.Rows[i]["name"].ToString(), extendedProperty) == value)
                    list.Add(dt.Rows[i]["name"].ToString());
            }
            return list;
        }

        public DataTable GetColumns()
        {
            try
            {
                return dataAccess.GetData("SELECT * FROM [sys].[all_columns] WHERE [object_id]=@table_id", "@table_id", GetTableID());
            }
            catch
            {
                return null;
            }
        }

        public string GetIdentityColumn()
        {
            DataTable columns = GetColumns();
            foreach (DataRow row in columns.Rows)
            {
                if (ColumnIsIdentity(row["name"].ToString()))
                    return row["name"].ToString();
            }
            return null;
        }

        public List<string> GetIdentityColumns()
        {
            DataTable columns = GetColumns();
            List<string> list = new List<string>();
            foreach (DataRow row in columns.Rows)
            {
                if (ColumnIsIdentity(row["name"].ToString()))
                    list.Add(row["name"].ToString());
            }
            return list;
        }

        public List<string> GetKeyColumns()
        {
            DataTable columns = GetColumns();
            List<string> list = new List<string>();
            foreach (DataRow row in columns.Rows)
            {
                if (ColumnIsKey(row["name"].ToString()))
                    list.Add(row["name"].ToString());
            }
            return list;
        }

        public bool ColumnIsKey(string columnName)
        {
            object obj = dataAccess.ExecuteScalar(string.Format("SELECT COUNT(*) FROM [sys].[indexes] AS i INNER JOIN [sys].[index_columns] AS ic ON i.OBJECT_ID = ic.OBJECT_ID AND i.index_id = ic.index_id WHERE i.is_primary_key = 1 AND OBJECT_NAME(ic.OBJECT_ID) ='{0}' AND COL_NAME(ic.OBJECT_ID,ic.column_id) = '{1}'", this.tableName, columnName));
            int i;
            if (int.TryParse(obj.ToString(), out i))
                return i > 0 ? true : false;
            return false;
        }

        public bool ColumnIsIdentity(string columnName)
        {
            object obj = dataAccess.ExecuteScalar("SELECT [is_identity] FROM [sys].[all_columns] WHERE [object_id]=@table_id AND [name]=@name", "@table_id", GetTableID(), "@name", columnName);
            if (obj == null)
                return false;
            bool IsIdentity;
            if (bool.TryParse(obj.ToString(), out IsIdentity))
                return IsIdentity;
            int i;
            if (int.TryParse(obj.ToString(), out i))
                return i == 1 ? true : false;
            return false;
        }

        public Dictionary<string, string> GetExtendedProperties()
        {
            string q = "SELECT sys.tables.name AS TableName,  sys.extended_properties.name AS Name, CAST(sys.extended_properties.value AS SQL_VARIANT) AS Value FROM sys.tables INNER JOIN sys.extended_properties ON sys.extended_properties.major_id = sys.tables.object_id AND sys.extended_properties.class = 1 WHERE sys.tables.name = '" + this.tableName + "'";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in dataAccess.GetData(q).Rows)
                dic.Add(row["Name"].ToString(), row["Value"].ToString());
            return dic;
        }

        public Dictionary<string, string> GetColumnExtendedProperties(string columnName)
        {
            string q = "SELECT sys.tables.name AS TableName, sys.all_columns.name AS ColumnName, sys.extended_properties.name AS Name, CAST(sys.extended_properties.value AS SQL_VARIANT) AS Value FROM sys.tables INNER JOIN sys.all_columns ON sys.all_columns.object_id = sys.tables.object_id INNER JOIN sys.extended_properties ON sys.extended_properties.major_id = sys.all_columns.object_id AND sys.extended_properties.minor_id = sys.all_columns.column_id AND sys.extended_properties.class = 1 WHERE sys.tables.name = '" + this.tableName + "' AND sys.all_columns.name = '" + columnName + "'";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow row in dataAccess.GetData(q).Rows)
                dic.Add(row["Name"].ToString(), row["Value"].ToString());
            return dic;
        }

        public string GetExtendedProperty(string property)
        {
            string q = "SELECT sys.tables.name AS TableName,  sys.extended_properties.name AS Name, CAST(sys.extended_properties.value AS SQL_VARIANT) AS Value FROM sys.tables INNER JOIN sys.extended_properties ON sys.extended_properties.major_id = sys.tables.object_id AND sys.extended_properties.class = 1 WHERE sys.tables.name = '" + this.tableName + "' AND sys.extended_properties.name = '" + property + "'";
            DataTable dt = dataAccess.GetData(q);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0]["Value"].ToString();
        }

        public string GetColumnExtendedProperty(string columnName, string property)
        {
            string q = "SELECT sys.tables.name AS TableName, sys.all_columns.name AS ColumnName, sys.extended_properties.name AS Name, CAST(sys.extended_properties.value AS SQL_VARIANT) AS Value FROM sys.tables INNER JOIN sys.all_columns ON sys.all_columns.object_id = sys.tables.object_id INNER JOIN sys.extended_properties ON sys.extended_properties.major_id = sys.all_columns.object_id AND sys.extended_properties.minor_id = sys.all_columns.column_id AND sys.extended_properties.class = 1 WHERE sys.tables.name = '" + this.tableName + "' AND sys.all_columns.name = '" + columnName + "' AND sys.extended_properties.name = '" + property + "'";
            DataTable dt = dataAccess.GetData(q);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0]["Value"].ToString();
        }

        public void AddExtendedPropertyToTable(string propertyName, string value)
        {
            dataAccess.Execute("EXEC sys.sp_addextendedproperty @name=N'" + propertyName + "', @value=N'" + value + "' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" + tableName + "'");
        }

        public void AddExtendedPropertyToColumn(string columnName, string propertyName, string value)
        {
            dataAccess.Execute("EXEC sys.sp_addextendedproperty @name=N'" + propertyName + "', @value=N'" + value + "' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" + tableName + "', @level2type=N'COLUMN',@level2name=N'" + columnName + "'");
        }

        public void UpdateTableExtendedProperty(string propertyName, string value)
        {
            if (GetExtendedProperty(propertyName) == null)
                AddExtendedPropertyToTable(propertyName, value);
            else
                dataAccess.Execute("EXEC sys.sp_updateextendedproperty @name=N'" + propertyName + "', @value=N'" + value + "' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" + tableName + "'");
        }

        public void UpdateColumnExtendedProperty(string columnName, string propertyName, string value)
        {
            if (GetColumnExtendedProperty(columnName, propertyName) == null)
                AddExtendedPropertyToColumn(columnName, propertyName, value);
            else
                dataAccess.Execute("EXEC sys.sp_updateextendedproperty @name=N'" + propertyName + "', @value=N'" + value + "' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" + tableName + "', @level2type=N'COLUMN',@level2name=N'" + columnName + "'");
        }

        public void DeleteTableExtendedProperty(string propertyName)
        {
            if (ExistExtendedProperty(propertyName))
                dataAccess.Execute("EXEC sys.sp_dropextendedproperty @name=N'" + propertyName + "' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" + tableName + "'");
        }

        public void DeleteColumnExtendedProperty(string columnName, string propertyName)
        {
            if (ExistColumnExtendedProperty(columnName, propertyName))
                dataAccess.Execute("EXEC sys.sp_dropextendedproperty @name=N'" + propertyName + "' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'" + tableName + "', @level2type=N'COLUMN',@level2name=N'" + columnName + "'");
        }

        public bool ExistColumnExtendedProperty(string columnName, string property)
        {
            string q = "SELECT sys.tables.name AS TableName, sys.all_columns.name AS ColumnName, sys.extended_properties.name AS Name, CAST(sys.extended_properties.value AS SQL_VARIANT) AS Value FROM sys.tables INNER JOIN sys.all_columns ON sys.all_columns.object_id = sys.tables.object_id INNER JOIN sys.extended_properties ON sys.extended_properties.major_id = sys.all_columns.object_id AND sys.extended_properties.minor_id = sys.all_columns.column_id AND sys.extended_properties.class = 1 WHERE sys.tables.name = '" + this.tableName + "' AND sys.all_columns.name = '" + columnName + "' AND sys.extended_properties.name = '" + property + "'";
            DataTable dt = dataAccess.GetData(q);
            if (dt.Rows.Count == 0)
                return false;
            return true;
        }

        public bool ExistExtendedProperty(string property)
        {
            string q = "SELECT sys.tables.name AS TableName,  sys.extended_properties.name AS Name, CAST(sys.extended_properties.value AS SQL_VARIANT) AS Value FROM sys.tables INNER JOIN sys.extended_properties ON sys.extended_properties.major_id = sys.tables.object_id AND sys.extended_properties.class = 1 WHERE sys.tables.name = '" + this.tableName + "' AND sys.extended_properties.name = '" + property + "'";
            DataTable dt = dataAccess.GetData(q);
            if (dt.Rows.Count == 0)
                return false;
            return true;
        }

        public string GetNewField()
        {
            string name = "Field";
            int index = 1;
            string[] columns = this.GetColumnNames();
            do
            {
                if (columns.Where(t => t == (name + index)).Count() == 0)
                    return (name + index);
                index++;
            } 
            while (true);
        }

        private DataAccess dataAccess;
        private string tableName;
    }
}
