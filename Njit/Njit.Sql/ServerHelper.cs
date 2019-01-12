using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Njit.Sql
{
    public class ServerHelper
    {
        public ServerHelper(string connectionString)
        {
            this.dataAccess = new DataAccess(connectionString);
        }
        public ServerHelper(SqlConnection connection, SqlTransaction transaction)
        {
            this.dataAccess = new DataAccess(connection, transaction);
        }
        public ServerHelper(System.Data.Common.DbConnection connection, System.Data.Common.DbTransaction transaction)
        {
            this.dataAccess = new DataAccess(connection, transaction);
        }

        public bool ServerIsLocal()
        {
            string server = GetServer();
            if (server == ".")
                return true;
            if (server.ToLower() == "(local)")
                return true;
            if (server.ToLower() == Environment.MachineName.ToLower())
                return true;
            return false;
        }

        public string GetServer()
        {
            string server = this.dataAccess.Connection.DataSource;
            int t = server.IndexOf('\\');
            if (t >= 0)
                server = server.Split('\\')[0];
            return server;
        }

        public string GetServerIpAddress()
        {
            return Njit.Common.PublicMethods.GetServerIpAddress(GetServer());
        }

        public DateTime GetServerDateTime()
        {
            return DateTime.Parse(dataAccess.ExecuteScalar("SELECT GETDATE() AS sysdatetime").ToString());
        }

        private DataAccess dataAccess;
    }
}
