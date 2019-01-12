using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    public static class RightfulPersonController
    {
        public static List<Model.Archive.RightfulPersonView> GetRightfulPersons()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.RightfulPersonViews.ToList();
        }

        internal static Model.Archive.RightfulPerson GetRightfulPerson(int id)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.RightfulPersons.Where(t => t.Id == id).Single();
        }

        internal static int Add(Model.Archive.RightfulPerson rightfulPerson)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.RightfulPersons.InsertOnSubmit(Model.Archive.RightfulPerson.GetNewInstance(rightfulPerson.Firstname, rightfulPerson.Lastname, rightfulPerson.Fathername, rightfulPerson.NationalCode, rightfulPerson.IdentityNumber, rightfulPerson.Birthdate, rightfulPerson.Address, rightfulPerson.Tel, rightfulPerson.Mobile, rightfulPerson.WorkAddress, rightfulPerson.BackAccount));
            dc.SubmitChanges();
            return rightfulPerson.Id;
        }

        internal static int Update(Model.Archive.RightfulPerson rightfulPerson, int id)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            rightfulPerson.Id = id;
            Model.Archive.RightfulPerson originalPerson = dc.RightfulPersons.Where(t => t.Id == id).Single();
            Model.Archive.RightfulPerson.Copy(originalPerson, rightfulPerson);
            dc.SubmitChanges();
            return id;
        }

        internal static void Delete(Model.Archive.RightfulPerson rightfulPerson)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.RightfulPersons.DeleteOnSubmit(dc.RightfulPersons.Where(t => t.Id == rightfulPerson.Id).Single());
            dc.SubmitChanges();
        }

        internal static object TryGetRightfulPerson(string p)
        {
            if (p.IsNullOrEmpty())
                return null;
            int? id = p.TryToInt();
            if (id.HasValue)
            {
                var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                var query = dc.RightfulPersonViews.Where(t => t.Id == id.Value);
                if (query.Count() == 1)
                    return query.Single().Fullname;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
