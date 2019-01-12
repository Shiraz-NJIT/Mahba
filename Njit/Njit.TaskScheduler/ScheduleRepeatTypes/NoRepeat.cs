using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler.ScheduleRepeatTypes
{
    public class NoRepeat : ScheduleRepeat
    {
        public NoRepeat()
            : base("بدون تکرار")
        {
            this.TypeOfRepeat = ScheduleRepeats.NoRepeat;
        }
        public NoRepeat(string startDate, string startTime)
            : base("بدون تکرار", startDate, startTime, "1900/01/01", "23:59", startTime)
        {
            this.TypeOfRepeat = ScheduleRepeats.NoRepeat;
        }
    }
}
