using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware
{
    public class CounterFieldSetting
    {
        public CounterFieldSetting()
        {
            this.FieldID = -1;
            this.FixedValueType = Enums.FixedValueTypes.CurrentYear;
            this.FixedValue = null;
            this.Separator = "/";
        }

        public CounterFieldSetting(int fieldID, Enums.FixedValueTypes fixedValueType, string fixedValue, string separator)
        {
            this.FieldID = fieldID;
            this.FixedValueType = fixedValueType;
            this.FixedValue = fixedValue;
            this.Separator = separator;
        }

        private int _FieldID;
        public int FieldID
        {
            get
            {
                return _FieldID;
            }
            set
            {
                _FieldID = value;
            }
        }

        private Enums.FixedValueTypes _FixedValueType;
        public Enums.FixedValueTypes FixedValueType
        {
            get
            {
                return _FixedValueType;
            }
            set
            {
                _FixedValueType = value;
            }
        }

        private string _FixedValue;
        public string FixedValue
        {
            get
            {
                return _FixedValue;
            }
            set
            {
                _FixedValue = value;
            }
        }

        private string _Separator;
        public string Separator
        {
            get
            {
                return _Separator;
            }
            set
            {
                _Separator = value;
            }
        }
    }
}
