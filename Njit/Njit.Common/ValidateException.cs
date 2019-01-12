using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public class ValidateException : Exception
    {
        public ValidateException(System.Windows.Forms.Control control, string errorMessage)
            : base(errorMessage)
        {
            this.Control = control;
            this.ErrorMessage = errorMessage;
        }

        private System.Windows.Forms.Control _Control;
        public System.Windows.Forms.Control Control
        {
            get
            {
                return _Control;
            }
            set
            {
                _Control = value;
            }
        }

        private string _ErrorMessage;
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
            }
        }

        private object _Tag;
        public object Tag
        {
            get
            {
                return _Tag;
            }
            set
            {
                _Tag = value;
            }
        }
    }
}
