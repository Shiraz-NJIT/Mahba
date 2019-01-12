using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler.ScheduleRepeatTypes
{
    public class Weekly : ScheduleRepeat
    {
        public Weekly()
            : base("هفتگی")
        {
            this.TypeOfRepeat = ScheduleRepeats.Weekly;
        }

        public Weekly(string startDate, string startTime, string endDate, string endTime, string executeTime, int[] weekDays)
            : base("هفتگی", startDate, startTime, endDate, endTime, executeTime)
        {
            this.WeekDays = weekDays;
            this.TypeOfRepeat = ScheduleRepeats.Weekly;
        }

        private int[] _WeekDays;
        public int[] WeekDays
        {
            get
            {
                return _WeekDays;
            }
            set
            {
                _WeekDays = value;
            }
        }

    }
}
