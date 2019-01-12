using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Njit.Program.Setting
{
    /// <summary>
    /// تنظیمات اصلی برنامه
    /// </summary>
    public abstract class ProgramSetting
    {
        private bool _ShowExitDialog = true;
        [DefaultValue(true)]
        public virtual bool ShowExitDialog
        {
            get
            {
                return _ShowExitDialog;
            }
            set
            {
                _ShowExitDialog = value;
            }
        }

        /// <summary>
        /// جستجو برای یافتن بهترین مسیر برای فایل های پشتیبان
        /// </summary>
        /// <param name="programTitle"></param>
        /// <param name="availableFreeSpace"></param>
        /// <returns></returns>
        public virtual string SearchBestPathForBackup(string programTitle, long availableFreeSpace)
        {
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            for (int i = drives.Length - 1; i >= 0; i--)
            {
                if (drives[i].DriveType == System.IO.DriveType.Fixed)
                {
                    if (drives[i].IsReady)
                    {
                        if (drives[i].AvailableFreeSpace >= availableFreeSpace)
                        {
                            return System.IO.Path.Combine(drives[i].RootDirectory.FullName, programTitle);
                        }
                    }
                }
            }
            return System.IO.Path.Combine(@"C:\", programTitle);
        }

        /// <summary>
        /// پسوند فایل های پشتیبان
        /// با نقطه
        /// </summary>
        public abstract string BackupExtension { get; }

        private Njit.Common.INIFile _ProgramSettingINIFile;
        /// <summary>
        /// شیء ذخیره کننده تنظیمات برنامه
        /// </summary>
        public virtual Njit.Common.INIFile ProgramSettingINIFile
        {
            get
            {
                if (_ProgramSettingINIFile == null)
                {
                    string filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "ProgramSetting.ini");
                    if (!System.IO.File.Exists(filename))
                        System.IO.File.CreateText(filename).Dispose();
                    _ProgramSettingINIFile = new Njit.Common.INIFile(filename);
                }
                return _ProgramSettingINIFile;
            }
            set
            {
                _ProgramSettingINIFile = value;
            }
        }

        public abstract void ShowSplashScreen();
        public abstract void CloseSplashScreen();
        public abstract void BackupDatabase();
        public abstract void BackupDatabase(bool AutoBackup, bool ShowAutoBackupCheckBox);
        public abstract void RestoreDatabase();
        public abstract void SaveFormState(System.Windows.Forms.Form form);
        public abstract void LoadFormState(System.Windows.Forms.Form form);
        public abstract string NetworkName { get; }
        public abstract int NetworkPort { get; }
        public abstract int MinuteDifferenceWithServerToShowMessage { get; }
        public abstract int AllowableHourDifferenceWithServer { get; }
        public abstract System.Reflection.Assembly GetExecutingAssembly();
        public abstract bool ShowBackupFormOnExit { get; }
    }
}
