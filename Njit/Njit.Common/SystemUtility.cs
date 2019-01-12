using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    [Serializable]
    public class SystemUtility : MarshalByRefObject
    {
        #region -------------------------------------------------------

        public bool DirectoryExists(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            System.IO.Directory.CreateDirectory(path);
        }

        public System.IO.FileInfo[] GetDirectoryFilesInfo(string path, string searchPattern, System.IO.SearchOption searchOption)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            return directory.GetFiles(searchPattern, searchOption);
        }

        public System.IO.FileInfo[] GetDirectoryFilesInfo(string path, string searchPattern)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            return directory.GetFiles(searchPattern);
        }

        public System.IO.FileInfo[] GetDirectoryFilesInfo(string path)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            return directory.GetFiles();
        }

        public string[] GetDirectoryFiles(string path, string searchPattern, System.IO.SearchOption searchOption)
        {
            return System.IO.Directory.GetFiles(path, searchPattern, searchOption);
        }

        public string[] GetDirectoryFiles(string path, string searchPattern)
        {
            return System.IO.Directory.GetFiles(path, searchPattern);
        }

        public string[] GetDirectoryFiles(string path)
        {
            return System.IO.Directory.GetFiles(path);
        }

        public int GetDirectoryFilesCount(string path, string searchPattern, System.IO.SearchOption searchOption)
        {
            return System.IO.Directory.GetFiles(path, searchPattern, searchOption).Length;
        }

        public System.IO.FileInfo GetFileInfo(string filePath)
        {
            return new System.IO.FileInfo(filePath);
        }

        public System.Drawing.Icon GetFileIcon(string filePath)
        {
            return System.Drawing.Icon.ExtractAssociatedIcon(filePath);
        }

        public void WriteAllBytesToFile(string filePath, byte[] data)
        {
            System.IO.File.WriteAllBytes(filePath, data);
        }

        public byte[] ReadFileBytes(string filePath)
        {
            return System.IO.File.ReadAllBytes(filePath);
        }

        public System.IO.FileStream OpenFile(string filePath)
        {
            System.IO.FileStream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            return stream;
        }

        public void CopyFile(string sourceFilePath, string destFilePath)
        {
            System.IO.File.Copy(sourceFilePath, destFilePath);
        }

        public void CopyFile(string sourceFilePath, string destFilePath, bool overwrite)
        {
            System.IO.File.Copy(sourceFilePath, destFilePath, overwrite);
        }

        public System.IO.FileStream CreateFile(string path)
        {
            return System.IO.File.Create(path);
        }

        public void CopyFileToClient(string filePath, string clientFilePath, System.Net.IPAddress clientAddress, string networkName, int networkPort)
        {
            System.IO.FileStream serverFile = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            SystemUtility clientUtility = (SystemUtility)System.Runtime.Remoting.RemotingServices.Connect(typeof(SystemUtility), string.Format("tcp://{0}:{1}/{2}", clientAddress.GetString(), networkPort, networkName));
            System.IO.FileStream clientFile = clientUtility.CreateFile(clientFilePath);
            byte[] buffer = new byte[1 * 1024 * 1024];
            int readcount;
            do
            {
                readcount = serverFile.Read(buffer, 0, buffer.Length);
                clientFile.Write(buffer, 0, readcount);
            }
            while (readcount > 0);
            serverFile.Close();
            clientFile.Close();
            serverFile.Dispose();
            clientFile.Dispose();
        }

        public void DeleteFile(string filePath)
        {
            System.IO.File.Delete(filePath);
        }

        public string GetSystemFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.System);
        }

        public string[] GetDrives()
        {
            return System.IO.Directory.GetLogicalDrives();
        }

        public string[] GetFolders(string path, string searchPattern, System.IO.SearchOption searchOption)
        {
            return System.IO.Directory.GetDirectories(path, searchPattern, searchOption);
        }

        #endregion -------------------------------------------------------
        #region ----------------------------------------------------------

        public IEnumerable<System.Net.IPAddress> GetIpAddresses()
        {
            System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            return host.AddressList;
        }

        public IEnumerable<System.Net.IPAddress> GetIpAddressesVersion4()
        {
            return GetIpAddresses().Where(t => t.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
        }

        public IEnumerable<System.Net.IPAddress> GetIpAddressesVersion6()
        {
            return GetIpAddresses().Where(t => t.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6);
        }

        public System.Net.IPAddress GetIpAddress()
        {
            return GetIpAddress(System.Net.Dns.GetHostName());
        }

        public System.Net.IPAddress GetIpAddress(string computerName)
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply replay = ping.Send(computerName);
                if (replay.Status == System.Net.NetworkInformation.IPStatus.Success)
                    return replay.Address;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public string GetComputerName()
        {
            return System.Net.Dns.GetHostName();
        }

        #endregion -------------------------------------------------------
        #region ----------------------------------------------------------

        public event EventHandler<MessageEventArgs> MessageReceived;
        private void OnMessageReceived(string sender, string message)
        {
            if (MessageReceived != null)
                MessageReceived(this, new MessageEventArgs(sender, message));
        }

        public void SendMessage(string sender, string message)
        {
            OnMessageReceived(sender, message);
        }

        public void SendMessage(string sender, string message, System.Net.IPAddress clientAddress, string networkName, int networkPort)
        {
            SystemUtility clientUtility = (SystemUtility)System.Runtime.Remoting.RemotingServices.Connect(typeof(SystemUtility), string.Format("tcp://{0}:{1}/{2}", clientAddress.GetString(), networkPort, networkName));
            clientUtility.SendMessage(sender, message);
        }

        public void SendMessage(string sender, string message, string clientComputerName, string networkName, int networkPort)
        {
            SendMessage(sender, message, GetIpAddress(clientComputerName), networkName, networkPort);
        }

        #endregion -------------------------------------------------------

        public void Hello()
        {

        }

        public System.IO.DriveInfo GetDriveInfo(string driveName)
        {
            return new System.IO.DriveInfo(driveName);
        }
    }
}
