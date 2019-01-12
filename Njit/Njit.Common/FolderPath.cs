using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Njit.Common
{
    public class FolderPath
    {
        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);

        public enum SpecialFolder
        {
            /// <summary>
            /// Desktop
            /// </summary>
            Desktop = 0x0000,
            /// <summary>
            /// Internet Explorer (icon on desktop)
            /// </summary>
            Internet = 0x0001,
            /// <summary>
            /// Start Menu\Programs
            /// </summary>
            Programs = 0x0002,
            /// <summary>
            /// My Computer\Control Panel
            /// </summary>
            Controls = 0x0003,
            /// <summary>
            /// My Computer\Printers
            /// </summary>
            Printers = 0x0004,
            /// <summary>
            /// My Documents
            /// </summary>
            Personal = 0x0005,
            /// <summary>
            /// UserName\Favorites
            /// </summary>
            Favorites = 0x0006,
            /// <summary>
            /// Start Menu\Programs\Startup
            /// </summary>
            Startup = 0x0007,
            /// <summary>
            /// UserName\Recent
            /// </summary>
            Recent = 0x0008,
            /// <summary>
            /// UserName\SendTo
            /// </summary>
            SendTo = 0x0009,
            /// <summary>
            /// Desktop\Recycle Bin
            /// </summary>
            RecycleBin = 0x000a,
            /// <summary>
            /// UserName\Start Menu
            /// </summary>
            StartMenu = 0x000b,
            /// <summary>
            /// Personal was just a silly name for My Documents
            /// </summary>
            MyDocuments = Personal,
            /// <summary>
            /// "My Music" folder
            /// </summary>
            MyMusic = 0x000d,
            /// <summary>
            /// "My Videos" folder
            /// </summary>
            MyVideos = 0x000e,
            /// <summary>
            /// UserName\Desktop
            /// </summary>
            DesktopDirectory = 0x0010,
            /// <summary>
            /// My Computer
            /// </summary>
            Drives = 0x0011,
            /// <summary>
            /// Network Neighborhood (My Network Places)
            /// </summary>
            Network = 0x0012,
            /// <summary>
            /// UserName\nethood
            /// </summary>
            Nethood = 0x0013,
            /// <summary>
            /// windows\fonts
            /// </summary>
            Fonts = 0x0014,
            Templates = 0x0015,
            /// <summary>
            /// All Users\Start Menu
            /// </summary>
            Common_StartMenu = 0x0016,
            /// <summary>
            /// All Users\Start Menu\Programs
            /// </summary>
            Common_Programs = 0x0017,
            /// <summary>
            /// All Users\Startup
            /// </summary>
            Common_Startup = 0x0018,
            /// <summary>
            /// All Users\Desktop
            /// </summary>
            Common_Desktop = 0x0019,
            /// <summary>
            /// UserName\Application Data
            /// </summary>
            AppData = 0x001a,
            /// <summary>
            /// UserName\PrintHood
            /// </summary>
            PrintHood = 0x001b,
            /// <summary>
            /// UserName\Local Settings\Applicaiton Data (non roaming)
            /// </summary>
            Local_AppData = 0x001c,
            /// <summary>
            /// non localized startup
            /// </summary>
            AltStartup = 0x001d,
            /// <summary>
            /// non localized common startup
            /// </summary>
            Common_AltStartup = 0x001e,
            Common_Favotites = 0x001f,
            Internet_Cache = 0x0020,
            Cookies = 0x0021,
            History = 0x0022,
            /// <summary>
            /// All Users\Application Data
            /// </summary>
            Common_AppData = 0x0023,
            /// <summary>
            /// GetWindowsDirectory()
            /// </summary>
            Windows = 0x0024,
            /// <summary>
            /// GetSystemDirectory()
            /// </summary>
            System = 0x0025,
            /// <summary>
            /// C:\Program Files
            /// </summary>
            Program_Files = 0x0026,
            /// <summary>
            /// C:\Program Files\My Pictures
            /// </summary>
            MyPictures = 0x0027,
            /// <summary>
            /// USERPROFILE
            /// </summary>
            Profile = 0x0028,
            /// <summary>
            /// x86 system directory on RISC
            /// </summary>
            SystemX86 = 0x0029,
            /// <summary>
            /// x86 C:\Program Files on RISC
            /// </summary>
            Program_FilesX86 = 0x002a,
            /// <summary>
            /// C:\Program Files\Common
            /// </summary>
            Program_Files_Common = 0x002b,
            /// <summary>
            /// x86 Program Files\Common on RISC
            /// </summary>
            Program_Files_CommonX86 = 0x002c,
            /// <summary>
            /// All Users\Templates
            /// </summary>
            Common_Templates = 0x002d,
            /// <summary>
            /// All Users\Documents
            /// </summary>
            Common_Documents = 0x002e,
            /// <summary>
            /// All Users\Start Menu\Programs\Administrative Tools
            /// </summary>
            Common_AdminTools = 0x002f,
            /// <summary>
            /// UserName\Start Menu\Programs\Administrative Tools
            /// </summary>
            AdminTools = 0x0030,
            /// <summary>
            /// Network and Dial-up Connections
            /// </summary>
            Connections = 0x0031,
            /// <summary>
            /// All Users\My Music
            /// </summary>
            Common_Music = 0x0035,
            /// <summary>
            /// All Users\My Pictures
            /// </summary>
            Common_Pictures = 0x0036,
            /// <summary>
            /// All Users\My Video
            /// </summary>
            Common_Video = 0x0037,
            /// <summary>
            /// Resource Direcotry
            /// </summary>
            Resources = 0x0038,
            /// <summary>
            /// Localized Resource Direcotry
            /// </summary>
            Resources_Localized = 0x0039,
            /// <summary>
            /// Links to All Users OEM specific apps
            /// </summary>
            Common_OEM_Links = 0x003a,
            /// <summary>
            /// USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
            /// </summary>
            CDBurn_Area = 0x003b,
            /// <summary>
            /// Computers Near Me (computered from Workgroup membership)
            /// </summary>
            ComputersNearMe = 0x003d,
            /// <summary>
            /// combine with CSIDL_ value to force folder creation in SHGetFolderPath()
            /// </summary>
            Flag_Create = 0x8000,
            /// <summary>
            /// combine with CSIDL_ value to return an unverified folder path
            /// </summary>
            FLAG_DONT_VERIFY = 0x4000,
            /// <summary>
            /// combine with CSIDL_ value to avoid unexpanding environment variables
            /// </summary>
            Flag_Dont_Unexpand = 0x2000,
            /// <summary>
            /// combine with CSIDL_ value to insure non-alias versions of the pidl
            /// </summary>
            Flag_No_Alias = 0x1000,
            /// <summary>
            /// combine with CSIDL_ value to indicate per-user init (eg. upgrade)
            /// </summary>
            Flag_Per_User_Init = 0x0800,
        }

        public static string GetFolderPath(SpecialFolder folder)
        {
            StringBuilder path = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, path, (int)folder, false);
            return path.ToString();
        }
    }
}
