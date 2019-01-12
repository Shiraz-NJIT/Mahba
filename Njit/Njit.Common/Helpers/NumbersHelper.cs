using System;
using System.Globalization;
using System.Linq;

namespace Njit.Common.Helpers
{
    /// <summary>
    /// دارای توابعی برای کار بر روی اعداد
    /// </summary>
    public sealed class NumbersHelper
    {
        private static string[] numberWords = new string[1000];
        private static void BuildMapping()
        {
            numberWords[1] = "يک";
            numberWords[2] = "دو";
            numberWords[3] = "سه";
            numberWords[4] = "چهار";
            numberWords[5] = "پنج";
            numberWords[6] = "شش";
            numberWords[7] = "هفت";
            numberWords[8] = "هشت";
            numberWords[9] = "نه";
            numberWords[10] = "ده";
            numberWords[11] = "یازده";
            numberWords[12] = "دوازده";
            numberWords[13] = "سیزده";
            numberWords[14] = "چهارده";
            numberWords[15] = "پانزده";
            numberWords[16] = "شانزده";
            numberWords[17] = "هفده";
            numberWords[18] = "هجده";
            numberWords[19] = "نوزده";
            numberWords[20] = "بيست";
            numberWords[21] = "سی";
            numberWords[22] = "چهل";
            numberWords[23] = "پنجاه";
            numberWords[24] = "شصت";
            numberWords[25] = "هفتاد";
            numberWords[26] = "هشتاد";
            numberWords[27] = "نود";
            numberWords[28] = "صد";
            numberWords[29] = "هزار";
            numberWords[30] = "میلیون";
            numberWords[31] = "میلیارد";
            numberWords[100] = "یکصد";
            numberWords[200] = "دویست";
            numberWords[300] = "سیصد";
            numberWords[400] = "چهارصد";
            numberWords[500] = "پانصد";
            numberWords[600] = "ششصد";
            numberWords[700] = "هفتصد";
            numberWords[800] = "هشتصد";
            numberWords[900] = "نهصد";
        }

        private static string cvt100(long Number)
        {
            int x = (int)Number;
            int t;
            string result = string.Empty;

            if (x > 999)
            {
                return "";
            }

            if (x > 99)
            {
                t = x / 100;
                switch (t)
                {
                    case 1:
                        result = numberWords[100];
                        break;
                    case 2:
                        result = numberWords[200];
                        break;
                    case 3:
                        result = numberWords[300];
                        break;
                    case 4:
                        result = numberWords[400];
                        break;
                    case 5:
                        result = numberWords[500];
                        break;
                    case 6:
                        result = numberWords[600];
                        break;
                    case 7:
                        result = numberWords[700];
                        break;
                    case 8:
                        result = numberWords[800];
                        break;
                    case 9:
                        result = numberWords[900];
                        break;
                }

                x = x - (t * 100);

                if (x <= 0)
                {
                    return result;
                }
                else
                {
                    result += String.Format(" {0} ", " و "); ;
                }
            }

            if (x > 20)
            {
                t = x / 10;
                result = result + numberWords[t + 18];
                x = x - (t * 10);

                if (x <= 0)
                {
                    return result;
                }
                else
                {
                    result += String.Format(" {0} ", " و "); ;
                }
            }

            if (x > 0)
            {
                result += numberWords[x];
            }

            return result;
        }

        /// <summary>
        /// دریافت مقدار یک عدد به حروف
        /// </summary>
        /// <param name="x">عدد مورد نظر</param>
        /// <returns>مقدار به حروف برگشت داده میشود</returns>
        public static string GetWords(int x)
        {
            return ToString(x);
        }

        /// <summary>
        /// دریافت مقدار یک عدد به حروف
        /// </summary>
        /// <param name="x">عدد مورد نظر</param>
        /// <returns>مقدار به حروف برگشت داده میشود</returns>
        public static string GetWords(string x)
        {
            return ToString(x);
        }

        /// <summary>
        /// دریافت مقدار یک عدد به حروف
        /// </summary>
        /// <param name="x">عدد مورد نظر</param>
        /// <returns>مقدار به حروف برگشت داده میشود</returns>
        public static string GetWords(long x)
        {
            return ToString(x);
        }

        /// <summary>
        /// دریافت مقدار یک عدد به حروف
        /// </summary>
        /// <param name="x">عدد مورد نظر</param>
        /// <returns>مقدار به حروف برگشت داده میشود</returns>
        public static string ToString(int x)
        {
            return (ToString(long.Parse(x.ToString())));
        }

        /// <summary>
        /// دریافت مقدار یک عدد به حروف
        /// </summary>
        /// <param name="x">عدد مورد نظر</param>
        /// <returns>مقدار به حروف برگشت داده میشود</returns>
        public static string ToString(string x)
        {
            try
            {
                return (ToString(long.Parse(x)));
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// دریافت مقدار یک عدد به حروف
        /// </summary>
        /// <param name="x">عدد مورد نظر</param>
        /// <returns>مقدار به حروف برگشت داده میشود</returns>
        public static string ToString(long x)
        {
            if (x == 0)
                return "صفر";

            BuildMapping();

            long t;
            string result = string.Empty;

            if (x > 999999999999)
            {
                return "";
            }

            if (x > 999999999)
            {
                t = x / 1000000000;
                result += cvt100(t) + " " + numberWords[31];
                x = x - (t * 1000000000);

                if (x <= 0)
                {
                    return result;
                }
                else
                {
                    result += String.Format(" {0} ", " و ");
                }
            }

            if (x > 999999)
            {
                t = x / 1000000;
                result += cvt100(t) + " " + numberWords[30];
                x = x - (t * 1000000);

                if (x <= 0)
                {
                    return result;
                }
                else
                {
                    result += String.Format(" {0} ", " و ");
                }
            }

            if (x > 999)
            {
                t = x / 1000;
                result += cvt100(t) + " " + numberWords[29];
                x = x - (t * 1000);

                if (x <= 0)
                {
                    return result;
                }
                else
                {
                    result += String.Format(" {0} ", " و "); ;
                }
            }

            if (x > 0)
            {
                result += cvt100(x);
            }

            return result;
        }

        /// <summary>
        /// گروه بندی هر سه رقم با کاما
        /// </summary>
        /// <param name="number">عدد مورد نظر</param>
        /// <returns>هر سه رقم عدد مورد نظر با کاما جدا میشود و برگشت داده می شود</returns>
        public static string InsertComma(string number)
        {
            number = number.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString(), "");
            if (number != "" && number != null)
            {
                if (!IsDecimal(number) || number.ToLower().Contains('e'))
                    return number;
                string[] str = new string[0];
                if (number.Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]))
                {
                    str = number.Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
                    number = str[0];
                }
                string newText = "";
                int j = 0;
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    newText = newText.Insert(0, number[i].ToString());
                    j++;
                    if (j == 3)
                    {
                        newText = newText.Insert(0, CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString());
                        j = 0;
                    }
                }
                if (newText.StartsWith(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0].ToString()))
                    newText = newText.Substring(1, newText.Length - 1);
                if (str != null && str.Length > 0)
                {
                    for (int i = 1; i < str.Length; i++)
                    {
                        newText += CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString() + str[i];
                    }
                }
                return newText;
            }
            else
                return "";
        }

        /// <summary>
        /// مشخص میکند عدد مورد نظر یک عدد اعشاری است یا خیر
        /// </summary>
        /// <param name="number">عدد مورد نظر</param>
        /// <returns>یک مقدار بولین برگشت داده میشود که مشخص میکند عدد مورد نظر یک عدد اعشاری است یا خیر</returns>
        public static bool IsDecimal(string number)
        {
            decimal temp;
            bool result = decimal.TryParse(number, out temp);
            return result;
        }

        /// <summary>
        /// حذف صفرهای اضافی از آخر یک عدد اعشاری
        /// </summary>
        /// <param name="number">عدد اعشاری مورد نظر</param>
        /// <returns>عدد اعشاری بدون صفر های اضافی برگشت داده میشود</returns>
        public static string RemoveDecimal(string number)
        {
            if (number.Trim() == "")
                return number;
            number = Math.Round(decimal.Parse(number), 18).ToString();
            string[] arr = number.Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
            if (arr.Length == 1)
                return number;
            long i = long.Parse(arr[1]);
            if (i == 0)
                return arr[0];
            else
            {
                int lenth = arr[1].Length;
                for (int t = 0; t < lenth; t++)
                    if (arr[1].EndsWith("0"))
                        arr[1] = arr[1].Substring(0, arr[1].Length - 1);
                return string.Format("{0}.{1}", arr[0], arr[1]);
            }
        }
    }
}
