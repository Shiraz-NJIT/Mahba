using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;

namespace Njit.Common
{
    public static class Win32
    {
        [Browsable(false)]
        /// <summary>
        /// مشخص میکند که ویندوز جاری ویندوز ویستا یا بالاتر است
        /// </summary>
        public static bool IsVistaOrLater
        {
            get
            {
                return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6;
            }
        }

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args)
        {
            string message = string.Format(format, args);
            return RegisterWindowMessage(message);
        }

        public const int HWND_BROADCAST = 0xffff;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImportAttribute("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowToFront(IntPtr window)
        {
            ShowWindow(window, SW_SHOWNORMAL);
            SetForegroundWindow(window);
        }

        public const int BS_COMMANDLINK = 0x0000000E;
        public const int BCM_SETNOTE = 0x00001609;
        public const int BCM_SETSHIELD = 0x0000160C;

        public const int TV_FIRST = 0x1100;
        public const int TVM_SETEXTENDEDSTYLE = TV_FIRST + 44;
        public const int TVM_GETEXTENDEDSTYLE = TV_FIRST + 45;
        public const int TVM_SETAUTOSCROLLINFO = TV_FIRST + 59;
        public const int TVS_NOHSCROLL = 0x8000;
        public const int TVS_EX_AUTOHSCROLL = 0x0020;
        public const int TVS_EX_FADEINOUTEXPANDOS = 0x0040;
        public const int GWL_STYLE = -16;

        // Various important window messages
        public const int WM_USER = 0x0400;
        public const int WM_ENTERIDLE = 0x0121;

        // FormatMessage constants and structs
        public const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("user32", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);


        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        #region File Operations Definitions

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        public struct COMDLG_FILTERSPEC
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszSpec;
        }

        public enum FDAP
        {
            FDAP_BOTTOM = 0x00000000,
            FDAP_TOP = 0x00000001,
        }

        public enum FDE_SHAREVIOLATION_RESPONSE
        {
            FDESVR_DEFAULT = 0x00000000,
            FDESVR_ACCEPT = 0x00000001,
            FDESVR_REFUSE = 0x00000002
        }

        public enum FDE_OVERWRITE_RESPONSE
        {
            FDEOR_DEFAULT = 0x00000000,
            FDEOR_ACCEPT = 0x00000001,
            FDEOR_REFUSE = 0x00000002
        }

        public enum SIATTRIBFLAGS
        {
            SIATTRIBFLAGS_AND = 0x00000001, // if multiple items and the attirbutes together.
            SIATTRIBFLAGS_OR = 0x00000002, // if multiple items or the attributes together.
            SIATTRIBFLAGS_APPCOMPAT = 0x00000003, // Call GetAttributes directly on the ShellFolder for multiple attributes
        }

        public enum SIGDN : uint
        {
            SIGDN_NORMALDISPLAY = 0x00000000,           // SHGDN_NORMAL
            SIGDN_PARENTRELATIVEPARSING = 0x80018001,   // SHGDN_INFOLDER | SHGDN_FORPARSING
            SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000,  // SHGDN_FORPARSING
            SIGDN_PARENTRELATIVEEDITING = 0x80031001,   // SHGDN_INFOLDER | SHGDN_FOREDITING
            SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000,  // SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
            SIGDN_FILESYSPATH = 0x80058000,             // SHGDN_FORPARSING
            SIGDN_URL = 0x80068000,                     // SHGDN_FORPARSING
            SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001,     // SHGDN_INFOLDER | SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
            SIGDN_PARENTRELATIVE = 0x80080001           // SHGDN_INFOLDER
        }

        [Flags]
        public enum FOS : uint
        {
            FOS_OVERWRITEPROMPT = 0x00000002,
            FOS_STRICTFILETYPES = 0x00000004,
            FOS_NOCHANGEDIR = 0x00000008,
            FOS_PICKFOLDERS = 0x00000020,
            FOS_FORCEFILESYSTEM = 0x00000040, // Ensure that items returned are filesystem items.
            FOS_ALLNONSTORAGEITEMS = 0x00000080, // Allow choosing items that have no storage.
            FOS_NOVALIDATE = 0x00000100,
            FOS_ALLOWMULTISELECT = 0x00000200,
            FOS_PATHMUSTEXIST = 0x00000800,
            FOS_FILEMUSTEXIST = 0x00001000,
            FOS_CREATEPROMPT = 0x00002000,
            FOS_SHAREAWARE = 0x00004000,
            FOS_NOREADONLYRETURN = 0x00008000,
            FOS_NOTESTFILECREATE = 0x00010000,
            FOS_HIDEMRUPLACES = 0x00020000,
            FOS_HIDEPINNEDPLACES = 0x00040000,
            FOS_NODEREFERENCELINKS = 0x00100000,
            FOS_DONTADDTORECENT = 0x02000000,
            FOS_FORCESHOWHIDDEN = 0x10000000,
            FOS_DEFAULTNOMINIMODE = 0x20000000
        }

        public enum CDCONTROLSTATE
        {
            CDCS_INACTIVE = 0x00000000,
            CDCS_ENABLED = 0x00000001,
            CDCS_VISIBLE = 0x00000002
        }

        #endregion

        #region KnownFolder Definitions

        public enum FFFP_MODE
        {
            FFFP_EXACTMATCH,
            FFFP_NEARESTPARENTMATCH
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        public struct KNOWNFOLDER_DEFINITION
        {
            public KF_CATEGORY category;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszCreator;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszDescription;
            public Guid fidParent;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszRelativePath;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszParsingName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszToolTip;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszLocalizedName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszIcon;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszSecurity;
            public uint dwAttributes;
            public KF_DEFINITION_FLAGS kfdFlags;
            public Guid ftidType;
        }

        public enum KF_CATEGORY
        {
            KF_CATEGORY_VIRTUAL = 0x00000001,
            KF_CATEGORY_FIXED = 0x00000002,
            KF_CATEGORY_COMMON = 0x00000003,
            KF_CATEGORY_PERUSER = 0x00000004
        }

        [Flags]
        public enum KF_DEFINITION_FLAGS
        {
            KFDF_PERSONALIZE = 0x00000001,
            KFDF_LOCAL_REDIRECT_ONLY = 0x00000002,
            KFDF_ROAMABLE = 0x00000004,
        }


        // Property System structs and consts
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct PROPERTYKEY
        {
            public Guid fmtid;
            public uint pid;
        }

        #endregion

        public const uint ERROR_CANCELLED = 0x800704C7;

        [Flags()]
        public enum FormatMessageFlags
        {
            FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100,
            FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,
            FORMAT_MESSAGE_FROM_STRING = 0x00000400,
            FORMAT_MESSAGE_FROM_HMODULE = 0x00000800,
            FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,
            FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SafeModuleHandle LoadLibrary(string name);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int LoadString(SafeModuleHandle hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint FormatMessage([MarshalAs(UnmanagedType.U4)] FormatMessageFlags dwFlags, IntPtr lpSource,
           uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer,
           uint nSize, string[] Arguments);


        public class SafeModuleHandle : System.Runtime.InteropServices.SafeHandle
        {
            public SafeModuleHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                return FreeLibrary(handle);
            }
        }

        public enum HRESULT : long
        {
            S_FALSE = 0x0001,
            S_OK = 0x0000,
            E_INVALIDARG = 0x80070057,
            E_OUTOFMEMORY = 0x8007000E
        }

    }
}
