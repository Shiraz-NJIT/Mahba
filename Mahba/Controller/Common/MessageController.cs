using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class MessageController
    {
        //internal static int GetCount()
        //{
        //    Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
        //    return db.Messages.Count();
        //}
        #region ذخیره پیام
        
        internal static bool Insert(Model.Common.Message model)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);

                db.Messages.InsertOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

    }
}
