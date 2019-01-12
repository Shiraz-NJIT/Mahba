using System;
using System.Collections.Generic;

namespace Njit.Common.CryptoService
{
    public class AESCryptoService
    {
        private System.Security.Cryptography.AesCryptoServiceProvider _Aes;
        private System.Security.Cryptography.AesCryptoServiceProvider Aes
        {
            get
            {
                if (_Aes == null)
                {
                    _Aes = new System.Security.Cryptography.AesCryptoServiceProvider();
                }
                return _Aes;
            }
        }
        public void SetKey(byte[] password1, byte[] password2)
        {
            Aes.Key = password1;
            Aes.IV = password2;
        }
        public void SetKey(string password1, string password2)
        {
            if (password1.Length > 32)
                password1 = password1.Substring(0, 32);
            if (password2.Length > 16)
                password2 = password2.Substring(0, 16);
            Aes.Key = System.Text.Encoding.UTF8.GetBytes(password1.PadRight(32, '*'));
            Aes.IV = System.Text.Encoding.UTF8.GetBytes(password2.PadRight(16, '*'));
        }
        //----------------------------------------------------------
        public void Encrypt(System.IO.Stream InputStream, System.IO.Stream OutputStream, byte[] Key, byte[] IV)
        {
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(OutputStream, Aes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(OutputStream, Aes.CreateEncryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Write);
            int readCount = 0;
            byte[] Data = new byte[1024];
            do
            {
                readCount = InputStream.Read(Data, 0, 1024);
                _CryptoStream.Write(Data, 0, readCount);
            }
            while (readCount > 0);
            _CryptoStream.FlushFinalBlock();
            _CryptoStream.Close();
            _CryptoStream.Dispose();
        }
        //----------------------
        public void Encrypt(System.IO.Stream InputStream, System.IO.Stream OutputStream)
        {
            Encrypt(InputStream, OutputStream, null, null);
        }
        //----------------------
        public byte[] Encrypt(byte[] Data, byte[] Key, byte[] IV)
        {
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, Aes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, Aes.CreateEncryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Write);
            _CryptoStream.Write(Data, 0, Data.Length);
            _CryptoStream.FlushFinalBlock();
            byte[] _EncryptedData = _MemoryStream.ToArray();
            _CryptoStream.Close();
            _MemoryStream.Close();
            _CryptoStream.Dispose();
            _MemoryStream.Dispose();
            return _EncryptedData;
        }
        //----------------------
        public byte[] Encrypt(string Data, byte[] Key, byte[] IV)
        {
            return Encrypt(System.Text.Encoding.UTF8.GetBytes(Data), Key, IV);
        }
        //----------------------
        public byte[] Encrypt(byte[] Data)
        {
            return Encrypt(Data, null, null);
        }
        //----------------------
        public byte[] Encrypt(string Data)
        {
            return Encrypt(System.Text.Encoding.UTF8.GetBytes(Data), null, null);
        }
        //----------------------------------------------------------
        public void Decrypt(System.IO.Stream InputStream, System.IO.Stream OutputStream, byte[] Key, byte[] IV)
        {
            //#region TinyLockCheck
            //System.Threading.Thread lockThread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            //{
            //    //if (!Njit.Common.PublicMethods.ServerIsLocal(Njit.Program.Options.LockServer))
            //    //    return;
            //    bool __AllowTrail = true;
            //    try
            //    {
            //        if (__AllowTrail)
            //        {
            //            System.Data.DataTable tableList = Njit.Program.Options.MainDataAccess.GetData("SELECT * FROM [sys].[Tables]");
            //            foreach (System.Data.DataRow row in tableList.Rows)
            //            {
            //                int count = int.Parse(Njit.Program.Options.MainDataAccess.ExecuteScalar(string.Format("SELECT Count(*) FROM [{0}]", row["Name"])).ToString());
            //                if (count > (Njit.Program.Options.MaxRowCount > 500 ? 500 : (Njit.Program.Options.MaxRowCount < 1 ? 1 : Njit.Program.Options.MaxRowCount)))
            //                {
            //                    goto checklock;
            //                }
            //            }
            //            tableList.Dispose();
            //        }
            //        else
            //        {
            //            goto checklock;
            //        }
            //    }
            //    catch
            //    {
            //        UI.LockError errform = new UI.LockError(0);
            //        errform.Show();
            //        errform.Refresh();
            //        System.Threading.Thread.Sleep(5000);
            //        errform.Close();
            //        errform.Dispose();
            //        Environment.Exit(13);
            //        return;
            //    }
            //    return;
            //checklock:
            //    try
            //    {
            //        if (Cryptography.MD5CryptoService.GetFileMD5("Tiny.ocx") != "CJdp3mJ/1KO9k7/PoX7pGA==")
            //        {
            //            UI.LockError errform = new UI.LockError(0);
            //            errform.Show();
            //            errform.Refresh();
            //            System.Threading.Thread.Sleep(5000);
            //            errform.Close();
            //            errform.Dispose();
            //            Environment.Exit(13);
            //            return;
            //        }
            //        TINYLib.TinyClass myTiny = new TINYLib.TinyClass();
            //        if (Njit.Common.PublicMethods.ServerIsLocal(Njit.Program.Options.LockServer))
            //        {
            //            myTiny.FirstTinyHID(/*"1520C0E7B0D9B6ADDC248E916575A16D"*/"A29ACA157D9DAFD89C8EC75675F79");
            //            if (myTiny.TinyErrCode != 0)
            //            {
            //                UI.LockError errform = new UI.LockError(myTiny.TinyErrCode * 3 + 1000);
            //                errform.Show();
            //                errform.Refresh();
            //                System.Threading.Thread.Sleep(5000);
            //                errform.Close();
            //                errform.Dispose();
            //                Environment.Exit(13);
            //                return;
            //            }
            //            //ReadData
            //        }
            //        else
            //        {
            //            myTiny.ServerIP = Njit.Program.Options.LockServer;
            //            myTiny.NetWorkINIT = true;
            //            if (myTiny.TinyErrCode != 0)
            //            {
            //                UI.LockError errform = new UI.LockError(myTiny.TinyErrCode * 3 + 1000);
            //                errform.Show();
            //                errform.Refresh();
            //                System.Threading.Thread.Sleep(5000);
            //                errform.Close();
            //                errform.Dispose();
            //                Environment.Exit(13);
            //                return;
            //            }
            //            else
            //            {
            //                myTiny.UserPassWord = /*"1520C0E7B0D9B6ADDC248E916575A16D"*/"A29ACA157D9DAFD89C8EC75675F79";
            //                myTiny.ShowTinyInfo = true;
            //                if (myTiny.TinyErrCode != 0)
            //                {
            //                    UI.LockError errform = new UI.LockError(myTiny.TinyErrCode * 3 + 1000);
            //                    errform.Show();
            //                    errform.Refresh();
            //                    System.Threading.Thread.Sleep(5000);
            //                    errform.Close();
            //                    errform.Dispose();
            //                    Environment.Exit(13);
            //                    return;
            //                }
            //                //ReadData
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        UI.LockError errform = new UI.LockError(0);
            //        errform.Show();
            //        errform.Refresh();
            //        System.Threading.Thread.Sleep(5000);
            //        errform.Close();
            //        errform.Dispose();
            //        Environment.Exit(13);
            //        return;
            //    }
            //    return;
            //}
            //));
            //lockThread.Start();
            //#endregion
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(InputStream, Aes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(InputStream, Aes.CreateDecryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Read);
            int readCount = 0;
            byte[] Data = new byte[1024];
            do
            {
                readCount = _CryptoStream.Read(Data, 0, 1024);
                OutputStream.Write(Data, 0, readCount);
            }
            while (readCount > 0);
            OutputStream.Flush();
        }
        //----------------------
        public void Decrypt(System.IO.Stream InputStream, System.IO.Stream OutputStream)
        {
            Decrypt(InputStream, OutputStream, null, null);
        }
        //----------------------
        public byte[] Decrypt(byte[] Data, byte[] Key, byte[] IV)
        {
            //#region TinyLockCheck
            //System.Threading.Thread lockThread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            //{
            //    //if (!Njit.Common.PublicMethods.ServerIsLocal(Njit.Program.Options.LockServer))
            //    //    return;
            //    bool __AllowTrail = true;
            //    try
            //    {
            //        if (__AllowTrail)
            //        {
            //            System.Data.DataTable tableList = Njit.Program.Options.MainDataAccess.GetData("SELECT * FROM [sys].[Tables]");
            //            foreach (System.Data.DataRow row in tableList.Rows)
            //            {
            //                int count = int.Parse(Njit.Program.Options.MainDataAccess.ExecuteScalar(string.Format("SELECT Count(*) FROM [{0}]", row["Name"])).ToString());
            //                if (count > (Njit.Program.Options.MaxRowCount > 500 ? 500 : (Njit.Program.Options.MaxRowCount < 1 ? 1 : Njit.Program.Options.MaxRowCount)))
            //                {
            //                    goto checklock;
            //                }
            //            }
            //            tableList.Dispose();
            //        }
            //        else
            //        {
            //            goto checklock;
            //        }
            //    }
            //    catch
            //    {
            //        UI.LockError errform = new UI.LockError(0);
            //        errform.Show();
            //        errform.Refresh();
            //        System.Threading.Thread.Sleep(5000);
            //        errform.Close();
            //        errform.Dispose();
            //        Environment.Exit(13);
            //        return;
            //    }
            //    return;
            //checklock:
            //    try
            //    {
            //        if (Cryptography.MD5CryptoService.GetFileMD5("Tiny.ocx") != "CJdp3mJ/1KO9k7/PoX7pGA==")
            //        {
            //            UI.LockError errform = new UI.LockError(0);
            //            errform.Show();
            //            errform.Refresh();
            //            System.Threading.Thread.Sleep(5000);
            //            errform.Close();
            //            errform.Dispose();
            //            Environment.Exit(13);
            //            return;
            //        }
            //        TINYLib.TinyClass myTiny = new TINYLib.TinyClass();
            //        if (Njit.Common.PublicMethods.ServerIsLocal(Njit.Program.Options.LockServer))
            //        {
            //            myTiny.FirstTinyHID(/*"1520C0E7B0D9B6ADDC248E916575A16D"*/"A29ACA157D9DAFD89C8EC75675F79");
            //            if (myTiny.TinyErrCode != 0)
            //            {
            //                UI.LockError errform = new UI.LockError(myTiny.TinyErrCode * 3 + 1000);
            //                errform.Show();
            //                errform.Refresh();
            //                System.Threading.Thread.Sleep(5000);
            //                errform.Close();
            //                errform.Dispose();
            //                Environment.Exit(13);
            //                return;
            //            }
            //            //ReadData
            //        }
            //        else
            //        {
            //            myTiny.ServerIP = Njit.Program.Options.LockServer;
            //            myTiny.NetWorkINIT = true;
            //            if (myTiny.TinyErrCode != 0)
            //            {
            //                UI.LockError errform = new UI.LockError(myTiny.TinyErrCode * 3 + 1000);
            //                errform.Show();
            //                errform.Refresh();
            //                System.Threading.Thread.Sleep(5000);
            //                errform.Close();
            //                errform.Dispose();
            //                Environment.Exit(13);
            //                return;
            //            }
            //            else
            //            {
            //                myTiny.UserPassWord = /*"1520C0E7B0D9B6ADDC248E916575A16D"*/"A29ACA157D9DAFD89C8EC75675F79";
            //                myTiny.ShowTinyInfo = true;
            //                if (myTiny.TinyErrCode != 0)
            //                {
            //                    UI.LockError errform = new UI.LockError(myTiny.TinyErrCode * 3 + 1000);
            //                    errform.Show();
            //                    errform.Refresh();
            //                    System.Threading.Thread.Sleep(5000);
            //                    errform.Close();
            //                    errform.Dispose();
            //                    Environment.Exit(13);
            //                    return;
            //                }
            //                //ReadData
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        UI.LockError errform = new UI.LockError(0);
            //        errform.Show();
            //        errform.Refresh();
            //        System.Threading.Thread.Sleep(5000);
            //        errform.Close();
            //        errform.Dispose();
            //        Environment.Exit(13);
            //        return;
            //    }
            //    return;
            //}
            //));
            //lockThread.Start();
            //#endregion
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream(Data);
            System.Security.Cryptography.CryptoStream _CryptoStream;
            if (Key == null && IV == null)
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, Aes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read);
            else
                _CryptoStream = new System.Security.Cryptography.CryptoStream(_MemoryStream, Aes.CreateDecryptor(Key, IV), System.Security.Cryptography.CryptoStreamMode.Read);
            System.IO.MemoryStream _OutMemoryStream = new System.IO.MemoryStream();
            byte[] TempData = new byte[1024];
            int readCount = 0;
            do
            {
                readCount = _CryptoStream.Read(TempData, 0, 1024);
                _OutMemoryStream.Write(TempData, 0, readCount);
            }
            while (readCount > 0);
            _CryptoStream.Close();
            _MemoryStream.Close();
            _CryptoStream.Dispose();
            _MemoryStream.Dispose();
            byte[] DecryptedData = _OutMemoryStream.ToArray();
            _OutMemoryStream.Close();
            _OutMemoryStream.Dispose();
            return DecryptedData;
        }
        //----------------------
        public byte[] Decrypt(byte[] Data)
        {
            return Decrypt(Data, null, null);
        }
        //----------------------
        public string DecryptToString(byte[] Data)
        {
            return System.Text.Encoding.UTF8.GetString(Decrypt(Data, null, null));
        }
    }
}