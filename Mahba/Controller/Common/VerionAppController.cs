using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class VerionAppController
    {
        public static string Version()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.VesionApps.OrderByDescending(a => a.ID).FirstOrDefault().Version;
        }
        //public static bool isNewVersion()
        //{
        //    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);

        //    string ClientIP = NjitSoftware.Setting.Program.GetMacAddress();

        //    var checkverion = dc.VesionApps.Where(q => q.OldVersion != q.NewVersion).OrderByDescending(a => a.ID).FirstOrDefault();

        //    var clientApp = dc.VersionClients.Where(a =>a.ClientIP == ClientIP).OrderByDescending(a => a.ID).FirstOrDefault(); 
        //    if (checkverion != null && clientApp == null)
        //    {
        //        return true;
        //    }else if (checkverion != null && clientApp.IsInstallUpdate==false)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool IsClientInstallUpdateApp()
        //{
        //    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);

        //    if(clientApp
        //    return clientApp==null?true:clientApp.Any();
        //}
        //public static string AppUpdatePathExe()
        //{
        //    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
        //    return dc.ProgramSettings.Select(a => a.AppUpdatePathExe).FirstOrDefault();
        //}
    }
}
