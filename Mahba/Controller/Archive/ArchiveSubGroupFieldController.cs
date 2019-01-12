using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class ArchiveSubGroupFieldController
    {
        internal static int AddSubGroupField(Field field, int archiveFieldID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.ArchiveField archiveField = dc.ArchiveFields.Where(t => t.ID == archiveFieldID).Single();
                int index = 1;
                if (archiveField.ArchiveSubGroupFields.Count > 0)
                    index = (archiveField.ArchiveSubGroupFields.Max(t => t.Index) + 1);

                if (FieldNameAlreadyExist(dc, archiveFieldID, field.Label))
                    throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", field.Label, archiveField.Label));

                Model.Archive.ArchiveSubGroupField archiveSubGroupField = Model.Archive.ArchiveSubGroupField.GetNewInstance(archiveFieldID, field.Label, field.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, null, index);
                dc.ArchiveSubGroupFields.InsertOnSubmit(archiveSubGroupField);
                dc.SubmitChanges();

                SqlHelper.CreateFieldForSubGroupField(dc, archiveSubGroupField);

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ثبت, null, "افزودن فیلد '" + archiveSubGroupField.Label + "' به فیلد '" + archiveField.Label + "' در گروه اطلاعاتی '" + archiveField.ArchiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                dc.Transaction.Commit();
                dc.Connection.Close();

                return archiveSubGroupField.ID;
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

        internal static void AddSubGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Common.ArchiveGroupSubGroupField archiveGroupSubGroupField)
        {
            Model.Archive.ArchiveField archiveField = dc.ArchiveFields.Where(t => t.IDParent == archiveGroupSubGroupField.ArchiveGroupFieldID).Single();

            int index = 1;
            if (archiveField.ArchiveSubGroupFields.Count > 0)
                index = (archiveField.ArchiveSubGroupFields.Max(t => t.Index) + 1);

            if (FieldNameAlreadyExist(dc, archiveField.ID, archiveGroupSubGroupField.Label))
                throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", archiveGroupSubGroupField.Label, archiveField.Label));

            Model.Archive.ArchiveSubGroupField archiveSubGroupField = Model.Archive.ArchiveSubGroupField.GetNewInstance(archiveField.ID, archiveGroupSubGroupField.Label, null, archiveGroupSubGroupField.FieldTypeCode, archiveGroupSubGroupField.StatusCode, archiveGroupSubGroupField.BoxTypeCode, archiveGroupSubGroupField.AutoComplete, archiveGroupSubGroupField.MinLength, archiveGroupSubGroupField.MaxLength, archiveGroupSubGroupField.MinValue, archiveGroupSubGroupField.MaxValue, archiveGroupSubGroupField.DefaultValue, archiveGroupSubGroupField.ID, index);
            dc.ArchiveSubGroupFields.InsertOnSubmit(archiveSubGroupField);
            dc.SubmitChanges();

            SqlHelper.CreateFieldForSubGroupField(dc, archiveSubGroupField);

            try
            {
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ثبت, null, "افزودن فیلد '" + archiveSubGroupField.Label + "' به فیلد '" + archiveField.Label + "' در گروه اطلاعاتی '" + archiveField.ArchiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
            }
            catch
            {
                throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
            }
        }

        internal static void UpdateSubGroupField(int originalSubGroupFieldID, Field field)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.ArchiveSubGroupField originalArchiveSubGroupField = dc.ArchiveSubGroupFields.Where(t => t.ID == originalSubGroupFieldID).Single();
                string originalLabel = originalArchiveSubGroupField.Label;
                int originalBoxTypeCode = originalArchiveSubGroupField.BoxTypeCode;
                string originalDefaultValue = originalArchiveSubGroupField.DefaultValue;

                if (FieldNameAlreadyExist(dc, originalArchiveSubGroupField.ArchiveFieldID, field.Label, originalArchiveSubGroupField.ID))
                    throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", field.Label, originalArchiveSubGroupField.ArchiveField.Label));

                Model.Archive.ArchiveSubGroupField archiveSubGroupField = Model.Archive.ArchiveSubGroupField.GetNewInstance(originalArchiveSubGroupField.ID, originalArchiveSubGroupField.ArchiveField.ID, field.Label, originalArchiveSubGroupField.FieldName, field.FieldTypeCode, field.StatusCode, field.BoxTypeCode, field.AutoComplete, field.MinLength, field.MaxLength, field.MinValue, field.MaxValue, field.DefaultValue, originalArchiveSubGroupField.IDParent, originalArchiveSubGroupField.Index);
                Model.Archive.ArchiveSubGroupField.Copy(originalArchiveSubGroupField, archiveSubGroupField);
                dc.SubmitChanges();

                SqlHelper.UpdateGroupField(dc, originalArchiveSubGroupField, (Enums.BoxTypes)originalBoxTypeCode, originalDefaultValue);

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش فیلد '" + originalLabel + "' در فیلد '" + originalArchiveSubGroupField.ArchiveField.Label + "' در گروه اطلاعاتی '" + originalArchiveSubGroupField.ArchiveField.ArchiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
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

        internal static void UpdateSubGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Common.ArchiveGroupSubGroupField archiveGroupSubGroupField)
        {
            Model.Archive.ArchiveSubGroupField originalArchiveSubGroupField = dc.ArchiveSubGroupFields.Where(t => t.IDParent == archiveGroupSubGroupField.ID).Single();
            string originalLabel = originalArchiveSubGroupField.Label;
            int originalBoxTypeCode = originalArchiveSubGroupField.BoxTypeCode;
            string originalDefaultValue = originalArchiveSubGroupField.DefaultValue;

            if (FieldNameAlreadyExist(dc, originalArchiveSubGroupField.ArchiveFieldID, archiveGroupSubGroupField.Label, originalArchiveSubGroupField.ID))
                throw new Exception(string.Format("فیلد '{0}' در زیرگروه جدولی '{1}' وجود دارد. لطفا نام دیگری انتخاب کنید", archiveGroupSubGroupField.Label, originalArchiveSubGroupField.ArchiveField.Label));

            Model.Archive.ArchiveSubGroupField archiveSubGroupField = Model.Archive.ArchiveSubGroupField.GetNewInstance(originalArchiveSubGroupField.ID, originalArchiveSubGroupField.ArchiveField.ID, archiveGroupSubGroupField.Label, originalArchiveSubGroupField.FieldName, archiveGroupSubGroupField.FieldTypeCode, archiveGroupSubGroupField.StatusCode, archiveGroupSubGroupField.BoxTypeCode, archiveGroupSubGroupField.AutoComplete, archiveGroupSubGroupField.MinLength, archiveGroupSubGroupField.MaxLength, archiveGroupSubGroupField.MinValue, archiveGroupSubGroupField.MaxValue, archiveGroupSubGroupField.DefaultValue, originalArchiveSubGroupField.IDParent, originalArchiveSubGroupField.Index);
            Model.Archive.ArchiveSubGroupField.Copy(originalArchiveSubGroupField, archiveSubGroupField);
            dc.SubmitChanges();

            SqlHelper.UpdateGroupField(dc, originalArchiveSubGroupField, (Enums.BoxTypes)originalBoxTypeCode, originalDefaultValue);

            try
            {
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش فیلد '" + originalLabel + "' در فیلد '" + originalArchiveSubGroupField.ArchiveField.Label + "' در گروه اطلاعاتی '" + originalArchiveSubGroupField.ArchiveField.ArchiveTab.Title + "' در بایگانی '" + dc.GetArchive().Title + "'");
            }
            catch
            {
                throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
            }
        }

        internal static void DeleteSubGroupField(int id)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.ArchiveSubGroupField archiveSubGroupField = dc.ArchiveSubGroupFields.Where(t => t.ID == id).Single();
                string originalLabel = archiveSubGroupField.Label;
                string originalArchiveFieldLabel = archiveSubGroupField.ArchiveField.Label;
                string originalArchiveTabTitle = archiveSubGroupField.ArchiveField.ArchiveTab.Title;
                if (archiveSubGroupField.IDParent.HasValue)
                {
                    archiveSubGroupField.IDParent = null;
                    dc.SubmitChanges();
                }
                else
                {
                    SqlHelper.DeleteGroupField(dc, archiveSubGroupField);
                    dc.ArchiveSubGroupFields.DeleteOnSubmit(archiveSubGroupField);
                    dc.SubmitChanges();

                    try
                    {
                        Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.حذف, null, "حذف فیلد '" + originalLabel + "' در فیلد '" + originalArchiveFieldLabel + "' در گروه اطلاعاتی '" + originalArchiveTabTitle + "' در بایگانی '" + dc.GetArchive().Title + "'");
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

        internal static void DeleteSubGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Common.ArchiveGroupSubGroupField archiveGroupSubGroupField)
        {
            Model.Archive.ArchiveSubGroupField archiveSubGroupField = dc.ArchiveSubGroupFields.Where(t => t.IDParent == archiveGroupSubGroupField.ID).Single();
            string originalLabel = archiveSubGroupField.Label;
            string originalArchiveFieldLabel = archiveSubGroupField.ArchiveField.Label;
            string originalArchiveTabTitle = archiveSubGroupField.ArchiveField.ArchiveTab.Title;
            archiveSubGroupField.IDParent = null;
            dc.SubmitChanges();
        }

        private static bool FieldNameAlreadyExist(Model.Archive.ArchiveDataClassesDataContext dc, int archiveFieldID, string label)
        {
            return dc.ArchiveSubGroupFields.Where(t => t.ArchiveFieldID == archiveFieldID && t.Label == label).Count() > 0;
        }

        private static bool FieldNameAlreadyExist(Model.Archive.ArchiveDataClassesDataContext dc, int archiveFieldID, string label, int originalArchiveSubGroupFieldID)
        {
            return dc.ArchiveSubGroupFields.Where(t => t.ArchiveFieldID == archiveFieldID && t.Label == label && t.ID != originalArchiveSubGroupFieldID).Count() > 0;
        }

        internal static List<Model.Archive.ArchiveSubGroupField> GetAllSubGroupFields()
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.ArchiveSubGroupFields.OrderBy(t => t.ArchiveFieldID).ThenBy(t => t.Index).ToList();
        }

        internal static IEnumerable<Field> GetSubGroupFields(string archiveFieldName)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            return GetSubGroupFields(dc.ArchiveFields.Where(t => t.FieldName == archiveFieldName).Single().ID);
        }

        internal static IEnumerable<Field> GetSubGroupFields(int archiveFieldID)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            List<NjitSoftware.Field> fields = new List<Field>();
            foreach (var item in dc.ArchiveSubGroupFields.Where(t => t.ArchiveFieldID == archiveFieldID).OrderBy(t => t.Index))
            {
                fields.Add(new Field(item.ID, item.Label, item.FieldName, item.FieldTypeCode, item.FieldType.Title, item.StatusCode, item.FieldStatus.Title, item.BoxTypeCode, item.BoxType.Title, item.AutoComplete, item.MinLength, item.MaxLength, item.MinValue, item.MaxValue, item.IDParent, item.Index, item.DefaultValue));
            }
            return fields;
        }

        internal static void UpdateSubGroupFieldsIndex(Dictionary<int, int> list)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            foreach (var id in list.Keys)
            {
                var item = dc.ArchiveSubGroupFields.Where(t => t.ID == id).Single();
                item.Index = list[id];
            }
            dc.SubmitChanges();
        }
    }
}
