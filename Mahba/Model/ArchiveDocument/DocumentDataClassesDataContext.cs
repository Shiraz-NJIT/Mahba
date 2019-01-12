using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.ArchiveDocument
{
    partial class DocumentDataClassesDataContext
    {
        public static DocumentDataClassesDataContext GetNewInstance(string name)
        {
            return new DocumentDataClassesDataContext(Setting.Sql.ThisProgram.GetDatabaseConnection(name).ConnectionString);
        }
    }
}
