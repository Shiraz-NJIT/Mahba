using System;
using System.Data.SqlClient;

namespace Njit.Sql
{
    /// <summary>
    /// اینترفیس پیاده سازی کلاس دسترسی به داده ها
    /// </summary>
    public interface IDataAccess
    {
        System.Data.DataTable GetData(string command, params object[] parameters);
        int Execute(System.Data.CommandType CommandType, string command, params object[] parameters);
        int Execute(string command, params object[] parameters);
        object ExecuteScalar(string command, params object[] parameters);
        bool TestConnection(out string error);
        System.Data.SqlClient.SqlConnection Connection { get; }
        System.Data.SqlClient.SqlCommand Command { get; }
        System.Data.SqlClient.SqlDataAdapter Adapter { get; }
        System.Data.SqlClient.SqlTransaction Transaction { get; set; }
    }
}
