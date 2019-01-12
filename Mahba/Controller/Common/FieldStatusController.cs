using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class FieldStatusController
    {
        internal static Model.Common.FieldStatus[] GetAllFieldStatus()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.FieldStatus.ToArray();
        }

        internal static Model.Common.FieldStatus[] GetFieldStatus(int fieldTypeCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.FieldStatus.Where(t => dc.StatusOfFieldTypes.Where(a => a.FieldTypeCode == fieldTypeCode).Select(a => a.StatusCode).Contains(t.Code)).ToArray();
        }

        internal static string GetTitle(int statusCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.FieldStatus.Where(t => t.Code == statusCode).Single().Title;
        }
    }
}
