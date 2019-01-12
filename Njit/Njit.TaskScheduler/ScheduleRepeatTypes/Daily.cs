using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler.ScheduleRepeatTypes
{
    public class Daily : ScheduleRepeat
    {
        public Daily()
            : base("روزانه")
        {
            this.TypeOfRepeat = ScheduleRepeats.Daily;
        }

        public Daily(string startDate, string endDate, string executeTime)
            : base("روزانه", startDate, "00:00", endDate, "23:59", executeTime)
        {
            this.TypeOfRepeat = ScheduleRepeats.Daily;
        }
    }
}
