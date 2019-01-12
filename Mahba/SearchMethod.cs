using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware
{
    public class SearchMethod
    {
        public static SearchMethod Equal = new SearchMethod((int)SearchMethods.Equal, "مساوی باشد با", true);
        public static SearchMethod NotEqual = new SearchMethod((int)SearchMethods.NotEqual, "مساوی نباشد با", true);
        public static SearchMethod Contains = new SearchMethod((int)SearchMethods.Contains, "حاوی", true);
        public static SearchMethod StartsWith = new SearchMethod((int)SearchMethods.StartsWith, "شروع شود با", true);
        public static SearchMethod NotStartsWith = new SearchMethod((int)SearchMethods.NotStartsWith, "شروع نشود با", true);
        public static SearchMethod EndsWith = new SearchMethod((int)SearchMethods.EndsWith, "خاتمه یابد با", true);
        public static SearchMethod NotEndsWith = new SearchMethod((int)SearchMethods.NotEndsWith, "خاتمه نیابد با", true);
        public static SearchMethod LessThan = new SearchMethod((int)SearchMethods.LessThan, "کوچکتر از", true);
        public static SearchMethod LessThanOrEqual = new SearchMethod((int)SearchMethods.LessThanOrEqual, "کوچکتر یا مساوی با", true);
        public static SearchMethod GreaterThan = new SearchMethod((int)SearchMethods.GreaterThan, "بزرگتر از", true);
        public static SearchMethod GreaterThanOrEqual = new SearchMethod((int)SearchMethods.GreaterThanOrEqual, "بزرگتر یا مساوی با", true);
        public static SearchMethod IsNull = new SearchMethod((int)SearchMethods.IsNull, "خالی باشد", false);
        public static SearchMethod IsNotNull = new SearchMethod((int)SearchMethods.IsNotNull, "خالی نباشد", false);
        public static SearchMethod In = new SearchMethod((int)SearchMethods.In, "یکی از مقادیر", true, "مقادیر را با کاما از یکدیگر جدا کنید");
        public static SearchMethod NotIn = new SearchMethod((int)SearchMethods.NotIn, "هیچکدام از مقادیر", true, "مقادیر را با کاما از یکدیگر جدا کنید");

        public enum SearchMethods
        {
            Equal,
            NotEqual,
            Contains,
            StartsWith,
            NotStartsWith,
            EndsWith,
            NotEndsWith,
            LessThan,
            LessThanOrEqual,
            GreaterThan,
            GreaterThanOrEqual,
            IsNull,
            IsNotNull,
            In,
            NotIn
        }

        public SearchMethod(int Code, string Title, bool RequiredValue, string Explain = null)
        {
            this.Code = Code;
            this.Title = Title;
            this.RequiredValue = RequiredValue;
            this.Explain = Explain;
        }

        private int _Code;
        public int Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
            }
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

        private bool _RequiredValue;
        public bool RequiredValue
        {
            get
            {
                return _RequiredValue;
            }
            set
            {
                _RequiredValue = value;
            }
        }

        private string _Explain;
        public string Explain
        {
            get
            {
                return _Explain;
            }
            set
            {
                _Explain = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is SearchMethod)
                return (obj as SearchMethod).Code == this.Code;
            return false;
        }

        public static bool operator !=(SearchMethod left, SearchMethod right)
        {
            return !(left == right);
        }

        public static bool operator ==(SearchMethod left, SearchMethod right)
        {
            if (object.ReferenceEquals(left, null))
                return object.ReferenceEquals(right, null);
            return left.Equals(right);
        }

        public override int GetHashCode()
        {
            return this.Code;
        }

        internal static List<SearchMethod> GetAllSearchMethods()
        {
            List<SearchMethod> list = new List<SearchMethod>();
            list.Add(StartsWith);
            list.Add(Equal);
            list.Add(NotEqual);
            list.Add(Contains);
          
            list.Add(NotStartsWith);
            list.Add(EndsWith);
            list.Add(NotEndsWith);
            list.Add(LessThan);
            list.Add(LessThanOrEqual);
            list.Add(GreaterThan);
            list.Add(GreaterThanOrEqual);
            list.Add(IsNull);
            list.Add(IsNotNull);
            list.Add(In);
            list.Add(NotIn);
            return list;
        }
    }
}
