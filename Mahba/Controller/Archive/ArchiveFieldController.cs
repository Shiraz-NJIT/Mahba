using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class ArchiveFieldController
    {
        internal static int AddField(Field field, int archiveTabID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.ArchiveTab archiveTab = dc.ArchiveTabs.Where(t => t.ID == archiveTabID).Single();

                if (ArchiveFieldController.FieldNameAlreadyExist(dc, archiveTabID, field.Label))
                    throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", field.Label, archiveTab.Title));

                if (archiveTab.Exist == false)
                {
                    SqlHelper.CreateTableForArchiveTab(dc, archiveTab);
                    archiveTab.Exist = true;
                    dc.SubmitChanges();
                }

                int index = 1;
                if (archiveTab.ArchiveFields.Count > 0)
                    index = archiveTab.ArchiveFields.Max(t => t.Index) + 1;
                Model.Archive.ArchiveField archiveField = Model.Archive.ArchiveField.GetNewInstance(archiveTab.ID, field.Label, field.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, null, index);
                dc.ArchiveFields.InsertOnSubmit(archiveField);
                dc.SubmitChanges();

                SqlHelper.CreateArchiveField(dc, archiveField);

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ثبت, null, "افزودن فیلد '" + archiveField.Label + "' به گروه اطلاعاتی '" + archiveField.ArchiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                dc.Transaction.Commit();
                dc.Connection.Close();
                return archiveField.ID;
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
            finally
            {
                if (dc.Connection.State == System.Data.ConnectionState.Open)
                    dc.Connection.Close();
            }
        }

        internal static void AddField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Common.ArchiveGroupField archiveGroupField)
        {
            Model.Archive.ArchiveTab archiveTab = dc.ArchiveTabs.Where(t => t.IDParent == archiveGroupField.ArchiveGroupTabID).Single();

            if (ArchiveFieldController.FieldNameAlreadyExist(dc, archiveTab.ID, archiveGroupField.Label))
                throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", archiveGroupField.Label, archiveTab.Title));

            if (archiveTab.Exist == false)
            {
                SqlHelper.CreateTableForArchiveTab(dc, archiveTab);
                archiveTab.Exist = true;
                dc.SubmitChanges();
            }

            int index = 1;
            var q = dc.ArchiveFields.Where(t => t.ArchiveTabID == archiveTab.ID).Select(t => t.Index);
            if (q.Count() > 0)
                index = (q.Max() + 1);
            Model.Archive.ArchiveField archiveField = Model.Archive.ArchiveField.GetNewInstance(archiveTab.ID, archiveGroupField.Label, null, archiveGroupField.FieldTypeCode, archiveGroupField.StatusCode, archiveGroupField.BoxTypeCode, archiveGroupField.AutoComplete, archiveGroupField.MinLength, archiveGroupField.MaxLength, archiveGroupField.MinValue, archiveGroupField.MaxValue, archiveGroupField.DefaultValue, archiveGroupField.ID, index);
            dc.ArchiveFields.InsertOnSubmit(archiveField);
            dc.SubmitChanges();

            SqlHelper.CreateArchiveField(dc, archiveField);

            try
            {
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ثبت, null, "افزودن فیلد '" + archiveField.Label + "' به گروه اطلاعاتی '" + archiveField.ArchiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
            }
            catch
            {
                throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
            }
        }

        internal static void UpdateField(int originalArchiveFieldID, Field field)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.ArchiveField originalArchiveField = dc.ArchiveFields.Where(t => t.ID == originalArchiveFieldID).Single();
                string originalLabel = originalArchiveField.Label;
                string originalTabTitle = originalArchiveField.ArchiveTab.Title;
                int originalBoxTypeCode = originalArchiveField.BoxTypeCode;
                string originalDefaultValue = originalArchiveField.DefaultValue;

                if (ArchiveFieldController.FieldNameAlreadyExist(dc, originalArchiveField.ArchiveTabID, field.Label, originalArchiveFieldID))
                    throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", field.Label, originalArchiveField.ArchiveTab.Title));

                Model.Archive.ArchiveField archiveField = Model.Archive.ArchiveField.GetNewInstance(originalArchiveField.ID, originalArchiveField.ArchiveTabID, field.Label, originalArchiveField.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, originalArchiveField.IDParent, originalArchiveField.Index);
                Model.Archive.ArchiveField.Copy(originalArchiveField, archiveField);
                dc.SubmitChanges();

                SqlHelper.UpdateArchiveField(dc, originalArchiveField, (Enums.BoxTypes)originalBoxTypeCode, originalDefaultValue);

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش فیلد '" + originalLabel + "' در گروه اطلاعاتی '" + originalTabTitle + "' در بایگانی '" + dc.GetArchive().Title + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
            finally
            {
                if (dc.Connection.State == System.Data.ConnectionState.Open)
                    dc.Connection.Close();
            }
        }

        internal static void UpdateField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Common.ArchiveGroupField archiveGroupField)
        {
            Model.Archive.ArchiveField originalArchiveField = dc.ArchiveFields.Where(t => t.IDParent == archiveGroupField.ID).Single();
            string originalLabel = originalArchiveField.Label;
            string originalTabTitle = originalArchiveField.ArchiveTab.Title;
            int originalBoxTypeCode = originalArchiveField.BoxTypeCode;
            string originalDefaultValue = originalArchiveField.DefaultValue;
            Model.Archive.ArchiveTab archiveTab = dc.ArchiveTabs.Where(t => t.ID == originalArchiveField.ArchiveTabID).Single();

            if (ArchiveFieldController.FieldNameAlreadyExist(dc, archiveTab.ID, archiveGroupField.Label, originalArchiveField.ID))
                throw new Exception(string.Format("فیلد '{0}' در گروه اطلاعاتی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", archiveGroupField.Label, archiveTab.Title));

            Model.Archive.ArchiveField archiveField = Model.Archive.ArchiveField.GetNewInstance(originalArchiveField.ID, archiveTab.ID, archiveGroupField.Label, originalArchiveField.FieldName, archiveGroupField.FieldTypeCode, archiveGroupField.StatusCode, archiveGroupField.BoxTypeCode, archiveGroupField.AutoComplete, archiveGroupField.MinLength, archiveGroupField.MaxLength, archiveGroupField.MinValue, archiveGroupField.MaxValue, archiveGroupField.DefaultValue, archiveGroupField.ID, originalArchiveField.Index);
            Model.Archive.ArchiveField.Copy(originalArchiveField, archiveField);
            dc.SubmitChanges();

            try
            {
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش فیلد '" + originalLabel + "' در گروه اطلاعاتی '" + originalTabTitle + "' در بایگانی '" + dc.GetArchive().Title + "'");
            }
            catch
            {
                throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
            }

            SqlHelper.UpdateArchiveField(dc, originalArchiveField, (Enums.BoxTypes)originalBoxTypeCode, originalDefaultValue);
        }

        internal static void DeleteField(int archiveFieldID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.ArchiveField originalArchiveField = dc.ArchiveFields.Where(t => t.ID == archiveFieldID).Single();
                string originalLabel = originalArchiveField.Label;
                string originalTabTitle = originalArchiveField.ArchiveTab.Title;
                if (originalArchiveField.IDParent.HasValue)
                {
                    originalArchiveField.IDParent = null;
                    dc.SubmitChanges();
                    foreach (var item in dc.ArchiveSubGroupFields.Where(t => t.ArchiveFieldID == originalArchiveField.ID))
                    {
                        item.IDParent = null;
                    }
                    dc.SubmitChanges();
                }
                else
                {
                    SqlHelper.DeleteArchiveField(dc, originalArchiveField);

                    dc.ArchiveSubGroupFields.DeleteAllOnSubmit(originalArchiveField.ArchiveSubGroupFields);
                    dc.SubmitChanges();

                    dc.CounterFieldSettings.DeleteAllOnSubmit(originalArchiveField.CounterFieldSettings);
                    dc.SubmitChanges();

                    dc.ArchiveFields.DeleteOnSubmit(originalArchiveField);
                    dc.SubmitChanges();

                    try
                    {
                        Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.حذف, null, "حذف فیلد '" + originalLabel + "' در گروه اطلاعاتی '" + originalTabTitle + "' در بایگانی '" + dc.GetArchive().Title + "'");
                    }
                    catch
                    {
                        throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                    }
                }

                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
            finally
            {
                if (dc.Connection.State == System.Data.ConnectionState.Open)
                    dc.Connection.Close();
            }
        }

        internal static void DeleteField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Common.ArchiveGroupField archiveGroupField)
        {
            Model.Archive.ArchiveField originalArchiveField = dc.ArchiveFields.Where(t => t.IDParent == archiveGroupField.ID).Single();
            string originalLabel = originalArchiveField.Label;
            string originalTabTitle = originalArchiveField.ArchiveTab.Title;
            if (originalArchiveField.IDParent.HasValue)
            {
                originalArchiveField.IDParent = null;
                dc.SubmitChanges();
                foreach (var item in dc.ArchiveSubGroupFields.Where(t => t.ArchiveFieldID == originalArchiveField.ID))
                {
                    item.IDParent = null;
                }
                dc.SubmitChanges();
                Model.Common.CounterFieldSetting archiveGroupFieldCounterSetting = Controller.Common.ArchiveGroupFieldController.GetCounterFieldProperties(archiveGroupField.ID);
                if (archiveGroupFieldCounterSetting != null)
                {
                    Controller.Archive.ArchiveFieldController.SetCounterFieldProperties(dc, originalArchiveField.ID, archiveGroupFieldCounterSetting.FixedValueType, archiveGroupFieldCounterSetting.FixedValue, archiveGroupFieldCounterSetting.Separator);
                }
            }
            else
            {
                SqlHelper.DeleteArchiveField(dc, originalArchiveField);

                dc.ArchiveSubGroupFields.DeleteAllOnSubmit(originalArchiveField.ArchiveSubGroupFields);
                dc.SubmitChanges();

                dc.CounterFieldSettings.DeleteAllOnSubmit(originalArchiveField.CounterFieldSettings);
                dc.SubmitChanges();

                dc.ArchiveFields.DeleteOnSubmit(originalArchiveField);
                dc.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.حذف, null, "حذف فیلد '" + originalLabel + "' در گروه اطلاعاتی '" + originalTabTitle + "' در بایگانی '" + dc.GetArchive().Title + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
            }
        }

        internal static bool FieldNameAlreadyExist(Model.Archive.ArchiveDataClassesDataContext dc, int archiveTabID, string label)
        {
            return dc.ArchiveFields.Where(t => t.ArchiveTabID == archiveTabID && t.Label == label).Count() > 0;
        }

        internal static bool FieldNameAlreadyExist(Model.Archive.ArchiveDataClassesDataContext dc, int archiveTabID, string label, int originalArchiveFieldID)
        {
            return dc.ArchiveFields.Where(t => t.ID != originalArchiveFieldID && t.ArchiveTabID == archiveTabID && t.Label == label).Count() > 0;
        }

        internal static List<Model.Archive.ArchiveField> GetAllArchiveFields()
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Select(t => t).OrderBy(t => t.ArchiveTabID).ThenBy(t => t.Index).ToList();
        }

        internal static List<Model.Archive.ArchiveField> GetDossierArchiveFieldsThahIsNotSubGroup()
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Where(t => t.ArchiveTab.TypeCode == 1 && t.FieldTypeCode != (int)Enums.FieldTypes.زیرگروه_جدولی).Select(t => t).OrderBy(t => t.ArchiveTabID).ThenBy(t => t.Index).ToList();
        }

        internal static List<Model.Archive.ArchiveField> GetDocumentArchiveFieldsThahIsNotSubGroup()
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Where(t => t.ArchiveTab.TypeCode == 2 && t.FieldTypeCode != (int)Enums.FieldTypes.زیرگروه_جدولی).Select(t => t).OrderBy(t => t.ArchiveTabID).ThenBy(t => t.Index).ToList();
        }

        internal static List<Model.Archive.ArchiveField> GetDocumentArchiveFieldsThahIsNotSubGroup(Model.Archive.ArchiveTab tab)
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Where(t => t.ArchiveTab.TypeCode == 2 && t.FieldTypeCode != (int)Enums.FieldTypes.زیرگروه_جدولی && t.ArchiveTabID == tab.ID).Select(t => t).OrderBy(t => t.ArchiveTabID).ThenBy(t => t.Index).ToList();
        }

        internal static List<Model.Archive.ArchiveField> GetArchiveFields(Model.Archive.ArchiveTab tab)
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Where(t => t.ArchiveTabID == tab.ID).Select(t => t).OrderBy(t => t.Index).ToList();
        }

        internal static List<Model.Archive.ArchiveField> GetArchiveFieldsThahIsNotSubGroup(Model.Archive.ArchiveTab tab)
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Where(t => t.ArchiveTabID == tab.ID && t.FieldTypeCode != (int)Enums.FieldTypes.زیرگروه_جدولی).Select(t => t).OrderBy(t => t.Index).ToList();
        }

        internal static void UpdateFieldsIndex(Dictionary<int, int> list)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            foreach (var id in list.Keys)
            {
                var item = dc.ArchiveFields.Where(t => t.ID == id).Single();
                item.Index = list[id];
            }
            dc.SubmitChanges();
        }

        internal static string GetArchiveFieldLabel(int archiveFieldID)
        {
            Model.Archive.ArchiveField field = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Where(t => t.ID == archiveFieldID).SingleOrDefault();
            return field == null ? "" : field.Label;
        }
        internal static Model.Archive.ArchiveField GetArchive(int archiveFieldID)
        {
            Model.Archive.ArchiveField field = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().ArchiveFields.Where(t => t.ID == archiveFieldID).SingleOrDefault();
            return field;
        }
        internal static object GetFieldValue(Model.Archive.ArchiveField archiveField, string personnelNumber)
        {
            return SqlHelper.GetArchiveFieldValue(archiveField.ArchiveTab.Name, archiveField.FieldName, personnelNumber);
        }

        internal static void SetCounterFieldProperties(Model.Archive.ArchiveDataClassesDataContext dc, int archiveFieldID, int fixedValueType, string fixedValue, string separator)
        {
            if (dc.CounterFieldSettings.Where(t => t.ArchiveFieldID == archiveFieldID).Count() > 0)
            {
                Model.Archive.CounterFieldSetting obj = dc.CounterFieldSettings.Where(t => t.ArchiveFieldID == archiveFieldID).Single();
                obj.FixedValueType = fixedValueType;
                obj.FixedValue = fixedValue;
                obj.Separator = separator;
                dc.SubmitChanges();
            }
            else
            {
                Model.Archive.CounterFieldSetting obj = Model.Archive.CounterFieldSetting.GetNewInstance(archiveFieldID, fixedValueType, fixedValue, separator);
                dc.CounterFieldSettings.InsertOnSubmit(obj);
                dc.SubmitChanges();
            }
        }

        internal static void SetCounterFieldProperties(int archiveFieldID, int fixedValueType, string fixedValue, string separator)
        {
            SetCounterFieldProperties(Model.Archive.ArchiveDataClassesDataContext.GetNewInstance(), archiveFieldID, fixedValueType, fixedValue, separator);
        }

        internal static Model.Archive.CounterFieldSetting GetCounterFieldProperties(int archiveFieldID)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            if (dc.CounterFieldSettings.Where(t => t.ArchiveFieldID == archiveFieldID).Count() > 0)
                return dc.CounterFieldSettings.Where(t => t.ArchiveFieldID == archiveFieldID).Single();
            return null;
        }
    }
}
