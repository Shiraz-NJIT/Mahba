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
    public partial class RestoreBackup : Njit.Program.Forms.RestoreBackupForm
    {
        public RestoreBackup()
        {
            InitializeComponent();
        }

        public RestoreBackup(string BackupPath, string BackupExtension, string Database, string Title)
            : base(BackupPath, BackupExtension, Database, Title)
        {
            InitializeComponent();
        }

        public override void ExitApplication()
        {
            PersianMessageBox.Show(this, "بازیابی اطلاعات با موفقیت انجام شد. اکنون برنامه راه اندازی مجدد می شود.");
            Setting.Program.ThisProgram.ShowExitDialog = false;
            this.Close();
            View.Main.Instance.Close();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = Application.ExecutablePath;
            p.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            p.Start();
        }
    }
}
