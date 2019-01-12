using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class ProgramSettings : Njit.Program.Forms.ProgramSettings
    {
        public ProgramSettings()
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            base.LoadSettings();
            txtOrganName.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.OrganName;
            txtBackupPath.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.BackupPath;
            pictureSelectBoxBackground.SetImageData(Setting.Archive.ThisProgram.LoadedArchiveSettings.Background == null ? null : Setting.Archive.ThisProgram.LoadedArchiveSettings.Background.ToArray());
            pictureSelectBoxLogo.SetImageData(Setting.Archive.ThisProgram.LoadedArchiveSettings.Logo == null ? null : Setting.Archive.ThisProgram.LoadedArchiveSettings.Logo.ToArray());
            groupBoxDocumentsPath.Visible = !Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase;
            groupBoxDocumentsDatabases.Visible = Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase;
            txtPersonnelNumber_Label.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label;
            txtPersonnelNumber_MaxLength.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_MaxLength.ToString();
            txtPersonnelNumber_MinLength.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_MinLength.ToString();
            checkBoxShowContactTab.Checked = Setting.Archive.ThisProgram.LoadedArchiveSettings.InfoGroupTab;
            imageFormatBindingSource.DataSource = Controller.Archive.ImageFormatController.GetImageFormats();
            compressionTypeBindingSource.DataSource = Controller.Archive.CompressionTypeController.GetCompressionTypes();
            cmbCompressionType.SelectedValue = Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultCompressionTypeCode ?? 0;
            cmbDocumentsFormat.SelectedValue = Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultImageFormatCode ?? 0;
            if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase)
            {

            }
            else
            {
                txtDocumentsPath.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName;
            }
            chkShowBackupFormOnExit.Checked = Setting.Archive.ThisProgram.LoadedCommonSettings.ShowBackupFormOnExit;
            txtMaxDocSize.Text = Setting.Archive.ThisProgram.LoadedArchiveSettings.MaxDocumentsSize.ToString();
        }

        public override bool SaveSettings()
        {
            if (!base.SaveSettings())
                return false;
            try
            {
                string documentsPathOrDatabaseName = Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase ? Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName : txtDocumentsPath.Text;
                Setting.Archive.ThisProgram.LoadedArchiveSettings = Model.Archive.ArchiveSetting.GetNewInstance(pictureSelectBoxBackground.DataStream == null || (pictureSelectBoxBackground.DataStream != null && pictureSelectBoxBackground.DataStream.Length == 0) ? null : new System.Data.Linq.Binary(pictureSelectBoxBackground.DataStream.ToArray()), txtBackupPath.Text, Setting.Archive.ThisProgram.LoadedArchiveSettings.AutoBackup, txtOrganName.Text, pictureSelectBoxLogo.DataStream == null || (pictureSelectBoxLogo.DataStream != null && pictureSelectBoxLogo.DataStream.Length == 0) ? null : new System.Data.Linq.Binary(pictureSelectBoxLogo.DataStream.ToArray()), documentsPathOrDatabaseName, txtPersonnelNumber_Label.Text, txtPersonnelNumber_MinLength.IntValue.Value, txtPersonnelNumber_MaxLength.IntValue.Value, checkBoxShowContactTab.Checked, Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase, Setting.Archive.ThisProgram.LoadedArchiveSettings.DatabasePath, Setting.Archive.ThisProgram.LoadedArchiveSettings.DefaultFilesSavePath, (int)cmbDocumentsFormat.SelectedValue, (int)cmbCompressionType.SelectedValue, txtMaxDocSize.IntValue.Value);
                Setting.Archive.ThisProgram.SaveAndReloadArchiveSettings();
                Setting.Archive.ThisProgram.LoadedCommonSettings = Model.Common.ProgramSetting.GetNewInstance(chkShowBackupFormOnExit.Checked, null, null);
                Setting.Archive.ThisProgram.SaveAndReloadCommonSettings();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ذخیره تنظیمات" + Environment.NewLine + Environment.NewLine + ex.Message);
                return false;
            }
            ProgramEvents.OnProgramSettingsChanged();
            return true;
        }

        public override void ValidateContents()
        {
            base.ValidateContents();
            if (txtOrganName.Text == "")
                throw new Njit.Common.ValidateException(txtOrganName, "نام شرکت / سازمان را وارد کنید") { Tag = tabPageProgramSettings };
            if (txtBackupPath.Text.Trim() == "")
                throw new Njit.Common.ValidateException(txtBackupPath, "مسیر ذخیره فایل های پشتیبان را وارد کنید") { Tag = tabPageSavePath };
            if (txtDocumentsPath.Visible && txtDocumentsPath.Text.Trim() == "")
                throw new Njit.Common.ValidateException(txtDocumentsPath, "مسیر ذخیره اسناد را وارد کنید") { Tag = tabPageSavePath };
            if (txtPersonnelNumber_Label.Text.Trim() == "")
                throw new Njit.Common.ValidateException(txtPersonnelNumber_Label, "عنوان فیلد اصلی را وارد کنید") { Tag = tabPageArchive };
            if (txtPersonnelNumber_MinLength.IntValue.HasValue == false)
                throw new Njit.Common.ValidateException(txtPersonnelNumber_MinLength, "حداقل طول فیلد اصلی به صورت صحیح وارد نشده است") { Tag = tabPageArchive };
            if (txtPersonnelNumber_MaxLength.IntValue.HasValue == false)
                throw new Njit.Common.ValidateException(txtPersonnelNumber_MaxLength, "حداکثر طول فیلد اصلی به صورت صحیح وارد نشده است") { Tag = tabPageArchive };
            if (txtPersonnelNumber_MinLength.IntValue.Value > txtPersonnelNumber_MaxLength.IntValue.Value)
                throw new Njit.Common.ValidateException(txtPersonnelNumber_MaxLength, "حداکثر طول فیلد اصلی نباید از حداقل طول کمتر باشد") { Tag = tabPageArchive };
            string serverName;
            try
            {
                serverName = Njit.Program.Options.SystemUtility.GetComputerName();
            }
            catch
            {
                throw new Njit.Common.ValidateException(this, "خطا در اتصال به سرور");
            }
            if (serverName == System.Net.Dns.GetHostName())
            {
                if (!System.IO.Directory.Exists(txtBackupPath.Text))
                    throw new Njit.Common.ValidateException(txtBackupPath, "مسیر ذخیره فایل های پشتیبان نامعتبر است") { Tag = tabPageSavePath };
            }
            if (txtMaxDocSize.IntValue.HasValue == false)
                throw new Njit.Common.ValidateException(txtMaxDocSize, "حداکثر اندازه حجم اسناد به صورت صحیح وارد نشده است") { Tag = tabPageSavePath };
            if (txtMaxDocSize.IntValue.Value < 0)
                throw new Njit.Common.ValidateException(txtMaxDocSize, "حداکثر اندازه حجم اسناد به صورت صحیح وارد نشده است") { Tag = tabPageSavePath };
        }
    }
}
