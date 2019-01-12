using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Setting
{
    class Archive
    {
        private static Archive _ThisProgram;
        public static Archive ThisProgram
        {
            get
            {
                if (_ThisProgram == null)
                    _ThisProgram = new Archive();
                return _ThisProgram;
            }
        }

        public event EventHandler SelectedArchiveChanged;
        private void OnSelectedArchiveChanged()
        {
            if (SelectedArchiveChanged != null)
                SelectedArchiveChanged(this, EventArgs.Empty);
        }

        private Model.Common.ArchiveTree _SelectedArchiveTree;
        public Model.Common.ArchiveTree SelectedArchiveTree
        {
            get
            {
                return _SelectedArchiveTree;
            }
            set
            {
                _SelectedArchiveTree = value;
                LoadedArchiveSettings = null;
                if (_SelectedArchiveTree != null)
                    Setting.User.ThisProgram.AddLog(User.UserOparatesPlaceNames.None, User.UserOparatesNames.تنظیمات, null, "ورود به بایگانی '" + _SelectedArchiveTree.Archive.Title + "'");
                OnSelectedArchiveChanged();
                Controller.Archive.DossierCacheController.ClearCachedData();
                Setting.Program.ThisProgram.ShowExitDialog = (value != null);
                if (value == null)
                {
                    View.Main.Instance.DisableTabPages();
                }
                else
                {
                    View.Main.Instance.EnableTabPages();
                }
                View.Main.Instance.SetToolstripValues();
            }
        }

        public bool LoadedArchiveSettingsISNull()
        {
            return _LoadedArchiveSettings == null;
        }

        private NjitSoftware.Model.Archive.ArchiveSetting _LoadedArchiveSettings;
        public NjitSoftware.Model.Archive.ArchiveSetting LoadedArchiveSettings
        {
            get
            {
                if (_LoadedArchiveSettings == null)
                    if (!this.LoadArchiveSettings())
                        return null;
                if (_LoadedArchiveSettings.BackupPath == null && this.SelectedArchiveTree != null)
                    _LoadedArchiveSettings.BackupPath = Setting.Program.ThisProgram.SearchBestPathForBackup("نرم افزار مهبا - " + ((this.SelectedArchiveTree == null) ? ("بایگانی پیشفرض") : (this.SelectedArchiveTree.Archive.Title)), 1000 * 1000 * 1000);
                if (_LoadedArchiveSettings.DocumentsPathOrDatabaseName == null && this.SelectedArchiveTree != null)
                    _LoadedArchiveSettings.DocumentsPathOrDatabaseName = Setting.Program.ThisProgram.SearchBestPathForBackup("نرم افزار مهبا - اسناد - " + ((this.SelectedArchiveTree == null) ? ("پیشفرض") : (this.SelectedArchiveTree.Archive.Title)), 1000 * 1000 * 1000);
                return _LoadedArchiveSettings;
            }
            set
            {
                _LoadedArchiveSettings = value;
            }
        }

        public bool LoadArchiveSettings()
        {
            if (Setting.Sql.ThisProgram.ArchiveConnection != null)
            {
                NjitSoftware.Model.Archive.ArchiveDataClassesDataContext dc = new NjitSoftware.Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                if (dc.ArchiveSettings.Count() > 0)
                    _LoadedArchiveSettings = dc.ArchiveSettings.First();
                else
                    _LoadedArchiveSettings = GetDefualtArchiveSetting();
                return true;
            }
            return false;
        }

        private NjitSoftware.Model.Archive.ArchiveSetting GetDefualtArchiveSetting()
        {
            return NjitSoftware.Model.Archive.ArchiveSetting.GetNewInstance(null, null, false, "نام سازمان", null, null, "شماره پرسنلی", 0, 1000, true, false, null, "", null, null, 0);
        }

        private Model.Common.ProgramSetting _LoadedCommonSettings;
        public Model.Common.ProgramSetting LoadedCommonSettings
        {
            get
            {
                if (_LoadedCommonSettings == null)
                    this.LoadCommonSettings();
                return _LoadedCommonSettings;
            }
            set
            {
                _LoadedCommonSettings = value;
            }
        }

        private void LoadCommonSettings()
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                if (dc.ProgramSettings.Count() > 0)
                    _LoadedCommonSettings = dc.ProgramSettings.First();
                else
                    _LoadedCommonSettings = GetDefualtCommonSettings();
            }
            catch
            {
                _LoadedCommonSettings = GetDefualtCommonSettings();
            }
        }

        private Model.Common.ProgramSetting GetDefualtCommonSettings()
        {
            return Model.Common.ProgramSetting.GetNewInstance(true, null, null);
        }

        public void SaveAndReloadCommonSettings()
        {
            SaveAndReloadCommonSettings(this.LoadedCommonSettings);
        }

        public void SaveAndReloadArchiveSettings()
        {
            SaveAndReloadArchiveSettings(this.LoadedArchiveSettings);
        }

        public void SaveAndReloadArchiveSettings(NjitSoftware.Model.Archive.ArchiveSetting instance)
        {
            try
            {
                NjitSoftware.Model.Archive.ArchiveDataClassesDataContext archiveDc = new NjitSoftware.Model.Archive.ArchiveDataClassesDataContext(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                var archiveSettingsQuery = archiveDc.ArchiveSettings.Select(t => t);
                if (archiveSettingsQuery.Count() > 0)
                {
                    NjitSoftware.Model.Archive.ArchiveSetting original = archiveSettingsQuery.First();
                    NjitSoftware.Model.Archive.ArchiveSetting.Copy(original, instance);
                }
                else
                {
                    NjitSoftware.Model.Archive.ArchiveSetting.Insert(archiveDc, instance);
                }
                archiveDc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ذخیره تنظیمات" + "\r\n\r\n" + ex.Message);
            }
            LoadArchiveSettings();
        }

        public void SaveAndReloadCommonSettings(Model.Common.ProgramSetting instance)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var query = dc.ProgramSettings.Select(t => t);
                if (query.Count() > 0)
                {
                    Model.Common.ProgramSetting original = query.First();
                    Model.Common.ProgramSetting.Copy(original, instance);
                }
                else
                {
                    Model.Common.ProgramSetting.Insert(dc, instance);
                }
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ذخیره تنظیمات" + "\r\n\r\n" + ex.Message);
            }
            LoadCommonSettings();
        }
    }
}
