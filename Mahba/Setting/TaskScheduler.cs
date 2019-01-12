using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NjitSoftware.Setting
{
    static class TaskScheduler
    {
        public static IEnumerable<NjitSoftware.Model.Common.TaskSchedule> GetTaskSchedules(Expression<Func<NjitSoftware.Model.Common.TaskSchedule, bool>> predicate)
        {
            NjitSoftware.Model.Common.ArchiveCommonDataClassesDataContext dc = new NjitSoftware.Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.TaskSchedules.Where(predicate);
        }

        public static Njit.TaskScheduler.Schedule GetSchedule(NjitSoftware.Model.Common.TaskSchedule taskSchedule)
        {
            Njit.TaskScheduler.Schedule schedule = new Njit.TaskScheduler.Schedule();
            schedule.ID = taskSchedule.TaskCode;
            schedule.Name = taskSchedule.Name;
            schedule.Description = taskSchedule.Description;
            schedule.ScheduleType = GetScheduleType(taskSchedule);
            schedule.RepeatType = GetScheduleRepeat(taskSchedule);
            return schedule;
        }

        public static Njit.TaskScheduler.ScheduleRepeat GetScheduleRepeat(NjitSoftware.Model.Common.TaskSchedule taskSchedule)
        {
            switch ((Njit.TaskScheduler.ScheduleRepeat.ScheduleRepeats)taskSchedule.RepeatTypeCode)
            {
                case Njit.TaskScheduler.ScheduleRepeat.ScheduleRepeats.NoRepeat:
                    return new Njit.TaskScheduler.ScheduleRepeatTypes.NoRepeat(taskSchedule.StartDate, taskSchedule.StartTime);
                case Njit.TaskScheduler.ScheduleRepeat.ScheduleRepeats.Daily:
                    return new Njit.TaskScheduler.ScheduleRepeatTypes.Daily(taskSchedule.StartDate, taskSchedule.EndDate, taskSchedule.ExecuteTime);
                case Njit.TaskScheduler.ScheduleRepeat.ScheduleRepeats.Weekly:
                    return new Njit.TaskScheduler.ScheduleRepeatTypes.Weekly(taskSchedule.StartDate, taskSchedule.StartTime, taskSchedule.EndDate, taskSchedule.EndTime, taskSchedule.ExecuteTime, GetIntArrar(taskSchedule.WeekDays));
                case Njit.TaskScheduler.ScheduleRepeat.ScheduleRepeats.Monthly:
                    return new Njit.TaskScheduler.ScheduleRepeatTypes.Monthly(taskSchedule.StartDate, taskSchedule.StartTime, taskSchedule.EndDate, taskSchedule.EndTime, taskSchedule.ExecuteTime, GetIntArrar(taskSchedule.Months), taskSchedule.MonthDay.Value);
                default:
                    throw new Exception();
            }
        }

        private static int[] GetIntArrar(string value)
        {
            string[] arr = value.Split(',');
            int[] intArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                intArr[i] = int.Parse(arr[i]);
            }
            return intArr;
        }

        public static Njit.TaskScheduler.ScheduleType GetScheduleType(NjitSoftware.Model.Common.TaskSchedule taskSchedule)
        {
            switch ((Njit.TaskScheduler.ScheduleType.ScheduleTypes)taskSchedule.ScheduleTypeCode)
            {
                case Njit.TaskScheduler.ScheduleType.ScheduleTypes.BackupDatabase:
                    return new Njit.TaskScheduler.ScheduleTypes.BackupDatabase(taskSchedule.BackupPath, taskSchedule.BackupFileName, (Njit.TaskScheduler.ScheduleTypes.BackupDatabase.SetNameTypes)taskSchedule.BackupNameType);
                case Njit.TaskScheduler.ScheduleType.ScheduleTypes.ShowMessage:
                    return new Njit.TaskScheduler.ScheduleTypes.ShowMessage(taskSchedule.MessageTitle, taskSchedule.MessageBody);
                case Njit.TaskScheduler.ScheduleType.ScheduleTypes.ExecuteProgram:
                    return new Njit.TaskScheduler.ScheduleTypes.ExecuteProgram(taskSchedule.ExecuteFilePath, taskSchedule.ExecuteParameter);
                default:
                    throw new Exception();
            }
        }

        private static string Aggregate(int[] values)
        {
            string[] s = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
                s[i] = values[i].ToString();
            return s.Aggregate((a, b) => a + "," + b);
        }

        public static void UpdateTaskSchedules(List<Njit.TaskScheduler.Schedule> scheduleList)
        {
            NjitSoftware.Model.Common.ArchiveCommonDataClassesDataContext dc = new NjitSoftware.Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            foreach (var item in dc.TaskSchedules)
                item.Flag = true;
            dc.SubmitChanges();
            foreach (var item in scheduleList)
            {
                Njit.TaskScheduler.ScheduleTypes.BackupDatabase backupDatabaseT = (item.ScheduleType as Njit.TaskScheduler.ScheduleTypes.BackupDatabase);
                Njit.TaskScheduler.ScheduleTypes.ExecuteProgram executeProgramT = (item.ScheduleType as Njit.TaskScheduler.ScheduleTypes.ExecuteProgram);
                Njit.TaskScheduler.ScheduleTypes.ShowMessage showMessageT = (item.ScheduleType as Njit.TaskScheduler.ScheduleTypes.ShowMessage);
                string weekdays = null, months = null;
                int? monthDay = null;
                Njit.TaskScheduler.ScheduleRepeatTypes.NoRepeat noRepeatR = (item.RepeatType as Njit.TaskScheduler.ScheduleRepeatTypes.NoRepeat);
                Njit.TaskScheduler.ScheduleRepeatTypes.Daily dailyR = (item.RepeatType as Njit.TaskScheduler.ScheduleRepeatTypes.Daily);
                Njit.TaskScheduler.ScheduleRepeatTypes.Weekly weeklyR = (item.RepeatType as Njit.TaskScheduler.ScheduleRepeatTypes.Weekly);
                Njit.TaskScheduler.ScheduleRepeatTypes.Monthly monthlyR = (item.RepeatType as Njit.TaskScheduler.ScheduleRepeatTypes.Monthly);
                switch (item.RepeatType.TypeOfRepeat)
                {
                    case Njit.TaskScheduler.ScheduleRepeat.ScheduleRepeats.Weekly:
                        weekdays = Aggregate(weeklyR.WeekDays);
                        break;
                    case Njit.TaskScheduler.ScheduleRepeat.ScheduleRepeats.Monthly:
                        months = Aggregate(monthlyR.Months);
                        monthDay = monthlyR.MonthDay;
                        break;
                }
                NjitSoftware.Model.Common.TaskSchedule task = NjitSoftware.Model.Common.TaskSchedule.GetNewInstance(item.ID, item.Name, item.Description,Setting.Archive.ThisProgram.SelectedArchiveTree==null?null:Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.Name, (int)item.RepeatType.TypeOfRepeat, (int)item.ScheduleType.TypeOfSchedule, backupDatabaseT == null ? null : backupDatabaseT.SaveTo, backupDatabaseT == null ? null : backupDatabaseT.FileName, backupDatabaseT == null ? null : (int?)backupDatabaseT.SetNameType, executeProgramT == null ? null : executeProgramT.FilePath, executeProgramT == null ? null : executeProgramT.Parameter, showMessageT == null ? null : showMessageT.MessageTitle, showMessageT == null ? null : showMessageT.MessageBody, item.RepeatType.StartDate, item.RepeatType.StartTime, item.RepeatType.EndDate, item.RepeatType.EndTime, item.RepeatType.ExecuteTime, weekdays, months, monthDay, false);
                var query = dc.TaskSchedules.Where(t => t.TaskCode == item.ID);
                if (query.Count() == 0)
                {
                    dc.TaskSchedules.InsertOnSubmit(task);
                    dc.SubmitChanges();
                }
                else
                {
                    NjitSoftware.Model.Common.TaskSchedule originalTask = query.Single();
                    NjitSoftware.Model.Common.TaskSchedule.Copy(originalTask, task);
                    dc.SubmitChanges();
                }
            }
            dc.TaskSchedules.DeleteAllOnSubmit(dc.TaskSchedules.Where(t => t.Flag == true));
            dc.SubmitChanges();
        }
    }
}
