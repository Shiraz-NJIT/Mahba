using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class BackupDocuments : Njit.Program.Forms.OKCancelForm
    {
        public BackupDocuments()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtPath.Text = Properties.Settings.Default.LastDocumentsBackupPath ?? "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                PersianMessageBox.Show(this, "مسیر ذخیره انتخاب نشده است");
                txtPath.FocusAndSetError("مسیر ذخیره انتخاب نشده است");
                return;
            }
            if (!System.IO.Directory.Exists(txtPath.Text))
            {
                PersianMessageBox.Show(this, "مسیر ذخیره نامعتبر است");
                txtPath.FocusAndSetError("مسیر ذخیره نامعتبر است");
                return;
            }
            if (backgroundWorker.IsBusy)
            {
                PersianMessageBox.Show(this, "عملیات در حال انجام است");
                return;
            }
            else
            {
                backgroundWorker.RunWorkerAsync(txtPath.Text);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = Controller.Archive.DocumentController.GetDocumentsCount();
            int index = 0;
            bool documentsAreInDatabase = Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase;
            foreach (Model.Archive.Document item in Controller.Archive.DocumentController.GetDocuments())
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                string documentSaveDirectory = System.IO.Path.Combine(e.Argument.ToString(), item.Dossier.PersonnelNumber);
                string documentSavePath = System.IO.Path.Combine(documentSaveDirectory, item.Number + System.IO.Path.GetExtension(item.FileName));
                if (!System.IO.Directory.Exists(documentSaveDirectory))
                    System.IO.Directory.CreateDirectory(documentSaveDirectory);
                if (documentsAreInDatabase)
                {
                    System.IO.File.WriteAllBytes(documentSavePath, Controller.ArchiveDocument.ArchiveDocumentController.GetDocumentData(item.ID));
                }
                else
                {
                    string file = System.IO.Path.Combine(item.Dossier.FilesPathOrDatabaseName, item.FileName);
                    System.IO.File.Copy(file, documentSavePath, true);
                }
                if ((index % 100) == 0)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                backgroundWorker.ReportProgress(100 * index / count, "در حال ذخیره سند " + item.Number + " از پرونده " + item.Dossier.PersonnelNumber);
                index++;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (e.UserState != null)
                lblStatus.Text = e.UserState.ToString();
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
            PersianMessageBox.Show(this, "پشتیبان گیری با موفقیت به پایان رسید");
            lblStatus.Text = "";
            Properties.Settings.Default.LastDocumentsBackupPath = txtPath.Text;
            Properties.Settings.Default.Save();
            Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.پشتیبان_گیری_از_اسناد, null, "پشتیبان گیری از اسناد بایگانی " + Controller.Common.ArchiveController.GetArchiveTitle(Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                var result = PersianMessageBox.Show(this, "عملیات پشتیبان گیری در حال انجام است\r\nعملیات لغو شود؟", "تایید لغو عملیات پشتیبان گیری", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
                else
                {
                    backgroundWorker.CancelAsync();
                }
            }
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }
    }
}
