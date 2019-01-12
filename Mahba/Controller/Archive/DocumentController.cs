using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Linq;
using NjitSoftware.Model.Archive;

namespace NjitSoftware.Controller.Archive
{
    class DocumentController
    {
        internal static IEnumerable<Model.Archive.Document> GetDocuments()
        {
            return Model.Archive.ArchiveDataClassesDataContext.GetNewInstance().Documents;
        }

        internal static IEnumerable<Model.Archive.Document> GetDocuments(string personnelNumber)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.PersonnelNumber == personnelNumber).OrderBy(t => t.Index);
        }
        internal static IEnumerable<Model.Archive.Document> GetDocumentsWithoutChilds(string personnelNumber)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.PersonnelNumber == personnelNumber && t.ParentDocumentID == null).OrderBy(t => t.Index);
        }
        /// <summary>
        /// تعداد اسناد اصلی یک پرونده( بدون بچه) 
        /// </summary>
        /// <param name="personnelNumber"></param>
        /// <returns></returns>
        internal static int GetNumberOfDocument(string personnelNumber)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.PersonnelNumber == personnelNumber && t.ParentDocumentID == null).Count();
        }
        internal static IEnumerable<Model.Archive.Document> GetDocuments(string personnelNumber, int index)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.PersonnelNumber == personnelNumber && t.Index == index).OrderBy(t => t.Index);
        }
        internal static Model.Archive.Document GetDocument(int DocumentID)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.ID == DocumentID).Single();
        }

        internal static string GetMaxDocumentNumber(string PersonnelNumber)
        {
            using (var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance())
            {
                var query = dc.Documents.Where(t => t.PersonnelNumber == PersonnelNumber).Select(t => t.Number);
                long max = 0;
                long temp = 0;
                foreach (var number in query)
                {
                    temp = long.Parse(number);
                    if (temp > max)
                        max = temp;
                }
                return max.ToString();
            }
        }

        internal static IEnumerable<Model.Archive.Document> GetDocuments(string personnelNumber, SearchField searchField)
        {
            return SqlHelper.GetDocumentList(personnelNumber, searchField);
        }

        internal static Model.Archive.Document GetDocument(string personnelNumber, string number)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.PersonnelNumber == personnelNumber && t.Number == number).Single();
        }

        internal static Model.Archive.Document GetDocument(string personnelNumber, int index)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.PersonnelNumber == personnelNumber&& t.Index==index).Single();
        }

        internal static System.Drawing.Image GetDocumentThumb(Model.Archive.Document doc)
        {
            return GetDocumentThumb(doc, new Size(Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom));
        }

        internal static System.Drawing.Image GetDocumentThumb(Model.Archive.Document doc, Size size)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
            {
                try
                {
                    string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
                    switch (fileExtension)
                    {
                        case ".bmp":
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".gif":
                        case ".tif":
                        case ".tiff":
                            var documentDc = Model.ArchiveDocument.DocumentDataClassesDataContext.GetNewInstance(doc.Dossier.FilesPathOrDatabaseName);
                            var query = documentDc.Documents.Where(t => t.ArchiveDocumentID == doc.ID);
                            if (query.Count() != 1)
                                return null;
                            MemoryStream ms = new MemoryStream(query.Single().Data.ToArray());
                            Image img = Image.FromStream(ms);
                            Image thumb = Njit.Common.Helpers.ImageHelper.GetThumbnail(img, size, Color.White);
                            img.Dispose();
                            ms.Dispose();
                            documentDc.Dispose();
                            return thumb;
                    }
                    Njit.Common.RegisteredFileType.EmbeddedIconInfo _EmbeddedIconInfo = Njit.Common.RegisteredFileType.GetExtensionDefaultIcon(fileExtension);
                    if (_EmbeddedIconInfo == null)
                        return null;
                    Icon icon = Njit.Common.RegisteredFileType.ExtractIconFromFile(_EmbeddedIconInfo, true);
                    if (icon == null)
                        return null;
                    return (icon).ToBitmap();
                }
                catch (Exception ex)
                {
                    return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("خطا در دریافت تصویر" + "\r\n" + ex.Message, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                }
            }
            else
            {
                try
                {
                    Njit.Common.SystemUtility sysUtil;
                    try
                    {
                        sysUtil = Njit.Program.Options.GetSystemUtility(dc.Connection as SqlConnection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                    }
                    catch (Exception ex)
                    {
                        return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("خطا در دریافت تصویر" + "\r\n" + ex.Message, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                    }
                    string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
                    string path = Path.Combine(doc.Dossier.FilesPathOrDatabaseName, System.IO.Path.GetFileName(doc.FileName));
                    if (!sysUtil.DirectoryExists(doc.Dossier.FilesPathOrDatabaseName))
                        return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("مسیر ذخیره فایل ها وجود ندارد", Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                    if (!sysUtil.FileExists(path))
                        return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("فایل سند پیدا نشد", Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                    switch (fileExtension)
                    {
                        case ".bmp":
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".gif":
                        case ".tif":
                        case ".tiff":
                            FileStream stream = null;
                            Image thumb;
                            try
                            {
                                stream = sysUtil.OpenFile(path);
                                System.Drawing.Image img = Image.FromStream(stream);
                                thumb = Njit.Common.Helpers.ImageHelper.GetThumbnail(img, size, Color.White);
                                img.Dispose();
                            }
                            catch (Exception ex)
                            {
                                return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("خطا در دریافت تصویر" + "\r\n" + ex.Message, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                            }
                            finally
                            {
                                if (stream != null)
                                    stream.Dispose();
                            }
                            return thumb;
                    }
                    Icon icon = sysUtil.GetFileIcon(path);
                    if (icon == null)
                        return null;
                    return icon.ToBitmap();
                }
                catch (Exception ex)
                {
                    return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("خطا در دریافت تصویر" + "\r\n" + ex.Message, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                }
            }
        }

        internal static int GetChildDocumentsCount(int id)
        {
            try
            {
                var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                return dc.Documents.Where(t => t.ParentDocumentID == id).Count();
            }
            catch { return 0; }
        }
        internal static List<Model.Archive.Document> GetChildDocuments(int id)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.Documents.Where(t => t.ParentDocumentID == id).ToList();
        }
        
        internal static Image GetDocumentImage(Model.Archive.Document doc)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
            {
                try
                {
                    string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
                    switch (fileExtension)
                    {
                        case ".bmp":
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".gif":
                        case ".tif":
                        case ".tiff":
                            var documentDc = Model.ArchiveDocument.DocumentDataClassesDataContext.GetNewInstance(doc.Dossier.FilesPathOrDatabaseName);
                            var query = documentDc.Documents.Where(t => t.ArchiveDocumentID == doc.ID);
                            if (query.Count() != 1)
                                return null;
                            MemoryStream ms = new MemoryStream(query.Single().Data.ToArray());
                            Image img = Image.FromStream(ms);
                            documentDc.Dispose();
                            return img;
                    }
                    Njit.Common.RegisteredFileType.EmbeddedIconInfo _EmbeddedIconInfo = Njit.Common.RegisteredFileType.GetExtensionDefaultIcon(fileExtension);
                    if (_EmbeddedIconInfo == null)
                        return null;
                    Icon icon = Njit.Common.RegisteredFileType.ExtractIconFromFile(_EmbeddedIconInfo, true);
                    if (icon == null)
                        return null;
                    return (icon).ToBitmap();
                }
                catch (Exception ex)
                {
                    return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("خطا در دریافت تصویر" + "\r\n" + ex.Message, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                }
            }
            else
            {
                Njit.Common.SystemUtility sysUtil;
                try
                {
                    sysUtil = Njit.Program.Options.GetSystemUtility(dc.Connection as SqlConnection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                }
                catch (Exception ex)
                {
                    return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("خطا در دریافت تصویر" + "\r\n" + ex.Message, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                }
                string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
                string path = Path.Combine(doc.Dossier.FilesPathOrDatabaseName, System.IO.Path.GetFileName(doc.FileName));
                if (!sysUtil.DirectoryExists(doc.Dossier.FilesPathOrDatabaseName))
                    return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("مسیر ذخیره فایل ها وجود ندارد", Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                if (!sysUtil.FileExists(path))
                    return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("فایل سند پیدا نشد", Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                switch (fileExtension)
                {
                    case ".bmp":
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                    case ".tif":
                    case ".tiff":
                        System.IO.FileStream fileStream = null;
                        System.Drawing.Image img = null;
                        try
                        {
                            fileStream = sysUtil.OpenFile(path);
                            img = Image.FromStream(fileStream);
                        }
                        catch (Exception ex)
                        {
                            if (img != null)
                                img.Dispose();
                            if (fileStream != null)
                                fileStream.Dispose();
                            return Njit.Common.Helpers.GraphicsHelper.GetErrorImage("خطا در دریافت تصویر" + "\r\n" + ex.Message, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom, Setting.User.ThisProgram.LoadedUserSetting.ArchiveDocumentsZoom);
                        }
                        return img;
                }
                Icon icon = sysUtil.GetFileIcon(path);
                if (icon == null)
                    return null;
                return icon.ToBitmap();
            }
        }


        internal static bool DocumentIsImage(Model.Archive.Document doc)
        {
            string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
            switch (fileExtension)
            {
                case ".bmp":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".tif":
                case ".tiff":
                    return true;
                default:
                    return false;
            }
        }

        internal static bool DocumentIsPdf(Model.Archive.Document doc)
        {
            string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
            switch (fileExtension)
            {
                case ".pdf":
                    return true;
                default:
                    return false;
            }
        }

        internal static string CopyDocumentToTempPath(Model.Archive.Document doc)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "~Mahba");
            if (!System.IO.Directory.Exists(tempPath))
                System.IO.Directory.CreateDirectory(tempPath);
            string tempFile = Path.Combine(tempPath, System.IO.Path.GetFileName(doc.FileName));

            using (var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance())
            {
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                {
                    try
                    {
                        var documentDc = Model.ArchiveDocument.DocumentDataClassesDataContext.GetNewInstance(doc.Dossier.FilesPathOrDatabaseName);
                        var query = documentDc.Documents.Where(t => t.ArchiveDocumentID == doc.ID);
                        if (query.Count() != 1)
                            throw new Exception("فایل سند در پایگاه داده موجود نیست");
                        System.IO.File.WriteAllBytes(tempFile, query.Single().Data.ToArray());
                        documentDc.Dispose();
                        return tempFile;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("خطا در دریافت فایل از پایگاه داده" + "\r\n" + ex.Message);
                    }
                }
                else
                {
                    Njit.Common.SystemUtility sysUtil;
                    try
                    {
                        sysUtil = Njit.Program.Options.GetSystemUtility(dc.Connection as SqlConnection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("خطا در اتصال به سرور" + "\r\n" + ex.Message);
                    }
                    string path = Path.Combine(doc.Dossier.FilesPathOrDatabaseName, System.IO.Path.GetFileName(doc.FileName));
                    if (!sysUtil.DirectoryExists(doc.Dossier.FilesPathOrDatabaseName))
                        throw new Exception("مسیر ذخیره فایل ها وجود ندارد");
                    if (!sysUtil.FileExists(path))
                        throw new Exception("فایل سند پیدا نشد");
                    System.IO.FileStream fileStream = null;
                    try
                    {
                        fileStream = sysUtil.OpenFile(path);
                    }
                    catch (Exception ex)
                    {
                        if (fileStream != null)
                            fileStream.Dispose();
                        throw new Exception("خطا در بازکردن فایل" + "\r\n" + ex.Message);
                    }
                    System.IO.FileStream newFileStream = null;
                    try
                    {
                        newFileStream = new FileStream(tempFile, FileMode.Create);
                        int readCount = 0;
                        byte[] buffer = new byte[32768];
                        do
                        {
                            readCount = fileStream.Read(buffer, 0, buffer.Length);
                            newFileStream.Write(buffer, 0, readCount);
                        }
                        while (readCount > 0);
                        fileStream.Close();
                        newFileStream.Flush();
                        newFileStream.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("خطا در ذخیره فایل" + "\r\n" + ex.Message);
                    }
                    finally
                    {
                        if (fileStream != null)
                            fileStream.Dispose();
                        if (newFileStream != null)
                            newFileStream.Dispose();
                    }
                    return tempFile;
                }
            }
        }

        static string[] imageExtensions = new string[] { ".bmp", ".jpg", ".jpeg", ".png", ".gif", ".tif", ".tiff" };

        public static string GetUniqFileName(string extension)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "~MAHBA");
            if (!System.IO.Directory.Exists(tempDirectory))
                System.IO.Directory.CreateDirectory(tempDirectory);
            string fileName = Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true, true);
            string documentPath = Path.Combine(tempDirectory, fileName + extension).ToString();
            int i = 0;
            while (System.IO.File.Exists(documentPath))
            {
                documentPath = Path.Combine(tempDirectory, fileName + "(" + (++i).ToString() + ")" + extension).ToString();
            }
            return documentPath;
        }

        internal static Document AddDocument(string personnelNumber, string file, int? parentDocumentID, bool attachToDossier, Njit.Program.ComponentOne.Enums.SaveFormats imageFormat, Njit.Program.ComponentOne.Enums.CompressionTypes imageCompression,ArchiveTab archivetab)
        {
            System.IO.FileInfo fileInfo = new FileInfo(file);
            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.MaxDocumentsSize > 0)
                if (fileInfo.Length / 1024 > Setting.Archive.ThisProgram.LoadedArchiveSettings.MaxDocumentsSize)
                    throw new Exception(string.Format("حجم فایل نباید از {0} کیلوبایت بیشتر باشد\r\nحجم این فایل {1} کیلوبایت است", Setting.Archive.ThisProgram.LoadedArchiveSettings.MaxDocumentsSize, fileInfo.Length / 1024));
            long number = Controller.Archive.DocumentController.GetNewDocumentNumber(personnelNumber);
            string fileExtension = Path.GetExtension(file).ToLower();
            Model.Archive.Dossier dossier = Controller.Archive.DossierController.Select(personnelNumber);
            if (imageExtensions.Contains(fileExtension))
            {
                switch (imageFormat)
                {
                    case Njit.Program.ComponentOne.Enums.SaveFormats.None:
                        break;
                    case Njit.Program.ComponentOne.Enums.SaveFormats.OnePdf:
                        if (fileExtension != ".pdf")
                        {
                            fileExtension = ".pdf";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Pdf.CreatePDF.FromImages(new Image[] { image }, newfile, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.OriginalSize);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Njit.Program.ComponentOne.Enums.SaveFormats.Pdf:
                        if (fileExtension != ".pdf")
                        {
                            fileExtension = ".pdf";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Pdf.CreatePDF.FromImages(new Image[] { image }, newfile, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.OriginalSize);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Njit.Program.ComponentOne.Enums.SaveFormats.OneMultiTiff:
                        if (fileExtension != ".tiff" && fileExtension != ".tif")
                        {
                            fileExtension = ".tiff";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Tiff, GetImageCompression(imageCompression), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Njit.Program.ComponentOne.Enums.SaveFormats.Tiff:
                        if (fileExtension != ".tiff" && fileExtension != ".tif")
                        {
                            fileExtension = ".tiff";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Tiff, GetImageCompression(imageCompression), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Njit.Program.ComponentOne.Enums.SaveFormats.JPEG:
                        if (fileExtension != ".jpg" && fileExtension != ".jpeg")
                        {
                            fileExtension = ".jpg";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Jpeg, GetImageCompression(imageCompression), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Njit.Program.ComponentOne.Enums.SaveFormats.PNG:
                        if (fileExtension != ".png")
                        {
                            fileExtension = ".png";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Png, GetImageCompression(imageCompression), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    case Njit.Program.ComponentOne.Enums.SaveFormats.BMP:
                        if (fileExtension != ".bmp")
                        {
                            fileExtension = ".bmp";
                            string newfile = GetUniqFileName(fileExtension);
                            Image image = Image.FromFile(file);
                            Njit.Common.Helpers.ImageHelper.ConvertImage(image, System.Drawing.Imaging.ImageFormat.Bmp, GetImageCompression(imageCompression), newfile);
                            image.Dispose();
                            file = newfile;
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }
            string fileNameToSaveInDatabase = Njit.Common.PublicMethods.ReplaceInvalidPathAndFileNameChars(personnelNumber, "-") + "-" + number.ToString() + fileExtension;
            string destinationFile = null;
            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase == false)
            {
                destinationFile = Path.Combine(dossier.FilesPathOrDatabaseName, fileNameToSaveInDatabase);
                Njit.Common.SystemUtility sysUtility = Njit.Program.Options.GetSystemUtility(DataAccess.ArchiveDataAccess.GetNewInstance().Connection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                int i = 1;
                while (sysUtility.FileExists(destinationFile))
                {
                    fileNameToSaveInDatabase = Njit.Common.PublicMethods.ReplaceInvalidPathAndFileNameChars(personnelNumber, "-") + "-" + number.ToString() + " (" + i.ToString() + ")" + fileExtension;
                    destinationFile = Path.Combine(dossier.FilesPathOrDatabaseName, fileNameToSaveInDatabase);
                    i++;
                }
            }

            Model.Archive.Document document = Model.Archive.Document.GetNewInstance(personnelNumber, number.ToString(), fileNameToSaveInDatabase, archivetab.ID, attachToDossier, parentDocumentID, Controller.Archive.DocumentController.GetMaxDocumentIndex(personnelNumber) + 1);

            var archiveDc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            Model.ArchiveDocument.DocumentDataClassesDataContext documentDc = null;
            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                documentDc = Model.ArchiveDocument.DocumentDataClassesDataContext.GetNewInstance(Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName);

            archiveDc.Connection.Open();
            archiveDc.Transaction = archiveDc.Connection.BeginTransaction();
            if (documentDc != null)
            {
                documentDc.Connection.Open();
                documentDc.Transaction = documentDc.Connection.BeginTransaction();
            }
            try
            {
                archiveDc.Documents.InsertOnSubmit(document);
                archiveDc.SubmitChanges();
                archiveDc.Transaction.Commit();
                if (documentDc != null)
                {
                    Model.ArchiveDocument.Document doc = Model.ArchiveDocument.Document.GetNewInstance(document.ID, new System.Data.Linq.Binary(System.IO.File.ReadAllBytes(file)));
                    documentDc.Documents.InsertOnSubmit(doc);
                    documentDc.SubmitChanges();
                    documentDc.Transaction.Commit();
                }
             
            }
            catch (Exception ex)
            {
                archiveDc.Transaction.Rollback();
                if (documentDc != null)
                    documentDc.Transaction.Rollback();
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                archiveDc.Connection.Close();
                if (documentDc != null)
                    documentDc.Connection.Close();
            }
            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase == false)
            {
                FileStream serverFileStream = null;
                FileStream clientFileStream = null;
                try
                {
                    Njit.Common.SystemUtility sysUtility = Njit.Program.Options.GetSystemUtility(DataAccess.ArchiveDataAccess.GetNewInstance().Connection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                    if (!sysUtility.DirectoryExists(dossier.FilesPathOrDatabaseName))
                        sysUtility.CreateDirectory(dossier.FilesPathOrDatabaseName);
                    serverFileStream = sysUtility.CreateFile(destinationFile);
                    clientFileStream = File.OpenRead(file);
                    byte[] buffre = new byte[1 * 1024 * 1024];
                    int readCount = 0;
                    do
                    {
                        readCount = clientFileStream.Read(buffre, 0, buffre.Length);
                        serverFileStream.Write(buffre, 0, readCount);
                    }
                    while (readCount > 0);
                    clientFileStream.Close();
                    serverFileStream.Close();
                    clientFileStream.Dispose();
                    serverFileStream.Dispose();
                }
                catch (Exception ex)
                {
                    if (clientFileStream != null)
                        clientFileStream.Dispose();
                    if (serverFileStream != null)
                        serverFileStream.Dispose();
                    throw new Exception("خطا در ذخیره فایل" + "\r\n" + file + "\r\n\r\n" + ex.Message);
                }
            }
            return document;
        }

        private static Njit.Common.Helpers.ImageHelper.CompressionTypes GetImageCompression(Njit.Program.ComponentOne.Enums.CompressionTypes imageCompression)
        {
            switch (imageCompression)
            {
                case Njit.Program.ComponentOne.Enums.CompressionTypes.None:
                    return Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionNone;
                case Njit.Program.ComponentOne.Enums.CompressionTypes.LZW:
                    return Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionLZW;
                case Njit.Program.ComponentOne.Enums.CompressionTypes.CCITT4:
                    return Njit.Common.Helpers.ImageHelper.CompressionTypes.CompressionCCITT4;
                default:
                    throw new Exception();
            }
        }

        internal static void Update(Model.Archive.Document document)
        {
            try
            {
                Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                Model.Archive.Document.Copy(dc.Documents.Where(t => t.ID == document.ID).FirstOrDefault(), document);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        internal static void Update(Model.Archive.ArchiveDataClassesDataContext dc, Model.Archive.Document document)
        {
            try
            {
                Model.Archive.Document.Copy(dc.Documents.Where(t => t.ID == document.ID).Single(), document);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }

        internal static void UpdateDocument(Model.Archive.Document document, List<System.Data.SqlClient.SqlCommand> sqlCommands)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                Model.Archive.Document.Copy(dc.Documents.Where(t => t.ID == document.ID).Single(), document);
                //------------
                foreach (System.Data.SqlClient.SqlCommand sqlCommand in sqlCommands)
                {
                    sqlCommand.Connection = dc.Connection as System.Data.SqlClient.SqlConnection;
                    sqlCommand.Transaction = dc.Transaction as System.Data.SqlClient.SqlTransaction;
                    sqlCommand.ExecuteNonQuery();
                }
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
                dc.Dispose();
            }
        }

        public static void LoadArchiveTabDataToControls(System.Windows.Forms.Control control, Model.Archive.ArchiveTab archiveTab, Model.Archive.Document document)
        {
            if (archiveTab.IsNullOrEmpty())
                return;
            if (archiveTab.ArchiveFields.Count == 0)
                return;
            System.Data.DataTable tempDataTable = SqlHelper.GetDocuments(archiveTab.Name, document);
            List<Model.Archive.ArchiveField> fields = Controller.Archive.ArchiveFieldController.GetArchiveFields(archiveTab);
            foreach (Model.Archive.ArchiveField field in fields)
            {
                if (field.BoxTypeCode == (int)Enums.BoxTypes.کادر_ورود_اطلاعات_گروهی)
                {
                    System.Data.DataTable DataTableSubGroup = SqlHelper.GetDocuments(field.FieldName, document);
                    Njit.Program.Controls.DataGridViewExtended subGroupDataGridView = control.Controls[field.FieldName].Controls[field.FieldName] as Njit.Program.Controls.DataGridViewExtended;
                    subGroupDataGridView.Rows.Clear();
                    List<Model.Archive.ArchiveSubGroupField> SubGroupFields = Controller.Archive.DossierCacheController.GetSubGroupFields(field.ID);
                    foreach (System.Data.DataRow row in DataTableSubGroup.Rows)
                    {
                        subGroupDataGridView.Rows.Add();
                        int CurrentRowIndex = subGroupDataGridView.RowCount - 2;
                        foreach (Model.Archive.ArchiveSubGroupField SubGroupField in SubGroupFields)
                        {
                            subGroupDataGridView.Rows[CurrentRowIndex].Cells[SubGroupField.FieldName].Value = row[SubGroupField.FieldName].ToString();
                        }
                    }
                    subGroupDataGridView.BestFitColumns();
                }
                else if (tempDataTable.Rows.Count > 0)
                {
                    if (field.FieldName != "Field4" && field.FieldName != "Field5" && field.FieldName != "Field6")
                    {
                        control.Controls[field.FieldName].Text = tempDataTable.Rows[0][field.FieldName].ToString();
                    }
                }
            }
        }

        internal static int GetMaxDocumentIndex(string personnelNumber)
        {
            using (var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance())
            {
                var query = dc.Documents.Where(t => t.PersonnelNumber == personnelNumber).Select(t => t.Index);
                return query.Count() == 0 ? 0 : query.Max();
            }
        }

        internal static long GetNewDocumentNumber(string personnelNumber)
        {
            long num = long.Parse(GetMaxDocumentNumber(personnelNumber));
            return num + 1;
        }

        internal static void Delete(int id)
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            try
            {
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                Delete(dc, id);
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            catch
            {
                dc.Transaction.Rollback();
                dc.Connection.Close();
                throw;
            }
            finally
            {
                dc.Dispose();
            }
        }

        internal static void Delete(Model.Archive.ArchiveDataClassesDataContext dc, int id)
        {
            Model.Archive.Document doc = dc.Documents.Where(t => t.ID == id).Single();
            Model.Archive.Dossier dossier = dc.Dossiers.Where(t => t.PersonnelNumber == doc.PersonnelNumber).Single();

            int childCount = dc.Documents.Where(t => t.ParentDocumentID == id).Count();
            if (childCount > 0)
                throw new Exception("تعداد " + childCount.ToString() + " سند به عنوان ضمیمه به سند شماره " + doc.Index + " افزوده شده است" + "\r\n" + "برای حذف سند شماره " + doc.Index + " ابتدا باید سندهای ضمیمه را حذف کنید");
            dc.Documents.DeleteOnSubmit(doc);
            dc.SubmitChanges();

            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
            {
                try
                {
                    Model.ArchiveDocument.DocumentDataClassesDataContext documentsDc = Model.ArchiveDocument.DocumentDataClassesDataContext.GetNewInstance(dossier.FilesPathOrDatabaseName);
                    documentsDc.Documents.DeleteAllOnSubmit(documentsDc.Documents.Where(t => t.ArchiveDocumentID == id));
                    documentsDc.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("خطا در حذف فایل سند شماره " + doc.Index + "\r\n" + ex.Message);
                }
            }
            else
            {
                Njit.Common.SystemUtility sysUtil;
                try
                {
                    sysUtil = Njit.Program.Options.GetSystemUtility(dc.Connection as SqlConnection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                }
                catch (Exception ex)
                {
                    throw new Exception("خطا در اتصال به سرور" + "\r\n" + ex.Message);
                }
                if (sysUtil.FileExists(Path.Combine(dossier.FilesPathOrDatabaseName, doc.FileName)))
                {
                    try
                    {
                        
                        //sysUtil.DeleteFile(Path.Combine(dossier.FilesPathOrDatabaseName, doc.FileName));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("خطا در حذف فایل سند شماره " + doc.Index + "\r\n" + ex.Message);
                    }
                }
            }
        }

        internal static int GetDocumentsCount()
        {
            using (var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance())
            {
                return dc.Documents.Count(t => t.ParentDocumentID == null);
            }
        }

        internal static int GetDocumentsCount(string personnelNumber)
        {
            using (var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance())
            {
                return dc.Documents.Where(t => t.PersonnelNumber == personnelNumber && t.ParentDocumentID == null).Count();
            }
        }

        internal static int GetArchiveDocumentsCount(string archiveName)
        {
            using (var dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.GetDatabaseConnection(archiveName).ConnectionString))
            {
                return dc.Documents.Count(t => t.ParentDocumentID == null);
            }
        }

        internal static byte[] GetDocumentImageBytes(Model.Archive.Document doc)
        {
            using (var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance())
            {
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
                {
                    string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
                    switch (fileExtension)
                    {
                        case ".bmp":
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".gif":
                        case ".tif":
                        case ".tiff":
                            var documentDc = Model.ArchiveDocument.DocumentDataClassesDataContext.GetNewInstance(doc.Dossier.FilesPathOrDatabaseName);
                            var query = documentDc.Documents.Where(t => t.ArchiveDocumentID == doc.ID);
                            if (query.Count() != 1)
                                return null;
                            return query.Single().Data.ToArray();
                    }
                    return null;
                }
                else
                {
                    Njit.Common.SystemUtility sysUtil;
                    sysUtil = Njit.Program.Options.GetSystemUtility(dc.Connection as SqlConnection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                    string fileExtension = System.IO.Path.GetExtension(doc.FileName).ToLower();
                    string path = Path.Combine(doc.Dossier.FilesPathOrDatabaseName, System.IO.Path.GetFileName(doc.FileName));
                    if (!sysUtil.DirectoryExists(doc.Dossier.FilesPathOrDatabaseName))
                        throw new Exception("مسیر ذخیره فایل ها وجود ندارد");
                    if (!sysUtil.FileExists(path))
                        throw new Exception("فایل سند پیدا نشد");
                    switch (fileExtension)
                    {
                        case ".bmp":
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                        case ".gif":
                        case ".tif":
                        case ".tiff":
                            return sysUtil.ReadFileBytes(path);
                    }
                    return null;
                }
            }
        }

        internal static string GetArchiveDocumentsSize(string archiveName)
        {
            long size = GetArchiveDocumentsBytesCount(archiveName);
            return Njit.Common.PublicMethods.GetBytesText(size, false);
        }

        internal static long GetArchiveDocumentsBytesCount(string archiveName)
        {
            long size = 0;
            using (var dc = new Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.GetDatabaseConnection(archiveName).ConnectionString))
            {
                bool useDatabase = true;
                if (dc.ArchiveSettings.Count() > 0)
                    useDatabase = dc.ArchiveSettings.First().UseDatabase;
                if (useDatabase)
                {
                    var docDC = new Model.ArchiveDocument.DocumentDataClassesDataContext(Setting.Sql.ThisProgram.GetDatabaseConnection(dc.ArchiveSettings.First().DocumentsPathOrDatabaseName).ConnectionString);
                    int index = 0;
                    foreach (var id in dc.Documents.Select(t => t.ID))
                    {
                        var query = docDC.Documents.Where(t => t.ArchiveDocumentID == id);
                        if (query.Count() == 1)
                        {
                            size += query.Single().Data.Length;
                        }
                        index++;
                        if (index % 30 == 0)
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    }
                }
                else
                {
                    foreach (var item in dc.Documents)
                    {
                        string file = Path.Combine(item.Dossier.FilesPathOrDatabaseName, item.FileName);
                        System.IO.FileInfo fileInfo = new FileInfo(file);
                        if (fileInfo.Exists)
                            size += fileInfo.Length;
                    }
                }
            }
            return size;
        }
    }
}
