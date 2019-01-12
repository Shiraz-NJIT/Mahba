using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class PersonController
    {
        internal static Model.Archive.Person AddPerson(string name)
        {
            Model.Archive.Person person = Model.Archive.Person.GetNewInstance(name);
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                dc.Persons.InsertOnSubmit(person);
                dc.SubmitChanges();
                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.امانت, Setting.User.UserOparatesNames.ثبت, null, "ثبت اطلاعات شخص با نام '" + name + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
            dc.Transaction.Commit();
            dc.Connection.Close();
            return person;
        }

        internal static void UpdatePerson(int originalID, string name)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.Person person = Model.Archive.Person.GetNewInstance(name);
                Model.Archive.Person originalPerson = dc.Persons.Where(t => t.ID == originalID).Single();
                string originalName = originalPerson.Name;
                Model.Archive.Person.Copy(originalPerson, person);
                dc.SubmitChanges();
                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.امانت, Setting.User.UserOparatesNames.ویرایش, null, "ویرایش اطلاعات شخص با نام '" + originalName + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
            dc.Transaction.Commit();
            dc.Connection.Close();
        }

        internal static Model.Archive.Person SearchPersonByName(string name)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            var query = dc.Persons.Where(t => t.Name == name);
            if (query.Count() == 0)
                return null;
            return query.FirstOrDefault();
        }

        internal static Model.Archive.Person GetPersonByID(int personID)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Persons.Where(t => t.ID == personID).Single();
        }

        internal static void Delete(int personID)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();

            Model.Archive.Person person = null;

            try
            {
                var query = from temp in dc.Persons where temp.ID == personID select temp;
                person = query.Single();
                string originalName = person.Name;
                Model.Archive.Person.Delete(dc, person);
                dc.SubmitChanges();

                try
                {
                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.امانت, Setting.User.UserOparatesNames.حذف, null, "حذف اطلاعات شخص با نام '" + originalName + "'");
                }
                catch
                {
                    throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                }

                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                if (ex.ErrorCode == -2146232060 && ex.Number == 547)
                {
                    throw new Exception("اطلاعات شخص با نام '" + person.Name + "' قابل حذف نیست از این اطلاعات در جای دیگر استفاده شده است");
                }
                else
                {
                    throw new Exception("خطا در حذف اطلاعات شخص با نام '" + person.Name + "'" + "     " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw new Exception("خطا در حذف اطلاعات شخص با نام '" + person.Name + "'" + "     " + ex.Message);
            }
            finally
            {
                if (dc.Connection.State != System.Data.ConnectionState.Closed)
                {
                    dc.Connection.Close();
                }
            }
        }
    }
}
