using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.DataAccess
{
    class CommonDataAccess : Njit.Sql.DataAccess
    {
        public CommonDataAccess()
            : base(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString)
        {

        }

        public static CommonDataAccess GetNewInstance()
        {
            return new CommonDataAccess();
        }

    }
}
