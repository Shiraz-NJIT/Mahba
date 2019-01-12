using System;
using System.Data.OleDb;

namespace Njit.Sql
{
    /// <summary>
    /// اینترفیس پیاده سازی کلاس دسترسی به داده ها
    /// </summary>
    public interface IOleDataAccess
    {
        System.Data.DataTable GetData(string command, params object[] parameters);
        int Execute(System.Data.CommandType CommandType, string command, params object[] parameters);
        int Execute(string command, params object[] parameters);
        object ExecuteScalar(string command, params object[] parameters);
        bool TestConnection(out string error);
        System.Data.OleDb.OleDbConnection Connection { get; }
        System.Data.OleDb.OleDbCommand Command { get; }
        System.Data.OleDb.OleDbDataAdapter Adapter { get; }
        System.Data.OleDb.OleDbTransaction Transaction { get; set; }
    }
}
