using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Common
{
    partial class ArchiveCommonDataClassesDataContext
    {
        public static ArchiveCommonDataClassesDataContext GetNewInstance()
        {
            ArchiveCommonDataClassesDataContext dc = new ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc;
        }
    }
}
