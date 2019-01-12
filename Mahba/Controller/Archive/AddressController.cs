using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    class AddressController
    {
        public static void Insert(Model.Archive.Address address)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                dc.Addresses.InsertOnSubmit(address);
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

        public static void Insert(List<Model.Archive.Address> addressList)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                dc.Addresses.InsertAllOnSubmit(addressList);
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

        public static void Insert(List<Model.Archive.Address> addressList, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            try
            {
                dc.Addresses.InsertAllOnSubmit(addressList);
                dc.SubmitChanges();
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
                dc.Addresses.DeleteAllOnSubmit(dc.Addresses.Where(t => t.PersonnelNumber == personnelNumber));
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

        public static void Insert(List<Model.Archive.AddressView> addressViewList)
        {
            if (addressViewList.Count == 0)
                return;
            List<Model.Archive.Address> addressList = new List<Model.Archive.Address>();
            foreach (var item in addressViewList)
            {
                addressList.Add(Model.Archive.Address.GetNewInstance(item.PersonnelNumber, item.AddressTypeID, item.ProvinceID, item.Township, item.MetropolitanAreaID, item.Street, item.Alley, item.PostalCode));
            }
            Insert(addressList);
        }

        public static void Insert(List<Model.Archive.AddressView> addressViewList, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            if (addressViewList.Count == 0)
                return;
            List<Model.Archive.Address> addressList = new List<Model.Archive.Address>();
            foreach (var item in addressViewList)
            {
                addressList.Add(Model.Archive.Address.GetNewInstance(item.PersonnelNumber, item.AddressTypeID, item.ProvinceID, item.Township, item.MetropolitanAreaID, item.Street, item.Alley, item.PostalCode));
            }
            Insert(addressList, dc);
        }

        public static List<Model.Archive.AddressView> Select(string personnelNumber)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.AddressViews.Where(t => t.PersonnelNumber == personnelNumber).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        internal static void Update(List<Model.Archive.AddressView> addressViewList, string personnelNumber, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            dc.Addresses.DeleteAllOnSubmit(dc.Addresses.Where(t => t.PersonnelNumber == personnelNumber));
            dc.SubmitChanges();
            List<Model.Archive.Address> addressList = new List<Model.Archive.Address>();
            foreach (var item in addressViewList)
                addressList.Add(Model.Archive.Address.GetNewInstance(item.PersonnelNumber, item.AddressTypeID, item.ProvinceID, item.Township, item.MetropolitanAreaID, item.Street, item.Alley, item.PostalCode));
            Insert(addressList, dc);
        }
    }
}
