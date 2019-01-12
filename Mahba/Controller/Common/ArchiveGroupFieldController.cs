using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    public class ArchiveGroupFieldController
    {
        internal static int AddField(Field field, int archiveGroupTabID, int archiveGroupID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext commonDataContext = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext = new List<Model.Archive.ArchiveDataClassesDataContext>();
            try
            {
                commonDataContext.Connection.Open();
                commonDataContext.Transaction = commonDataContext.Connection.BeginTransaction();

                IEnumerable<string> archivesConnections = Controller.Common.ArchiveGroupTabController.GetArchivesConnectionStrings(archiveGroupTabID);
                foreach (string connectionString in archivesConnections)
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(connectionString);
                    dcArchive.Connection.Open();
                    dcArchive.Transaction = dcArchive.Connection.BeginTransaction();
                    archivesDataContext.Add(dcArchive);
                }

                CheckFieldName(commonDataContext, archivesDataContext, field.Label, archiveGroupTabID);

                Model.Common.ArchiveGroupTab archiveGroupTab = commonDataContext.ArchiveGroupTabs.Where(t => t.ID == archiveGroupTabID).Single();
                int index = 1;
                if (archiveGroupTab.ArchiveGroupFields.Count > 0)
                    index = archiveGroupTab.ArchiveGroupFields.Max(t => t.Index) + 1;
                Model.Common.ArchiveGroupField archiveGroupField = Model.Common.ArchiveGroupField.GetNewInstance(archiveGroupID, archiveGroupTab.ID, field.Label, field.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, index);
                commonDataContext.ArchiveGroupFields.InsertOnSubmit(archiveGroupField);
                commonDataContext.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(commonDataContext, Setting.User.UserOparatesPlaceNames.گروه_بایگانی, Setting.User.UserOparatesNames.ثبت, null, "افزودن فیلد '" + archiveGroupField.Label + "' به گروه اطلاعاتی '" + archiveGroupField.ArchiveGroupTab.Title + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                foreach (var dc in archivesDataContext)
                    Controller.Archive.ArchiveFieldController.AddField(dc, archiveGroupField);

                commonDataContext.Transaction.Commit();
                foreach (var dcArchive in archivesDataContext)
                    dcArchive.Transaction.Commit();

                return archiveGroupField.ID;
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

        internal static void UpdateField(int originalArchiveGroupFieldID, Field field, int archiveGroupTabID, int archiveGroupID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext commonDataContext = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext = new List<Model.Archive.ArchiveDataClassesDataContext>();
            try
            {
                commonDataContext.Connection.Open();
                commonDataContext.Transaction = commonDataContext.Connection.BeginTransaction();

                IEnumerable<string> archivesConnections = Controller.Common.ArchiveGroupTabController.GetArchivesConnectionStrings(archiveGroupTabID);
                foreach (string connectionString in archivesConnections)
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(connectionString);
                    dcArchive.Connection.Open();
                    dcArchive.Transaction = dcArchive.Connection.BeginTransaction();
                    archivesDataContext.Add(dcArchive);
                }

                CheckFieldName(commonDataContext, archivesDataContext, field.Label, archiveGroupTabID, originalArchiveGroupFieldID);

                Model.Common.ArchiveGroupField originalArchiveGroupField = commonDataContext.ArchiveGroupFields.Where(t => t.ID == originalArchiveGroupFieldID).Single();
                string originalLabel = originalArchiveGroupField.Label;
                string originalTabTitle = originalArchiveGroupField.ArchiveGroupTab.Title;

                Model.Common.ArchiveGroupField archiveGroupField = Model.Common.ArchiveGroupField.GetNewInstance(originalArchiveGroupField.ID, archiveGroupID, archiveGroupTabID, field.Label, originalArchiveGroupField.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, originalArchiveGroupField.Index);
                Model.Common.ArchiveGroupField.Copy(originalArchiveGroupField, archiveGroupField);
                commonDataContext.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(commonDataContext, Setting.User.UserOparatesPlaceNames.گروه_بایگانی, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش فیلد '" + originalLabel + "' در گروه اطلاعاتی '" + originalTabTitle + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                foreach (var dc in archivesDataContext)
                    Controller.Archive.ArchiveFieldController.UpdateField(dc, originalArchiveGroupField);

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

        internal static void DeleteField(int archiveGroupFieldID, int archiveGroupTabID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext commonDataContext = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext = new List<Model.Archive.ArchiveDataClassesDataContext>();
            try
            {
                commonDataContext.Connection.Open();
                commonDataContext.Transaction = commonDataContext.Connection.BeginTransaction();

                IEnumerable<string> archivesConnections = Controller.Common.ArchiveGroupTabController.GetArchivesConnectionStrings(archiveGroupTabID);
                foreach (string connectionString in archivesConnections)
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(connectionString);
                    dcArchive.Connection.Open();
                    dcArchive.Transaction = dcArchive.Connection.BeginTransaction();
                    archivesDataContext.Add(dcArchive);
                }

                Model.Common.ArchiveGroupField originalArchiveGroupField = commonDataContext.ArchiveGroupFields.Where(t => t.ID == archiveGroupFieldID).Single();
                string originalLabel = originalArchiveGroupField.Label;
                string originalTabTitle = originalArchiveGroupField.ArchiveGroupTab.Title;

                foreach (var dc in archivesDataContext)
                    Controller.Archive.ArchiveFieldController.DeleteField(dc, originalArchiveGroupField);

                commonDataContext.CounterFieldSettings.DeleteAllOnSubmit(commonDataContext.CounterFieldSettings.Where(t => t.ArchiveGroupFieldID == originalArchiveGroupField.ID));
                commonDataContext.SubmitChanges();

                commonDataContext.ArchiveGroupFields.DeleteOnSubmit(originalArchiveGroupField);
                commonDataContext.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(commonDataContext, Setting.User.UserOparatesPlaceNames.گروه_بایگانی, Setting.User.UserOparatesNames.حذف, null, "حذف فیلد '" + originalLabel + "' از گروه اطلاعاتی '" + originalTabTitle + "'");
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

        internal static Model.Common.ArchiveGroupField GetByID(int id)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.ArchiveGroupFields.Where(t => t.ID == id);
            if (query.Count() == 0)
                return null;
            return query.Single();
        }

        internal static IEnumerable<Field> GetFields(int archiveGroupFieldID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Field> list = new List<Field>();
            foreach (var item in dc.ArchiveGroupSubGroupFields.Where(t => t.ArchiveGroupFieldID == archiveGroupFieldID).OrderBy(t => t.Index))
            {
                list.Add(new Field(item.ID, item.Label, item.FieldName, item.FieldTypeCode, item.FieldType.Title, item.StatusCode, item.FieldStatus.Title, item.BoxTypeCode, item.BoxType.Title, item.AutoComplete, item.MinLength, item.MaxLength, item.MinValue, item.MaxValue, null, item.Index, item.DefaultValue));
            }
            return list;
        }

        internal static void CheckFieldName(Model.Common.ArchiveCommonDataClassesDataContext dc, List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext, string label, int archiveGroupTabID, int originalArchiveGroupFieldID)
        {
            Model.Common.ArchiveGroupTab archiveGroupTab = dc.ArchiveGroupTabs.Where(t => t.ID == archiveGroupTabID).Single();
            if (dc.ArchiveGroupFields.Where(t => t.ID != originalArchiveGroupFieldID && t.ArchiveGroupTabID == archiveGroupTabID && t.Label == label).Count() > 0)
                throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveGroupTab.Title));
            foreach (Model.Archive.ArchiveDataClassesDataContext dcArchive in archivesDataContext)
            {
                foreach (var archiveTab in dcArchive.ArchiveTabs.Where(t => t.IDParent == archiveGroupTabID && t.Deleted == false))
                {
                    if (archiveTab.ArchiveFields.Where(t => t.Label == label && t.IDParent != originalArchiveGroupFieldID).Count() > 0)
                        throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' مربوط به بایگانی '{2}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveTab.Title, Controller.Common.ArchiveController.GetArchiveTitle(dcArchive.Connection.Database)));
                }
            }
        }

        internal static void CheckFieldName(Model.Common.ArchiveCommonDataClassesDataContext dc, List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext, string label, int archiveGroupTabID)
        {
            Model.Common.ArchiveGroupTab archiveGroupTab = dc.ArchiveGroupTabs.Where(t => t.ID == archiveGroupTabID).Single();
            if (dc.ArchiveGroupFields.Where(t => t.ArchiveGroupTabID == archiveGroupTabID && t.Label == label).Count() > 0)
                throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveGroupTab.Title));
            foreach (Model.Archive.ArchiveDataClassesDataContext dcArchive in archivesDataContext)
            {
                foreach (var archiveTab in dcArchive.ArchiveTabs.Where(t => t.IDParent == archiveGroupTabID && t.Deleted == false))
                {
                    if (archiveTab.ArchiveFields.Where(t => t.Label == label).Count() > 0)
                        throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' مربوط به بایگانی '{2}' وجود دارد. لطفا نام دیگری را انتخاب کنید", label, archiveTab.Title, Controller.Common.ArchiveController.GetArchiveTitle(dcArchive.Connection.Database)));
                }
            }
        }

        internal static void UpdateFieldsIndex(Dictionary<int, int> list)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            foreach (var id in list.Keys)
            {
                var item = dc.ArchiveGroupFields.Where(t => t.ID == id).Single();
                item.Index = list[id];
            }
            dc.SubmitChanges();
        }

        internal static string GetArchiveGroupFieldLabel(int archiveGroupFieldID)
        {
            Model.Common.ArchiveGroupField field = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().ArchiveGroupFields.Where(t => t.ID == archiveGroupFieldID).SingleOrDefault();
            return field == null ? "" : field.Label;
        }

        internal static IEnumerable<Model.Common.ArchiveGroupSubGroupField> GetArchiveGroupSubGroupFields(Model.Common.ArchiveCommonDataClassesDataContext dc, int archiveGroupFieldID)
        {
            return dc.ArchiveGroupSubGroupFields.Where(t => t.ArchiveGroupFieldID == archiveGroupFieldID);
        }

        internal static void SetCounterFieldProperties(int archiveGroupFieldID, int fixedValueType, string fixedValue, string separator)
        {
            Model.Common.ArchiveCommonDataClassesDataContext commonDataContext = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContext = new List<Model.Archive.ArchiveDataClassesDataContext>();
            try
            {
                commonDataContext.Connection.Open();
                commonDataContext.Transaction = commonDataContext.Connection.BeginTransaction();
                int archiveGroupTabID = commonDataContext.ArchiveGroupFields.Where(t => t.ID == archiveGroupFieldID).Single().ArchiveGroupTabID;

                IEnumerable<string> archivesConnections = Controller.Common.ArchiveGroupTabController.GetArchivesConnectionStrings(archiveGroupTabID);
                foreach (string connectionString in archivesConnections)
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(connectionString);
                    dcArchive.Connection.Open();
                    dcArchive.Transaction = dcArchive.Connection.BeginTransaction();
                    archivesDataContext.Add(dcArchive);
                }

                if (commonDataContext.CounterFieldSettings.Where(t => t.ArchiveGroupFieldID == archiveGroupFieldID).Count() > 0)
                {
                    Model.Common.CounterFieldSetting obj = commonDataContext.CounterFieldSettings.Where(t => t.ArchiveGroupFieldID == archiveGroupFieldID).Single();
                    obj.FixedValueType = fixedValueType;
                    obj.FixedValue = fixedValue;
                    obj.Separator = separator;
                    commonDataContext.SubmitChanges();
                }
                else
                {
                    Model.Common.CounterFieldSetting obj = Model.Common.CounterFieldSetting.GetNewInstance(archiveGroupFieldID, fixedValueType, fixedValue, separator);
                    commonDataContext.CounterFieldSettings.InsertOnSubmit(obj);
                    commonDataContext.SubmitChanges();
                }

                foreach (var dcArchive in archivesDataContext)
                {
                    int archiveFieldID = dcArchive.ArchiveFields.Where(t => t.IDParent == archiveGroupFieldID).Single().ID;
                    Controller.Archive.ArchiveFieldController.SetCounterFieldProperties(dcArchive, archiveFieldID, fixedValueType, fixedValue, separator);
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

        internal static Model.Common.CounterFieldSetting GetCounterFieldProperties(int fieldID)
        {
            var dc = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
            if (dc.CounterFieldSettings.Where(t => t.ArchiveGroupFieldID == fieldID).Count() > 0)
                return dc.CounterFieldSettings.Where(t => t.ArchiveGroupFieldID == fieldID).Single();
            return null;
        }
    }
}
