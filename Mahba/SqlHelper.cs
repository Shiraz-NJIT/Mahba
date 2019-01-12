using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware
{
    class SqlHelper
    {
        internal static string GetSqlType(int fieldTypes)
        {
            switch ((Enums.FieldTypes)fieldTypes)
            {
                case Enums.FieldTypes.متن:
                    return "NVARCHAR (MAX)";
                case Enums.FieldTypes.متن_طولانی:
                    return "NVARCHAR (MAX)";
                case Enums.FieldTypes.متن_طولانی_تک_خطی:
                    return "NVARCHAR (MAX)";
                case Enums.FieldTypes.عدد_صحیح:
                    return "INT";
                case Enums.FieldTypes.عدد_صحیح_بزرگ:
                    return "BIGINT";
                case Enums.FieldTypes.عدد_اعشاری:
                    return "FLOAT";
                case Enums.FieldTypes.عدد_اعشاری_بزرگ:
                    return "DECIMAL(18,5)";
                case Enums.FieldTypes.مقدار_صحیح_و_غلط:
                    return "BIT";
                case Enums.FieldTypes.تاریخ:
                    return "CHAR(10)";
                case Enums.FieldTypes.تاریخ_جاری:
                    return "CHAR(10)";
                case Enums.FieldTypes.ساعت:
                    return "CHAR(5)";
                case Enums.FieldTypes.شماره_موبایل:
                    return "CHAR(11)";
                case Enums.FieldTypes.کد_ملی:
                    return "CHAR(12)";
                case Enums.FieldTypes.زیرگروه_جدولی:
                    throw new Exception();
                case Enums.FieldTypes.پست_الکترونیک:
                    return "NVARCHAR (MAX)";
                case Enums.FieldTypes.مبلغ:
                    return "BIGINT";
                case Enums.FieldTypes.شمارنده:
                    return "NVARCHAR (MAX)";
                case Enums.FieldTypes.شخص_حقیقی:
                    return "INT";
                case Enums.FieldTypes.شخص_حقوقی:
                    return "INT";
                default:
                    throw new Exception();
            }
        }

        internal static string GetSqlFieldStatus(int statusOfFields)
        {
            switch ((Enums.StatusOfFields)statusOfFields)
            {
                case Enums.StatusOfFields.مقدار_بتواند_تهی_باشد:
                    return "NULL";
                case Enums.StatusOfFields.مقدار_نتواند_تهی_باشد:
                    return "NOT NULL";
                case Enums.StatusOfFields.مقدار_یکتا_باشد_و_نتواند_تهی_باشد:
                    return "NOT NULL";
                case Enums.StatusOfFields.مقدار_یکتا_باشد_و_بتواند_تهی_باشد:
                    return "NULL";
                default:
                    throw new Exception();
            }
        }

        internal static void CreateTableForArchiveTab(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveTab archiveTab)
        {
            if (archiveTab.Name.IsNullOrEmpty())
            {
                archiveTab.Name = archiveTab.GetName();
                dc.SubmitChanges();
            }
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
            string query = string.Format("CREATE TABLE [dbo].[{0}] {1}", archiveTab.Name, GetFieldsQueryForArchiveTab(dc, archiveTab));
            da.Execute(query);
            dc.SubmitChanges();
        }

        private static string GetFieldsQueryForArchiveTab(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveTab archiveTab)
        {
            string query = "";
            if (archiveTab.TypeCode == 1)
            {
                query += "(";
                query += "[PersonnelNumber] NVARCHAR (50) NOT NULL,";
                foreach (var field in archiveTab.ArchiveFields)
                {
                    if (field.FieldName.IsNullOrEmpty())
                    {
                        field.FieldName = field.GetName();
                        dc.SubmitChanges();
                    }
                    if (((Enums.FieldTypes)field.FieldTypeCode) != Enums.FieldTypes.زیرگروه_جدولی)
                        query += "[" + field.FieldName + "]" + " " + SqlHelper.GetSqlType(field.FieldTypeCode) + " " + SqlHelper.GetSqlFieldStatus(field.StatusCode) + ",";
                }
                query += "CONSTRAINT [PK_" + archiveTab.Name + "] PRIMARY KEY CLUSTERED ([PersonnelNumber] ASC),";
                query += "CONSTRAINT [FK_" + archiveTab.Name + "_Dossier] FOREIGN KEY ([PersonnelNumber]) REFERENCES [Dossier]([PersonnelNumber]) ON DELETE CASCADE ON UPDATE CASCADE";
                query += ")";
            }
            else
            {
                query += "(";
                query += "[DocumentID] INT NOT NULL,";
                foreach (var field in archiveTab.ArchiveFields)
                {
                    if (field.FieldName.IsNullOrEmpty())
                    {
                        field.FieldName = field.GetName();
                        dc.SubmitChanges();
                    }
                    if (((Enums.FieldTypes)field.FieldTypeCode) != Enums.FieldTypes.زیرگروه_جدولی)
                        query += "[" + field.FieldName + "]" + " " + SqlHelper.GetSqlType(field.FieldTypeCode) + " " + SqlHelper.GetSqlFieldStatus(field.StatusCode) + ",";
                }
                query += "CONSTRAINT [PK_" + archiveTab.Name + "] PRIMARY KEY CLUSTERED ([DocumentID] ASC),";
                query += "CONSTRAINT [FK_" + archiveTab.Name + "_Document] FOREIGN KEY ([DocumentID]) REFERENCES [Document]([ID]) ON DELETE CASCADE ON UPDATE CASCADE";
                query += ")";
            }
            foreach (var field in archiveTab.ArchiveFields)
            {
                if (!string.IsNullOrEmpty(field.DefaultValue))
                    query += string.Format("\r\n" + "ALTER TABLE [dbo].[{0}] ADD  CONSTRAINT [DF_{0}_{1}]  DEFAULT ({2}) FOR [{1}]", archiveTab.Name, field.FieldName, field.IsNumber() ? (field.DefaultValue) : ("'" + field.DefaultValue + "'"));
            }
            return query;
        }

        internal static void CreateTableForGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveField archiveField)
        {
            if (archiveField.FieldName.IsNullOrEmpty())
            {
                archiveField.FieldName = archiveField.GetName();
                dc.SubmitChanges();
            }
            if (archiveField.FieldTypeCode != (int)Enums.FieldTypes.زیرگروه_جدولی)
                throw new Exception();
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
            string query = string.Format("CREATE TABLE [dbo].[{0}] {1}", archiveField.FieldName, GetFieldsQueryForGroupField(dc, archiveField));
            da.Execute(query);
            dc.SubmitChanges();
        }

        private static string GetFieldsQueryForGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveField archiveField)
        {
            Model.Archive.ArchiveTab tab = Controller.Archive.ArchiveTabController.Select(dc, archiveField.ArchiveTabID);
            if (tab.TypeCode == 1)
            {
                string query = "";
                query += "(";
                query += "[ID] INT IDENTITY (1, 1) NOT NULL,";
                query += "[PersonnelNumber] NVARCHAR(50) NOT NULL,";
                query += "CONSTRAINT [PK_" + archiveField.FieldName + "] PRIMARY KEY CLUSTERED ([ID] ASC),";
                query += "CONSTRAINT [FK_" + archiveField.FieldName + "_Dossier] FOREIGN KEY ([PersonnelNumber]) REFERENCES [Dossier]([PersonnelNumber]) ON DELETE CASCADE ON UPDATE CASCADE";
                query += ")";
                return query;
            }
            else
            {
                string query = "";
                query += "(";
                query += "[ID] INT IDENTITY (1, 1) NOT NULL,";
                query += "[DocumentID] INT NOT NULL,";
                query += "CONSTRAINT [PK_" + archiveField.FieldName + "] PRIMARY KEY CLUSTERED ([ID] ASC),";
                query += "CONSTRAINT [FK_" + archiveField.FieldName + "_Document] FOREIGN KEY ([DocumentID]) REFERENCES [Document]([ID]) ON DELETE CASCADE ON UPDATE CASCADE";
                query += ")";
                return query;
            }
        }

        internal static void CreateArchiveField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveField archiveField)
        {
            try
            {
                if (archiveField.ArchiveTab.Name.IsNullOrEmpty())
                {
                    archiveField.ArchiveTab.Name = archiveField.ArchiveTab.GetName();
                    dc.SubmitChanges();
                }
                if (((Enums.FieldTypes)archiveField.FieldTypeCode) != Enums.FieldTypes.زیرگروه_جدولی)
                {
                    Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
                    if (archiveField.FieldName.IsNullOrEmpty())
                    {
                        archiveField.FieldName = archiveField.GetName();
                        dc.SubmitChanges();
                    }
                    string query = string.Format("ALTER TABLE [dbo].[{0}] ADD [{1}] {2} {3} {4};", archiveField.ArchiveTab.Name, archiveField.FieldName, SqlHelper.GetSqlType(archiveField.FieldTypeCode), SqlHelper.GetSqlFieldStatus(archiveField.StatusCode), GetDefaultValueQuery(archiveField));
                    da.Execute(query);
                    if (((Enums.BoxTypes)archiveField.BoxTypeCode) == Enums.BoxTypes.کادر_بازشو)
                        CreateTableForField(dc, archiveField);
                }
                else
                {
                    CreateTableForGroupField(dc, archiveField);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در افزودن فیلد اطلاعاتی '" + archiveField.Label + "'" + "\r\n" + ex.Message);
            }
        }

        private static string GetDefaultValueQuery(Model.Archive.ArchiveField archiveField)
        {
            if (archiveField.FieldTypeCode == (int)Enums.FieldTypes.تاریخ_جاری)
                archiveField.DefaultValue = Njit.Common.PersianCalendar.GetDate(DateTime.Now);
            if (archiveField.FieldTypeCode == (int)Enums.FieldTypes.مقدار_صحیح_و_غلط)
                archiveField.DefaultValue = "TRUE";
            if (archiveField.DefaultValue.IsNullOrEmpty())
                return "";
            return string.Format("CONSTRAINT DF_{0}_{1} DEFAULT {2}", archiveField.ArchiveTab.Name, archiveField.FieldName, archiveField.IsNumber() ? archiveField.DefaultValue : "'" + archiveField.DefaultValue + "'");
        }

        private static void CreateTableForField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveField archiveField)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
            string query = string.Format("CREATE TABLE [dbo].[{0}] {1}", archiveField.FieldName, GetFieldsQueryForField(dc, archiveField.FieldName));
            da.Execute(query);
            dc.SubmitChanges();
        }

        private static void CreateTableForField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveSubGroupField archiveField)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
            string query = string.Format("CREATE TABLE [dbo].[{0}] {1}", archiveField.FieldName, GetFieldsQueryForField(dc, archiveField.FieldName));
            da.Execute(query);
            dc.SubmitChanges();
        }

        private static string GetFieldsQueryForField(Model.Archive.ArchiveDataClassesDataContext dc, string archiveFieldName)
        {
            string query = "";
            query += "(";
            query += "[ID] INT IDENTITY (1, 1) NOT NULL,";
            query += "[Title] NVARCHAR(MAX) NOT NULL,";
            query += "CONSTRAINT [PK_" + archiveFieldName + "] PRIMARY KEY CLUSTERED ([ID] ASC)";
            query += ")";
            return query;
        }

        internal static void UpdateArchiveField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveField archiveField, Enums.BoxTypes oldBoxType, string oldDefaultValue)
        {
            try
            {
                if (archiveField.ArchiveTab.Name.IsNullOrEmpty())
                {
                    archiveField.ArchiveTab.Name = archiveField.ArchiveTab.GetName();
                    dc.SubmitChanges();
                }
                if (((Enums.FieldTypes)archiveField.FieldTypeCode) != Enums.FieldTypes.زیرگروه_جدولی)
                {
                    Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
                    if (archiveField.FieldName.IsNullOrEmpty())
                    {
                        archiveField.FieldName = archiveField.GetName();
                        dc.SubmitChanges();
                    }
                    if (!oldDefaultValue.IsNullOrEmpty())
                    {
                        string defaultValueQuery = string.Format("ALTER TABLE [dbo].[{0}] DROP CONSTRAINT DF_{0}_{1}", archiveField.ArchiveTab.Name, archiveField.FieldName);
                        da.Execute(defaultValueQuery);
                    }
                    string query = string.Format("ALTER TABLE [dbo].[{0}] ALTER COLUMN [{1}] {2} {3}", archiveField.ArchiveTab.Name, archiveField.FieldName, SqlHelper.GetSqlType(archiveField.FieldTypeCode), SqlHelper.GetSqlFieldStatus(archiveField.StatusCode));
                    da.Execute(query);
                    if (!archiveField.DefaultValue.IsNullOrEmpty())
                    {
                        string defaultValueQuery = string.Format("ALTER TABLE [dbo].[{0}] ADD CONSTRAINT DF_{0}_{1} DEFAULT {2} FOR [{1}]", archiveField.ArchiveTab.Name, archiveField.FieldName, archiveField.IsNumber() ? archiveField.DefaultValue : "'" + archiveField.DefaultValue + "'");
                        da.Execute(defaultValueQuery);
                    }
                    if (oldBoxType == Enums.BoxTypes.کادر_بازشو)
                    {
                        if (((Enums.BoxTypes)archiveField.BoxTypeCode) != Enums.BoxTypes.کادر_بازشو)
                        {
                            string dropQuery = string.Format("DROP TABLE [dbo].[{0}]", archiveField.FieldName);
                            da.Execute(dropQuery);
                        }
                    }
                    else
                    {
                        if (((Enums.BoxTypes)archiveField.BoxTypeCode) == Enums.BoxTypes.کادر_بازشو)
                        {
                            CreateTableForField(dc, archiveField);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در تغییر نوع فیلد اطلاعاتی '" + archiveField.Label + "'" + "\r\n" + ex.Message);
            }
        }

        internal static void UpdateGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveSubGroupField archiveSubGroupField, Enums.BoxTypes oldBoxType, string oldDefaultValue)
        {
            try
            {
                Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);

                if (!oldDefaultValue.IsNullOrEmpty())
                {
                    string defaultValueQuery = string.Format("ALTER TABLE [dbo].[{0}] DROP CONSTRAINT DF_{0}_{1}", archiveSubGroupField.ArchiveField.FieldName, archiveSubGroupField.FieldName);
                    da.Execute(defaultValueQuery);
                }

                string query = string.Format("ALTER TABLE [dbo].[{0}] ALTER COLUMN [{1}] {2} {3}", archiveSubGroupField.ArchiveField.FieldName, archiveSubGroupField.FieldName, SqlHelper.GetSqlType(archiveSubGroupField.FieldTypeCode), SqlHelper.GetSqlFieldStatus(archiveSubGroupField.StatusCode));
                da.Execute(query);

                if (!archiveSubGroupField.DefaultValue.IsNullOrEmpty())
                {
                    string defaultValueQuery = string.Format("ALTER TABLE [dbo].[{0}] ADD CONSTRAINT DF_{0}_{1} DEFAULT {2} FOR [{1}]", archiveSubGroupField.ArchiveField.FieldName, archiveSubGroupField.FieldName, archiveSubGroupField.IsNumber() ? archiveSubGroupField.DefaultValue : "'" + archiveSubGroupField.DefaultValue + "'");
                    da.Execute(defaultValueQuery);
                }

                if (oldBoxType == Enums.BoxTypes.کادر_بازشو)
                {
                    if (((Enums.BoxTypes)archiveSubGroupField.BoxTypeCode) != Enums.BoxTypes.کادر_بازشو)
                    {
                        string dropQuery = string.Format("DROP TABLE [dbo].[{0}]", archiveSubGroupField.FieldName);
                        da.Execute(dropQuery);
                    }
                }
                else
                {
                    if (((Enums.BoxTypes)archiveSubGroupField.BoxTypeCode) == Enums.BoxTypes.کادر_بازشو)
                    {
                        CreateTableForField(dc, archiveSubGroupField);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در تغییر نوع فیلد اطلاعاتی '" + archiveSubGroupField.Label + "'" + "\r\n" + ex.Message);
            }
        }

        internal static void DeleteArchiveField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveField archiveField)
        {
            try
            {
                Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
                if (((Enums.FieldTypes)archiveField.FieldTypeCode) != Enums.FieldTypes.زیرگروه_جدولی)
                {
                    if (!archiveField.DefaultValue.IsNullOrEmpty())
                    {
                        string defaultValueQuery = string.Format("ALTER TABLE [dbo].[{0}] DROP CONSTRAINT DF_{0}_{1}", archiveField.ArchiveTab.Name, archiveField.FieldName);
                        da.Execute(defaultValueQuery);
                    }
                    string fieldQuery = string.Format("ALTER TABLE [dbo].[{0}] DROP COLUMN [{1}]", archiveField.ArchiveTab.Name, archiveField.FieldName);
                    da.Execute(fieldQuery);
                    if (((Enums.BoxTypes)archiveField.BoxTypeCode) == Enums.BoxTypes.کادر_بازشو)
                    {
                        string fieldTableQuery = string.Format("DROP TABLE [dbo].[{0}]", archiveField.FieldName);
                        da.Execute(fieldTableQuery);
                    }
                }
                else
                {
                    string tableQuery = string.Format("DROP TABLE [dbo].[{0}]", archiveField.FieldName);
                    da.Execute(tableQuery);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در حذف فیلد اطلاعاتی '" + archiveField.Label + "'" + "\r\n" + ex.Message);
            }
        }

        internal static void DeleteGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveSubGroupField archiveSubGroupField)
        {
            try
            {
                Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);

                if (!archiveSubGroupField.DefaultValue.IsNullOrEmpty())
                {
                    string defaultValueQuery = string.Format("ALTER TABLE [dbo].[{0}] DROP CONSTRAINT DF_{0}_{1}", archiveSubGroupField.ArchiveField.FieldName, archiveSubGroupField.FieldName);
                    da.Execute(defaultValueQuery);
                }

                string fieldQuery = string.Format("ALTER TABLE [dbo].[{0}] DROP COLUMN [{1}]", archiveSubGroupField.ArchiveField.FieldName, archiveSubGroupField.FieldName);
                da.Execute(fieldQuery);

                if (((Enums.BoxTypes)archiveSubGroupField.BoxTypeCode) == Enums.BoxTypes.کادر_بازشو)
                {
                    string fieldTableQuery = string.Format("DROP TABLE [dbo].[{0}]", archiveSubGroupField.FieldName);
                    da.Execute(fieldTableQuery);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در حذف فیلد اطلاعاتی '" + archiveSubGroupField.Label + "'" + "\r\n" + ex.Message);
            }
        }

        internal static void CreateFieldForSubGroupField(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ArchiveSubGroupField archiveSubGroupField)
        {
            try
            {
                if (archiveSubGroupField.FieldName.IsNullOrEmpty())
                    archiveSubGroupField.FieldName = archiveSubGroupField.GetName();
                dc.SubmitChanges();

                Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
                string query = string.Format("ALTER TABLE [dbo].[{0}] ADD [{1}] {2} {3} {4};", archiveSubGroupField.ArchiveField.FieldName, archiveSubGroupField.FieldName, SqlHelper.GetSqlType(archiveSubGroupField.FieldTypeCode), SqlHelper.GetSqlFieldStatus(archiveSubGroupField.StatusCode), GetDefaultValueQuery(archiveSubGroupField));
                da.Execute(query);
                if (((Enums.BoxTypes)archiveSubGroupField.BoxTypeCode) == Enums.BoxTypes.کادر_بازشو)
                    CreateTableForField(dc, archiveSubGroupField);


            }
            catch (Exception ex)
            {
                throw new Exception("خطا در افزودن فیلد اطلاعاتی '" + archiveSubGroupField.Label + "'" + "\r\n" + ex.Message);
            }
        }

        private static object GetDefaultValueQuery(Model.Archive.ArchiveSubGroupField archiveSubGroupField)
        {
            if (archiveSubGroupField.DefaultValue.IsNullOrEmpty())
                return "";
            return string.Format("CONSTRAINT DF_{0}_{1} DEFAULT {2}", archiveSubGroupField.ArchiveField.FieldName, archiveSubGroupField.FieldName, archiveSubGroupField.IsNumber() ? archiveSubGroupField.DefaultValue : "'" + archiveSubGroupField.DefaultValue + "'");
        }

        internal static void CreateArchive(Model.Common.ArchiveCommonDataClassesDataContext dc, Model.Common.Archive originalArchive, string path)
        {
            string scriptFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Scripts\\Archive.sql");
            if (!System.IO.File.Exists(scriptFilePath))
                throw new Exception("فایل زیر پیدا نشد" + "\r\n" + scriptFilePath);

            originalArchive.Name = GetNewArchiveName(dc);
            dc.SubmitChanges();

            try
            {
                Njit.Sql.DatabaseHelper dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
                dbHelper.CreateDatabase(originalArchive.Name, path);
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ایجاد پایگاه داده" + "\r\n" + ex.Message);
            }
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection.ConnectionString);
            try
            {
                da.Connection.Open();
                da.Connection.ChangeDatabase(originalArchive.Name);
                string scriptFileContent = System.IO.File.ReadAllText(scriptFilePath);
                Njit.Sql.SqlHelper.RunQuery(scriptFileContent, da);

                string archiveUpdatesPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DatabaseUpdates\\ArchiveDatabase");
                if (!System.IO.Directory.Exists(archiveUpdatesPath))
                {
                    try
                    { System.IO.Directory.CreateDirectory(archiveUpdatesPath); }
                    catch (Exception)
                    { return; }
                }
                using (Njit.Program.Forms.DatabseUpdatesInstaller form = new Njit.Program.Forms.DatabseUpdatesInstaller(Setting.Sql.ThisProgram.GetDatabaseConnection(originalArchive.Name).ConnectionString, archiveUpdatesPath, "sql", true))
                    form.ShowDialog();
            }
            catch
            {
                Njit.Sql.DatabaseHelper dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
                dbHelper.DropDatabase(originalArchive.Name);
                throw;
            }
            finally
            {
                if ((da.Connection.State & System.Data.ConnectionState.Open) == System.Data.ConnectionState.Open)
                    da.Connection.Close();
            }
        }

        internal static string GetNewArchiveName(Model.Common.ArchiveCommonDataClassesDataContext dc)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
            string[] databases = dc.GetDatabaseList();
            int index = 1;
            string name = "Archive" + index.ToString();
            do
            {
                if (databases.Contains(name))
                {
                    index++;
                    name = "Archive" + index.ToString();
                }
                else
                    break;
            }
            while (true);
            return name;
        }
        internal static object GetArchiveFieldValueFoDocument2(string archiveTabName, string archiveFieldName, int DocumentID)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            return da.ExecuteScalar(string.Format("SELECT [{0}] FROM [{1}] WHERE [DocumentID]=@p", archiveFieldName, archiveTabName), "@p", DocumentID);
        }
        internal static object GetArchiveFieldValue(string archiveTabName, string archiveFieldName, string personnelNumber)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            return da.ExecuteScalar(string.Format("SELECT [{0}] FROM [{1}] WHERE [PersonnelNumber]=@p", archiveFieldName, archiveTabName), "@p", personnelNumber);
        }
        internal static DataTable GetListShomareName(string personnelNumber)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string query = string.Format("SELECT DocumentID ,Field7  FROM [Document2] JOIN [Document]  ON [Document2].DocumentID = [Document].ID  where [Document].PersonnelNumber ='{0}'", personnelNumber);
            return da.GetData(query);
        }
        internal static DataTable GetArchiveFieldValue(string archiveTabName, string personnelnumberr, string Field1, string Field2, string Field15)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string query = string.Format("SELECT {0},{1},{2},{3} FROM [{4}] ", personnelnumberr, Field1, Field2, Field15, archiveTabName);
            return da.GetData(query);
        }
        //internal static object GetDocUmentFails(int ArchiveId, string archiveFieldName, string personnelNumber)
        //{
        //    Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
        //    return da.ExecuteScalar(string.Format("SELECT [{0}] FROM [{1}] WHERE [PersonnelNumber]=@p", archiveFieldName, archiveTabName), "@p", personnelNumber);
        //}
        internal static DataTable GetLendingList(List<Model.Archive.ArchiveField> displayFields)
        {
            if (displayFields == null)
                return null;
            if (displayFields.Count == 0)
                return null;
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string query = string.Format("SELECT dbo.Lending.ID, dbo.Lending.PersonnelNumber AS [{0}],{1}" + ", dbo.Person.Name AS [امانت گیرنده], dbo.Lending.Intention AS [قصد امانت], dbo.Lending.Date AS [تاریخ], dbo.Lending.Time AS [ساعت], dbo.Lending.DurationDay AS [مدت روز امانت], dbo.Lending.DurationHour AS [مدت ساعت امانت], dbo.Lending.ReturnDate AS [تاریخ بازگشت],dbo.Lending.ReturnTime AS [ساعت بازگشت], dbo.Lending.RealDurationDay AS [مدت روز امانت برده شده], dbo.Lending.RealDurationHour AS [مدت ساعت امانت برده شده] "
                + "FROM dbo.Lending INNER JOIN "
                + "dbo.Person ON dbo.Lending.PersonID = dbo.Person.ID INNER JOIN "
                + "dbo.Dossier ON dbo.Lending.PersonnelNumber = dbo.Dossier.PersonnelNumber LEFT OUTER JOIN {2}"
                , Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label
                , displayFields.Select(t => "dbo.[" + t.ArchiveTab.Name + "].[" + t.FieldName + "] AS [" + t.Label + "]").Aggregate((a, b) => a + "," + b)
                , displayFields.Where(t => t.ArchiveTab.TypeCode == 1).Select(t => "dbo.[" + t.ArchiveTab.Name + "] ON dbo.Dossier.PersonnelNumber = dbo.[" + t.ArchiveTab.Name + "].PersonnelNumber").Distinct().Aggregate((a, b) => a + " LEFT OUTER JOIN " + b));
            return da.GetData(query);
        }
        //internal static DataTable GetLendingList()
        //{
        //    Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
        //    string query = string.Format("SELECT dbo.Lending.ID, dbo.Lending.PersonnelNumber AS [{0}]," + ", dbo.Person.Name AS [امانت گیرنده], dbo.Lending.Intention AS [قصد امانت], dbo.Lending.Date AS [تاریخ], dbo.Lending.Time AS [ساعت], dbo.Lending.DurationDay AS [مدت روز امانت], dbo.Lending.DurationHour AS [مدت ساعت امانت], dbo.Lending.ReturnDate AS [تاریخ بازگشت],dbo.Lending.ReturnTime AS [ساعت بازگشت], dbo.Lending.RealDurationDay AS [مدت روز امانت برده شده], dbo.Lending.RealDurationHour AS [مدت ساعت امانت برده شده] "
        //        + "FROM dbo.Lending INNER JOIN "
        //        + "dbo.Person ON dbo.Lending.PersonID = dbo.Person.ID INNER JOIN "
        //        + "dbo.Dossier ON dbo.Lending.PersonnelNumber = dbo.Dossier.PersonnelNumber ");

        //    return da.GetData(query);
        //}

        internal static DataTable GetDossierList(List<Model.Archive.ArchiveField> displayFields, params SearchField[] searchFields)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            List<Model.Archive.ArchiveTab> tabList = new List<Model.Archive.ArchiveTab>(); //Controller.Archive.ArchiveTabController.SelectAll();
            foreach (var tab in displayFields.Select(t => t.ArchiveTab).Distinct())
                tabList.Add(tab);
            if (searchFields != null && searchFields.Length > 0)
                AddTabToList(tabList, searchFields.ToList());
            string query = string.Format("SELECT dbo.Dossier.PersonnelNumber AS [{0}],{1} FROM dbo.Dossier LEFT OUTER JOIN {2}"
                , Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label
                , displayFields.Select(t => "dbo.[" + t.ArchiveTab.Name + "].[" + t.FieldName + "] AS [" + t.Label + "]").Aggregate((a, b) => a + "," + b)
                , tabList.Select(t => "dbo.[" + t.Name + "] ON dbo.Dossier.PersonnelNumber = dbo.[" + t.Name + "].PersonnelNumber").Distinct().Aggregate((a, b) => a + " LEFT OUTER JOIN " + b));
            if (searchFields != null && searchFields.Length > 0)
            {
                if (searchFields[0].Relation != SearchField.Relations.None)
                    searchFields[0].Relation = SearchField.Relations.None;
                string whereQuery = GetWhereQuery(searchFields);
                query += string.Format(" WHERE {0}", whereQuery);// searchFields.Select(t => "(" + t.SearchQuery + ")").Aggregate((a, b) => a + " " + b));
            }
            return da.GetData(query);
        }

        private static string GetWhereQuery(SearchField[] searchFields)
        {
            string s = "";
            foreach (SearchField item in searchFields)
            {
                s += item.RelationQuery + " (" + item.SearchQueryWithoutRelation + (item.SearchFields == null ? "" : GetWhereQuery(item.SearchFields.ToArray())) + ")";
            }
            return s;
        }

        private static void AddTabToList(List<Model.Archive.ArchiveTab> tabList, List<SearchField> searchFields)
        {
            foreach (var field in searchFields)
            {
                if (!tabList.Contains(field.Field.ArchiveTab))
                    tabList.Add(field.Field.ArchiveTab);
                if (field.SearchFields != null)
                    AddTabToList(tabList, field.SearchFields);
            }
        }

        internal static bool FieldHaveData(string tableName, string fieldName, object value, string originalPersonnelNumber)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string query = string.Format("SELECT [" + fieldName + "] From [" + tableName + "] Where [" + fieldName + "]=@Value AND PersonnelNumber !=@PersonnelNumber");
            DataTable _DataTable = da.GetData(query, "@Value", value, "@PersonnelNumber", originalPersonnelNumber);
            if (_DataTable.Rows.Count == 0)
                return false;
            else
                return true;
        }
        internal static DataTable LendingListNotBacked(string tableName, string fieldName)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string query = string.Format("SELECT * From [" + tableName + "] Where [" + fieldName + "] IS  NULL");
            return da.GetData(query);

        }
        internal static int InsertDossier1(string PersonnelNumber, string Name, string Family, string NN)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string query = "INSERT INTO Dossier1 (PersonnelNumber, Field1,Field2,Field15)" +
"VALUES (N'" + PersonnelNumber + "', N'" + Name + "',  N'" + Family + "', N'" + NN + "')";
            return da.Execute(query);

        }
        internal static int UpdateDossier1(string PersonnelNumber, string Field, object value)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string query = string.Format(" UPDATE Dossier1 SET {0} = N'{1}' WHERE [PersonnelNumber] = N'{2}'", Field, value, PersonnelNumber);
            return da.Execute(query);

        }

        internal static string[] GetAllFieldValues(string TableName, string FieldName)
        {
            try
            {
                Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                DataTable _DataTable = da.GetData("SELECT [" + FieldName + "] From [" + TableName + "]");
                return _DataTable.AsEnumerable().Select(x => x[FieldName].ToString()).ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        internal static IEnumerable<Model.Archive.Document> GetDocumentList(string personnelNumber, params SearchField[] searchFields)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            List<Model.Archive.ArchiveTab> tabList = new List<Model.Archive.ArchiveTab>();
            string query;
            if (searchFields != null && searchFields.Length > 0)
            {
                AddTabToList(tabList, searchFields.ToList());
                query = string.Format("SELECT * FROM [dbo].[Document] LEFT OUTER JOIN {0}"
                    , tabList.Select(t => "dbo.[" + t.Name + "] ON dbo.Document.ID = dbo.[" + t.Name + "].DocumentID").Distinct().Aggregate((a, b) => a + " LEFT OUTER JOIN " + b));

                if (searchFields[0].Relation != SearchField.Relations.None)
                    searchFields[0].Relation = SearchField.Relations.None;
                string whereQuery = GetWhereQuery(searchFields);
                query += string.Format(" WHERE [dbo].[Document].[PersonnelNumber]=N'{0}' AND ({1})", personnelNumber, whereQuery);
            }
            else
                query = "SELECT * FROM [dbo].[Document]";
            return dc.ExecuteQuery<Model.Archive.Document>(query).ToArray();
        }

        internal static DataTable GetDocumentList(List<Model.Archive.ArchiveField> displayFields, params SearchField[] searchFields)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            List<Model.Archive.ArchiveTab> tabList = new List<Model.Archive.ArchiveTab>();
            foreach (var tab in displayFields.Select(t => t.ArchiveTab).Distinct())
                tabList.Add(tab);
            if (searchFields != null && searchFields.Length > 0)
                AddTabToList(tabList, searchFields.ToList());
            string query = string.Format("SELECT dbo.Document.PersonnelNumber AS [{0}],{1} FROM dbo.Document LEFT OUTER JOIN {2}"
                , Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label
                , displayFields.Select(t => "dbo.[" + t.ArchiveTab.Name + "].[" + t.FieldName + "] AS [" + t.Label + "]").Aggregate((a, b) => a + "," + b)
                , tabList.Select(t => "dbo.[" + t.Name + "] ON dbo.Document.ID = dbo.[" + t.Name + "].DocumentID").Distinct().Aggregate((a, b) => a + " LEFT OUTER JOIN " + b));
            if (searchFields != null && searchFields.Length > 0)
            {
                if (searchFields[0].Relation != SearchField.Relations.None)
                    searchFields[0].Relation = SearchField.Relations.None;
                string whereQuery = GetWhereQuery(searchFields);
                query += string.Format(" WHERE {0}", whereQuery);// searchFields.Select(t => "(" + t.SearchQuery + ")").Aggregate((a, b) => a + " " + b));
            }
            return da.GetData(query);
        }
        internal static List<System.Data.SqlClient.SqlCommand> GetDossier1InsertCommands(List<Dossier1> listdossier1, Model.Archive.ArchiveTab archiveTab, string personnelNumber)
        {
            List<Model.Archive.ArchiveField> fieldsOfCurrentTab = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
            List<System.Data.SqlClient.SqlCommand> sqlCommandList = new List<System.Data.SqlClient.SqlCommand>();
            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
            sqlCommand.CommandText = string.Format("INSERT INTO dbo.[{0}] ( ", archiveTab.Name);
            string values = " VALUES (";
            SetDossierSqlCommandParameter(sqlCommand, ref values, "PersonnelNumber", personnelNumber, typeof(string));

            foreach (Model.Archive.ArchiveField field in fieldsOfCurrentTab)
            {
                if (listdossier1.Any(q => q.Name == field.FieldName))
                    SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, listdossier1.FirstOrDefault(q => q.Name == field.FieldName).Value, SqlHelper.GetFieldType(field));
                else
                    SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, "", SqlHelper.GetFieldType(field));
            }
            sqlCommand.CommandText += " ) " + values + " ) ";
            sqlCommandList.Add(sqlCommand);
            return sqlCommandList;
        }

        internal static List<System.Data.SqlClient.SqlCommand> GetDossierInsertCommands(System.Windows.Forms.Control tabPage, Model.Archive.ArchiveTab archiveTab, string personnelNumber)
        {
            List<Model.Archive.ArchiveField> fieldsOfCurrentTab = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
            List<System.Data.SqlClient.SqlCommand> sqlCommandList = new List<System.Data.SqlClient.SqlCommand>();
            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
            sqlCommand.CommandText = string.Format("INSERT INTO dbo.[{0}] ( ", archiveTab.Name);
            string values = " VALUES (";
            bool addFirstParameter = true;
            SetDossierSqlCommandParameter(sqlCommand, ref values, "PersonnelNumber", personnelNumber, typeof(string));

            foreach (Model.Archive.ArchiveField field in fieldsOfCurrentTab)
            {
                switch (field.BoxTypeCode)
                {
                    case (int)Enums.BoxTypes.کادر_انتخاب:
                        CheckBox _CheckBox = tabPage.Controls[field.FieldName] as CheckBox;
                        SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, _CheckBox.Checked.ToString(), SqlHelper.GetFieldType(field));
                        addFirstParameter = false;
                        break;

                    case (int)Enums.BoxTypes.کادر_بازشو:
                        Njit.Program.Controls.ComboBoxExtended _ComboBoxExtended = tabPage.Controls[field.FieldName] as Njit.Program.Controls.ComboBoxExtended;
                        SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, _ComboBoxExtended.Text, SqlHelper.GetFieldType(field));
                        addFirstParameter = false;
                        break;

                    case (int)Enums.BoxTypes.کادر_متن:
                        Njit.Program.Controls.TextBoxExtended textBoxExtended = tabPage.Controls[field.FieldName] as Njit.Program.Controls.TextBoxExtended;
                        SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, textBoxExtended.AutoSeparateDigits ? textBoxExtended.TextWithoutComma : textBoxExtended.Text, SqlHelper.GetFieldType(field));
                        addFirstParameter = false;
                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی:
                        GroupBox groupBox = tabPage.Controls[field.FieldName] as GroupBox;
                        Njit.Program.Controls.DataGridViewExtended dataGridView = groupBox.Controls[field.FieldName] as Njit.Program.Controls.DataGridViewExtended;
                        if (dataGridView.RowCount > 1)
                        {
                            for (int i = 0; i < dataGridView.RowCount - 1; i++)
                            {
                                System.Data.SqlClient.SqlCommand sqlCommandTemp = new System.Data.SqlClient.SqlCommand();
                                sqlCommandTemp.CommandText = string.Format("INSERT INTO dbo.[{0}] ( ", field.FieldName);
                                string valuesTemp = " VALUES (";
                                bool firstParameterTemp = true;

                                DataGridViewRow row = dataGridView.Rows[i];
                                SetDossierSqlCommandParameter(sqlCommandTemp, ref valuesTemp, "PersonnelNumber", personnelNumber, typeof(string));

                                foreach (Model.Archive.ArchiveSubGroupField CurrentSubField in Controller.Archive.DossierCacheController.GetSubGroupFields(field.ID))
                                {
                                    if (CurrentSubField.FieldTypeCode == (int)Enums.FieldTypes.شخص_حقیقی || CurrentSubField.FieldTypeCode == (int)Enums.FieldTypes.شخص_حقوقی)
                                    {
                                        var cell = row.Cells[CurrentSubField.FieldName] as Njit.Program.DataGridViewColumn.NjitComboBoxCell;
                                        string value = cell.SelectedValue.IsNullOrEmpty() ? null : cell.SelectedValue.ToString();
                                        if (value == null)
                                            value = "-1";
                                        SetDossierSqlCommandParameter(sqlCommandTemp, ref valuesTemp, CurrentSubField.FieldName, value, SqlHelper.GetFieldType((Enums.FieldTypes)CurrentSubField.FieldTypeCode));
                                    }
                                    else
                                    {
                                        SetDossierSqlCommandParameter(sqlCommandTemp, ref valuesTemp, CurrentSubField.FieldName, row.Cells[CurrentSubField.FieldName].Value.IsNullOrEmpty() ? null : (((row.Cells[CurrentSubField.FieldName].OwningColumn is Njit.Program.DataGridViewColumn.NjitTextBoxColumn) && ((row.Cells[CurrentSubField.FieldName].OwningColumn as Njit.Program.DataGridViewColumn.NjitTextBoxColumn).TextBoxExtended.AutoSeparateDigits)) ? row.Cells[CurrentSubField.FieldName].Value.ToString().Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), "") : row.Cells[CurrentSubField.FieldName].Value.ToString()), SqlHelper.GetFieldType((Enums.FieldTypes)CurrentSubField.FieldTypeCode));
                                    }
                                    firstParameterTemp = false;
                                }
                                sqlCommandTemp.CommandText += " ) " + valuesTemp + " ) ";
                                if (!firstParameterTemp)
                                    sqlCommandList.Add(sqlCommandTemp);
                            }
                        }

                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_تاریخ:
                        Njit.Program.Controls.DateControl _DateControl = tabPage.Controls[field.FieldName] as Njit.Program.Controls.DateControl;
                        SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, _DateControl.Text, SqlHelper.GetFieldType(field));
                        addFirstParameter = false;
                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_ساعت:
                        Njit.Program.Controls.TimeControl _TimeControl = tabPage.Controls[field.FieldName] as Njit.Program.Controls.TimeControl;
                        SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, _TimeControl.Text, SqlHelper.GetFieldType(field));
                        addFirstParameter = false;
                        break;
                    case (int)Enums.BoxTypes.کادر_انتخاب_اشخاص:
                        Njit.Program.Controls.ComboBoxExtended personComboBoxExtended = tabPage.Controls[field.FieldName] as Njit.Program.Controls.ComboBoxExtended;
                        string cmbValue = personComboBoxExtended.SelectedValue == null ? null : personComboBoxExtended.SelectedValue.ToString();
                        if (cmbValue == null)
                            cmbValue = "-1";
                        SetDossierSqlCommandParameter(sqlCommand, ref values, field.FieldName, cmbValue, SqlHelper.GetFieldType(field));
                        addFirstParameter = false;
                        break;
                }
            }
            sqlCommand.CommandText += " ) " + values + " ) ";
            if (!addFirstParameter)
                sqlCommandList.Add(sqlCommand);
            return sqlCommandList;
        }

        internal static List<System.Data.SqlClient.SqlCommand> GetDocumentInsertCommands(System.Windows.Forms.Panel panel, Model.Archive.ArchiveTab archiveTab, Model.Archive.Document document, string personnelNumber)
        {
            List<Model.Archive.ArchiveField> fields = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
            List<System.Data.SqlClient.SqlCommand> sqlCommands = new List<System.Data.SqlClient.SqlCommand>();
            System.Data.SqlClient.SqlCommand _SqlCommand = new System.Data.SqlClient.SqlCommand();
            _SqlCommand.CommandText = string.Format("INSERT INTO dbo.[{0}] ( ", archiveTab.Name);
            string values = " VALUES (";
            bool AddFirstParameter = true;
            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, "DocumentID", document.ID);

            foreach (Model.Archive.ArchiveField field in fields)
            {
                switch (field.BoxTypeCode)
                {
                    case (int)Enums.BoxTypes.کادر_انتخاب:
                        CheckBox _CheckBox = panel.Controls[field.FieldName] as CheckBox;
                        SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _CheckBox.Checked.ToString());
                        AddFirstParameter = false;
                        break;

                    case (int)Enums.BoxTypes.کادر_بازشو:
                        if (field.FieldName == "Field10")
                        {

                            AutoCompleteTextBoxSample3.AutoCompleteTextbox3 _TextBoxAutoExtended = panel.Controls[field.FieldName] as AutoCompleteTextBoxSample3.AutoCompleteTextbox3;
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _TextBoxAutoExtended.Text);
                            AddFirstParameter = false;
                        }
                        else if (field.FieldName == "Field12")
                        {
                            AutoCompleteTextBoxSample3.AutoCompleteTextbox3 _TextBoxAutoExtended = panel.Controls[field.FieldName] as AutoCompleteTextBoxSample3.AutoCompleteTextbox3;
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _TextBoxAutoExtended.Text);
                            AddFirstParameter = false;
                        }
                        else if (field.FieldName == "Field14")
                        {
                            AutoCompleteTextBoxSample3.AutoCompleteTextbox3 _TextBoxAutoExtended = panel.Controls[field.FieldName] as AutoCompleteTextBoxSample3.AutoCompleteTextbox3;
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _TextBoxAutoExtended.Text);
                            AddFirstParameter = false;
                        }
                        else
                        {
                            Njit.Program.Controls.ComboBoxExtended _ComboBoxExtended = panel.Controls[field.FieldName] as Njit.Program.Controls.ComboBoxExtended;
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _ComboBoxExtended.Text);
                            AddFirstParameter = false;
                        }
                        break;

                    case (int)Enums.BoxTypes.کادر_متن:
                        if (field.FieldName == "Field5")
                        {
                            AutoCompleteTextBoxSample3.AutoCompleteTextbox3 _TextBoxAutoExtended = panel.Controls[field.FieldName] as AutoCompleteTextBoxSample3.AutoCompleteTextbox3;
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _TextBoxAutoExtended.Text);
                            AddFirstParameter = false;
                            break;
                        }
                        if (field.FieldName == "Field7")
                        {
                            AutoCompleteTextBoxSample.AutoCompleteTextbox _TextBoxAutoExtended = panel.Controls[field.FieldName] as AutoCompleteTextBoxSample.AutoCompleteTextbox;
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _TextBoxAutoExtended.Text);
                            AddFirstParameter = false;
                            break;
                        }
                        if (field.FieldName == "Field6")
                        {
                            AutoCompleteTextBoxSample3.AutoCompleteTextbox3 _TextBoxAutoExtended = panel.Controls[field.FieldName] as AutoCompleteTextBoxSample3.AutoCompleteTextbox3;
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _TextBoxAutoExtended.Text);
                            AddFirstParameter = false;
                            break;
                        }
                        if (field.FieldName == "Field16")
                        {

                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, Setting.User.ThisProgram.LoadedUserSetting.UserCode);
                            AddFirstParameter = false;
                            break;
                        }
                        Njit.Program.Controls.TextBoxExtended _TextBoxExtended = panel.Controls[field.FieldName] as Njit.Program.Controls.TextBoxExtended;
                        Type type = GetFieldType(field);
                        object convertedValue = _TextBoxExtended.Text;
                        Njit.Common.PublicMethods.ConvertValue(_TextBoxExtended.Text, ref convertedValue, type);
                        SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, convertedValue);
                        AddFirstParameter = false;
                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی:
                        GroupBox _GroupBox = panel.Controls[field.FieldName] as GroupBox;
                        Njit.Program.Controls.DataGridViewExtended _DataGridView = _GroupBox.Controls[field.FieldName] as Njit.Program.Controls.DataGridViewExtended;
                        if (_DataGridView.RowCount > 1)
                        {
                            for (int i = 0; i < _DataGridView.RowCount - 1; i++)
                            {
                                System.Data.SqlClient.SqlCommand SqlCommandTemp = new System.Data.SqlClient.SqlCommand();
                                SqlCommandTemp.CommandText = string.Format("INSERT INTO dbo.[{0}] ( ", field.FieldName);
                                string ValueCommandTemp = " VALUES (";
                                bool FirstParameterTemp = true;

                                DataGridViewRow Dr = _DataGridView.Rows[i];
                                SetDocumnetSqlCommandParameter(SqlCommandTemp, ref ValueCommandTemp, "DocumentID", document.ID);

                                foreach (Model.Archive.ArchiveSubGroupField CurrentSubField in Controller.Archive.DossierCacheController.GetSubGroupFields(field.ID))
                                {
                                    if (!Dr.Cells[CurrentSubField.FieldName].Value.IsNullOrEmpty())
                                    {
                                        SetDocumnetSqlCommandParameter(SqlCommandTemp, ref ValueCommandTemp, CurrentSubField.FieldName, Dr.Cells[CurrentSubField.FieldName].Value);
                                        FirstParameterTemp = false;
                                    }
                                }
                                SqlCommandTemp.CommandText += " ) " + ValueCommandTemp + " ) ";
                                if (!FirstParameterTemp)
                                    sqlCommands.Add(SqlCommandTemp);
                            }
                        }

                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_تاریخ:
                        Njit.Program.Controls.DateControl _DateControl = panel.Controls[field.FieldName] as Njit.Program.Controls.DateControl;
                        if (field.FieldName == "Field17")
                            SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _DateControl.Text.Substring(0,10)+" " + System.DateTime.Now.ToShortTimeString());
                        else
                        SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _DateControl.Text);
                        AddFirstParameter = false;
                        break;

                    case (int)Enums.BoxTypes.کادر_ورود_ساعت:
                        Njit.Program.Controls.TimeControl _TimeControl = panel.Controls[field.FieldName] as Njit.Program.Controls.TimeControl;
                        SetDocumnetSqlCommandParameter(_SqlCommand, ref values, field.FieldName, _TimeControl.Text);
                        AddFirstParameter = false;
                        break;
                }
            }
            _SqlCommand.CommandText += " ) " + values + " ) ";
            if (!AddFirstParameter)
                sqlCommands.Add(_SqlCommand);
            return sqlCommands;
        }

        public static Type GetFieldType(Enums.FieldTypes fieldType)
        {
            switch (fieldType)
            {
                case Enums.FieldTypes.متن:
                    return typeof(string);
                case Enums.FieldTypes.متن_طولانی:
                    return typeof(string);
                case Enums.FieldTypes.متن_طولانی_تک_خطی:
                    return typeof(string);
                case Enums.FieldTypes.عدد_صحیح:
                    return typeof(int);
                case Enums.FieldTypes.عدد_صحیح_بزرگ:
                    return typeof(long);
                case Enums.FieldTypes.عدد_اعشاری:
                    return typeof(double);
                case Enums.FieldTypes.عدد_اعشاری_بزرگ:
                    return typeof(decimal);
                case Enums.FieldTypes.مقدار_صحیح_و_غلط:
                    return typeof(bool);
                case Enums.FieldTypes.تاریخ:
                    return typeof(string);
                case Enums.FieldTypes.تاریخ_جاری:
                    return typeof(string);
                case Enums.FieldTypes.ساعت:
                    return typeof(string);
                case Enums.FieldTypes.شماره_موبایل:
                    return typeof(string);
                case Enums.FieldTypes.کد_ملی:
                    return typeof(string);
                case Enums.FieldTypes.پست_الکترونیک:
                    return typeof(string);
                case Enums.FieldTypes.زیرگروه_جدولی:
                    throw new Exception();
                case Enums.FieldTypes.شمارنده:
                    return typeof(string);
                case Enums.FieldTypes.مبلغ:
                    return typeof(long);
                case Enums.FieldTypes.شخص_حقیقی:
                    return typeof(int);
                case Enums.FieldTypes.شخص_حقوقی:
                    return typeof(int);
                default:
                    throw new Exception();
            }
        }
        public static Type GetFieldType(Model.Archive.ArchiveField field)
        {
            return GetFieldType((Enums.FieldTypes)field.FieldTypeCode);
        }

        private static void SetDocumnetSqlCommandParameter(System.Data.SqlClient.SqlCommand sqlCommand, ref string values, string fieldName, object value)
        {
            if (!value.IsNullOrEmpty())
            {
                if (fieldName != "DocumentID")
                {
                    sqlCommand.CommandText += " , ";
                    values += " , ";
                }
                sqlCommand.CommandText += "[" + fieldName + "] ";
                values += string.Format("@{0}", fieldName);
                sqlCommand.Parameters.AddWithValue(string.Format("@{0}", fieldName), value);
            }
        }

        private static void SetDossierSqlCommandParameter(System.Data.SqlClient.SqlCommand sqlCommand, ref string values, string fieldName, string value, Type fieldType)
        {
            if (fieldName != "PersonnelNumber")
            {
                sqlCommand.CommandText += " , ";
                values += " , ";
            }
            sqlCommand.CommandText += "[" + fieldName + "] ";
            values += string.Format("@{0}", fieldName);
            object convertedValue = value;
            if (Njit.Common.PublicMethods.ConvertValue(value, ref convertedValue, fieldType))
                sqlCommand.Parameters.AddWithValue(string.Format("@{0}", fieldName), convertedValue);
            else
                sqlCommand.Parameters.AddWithValue(string.Format("@{0}", fieldName), value.IsNullOrEmpty() ? DBNull.Value : (object)value);
        }

        public static System.Data.SqlClient.SqlCommand GetDeleteCommandForArchiveTab(Model.Archive.ArchiveTab archiveTab, string personnelNumber)
        {
            return new System.Data.SqlClient.SqlCommand(string.Format("DELETE FROM [{0}] WHERE [PersonnelNumber] = N'{1}'", archiveTab.Name, personnelNumber));
        }

        public static System.Data.SqlClient.SqlCommand GetDeleteCommandForArchiveTab(Model.Archive.ArchiveTab archiveTab, int DocumentID)
        {
            return new System.Data.SqlClient.SqlCommand(string.Format("DELETE FROM [{0}] WHERE [DocumentID] = {1}", archiveTab.Name, DocumentID));
        }

        internal static System.Data.SqlClient.SqlCommand GetDeleteCommandForArchiveField(Model.Archive.ArchiveField field, string personnelNumber)
        {
            return new System.Data.SqlClient.SqlCommand(string.Format("DELETE FROM [{0}] WHERE [PersonnelNumber] = N'{1}'", field.FieldName, personnelNumber));
        }

        internal static System.Data.SqlClient.SqlCommand GetDeleteCommandForArchiveField(Model.Archive.ArchiveField field, int documentID)
        {
            return new System.Data.SqlClient.SqlCommand(string.Format("DELETE FROM [{0}] WHERE [DocumentID] = {1}", field.FieldName, documentID));
        }

        public static DataTable GetData(string tableName, string personnelNumber)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string Query = string.Format("SELECT * From dbo.{0} WHERE PersonnelNumber=@PersonnelNumber", tableName);
            return da.GetData(Query, "@PersonnelNumber", personnelNumber);
        }

        public static DataTable GetDocuments(string tableName, Model.Archive.Document document)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string Query = string.Format("SELECT * From dbo.{0} WHERE DocumentID={1}", tableName, document.ID);
            return da.GetData(Query);
        }
        public static DataTable GetDocuments(string tableName, int documenId)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string Query = string.Format("SELECT * From dbo.{0} WHERE ID={1}", tableName, documenId);
            return da.GetData(Query);
        }
        public static DataTable GetDocumentsForFailures(string tableName, int documenId)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string Query = string.Format("SELECT * From dbo.{0} WHERE DocumentID={1}", tableName, documenId);
            return da.GetData(Query);
        }
        public static DataTable GetField(string tableName)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string Query = string.Format("SELECT * From dbo.{0} ", tableName);
            return da.GetData(Query);
        }
        public static DataTable GetDocuments(string tableName)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            string Query = string.Format("SELECT * From dbo.{0}", tableName);
            return da.GetData(Query);
        }
        internal static string CreateArchiveDocumnetDatabase(Model.Common.ArchiveCommonDataClassesDataContext dc, string path)
        {
            string scriptFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Scripts\\ArchiveDocument.sql");
            if (!System.IO.File.Exists(scriptFilePath))
                throw new Exception("فایل زیر پیدا نشد" + "\r\n" + scriptFilePath);
            string databaseName = Controller.ArchiveDocument.ArchiveDocumentController.GetNewArchiveDocumentDatabaseName(dc);
            try
            {
                Njit.Sql.DatabaseHelper dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
                dbHelper.CreateDatabase(databaseName, path);
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ایجاد پایگاه داده" + "\r\n" + ex.Message);
            }
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection.ConnectionString);
            try
            {
                da.Connection.Open();
                da.Connection.ChangeDatabase(databaseName);
                string scriptFileContent = System.IO.File.ReadAllText(scriptFilePath);
                Njit.Sql.SqlHelper.RunQuery(scriptFileContent, da);
            }
            catch
            {
                Njit.Sql.DatabaseHelper dbHelper = new Njit.Sql.DatabaseHelper(dc.Connection.ConnectionString);
                dbHelper.DropDatabase(databaseName);
                throw;
            }
            finally
            {
                if ((da.Connection.State & System.Data.ConnectionState.Open) == System.Data.ConnectionState.Open)
                    da.Connection.Close();
            }
            return databaseName;
        }

        internal static long? GetMaxNumber(string table, string field)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            object obj = da.ExecuteScalar(string.Format("SELECT MAX([{0}]) FROM [{1}]", field, table));
            if (obj.IsNullOrEmpty())
                return null;
            else
                return long.Parse(obj.ToString());
        }

        internal static string GetNewValueOfCounterFiled(Model.Archive.ArchiveField field, Model.Archive.CounterFieldSetting counterFieldSetting)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            DataTable dataTable = da.GetData(string.Format("SELECT [{0}] FROM [{1}]", field.FieldName, field.ArchiveTab.Name));
            if (dataTable.Rows.Count == 0)
            {
                if (field.DefaultValue.IsNullOrEmpty())
                    return GetNewValueOfCounterFiled(counterFieldSetting, "1");
                else
                    return field.DefaultValue;
            }
            string[] data = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
                data[i] = dataTable.Rows[i][0].ToString();
            long? lastValue = GetLastValue(data, GetFixedValuePart(counterFieldSetting), counterFieldSetting.Separator);
            if (lastValue.HasValue == false)
                return GetNewValueOfCounterFiled(counterFieldSetting, "1");
            string newValue = GetNewValueOfCounterFiled(counterFieldSetting, (lastValue.Value + 1).ToString());
            return newValue;
        }

        private static string GetFixedValuePart(Model.Archive.CounterFieldSetting counterFieldSetting)
        {
            switch ((Enums.FixedValueTypes)counterFieldSetting.FixedValueType)
            {
                case NjitSoftware.Enums.FixedValueTypes.CurrentYear:
                    return Njit.Common.PersianCalendar.GetYear(DateTime.Now).ToString().Substring(2, 2);
                case NjitSoftware.Enums.FixedValueTypes.UseCustomFixedValue:
                    return (counterFieldSetting.FixedValue ?? "");
                case NjitSoftware.Enums.FixedValueTypes.WithoutFixedValue:
                    return "";
                default:
                    throw new Exception();
            }
        }

        private static string GetFixedValuePart(string value, string separator)
        {
            string[] arr = value.Split(new string[] { separator }, StringSplitOptions.None);
            return arr[0];
        }

        private static string GetVariableValuePart(string value, string separator)
        {
            string[] arr = value.Split(new string[] { separator }, StringSplitOptions.None);
            if (arr.Length == 2)
                return arr[1];
            else
                return arr[0];
        }

        private static long? GetLastValue(string[] data, string fixedValuePart, string separator)
        {
            string[] query;
            if (fixedValuePart.IsNullOrEmpty())
                query = data;
            else
                query = data.Where(t => GetFixedValuePart(t, separator) == fixedValuePart).ToArray();
            if (query.Count() == 0)
                return null;
            long[] codes = new long[query.Count()];
            for (int i = 0; i < query.Length; i++)
            {
                string[] arr = query[i].ToString().Split(new string[] { separator }, StringSplitOptions.None);
                if (arr.Length == 2)
                    codes[i] = long.Parse(arr[1]);
                else
                    codes[i] = long.Parse(arr[0]);
            }
            return codes.Max();
        }

        private static string GetNewValueOfCounterFiled(Model.Archive.CounterFieldSetting counterFieldSetting, string value)
        {
            switch ((Enums.FixedValueTypes)counterFieldSetting.FixedValueType)
            {
                case NjitSoftware.Enums.FixedValueTypes.CurrentYear:
                    return Njit.Common.PersianCalendar.GetYear(DateTime.Now).ToString().Substring(2, 2) + counterFieldSetting.Separator + value;
                case NjitSoftware.Enums.FixedValueTypes.UseCustomFixedValue:
                    return (counterFieldSetting.FixedValue ?? "") + counterFieldSetting.Separator + value;
                case NjitSoftware.Enums.FixedValueTypes.WithoutFixedValue:
                    return value;
                default:
                    throw new Exception();
            }
        }

        internal static void ChangePersonnelNumber(string originalPersonnelNumber, string newPersonnelNumber)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
            if (((int)da.ExecuteScalar("SELECT COUNT(PersonnelNumber) FROM [Dossier] WHERE [PersonnelNumber]=@newPersonnelNumber AND [PersonnelNumber]!=@originalPersonnelNumber", "@newPersonnelNumber", newPersonnelNumber, "@originalPersonnelNumber", originalPersonnelNumber)) > 0)
                throw new Exception("شماره " + newPersonnelNumber + " تکراری است");
            da.Execute("UPDATE [Dossier] SET [PersonnelNumber]=@newPersonnelNumber WHERE [PersonnelNumber]=@originalPersonnelNumber", "@newPersonnelNumber", newPersonnelNumber, "@originalPersonnelNumber", originalPersonnelNumber);

        }
    }
}
