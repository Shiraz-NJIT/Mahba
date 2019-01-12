using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.FastReportExtensions.Forms
{
    public partial class PrintPreview : Njit.Program.Forms.ListForm
    {
        public PrintPreview()
        {
            DeketeFastReportConfigFile();
            FastReport.Utils.Res.LoadLocale(new System.IO.MemoryStream(Properties.Resources.Persian));
            InitializeComponent();
            this.ReportDocument = new global::FastReport.Report();
            this.ReportDocument.Preview = this.previewControl;
     
            this.previewControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        public PrintPreview(string reportFile, PrintSizes printSize, string formTitle, int printCount)
            : this()
        {
            this.DefaultPrintCount = printCount;
            this.PrintSize = printSize;
            this.ReportFileAddress = reportFile;
            if (System.IO.File.Exists(reportFile))
                this.ReportDocument.Load(reportFile);
            else
                throw new System.IO.FileNotFoundException("فایل گزارش پیدا نشد", reportFile);
            if (!string.IsNullOrEmpty(formTitle))
                this.Text = formTitle;
        }

        public enum PrintSizes
        {
            A5, A4
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.PrintSize == PrintSizes.A4)
            {
                if (Screen.PrimaryScreen.Bounds.Width > 800)
                    this.Size = new Size(875, 575);
                else
                    this.Size = new Size(800, 575);
                this.CenterToScreen();
            }
            RefreshReport();
        }

        private void RefreshReport()
        {
            this.ReportDocument.Prepare();
            this.ReportDocument.ShowPrepared();
        }

        public static void DeketeFastReportConfigFile()
        {
            string fastReportConfigFile = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\FastReport\\FastReport.config";
            if (System.IO.File.Exists(fastReportConfigFile))
            {
                try
                {
                    System.IO.File.Delete(fastReportConfigFile);
                }
                catch
                {
                }
            }
        }

        private int _DefaultPrintCount = 1;
        [DefaultValue(1)]
        public int DefaultPrintCount
        {
            get
            {
                return _DefaultPrintCount;
            }
            set
            {
                _DefaultPrintCount = value;
            }
        }

        private PrintSizes _PrintSize = PrintSizes.A5;
        [DefaultValue(typeof(PrintSizes), "A5")]
        public PrintSizes PrintSize
        {
            get
            {
                return _PrintSize;
            }
            set
            {
                _PrintSize = value;
            }
        }

        private global::FastReport.Report _ReportDocument = null;
        [DefaultValue(null)]
        public global::FastReport.Report ReportDocument
        {
            get
            {
                return _ReportDocument;
            }
            set
            {
                _ReportDocument = value;
            }
        }

        private string _ReportFileAddress = null;
        [DefaultValue(null)]
        public string ReportFileAddress
        {
            get
            {
                return _ReportFileAddress;
            }
            set
            {
                _ReportFileAddress = value;
            }
        }

    }
}
