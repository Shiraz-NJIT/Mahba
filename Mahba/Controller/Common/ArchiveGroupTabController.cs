using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    static class ArchiveGroupTabController
    {
        public static void Insert(Model.Common.ArchiveGroupTab archiveGroupTab)
        {
            List<System.Data.Common.DbTransaction> transactionOfArchives = new List<System.Data.Common.DbTransaction>();
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDC = new List<Model.Archive.ArchiveDataClassesDataContext>();

            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                //--------------- ArchiveGroupTab ذخیره گروه اطلاعاتی در
                archiveGroupTab.Index = dc.ArchiveGroupTabs.Count() == 0 ? 1 : (dc.ArchiveGroupTabs.Select(t => t.Index).Max() + 1);
                dc.ArchiveGroupTabs.InsertOnSubmit(archiveGroupTab);
                dc.SubmitChanges();

                if (archiveGroupTab.TypeCode == (int)Enums.TabTypes.Dossier)
                    Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_پرونده, Setting.User.UserOparatesNames.ثبت, null, "ثبت گروه اطلاعاتی '" + archiveGroupTab.Title + "' در گروه بایگانی '" + archiveGroupTab.ArchiveGroup.Title + "'");
                else
                    Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_سند, Setting.User.UserOparatesNames.ثبت, null, "ثبت گروه اطلاعاتی '" + archiveGroupTab.Title + "' در گروه بایگانی '" + archiveGroupTab.ArchiveGroup.Title + "'");

                //---------------ذخیره گروه اطلاعاتی در بایگانی های مشتق شده 
                foreach (string sqlConnectionString in GetArchivesConnectionStrings(archiveGroupTab.ID, dc))
                {
                    Model.Archive.ArchiveDataClassesDataContext archiveDC = new Model.Archive.ArchiveDataClassesDataContext(sqlConnectionString);
                    archiveDC.Connection.Open();
                    archivesDC.Add(archiveDC);
                    transactionOfArchives.Add(archiveDC.Connection.BeginTransaction());
                    archiveDC.Transaction = transactionOfArchives[transactionOfArchives.Count - 1];
                }
                AddArchiveTabForArchives(archiveGroupTab, dc, archivesDC);

                //--------------- عمل کردن تمام تراکنش ها
                foreach (System.Data.Common.DbTransaction tr in transactionOfArchives)
                    tr.Commit();
                dc.Transaction.Commit();
            }
            //--------------- بازگرداندن تمام تراکنش ها
            catch (Exception ex)
            {
                foreach (System.Data.Common.DbTransaction tr in transactionOfArchives)
                    tr.Rollback();
                dc.Transaction.Rollback();
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            //--------------- بستن تمام کانکشن ها
            finally
            {
                foreach (Model.Archive.ArchiveDataClassesDataContext dcArchive in archivesDC)
                    dcArchive.Connection.Close();
                dc.Connection.Close();
            }
        }

        public static void AddArchiveTabForArchives(Model.Common.ArchiveGroupTab archiveGroupTab, Model.Common.ArchiveCommonDataClassesDataContext dc, List<Model.Archive.ArchiveDataClassesDataContext> dataContextOfArchives)
        {
            foreach (var archiveDC in dataContextOfArchives)
            {
                AddArchiveTabToArchive(archiveGroupTab, dc, archiveDC);
            }
        }

        public static void AddArchiveTabToArchive(Model.Common.ArchiveGroupTab archiveGroupTab, Model.Common.ArchiveCommonDataClassesDataContext dc, Model.Archive.ArchiveDataClassesDataContext archiveDC)
        {
            if (archiveDC.ArchiveTabs.Where(t => t.TypeCode == archiveGroupTab.TypeCode && t.Title == archiveGroupTab.Title && t.Deleted == false).Count() > 0)
                throw new Exception(" گروه اطلاعاتی '" + archiveGroupTab.Title + "' در بایگانی '" + dc.Archives.Where(t => t.Name == archiveDC.Connection.Database).Select(t => t.Title).Single() + "' وجود دارد لطفا نام دیگری را انتخاب کنید ");
            Model.Archive.ArchiveTab archiveTab = Model.Archive.ArchiveTab.GetNewInstance(archiveGroupTab.TypeCode, 0, null, archiveGroupTab.Title, true, false, archiveGroupTab.ID, false);
            Controller.Archive.ArchiveTabController.Insert(archiveTab, archiveDC);
            archiveDC.SubmitChanges();
            SqlHelper.CreateTableForArchiveTab(archiveDC, archiveTab);
            foreach (Model.Common.ArchiveGroupField field in Controller.Common.ArchiveGroupTabController.GetArchiveGroupFields(dc, archiveGroupTab.ID, archiveGroupTab.ArchiveGroupID))
            {
                Controller.Archive.ArchiveFieldController.AddField(archiveDC, field);
                foreach (Model.Common.ArchiveGroupSubGroupField subField in Controller.Common.ArchiveGroupFieldController.GetArchiveGroupSubGroupFields(dc, field.ID))
                {
                    Controller.Archive.ArchiveSubGroupFieldController.AddSubGroupField(archiveDC, subField);
                }
            }
            if (archiveGroupTab.TypeCode == (int)Enums.TabTypes.Dossier)
                Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_پرونده, Setting.User.UserOparatesNames.ثبت, null, "ثبت گروه اطلاعاتی '" + archiveTab.Title + "' در بایگانی '" + archiveDC.GetArchive().Title + "'");
            else
                Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_سند, Setting.User.UserOparatesNames.ثبت, null, "ثبت گروه اطلاعاتی '" + archiveTab.Title + "' در بایگانی '" + archiveDC.GetArchive().Title + "'");
        }

        public static Model.Common.ArchiveGroupTab Select(int id)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            try
            {
                return dc.ArchiveGroupTabs.Where(t => t.ID == id).Single();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);

            }
        }

        public static List<Model.Common.ArchiveGroupTab> GetAllSelfAndBaseArchiveGroupTabs(int archiveGroupID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            try
            {
                List<NjitSoftware.Model.Common.ArchiveGroup> AllParent = Controller.Common.ArchiveGroupController.GetBaseArchiveGroups(archiveGroupID).ToList();
                AllParent.Add(dc.ArchiveGroups.Where(t => t.ID == archiveGroupID).Single());
                return dc.ArchiveGroupTabs.Select(t => t).Where(t => AllParent.Select(t2 => t2.ID).Contains(t.ArchiveGroupID)).OrderBy(t => t.Index).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static List<Model.Common.ArchiveGroupTab> SelectAll()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            try
            {
                return dc.ArchiveGroupTabs.Select(t => t).OrderBy(t => t.Index).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);

            }
        }

        public static List<Model.Common.ArchiveGroupTab> SelectAllDossier()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            try
            {
                return dc.ArchiveGroupTabs.Where(t => t.TypeCode == (int)Enums.TabTypes.Dossier).OrderBy(t => t.Index).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);

            }
        }

        public static List<Model.Common.ArchiveGroupTab> SelectAllTabDocuments()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            try
            {
                return dc.ArchiveGroupTabs.Where(t => t.TypeCode == (int)Enums.TabTypes.Document).OrderBy(t => t.Index).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);

            }
        }

        public static bool TabExistNameCheck(string Title, int TypeCode)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                return dc.ArchiveGroupTabs.Where(t => t.TypeCode == TypeCode && t.Title == Title).Count() == 0 ? false : true;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static bool TabExistNameCheck_UsedArchive(string Title, int TypeCode, int _ID, out string Message)
        {
            try
            {
                Message = null;
                foreach (string _SqlConnection in GetArchivesConnectionStrings(_ID))
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(_SqlConnection);
                    if (dcArchive.ArchiveTabs.Where(t => t.TypeCode == TypeCode && t.Title == Title && t.Deleted == false).Count() > 0)
                    {
                        Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                        Message = " گروه اطلاعاتی " + Title + " در بایگانی " + dc.Archives.Where(t => t.Name == dcArchive.Connection.Database).Select(t => t.Title).Single() + " وجود دارد لطفا نام دیگری را انتخاب کنید ";
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static void Update(Model.Common.ArchiveGroupTab _ArchiveGroupTab)
        {
            List<System.Data.Common.DbTransaction> _DbTransactionAllArchive = new List<System.Data.Common.DbTransaction>();
            List<Model.Archive.ArchiveDataClassesDataContext> dcAllArchive = new List<Model.Archive.ArchiveDataClassesDataContext>();

            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                //---------------ArchiveGroupTab تغییر نام گروه اطلاعاتی در
                var originalArchiveGroupTab = dc.ArchiveGroupTabs.Where(t => t.ID == _ArchiveGroupTab.ID).Single();
                string original_title = originalArchiveGroupTab.Title;
                Model.Common.ArchiveGroupTab.Copy(originalArchiveGroupTab, _ArchiveGroupTab);
                dc.SubmitChanges();

                if (_ArchiveGroupTab.TypeCode == (int)Enums.TabTypes.Dossier)
                    Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_پرونده, Setting.User.UserOparatesNames.ویرایش, null, "تغییر نام گروه اطلاعاتی '" + original_title + "' به '" + _ArchiveGroupTab.Title + "'");
                else
                    Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_سند, Setting.User.UserOparatesNames.ویرایش, null, "تغییر نام گروه اطلاعاتی '" + original_title + "' به '" + _ArchiveGroupTab.Title + "'");

                //--------- ذخیره گروه اطلاعاتی در بایگانی های مشتق شده 
                foreach (string SqlConnection in GetArchivesConnectionStrings(_ArchiveGroupTab.ID, dc))
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(SqlConnection);
                    dcArchive.Connection.Open();

                    dcAllArchive.Add(dcArchive);// لیست تمام کانکشن ها
                    _DbTransactionAllArchive.Add(dcArchive.Connection.BeginTransaction());//----- لیست تمام تراکنش ها

                    dcArchive.Transaction = _DbTransactionAllArchive[_DbTransactionAllArchive.Count - 1];

                    if (dcArchive.ArchiveTabs.Where(t => t.TypeCode == _ArchiveGroupTab.TypeCode && t.Title == _ArchiveGroupTab.Title && t.Deleted == false).Count() > 0 ? true : false)
                    {
                        string Message = " گروه اطلاعاتی " + _ArchiveGroupTab.Title + " در بایگانی " + dc.Archives.Where(t => t.Name == dcArchive.Connection.Database).Select(t => t.Title).Single() + " وجود دارد لطفا نام دیگری را انتخاب کنید ";
                        throw new Exception(Message);
                    }
                    else
                    {
                        Model.Archive.ArchiveTab archiveTab = dcArchive.ArchiveTabs.Where(t => t.IDParent == _ArchiveGroupTab.ID).Single();
                        archiveTab.Title = _ArchiveGroupTab.Title;
                        dcArchive.SubmitChanges();
                        if (archiveTab.TypeCode == (int)Enums.TabTypes.Dossier)
                            Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_پرونده, Setting.User.UserOparatesNames.ویرایش, null, "تغییر نام گروه اطلاعاتی '" + original_title + "' در بایگانی '" + dcArchive.GetArchive().Title + "' به '" + _ArchiveGroupTab.Title + "'");
                        else
                            Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_سند, Setting.User.UserOparatesNames.ویرایش, null, "تغییر نام گروه اطلاعاتی '" + original_title + "' در بایگانی '" + dcArchive.GetArchive().Title + "' به '" + _ArchiveGroupTab.Title + "'");
                    }
                }

                //------ عمل کردن تمام تراکنش ها
                foreach (System.Data.Common.DbTransaction DbTransaction in _DbTransactionAllArchive)
                    DbTransaction.Commit();
                dc.Transaction.Commit();
            }
            catch (Exception ex)//----- بازگرداندن تمام تراکنش ها
            {
                foreach (System.Data.Common.DbTransaction DbTransaction in _DbTransactionAllArchive)
                    DbTransaction.Rollback();
                dc.Transaction.Rollback();
                throw new Exception("خطا در بروزرسانی اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            finally//--------------- بستن تمام کانکشن ها
            {
                foreach (Model.Archive.ArchiveDataClassesDataContext dcArchive in dcAllArchive)
                    dcArchive.Connection.Close();
                dc.Connection.Close();
            }
        }

        public static void Update_ArchiveTabIndex(Model.Common.ArchiveGroupTab _ArchiveGroupTab)
        {
            List<System.Data.Common.DbTransaction> _DbTransactionAllArchive = new List<System.Data.Common.DbTransaction>();
            List<Model.Archive.ArchiveDataClassesDataContext> dcAllArchive = new List<Model.Archive.ArchiveDataClassesDataContext>();

            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                //---------------ArchiveGroupTab تغییر نام گروه اطلاعاتی در
                Model.Common.ArchiveGroupTab.Copy(dc.ArchiveGroupTabs.Where(t => t.ID == _ArchiveGroupTab.ID).Single(), _ArchiveGroupTab);
                dc.SubmitChanges();
                dc.Transaction.Commit();
            }
            catch (Exception ex)//----- بازگرداندن تمام تراکنش ها
            {
                dc.Transaction.Rollback();
                throw new Exception("خطا در بروزرسانی اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            finally//--------------- بستن تمام کانکشن ها
            {
                dc.Connection.Close();
            }
        }

        public static void Delete(int ID)
        {
            List<System.Data.Common.DbTransaction> archivesTransactions = new List<System.Data.Common.DbTransaction>();
            List<Model.Archive.ArchiveDataClassesDataContext> archivesDataContexts = new List<Model.Archive.ArchiveDataClassesDataContext>();

            Model.Common.ArchiveCommonDataClassesDataContext archiveCommonDc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            archiveCommonDc.Connection.Open();
            archiveCommonDc.Transaction = archiveCommonDc.Connection.BeginTransaction();
            try
            {
                foreach (string SqlConnection in GetArchivesConnectionStrings(ID))
                {
                    Model.Archive.ArchiveDataClassesDataContext dcArchive = new Model.Archive.ArchiveDataClassesDataContext(SqlConnection);
                    dcArchive.Connection.Open();

                    archivesDataContexts.Add(dcArchive);
                    archivesTransactions.Add(dcArchive.Connection.BeginTransaction());

                    dcArchive.Transaction = archivesTransactions[archivesTransactions.Count - 1];

                    Model.Archive.ArchiveTab archiveTab = dcArchive.ArchiveTabs.Where(t => t.IDParent == ID).Single();
                    archiveTab.IDParent = null;

                    List<Model.Archive.ArchiveField> archiveFields = dcArchive.ArchiveFields.Where(t => t.ArchiveTabID == archiveTab.ID).ToList();
                    foreach (Model.Archive.ArchiveField item in archiveFields)
                    {
                        item.IDParent = null;
                    }

                    dcArchive.SubmitChanges();
                }

                var originalArchiveGroupTab = archiveCommonDc.ArchiveGroupTabs.Where(t => t.ID == ID).Single();
                string originalTitle = originalArchiveGroupTab.Title;
                string originalArchiveGroupTitle = originalArchiveGroupTab.ArchiveGroup.Title;
                int originalTypeCode = originalArchiveGroupTab.TypeCode;

                Model.Common.ArchiveGroupTab.Delete(archiveCommonDc, originalArchiveGroupTab);
                archiveCommonDc.SubmitChanges();

                try
                {
                    if (originalTypeCode == (int)Enums.TabTypes.Dossier)
                        Setting.User.ThisProgram.AddLog(archiveCommonDc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_پرونده, Setting.User.UserOparatesNames.ثبت, null, "حذف گروه اطلاعاتی '" + originalTitle + "' از گروه بایگانی '" + originalArchiveGroupTitle + "'");
                    else
                        Setting.User.ThisProgram.AddLog(archiveCommonDc, Setting.User.UserOparatesPlaceNames.گروه_اطلاعاتی_سند, Setting.User.UserOparatesNames.ثبت, null, "حذف گروه اطلاعاتی '" + originalTitle + "' از گروه بایگانی '" + originalArchiveGroupTitle + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                foreach (System.Data.Common.DbTransaction DbTransaction in archivesTransactions)
                    DbTransaction.Commit();
                archiveCommonDc.Transaction.Commit();
            }
            catch (Exception ex)
            {
                foreach (System.Data.Common.DbTransaction DbTransaction in archivesTransactions)
                    DbTransaction.Rollback();
                archiveCommonDc.Transaction.Rollback();
                throw new Exception("خطا در حذف گروه اطلاعاتی" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                foreach (Model.Archive.ArchiveDataClassesDataContext dcArchive in archivesDataContexts)
                    dcArchive.Connection.Close();
                archiveCommonDc.Connection.Close();
            }
        }

        public static IEnumerable<string> GetArchivesConnectionStrings(int archiveGroupTabID)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                return GetArchivesConnectionStrings(dc.ArchiveGroupTabs.Where(t => t.ID == archiveGroupTabID).Single());
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static IEnumerable<string> GetArchivesConnectionStrings(int archiveGroupTabID, Model.Common.ArchiveCommonDataClassesDataContext dc)
        {
            try
            {
                return GetArchivesConnectionStrings(dc.ArchiveGroupTabs.Where(t => t.ID == archiveGroupTabID).Single());
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static IEnumerable<string> GetArchivesConnectionStrings(NjitSoftware.Model.Common.ArchiveGroupTab archiveGroupTab)
        {
            List<string> archives = new List<string>();
            AddArchivesToList(archiveGroupTab.ArchiveGroup, archives);

            List<string> list = new List<string>();
            foreach (var item in archives)
            {
                list.Add(Setting.Sql.ThisProgram.GetDatabaseConnection(item).ConnectionString);
            }
            return list;
        }

        public static List<NjitSoftware.Model.Archive.ArchiveDataClassesDataContext> GetArchivesConnections(NjitSoftware.Model.Common.ArchiveGroupTab archiveGroupTab)
        {
            List<string> archives = new List<string>();
            AddArchivesToList(archiveGroupTab.ArchiveGroup, archives);

            List<NjitSoftware.Model.Archive.ArchiveDataClassesDataContext> list = new List<NjitSoftware.Model.Archive.ArchiveDataClassesDataContext>();
            foreach (var item in archives)
            {
                System.Data.SqlClient.SqlConnectionStringBuilder csb = Setting.Sql.ThisProgram.GetDatabaseConnection(item);
                list.Add(new NjitSoftware.Model.Archive.ArchiveDataClassesDataContext(csb.ConnectionString));
            }
            return list;
        }

        private static void AddArchivesToList(NjitSoftware.Model.Common.ArchiveGroup archiveGroup, List<string> archives)
        {
            foreach (var item in archiveGroup.Archives.Where(t => t.Active == true))
            {
                archives.Add(item.Name);
            }
            foreach (var item in archiveGroup.ArchiveGroups)
            {
                AddArchivesToList(item, archives);
            }
        }

        public static IEnumerable<NjitSoftware.Model.Common.ArchiveGroupTab> GetBaseTabs(Model.Common.ArchiveGroupTab archiveGroupTab)
        {
            List<NjitSoftware.Model.Common.ArchiveGroupTab> list = new List<NjitSoftware.Model.Common.ArchiveGroupTab>();
            AddBaseArchiveGroupTabsToList(list, archiveGroupTab.ArchiveGroup);
            return list;
        }

        private static void AddBaseArchiveGroupTabsToList(List<NjitSoftware.Model.Common.ArchiveGroupTab> list, NjitSoftware.Model.Common.ArchiveGroup archiveGroup)
        {
            if (archiveGroup.ParentID.HasValue)
            {
                foreach (var item in archiveGroup.ArchiveGroup1.ArchiveGroupTabs)
                {
                    list.Add(item);
                }
                AddBaseArchiveGroupTabsToList(list, archiveGroup.ArchiveGroup1);
            }
        }

        public static IEnumerable<NjitSoftware.Model.Common.ArchiveGroupTab> GetBaseTabs(int ArchiveGroupTabID)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                return GetBaseTabs(dc.ArchiveGroupTabs.Where(t => t.ID == ArchiveGroupTabID).Single());
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        public static Model.Common.ArchiveGroupField[] GetArchiveGroupFields(Model.Common.ArchiveCommonDataClassesDataContext dc, int archiveGroupTabID, int archiveGroupID)
        {
            return dc.ArchiveGroupFields.Where(t => t.ArchiveGroupTabID == archiveGroupTabID && t.ArchiveGroupID == archiveGroupID).ToArray();
        }

        public static Model.Common.ArchiveGroupField[] GetArchiveGroupFields(int archiveGroupTabID, int archiveGroupID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return GetArchiveGroupFields(dc, archiveGroupTabID, archiveGroupID);
        }

        public static IEnumerable<Field> GetFields(int archiveGroupTabID, int archiveGroupID)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return GetFields(dc.ArchiveGroupTabs.Where(t => t.ID == archiveGroupTabID).Single(), archiveGroupID);
        }

        public static IEnumerable<Field> GetFields(Model.Common.ArchiveGroupTab archiveGroupTab, int archiveGroupID)
        {
            List<Field> list = new List<Field>();
            IEnumerable<int> baseArchiveGroupIDs = Controller.Common.ArchiveGroupController.GetBaseArchiveGroups(archiveGroupID).Select(t => t.ID);
            foreach (var item in archiveGroupTab.ArchiveGroupFields.Where(t => t.ArchiveGroupID == archiveGroupID || baseArchiveGroupIDs.Contains(t.ArchiveGroupID)).OrderBy(t => t.Index))
            {
                list.Add(new Field(item.ID, item.Label, item.FieldName, item.FieldTypeCode, item.FieldType.Title, item.StatusCode, item.FieldStatus.Title, item.BoxTypeCode, item.BoxType.Title, item.AutoComplete, item.MinLength, item.MaxLength, item.MinValue, item.MaxValue, (item.ArchiveGroupID != archiveGroupID) ? item.ArchiveGroupTabID : (int?)null, item.Index, item.DefaultValue));
                if (item.FieldTypeCode == (int)Enums.FieldTypes.زیرگروه_جدولی)
                {
                    List<Field> list2 = new List<Field>();
                    foreach (var item2 in item.ArchiveGroupSubGroupFields.OrderBy(t => t.Index))
                    {
                        list2.Add(new Field(item2.ID, item2.Label, item2.FieldName, item2.FieldTypeCode, item2.FieldType.Title, item2.StatusCode, item2.FieldStatus.Title, item2.BoxTypeCode, item2.BoxType.Title, item2.AutoComplete, item2.MinLength, item2.MaxLength, item2.MinValue, item2.MaxValue, (item.ArchiveGroupID != archiveGroupID) ? item.ArchiveGroupTabID : (int?)null, item2.Index, item.DefaultValue));
                    }
                    list[list.Count - 1].SubFields = list2;
                }
            }
            return list;
        }
    }
}
