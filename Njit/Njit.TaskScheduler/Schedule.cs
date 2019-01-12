using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler
{
    public class Schedule
    {
        public Schedule()
            : this("", "", new ScheduleTypes.ShowMessage("", ""), new ScheduleRepeatTypes.NoRepeat("", ""))
        {
        }

        public Schedule(string name, string description, ScheduleType scheduleType, ScheduleRepeat repeatType)
        {
            this.Name = name;
            this.Description = description;
            this.ScheduleType = scheduleType;
            this.RepeatType = repeatType;
            this.ID = Guid.NewGuid().ToString();
        }

        private string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        private ScheduleType _ScheduleType;
        public ScheduleType ScheduleType
        {
            get
            {
                return _ScheduleType;
            }
            set
            {
                _ScheduleType = value;
            }
        }

        private ScheduleRepeat _RepeatType;
        public ScheduleRepeat RepeatType
        {
            get
            {
                return _RepeatType;
            }
            set
            {
                _RepeatType = value;
            }
        }

        //public string GetFullDescription()
        //{
        //    string description = "";
        //    description += this.Description == "" ? "(بدون توضیحات)" : this.Description;
        //    switch (this.RepeatType.ID)
        //    {
        //        case (int)ScheduleRepeatTypes.NoRepeat:
        //            description += string.Format(" (" + "اجرا در تاریخ {0} و ساعت {1}" + ")", this.StartDate, this.StartTime);
        //            break;
        //        case (int)ScheduleRepeatTypes.Daily:
        //            description += " (" + "تکرار هر روز ساعت " + this.ExecuteTime + ")";
        //            break;
        //        case (int)ScheduleRepeatTypes.Weekly:
        //            description += string.Format(" (" + "تکرار روزهای {0} ساعت ", GetWeekDayNames(this.WeekDays)) + this.ExecuteTime + ")";
        //            break;
        //        case (int)ScheduleRepeatTypes.Monthly:
        //            description += string.Format(" (" + "تکرار {0} ماه های {1} ساعت ", GetDayName(this.MonthDay), GetMonthNames(this.Months)) + this.ExecuteTime + ")";
        //            break;
        //        default:
        //            throw new Exception();
        //    }
        //    switch (this.ScheduleType.ID)
        //    {
        //        case (int)ScheduleTypes.BackupDatabase:
        //            break;
        //        case (int)ScheduleTypes.ShowMessage:
        //            break;
        //        case (int)ScheduleTypes.ExecuteProgram:
        //            break;
        //        default:
        //            throw new Exception();
        //    }
        //    return description;
        //}

        //private string GetMonthNames(int[] months)
        //{
        //    List<string> list = new List<string>();
        //    foreach (int item in months)
        //    {
        //        list.Add(Njit.Common.PersianCalendar.GetMonthName(item));
        //    }
        //    return list.Aggregate((a, b) => a + "," + b);
        //}

        //private string GetDayName(int day)
        //{
        //    string s = Njit.Common.NumbersUtility.GetWords(day);
        //    if (day == 3)
        //        s = s.Substring(0, 1) + "وم";
        //    else if (day == 23)
        //        s = s.Substring(0, 8) + "وم";
        //    else
        //        s = s + "م";
        //    return s;
        //}

        //private string GetWeekDayNames(int[] weekDays)
        //{
        //    List<string> list = new List<string>();
        //    foreach (int item in weekDays)
        //    {
        //        switch (item)
        //        {
        //            case 1:
        //                list.Add("شنبه");
        //                break;
        //            case 2:
        //                list.Add("یک شنبه");
        //                break;
        //            case 3:
        //                list.Add("دو شنبه");
        //                break;
        //            case 4:
        //                list.Add("سه شنبه");
        //                break;
        //            case 5:
        //                list.Add("چهارشنبه");
        //                break;
        //            case 6:
        //                list.Add("پنج شنبه");
        //                break;
        //            case 7:
        //                list.Add("جمعه");
        //                break;
        //        }
        //    }
        //    return list.Aggregate((a, b) => a + "," + b);
        //}
    }
}
