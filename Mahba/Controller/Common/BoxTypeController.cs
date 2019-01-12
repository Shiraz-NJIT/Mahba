using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class BoxTypeController
    {
        internal static Model.Common.BoxType[] GetBoxTypes(int fieldTypeCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.BoxTypes.Where(t => dc.BoxOfFieldTypes.Where(a => a.FieldTypeCode == fieldTypeCode).Select(a => a.BoxTypeCode).Contains(t.Code)).ToArray();
        }

        internal static Model.Common.BoxType[] GetAllBoxTypes()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.BoxTypes.ToArray();
        }

        internal static string GetTitle(int BoxTypeCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.BoxTypes.Where(t => t.Code == BoxTypeCode).Single().Title;
        }
    }
}
