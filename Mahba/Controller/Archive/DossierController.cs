using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class DossierController
    {
        public static Model.Archive.Dossier Select(string PersonnelNumber)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.Dossiers.Where(t => t.PersonnelNumber == PersonnelNumber).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static List<Model.Archive.Dossier> GetAllDossiers()
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.Dossiers.Select(t => t).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static string[] GetAllPersonnelNumbers()
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Dossiers.Select(t => t.PersonnelNumber).ToArray();
        }
        public static List<string> GetAllPersonnelNumbers2()
        {
            string[] Name = new string[] {"محمد","حسن","حسین","محسن" };
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return Name.ToList();
        }
        public static bool CheckExistPersonnelNumber(string PersonnelNumber)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.Dossiers.Where(t => t.PersonnelNumber == PersonnelNumber).Count() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }
        public static Model.Archive.Dossier Get(string PersonnelNumber)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.Dossiers.Where(t => t.PersonnelNumber == PersonnelNumber).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }
      
        public static void Insret(Model.Archive.Dossier dossier, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            try
            {
                dc.Dossiers.InsertOnSubmit(dossier);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        public static void Update(Model.Archive.Dossier dossier, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            try
            {
                Model.Archive.Dossier.Copy(dc.Dossiers.Where(t => t.PersonnelNumber == dossier.PersonnelNumber).Single(), dossier);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در بروزرسانی اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        public static void Insert(Model.Archive.Dossier dossier, List<System.Data.SqlClient.SqlCommand> sqlCommands,
            List<Model.Archive.ContactView> contactView, List<Model.Archive.AddressView> addressView, Model.Archive.Info info)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Controller.Archive.DossierController.Insret(dossier, dc);
                //------------
                foreach (System.Data.SqlClient.SqlCommand sqlCommand in sqlCommands)
                {
                    sqlCommand.Connection = dc.Connection as System.Data.SqlClient.SqlConnection;
                    sqlCommand.Transaction = dc.Transaction as System.Data.SqlClient.SqlTransaction;
                    sqlCommand.ExecuteNonQuery();
                }
                //------------ اطلاعات تماس و آدرس
                Controller.Archive.InfoController.Insert(info, dc);
                Controller.Archive.AddressController.Insert(addressView, dc);
                Controller.Archive.ContactController.Insert(contactView, dc);
                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.پرونده, Setting.User.UserOparatesNames.ثبت, null, "ثبت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + dossier.PersonnelNumber);
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
                dc.Transaction.Commit();
            }
            catch
            {
                dc.Transaction.Rollback();
                throw;
            }
            finally
            {
                dc.Connection.Close();
            }
        }

        public static void Update(Model.Archive.Dossier dossier, List<System.Data.SqlClient.SqlCommand> sSqlCommands,
            List<Model.Archive.ContactView> contactView, List<Model.Archive.AddressView> addressView, Model.Archive.Info info)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Controller.Archive.DossierController.Update(dossier, dc);
                //------------
                foreach (System.Data.SqlClient.SqlCommand sqlCommand in sSqlCommands)
                {
                    sqlCommand.Connection = dc.Connection as System.Data.SqlClient.SqlConnection;
                    sqlCommand.Transaction = dc.Transaction as System.Data.SqlClient.SqlTransaction;
                    sqlCommand.ExecuteNonQuery();
                }
                //------------ اطلاعات تماس و آدرس
                Controller.Archive.InfoController.InsertOrUpdate(info, dc);
                Controller.Archive.AddressController.Update(addressView, dossier.PersonnelNumber, dc);
                Controller.Archive.ContactController.Update(contactView, dossier.PersonnelNumber, dc);
                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.پرونده, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + dossier.PersonnelNumber);
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
                dc.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                dc.Connection.Close();
            }
        }

        public static void LoadPersonnelDataToControl(System.Windows.Forms.Control control, Model.Archive.ArchiveTab archiveTab, string personnelNumber)
        {
            System.Data.DataTable tempDataTable = SqlHelper.GetData(archiveTab.Name, personnelNumber);
            List<Model.Archive.ArchiveField> archiveFields = Controller.Archive.DossierCacheController.GetArchiveFields(archiveTab.ID);
            foreach (Model.Archive.ArchiveField field in archiveFields)
            {
                if (field.BoxTypeCode == (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی)
                {
                    System.Data.DataTable subGroupDataTable = SqlHelper.GetData(field.FieldName, personnelNumber);
                    Njit.Program.Controls.DataGridViewExtended subGroupDataGridView = control.Controls[field.FieldName].Controls[field.FieldName] as Njit.Program.Controls.DataGridViewExtended;
                    List<Model.Archive.ArchiveSubGroupField> subGroupFields = Controller.Archive.DossierCacheController.GetSubGroupFields(field.ID);

                    subGroupDataGridView.Rows.Clear();
                    foreach (System.Data.DataRow row in subGroupDataTable.Rows)
                    {
                        subGroupDataGridView.Rows.Add();
                        int CurrentRowIndex = subGroupDataGridView.RowCount - 2;
                        foreach (Model.Archive.ArchiveSubGroupField SubGroupField in subGroupFields)
                        {
                            if (SubGroupField.FieldTypeCode == (int)Enums.FieldTypes.شخص_حقیقی)
                            {
                                subGroupDataGridView.Rows[CurrentRowIndex].Cells[SubGroupField.FieldName].Value = Controller.Archive.RightfulPersonController.TryGetRightfulPerson(row[SubGroupField.FieldName].ToString());
                                ((subGroupDataGridView.Rows[CurrentRowIndex].Cells[SubGroupField.FieldName]) as Njit.Program.DataGridViewColumn.NjitComboBoxCell).SelectedValue = row[SubGroupField.FieldName];
                            }
                            else if (SubGroupField.FieldTypeCode == (int)Enums.FieldTypes.شخص_حقوقی)
                            {
                                subGroupDataGridView.Rows[CurrentRowIndex].Cells[SubGroupField.FieldName].Value = Controller.Archive.LegalPersonController.TryGetLegalPerson(row[SubGroupField.FieldName].ToString());
                                ((subGroupDataGridView.Rows[CurrentRowIndex].Cells[SubGroupField.FieldName]) as Njit.Program.DataGridViewColumn.NjitComboBoxCell).SelectedValue = row[SubGroupField.FieldName];
                            }
                            else
                            {
                                subGroupDataGridView.Rows[CurrentRowIndex].Cells[SubGroupField.FieldName].Value = row[SubGroupField.FieldName].ToString();
                            }
                        }
                    }
                    subGroupDataGridView.BestFitColumns();
                }
                else if (tempDataTable.Rows.Count > 0)
                {
                    if (field.BoxTypeCode == (int)Enums.BoxTypes.کادر_انتخاب_اشخاص)
                    {
                        ((Njit.Program.Controls.ComboBoxExtended)(control.Controls[field.FieldName])).SelectedValue = tempDataTable.Rows[0][field.FieldName];
                    }
                    else if (field.BoxTypeCode == (int)Enums.BoxTypes.کادر_انتخاب)
                    {
                        ((System.Windows.Forms.CheckBox)control.Controls[field.FieldName]).Checked = bool.Parse(tempDataTable.Rows[0][field.FieldName].ToString());
                    }
                    else
                    {
                        control.Controls[field.FieldName].Text = tempDataTable.Rows[0][field.FieldName].ToString();
                    }
                }
            }
        }

        internal static DataTable GetDossierList(List<Model.Archive.ArchiveField> displayFields, params SearchField[] searchFields)
        {
            return SqlHelper.GetDossierList(displayFields, searchFields);
        }

        internal static DataTable GetDossierList(params SearchField[] searchFields)
        {
            List<Model.Archive.ArchiveField> displayFields = Controller.Archive.ArchiveFieldController.GetDossierArchiveFieldsThahIsNotSubGroup();
            return GetDossierList(displayFields, searchFields);
        }

        internal static DataTable GetDossierList(Model.Archive.ArchiveTab tab, params SearchField[] searchFields)
        {
            List<Model.Archive.ArchiveField> displayFields = Controller.Archive.ArchiveFieldController.GetArchiveFieldsThahIsNotSubGroup(tab);
            DataTable SourceTable = GetDossierList(displayFields, searchFields);
            //اضافه کردن ستون
           DataTable ResultTable = new DataTable();

           DataColumn AutoNumberColumn = new DataColumn();

           AutoNumberColumn.ColumnName = "ردیف";

           AutoNumberColumn.DataType = typeof(int);

           AutoNumberColumn.AutoIncrement = true;

           AutoNumberColumn.AutoIncrementSeed = 1;

           AutoNumberColumn.AutoIncrementStep = 1;

           ResultTable.Columns.Add(AutoNumberColumn);

           ResultTable.Merge(SourceTable);

           return ResultTable;
        }

        internal static DataTable GetDocumentList(List<Model.Archive.ArchiveField> displayFields, params SearchField[] searchFields)
        {
            return SqlHelper.GetDocumentList(displayFields, searchFields);
        }

        internal static DataTable GetDocumentList(params SearchField[] searchFields)
        {
            List<Model.Archive.ArchiveField> displayFields = Controller.Archive.ArchiveFieldController.GetDocumentArchiveFieldsThahIsNotSubGroup();
            return GetDocumentList(displayFields, searchFields);
        }

        internal static DataTable GetDocumentList(Model.Archive.ArchiveTab tab, params SearchField[] searchFields)
        {
            List<Model.Archive.ArchiveField> displayFields = Controller.Archive.ArchiveFieldController.GetArchiveFieldsThahIsNotSubGroup(tab);
            return GetDocumentList(displayFields, searchFields);
        }

        internal static bool CheckPersonnelNumberAlreadyExist(string personnelNumber, string originalPersonnelNumber)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                if (!originalPersonnelNumber.IsNullOrEmpty())
                    return (dc.Dossiers.Where(t => t.PersonnelNumber == personnelNumber && t.PersonnelNumber != originalPersonnelNumber).Count() == 0) ? false : true;
                return (dc.Dossiers.Where(t => t.PersonnelNumber == personnelNumber).Count() == 0) ? false : true;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        internal static void Delete(string personnelNumber)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();

                //if (Controller.Archive.DossierController.IsDossierInLending(dc, personnelNumber))
                //    throw new Exception("این پرونده به امانت داده شده است، ابتدا بازگشت امانت را ثبت کنید");

                dc.Addresses.DeleteAllOnSubmit(dc.Addresses.Where(t => t.PersonnelNumber == personnelNumber));
                dc.SubmitChanges();

                dc.Contacts.DeleteAllOnSubmit(dc.Contacts.Where(t => t.PersonnelNumber == personnelNumber));
                dc.SubmitChanges();

                dc.Infos.DeleteAllOnSubmit(dc.Infos.Where(t => t.PersonnelNumber == personnelNumber));
                dc.SubmitChanges();

                dc.Lendings.DeleteAllOnSubmit(dc.Lendings.Where(t => t.PersonnelNumber == personnelNumber));
                dc.SubmitChanges();

                foreach (var doc in dc.Documents.Where(t => t.PersonnelNumber == personnelNumber && t.ParentDocumentID.HasValue))
                    Controller.Archive.DocumentController.Delete(dc, doc.ID);

                foreach (var doc in dc.Documents.Where(t => t.PersonnelNumber == personnelNumber && t.ParentDocumentID == null))
                    Controller.Archive.DocumentController.Delete(dc, doc.ID);

                Model.Archive.Dossier dossier = dc.Dossiers.Where(t => t.PersonnelNumber == personnelNumber).Single();
                dc.Dossiers.DeleteOnSubmit(dossier);
                dc.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.پرونده, Setting.User.UserOparatesNames.حذف, null, "حذف پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + personnelNumber);
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
        }

        private static bool IsDossierInLending(Model.Archive.ArchiveDataClassesDataContext dc, string personnelNumber)
        {
            return dc.Lendings.Where(t => t.PersonnelNumber == personnelNumber && t.ReturnDate != null && t.ReturnDate != "").Count() > 0;
        }

        private static bool IsDossierInLending(string personnelNumber)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return IsDossierInLending(dc, personnelNumber);
        }

        internal static void ChangePersonnelNumber(string originalPersonnelNumber, string newPersonnelNumber)
        {
            SqlHelper.ChangePersonnelNumber(originalPersonnelNumber, newPersonnelNumber);
        }

        internal static object GetDossiersCount(string archiveName)
        {
            using (var dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.GetDatabaseConnection(archiveName).ConnectionString))
            {
                return dc.Dossiers.Count();
            }
        }
    }
}
