using System;
using System.Collections.Generic;

namespace Njit.Common.CryptoService
{
    /// <summary>
    /// کلاس رمزگذاری داده ها با الگوریتم
    /// DES
    /// </summary>
    public class DESCryptoService
    {
        private System.Security.Cryptography.DESCryptoServiceProvider _DES;
        public System.Security.Cryptography.DESCryptoServiceProvider DES
        {
            get
            {
                if (_DES == null)
                    _DES = new System.Security.Cryptography.DESCryptoServiceProvider();
                return _DES;
            }
        }

        /// <summary>
        /// مشخص کردن رمز
        /// </summary>
        /// <param name="password1">Key</param>
        /// <param name="password2">IV</param>
        public void SetKey(string password1, string password2)
        {
            if (password1.Length > 8)
                password1 = password1.Substring(0, 8);
            if (password2.Length > 8)
                password2 = password2.Substring(0, 8);
            DES.Key = System.Text.Encoding.UTF8.GetBytes(password1.PadRight(8, '*'));
            DES.IV = System.Text.Encoding.UTF8.GetBytes(password2.PadRight(8, '*'));
        }

        /// <summary>
        /// رمز گذاری استریم
        /// </summary>
        /// <param name="inputStream">استریم مورد نظر</param>
        /// <param name="outputStream">استریمی که رمز گذاری شود</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        public void Encrypt(System.IO.Stream inputStream, System.IO.Stream outputStream, byte[] Key, byte[] IV)
        {
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(outputStream, DES.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(outputStream, DES.CreateEncryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Write);
            int readCount = 0;
            byte[] Data = new byte[2048];
            do
            {
                readCount = inputStream.Read(Data, 0, 2048);
                _CryptoStream.Write(Data, 0, readCount);
            }
            while (readCount > 0);
            _CryptoStream.FlushFinalBlock();
            _CryptoStream.Close();
            _CryptoStream.Dispose();
        }

        /// <summary>
        /// رمز گذاری استریم
        /// </summary>
        /// <param name="inputStream">استریم مورد نظر</param>
        /// <param name="outputStream">استریمی که رمز گذاری شود</param>
        public void Encrypt(System.IO.Stream inputStream, System.IO.Stream outputStream)
        {
            Encrypt(inputStream, outputStream, null, null);
        }

        /// <summary>
        /// رمز گذاری داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        public byte[] Encrypt(byte[] data, byte[] Key, byte[] IV)
        {
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, DES.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, DES.CreateEncryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Write);
            _CryptoStream.Write(data, 0, data.Length);
            _CryptoStream.FlushFinalBlock();
            byte[] _EncryptedData = _MemoryStream.ToArray();
            _CryptoStream.Close();
            _MemoryStream.Close();
            _CryptoStream.Dispose();
            _MemoryStream.Dispose();
            return _EncryptedData;
        }

        /// <summary>
        /// رمز گذاری متن
        /// </summary>
        /// <param name="data">متن</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        public byte[] Encrypt(string data, byte[] Key, byte[] IV)
        {
            return Encrypt(System.Text.Encoding.UTF8.GetBytes(data), Key, IV);
        }

        /// <summary>
        /// رمز گذاری داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        public byte[] Encrypt(byte[] data)
        {
            return Encrypt(data, null, null);
        }

        /// <summary>
        /// رمز گذاری متن
        /// </summary>
        /// <param name="data">متن</param>
        public byte[] Encrypt(string data)
        {
            return Encrypt(System.Text.Encoding.UTF8.GetBytes(data), null, null);
        }

        /// <summary>
        /// رمز گذاری متن
        /// </summary>
        /// <param name="data">متن</param>
        public string EncryptToBase64(string data)
        {
            return Convert.ToBase64String(Encrypt(System.Text.Encoding.UTF8.GetBytes(data), null, null));
        }

        /// <summary>
        /// رمز گذاری داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        public string EncryptToBase64(byte[] data)
        {
            return Convert.ToBase64String(Encrypt(data, null, null));
        }

        /// <summary>
        /// رمز گشایی استریم
        /// </summary>
        /// <param name="inputStream">استریم رمز شده</param>
        /// <param name="outputStream">استریمی که مقدار رمزگشایی شده در آن قرار میگیرد</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        public void Decrypt(System.IO.Stream inputStream, System.IO.Stream outputStream, byte[] Key, byte[] IV)
        {
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(inputStream, DES.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(inputStream, DES.CreateDecryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Read);

            int readCount = 0;
            byte[] Data = new byte[2048];
            do
            {
                readCount = _CryptoStream.Read(Data, 0, 2048);
                outputStream.Write(Data, 0, readCount);
            }
            while (readCount > 0);
            outputStream.Flush();
        }

        /// <summary>
        /// رمز گشایی استریم
        /// </summary>
        /// <param name="inputStream">استریم رمز شده</param>
        /// <param name="outputStream">استریمی که مقدار رمزگشایی شده در آن قرار میگیرد</param>
        public void Decrypt(System.IO.Stream inputStream, System.IO.Stream outputStream)
        {
            Decrypt(inputStream, outputStream, null, null);
        }

        /// <summary>
        /// رمزگشایی داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        /// <param name="Key">Key</param>
        /// <param name="IV">IV</param>
        public byte[] Decrypt(byte[] data, byte[] Key, byte[] IV)
        {
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream(data);
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, DES.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, DES.CreateDecryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Read);
            List<byte> DecryptedDataList = new List<byte>();
            byte[] TempData = new byte[2048];
            int readCount = 0;
            do
            {
                readCount = _CryptoStream.Read(TempData, 0, 2048);
                for (int i = 0; i < readCount; i++)
                {
                    DecryptedDataList.Add(TempData[i]);
                }
            }
            while (readCount > 0);
            _CryptoStream.Close();
            _MemoryStream.Close();
            _CryptoStream.Dispose();
            _MemoryStream.Dispose();
            return DecryptedDataList.ToArray();
        }

        /// <summary>
        /// رمزگشایی داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        public byte[] Decrypt(byte[] data)
        {
            return Decrypt(data, null, null);
        }

        /// <summary>
        /// رمزگشایی داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        public string DecryptToString(byte[] data)
        {
            return System.Text.Encoding.UTF8.GetString(Decrypt(data, null, null));
        }

        /// <summary>
        /// رمزگشایی داده ها
        /// </summary>
        /// <param name="data">داده ها</param>
        public string DecryptFromBase64(string data)
        {
            return System.Text.Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(data), null, null));
        }
    }
}