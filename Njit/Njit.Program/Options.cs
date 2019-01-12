using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Njit.Program
{
    public static class Options
    {
        public static void Initialize(ISettingInitializer settingInitializer)
        {
            Options.SettingInitializer = settingInitializer;
        }

        private static ISettingInitializer _SettingInitializer;
        public static ISettingInitializer SettingInitializer
        {
            get
            {
                return _SettingInitializer;
            }
            set
            {
                _SettingInitializer = value;
            }
        }

        public static Njit.Sql.IDataAccess MasterDataAccess
        {
            get
            {
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(Options.SettingInitializer.GetDataAccess().Connection.ConnectionString);
                csb.InitialCatalog = "master";
                return new Njit.Sql.DataAccess(csb.ConnectionString);
            }
        }

        private static Njit.Common.SystemUtility _SystemUtility;
        public static Njit.Common.SystemUtility SystemUtility
        {
            get
            {
                if (_SystemUtility == null)
                {
                    if (SettingInitializer == null)
                        return null;
                    _SystemUtility = GetSystemUtility(SettingInitializer.GetDataAccess().Connection, SettingInitializer.GetProgramSetting().NetworkName, SettingInitializer.GetProgramSetting().NetworkPort);
                }
                return _SystemUtility;
            }
            set
            {
                _SystemUtility = value;
            }
        }

        public static Njit.Common.SystemUtility GetSystemUtility(SqlConnection sqlConnection, string networkName, int networkPort)
        {
            if (sqlConnection.ServerIsLocal())
                return new Njit.Common.SystemUtility();
            try
            {
                return (Njit.Common.SystemUtility)System.Runtime.Remoting.RemotingServices.Connect(typeof(Njit.Common.SystemUtility), string.Format("tcp://{0}:{1}/{2}", sqlConnection.GetServerIpAddress(), networkPort, networkName));
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در اتصال به سرور" + "\r\n\r\n" + ex.Message);
            }
        }

        public static Njit.Common.SystemUtility GetSystemUtility(SqlConnection sqlConnection)
        {
            return GetSystemUtility(sqlConnection, SettingInitializer.GetProgramSetting().NetworkName, SettingInitializer.GetProgramSetting().NetworkPort);
        }

        public static Njit.Common.SystemUtility GetSystemUtility(string serverIpAddressOrName, string networkName, int networkPort)
        {
            if (Njit.Common.PublicMethods.ServerIsLocal(serverIpAddressOrName))
                return new Njit.Common.SystemUtility();
            try
            {
                return (Njit.Common.SystemUtility)System.Runtime.Remoting.RemotingServices.Connect(typeof(Njit.Common.SystemUtility), string.Format("tcp://{0}:{1}/{2}", Njit.Common.PublicMethods.GetServerIpAddress(serverIpAddressOrName), networkPort, networkName));
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در اتصال به سرور" + "\r\n\r\n" + ex.Message);
            }
        }

        public static Njit.Common.SystemUtility GetSystemUtility(string serverIpAddressOrName)
        {
            return GetSystemUtility(serverIpAddressOrName, SettingInitializer.GetProgramSetting().NetworkName, SettingInitializer.GetProgramSetting().NetworkPort);
        }
    }
}
