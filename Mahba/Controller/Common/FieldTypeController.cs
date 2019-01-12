using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class FieldTypeController
    {
        internal static Model.Common.FieldType[] GetAllFieldTypes()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.FieldTypes.OrderBy(t => t.Index).ToArray();
        }

        internal static string GetTitle(int fieldTypeCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.FieldTypes.Where(t => t.Code == fieldTypeCode).Single().Title;
        }

        internal static Model.Common.FieldType[] GetAllFieldTypesForSubField()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.FieldTypes.Where(t => t.Code != (int)Enums.FieldTypes.زیرگروه_جدولی && t.Code != (int)Enums.FieldTypes.شمارنده).OrderBy(t => t.Index).ToArray();
        }
    }
}
