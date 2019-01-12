using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Njit.Common
{
    /// <summary>
    /// کار با فایل های INI
    /// </summary>
    public class INIFile
    {
        private string _FilePath;
        /// <summary>
        /// مسیر فایل
        /// </summary>
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
            }
        }

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPrivateProfileString([MarshalAs(UnmanagedType.LPWStr)]string lpAppName, [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)]string lpDefault, [MarshalAs(UnmanagedType.LPWStr)] string lpReturnString, int nSize, [MarshalAs(UnmanagedType.LPWStr)]string lpFilename);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int WritePrivateProfileString([MarshalAs(UnmanagedType.LPWStr)]string lpAppName, [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)] string lpString, [MarshalAs(UnmanagedType.LPWStr)] string lpFilename);

        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="FilePath">مسیر فایل</param>
        public INIFile(string FilePath)
        {
            this.FilePath = FilePath;
        }

        /// <summary>
        /// ذخیره مقدار در کلاس
        /// </summary>
        /// <param name="Section">بخش</param>
        /// <param name="Key">کلید</param>
        /// <param name="Value">مقدار</param>
        /// <returns>در صورتی صحیح اجرا شدن مقدار True برگشت داده میشود</returns>
        public bool WriteValue(string Section, string Key, string Value)
        {
            if (!System.IO.File.Exists(this.FilePath))
                System.IO.File.WriteAllText(this.FilePath, "", Encoding.Unicode);
            return WritePrivateProfileString(Section, Key, Value, this.FilePath) == 0 ? false : true;
        }

        /// <summary>
        /// خواندن مقدار از فایل
        /// </summary>
        /// <param name="Section">بخش</param>
        /// <param name="Key">کلید</param>
        /// <returns>مقدار خوانده شده برگشت داده می شود</returns>
        public string ReadValue(string Section, string Key)
        {
            string returnString = new string(' ', 1024);
            GetPrivateProfileString(Section, Key, "", returnString, 1024, this.FilePath);
            return returnString.Split('\0')[0];
        }

        /// <summary>
        /// خواندن مقدار از فایل
        /// </summary>
        /// <param name="Section">بخش</param>
        /// <param name="Key">کلید</param>
        /// <param name="readCount">تعداد حروف خوانده شده در این مقدار قرار می گیرد</param>
        /// <returns>مقدار خوانده شده برگشت داده می شود</returns>
        public string ReadValue(string Section, string Key, out int readCount)
        {
            string returnString = new string(' ', 1024);
            readCount = GetPrivateProfileString(Section, Key, "", returnString, 1024, this.FilePath);
            return returnString.Split('\0')[0];
        }
    }
}
