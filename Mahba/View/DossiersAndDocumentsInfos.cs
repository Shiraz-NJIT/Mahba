using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NjitSoftware.View
{
    public partial class DossiersAndDocumentsInfos : Njit.Program.Forms.ListForm
    {
        public DossiersAndDocumentsInfos()
        {
            InitializeComponent();
        }

        private static DossiersAndDocumentsInfos _Instance;
        public static DossiersAndDocumentsInfos Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DossiersAndDocumentsInfos();
                if (_Instance.IsDisposed)
                    _Instance = new DossiersAndDocumentsInfos();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConditionalFormattingObject c1 = new ConditionalFormattingObject("Green, applied to entire row", ConditionTypes.Equal, "", "", true);
            c1.RowBackColor = Color.LightBlue;
            c1.CellBackColor = Color.LightBlue;
            radGridViewExtended.Columns["Column1"].ConditionalFormattingObjectList.Add(c1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalCount, index = 0;
            var archives = Controller.Common.ArchiveController.GetActiveArchives();
            totalCount = (archives.Length * 3) + 3;
            //List<object[]> list = new List<object[]>();
            //list.Add();
            backgroundWorker.ReportProgress(100 * ((++index) / totalCount), new object[] { "تعداد بایگانی ها", Controller.Common.ArchiveController.GetActiveArchivesCount() });
            long documnetsSize = 0;
            long documnetsCount = 0;
            for (int i = 0; i < archives.Length; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                long count = Controller.Archive.DocumentController.GetArchiveDocumentsCount(archives[i].Name);
                long size = 0;
                if ((bool)e.Argument)
                    size = Controller.Archive.DocumentController.GetArchiveDocumentsBytesCount(archives[i].Name);
                documnetsSize += size;
                documnetsCount += count;
                //list.Add();
                backgroundWorker.ReportProgress(100 * ((++index) / totalCount), new object[] { "          تعداد اسناد بایگانی '" + archives[i].Title + "'", count });

                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                //list.Add();
                backgroundWorker.ReportProgress(100 * ((++index) / totalCount), new object[] { "          تعداد پرونده های بایگانی '" + archives[i].Title + "'", Controller.Archive.DossierController.GetDossiersCount(archives[i].Name) });

                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                //list.Add();

                if ((bool)e.Argument)
                    backgroundWorker.ReportProgress(100 * ((++index) / totalCount), new object[] { "          حجم اسناد بایگانی '" + archives[i].Title + "'", Njit.Common.PublicMethods.GetBytesText(size, false) });

                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (i != archives.Length - 1)
                    backgroundWorker.ReportProgress(100 * ((++index) / totalCount), new object[] { "", "" });
                //list.Add();
            }
            //list.Add();
            if ((bool)e.Argument)
                backgroundWorker.ReportProgress(100 * ((++index) / totalCount), new object[] { "حجم کل اسناد", Njit.Common.PublicMethods.GetBytesText(documnetsSize, false) });
            //list.Add();
            backgroundWorker.ReportProgress(100 * ((++index) / totalCount), new object[] { "تعداد کل اسناد", documnetsCount });
            //e.Result = list;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (progressBar.Value <= 2)
                progressBar.Value = 2;
            if (e.UserState is object[])
                this.radGridViewExtended.Rows.Add(e.UserState as object[]);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Error != null)
            {
                PersianMessageBox.Show(this, "خطا" + "\r\n\r\n" + e.Error.Message);
                return;
            }
            progressBar.Value = 100;
            //foreach (object[] item in (e.Result as List<object[]>))
            //{
            //    this.radGridViewExtended.Rows.Add(item);
            //}
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == false)
            {
                this.radGridViewExtended.Rows.Clear();
                backgroundWorker.RunWorkerAsync(radioButton1.Checked ? true : false);
            }
            else
            {
                PersianMessageBox.Show(this, "عملیات در حال انجام است");
            }
        }

    }
}
