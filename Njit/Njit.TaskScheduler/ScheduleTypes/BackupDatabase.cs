using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler.ScheduleTypes
{
    public class BackupDatabase : ScheduleType
    {
        public BackupDatabase()
            : base("تهیه نسخه پشتیبان")
        {
            this.TypeOfSchedule = ScheduleTypes.BackupDatabase;
        }

        public BackupDatabase(string saveTo, string fileName, SetNameTypes setNameType)
            : this()
        {
            this.SaveTo = saveTo;
            this.FileName = fileName;
            this.SetNameType = setNameType;
        }

        public enum SetNameTypes
        {
            DateAndTime,
            AutoNumber,
            Fixed
        }

        //private static string _ConnectionString;
        //public static string ConnectionString
        //{
        //    get
        //    {
        //        return _ConnectionString;
        //    }
        //    set
        //    {
        //        _ConnectionString = value;
        //    }
        //}

        private string _SaveTo;
        public string SaveTo
        {
            get
            {
                return _SaveTo;
            }
            set
            {
                _SaveTo = value;
            }
        }

        private SetNameTypes _SetNameType;
        public SetNameTypes SetNameType
        {
            get
            {
                return _SetNameType;
            }
            set
            {
                _SetNameType = value;
            }
        }

        private string _FileName;
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }

    }
}
