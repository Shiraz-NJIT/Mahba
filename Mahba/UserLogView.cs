using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware
{
    class UserLogView
    {
        public UserLogView(int SystemCode, int UserCode, string UserFullName, string Unit, string Operation, string OperationCode, string Description, string Date, string Time, string IPAddress, string ArchiveName)
        {
      
            this.SystemCode = SystemCode;
            this.UserCode = UserCode;
            this.UserFullName = UserFullName;
            this.Unit = Unit;
            this.Operation = Operation;
            this.OperationCode = OperationCode;
            this.Description = Description;
            this.Date = Date;
            this.Time = Time;
            this.IPAddress = IPAddress;
            this.ArchiveID = ArchiveName;
        }
        private int _Radif;
        public int Radif
        {
            get
            {
                return _Radif;
            }
            set
            {
                _Radif = value;
            }
        }

        private int _SystemCode;
        public int SystemCode
        {
            get
            {
                return _SystemCode;
            }
            set
            {
                _SystemCode = value;
            }
        }

        private int _UserCode;
        public int UserCode
        {
            get
            {
                return _UserCode;
            }
            set
            {
                _UserCode = value;
            }
        }

        private string _UserFullName;
        public string UserFullName
        {
            get
            {
                return _UserFullName;
            }
            set
            {
                _UserFullName = value;
            }
        }

        private string _Unit;
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }

        private string _Operation;
        public string Operation
        {
            get
            {
                return _Operation;
            }
            set
            {
                _Operation = value;
            }
        }

        private string _OperationCode;
        public string OperationCode
        {
            get
            {
                return _OperationCode;
            }
            set
            {
                _OperationCode = value;
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

        private string _Date;
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }

        private string _Time;
        public string Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }
        private string _IPAddress;
        public string IPAddress
        {
            get
            {
                return _IPAddress;
            }
            set
            {
                _IPAddress = value;
            }
        }
        private string _ArchiveID;
        public string ArchiveID
        {
            get
            {
                return _ArchiveID;
            }
            set
            {
                _ArchiveID = value;
            }
        }
    }
}
