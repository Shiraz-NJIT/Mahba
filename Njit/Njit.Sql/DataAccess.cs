using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Njit.Sql
{
    /// <summary>
    /// کلاس دسترسی به داده ها
    /// </summary>
    [Serializable]
    public class DataAccess : Njit.Sql.IDataAccess, IDisposable
    {
        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="ConnectionString">متن کانکشن</param>
        public DataAccess(string ConnectionString)
        {
            this._Connection = new SqlConnection(ConnectionString);
            this._Command = new SqlCommand();
            this._Command.Connection = this._Connection;
            this._Adapter = new SqlDataAdapter();
            this._Adapter.SelectCommand = new SqlCommand();
            this._Adapter.SelectCommand.Connection = this._Connection;
        }

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="ConnectionString">متن کانکشن</param>
        public DataAccess(SqlConnection connection, SqlTransaction transaction)
        {
            this._Connection = connection;
            this._Command = new SqlCommand();
            this._Command.Connection = this._Connection;
            this._Adapter = new SqlDataAdapter();
            this._Adapter.SelectCommand = new SqlCommand();
            this._Adapter.SelectCommand.Connection = this._Connection;
            this.Transaction = transaction;
        }

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="ConnectionString">متن کانکشن</param>
        public DataAccess(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            if (!(connection is SqlConnection))
                throw new Exception("فقط SqlConnection مورد قبول است");
            if (!(transaction is SqlTransaction))
                throw new Exception("فقط SqlTransaction مورد قبول است");
            this._Connection = connection as SqlConnection;
            this._Command = new SqlCommand();
            this._Command.Connection = this._Connection;
            this._Adapter = new SqlDataAdapter();
            this._Adapter.SelectCommand = new SqlCommand();
            this._Adapter.SelectCommand.Connection = this._Connection;
            this.Transaction = transaction as SqlTransaction;
        }

        private SqlConnection _Connection;

        /// <summary>
        /// کانکشن
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                return _Connection;
            }
        }

        private SqlCommand _Command;

        /// <summary>
        /// Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
        /// </summary>
        public SqlCommand Command
        {
            get
            {
                return _Command;
            }
        }

        private SqlDataAdapter _Adapter;
        public SqlDataAdapter Adapter
        {
            get
            {
                return _Adapter;
            }
        }

        private SqlTransaction _Transaction;
        public SqlTransaction Transaction
        {
            get
            {
                return _Transaction;
            }
            set
            {
                _Transaction = value;
                this.Command.Transaction = value;
                this.Adapter.SelectCommand.Transaction = value;
            }
        }

        /// <summary>
        /// اجرای دستور اس کیو ال
        /// </summary>
        /// <param name="command">دستور</param>
        /// <param name="parameters">پارامتر ها</param>
        /// <returns>تعداد سطرهای مورد تغییر قرار گرفته برگشت داده می شود</returns>
        public int Execute(string command, params object[] parameters)
        {
            return Execute(CommandType.Text, command, parameters);
        }

        /// <summary>
        /// اجرای دستور اس کیو ال
        /// </summary>
        /// <param name="CommandType">نوع دستور</param>
        /// <param name="command">دستور</param>
        /// <param name="parameters">پارامتر ها</param>
        /// <returns>تعداد سطرهای مورد تغییر قرار گرفته برگشت داده می شود</returns>
        public int Execute(System.Data.CommandType CommandType, string command, params object[] parameters)
        {
            Command.Parameters.Clear();
            Command.CommandText = command;
            Command.CommandType = CommandType;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            int i;
            try
            {
                i = Command.ExecuteNonQuery();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }

        /// <summary>
        /// ثبت
        /// </summary>
        /// <param name="model">یک شی معادل با جدول پایگاه داده</param>
        /// <returns>تعداد سطرهای درج شده برگشت داده میشود</returns>
        public int InsertObject(object model)
        {
            Type type = model.GetType();
            Njit.Sql.TableHelper _TableHelper = new TableHelper(this.Connection, this.Transaction, type.Name);
            List<string> identityColumns = _TableHelper.GetIdentityColumns();
            Command.Parameters.Clear();
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties().Where(t => !identityColumns.Contains(t.Name) && t.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), false).Count() > 0).ToArray();
            List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
            int index = 0;
            foreach (var property in properties)
            {
                SqlParameter p = new SqlParameter("@p" + (index++).ToString(), property.GetValue(model, null) ?? DBNull.Value);
                Command.Parameters.Add(p);
                parameters.Add(p);
            }
            Command.CommandText = string.Format("INSERT INTO [{0}] ({1}) VALUES({2})", type.Name, properties.Select(t => "[" + t.Name + "]").Aggregate((a, b) => a + "," + b), parameters.Select(t => t.ParameterName).Aggregate((a, b) => a + "," + b));
            Command.CommandType = CommandType.Text;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            int i;
            try
            {
                i = Command.ExecuteNonQuery();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }

        /// <summary>
        /// ویرایش
        /// </summary>
        /// <param name="model">یک شی معادل با جدول پایگاه داده</param>
        /// <param name="originalModel">یک شی معادل با جدول پایگاه داده</param>
        /// <returns>تعداد سطرهای ویرایش شده برگشت داده میشود</returns>
        public int UpdateWithObject(object model, object originalModel)
        {
            Type type = model.GetType();
            Njit.Sql.TableHelper tableHelper = new TableHelper(this.Connection, this.Transaction, type.Name);
            List<string> identityColumns = tableHelper.GetIdentityColumns();
            List<string> keyColumns = tableHelper.GetKeyColumns();
            Command.Parameters.Clear();
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties().Where(t => !identityColumns.Contains(t.Name) && t.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), false).Count() > 0).ToArray();
            List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
            foreach (var property in properties)
            {
                System.Data.SqlClient.SqlParameter parameter = new System.Data.SqlClient.SqlParameter("@" + property.Name, property.GetValue(model, null) ?? DBNull.Value);
                Command.Parameters.Add(parameter);
                parameters.Add(parameter);
            }

            System.Reflection.PropertyInfo[] keyProperties = model.GetType().GetProperties().Where(t => keyColumns.Contains(t.Name)).ToArray();
            foreach (var property in keyProperties)
            {
                System.Data.SqlClient.SqlParameter originalParameter = new System.Data.SqlClient.SqlParameter("@original_" + property.Name, property.GetValue(originalModel, null) ?? DBNull.Value);
                Command.Parameters.Add(originalParameter);
                parameters.Add(originalParameter);
            }

            Command.CommandText = string.Format("UPDATE [{0}] SET {1} WHERE {2}", model.GetType().Name, properties.Select(t => "[" + t.Name + "]" + "=" + "@" + t.Name).Aggregate((a, b) => a + "," + b), keyProperties.Select(t => "[" + t.Name + "]" + "=" + "@original_" + t.Name).Aggregate((a, b) => a + " AND " + b));
            Command.CommandType = CommandType.Text;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            int i;
            try
            {
                i = Command.ExecuteNonQuery();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }

        /// <summary>
        /// حذف
        /// </summary>
        /// <param name="model">یک شی معادل با جدول پایگاه داده</param>
        /// <returns>تعداد سطرهای حذف شده برگشت داده میشود</returns>
        public int DeleteObject(object model)
        {
            Type type = model.GetType();
            Njit.Sql.TableHelper tableHelper = new TableHelper(this.Connection, this.Transaction, type.Name);
            List<string> keyColumns = tableHelper.GetKeyColumns();
            Command.Parameters.Clear();
            List<System.Data.SqlClient.SqlParameter> parameters = new List<System.Data.SqlClient.SqlParameter>();
            System.Reflection.PropertyInfo[] keyProperties = model.GetType().GetProperties().Where(t => keyColumns.Contains(t.Name)).ToArray();
            foreach (var property in keyProperties)
            {
                System.Data.SqlClient.SqlParameter originalParameter = new System.Data.SqlClient.SqlParameter("@original_" + property.Name, property.GetValue(model, null) ?? DBNull.Value);
                Command.Parameters.Add(originalParameter);
                parameters.Add(originalParameter);
            }

            Command.CommandText = string.Format("DELETE [{0}] WHERE {1}", model.GetType().Name, keyProperties.Select(t => "[" + t.Name + "]" + "=" + "@original_" + t.Name).Aggregate((a, b) => a + " AND " + b));
            Command.CommandType = CommandType.Text;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            int i;
            try
            {
                i = Command.ExecuteNonQuery();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }

        /// <summary>
        /// اجرای دستور
        /// Select
        /// که یک مقدار را برمیگرداند
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string command, params object[] parameters)
        {
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            object i;
            try
            {
                i = Command.ExecuteScalar();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }

        /// <summary>
        /// اجرای دستور
        /// Select
        /// </summary>
        /// <param name="command">دستور</param>
        /// <param name="parameters">پارامترها</param>
        public List<T> GetData<T>(string command, params object[] parameters)
        {
            if (!TestConnection())
            {
                throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست");
            }
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            Adapter.SelectCommand = Command;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            DataTable dt = new DataTable();
            try
            {
                Adapter.Fill(dt);
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            Type type = typeof(T);
            List<T> list = new List<T>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(((T)Activator.CreateInstance(type)));
                System.Reflection.PropertyInfo[] properties = type.GetProperties().Where(t => t.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), false).Count() > 0).ToArray();
                foreach (System.Reflection.PropertyInfo item in properties)
                {
                    item.SetValue(list[list.Count - 1], dt.Rows[i][item.Name] == DBNull.Value ? null : dt.Rows[i][item.Name], null);
                }
            }
            return list;
        }

        /// <summary>
        /// دریافت کل اطلاعات
        /// </summary>
        public List<T> GetData<T>()
        {
            Type type = typeof(T);
            return GetData<T>(string.Format("SELECT * FROM [{0}]", type.Name));
        }

        /// <summary>
        /// اجرای دستور
        /// Select
        /// </summary>
        /// <param name="command">دستور</param>
        /// <param name="parameters">پارامترها</param>
        public DataTable GetData(string command, params object[] parameters)
        {
            if (!TestConnection())
            {
                throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست");
            }
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            Adapter.SelectCommand = Command;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            DataTable dt = new DataTable();
            try
            {
                Adapter.Fill(dt);
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return dt;
        }

        /// <summary>
        /// تست ارتباط
        /// </summary>
        public bool TestConnection()
        {
            string temp;
            return TestConnection(out temp);
        }

        /// <summary>
        /// تست ارتباط
        /// </summary>
        /// <param name="ErrorMessage">متن خطا</param>
        public bool TestConnection(out string ErrorMessage)
        {
            System.Data.ConnectionState previousConnectionState = this.Connection.State;
            try
            {
                if (((this.Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
                    this.Connection.Open();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                this.Connection.Close();
                return false;
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    this.Connection.Close();
                }
            }
            ErrorMessage = "";
            return true;
        }

        public void Dispose()
        {
            if (this._Adapter != null)
                this._Adapter.Dispose();
            if (this._Command != null)
                this._Command.Dispose();
            if (this._Transaction != null)
                this._Transaction.Dispose();
            if (this._Connection != null)
                this._Connection.Dispose();
        }
    }
}
