using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class ArchiveGroupSubGroupFieldController
    {
        internal static int AddSubGroupField(Field field, int archiveGroupFieldID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext commonDataContext = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext = new List<Model.Archive.ArchiveDataClassesDataContext>();
            try
            {
                commonDataContext.Connection.Open();
                commonDataContext.Transaction = commonDataContext.Connection.BeginTransaction();

                Model.Common.ArchiveGroupField archiveGroupField = commonDataContext.ArchiveGroupFields.Where(t => t.ID == archiveGroupFieldID).Single();

                IEnumerable<string> archivesConnections = Controller.Common.ArchiveGroupTabController.GetArchivesConnectionStrings(archiveGroupField.ArchiveGroupTabID);
                foreach (string connectionString in archivesConnections)
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(connectionString);
                    dcArchive.Connection.Open();
                    dcArchive.Transaction = dcArchive.Connection.BeginTransaction();
                    archivesDataContext.Add(dcArchive);
                }

                CheckSubGroupFieldName(commonDataContext, archivesDataContext, field.Label, archiveGroupFieldID);

                int index = 1;
                if (archiveGroupField.ArchiveGroupSubGroupFields.Count > 0)
                    index = archiveGroupField.ArchiveGroupSubGroupFields.Max(t => t.Index) + 1;
                Model.Common.ArchiveGroupSubGroupField archiveGroupSubGroupField = Model.Common.ArchiveGroupSubGroupField.GetNewInstance(archiveGroupFieldID, field.Label, field.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, index);
                commonDataContext.ArchiveGroupSubGroupFields.InsertOnSubmit(archiveGroupSubGroupField);
                commonDataContext.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.گروه_بایگانی, Setting.User.UserOparatesNames.ثبت, null, "افزودن فیلد '" + archiveGroupSubGroupField.Label + "' به فیلد '" + archiveGroupField.Label + "' در گروه اطلاعاتی '" + archiveGroupField.ArchiveGroupTab.Title + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                foreach (var dcArchive in archivesDataContext)
                {
                    Controller.Archive.ArchiveSubGroupFieldController.AddSubGroupField(dcArchive, archiveGroupSubGroupField);
                }

                commonDataContext.Transaction.Commit();
                foreach (var dcArchive in archivesDataContext)
                    dcArchive.Transaction.Commit();

                return archiveGroupSubGroupField.ID;
            }
            catch
            {
                commonDataContext.Transaction.Rollback();
                foreach (var dcArchive in archivesDataContext)
                    dcArchive.Transaction.Rollback();
                throw;
            }
            finally
            {
                foreach (var dcArchive in archivesDataContext)
                    if (dcArchive.Connection.State == System.Data.ConnectionState.Open)
                        dcArchive.Connection.Close();
                if (commonDataContext.Connection.State == System.Data.ConnectionState.Open)
                    commonDataContext.Connection.Close();
            }
        }

        internal static void UpdateSubGroupField(int originalArchiveGroupSubGroupFieldID, Field field)
        {
            Model.Common.ArchiveCommonDataClassesDataContext commonDataContext = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext = new List<Model.Archive.ArchiveDataClassesDataContext>();
            try
            {
                commonDataContext.Connection.Open();
                commonDataContext.Transaction = commonDataContext.Connection.BeginTransaction();

                Model.Common.ArchiveGroupSubGroupField originalArchiveGroupSubGroupField = commonDataContext.ArchiveGroupSubGroupFields.Where(t => t.ID == originalArchiveGroupSubGroupFieldID).Single();
                string originalLabel = originalArchiveGroupSubGroupField.Label;
                string originalGroupFieldLabel = originalArchiveGroupSubGroupField.ArchiveGroupField.Label;
                string originalGroupTabTitle = originalArchiveGroupSubGroupField.ArchiveGroupField.ArchiveGroupTab.Title;

                IEnumerable<string> archivesConnections = Controller.Common.ArchiveGroupTabController.GetArchivesConnectionStrings(originalArchiveGroupSubGroupField.ArchiveGroupField.ArchiveGroupTabID);
                foreach (string connectionString in archivesConnections)
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(connectionString);
                    dcArchive.Connection.Open();
                    dcArchive.Transaction = dcArchive.Connection.BeginTransaction();
                    archivesDataContext.Add(dcArchive);
                }

                CheckSubGroupFieldName(commonDataContext, archivesDataContext, field.Label, originalArchiveGroupSubGroupField.ArchiveGroupFieldID, originalArchiveGroupSubGroupField.ID);

                Model.Common.ArchiveGroupSubGroupField archiveSubGroupField = Model.Common.ArchiveGroupSubGroupField.GetNewInstance(originalArchiveGroupSubGroupField.ArchiveGroupField.ID, field.Label, originalArchiveGroupSubGroupField.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, originalArchiveGroupSubGroupField.Index);
                Model.Common.ArchiveGroupSubGroupField.Copy(originalArchiveGroupSubGroupField, archiveSubGroupField);
                commonDataContext.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.گروه_بایگانی, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش فیلد '" + originalLabel + "' در فیلد '" + originalGroupFieldLabel + "' در گروه اطلاعاتی '" + originalGroupTabTitle + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                foreach (var dcArchive in archivesDataContext)
                {
                    Controller.Archive.ArchiveSubGroupFieldController.UpdateSubGroupField(dcArchive, originalArchiveGroupSubGroupField);
                }

                commonDataContext.Transaction.Commit();
                foreach (var dcArchive in archivesDataContext)
                    dcArchive.Transaction.Commit();
            }
            catch
            {
                commonDataContext.Transaction.Rollback();
                foreach (var dcArchive in archivesDataContext)
                    dcArchive.Transaction.Rollback();
                throw;
            }
            finally
            {
                foreach (var dcArchive in archivesDataContext)
                    if (dcArchive.Connection.State == System.Data.ConnectionState.Open)
                        dcArchive.Connection.Close();
                if (commonDataContext.Connection.State == System.Data.ConnectionState.Open)
                    commonDataContext.Connection.Close();
            }
        }

        internal static void DeleteSubGroupField(int archiveGroupSubGroupFieldID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext commonDataContext = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext = new List<Model.Archive.ArchiveDataClassesDataContext>();
            try
            {
                commonDataContext.Connection.Open();
                commonDataContext.Transaction = commonDataContext.Connection.BeginTransaction();

                Model.Common.ArchiveGroupSubGroupField archiveGroupSubGroupField = commonDataContext.ArchiveGroupSubGroupFields.Where(t => t.ID == archiveGroupSubGroupFieldID).Single();
                string originalLabel = archiveGroupSubGroupField.Label;
                string originalGroupFieldLabel = archiveGroupSubGroupField.ArchiveGroupField.Label;
                string originalGroupTabTitle = archiveGroupSubGroupField.ArchiveGroupField.ArchiveGroupTab.Title;

                IEnumerable<string> archivesConnections = Controller.Common.ArchiveGroupTabController.GetArchivesConnectionStrings(archiveGroupSubGroupField.ArchiveGroupField.ArchiveGroupTabID);
                foreach (string connectionString in archivesConnections)
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(connectionString);
                    dcArchive.Connection.Open();
                    dcArchive.Transaction = dcArchive.Connection.BeginTransaction();
                    archivesDataContext.Add(dcArchive);
                }

                foreach (var dcArchive in archivesDataContext)
                {
                    Controller.Archive.ArchiveSubGroupFieldController.DeleteSubGroupField(dcArchive, archiveGroupSubGroupField);
                }

                commonDataContext.ArchiveGroupSubGroupFields.DeleteOnSubmit(archiveGroupSubGroupField);
                commonDataContext.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.گروه_بایگانی, Setting.User.UserOparatesNames.حذف, null, "حذف فیلد '" + originalLabel + "' در فیلد '" + originalGroupFieldLabel + "' در گروه اطلاعاتی '" + originalGroupTabTitle + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                commonDataContext.Transaction.Commit();
                foreach (var dcArchive in archivesDataContext)
                    dcArchive.Transaction.Commit();
            }
            catch
            {
                commonDataContext.Transaction.Rollback();
                foreach (var dcArchive in archivesDataContext)
                    dcArchive.Transaction.Rollback();
                throw;
            }
            finally
            {
                foreach (var dcArchive in archivesDataContext)
                    if (dcArchive.Connection.State == System.Data.ConnectionState.Open)
                        dcArchive.Connection.Close();
                if (commonDataContext.Connection.State == System.Data.ConnectionState.Open)
                    commonDataContext.Connection.Close();
            }
        }

        internal static IEnumerable<Field> GetSubGroupFields(string archiveGroupFieldName, int archiveGroupID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            return GetSubGroupFields(dc.ArchiveGroupFields.Where(t => t.FieldName == archiveGroupFieldName).Single().ID, archiveGroupID);
        }

        internal static IEnumerable<Field> GetSubGroupFields(int archiveGroupFieldID, int archiveGroupID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<NjitSoftware.Field> fields = new List<Field>();
            foreach (var item in dc.ArchiveGroupSubGroupFields.Where(t => t.ArchiveGroupFieldID == archiveGroupFieldID).OrderBy(t => t.Index))
            {
                fields.Add(new Field(item.ID, item.Label, item.FieldName, item.FieldTypeCode, item.FieldType.Title, item.StatusCode, item.FieldStatus.Title, item.BoxTypeCode, item.BoxType.Title, item.AutoComplete, item.MinLength, item.MaxLength, item.MinValue, item.MaxValue, (item.ArchiveGroupField.ArchiveGroupID != archiveGroupID) ? item.ArchiveGroupField.ArchiveGroupTabID : (int?)null, item.Index, item.DefaultValue));
            }
            return fields;
        }

        internal static void UpdateSubGroupFieldsIndex(Dictionary<int, int> list)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            foreach (var id in list.Keys)
            {
                var item = dc.ArchiveGroupSubGroupFields.Where(t => t.ID == id).Single();
                item.Index = list[id];
            }
            dc.SubmitChanges();
        }

        internal static void CheckSubGroupFieldName(Model.Common.ArchiveCommonDataClassesDataContext dc, List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext, string label, int archiveGroupFieldID, int originalArchiveGroupSubGroupFieldID)
        {
            Model.Common.ArchiveGroupField archiveGroupField = dc.ArchiveGroupFields.Where(t => t.ID == archiveGroupFieldID).Single();

            if (dc.ArchiveGroupSubGroupFields.Where(t => t.ID != originalArchiveGroupSubGroupFieldID && t.ArchiveGroupFieldID == archiveGroupFieldID && t.Label == label).Count() > 0)
                throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveGroupField.Label));

            foreach (Model.Archive.ArchiveDataClassesDataContext dcArchive in archivesDataContext)
            {
                foreach (var archiveTab in dcArchive.ArchiveTabs.Where(t => t.IDParent == archiveGroupField.ArchiveGroupTabID && t.Deleted == false))
                {
                    foreach (var archiveField in archiveTab.ArchiveFields.Where(t => t.IDParent == archiveGroupFieldID))
                    {
                        if (archiveField.ArchiveSubGroupFields.Where(t => t.Label == label && t.IDParent != originalArchiveGroupSubGroupFieldID).Count() > 0)
                            throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' مربوط به گروه اطلاعاتی '{2}' و بایگانی '{3}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveField.Label, archiveTab.Title, Controller.Common.ArchiveController.GetArchiveTitle(dcArchive.Connection.Database)));
                    }
                }
            }
        }

        internal static void CheckSubGroupFieldName(Model.Common.ArchiveCommonDataClassesDataContext dc, List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext, string label, int archiveGroupFieldID)
        {
            Model.Common.ArchiveGroupField archiveGroupField = dc.ArchiveGroupFields.Where(t => t.ID == archiveGroupFieldID).Single();

            if (dc.ArchiveGroupSubGroupFields.Where(t => t.ArchiveGroupFieldID == archiveGroupFieldID && t.Label == label).Count() > 0)
                throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveGroupField.Label));

            foreach (Model.Archive.ArchiveDataClassesDataContext dcArchive in archivesDataContext)
            {
                foreach (var archiveTab in dcArchive.ArchiveTabs.Where(t => t.IDParent == archiveGroupField.ArchiveGroupTabID && t.Deleted == false))
                {
                    foreach (var archiveField in archiveTab.ArchiveFields.Where(t => t.IDParent == archiveGroupFieldID))
                    {
                        if (archiveField.ArchiveSubGroupFields.Where(t => t.Label == label).Count() > 0)
                            throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' مربوط به گروه اطلاعاتی '{2}' و بایگانی '{3}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveField.Label, archiveTab.Title, Controller.Common.ArchiveController.GetArchiveTitle(dcArchive.Connection.Database)));
                    }
                }
            }
        }
    }
}
