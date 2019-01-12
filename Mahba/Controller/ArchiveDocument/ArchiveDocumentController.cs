using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.ArchiveDocument
{
    static class ArchiveDocumentController
    {
        internal static string GetNewArchiveDocumentDatabaseName(Model.Common.ArchiveCommonDataClassesDataContext dc)
        {
            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(dc.Connection, dc.Transaction);
            string[] databases = dc.GetDatabaseList();
            int index = 1;
            string name = "ArchiveDocument" + index.ToString();
            do
            {
                if (databases.Contains(name))
                {
                    index++;
                    name = "ArchiveDocument" + index.ToString();
                }
                else
                    break;
            }
            while (true);
            return name;
        }

        internal static byte[] GetDocumentData(int archiveDocumentID)
        {
            Model.Archive.Document doc = Controller.Archive.DocumentController.GetDocument(archiveDocumentID);
            using (var dc = Model.ArchiveDocument.DocumentDataClassesDataContext.GetNewInstance(doc.Dossier.FilesPathOrDatabaseName))
            {
                return dc.Documents.Where(t => t.ArchiveDocumentID == archiveDocumentID).Single().Data.ToArray();
            }
        }
    }
}
