using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    class ContactController
    {
        public static void Insert(Model.Archive.Contact contact)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                dc.Contacts.InsertOnSubmit(contact);
                dc.SubmitChanges();
                dc.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                dc.Connection.Close();
            }
        }

        public static void Insert(List<Model.Archive.Contact> contact)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                dc.Contacts.InsertAllOnSubmit(contact);
                dc.SubmitChanges();
                dc.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                dc.Connection.Close();
            }
        }

        public static void Insert(List<Model.Archive.Contact> contact, Model.Archive.ArchiveDataClassesDataContext dcArchive)
        {
            try
            {
                dcArchive.Contacts.InsertAllOnSubmit(contact);
                dcArchive.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        public static void DeleteAll(string personnelNumber)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                dc.Contacts.DeleteAllOnSubmit(dc.Contacts.Where(t => t.PersonnelNumber == personnelNumber));
                dc.SubmitChanges();
                dc.Transaction.Commit();
            }
            catch (Exception ex)
            {
                dc.Transaction.Rollback();
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                dc.Connection.Close();
            }
        }

        public static void Insert(List<Model.Archive.ContactView> contactView)
        {
            try
            {
                if (contactView.Count == 0)
                    return;
                List<Model.Archive.Contact> contact = new List<Model.Archive.Contact>();
                foreach (var item in contactView)
                {
                    contact.Add(Model.Archive.Contact.GetNewInstance(item.PersonnelNumber, item.CallTypeID, item.Number, item.Comment));
                }
                Insert(contact);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void Insert(List<Model.Archive.ContactView> contactView, Model.Archive.ArchiveDataClassesDataContext dcArchive)
        {
            if (contactView.Count == 0)
                return;
            List<Model.Archive.Contact> contact = new List<Model.Archive.Contact>();
            foreach (var item in contactView)
                contact.Add(Model.Archive.Contact.GetNewInstance(item.PersonnelNumber, item.CallTypeID, item.Number, item.Comment));
            Insert(contact, dcArchive);
        }

        public static List<Model.Archive.ContactView> Select(string PersonnelNumber)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.ContactViews.Where(t => t.PersonnelNumber == PersonnelNumber).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        internal static void Update(List<Model.Archive.ContactView> contactViewList, string personnelNumber, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            dc.Contacts.DeleteAllOnSubmit(dc.Contacts.Where(t => t.PersonnelNumber == personnelNumber));
            dc.SubmitChanges();
            List<Model.Archive.Contact> contactList = new List<Model.Archive.Contact>();
            foreach (var item in contactViewList)
                contactList.Add(Model.Archive.Contact.GetNewInstance(item.PersonnelNumber, item.CallTypeID, item.Number, item.Comment));
            Insert(contactList, dc);
        }
    }
}
