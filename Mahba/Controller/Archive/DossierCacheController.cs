using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    class DossierCacheController
    {
        /// <summary>
        /// گرفتن تمام گروه های اطلاعاتی
        /// </summary>
        private static List<Model.Archive.ArchiveTab> archiveTabs = null;
        public static List<Model.Archive.ArchiveTab> GetActiveArchiveTabs()
        {
            if (archiveTabs != null)
                return archiveTabs;
            else
            {
                return archiveTabs = Controller.Archive.ArchiveTabController.GetActiveArchiveTabs();
            }
        }

        /// <summary>
        /// گرفتن تمام گروه های اطلاعاتی پرونده
        /// </summary>
        private static List<Model.Archive.ArchiveTab> dossierTabs = null;
        public static List<Model.Archive.ArchiveTab> GetActiveDossierTabs()
        {
            if (dossierTabs != null)
                return dossierTabs;
            else
            {
                return dossierTabs = Controller.Archive.ArchiveTabController.GetActiveDossierTabs();
            }
        }

        /// <summary>
        /// گرفتن تمام فیلدهای گروه اطلاعاتی
        /// </summary>
        private static List<Model.Archive.ArchiveField> archiveFields = null;
        public static List<Model.Archive.ArchiveField> GetAllArchiveFields()
        {
            if (archiveFields != null)
                return archiveFields;
            else
                return archiveFields = Controller.Archive.ArchiveFieldController.GetAllArchiveFields();
        }

        /// <summary>
        /// گرفتن فیلدهای یک گروه اطلاعاتی خاص
        /// </summary>
        public static List<Model.Archive.ArchiveField> GetArchiveFields(int archiveTabID)
        {
            if (archiveFields == null)
                GetAllArchiveFields();
            return archiveFields.Where(t => t.ArchiveTabID == archiveTabID).ToList();
        }

        /// <summary>
        /// گرفتن تمام فیلدهای زیر گروه اطلاعاتی
        /// </summary>
        private static List<Model.Archive.ArchiveSubGroupField> subGroupFields = null;
        public static List<Model.Archive.ArchiveSubGroupField> GetAllSubGroupFields()
        {
            if (subGroupFields != null)
                return subGroupFields;
            else
                return subGroupFields = Controller.Archive.ArchiveSubGroupFieldController.GetAllSubGroupFields();
        }

        /// <summary>
        /// گرفتن فیلدهای یک زیر گروه اطلاعاتی خاص
        /// </summary>
        public static List<Model.Archive.ArchiveSubGroupField> GetSubGroupFields(int archiveFieldID)
        {
            if (subGroupFields == null)
                GetAllSubGroupFields();
            return subGroupFields.Where(t => t.ArchiveFieldID == archiveFieldID).ToList();
        }

        public static void ClearCachedData()
        {
            archiveTabs = null;
            dossierTabs = null;
            archiveFields = null;
            subGroupFields = null;
        }
    }
}
