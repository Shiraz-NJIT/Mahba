using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    static class ArchiveGroupController
    {
        public static IEnumerable<Model.Common.ArchiveGroup> GetBaseArchiveGroups(int archiveGroupID)
        {
            List<Model.Common.ArchiveGroup> list = new List<Model.Common.ArchiveGroup>();
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            AddBaseArchiveGroupTabsToList(list, dc.ArchiveGroups.Where(t => t.ID == archiveGroupID).Single());
            return list;
        }

        private static void AddBaseArchiveGroupTabsToList(List<Model.Common.ArchiveGroup> list, Model.Common.ArchiveGroup archiveGroup)
        {
            if (archiveGroup.ParentID.HasValue)
            {
                list.Add(archiveGroup.ArchiveGroup1);
                AddBaseArchiveGroupTabsToList(list, archiveGroup.ArchiveGroup1);
            }
        }

        public static IEnumerable<Model.Common.ArchiveGroup> GetArchiveGroups(Func<Model.Common.ArchiveGroup, bool> predicate)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().ArchiveGroups.Where(predicate);
        }

        public static Model.Common.ArchiveGroup GetArchiveGroupByID(int id)
        {
            return Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().ArchiveGroups.Where(t => t.ID == id).Single();
        }

        internal static IEnumerable<Model.Common.ArchiveGroup> GetChildArchiveGroups(int archiveGroupID)
        {
            List<Model.Common.ArchiveGroup> list = new List<Model.Common.ArchiveGroup>();
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            Model.Common.ArchiveGroup archiveGroup = dc.ArchiveGroups.Where(t => t.ID == archiveGroupID).Single();
            AddChildArchiveGroupsToList(dc, list, archiveGroup);
            return list;
        }

        private static void AddChildArchiveGroupsToList(Model.Common.ArchiveCommonDataClassesDataContext dc, List<Model.Common.ArchiveGroup> list, Model.Common.ArchiveGroup archiveGroup)
        {
            foreach (var item in dc.ArchiveGroups.Where(t => t.ParentID == archiveGroup.ID))
            {
                list.Add(item);
                AddChildArchiveGroupsToList(dc, list, item);
            }
        }
    }
}
