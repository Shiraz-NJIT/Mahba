using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Program
{
    public interface ISettingInitializer
    {
        Setting.ProgramSetting GetProgramSetting();
        Setting.SqlSetting GetSqlSetting();
        Setting.UserSetting GetUserSetting();
        Njit.Sql.IDataAccess GetDataAccess();
    }
}
