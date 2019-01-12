using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.DataAccess
{
    class ArchiveDataAccess : Njit.Sql.DataAccess
    {
        public ArchiveDataAccess()
            : base(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString)
        {

        }

        public static ArchiveDataAccess GetNewInstance()
        {
            return new ArchiveDataAccess();
        }

    }
}
