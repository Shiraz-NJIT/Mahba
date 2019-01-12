using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class ArchiveController
    {
        internal static string GetArchiveTitle(string databaseName)
        {
            return Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().Archives.Where(t => t.Name == databaseName).Single().Title;
        }

        internal static Model.Common.ArchiveTree AddArchive(int? archiveGroupID, string databasePath, bool useDatabaseForSaveDocuments, string dcumentsPathOrDatabasePath, int index, int? parentID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            Model.Archive.ArchiveDataClassesDataContext archiveDc = null;

            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Common.Archive archive = Model.Common.Archive.GetNewInstance("", "بایگانی جدید", databasePath, true, false, archiveGroupID);
                dc.Archives.InsertOnSubmit(archive);
                dc.SubmitChanges();

                Model.Common.Archive originalArchive = dc.Archives.Where(t => t.ID == archive.ID).Single();

                SqlHelper.CreateArchive(dc, originalArchive, databasePath);

                Model.Common.ArchiveTree groupTree = Model.Common.ArchiveTree.GetNewInstance(null, null, archive.ID, null, null, parentID, index);
                dc.ArchiveTrees.InsertOnSubmit(groupTree);
                dc.SubmitChanges();

                string archiveDocumentDatabaseOrFilesPath;
                if (useDatabaseForSaveDocuments)
                    archiveDocumentDatabaseOrFilesPath = SqlHelper.CreateArchiveDocumnetDatabase(dc, dcumentsPathOrDatabasePath);
                else
                    archiveDocumentDatabaseOrFilesPath = dcumentsPathOrDatabasePath;

                archiveDc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.GetDatabaseConnection(originalArchive.Name).ConnectionString);
                archiveDc.Connection.Open();
                archiveDc.Transaction = archiveDc.Connection.BeginTransaction();

                NjitSoftware.Model.Archive.ArchiveSetting archiveSettingInstance = NjitSoftware.Model.Archive.ArchiveSetting.GetNewInstance(null, null, false, "نام سازمان", null, archiveDocumentDatabaseOrFilesPath, "شماره پرسنلی", 0, 1000, true, useDatabaseForSaveDocuments, useDatabaseForSaveDocuments ? dcumentsPathOrDatabasePath : null, "", null, null, 0);
                var archiveSettingsQuery = archiveDc.ArchiveSettings.Select(t => t);
                if (archiveSettingsQuery.Count() > 0)
                {
                    NjitSoftware.Model.Archive.ArchiveSetting original = archiveSettingsQuery.First();
                    NjitSoftware.Model.Archive.ArchiveSetting.Copy(original, archiveSettingInstance);
                }
                else
                {
                    NjitSoftware.Model.Archive.ArchiveSetting.Insert(archiveDc, archiveSettingInstance);
                }
                archiveDc.SubmitChanges();
                if (useDatabaseForSaveDocuments)
                {
                    Model.Archive.DocumentSaveLocation _DocumentSaveLocation = Model.Archive.DocumentSaveLocation.GetNewInstance("پایگاه داده شماره یک", archiveDocumentDatabaseOrFilesPath, true);
                    archiveDc.DocumentSaveLocations.InsertOnSubmit(_DocumentSaveLocation);
                    archiveDc.SubmitChanges();
                }
                if (archiveGroupID.HasValue)
                {
                    List<Model.Common.ArchiveGroupTab> archiveGroupTabs = Controller.Common.ArchiveGroupTabController.GetAllSelfAndBaseArchiveGroupTabs(archiveGroupID.Value);
                    foreach (var tab in archiveGroupTabs)
                        Controller.Common.ArchiveGroupTabController.AddArchiveTabToArchive(tab, dc, archiveDc);
                }
                Controller.Common.AccessPermissionTree.SaveArchivesTrees(dc);

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.افزودن, null, "افزودن بایگانی '" + archive.Title + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                if (archiveDc != null)
                    archiveDc.Transaction.Commit();
                dc.Transaction.Commit();
                return groupTree;
            }
            catch (Exception ex)
            {
                if (archiveDc != null)
                    archiveDc.Transaction.Rollback();
                dc.Transaction.Rollback();
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                if (archiveDc != null)
                    archiveDc.Connection.Close();
                dc.Connection.Close();
            }
        }

        internal static Model.Common.Archive[] GetActiveArchives()
        {
            var dc = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
            return dc.Archives.Where(t => t.Active == true).ToArray();
        }

        internal static string GetArchiveDocumentsDatabaseName(string name)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.GetDatabaseConnection(name).ConnectionString);
            if (((int)da.ExecuteScalar("SELECT COUNT(*) FROM [ArchiveSetting]")) > 0)
                if ((bool)(da.GetData("SELECT [UseDatabase] FROM [ArchiveSetting]").Rows[0][0]))
                    return da.GetData("SELECT [DocumentsPathOrDatabaseName] FROM [ArchiveSetting]").Rows[0][0].ToString();
            return null;
        }

        internal static int GetActiveArchivesCount()
        {
            var dc = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
            return dc.Archives.Where(t => t.Active == true).Count();
        }
    }
}
