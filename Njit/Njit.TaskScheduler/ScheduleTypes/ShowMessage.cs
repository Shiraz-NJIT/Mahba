using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.TaskScheduler.ScheduleTypes
{
    public class ShowMessage : ScheduleType
    {
        public ShowMessage()
            : base("نمایش پیام")
        {
            this.TypeOfSchedule = ScheduleTypes.ShowMessage;
        }

        public ShowMessage(string messageTitle, string messageBody)
            : this()
        {
            this.MessageTitle = messageTitle;
            this.MessageBody = messageBody;
        }

        private string _MessageTitle;
        public string MessageTitle
        {
            get
            {
                return _MessageTitle;
            }
            set
            {
                _MessageTitle = value;
            }
        }

        private string _MessageBody;
        public string MessageBody
        {
            get
            {
                return _MessageBody;
            }
            set
            {
                _MessageBody = value;
            }
        }

    }
}
