using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class VerionAppController
    {
        public static bool isNewVersion() { 
              Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
              return dc.VesionApps.Where(q => q.OldVersion != q.NewVersion).Any();
        }
        public static string AppUpdatePathExe()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.ProgramSettings.Select(a=>a.AppUpdatePathExe).FirstOrDefault();
        }
    }
}
