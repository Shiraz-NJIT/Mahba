using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Njit.Program.Setting
{
    /// <summary>
    /// تنظیمات 
    /// SqlServer
    /// </summary>
    [Serializable]
    public abstract class SqlSetting
    {
        /// <summary>
        /// اطلاعات کانکشن پایگاه داده
        /// </summary>
        public abstract SqlConnectionStringBuilder DatabaseConnection
        {
            get;
            set;
        }

        private string _LockServer;
        /// <summary>
        /// نام سرور قفل نرم افزار
        /// </summary>
        public virtual string LockServer
        {
            get
            {
                if (_LockServer == null)
                    _LockServer = "";
                return _LockServer;
            }
            set
            {
                _LockServer = value;
            }
        }

        private string _SettingFile;
        /// <summary>
        /// فایلی که تنظیمات روی آن ذخیره می شود
        /// </summary>
        public virtual string SettingFile
        {
            get
            {
                if (_SettingFile == null)
                    _SettingFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "SqlSetting.data");
                return _SettingFile;
            }
            set
            {
                _SettingFile = value;
            }
        }

        /// <summary>
        /// بارگذاری تنظیمات
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// ذخیره تنظیمات
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// ست کردن تنظیمات
        /// </summary>
        public abstract void SetSettings();

    }
}
