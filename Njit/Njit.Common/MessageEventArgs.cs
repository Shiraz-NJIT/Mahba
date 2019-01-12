using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string sender, string message)
        {
            this.Sender = sender;
            this.MessageText = message;
        }
        private string _Sender;
        public string Sender
        {
            get
            {
                return _Sender;
            }
            set
            {
                _Sender = value;
            }
        }
        private string _MessageText;
        public string MessageText
        {
            get
            {
                return _MessageText;
            }
            set
            {
                _MessageText = value;
            }
        }
    }
}
