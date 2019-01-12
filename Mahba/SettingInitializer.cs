using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware
{
    class SettingInitializer : Njit.Program.ISettingInitializer
    {
        private static SettingInitializer _Instance;
        public static SettingInitializer Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SettingInitializer();
                return _Instance;
            }
        }

        public Njit.Program.Setting.ProgramSetting GetProgramSetting()
        {
            return Setting.Program.ThisProgram;
        }

        public Njit.Program.Setting.SqlSetting GetSqlSetting()
        {
            return Setting.Sql.ThisProgram;
        }

        public Njit.Program.Setting.UserSetting GetUserSetting()
        {
            return Setting.User.ThisProgram;
        }

        public Njit.Sql.IDataAccess GetDataAccess()
        {
            return DataAccess.CommonDataAccess.GetNewInstance();
        }
    }
}
