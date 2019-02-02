using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class VersionClientController
    {
      
        #region ذخیره 

        internal static bool Insert(Model.Common.VersionClient model)
        {
            try
            {
                model.ClientIP = NjitSoftware.Setting.Program.GetMacAddress();
                Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                db.VersionClients.InsertOnSubmit(model);
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
