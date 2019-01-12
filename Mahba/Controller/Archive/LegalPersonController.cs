using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    public static class LegalPersonController
    {
        public static List<Model.Archive.LegalPersonView> GetLegalPersons()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.LegalPersonViews.ToList();
        }

        internal static Model.Archive.LegalPerson GetLegalPerson(int id)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.LegalPersons.Where(t => t.Id == id).Single();
        }

        internal static int Add(Model.Archive.LegalPerson legalPerson)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.LegalPersons.InsertOnSubmit(Model.Archive.LegalPerson.GetNewInstance(legalPerson.Name, legalPerson.CompanyNumber, legalPerson.EconomicNumber, legalPerson.Address, legalPerson.Tel, legalPerson.Manager, legalPerson.ManagerTel));
            dc.SubmitChanges();
            return legalPerson.Id;
        }

        internal static int Update(Model.Archive.LegalPerson legalPerson, int id)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            legalPerson.Id = id;
            Model.Archive.LegalPerson originalPerson = dc.LegalPersons.Where(t => t.Id == id).Single();
            Model.Archive.LegalPerson.Copy(originalPerson, legalPerson);
            dc.SubmitChanges();
            return id;
        }

        internal static void Delete(Model.Archive.LegalPerson legalPerson)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.LegalPersons.DeleteOnSubmit(dc.LegalPersons.Where(t => t.Id == legalPerson.Id).Single());
            dc.SubmitChanges();
        }

        internal static object TryGetLegalPerson(string p)
        {
            if (p.IsNullOrEmpty())
                return null;
            int? id = p.TryToInt();
            if (id.HasValue)
            {
                var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                var query = dc.LegalPersonViews.Where(t => t.Id == id.Value);
                if (query.Count() == 1)
                    return query.Single().Name;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
