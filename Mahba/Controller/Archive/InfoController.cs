using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    class InfoController
    {
        public static void Insert(Model.Archive.Info info)
        {
            if (info == null)
                return;
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                dc.Infos.InsertOnSubmit(info);
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

        public static void Insert(Model.Archive.Info info, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            try
            {
                if (info == null)
                    return;
                dc.Infos.InsertOnSubmit(info);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        public static Model.Archive.Info Select(string PersonnelNumber)
        {
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                return dc.Infos.Where(t => t.PersonnelNumber == PersonnelNumber).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در خواندن اطلاعات از پایگاه داده" + "\r\n\r\n" + ex.Message);
            }
        }

        internal static void InsertOrUpdate(Model.Archive.Info info, Model.Archive.ArchiveDataClassesDataContext dc)
        {
            try
            {
                if (info == null)
                    return;
                var query = dc.Infos.Where(t => t.PersonnelNumber == info.PersonnelNumber);
                if (query.Count() == 1)
                {
                    var originalInfo = query.Single();
                    Model.Archive.Info.Copy(originalInfo, info);
                    dc.SubmitChanges();
                }
                else
                {
                    dc.Infos.InsertOnSubmit(info);
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }
    }

}
