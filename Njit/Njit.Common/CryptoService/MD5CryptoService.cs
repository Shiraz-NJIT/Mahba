using System;
using System.Collections.Generic;

namespace Njit.Common.CryptoService
{
    /// <summary>
    /// هش کردن داده ها با الگوریتم
    /// MD5
    /// </summary>
    public class MD5CryptoService
    {
        private System.Security.Cryptography.MD5CryptoServiceProvider _md5;
        public System.Security.Cryptography.MD5CryptoServiceProvider MD5
        {
            get
            {
                if (_md5 == null)
                    _md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                return _md5;
            }
        }

        /// <summary>
        /// هش کردن داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        /// <returns>مقدار هش شده برگشت داده می شود</returns>
        public byte[] ComputeHash(byte[] data)
        {
            return MD5.ComputeHash(data);
        }

        /// <summary>
        /// هش کردن متن
        /// </summary>
        /// <param name="data">متن</param>
        /// <returns>مقدار هش شده برگشت داده می شود</returns>
        public string ComputeHash(string data)
        {
            return Convert.ToBase64String(MD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data)));
        }

        /// <summary>
        /// دریافت مقدار هش یک فایل
        /// </summary>
        /// <param name="filePath">مسیر فایل</param>
        /// <returns>مقدار هش شده برگشت داده می شود</returns>
        public string GetFileMD5(string filePath)
        {
            System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
            byte[] md5bytes = MD5.ComputeHash(stream);
            stream.Close();
            stream.Dispose();
            return Convert.ToBase64String(md5bytes);
        }
    }
}
