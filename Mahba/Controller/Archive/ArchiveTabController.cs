using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class ArchiveTabController
    {
        public static void Insert(Model.Archive.ArchiveTab archiveTab)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                archiveTab.Index = dc.ArchiveTabs.Count() == 0 ? 1 : (dc.ArchiveTabs.Select(t => t.Index).Max() + 1);
                dc.ArchiveTabs.InsertOnSubmit(archiveTab);
                dc.SubmitChanges();
                dc.Transaction.Commit();
                dc.Connection.Close();

                SqlHelper.CreateTableForArchiveTab(dc, archiveTab);

                archiveTab.Exist = true;
                dc.SubmitChanges();

                if (archiveTab.TypeCode == (int)Enums.TabTypes.Dossier)
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_پرونده, Setting.User.UserOparatesNames.ثبت, null, "ثبت گروه اطلاعاتی '" + archiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
                else
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_سند, Setting.User.UserOparatesNames.ثبت, null, "ثبت گروه اطلاعاتی '" + archiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        public static void Insert(Model.Archive.ArchiveTab archiveTab, Model.Archive.ArchiveDataClassesDataContext dcArchive)
        {
            try
            {
                archiveTab.Index = dcArchive.ArchiveTabs.Count() == 0 ? 1 : (dcArchive.ArchiveTabs.Select(t => t.Index).Max() + 1);
                dcArchive.ArchiveTabs.InsertOnSubmit(archiveTab);
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ایجاد گروه اطلاعاتی  برای بایگانی های مشتق شده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static Model.Archive.ArchiveTab Select(Model.Archive.ArchiveDataClassesDataContext dc, int ID)
        {
            return dc.ArchiveTabs.Where(t => t.ID == ID).Single();
        }

        public static Model.Archive.ArchiveTab Select(int ID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.ArchiveTabs.Where(t => t.ID == ID).Single();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static List<Model.Archive.ArchiveTab> GetActiveArchiveTabs()
        {

            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.ArchiveTabs.Where(t => t.Deleted == false).OrderBy(t => t.Index).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static List<Model.Archive.ArchiveTab> GetActiveDossierTabs()
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.ArchiveTabs.Where(t => t.TypeCode == (int)Enums.TabTypes.Dossier && t.Deleted == false).OrderBy(t => t.Index).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static List<Model.Archive.ArchiveTab> GetActiveDocumentTabs()
        {

            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.ArchiveTabs.Where(t => t.TypeCode == (int)Enums.TabTypes.Document && t.Deleted == false).OrderBy(t => t.Index).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static bool TabNameExist(string title, int typeCode)
        {
            try
            {
                Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                return dc.ArchiveTabs.Where(t => t.TypeCode == typeCode && t.Title == title && t.Deleted == false).Count() == 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static void Update(Model.Archive.ArchiveTab archiveTab)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            Update(dc, archiveTab);
        }

        public static void Update(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveTab archiveTab)
        {
            try
            {
                var originalArchiveTab = dc.ArchiveTabs.Where(t => t.ID == archiveTab.ID).Single();
                int originalTypeCode = originalArchiveTab.TypeCode;
                string originalTitle = originalArchiveTab.Title;
                Model.Archive.ArchiveTab.Copy(originalArchiveTab, archiveTab);
                dc.SubmitChanges();
                if (originalTypeCode == (int)Enums.TabTypes.Dossier)
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_پرونده, Setting.User.UserOparatesNames.ویرایش, null, "تغییر نام گروه اطلاعاتی '" + originalTitle + "' به '" + archiveTab.Title + "'");
                else
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_سند, Setting.User.UserOparatesNames.ویرایش, null, "تغییر نام گروه اطلاعاتی '" + originalTitle + "' به '" + archiveTab.Title + "'");
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در بروزرسانی اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        public static List<Model.Archive.ArchiveField> GetArchiveFields(int archiveTabID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.ArchiveFields.Where(t => t.ArchiveTabID == archiveTabID).OrderBy(t => t.Index).ToList();
        }

        public static List<Model.Archive.ArchiveField> GetArchiveFieldsThatIsNotSubGroup(int archiveTabID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.ArchiveFields.Where(t => t.ArchiveTabID == archiveTabID && t.FieldTypeCode != (int)Enums.FieldTypes.زیرگروه_جدولی).OrderBy(t => t.Index).ToList();
        }

        public static IEnumerable<Field> GetFields(int archiveTabID)
        {
            List<Field> archiveFieldList = new List<Field>();
            foreach (var archiveField in GetArchiveFields(archiveTabID))
            {
                archiveFieldList.Add(new Field(archiveField.ID, archiveField.Label, archiveField.FieldName, archiveField.FieldTypeCode, archiveField.FieldType.Title, archiveField.StatusCode, archiveField.FieldStatus.Title, archiveField.BoxTypeCode, archiveField.BoxType.Title, archiveField.AutoComplete, archiveField.MinLength, archiveField.MaxLength, archiveField.MinValue, archiveField.MaxValue, archiveField.IDParent, archiveField.Index, archiveField.DefaultValue));
                if (archiveField.FieldTypeCode == (int)Enums.FieldTypes.زیرگروه_جدولی)
                {
                    List<Field> subGroupList = new List<Field>();
                    foreach (var archiveSubGroupField in archiveField.ArchiveSubGroupFields.OrderBy(t => t.Index))
                    {
                        subGroupList.Add(new Field(archiveSubGroupField.ID, archiveSubGroupField.Label, archiveSubGroupField.FieldName, archiveSubGroupField.FieldTypeCode, archiveSubGroupField.FieldType.Title, archiveSubGroupField.StatusCode, archiveSubGroupField.FieldStatus.Title, archiveSubGroupField.BoxTypeCode, archiveSubGroupField.BoxType.Title, archiveSubGroupField.AutoComplete, archiveSubGroupField.MinLength, archiveSubGroupField.MaxLength, archiveSubGroupField.MinValue, archiveSubGroupField.MaxValue, archiveSubGroupField.IDParent, archiveSubGroupField.Index, archiveSubGroupField.DefaultValue));
                    }
                    archiveFieldList[archiveFieldList.Count - 1].SubFields = subGroupList;
                }
            }
            return archiveFieldList;
        }

        public static IEnumerable<Field> GetFields(Model.Archive.ArchiveTab archiveTab)
        {
            return GetFields(archiveTab.ID);
        }

        internal static Model.Archive.ArchiveTab GetFirstDocumentTab()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            if (dc.ArchiveTabs.Where(t => t.TypeCode == 2).Count() > 0)
                return dc.ArchiveTabs.Where(t => t.TypeCode == 2 && t.Index == dc.ArchiveTabs.Where(a => a.TypeCode == 2).Select(a => a.Index).Min()).First();
            return null;
        }

        internal static Model.Archive.ArchiveTab GetFirstDossierTab()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            if (dc.ArchiveTabs.Where(t => t.TypeCode == 1).Count() > 0)
                return dc.ArchiveTabs.Where(t => t.TypeCode == 1 && t.Index == dc.ArchiveTabs.Where(a => a.TypeCode == 1).Select(a => a.Index).Min()).First();
            return null;
        }
        internal static Model.Archive.ArchiveTab GetName(string Name)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                return dc.ArchiveTabs.Where(t=> t.Name == Name).FirstOrDefault();
        }

        internal static void Delete(int id)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            Model.Archive.ArchiveTab archiveTab = dc.ArchiveTabs.Where(t => t.ID == id).Single();
            archiveTab.Deleted = true;
            dc.SubmitChanges();
        }

        internal static void SetIndex(int id, int index)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            Model.Archive.ArchiveTab archiveTab = dc.ArchiveTabs.Where(t => t.ID == id).Single();
            archiveTab.Index = index;
            dc.SubmitChanges();
        }
    }
}
