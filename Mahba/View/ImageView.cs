using Njit.Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class ImageView : Form
    {
        private string _PersonnelNumber;
        private string PersonnelNumber
        {
            get
            {
                return _PersonnelNumber;
            }
            set
            {
                _PersonnelNumber = value;
            }
        }
        private Model.Archive.Document document;


        SqlConnectionStringBuilder _Connection;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual SqlConnectionStringBuilder Connection
        {
            get
            {
                if (_Connection == null)
                    _Connection = Options.SettingInitializer.GetSqlSetting().DatabaseConnection;
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }
        private Njit.Sql.DataAccess _DataAccess;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected Njit.Sql.DataAccess DataAccess
        {
            get
            {
                if (_DataAccess == null)
                    _DataAccess = new Njit.Sql.DataAccess(this.Connection.ConnectionString);
                return _DataAccess;
            }
            set
            {
                _DataAccess = value;
            }
        }

        public ImageView(Model.Archive.Document document, string PersonnelNumber)
        {
            this._PersonnelNumber = PersonnelNumber;
            this.document = document;
            InitializeComponent();
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            Image img = Controller.Archive.DocumentController.GetDocumentImage(document);
            mhR_ImageView1.OpenButton = false;
            Bitmap bm = new Bitmap(img);
            mhR_ImageView1.Image = bm;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            mhR_ImageView1.AutoSize = true;
            mhR_ImageView1.AutoSizeMode = AutoSizeMode.GrowOnly;
            mhR_ImageView1.PerssonelNumber = PersonnelNumber;
            //نمایش نام و نام خانوادگی
            object obj = SqlHelper.GetArchiveFieldValue("Dossier1", "Field1", PersonnelNumber);
            if (obj != null)
            {

                mhR_ImageView1.Name = obj.ToString();
                object obj2 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field2", PersonnelNumber);
                if (obj2 != null)
                {
                    mhR_ImageView1.Name += " " + obj2.ToString();
                }
            }
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.مشاهده_سند, PersonnelNumber, "مشاهده سند شماره:" + document.Number);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                mhR_ImageView1_printClick();
                return true;
            }
            if (keyData == (Keys.PageUp))
            {
                mhR_ImageView1_NextClick();
                return true;
            }
            if (keyData == (Keys.PageDown))
            {
                mhR_ImageView1_PreviewClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ImageView_Load(object sender, EventArgs e)
        {
            //زمانی که دکمه پرینت زده می شود
            mhR_ImageView1.printClick += mhR_ImageView1_printClick;
            //زمانی که بروی دکمه ذخیره کلیک می شود
            mhR_ImageView1.SaveClick += mhR_ImageView1_SaveClick;
            //زمانی که بروی عکس بعدی کلیک می شود
            mhR_ImageView1.NextClick += mhR_ImageView1_NextClick;
            //زمانی که بروی دکمه عکس قبلی کلیک می شود
            mhR_ImageView1.PreviewClick += mhR_ImageView1_PreviewClick;
            //زمانی که بروی اعلام خرابی کلیک می شود
            mhR_ImageView1.WarningClick += mhR_ImageView1_WarningClick;
        }

        void mhR_ImageView1_WarningClick()
        {
            Model.Common.DocumentsFailure df = new Model.Common.DocumentsFailure();
            df.ArchiveID = Convert.ToInt32(Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID);
            df.PerssonelNumber = this._PersonnelNumber;
            df.documentID = this.document.ID;
            df.Title = mhR_ImageView1.cmTilte;
            df.Description = mhR_ImageView1.MyWarning;
            df.UserSender = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;
            df.Userchecker = null;
            df.isRead = false;
            df.DateSender = System.DateTime.Now;
            df.DateChecker = null;
            df.DocumnetNumber = this.document.Number;
            this.DataAccess.InsertObject(df); MessageBox.Show("اعلام خرابی سند با موفقیت ثبت شد.");
        }

        void mhR_ImageView1_PreviewClick()
        {
            var docs = Controller.Archive.DocumentController.GetDocuments(this.document.PersonnelNumber).ToArray();
            if (docs.Length <= 1)
                return;
            for (int i = 0; i < docs.Length; i++)
            {
                if (docs[i].ID == this.document.ID)
                {
                    if (i == 0)
                    {
                        LoadDocument(docs[docs.Length - 1]);
                        break;
                    }
                    else
                    {
                        LoadDocument(docs[i - 1]);
                        break;
                    }
                }
            }
        }
        private void LoadDocument(Model.Archive.Document document)
        {
            this.document = document;
            Image img = Controller.Archive.DocumentController.GetDocumentImage(document);
            Bitmap bm = new Bitmap(img);
            mhR_ImageView1.Image = bm;

        }

        void mhR_ImageView1_NextClick()
        {
            var docs = Controller.Archive.DocumentController.GetDocuments(this.document.PersonnelNumber).ToArray();
            if (docs.Length <= 1)
                return;
            for (int i = 0; i < docs.Length; i++)
            {
                if (docs[i].ID == this.document.ID)
                {
                    if (i == docs.Length - 1)
                    {
                        LoadDocument(docs[0]);
                        break;
                    }
                    else
                    {
                        LoadDocument(docs[i + 1]);
                        break;
                    }
                }
            }
        }

        void mhR_ImageView1_SaveClick()
        {
            ConverAllImagesToOnePDFFile();
        }
        public string GetUniqFileName2(string extension)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save pdf Files";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "Text files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string tempDirectory = Path.Combine(saveFileDialog1.InitialDirectory, "");
                string fileName = saveFileDialog1.FileName;
                string documentPath = Path.Combine(tempDirectory, fileName + extension).ToString();
                int i = 0;
                while (System.IO.File.Exists(documentPath))
                {
                    documentPath = Path.Combine(tempDirectory, fileName + "(" + (++i).ToString() + ")" + extension).ToString();
                }
                return documentPath;
            }

            return "";
        }
        private void ConverAllImagesToOnePDFFile()
        {
            System.Drawing.Image img = Controller.Archive.DocumentController.GetDocumentImage(this.document);
            Image[] images = new Image[1];
            images[0] = img;
            this.Cursor = Cursors.WaitCursor;
            string documentPath = GetUniqFileName2(".pdf");
            Njit.Pdf.CreatePDF.FromImages(images, documentPath, 0, Njit.Pdf.CreatePDF.PageOrientation.عمودی, Njit.Pdf.CreatePDF.PageSize.A4);
            MessageBox.Show(" ذخیره شد." + documentPath + "فایل پی دی اف در مسیر");
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ذخیره_سند, this.PersonnelNumber, string.Format("ذخیره اسناد شماره {0} از پرونده {1} در بایگانی ",this.document.Number, this.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
        }
        void mhR_ImageView1_printClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Njit.Program.FastReportExtensions.Forms.PrintPreview form = new Njit.Program.FastReportExtensions.Forms.PrintPreview(Setting.Program.ThisProgram.GetReportPath("Document.frx"), Njit.Program.FastReportExtensions.Forms.PrintPreview.PrintSizes.A4, null, 1);
                form.ReportDocument.SetParameterValue("CompanyName", Setting.Archive.ThisProgram.LoadedArchiveSettings.OrganName);
                form.ReportDocument.SetParameterValue("ReportPrintDate", Njit.Common.PersianCalendar.GetDate(DateTime.Now));
                form.ReportDocument.SetParameterValue("ReportPrintTime", Njit.Common.PersianCalendar.GetTime());
                DataTable dt = new DataTable("Images");
                dt.Columns.Add("img", typeof(byte[]));
                dt.Rows.Add(Controller.Archive.DocumentController.GetDocumentImageBytes(this.document));
                form.ReportDocument.RegisterData(dt, "Images");
                form.ReportDocument.GetDataSource("Images").Enabled = true;
                form.ShowDialog(this);
                Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.چاپ, null, string.Format("چاپ اسناد شماره {0} از پرونده {1} در بایگانی ", this.document.ID, this.document.PersonnelNumber) + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            System.Drawing.Image img = Controller.Archive.DocumentController.GetDocumentImage(this.document);
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(img, loc);
        }
    }
}
