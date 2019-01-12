using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class ReportController
    {
        internal static Model.Archive.Report AddReport(string name, List<SearchField> searchFields, List<Model.Archive.ArchiveField> displayFields)
        {
            Model.Archive.Report report = null;
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                if (dc.Reports.Where(t => t.Title == name).Count() == 1)
                    DeleteReport(dc, dc.Reports.Where(t => t.Title == name).Single().ID);
                report = Model.Archive.Report.GetNewInstance(name);
                dc.Reports.InsertOnSubmit(report);
                dc.SubmitChanges();
                foreach (SearchField item in searchFields)
                {
                    AddDetailToReport(dc, report, item);
                }
                foreach (var item in displayFields)
                {
                    Model.Archive.DisplayField d = Model.Archive.DisplayField.GetNewInstance((int)Enums.DisplayFieldCodes.گزارشات, report.ID, item.ID);
                    dc.DisplayFields.InsertOnSubmit(d);
                }
                dc.SubmitChanges();
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
            dc.Transaction.Commit();
            dc.Connection.Close();
            return report;
        }

        private static void AddDetailToReport(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.Report report, SearchField searchField)
        {
            Model.Archive.ReportDetail reportDetail = Model.Archive.ReportDetail.GetNewInstance(report.ID, searchField.Field.ID, (int)searchField.Relation, searchField.Method.Code, searchField.Value, null);
            dc.ReportDetails.InsertOnSubmit(reportDetail);
            dc.SubmitChanges();
            foreach (var item in searchField.SearchFields)
            {
                AddDetailToDetail(dc, reportDetail, item);
            }
        }

        private static void AddDetailToDetail(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ReportDetail reportDetail, SearchField searchField)
        {
            Model.Archive.ReportDetail newReportDetail = Model.Archive.ReportDetail.GetNewInstance(null, searchField.Field.ID, (int)searchField.Relation, searchField.Method.Code, searchField.Value, reportDetail.ID);
            dc.ReportDetails.InsertOnSubmit(newReportDetail);
            dc.SubmitChanges();
            foreach (var item in searchField.SearchFields)
            {
                AddDetailToDetail(dc, newReportDetail, item);
            }
        }

        private static void DeleteReport(Model.Archive.ArchiveDataClassesDataContext dc, int reportID)
        {
            dc.DisplayFields.DeleteAllOnSubmit(dc.DisplayFields.Where(t => t.ReportID == reportID));
            dc.SubmitChanges();
            foreach (Model.Archive.ReportDetail item in dc.ReportDetails.Where(t => t.ReportID == reportID && t.ParentID == null))
            {
                DeleteReportDetails(dc, item);

                dc.ReportDetails.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
            dc.Reports.DeleteOnSubmit(dc.Reports.Where(t => t.ID == reportID).Single());
            dc.SubmitChanges();
        }

        private static void DeleteReportDetails(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ReportDetail reportDetail)
        {
            foreach (var item in dc.ReportDetails.Where(t => t.ParentID == reportDetail.ID))
            {
                DeleteReportDetails(dc, item);

                dc.ReportDetails.DeleteOnSubmit(item);
                dc.SubmitChanges();
            }
        }

        internal static IEnumerable<Model.Archive.Report> GetReports()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Reports.OrderBy(t => t.Title);
        }

        internal static IEnumerable<SearchField> LoadReport(int reportID)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            List<SearchField> list = new List<SearchField>();
            foreach (var item in dc.ReportDetails.Where(t => t.ReportID == reportID && t.ParentID == null))
            {
                List<SearchField> searchFields = new List<SearchField>();
                LoadSearchFields(dc, item, searchFields);
                SearchField f = new SearchField(item.ArchiveField, SearchMethod.GetAllSearchMethods().Where(t => t.Code == item.MethodCode).Single(), item.Value, (SearchField.Relations)item.RelationCode, searchFields);
                list.Add(f);
            }
            return list;
        }

        private static List<SearchField> LoadSearchFields(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.ReportDetail reportDetail, List<SearchField> searchFields)
        {
            foreach (var item in dc.ReportDetails.Where(t => t.ParentID == reportDetail.ID))
            {
                List<SearchField> innerSearchFields = new List<SearchField>();
                LoadSearchFields(dc, item, innerSearchFields);
                searchFields.Add(new SearchField(item.ArchiveField, SearchMethod.GetAllSearchMethods().Where(t => t.Code == item.MethodCode).Single(), item.Value, (SearchField.Relations)item.RelationCode, innerSearchFields));
            }
            return searchFields;
        }

        internal static void DeleteReport(int reportID)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                DeleteReport(dc, reportID);
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
    }
}
