using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    static class AccessPermissionTree
    {
        internal static void SaveDossierTypeTrees()
        {
            var dc = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
            var archiveDc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            foreach (var item in archiveDc.DossierTypes)
            {
                var query = dc.AccessPermissionTrees.Where(t => t.Item == Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.DossierType));
                if (query.Count() == 0)
                {
                    Model.Common.AccessPermissionTree tree = Model.Common.AccessPermissionTree.GetNewInstance(Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.DossierType), null, "سطح دسترسی پرونده ها", true, false);
                    dc.AccessPermissionTrees.InsertOnSubmit(tree);
                    dc.SubmitChanges();
                }
                var accessPermissionTreeQuery = dc.AccessPermissionTrees.Where(t => t.Group == Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.DossierType) && t.Item == item.ID.ToString());
                if (accessPermissionTreeQuery.Count() > 0)
                {
                    Model.Common.AccessPermissionTree originalTree = accessPermissionTreeQuery.Single();
                    Model.Common.AccessPermissionTree tree = Model.Common.AccessPermissionTree.GetNewInstance(item.ID.ToString(), Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.DossierType), item.Title, true, false);
                    Model.Common.AccessPermissionTree.Copy(originalTree, tree);
                    dc.SubmitChanges();
                }
                else
                {
                    Model.Common.AccessPermissionTree tree = Model.Common.AccessPermissionTree.GetNewInstance(item.ID.ToString(), Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.DossierType), item.Title, true, false);
                    dc.AccessPermissionTrees.InsertOnSubmit(tree);
                    dc.SubmitChanges();
                }
            }
        }
        
        internal static void SaveArchivesTrees(Model.Common.ArchiveCommonDataClassesDataContext dc)
        {
            var accessPermissionTreesQuery = dc.AccessPermissionTrees.Where(t => t.Item == Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.Archive));
            if (accessPermissionTreesQuery.Count() == 0)
            {
                Model.Common.AccessPermissionTree tree = Model.Common.AccessPermissionTree.GetNewInstance(Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.Archive), null, "بایگانی ها", true, false);
                dc.AccessPermissionTrees.InsertOnSubmit(tree);
                dc.SubmitChanges();
            }
            foreach (var item in dc.Archives)
            {
                var query = dc.AccessPermissionTrees.Where(t => t.Item == Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.Archive));
                if (query.Count() == 0)
                {
                    Model.Common.AccessPermissionTree tree = Model.Common.AccessPermissionTree.GetNewInstance(Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.Archive), null, "بایگانی ها", true, false);
                    dc.AccessPermissionTrees.InsertOnSubmit(tree);
                    dc.SubmitChanges();
                }
                var accessPermissionTreeQuery = dc.AccessPermissionTrees.Where(t => t.Group == Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.Archive) && t.Item == item.ID.ToString());
                if (accessPermissionTreeQuery.Count() > 0)
                {
                    Model.Common.AccessPermissionTree originalTree = accessPermissionTreeQuery.Single();
                    Model.Common.AccessPermissionTree tree = Model.Common.AccessPermissionTree.GetNewInstance(item.ID.ToString(), Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.Archive), item.Title, true, false);
                    Model.Common.AccessPermissionTree.Copy(originalTree, tree);
                    dc.SubmitChanges();
                }
                else
                {
                    Model.Common.AccessPermissionTree tree = Model.Common.AccessPermissionTree.GetNewInstance(item.ID.ToString(), Setting.User.ThisProgram.GetAccessPermissionUnitGroupName(Setting.User.AccessPermissionUnits.Archive), item.Title, true, false);
                    dc.AccessPermissionTrees.InsertOnSubmit(tree);
                    dc.SubmitChanges();
                }
            }
        }
    }
}
