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
    public partial class SaveFiles : Njit.Program.Forms.CancelableDialogForm
    {
        public SaveFiles(Action<string> saveAction, string[] files, string savePath, Njit.Common.SystemUtility destinationSystemUtility, bool useDateTimeForFileNames)
        {
            InitializeComponent();
            this.saveAction = saveAction;
            this.sourceFiles = files;
            this.destinationPath = savePath;
            this.destinationFiles = null;
            this.destinationSystemUtility = destinationSystemUtility;
            this.useDateTimeForFileNames = useDateTimeForFileNames;
        }
        public SaveFiles(Action<string> saveAction, string[] files, string[] destinationFiles, Njit.Common.SystemUtility destinationSystemUtility)
        {
            InitializeComponent();
            this.saveAction = saveAction;
            this.sourceFiles = files;
            this.destinationPath = null;
            this.destinationFiles = destinationFiles;
            this.destinationSystemUtility = destinationSystemUtility;
        }

        Action<string> saveAction;
        string[] sourceFiles;
        string destinationPath;
        long totalLenght = 0;
        long amountOfBytesCopied;
        DateTime startDateTime;
        private const int bufferLenght = 1 * 1024 * 1024;
        Njit.Common.SystemUtility destinationSystemUtility;
        string[] destinationFiles;
        bool useDateTimeForFileNames;

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
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(sourceFiles[i]);
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
            int counter = 0;
            backgroundWorkerCopy.ReportProgress(0);
            amountOfBytesCopied = 0;
            byte[] buffer = new byte[bufferLenght];
            if (destinationPath != null && destinationSystemUtility != null && !destinationSystemUtility.DirectoryExists(destinationPath))
                destinationSystemUtility.CreateDirectory(destinationPath);
            startDateTime = DateTime.Now;
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                if (backgroundWorkerCopy.CancellationPending)
                {
                    e.Cancel = true;
                    e.Result = counter;
                    return;
                }
                string destinationFile = null;
                if (destinationPath != null)
                {
                    if (useDateTimeForFileNames == false)
                        destinationFile = System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileName(sourceFiles[i]));
                    else
                    {
                        destinationFile = System.IO.Path.Combine(destinationPath, GetNewFileName()) + System.IO.Path.GetExtension(sourceFiles[i]);
                        int index = 1;
                        while (System.IO.File.Exists(destinationFile))
                        {
                            destinationFile = System.IO.Path.Combine(destinationPath, GetNewFileName() + " (" + (++index).ToString() + ")") + System.IO.Path.GetExtension(sourceFiles[i]);
                        }
                    }
                }
                else if (destinationFiles != null)
                    destinationFile = destinationFiles[i];

                if (saveAction != null)
                {
                    try
                    {
                        saveAction(sourceFiles[i]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("خطا در ذخیره فایل" + "\r\n" + sourceFiles[i] + "\r\n" + "\r\n" + ex.Message);
                    }
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(sourceFiles[i]);
                    amountOfBytesCopied += fileInfo.Length;
                    backgroundWorkerCopy.ReportProgress((int)(100 * amountOfBytesCopied / totalLenght), sourceFiles[i]);
                }
                else
                {
                    System.IO.FileStream sourceStream = null;
                    System.IO.FileStream destinationStream = null;
                    try
                    {
                        sourceStream = System.IO.File.OpenRead(sourceFiles[i]);
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
                                e.Result = counter;
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
                counter++;
            }
            backgroundWorkerCopy.ReportProgress(100);
            e.Result = counter;
        }

        public static string GetNewFileName()
        {
            return Njit.Common.PersianCalendar.GetDate(DateTime.Now, "-") + " " + Njit.Common.PersianCalendar.GetTime(DateTime.Now, "-", true);
        }

        private void backgroundWorkerCopy_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 0)
                lblTitle.Text = "شروع ذخیره فایل ها...";
            else if (e.UserState != null && e.UserState is string)
            {
                lblTitle.Text = string.Format("در حال ذخیره فایل: '{0}'", System.IO.Path.GetFileName(e.UserState.ToString()));
                TimeSpan timeSpan = DateTime.Now.Subtract(startDateTime);
                double speed = amountOfBytesCopied / timeSpan.TotalSeconds;
                double remainingSeconds = (totalLenght - amountOfBytesCopied) / speed;
                TimeSpan remainingTime = new TimeSpan(0, 0, (int)remainingSeconds);
                lblTitle.Text += "\r\n";
                lblTitle.Text += "مدت زمان باقی مانده: " + remainingTime.GetText();
                this.Text = "ذخیره فایل ها (" + e.ProgressPercentage.ToString() + " %)";
            }
        }

        private void backgroundWorkerCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Tag = e.Result;
            }
            catch
            {
                this.Tag = 0;
            }
            if (e.Error != null)
            {
                PersianMessageBox.Show(this, "خطا در ذخیره فایل ها" + "\r\n" + e.Error.Message);
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

    }
}
