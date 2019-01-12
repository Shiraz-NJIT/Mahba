using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.TaskScheduler
{
    public partial class EditSchedules : Njit.Program.Forms.ListForm
    {
        public EditSchedules(IEnumerable<Njit.TaskScheduler.Schedule> schedules, Njit.TaskScheduler.ScheduleType.ScheduleTypes allowedScheduleTypes)
        {
            InitializeComponent();
            this.Schedules = schedules.ToList();
            this.AllowedScheduleTypes = allowedScheduleTypes;
            scheduleBindingSource.DataSource = this.Schedules;
        }

        private void SetSystemSchedule(Schedule schedule)
        {
            using (Microsoft.Win32.TaskScheduler.TaskService ts = new Microsoft.Win32.TaskScheduler.TaskService())
            {
                Microsoft.Win32.TaskScheduler.TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = schedule.Description;
                td.Triggers.Add(GetTrigger(schedule));
                td.Actions.Add(GetAction(schedule));
                ts.RootFolder.RegisterTaskDefinition(schedule.Name, td);
            }
        }

        private void RemoveSystemSchedule(Schedule schedule)
        {
            using (Microsoft.Win32.TaskScheduler.TaskService ts = new Microsoft.Win32.TaskScheduler.TaskService())
            {
                ts.RootFolder.DeleteTask(schedule.Name);
            }
        }

        private Microsoft.Win32.TaskScheduler.Action GetAction(Schedule schedule)
        {
            if (schedule.ScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.BackupDatabase)
            {
                Microsoft.Win32.TaskScheduler.ExecAction action = new Microsoft.Win32.TaskScheduler.ExecAction();
                ScheduleTypes.BackupDatabase b = schedule.ScheduleType as ScheduleTypes.BackupDatabase;
                action.Path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "BackupDatabase.exe");
                action.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                action.Arguments = string.Format("\"BackupPath={0}\" \"BackupName={1}\" \"SetNameType={2}\"", b.SaveTo, b.FileName, (int)b.SetNameType);
                return action;
            }
            else if (schedule.ScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.ExecuteProgram)
            {
                Microsoft.Win32.TaskScheduler.ExecAction action = new Microsoft.Win32.TaskScheduler.ExecAction();
                ScheduleTypes.ExecuteProgram e = schedule.ScheduleType as ScheduleTypes.ExecuteProgram;
                action.Path = e.FilePath;
                action.WorkingDirectory = System.IO.Path.GetDirectoryName(e.FilePath);
                action.Arguments = e.Parameter;
                return action;
            }
            else if (schedule.ScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.ShowMessage)
            {
                Microsoft.Win32.TaskScheduler.ExecAction action = new Microsoft.Win32.TaskScheduler.ExecAction();
                ScheduleTypes.ShowMessage s = schedule.ScheduleType as ScheduleTypes.ShowMessage;
                action.Path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "ShowMessage.exe");
                action.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                action.Arguments = string.Format("\"MessageTitle={0}\" \"MessageBody={1}\"", s.MessageTitle, s.MessageBody);
                return action;
            }
            throw new Exception();
        }

        private Microsoft.Win32.TaskScheduler.Trigger GetTrigger(Schedule schedule)
        {
            switch (schedule.RepeatType.TypeOfRepeat)
            {
                case ScheduleRepeat.ScheduleRepeats.NoRepeat:
                    ScheduleRepeatTypes.NoRepeat r1 = schedule.RepeatType as ScheduleRepeatTypes.NoRepeat;
                    Microsoft.Win32.TaskScheduler.TimeTrigger trigger1 = new Microsoft.Win32.TaskScheduler.TimeTrigger(Njit.Common.PersianCalendar.ToDateTime(r1.StartDate, r1.StartTime, '/', ':'));
                    return trigger1;
                case ScheduleRepeat.ScheduleRepeats.Daily:
                    ScheduleRepeatTypes.Daily r2 = schedule.RepeatType as ScheduleRepeatTypes.Daily;
                    Microsoft.Win32.TaskScheduler.DailyTrigger trigger2 = new Microsoft.Win32.TaskScheduler.DailyTrigger();
                    trigger2.StartBoundary = Njit.Common.PersianCalendar.ToDateTime(r2.StartDate, r2.ExecuteTime, '/', ':');
                    trigger2.EndBoundary = Njit.Common.PersianCalendar.ToDateTime(r2.EndDate, r2.EndTime, '/', ':');
                    return trigger2;
                case ScheduleRepeat.ScheduleRepeats.Weekly:
                    ScheduleRepeatTypes.Weekly r3 = schedule.RepeatType as ScheduleRepeatTypes.Weekly;
                    Microsoft.Win32.TaskScheduler.WeeklyTrigger trigger3 = new Microsoft.Win32.TaskScheduler.WeeklyTrigger();
                    trigger3.StartBoundary = Njit.Common.PersianCalendar.ToDateTime(r3.StartDate, r3.ExecuteTime, '/', ':');
                    trigger3.EndBoundary = Njit.Common.PersianCalendar.ToDateTime(r3.EndDate, r3.EndTime, '/', ':');
                    trigger3.DaysOfWeek = GetDaysOfWeek(r3.WeekDays);
                    return trigger3;
                case ScheduleRepeat.ScheduleRepeats.Monthly:
                    ScheduleRepeatTypes.Monthly r4 = schedule.RepeatType as ScheduleRepeatTypes.Monthly;
                    Microsoft.Win32.TaskScheduler.MonthlyTrigger trigger4 = new Microsoft.Win32.TaskScheduler.MonthlyTrigger();
                    trigger4.StartBoundary = Njit.Common.PersianCalendar.ToDateTime(r4.StartDate, r4.ExecuteTime, '/', ':');
                    trigger4.EndBoundary = Njit.Common.PersianCalendar.ToDateTime(r4.EndDate, r4.EndTime, '/', ':');
                    trigger4.MonthsOfYear = GetMonthsOfYear(r4.Months);
                    trigger4.DaysOfMonth = new int[] { r4.MonthDay };
                    return trigger4;
                default:
                    throw new Exception();
            }
        }

        private Microsoft.Win32.TaskScheduler.MonthsOfTheYear GetMonthsOfYear(int[] months)
        {
            Microsoft.Win32.TaskScheduler.MonthsOfTheYear t = GetMonthOfYear(months[0]);
            if (months.Length > 1)
            {
                for (int i = 1; i < months.Length; i++)
                {
                    t |= GetMonthOfYear(months[i]);
                }
            }
            return t;
        }

        private Microsoft.Win32.TaskScheduler.MonthsOfTheYear GetMonthOfYear(int month)
        {
            if (month == 1)
                return Microsoft.Win32.TaskScheduler.MonthsOfTheYear.January;
            if (month == 2)
                return Microsoft.Win32.TaskScheduler.MonthsOfTheYear.February;
            return (Microsoft.Win32.TaskScheduler.MonthsOfTheYear)((int)Math.Pow(month - 1, 2));
        }

        private Microsoft.Win32.TaskScheduler.DaysOfTheWeek GetDaysOfWeek(int[] days)
        {
            Microsoft.Win32.TaskScheduler.DaysOfTheWeek t = GetDayOfWeek(days[0]);
            if (days.Length > 1)
            {
                for (int i = 1; i < days.Length; i++)
                {
                    t |= GetDayOfWeek(days[i]);
                }
            }
            return t;
        }

        private Microsoft.Win32.TaskScheduler.DaysOfTheWeek GetDayOfWeek(int p)
        {
            switch (p)
            {
                case 1:
                    return Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Saturday;
                case 2:
                    return Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Sunday;
                case 3:
                    return Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Monday;
                case 4:
                    return Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Tuesday;
                case 5:
                    return Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Wednesday;
                case 6:
                    return Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Thursday;
                case 7:
                    return Microsoft.Win32.TaskScheduler.DaysOfTheWeek.Friday;
                default:
                    throw new Exception();
            }
        }

        private List<Schedule> _Schedules;
        public List<Schedule> Schedules
        {
            get
            {
                return _Schedules;
            }
            set
            {
                _Schedules = value;
            }
        }

        private Njit.TaskScheduler.ScheduleType.ScheduleTypes _AllowedScheduleTypes;
        public Njit.TaskScheduler.ScheduleType.ScheduleTypes AllowedScheduleTypes
        {
            get
            {
                return _AllowedScheduleTypes;
            }
            set
            {
                _AllowedScheduleTypes = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddEditSchedule f = new AddEditSchedule(this.AllowedScheduleTypes))
            {
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        Schedule schedule = f.Tag as Schedule;
                        SetSystemSchedule(schedule);
                        scheduleBindingSource.Add(schedule);
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در ثبت برنامه زمانی" + "\r\n" + ex.Message);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
                list.Add((row.DataBoundItem as Schedule).ID);
            foreach (string item in list)
            {
                Schedule schedule = Schedules.Where(t => t.ID == item).Single();
                DialogResult result = PersianMessageBox.Show(this, string.Format("برنامه زمانی با نام '" + schedule.Name + "' حذف شود؟"), "تایید حذف", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                    break;
                else if (result == DialogResult.Yes)
                {
                    try
                    {
                        scheduleBindingSource.Remove(schedule);
                        RemoveSystemSchedule(schedule);
                    }
                    catch (System.IO.IOException)
                    {
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در حذف برنامه زمانی با نام '" + schedule.Name + "'" + "\n\n" + ex.Message);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 1)
                return;
            using (AddEditSchedule f = new AddEditSchedule(this.AllowedScheduleTypes, this.Schedules.Where(t => t.ID == (dataGridView.SelectedRows[0].DataBoundItem as Schedule).ID).Single()))
            {
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        Schedule originalSchedule = this.Schedules.Where(t => t.ID == (dataGridView.SelectedRows[0].DataBoundItem as Schedule).ID).Single();
                        Schedule newSchedule = f.Tag as Schedule;
                        try
                        {
                            RemoveSystemSchedule(originalSchedule);
                        }
                        catch
                        {
                        }
                        Copy(originalSchedule, newSchedule);
                        SetSystemSchedule(originalSchedule);
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در ثبت برنامه زمانی" + "\r\n" + ex.Message);
                    }
                }
            }
        }

        private void Copy(Schedule originalSchedule, Schedule newSchedule)
        {
            originalSchedule.Description = newSchedule.Description;
            //originalSchedule.ID = newSchedule.ID;
            originalSchedule.Name = newSchedule.Name;
            originalSchedule.RepeatType = newSchedule.RepeatType;
            originalSchedule.ScheduleType = newSchedule.ScheduleType;
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                InvokeOnClick(btnEdit, EventArgs.Empty);
        }
    }
}
