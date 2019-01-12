using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public static class PublicMethods
    {
        /// <summary>
        /// چک کردن اینکه آیا سرور محلی است یا خیر
        /// </summary>
        /// <param name="server">نام سرور</param>
        /// <returns></returns>
        public static bool ServerIsLocal(string server)
        {
            if (server.IsNullOrEmpty())
                return true;
            if (server == ".")
                return true;
            if (server.ToLower() == "(local)")
                return true;
            if (server.ToLower() == Environment.MachineName.ToLower())
                return true;
            if (server == "127.0.0.1")
                return true;
            return false;
        }

        /// <summary>
        /// دریافت آدرس آی پی یک سیستم
        /// </summary>
        /// <param name="server">نام کامپیوتر</param>
        /// <returns></returns>
        public static string GetServerIpAddress(string server)
        {
            if (IsIPV4(server))
                return server;
            if (IsIpV6(server))
            {
                if (server.StartsWith("["))
                    return server;
                else
                    return "[" + server + "]";
            }
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply replay = ping.Send(server);
            return replay.Address.GetString();
        }

        /// <summary>
        /// چک کردن اینکه آدرس IP
        /// ورژن 6 است یا خیر
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public static bool IsIpV6(string server)
        {
            return server.Contains(":");
        }

        /// <summary>
        /// چک کردن اینکه آدرس IP
        /// ورژن 4 است یا خیر
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public static bool IsIPV4(string server)
        {
            string[] ipv4 = server.Split('.');
            if (ipv4.Length != 4)
                return false;
            byte temp;
            foreach (var item in ipv4)
            {
                if (!byte.TryParse(item, out temp))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// اصلاح حروف عربی و تبدیل آنها به حروف فارسی
        /// </summary>
        /// <param name="e"></param>
        public static void FixArabicChars(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 'ي')
                e.KeyChar = 'ی';
            if (e.KeyChar == 'ك')
                e.KeyChar = 'ک';
        }

        /// <summary>
        /// اصلاح حروف عربی و تبدیل آنها به حروف فارسی 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FixArabicChars(string value)
        {
            return value.Replace("ي", "ی").Replace("ك", "ک");
        }

        /// <summary>
        /// تبدیل مقدار
        /// </summary>
        /// <param name="value">مقدار به صورت متنی</param>
        /// <param name="convertedValue">متغیری که مقدار تبدیل شده در آن ذخیره می شود</param>
        /// <param name="type">نوع</param>
        /// <returns>اگر تبدیل انجام شود مقدار True برگردانده می شود</returns>
        public static bool ConvertValue(string value, ref object convertedValue, Type type)
        {
            if (value == null)
                return false;
            if (type == typeof(int) || type == typeof(int?))
            {
                int v;
                if (int.TryParse(value, out v))
                {
                    convertedValue = v;
                    return true;
                }
                else
                    return false;
            }
            if (type == typeof(long) || type == typeof(long?))
            {
                long v;
                if (long.TryParse(value, out v))
                {
                    convertedValue = v;
                    return true;
                }
                else
                    return false;
            }
            if (type == typeof(short) || type == typeof(short?))
            {
                short v;
                if (short.TryParse(value, out v))
                {
                    convertedValue = v;
                    return true;
                }
                else
                    return false;
            }
            if (type == typeof(float) || type == typeof(float?))
            {
                float v;
                if (float.TryParse(value, out v))
                {
                    convertedValue = v;
                    return true;
                }
                else
                    return false;
            }
            if (type == typeof(double) || type == typeof(double?))
            {
                double v;
                if (double.TryParse(value, out v))
                {
                    convertedValue = v;
                    return true;
                }
                else
                    return false;
            }
            if (type == typeof(decimal) || type == typeof(decimal?))
            {
                decimal v;
                if (decimal.TryParse(value, out v))
                {
                    convertedValue = v;
                    return true;
                }
                else
                    return false;
            }
            if (type == typeof(bool) || type == typeof(bool?))
            {
                bool v;
                if (bool.TryParse(value.ToUpper(), out v))
                {
                    convertedValue = v;
                    return true;
                }
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// حذف کاراکتر های غیر مجاز از مسیر فایل یا پوشه
        /// </summary>
        /// <param name="text">مسیر</param>
        /// <returns></returns>
        public static string RemoveInvalidPathAndFileNameChars(string text)
        {
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars())
            {
                text = text.Replace(ch.ToString(), "");
            }
            foreach (char ch in System.IO.Path.GetInvalidPathChars())
            {
                text = text.Replace(ch.ToString(), "");
            }
            return text;
        }

        /// <summary>
        /// جایگزین کردن کاراکتر های غیر مجاز از مسیر فایل یا پوشه
        /// </summary>
        /// <param name="text">مسیر</param>
        /// <param name="replaceWith">جایگزین  کردن کاراکتر ها با این مقدار</param>
        /// <returns></returns>
        public static string ReplaceInvalidPathAndFileNameChars(string text, string replaceWith)
        {
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars())
            {
                text = text.Replace(ch.ToString(), replaceWith);
            }
            foreach (char ch in System.IO.Path.GetInvalidPathChars())
            {
                text = text.Replace(ch.ToString(), replaceWith);
            }
            return text;
        }

        /// <summary>
        /// تبدیل بایت ها به متن
        /// </summary>
        /// <param name="bytes">تعداد بایت ها</param>
        /// <returns></returns>
        public static string GetShortBytesText(long bytes)
        {
            if (bytes >= Math.Pow(1024, 4) && bytes < Math.Pow(1024, 5))
            {
                long tb = (long)(bytes / Math.Pow(1024, 4));
                return tb.ToString() + " ترابایت";
            }
            if (bytes >= Math.Pow(1024, 3) && bytes < Math.Pow(1024, 4))
            {
                long gb = bytes / (1024 * 1024 * 1024);
                return gb.ToString() + " گیگابایت";
            }
            if (bytes >= Math.Pow(1024, 2) && bytes < Math.Pow(1024, 3))
            {
                long mb = bytes / (1024 * 1024);
                return mb.ToString() + " مگابایت";
            }
            if (bytes >= Math.Pow(1024, 1) && bytes < Math.Pow(1024, 2))
            {
                long kb = bytes / 1024;
                return kb.ToString() + " کیلوبایت";
            }
            return bytes.ToString() + " بایت";
        }

        /// <summary>
        /// تبدیل بایت ها به متن
        /// </summary>
        /// <param name="bytes">تعداد بایت ها</param>
        /// <param name="accurateCalculation">اگر با True مقدار دهی شود تا مگا بایت حساب می شود</param>
        /// <returns></returns>
        public static string GetBytesText(long bytes, bool accurateCalculation)
        {
            if (bytes >= Math.Pow(1024, 4) && bytes < Math.Pow(1024, 5))
            {
                long tb = (long)(bytes / Math.Pow(1024, 4));
                long remainderBytes = (long)(bytes % Math.Pow(1024, 4));
                if (remainderBytes > 0)
                    return tb.ToString() + " ترابایت و " + GetBytesText(remainderBytes, accurateCalculation);
                else
                    return tb.ToString() + " ترابایت";
            }
            if (bytes >= Math.Pow(1024, 3) && bytes < Math.Pow(1024, 4))
            {
                long gb = bytes / (1024 * 1024 * 1024);
                long remainderBytes = bytes % (1024 * 1024 * 1024);
                if (remainderBytes > 0)
                    return gb.ToString() + " گیگابایت و " + GetBytesText(remainderBytes, accurateCalculation);
                else
                    return gb.ToString() + " گیگابایت";
            }
            if (bytes >= Math.Pow(1024, 2) && bytes < Math.Pow(1024, 3))
            {
                long mb = bytes / (1024 * 1024);
                long remainderBytes = bytes % (1024 * 1024);
                if (remainderBytes > 0)
                    return mb.ToString() + " مگابایت و " + GetBytesText(remainderBytes, accurateCalculation);
                else
                    return mb.ToString() + " مگابایت";
            }
            if (bytes >= Math.Pow(1024, 1) && bytes < Math.Pow(1024, 2))
            {
                long kb = bytes / 1024;
                if (accurateCalculation)
                {
                    long remainderBytes = bytes % 1024;
                    if (remainderBytes > 0)
                        return kb.ToString() + " کیلوبایت و " + GetBytesText(remainderBytes, accurateCalculation);
                    else
                        return kb.ToString() + " کیلوبایت";
                }
                return kb.ToString() + " کیلوبایت";
            }
            return bytes.ToString() + " بایت";
        }

        /// <summary>
        /// دریافت یک مقدار خاص از متن
        /// </summary>
        /// <param name="text">متن</param>
        /// <param name="keyword">نام مقدار</param>
        /// <param name="dataEndChar">کاراکتر جدا کننده</param>
        /// <returns></returns>
        public static string GetStringData(string text, string keyword, char dataEndChar)
        {
            StringBuilder data = new StringBuilder();
            int i = text.IndexOf(keyword);
            if (i < 0)
                return null;
            i += keyword.Length;
            while (i < text.Length && text[i] != dataEndChar)
            {
                data.Append(text[i]);
                i++;
            }
            return data.ToString();
        }
    }
}
