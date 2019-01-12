using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler.ScheduleTypes
{
    public class ExecuteProgram : ScheduleType
    {
        public ExecuteProgram()
            : base("اجرای یک برنامه")
        {
            this.TypeOfSchedule = ScheduleTypes.ExecuteProgram;
        }

        public ExecuteProgram(string filePath, string parameter)
            : this()
        {
            this.FilePath = filePath;
            this.Parameter = parameter;
        }

        private string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
            }
        }

        private string _Parameter;
        public string Parameter
        {
            get
            {
                return _Parameter;
            }
            set
            {
                _Parameter = value;
            }
        }
    }
}
