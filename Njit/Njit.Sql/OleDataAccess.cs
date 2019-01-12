using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace Njit.Sql
{
    /// <summary>
    /// کلاس دسترسی به داده ها
    /// </summary>
    [Serializable]
    public class OleDataAccess : Njit.Sql.IOleDataAccess, IDisposable
    {
        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="ConnectionString">متن کانکشن</param>
        public OleDataAccess(string ConnectionString)
        {
            this._Connection = new System.Data.OleDb.OleDbConnection(ConnectionString);
            this._Command = new System.Data.OleDb.OleDbCommand();
            this._Command.Connection = this._Connection;
            this._Adapter = new System.Data.OleDb.OleDbDataAdapter();
            this._Adapter.SelectCommand = new System.Data.OleDb.OleDbCommand();
            this._Adapter.SelectCommand.Connection = this._Connection;
        }

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="connection">کانکشن</param>
        /// <param name="transaction">تراکنش</param>
        public OleDataAccess(System.Data.OleDb.OleDbConnection connection, System.Data.OleDb.OleDbTransaction transaction)
        {
            this._Connection = connection;
            this._Command = new System.Data.OleDb.OleDbCommand();
            this._Command.Connection = this._Connection;
            this._Adapter = new System.Data.OleDb.OleDbDataAdapter();
            this._Adapter.SelectCommand = new System.Data.OleDb.OleDbCommand();
            this._Adapter.SelectCommand.Connection = this._Connection;
            this.Transaction = transaction;
        }

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="connection">کانکشن</param>
        /// <param name="transaction">تراکنش</param>
        public OleDataAccess(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            if (!(connection is System.Data.OleDb.OleDbConnection))
                throw new Exception("فقط OleDbConnection مورد قبول است");
            if (!(transaction is System.Data.OleDb.OleDbTransaction))
                throw new Exception("فقط OleDbTransaction مورد قبول است");
            this._Connection = connection as System.Data.OleDb.OleDbConnection;
            this._Command = new System.Data.OleDb.OleDbCommand();
            this._Command.Connection = this._Connection;
            this._Adapter = new System.Data.OleDb.OleDbDataAdapter();
            this._Adapter.SelectCommand = new System.Data.OleDb.OleDbCommand();
            this._Adapter.SelectCommand.Connection = this._Connection;
            this.Transaction = transaction as System.Data.OleDb.OleDbTransaction;
        }

        /// <summary>
        /// کانکشن
        /// </summary>
        private System.Data.OleDb.OleDbConnection _Connection;
        public System.Data.OleDb.OleDbConnection Connection
        {
            get
            {
                return _Connection;
            }
        }

        /// <summary>
        /// Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database. This class cannot be inherited.
        /// </summary>
        private System.Data.OleDb.OleDbCommand _Command;
        public System.Data.OleDb.OleDbCommand Command
        {
            get
            {
                return _Command;
            }
        }

        private System.Data.OleDb.OleDbDataAdapter _Adapter;
        public System.Data.OleDb.OleDbDataAdapter Adapter
        {
            get
            {
                return _Adapter;
            }
        }

        private System.Data.OleDb.OleDbTransaction _Transaction;
        public System.Data.OleDb.OleDbTransaction Transaction
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
        /// Insert
        /// </summary>
        /// <param name="model">یک شی معادل با جدول پایگاه داده</param>
        /// <param name="identityColumns">نام ستون هایی که آیدنتیتی تعریف شده اند</param>
        /// <returns>تعداد سطرهای درج شده برگشت داده میشود</returns>
        public int Insert(object model, params string[] identityColumns)
        {
            Command.Parameters.Clear();
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties().Where(t => !identityColumns.Contains(t.Name)).ToArray();
            List<System.Data.OleDb.OleDbParameter> parameters = new List<System.Data.OleDb.OleDbParameter>();
            int index = 0;
            foreach (var property in properties)
            {
                System.Data.OleDb.OleDbParameter p = new System.Data.OleDb.OleDbParameter("@p" + (index++).ToString(), property.GetValue(model, null) ?? DBNull.Value);
                Command.Parameters.Add(p);
                parameters.Add(p);
            }
            Command.CommandText = string.Format("INSERT INTO [{0}] ({1}) VALUES({2})", model.GetType().Name, properties.Select(t => "[" + t.Name + "]").Aggregate((a, b) => a + "," + b), parameters.Select(t => t.ParameterName).Aggregate((a, b) => a + "," + b));
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

        public int Update(object model, object originalModel, string[] keyColumns, params string[] identityColumns)
        {
            Command.Parameters.Clear();
            System.Reflection.PropertyInfo[] properties = model.GetType().GetProperties().Where(t => !identityColumns.Contains(t.Name)).ToArray();
            List<System.Data.OleDb.OleDbParameter> parameters = new List<System.Data.OleDb.OleDbParameter>();
            foreach (var property in properties)
            {
                System.Data.OleDb.OleDbParameter parameter = new System.Data.OleDb.OleDbParameter("@" + property.Name, property.GetValue(model, null) ?? DBNull.Value);
                Command.Parameters.Add(parameter);
                parameters.Add(parameter);
            }

            System.Reflection.PropertyInfo[] keyProperties = model.GetType().GetProperties().Where(t => keyColumns.Contains(t.Name)).ToArray();
            foreach (var property in keyProperties)
            {
                System.Data.OleDb.OleDbParameter originalParameter = new System.Data.OleDb.OleDbParameter("@original_" + property.Name, property.GetValue(originalModel, null) ?? DBNull.Value);
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
                list.Add((T)Activator.CreateInstance(type));
                foreach (System.Reflection.PropertyInfo item in type.GetProperties())
                {
                    item.SetValue(list[list.Count - 1], dt.Rows[i][item.Name] == DBNull.Value ? null : dt.Rows[i][item.Name], null);
                }
            }
            return list;
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
