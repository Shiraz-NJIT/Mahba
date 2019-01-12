using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class DisplayFieldController
    {
        internal static bool IsDisplayField(int archiveFieldID, Enums.DisplayFieldCodes code)
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().DisplayFields.Where(t => t.ArchiveFieldID == archiveFieldID && t.Code == (int)code).Count() != 0;
        }

        internal static void SetDisplayField(int archiveFieldID, bool value, Enums.DisplayFieldCodes code)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            if (value)
            {
                if (dc.DisplayFields.Where(t => t.ArchiveFieldID == archiveFieldID && t.Code == (int)code).Count() == 0)
                {
                    dc.DisplayFields.InsertOnSubmit(Model.Archive.DisplayField.GetNewInstance((int)code, null, archiveFieldID));
                    dc.SubmitChanges();
                }
            }
            else
            {
                dc.DisplayFields.DeleteAllOnSubmit(dc.DisplayFields.Where(t => t.ArchiveFieldID == archiveFieldID && t.Code == (int)code));
                dc.SubmitChanges();
            }
        }

        internal static List<Model.Archive.ArchiveField> GetDisplayFields(NjitSoftware.Enums.DisplayFieldCodes code)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            IQueryable<int> list = dc.DisplayFields.Where(t => t.Code == (int)code).Select(t => t.ArchiveFieldID);
            return dc.ArchiveFields.Where(t => list.Contains(t.ID)).OrderBy(t => t.ArchiveTabID).ThenBy(t => t.Index).ToList();
        }

        internal static List<Model.Archive.ArchiveField> GetDisplayFields(int reportID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            IQueryable<int> list = dc.DisplayFields.Where(t => t.Code == (int)NjitSoftware.Enums.DisplayFieldCodes.گزارشات && t.ReportID == reportID).Select(t => t.ArchiveFieldID);
            return dc.ArchiveFields.Where(t => list.Contains(t.ID)).OrderBy(t => t.ArchiveTabID).ThenBy(t => t.Index).ToList();
        }

        internal static Dictionary<Model.Archive.ArchiveTab, List<Model.Archive.ArchiveField>> GetDisplayFieldsGroupedByTab(Enums.DisplayFieldCodes code)
        {
            List<Model.Archive.ArchiveField> displayFields = GetDisplayFields(code);
            Dictionary<Model.Archive.ArchiveTab, List<Model.Archive.ArchiveField>> dic = new Dictionary<Model.Archive.ArchiveTab, List<Model.Archive.ArchiveField>>();
            foreach (var item in displayFields)
            {
                List<Model.Archive.ArchiveField> temp = dic.ContainsKey(item.ArchiveTab) ? dic[item.ArchiveTab] : new List<Model.Archive.ArchiveField>();
                temp.Add(item);
                if (dic.ContainsKey(item.ArchiveTab))
                    dic[item.ArchiveTab] = temp;
                else
                    dic.Add(item.ArchiveTab, temp);
            }
            return dic;
        }
    }
}
