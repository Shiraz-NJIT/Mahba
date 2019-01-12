using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class LendingController
    {
        public static int AddLending(Model.Archive.Lending lending)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                var query = dc.Lendings.Where(t => t.PersonnelNumber == lending.PersonnelNumber && t.ReturnDate == null);
                if (query.Count() > 0)
                    throw new Exception(string.Format("پرونده با {0} '{1}' به '{2}' امانت داده شده است", Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label, lending.PersonnelNumber, query.First().Person.Name));
                dc.Lendings.InsertOnSubmit(lending);
                dc.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.امانت, Setting.User.UserOparatesNames.ثبت, null, "ثبت امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + lending.PersonnelNumber + " به " + lending.Person.Name);
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                dc.Transaction.Commit();
                dc.Connection.Close();

                return lending.ID;
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
        }

        internal static Model.Archive.Lending GetLending(int lendingID)
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().Lendings.Where(t => t.ID == lendingID).Single();
        }

        internal static int UpdateLending(int originalID, Model.Archive.Lending lending)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.Lending originalLending = dc.Lendings.Where(t => t.ID == originalID).Single();
                string originalPersonnelNumber = originalLending.PersonnelNumber;
                Model.Archive.Lending.Copy(originalLending, lending);
                dc.SubmitChanges();

                ReturnLending(dc, originalLending.ID, originalLending.ReturnDate, originalLending.ReturnTime);

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.امانت, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + originalPersonnelNumber);
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                dc.Transaction.Commit();
                dc.Connection.Close();

                return originalID;
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
        }

        internal static DataTable GetLendingList()
        {
            List<Model.Archive.ArchiveField> displayFields = Controller.Archive.DisplayFieldController.GetDisplayFields(Enums.DisplayFieldCodes.امانت);
            return SqlHelper.GetLendingList(displayFields);
        }

        internal static void DeleteLending(Model.Archive.Lending lending)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                var originalLending = (from temp in dc.Lendings where temp.ID == lending.ID select temp).Single();
                dc.Lendings.DeleteOnSubmit(originalLending);
                dc.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.امانت, Setting.User.UserOparatesNames.حذف, null, "حذف امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + originalLending.PersonnelNumber);
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                if (ex.ErrorCode == -2146232060 && ex.Number == 547)
                {
                    throw new Exception("امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " '" + lending.PersonnelNumber + "' قابل حذف نیست\nاز این اطلاعات در جای دیگر استفاده شده است");
                }
                else
                {
                    throw new Exception("خطا در حذف امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings + " '" + lending.PersonnelNumber + "'" + "  " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw new Exception("خطا در حذف امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " '" + lending.PersonnelNumber + "'" + "\n\n" + ex.Message);
            }
            if (dc.Connection.State != ConnectionState.Closed)
            {
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
        }

        internal static void ReturnLending(Model.Archive.ArchiveDataClassesDataContext dc, int lendingID, string returnDate, string returnTime)
        {
            if (returnDate == null)
                UnReturnLending(dc, lendingID);
            else
            {
                var lending = dc.Lendings.Where(t => t.ID == lendingID).Single();

                if (lending.Date.CompareTo(returnDate) > 0)
                    throw new Exception("تاریخ بازگشت نمی تواند از تاریخ امانت کوچکتر باشد");

                if (lending.Date.CompareTo(returnDate) == 0 && lending.Time.CompareTo(returnTime) > 0)
                    throw new Exception("زمان بازگشت نمی تواند از زمان امانت کوچکتر باشد");

                lending.ReturnDate = returnDate;
                lending.ReturnTime = returnTime;
                TimeSpan timeSpan = GetRealDurationDayAndHour(lending.Date, lending.ReturnDate, lending.Time, lending.ReturnTime);
                lending.RealDurationDay = timeSpan.Days;
                lending.RealDurationHour = timeSpan.Hours;
                dc.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بازگشت_امانت, Setting.User.UserOparatesNames.ثبت, null, "بازگشت امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + lending.PersonnelNumber);
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
            }
        }

        internal static void ReturnLending(int lendingID, string returnDate, string returnTime)
        {
            if (returnDate == null)
                UnReturnLending(lendingID);
            else
            {
                var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {
                    ReturnLending(dc, lendingID, returnDate, returnTime);

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
        }

        private static TimeSpan GetRealDurationDayAndHour(string date, string returnDate, string time, string returnTime)
        {
            int days = Njit.Common.PersianCalendar.CompareDate(date, returnDate);
            int hours = Njit.Common.PersianCalendar.CompareTimeWithHour(time, returnTime);
            if (days < 0)
                throw new Exception();
            if (days == 0 && hours < 0)
                throw new Exception();
            if (hours < 0)
            {
                int h = days * 24;
                h = h - (-hours);
                days = h / 24;
                hours = h % 24;
            }
            return new TimeSpan(days, hours, 0, 0);
        }

        internal static void UnReturnLending(int lendingID)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                UnReturnLending(dc, lendingID);

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

        internal static void UnReturnLending(Model.Archive.ArchiveDataClassesDataContext dc, int lendingID)
        {
            var lending = dc.Lendings.Where(t => t.ID == lendingID).Single();
            lending.ReturnDate = null;
            lending.ReturnTime = null;
            lending.RealDurationDay = null;
            lending.RealDurationHour = null;
            dc.SubmitChanges();
            try
            {
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بازگشت_امانت, Setting.User.UserOparatesNames.حذف, null, "لغو بازگشت امانت پرونده با " + Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + " " + lending.PersonnelNumber);
            }
            catch
            {
                throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
            }
        }
    }
}
