using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Archive
{
    partial class ArchiveDataClassesDataContext
    {
        public static ArchiveDataClassesDataContext GetNewInstance()
        {
            ArchiveDataClassesDataContext dc = new ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            return dc;
        }

        public Model.Common.Archive GetArchive()
        {
            var dc = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
            return dc.Archives.Where(t => t.Name == this.Connection.Database).Single();
        }
    }
}
