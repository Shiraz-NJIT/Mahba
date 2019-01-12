using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Sql
{
    [Serializable]
    public class Connections
    {
        public Connections()
        {
            this.MainDBConnectionString = "";
            this.SettingDBConnectionString = "";
            this.LockServer = "";
        }

        public Connections(string MainDBConnectionString, string SettingDBConnectionString, string LockServer)
        {
            this.MainDBConnectionString = MainDBConnectionString;
            this.SettingDBConnectionString = SettingDBConnectionString;
            this.LockServer = LockServer;
        }

        private string _MainDBConnectionString;
        public string MainDBConnectionString
        {
            get
            {
                return _MainDBConnectionString;
            }
            set
            {
                _MainDBConnectionString = value;
            }
        }

        private string _SettingDBConnectionString;
        public string SettingDBConnectionString
        {
            get
            {
                return _SettingDBConnectionString;
            }
            set
            {
                _SettingDBConnectionString = value;
            }
        }

        private string _LockServer;
        public string LockServer
        {
            get
            {
                return _LockServer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _LockServer = "(local)";
                else
                    _LockServer = value;
            }
        }

        public static Njit.Sql.Connections ReadConnections(string FileName, string Password)
        {
            if (!string.IsNullOrEmpty(FileName) && System.IO.File.Exists(FileName))
            {
                Njit.Common.CryptoService.AESCryptoService aes = new Njit.Common.CryptoService.AESCryptoService();
                aes.SetKey(Password, Password);
                string temp = System.Text.Encoding.UTF8.GetString(aes.Decrypt(System.IO.File.ReadAllBytes(FileName)));
                Njit.Sql.Connections con = null;
                try
                {
                    con = Deserialize(temp);
                }
                catch
                {
                    System.IO.File.Delete(FileName);
                    throw;
                }
                return con;
            }
            return null;
        }

        public static void SaveConnections(string MainConnectionString, string SettingConnectionString, string LockServer, string FileName, string Password)
        {
            Njit.Sql.Connections con = new Njit.Sql.Connections(MainConnectionString, (string.IsNullOrEmpty(SettingConnectionString) ? MainConnectionString : SettingConnectionString), LockServer);
            Njit.Common.CryptoService.AESCryptoService aes = new Njit.Common.CryptoService.AESCryptoService();
            aes.SetKey(Password, Password);
            if (!string.IsNullOrEmpty(FileName))
            {
                string temp = Serialize(con);
                System.IO.File.WriteAllBytes(FileName, aes.Encrypt(System.Text.Encoding.UTF8.GetBytes(temp)));
            }
        }

        private static Connections Deserialize(string text)
        {
            string[] arr = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (arr.Length == 3)
                return new Connections(arr[0], arr[1], arr[2]);
            else
                return new Connections(arr[0], arr[1], "(local)");
        }

        private static string Serialize(Connections con)
        {
            string temp = con.MainDBConnectionString;
            temp += "\r\n";
            temp += con.SettingDBConnectionString;
            temp += "\r\n";
            temp += con.LockServer;
            return temp;
        }
    }
}
