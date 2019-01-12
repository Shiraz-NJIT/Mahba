using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Njit.Sql
{
    /// <summary>
    /// تست ارتباط با SQLServer
    /// </summary>
    [Serializable]
    public class TestConnection
    {
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
            set
            {
                _Connection = value;
            }
        }

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="ConnectionString">متن کانکشن</param>
        public TestConnection(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// تست ارتباط
        /// </summary>
        public bool Test()
        {
            bool Result = true;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) == System.Data.ConnectionState.Open))
                return true;
            try
            {
                Connection.Open();
            }
            catch
            {
                Result = false;
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return Result;
        }
    }
}
