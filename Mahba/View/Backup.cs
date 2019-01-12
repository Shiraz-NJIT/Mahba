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
    public partial class Backup : Njit.Program.Forms.BackupDatabaseForm
    {
        public Backup()
        {
            InitializeComponent();
        }

        public Backup(string DatabaseName, string BackupPath, string FileName, string Title, string BackupExtension, bool AutoBackup, bool ShowAutoBackupCheckBox)
            : base(DatabaseName, BackupPath, FileName, Title, BackupExtension, AutoBackup, ShowAutoBackupCheckBox)
        {
            InitializeComponent();
        }

        public override string DatabaseBackupPath
        {
            get
            {
                return Setting.Archive.ThisProgram.LoadedArchiveSettings.BackupPath;
            }
        }

        public override void SaveSetting()
        {
            Setting.Archive.ThisProgram.LoadedArchiveSettings.AutoBackup = checkBoxAuto.Checked;
            Setting.Archive.ThisProgram.SaveAndReloadArchiveSettings(Setting.Archive.ThisProgram.LoadedArchiveSettings);
        }

        public override void LoadSetting()
        {
            checkBoxAuto.Checked = Setting.Archive.ThisProgram.LoadedArchiveSettings.AutoBackup;
        }

        private void commandLinkSchedule_Click(object sender, EventArgs e)
        {
            var taskSchedules = Setting.TaskScheduler.GetTaskSchedules(t => t.ScheduleTypeCode == (int)Njit.TaskScheduler.ScheduleType.ScheduleTypes.BackupDatabase);
            List<Njit.TaskScheduler.Schedule> list = new List<Njit.TaskScheduler.Schedule>();
            foreach (var item in taskSchedules)
                list.Add(Setting.TaskScheduler.GetSchedule(item));
            using (Njit.TaskScheduler.EditSchedules editForm = new Njit.TaskScheduler.EditSchedules(list, Njit.TaskScheduler.ScheduleType.ScheduleTypes.BackupDatabase))
            {
                editForm.ShowDialog();
                Setting.TaskScheduler.UpdateTaskSchedules(editForm.Schedules);
            }
        }
    }
}
