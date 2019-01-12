using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

public static class ExtentionMethods
{
    #region SqlConnection

    public static string[] GetPhysicalFileNames(this IDbConnection connection)
    {
        Njit.Sql.DatabaseHelper dbHelper = new Njit.Sql.DatabaseHelper(connection.ConnectionString);
        return dbHelper.GetPhysicalFileNames();
    }

    public static string[] GetLogicalFileNames(this IDbConnection connection)
    {
        Njit.Sql.DatabaseHelper dbHelper = new Njit.Sql.DatabaseHelper(connection.ConnectionString);
        return dbHelper.GetLogicalFileNames();
    }

    public static long GetDatabaseSize(this IDbConnection connection)
    {
        Njit.Sql.DatabaseHelper dbHelper = new Njit.Sql.DatabaseHelper(connection.ConnectionString);
        return dbHelper.GetDatabaseSize();
    }

    public static string GetTableID(this IDbConnection connection, string tableName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetTableID();
    }

    public static string[] GetTableColumnNames(this IDbConnection connection, string tableName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetColumnNames();
    }

    public static IEnumerable<string> GetTableColumnNames(this IDbConnection connection, string tableName, string extendedProperty, string value)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetColumnNames(extendedProperty, value);
    }

    public static DataTable GetTableColumns(this IDbConnection connection, string tableName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetColumns();
    }

    public static string GetTableIdentityColumn(this IDbConnection connection, string tableName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetIdentityColumn();
    }

    public static Dictionary<string, string> GetTableExtendedProperties(this IDbConnection connection, string tableName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetExtendedProperties();
    }

    public static Dictionary<string, string> GetColumnExtendedProperties(this IDbConnection connection, string tableName, string columnName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetColumnExtendedProperties(columnName);
    }

    public static string GetTableExtendedProperty(this IDbConnection connection, string tableName, string property)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetExtendedProperty(property);
    }

    public static string GetColumnExtendedProperty(this IDbConnection connection, string tableName, string columnName, string property)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetColumnExtendedProperty(columnName, property);
    }

    public static void AddExtendedPropertyToTable(this IDbConnection connection, string tableName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        tableHelper.AddExtendedPropertyToTable(propertyName, value);
    }

    public static void AddExtendedPropertyToColumn(this IDbConnection connection, string tableName, string columnName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        tableHelper.AddExtendedPropertyToColumn(columnName, propertyName, value);
    }

    public static void UpdateTableExtendedProperty(this IDbConnection connection, string tableName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        tableHelper.UpdateTableExtendedProperty(propertyName, value);
    }

    public static void UpdateColumnExtendedProperty(this IDbConnection connection, string tableName, string columnName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        tableHelper.UpdateColumnExtendedProperty(columnName, propertyName, value);
    }

    public static void DeleteColumnExtendedProperty(this IDbConnection connection, string tableName, string columnName, string propertyName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        tableHelper.DeleteColumnExtendedProperty(columnName, propertyName);
    }

    public static void DeleteTableExtendedProperty(this IDbConnection connection, string tableName, string propertyName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        tableHelper.DeleteTableExtendedProperty(propertyName);
    }

    public static bool ServerIsLocal(this IDbConnection connection)
    {
        Njit.Sql.ServerHelper serverHelper = new Njit.Sql.ServerHelper(connection.ConnectionString);
        return serverHelper.ServerIsLocal();
    }

    public static string GetServer(this IDbConnection connection)
    {
        Njit.Sql.ServerHelper serverHelper = new Njit.Sql.ServerHelper(connection.ConnectionString);
        return serverHelper.GetServer();
    }

    public static string GetServerIpAddress(this IDbConnection connection)
    {
        Njit.Sql.ServerHelper serverHelper = new Njit.Sql.ServerHelper(connection.ConnectionString);
        return serverHelper.GetServerIpAddress();
    }

    public static string GetServerPersianDate(this IDbConnection connection)
    {
        Njit.Sql.ServerHelper serverHelper = new Njit.Sql.ServerHelper(connection.ConnectionString);
        return Njit.Common.PersianCalendar.GetDate(serverHelper.GetServerDateTime());
    }

    public static string GetServerTime(this IDbConnection connection)
    {
        Njit.Sql.ServerHelper serverHelper = new Njit.Sql.ServerHelper(connection.ConnectionString);
        return Njit.Common.PersianCalendar.GetTime(serverHelper.GetServerDateTime(), ":", true);
    }

    public static DateTime GetServerDateTime(this IDbConnection connection)
    {
        Njit.Sql.ServerHelper serverHelper = new Njit.Sql.ServerHelper(connection.ConnectionString);
        return serverHelper.GetServerDateTime();
    }

    public static string GetNewField(this IDbConnection connection, string tableName)
    {
        Njit.Sql.TableHelper tableHelper = new Njit.Sql.TableHelper(connection.ConnectionString, tableName);
        return tableHelper.GetNewField();
    }

    public static string[] GetDatabaseList(this IDbConnection connection)
    {
        Njit.Sql.DatabaseHelper databaseHelper = new Njit.Sql.DatabaseHelper(connection.ConnectionString);
        return databaseHelper.GetDatabaseList();
    }

    #endregion
    #region DataContext
    public static string[] GetPhysicalFileNames(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.DatabaseHelper dbHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection, dc.Transaction);
        else
            dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
        return dbHelper.GetPhysicalFileNames();
    }

    public static string[] GetLogicalFileNames(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.DatabaseHelper dbHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection, dc.Transaction);
        else
            dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
        return dbHelper.GetLogicalFileNames();
    }

    public static long GetDatabaseSize(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.DatabaseHelper dbHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection, dc.Transaction);
        else
            dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
        return dbHelper.GetDatabaseSize();
    }

    public static string GetTableID(this System.Data.Linq.DataContext dc, string tableName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetTableID();
    }

    public static string[] GetTableColumnNames(this System.Data.Linq.DataContext dc, string tableName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetColumnNames();
    }

    public static IEnumerable<string> GetTableColumnNames(this System.Data.Linq.DataContext dc, string tableName, string extendedProperty, string value)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetColumnNames(extendedProperty, value);
    }

    public static DataTable GetTableColumns(this System.Data.Linq.DataContext dc, string tableName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetColumns();
    }

    public static string GetTableIdentityColumn(this System.Data.Linq.DataContext dc, string tableName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetIdentityColumn();
    }

    public static Dictionary<string, string> GetTableExtendedProperties(this System.Data.Linq.DataContext dc, string tableName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetExtendedProperties();
    }

    public static Dictionary<string, string> GetColumnExtendedProperties(this System.Data.Linq.DataContext dc, string tableName, string columnName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetColumnExtendedProperties(columnName);
    }

    public static string GetTableExtendedProperty(this System.Data.Linq.DataContext dc, string tableName, string property)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetExtendedProperty(property);
    }

    public static string GetColumnExtendedProperty(this System.Data.Linq.DataContext dc, string tableName, string columnName, string property)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetColumnExtendedProperty(columnName, property);
    }

    public static void AddExtendedPropertyToTable(this System.Data.Linq.DataContext dc, string tableName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        tableHelper.AddExtendedPropertyToTable(propertyName, value);
    }

    public static void AddExtendedPropertyToColumn(this System.Data.Linq.DataContext dc, string tableName, string columnName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        tableHelper.AddExtendedPropertyToColumn(columnName, propertyName, value);
    }

    public static void UpdateTableExtendedProperty(this System.Data.Linq.DataContext dc, string tableName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        tableHelper.UpdateTableExtendedProperty(propertyName, value);
    }

    public static void UpdateColumnExtendedProperty(this System.Data.Linq.DataContext dc, string tableName, string columnName, string propertyName, string value)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        tableHelper.UpdateColumnExtendedProperty(columnName, propertyName, value);
    }

    public static void DeleteColumnExtendedProperty(this System.Data.Linq.DataContext dc, string tableName, string columnName, string propertyName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        tableHelper.DeleteColumnExtendedProperty(columnName, propertyName);
    }

    public static void DeleteTableExtendedProperty(this System.Data.Linq.DataContext dc, string tableName, string propertyName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        tableHelper.DeleteTableExtendedProperty(propertyName);
    }

    public static string GetNewField(this System.Data.Linq.DataContext dc, string tableName)
    {
        Njit.Sql.TableHelper tableHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            tableHelper = new Njit.Sql.TableHelper(dc.Connection, dc.Transaction, tableName);
        else
            tableHelper = new Njit.Sql.TableHelper(dc.Connection.ConnectionString, tableName);
        return tableHelper.GetNewField();
    }

    public static bool ServerIsLocal(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.ServerHelper serverHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection, dc.Transaction);
        else
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection.ConnectionString);
        return serverHelper.ServerIsLocal();
    }

    public static string GetServer(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.ServerHelper serverHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection, dc.Transaction);
        else
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection.ConnectionString);
        return serverHelper.GetServer();
    }

    public static string GetServerIpAddress(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.ServerHelper serverHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection, dc.Transaction);
        else
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection.ConnectionString);
        return serverHelper.GetServerIpAddress();
    }

    public static string GetServerPersianDate(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.ServerHelper serverHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection, dc.Transaction);
        else
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection.ConnectionString);
        return Njit.Common.PersianCalendar.GetDate(serverHelper.GetServerDateTime());
    }

    public static string GetServerTime(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.ServerHelper serverHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection, dc.Transaction);
        else
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection.ConnectionString);
        return Njit.Common.PersianCalendar.GetTime(serverHelper.GetServerDateTime(), ":", true);
    }

    public static DateTime GetServerDateTime(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.ServerHelper serverHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection, dc.Transaction);
        else
            serverHelper = new Njit.Sql.ServerHelper(dc.Connection.ConnectionString);
        return serverHelper.GetServerDateTime();
    }

    public static string[] GetDatabaseList(this System.Data.Linq.DataContext dc)
    {
        Njit.Sql.DatabaseHelper databaseHelper;
        if ((dc.Connection.State & ConnectionState.Open) == ConnectionState.Open && dc.Transaction != null)
            databaseHelper = new Njit.Sql.DatabaseHelper(dc.Connection, dc.Transaction);
        else
            databaseHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
        return databaseHelper.GetDatabaseList();
    }

    #endregion
}