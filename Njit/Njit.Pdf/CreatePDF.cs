using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Njit.Pdf
{
    /// <summary>
    /// ساخت فایل PDF
    /// </summary>
    public static class CreatePDF
    {
        public enum PageSize
        {
            OriginalSize = 0,
            A0 = 1,
            A1 = 2,
            A2 = 3,
            A3 = 4,
            A4 = 5,
            A5 = 6,
            RA0 = 7,
            RA1 = 8,
            RA2 = 9,
            RA3 = 10,
            RA4 = 11,
            RA5 = 12,
            B0 = 13,
            B1 = 14,
            B2 = 15,
            B3 = 16,
            B4 = 17,
            B5 = 18,
            Quarto = 100,
            Foolscap = 101,
            Executive = 102,
            GovernmentLetter = 103,
            Letter = 104,
            Legal = 105,
            Ledger = 106,
            Tabloid = 107,
            Post = 108,
            Crown = 109,
            LargePost = 110,
            Demy = 111,
            Medium = 112,
            Royal = 113,
            Elephant = 114,
            DoubleDemy = 115,
            QuadDemy = 116,
            STMT = 117,
            Folio = 120,
            Statement = 121,
            Size10x14 = 122,
        }

        public enum PageOrientation
        {
            عمودی = 0,
            افقی = 1,
        }

        public static void FromImageFiles(List<string> imageFilesPath, string saveTo, int margin, PageOrientation pageOrientation, PageSize pageSize)
        {
            PdfDocument doc = new PdfDocument();
            for (int i = 0; i < imageFilesPath.Count; i++)
            {
                if (!System.IO.File.Exists(imageFilesPath[i]))
                    continue;

                doc.Pages.Add(new PdfPage());
                XImage img = XImage.FromFile(imageFilesPath[i]);

                if (pageSize == PageSize.OriginalSize)
                {
                    doc.Pages[i].Width = img.Size.Width;
                    doc.Pages[i].Height = img.Size.Height;
                }
                else
                    doc.Pages[i].Size = (global::PdfSharp.PageSize)pageSize;

                doc.Pages[i].Orientation = (global::PdfSharp.PageOrientation)pageOrientation;// Portrait Or Landscape
                XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[i]);
                xgr.DrawImage(img, margin, margin, doc.Pages[i].Width - (2 * margin), doc.Pages[i].Height - (2 * margin));
                img.Dispose();
            }
            doc.Save(saveTo);
            doc.Close();
        }

        public static void FromImages(IList<System.Drawing.Image> images, string saveTo, int margin, PageOrientation pageOrientation, PageSize pageSize)
        {
            PdfDocument doc = new PdfDocument();
            for (int i = 0; i < images.Count; i++)
            {
                doc.Pages.Add(new PdfPage());
                XImage img = images[i];

                if (pageSize == PageSize.OriginalSize)
                {
                    doc.Pages[i].Width = img.Size.Width;
                    doc.Pages[i].Height = img.Size.Height;
                }
                else
                    doc.Pages[i].Size = (global::PdfSharp.PageSize)pageSize;

                doc.Pages[i].Orientation = (global::PdfSharp.PageOrientation)pageOrientation;// Portrait Or Landscape
                XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[i]);
                xgr.DrawImage(img, margin, margin, doc.Pages[i].Width - (2 * margin), doc.Pages[i].Height - (2 * margin));
                img.Dispose();
            }
            doc.Save(saveTo);
            doc.Close();
        }

        public static byte[] FromImages(IList<System.Drawing.Image> images, int margin, PageOrientation pageOrientation, PageSize pageSize)
        {
            PdfDocument doc = new PdfDocument();
            for (int i = 0; i < images.Count; i++)
            {
                doc.Pages.Add(new PdfPage());
                XImage img = images[i];

                if (pageSize == PageSize.OriginalSize)
                {
                    doc.Pages[i].Width = img.Size.Width;
                    doc.Pages[i].Height = img.Size.Height;
                }
                else
                    doc.Pages[i].Size = (global::PdfSharp.PageSize)pageSize;

                doc.Pages[i].Orientation = (global::PdfSharp.PageOrientation)pageOrientation;// Portrait Or Landscape
                XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[i]);
                xgr.DrawImage(img, margin, margin, doc.Pages[i].Width - (2 * margin), doc.Pages[i].Height - (2 * margin));
                img.Dispose();
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            doc.Save(ms);
            doc.Close();
            ms.Close();
            return ms.ToArray();
        }
    }
}
