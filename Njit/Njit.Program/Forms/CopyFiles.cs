using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.Forms
{
    public partial class CopyFiles : Njit.Program.Forms.CancelableDialogForm
    {
        private CopyFiles()
        {
            InitializeComponent();
        }

        public CopyFiles(string[] sourceFiles, string destinationPath, Njit.Common.SystemUtility sourceSystemUtility, Njit.Common.SystemUtility destinationSystemUtility, bool overWrite)
            : this()
        {
            this.sourceFiles = sourceFiles;
            this.destinationPath = destinationPath;
            this.destinationFiles = null;
            this.sourceSystemUtility = sourceSystemUtility;
            this.destinationSystemUtility = destinationSystemUtility;
            this.overWrite = overWrite;
        }

        public CopyFiles(string[] sourceFiles, string[] destinationFiles, Njit.Common.SystemUtility sourceSystemUtility, Njit.Common.SystemUtility destinationSystemUtility, bool overWrite)
            : this()
        {
            this.sourceFiles = sourceFiles;
            this.destinationPath = null;
            this.destinationFiles = destinationFiles;
            this.sourceSystemUtility = sourceSystemUtility;
            this.destinationSystemUtility = destinationSystemUtility;
            this.overWrite = overWrite;
        }

        private string[] sourceFiles;
        private string destinationPath;
        private string[] destinationFiles;
        private Njit.Common.SystemUtility sourceSystemUtility;
        private Njit.Common.SystemUtility destinationSystemUtility;
        private long totalLenght;
        private long amountOfBytesCopied;
        private const int bufferLenght = 1 * 1024 * 1024;
        private bool overWrite;
        private DateTime startDateTime;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Refresh();
            backgroundWorkerInit.RunWorkerAsync();
        }

        private void backgroundWorkerInit_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorkerInit.ReportProgress(0);
            totalLenght = 0;
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                if (backgroundWorkerInit.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                System.IO.FileInfo fileInfo = sourceSystemUtility.GetFileInfo(sourceFiles[i]);
                totalLenght += fileInfo.Length;
            }
            backgroundWorkerInit.ReportProgress(100);
        }

        private void backgroundWorkerInit_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
                lblTitle.Text = "در حال دریافت اطلاعات فایل ها";
            else if (e.ProgressPercentage == 100)
                lblTitle.Text = "اطلاعات فایل ها دریافت شد";
        }

        private void backgroundWorkerInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                PersianMessageBox.Show(this, "خطا در دریافت اطلاعات فایل ها" + "\r\n" + e.Error.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
                return;
            }
            else if (e.Cancelled)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            backgroundWorkerCopy.RunWorkerAsync();
        }

        private void backgroundWorkerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorkerCopy.ReportProgress(0);
            amountOfBytesCopied = 0;
            byte[] buffer = new byte[bufferLenght];
            if (destinationPath != null && !destinationSystemUtility.DirectoryExists(destinationPath))
                destinationSystemUtility.CreateDirectory(destinationPath);
            startDateTime = DateTime.Now;
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                if (backgroundWorkerCopy.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                string destinationFile;
                if (destinationPath != null)
                    destinationFile = System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileName(sourceFiles[i]));
                else
                    destinationFile = destinationFiles[i];
                if (this.overWrite || (!this.overWrite && !destinationSystemUtility.FileExists(destinationFile)))
                {
                    System.IO.FileStream sourceStream = null;
                    System.IO.FileStream destinationStream = null;
                    try
                    {
                        sourceStream = sourceSystemUtility.OpenFile(sourceFiles[i]);
                        destinationStream = destinationSystemUtility.CreateFile(destinationFile);
                        int readCount;
                        do
                        {
                            if (backgroundWorkerCopy.CancellationPending)
                            {
                                e.Cancel = true;
                                if (sourceStream != null)
                                {
                                    sourceStream.Close();
                                    sourceStream.Dispose();
                                }
                                if (destinationStream != null)
                                {
                                    destinationStream.Close();
                                    destinationStream.Dispose();
                                }
                                try
                                {
                                    destinationSystemUtility.DeleteFile(destinationFile);
                                }
                                catch { }
                                return;
                            }
                            readCount = sourceStream.Read(buffer, 0, buffer.Length);
                            destinationStream.Write(buffer, 0, readCount);

                            amountOfBytesCopied += readCount;
                            backgroundWorkerCopy.ReportProgress((int)(100 * amountOfBytesCopied / totalLenght), sourceFiles[i]);
                        }
                        while (readCount > 0);
                    }
                    finally
                    {
                        if (sourceStream != null)
                        {
                            sourceStream.Close();
                            sourceStream.Dispose();
                        }
                        if (destinationStream != null)
                        {
                            destinationStream.Close();
                            destinationStream.Dispose();
                        }
                    }
                }
            }
            backgroundWorkerCopy.ReportProgress(100);
        }

        private void backgroundWorkerCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 0)
                lblTitle.Text = "شروع کپی فایل ها...";
            else if (e.UserState != null && e.UserState is string)
            {
                lblTitle.Text = string.Format("در حال کپی فایل: '{0}'", System.IO.Path.GetFileName(e.UserState.ToString()));
                TimeSpan timeSpan = DateTime.Now.Subtract(startDateTime);
                double speed = amountOfBytesCopied / timeSpan.TotalSeconds;
                double remainingSeconds = (totalLenght - amountOfBytesCopied) / speed;
                TimeSpan remainingTime = new TimeSpan(0, 0, (int)remainingSeconds);
                lblTitle.Text += "\r\n";
                lblTitle.Text += "مدت زمان باقی مانده: " + remainingTime.GetText();
                this.Text = "کپی فایل ها (" + e.ProgressPercentage.ToString() + " %)";
            }
        }

        private void backgroundWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                PersianMessageBox.Show(this, "خطا در کپی فایل ها" + "\r\n" + e.Error.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
                return;
            }
            else if (e.Cancelled)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorkerInit.IsBusy)
            {
                backgroundWorkerInit.CancelAsync();
                e.Cancel = true;
            }
            if (backgroundWorkerCopy.IsBusy)
            {
                backgroundWorkerCopy.CancelAsync();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

    }
}
