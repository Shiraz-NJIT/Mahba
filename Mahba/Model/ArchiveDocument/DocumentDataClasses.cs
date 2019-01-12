namespace NjitSoftware.Model.ArchiveDocument
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public partial class Document
    {
        public static Document GetNewInstance(int ID, int ArchiveDocumentID, System.Data.Linq.Binary Data)
        {
            Document _Instance = new Document();
            _Instance.ID = ID;
            _Instance.ArchiveDocumentID = ArchiveDocumentID;
            _Instance.Data = Data;
            return _Instance;
        }
        public static Document GetNewInstance(int ArchiveDocumentID, System.Data.Linq.Binary Data)
        {
            Document _Instance = new Document();
            _Instance.ArchiveDocumentID = ArchiveDocumentID;
            _Instance.Data = Data;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Document";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Document NewInstance)
        {
            DataContext.GetTable<Document>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Document OriginalInstance, Document NewInstance)
        {
            OriginalInstance.ArchiveDocumentID = NewInstance.ArchiveDocumentID;
            OriginalInstance.Data = NewInstance.Data;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Document OriginalInstance)
        {
            DataContext.GetTable<Document>().DeleteOnSubmit(OriginalInstance);
        }
    }
}
