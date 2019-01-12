using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler
{
    public class ScheduleRepeat
    {
        //public static ScheduleRepeat NoRepeat = new ScheduleRepeatTypes.NoRepeat();
        //public static ScheduleRepeat Daily = new ScheduleRepeatTypes.Daily();
        //public static ScheduleRepeat Weekly = new ScheduleRepeatTypes.Weekly();
        //public static ScheduleRepeat Monthly = new ScheduleRepeatTypes.Monthly();

        public enum ScheduleRepeats
        {
            NoRepeat,
            Daily,
            Weekly,
            Monthly
        }

        private ScheduleRepeats _ScheduleRepeat;
        public ScheduleRepeats TypeOfRepeat
        {
            get
            {
                return _ScheduleRepeat;
            }
            set
            {
                _ScheduleRepeat = value;
            }
        }

        public ScheduleRepeat(string title)
        {
            this.Title = title;
        }

        public ScheduleRepeat(string title, string startDate, string startTime, string endDate, string endTime, string executeTime)
        {
            this.Title = title;
            this.StartDate = startDate;
            this.StartTime = startTime;
            this.EndDate = endDate;
            this.EndTime = endTime;
            this.ExecuteTime = executeTime;
        }

        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        private string _StartDate;
        public string StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }

        private string _StartTime;
        public string StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
            }
        }

        private string _EndDate;
        public string EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }

        private string _EndTime;
        public string EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                _EndTime = value;
            }
        }

        private string _ExecuteTime;
        public string ExecuteTime
        {
            get
            {
                return _ExecuteTime;
            }
            set
            {
                _ExecuteTime = value;
            }
        }
    }
}
