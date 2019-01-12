using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler
{
    public class ScheduleType
    {
        //public static ScheduleType BackupDatabase = new Njit.TaskScheduler.ScheduleTypes.BackupDatabase();
        //public static ScheduleType ShowMessage = new Njit.TaskScheduler.ScheduleTypes.ShowMessage();
        //public static ScheduleType ExecuteProgram = new Njit.TaskScheduler.ScheduleTypes.ExecuteProgram();

        public enum ScheduleTypes
        {
            BackupDatabase,
            ShowMessage,
            ExecuteProgram,
        }

        private ScheduleTypes _ScheduleType;
        public ScheduleTypes TypeOfSchedule
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

        public ScheduleType(string Title)
        {
            this.Title = Title;
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
    }
}
