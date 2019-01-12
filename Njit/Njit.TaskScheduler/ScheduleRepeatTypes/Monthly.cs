using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler.ScheduleRepeatTypes
{
    public class Monthly : ScheduleRepeat
    {
        public Monthly()
            : base("ماهانه")
        {
            this.TypeOfRepeat = ScheduleRepeats.Monthly;
        }

        public Monthly(string startDate, string startTime, string endDate, string endTime, string executeTime, int[] months, int monthDay)
            : base("ماهانه", startDate, startTime, endDate, endTime, executeTime)
        {
            this.Months = months;
            this.MonthDay = monthDay;
            this.TypeOfRepeat = ScheduleRepeats.Monthly;
        }

        private int[] _Months;
        public int[] Months
        {
            get
            {
                return _Months;
            }
            set
            {
                _Months = value;
            }
        }

        private int _MonthDay;
        public int MonthDay
        {
            get
            {
                return _MonthDay;
            }
            set
            {
                _MonthDay = value;
            }
        }

    }
}
