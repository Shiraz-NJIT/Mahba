using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Njit.Program.Forms
{
    public partial class MainForm : Njit.Program.Forms.BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            InitilizeProgramSettings();
            if (!this.DesignMode)
            {
                if (Options.SettingInitializer != null)
                    Options.SettingInitializer.GetProgramSetting().ShowSplashScreen();
            }
        }

        protected virtual void LoadSettings()
        {

        }

        protected virtual void SaveSettings()
        {

        }

        protected virtual void InitilizeProgramSettings()
        {

        }

        private bool _ShutdownWhenExit = false;
        [DefaultValue(false)]
        public bool ShutdownWhenExit
        {
            get
            {
                return _ShutdownWhenExit;
            }
            set
            {
                _ShutdownWhenExit = value;
            }
        }

        private bool _SingleInstanceProgram = true;
        [DefaultValue(true)]
        public bool SingleInstanceProgram
        {
            get
            {
                return _SingleInstanceProgram;
            }
            set
            {
                _SingleInstanceProgram = value;
            }
        }

        public virtual void SetDateTime()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            SetDateTime();
        }

        protected override void WndProc(ref Message message)
        {
            if (Njit.Common.SingleInstance.WM_SHOWFIRSTINSTANCE != 0 && message.Msg == Njit.Common.SingleInstance.WM_SHOWFIRSTINSTANCE)
                ShowWindow();
            base.WndProc(ref message);
        }

        public void ShowWindow()
        {
            Njit.Common.Win32.ShowToFront(this.Handle);
        }

        Njit.Common.SingleInstance _SingleInstance;

        private bool CloseIfNotMainInstance()
        {
            //Process currentProcess = Process.GetCurrentProcess();
            //Process[] processList = Process.GetProcessesByName(currentProcess.ProcessName);
            //foreach (Process process in processList)
            //{
            //    if ((process.Id != currentProcess.Id) && (process.MainModule.FileName == currentProcess.MainModule.FileName))
            //    {
            //        Options.SettingInitializer.GetProgramSetting().ShowExitDialog = false;
            //        this.Close();
            //        return true;
            //    }
            //}
            //return false;

            //bool createdNew;
            //Mutex mutex = new Mutex(true, "MyAwesomeApp", out createdNew);
            //if (!createdNew)
            //{
            //    Options.SettingInitializer.GetProgramSetting().ShowExitDialog = false;
            //    this.Close();
            //    return true;
            //}
            //return false;
            if (Options.SettingInitializer == null)
                return false;
            _SingleInstance = new Common.SingleInstance(Options.SettingInitializer.GetProgramSetting().NetworkName);
            if (!_SingleInstance.Start())
            {
                _SingleInstance.ShowFirstInstance();
                Options.SettingInitializer.GetProgramSetting().ShowExitDialog = false;
                this.Close();
                return true;
            }
            return false;
        }

        public void ChangeSystemDate(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "timedate.cpl";
            if (Njit.Common.Win32.IsVistaOrLater)
                p.StartInfo.Verb = "runas";
            p.Start();
            p.WaitForExit();
            p.Dispose();
        }

        InputLanguage lastInputLanguage;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.SingleInstanceProgram)
                if (CloseIfNotMainInstance())
                    return;
            try
            {
                lastInputLanguage = Application.CurrentInputLanguage;
                InputLanguage persianLang = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo("fa-IR"));
                if (persianLang == null)
                    persianLang = InputLanguage.FromCulture(System.Globalization.CultureInfo.GetCultureInfo("fa"));
                if (persianLang != null)
                    Application.CurrentInputLanguage = persianLang;
            }
            catch
            { }
            if (this.DesignMode)
                return;
            if (Options.SettingInitializer == null)
                throw new Exception("تنظیمات برنامه پیاده سازی نشده است");
            Options.SettingInitializer.GetProgramSetting().CloseSplashScreen();
            if (Options.SettingInitializer != null)
            {
                if (!Options.SettingInitializer.GetUserSetting().Login())
                {
                    Options.SettingInitializer.GetProgramSetting().ShowExitDialog = false;
                    this.Close();
                    return;
                }
            }
            UpdateDatabases();
            DateTime serverDateTime = Options.SettingInitializer.GetDataAccess().Connection.GetServerDateTime();
            TimeSpan timeDifference = serverDateTime.Subtract(DateTime.Now);
            do
            {

                if (timeDifference.TotalMinutes >= Options.SettingInitializer.GetProgramSetting().MinuteDifferenceWithServerToShowMessage || timeDifference.TotalMinutes <= -Options.SettingInitializer.GetProgramSetting().MinuteDifferenceWithServerToShowMessage)
                {
                    MessageBox.VDialogResult dResult = PersianMessageBox.Show(this, string.Format("این سیستم {0} با سرور اختلاف ساعت دارد\r\nساعت سرور: {1}", timeDifference.GetText(), serverDateTime.ToLongTimeString()), "اختلاف ساعت", new MessageBox.VDialogButton[] { new MessageBox.VDialogButton(MessageBox.VDialogResult.OK, "تایید"), new MessageBox.VDialogButton("تغییر تاریخ / ساعت", ChangeSystemDate, true), new MessageBox.VDialogButton(MessageBox.VDialogResult.Cancel, "خروج از برنامه") }, MessageBox.VDialogIcon.Warning, MessageBox.VDialogDefaultButton.Button1, System.Windows.Forms.RightToLeft.Yes, false, null, null, null, null, null);
                    if (dResult == MessageBox.VDialogResult.Cancel)
                    {
                        Options.SettingInitializer.GetProgramSetting().ShowExitDialog = false;
                        this.Close();
                        return;
                    }
                }
                Njit.Sql.DataAccess da = new Sql.DataAccess(Options.SettingInitializer.GetSqlSetting().DatabaseConnection.ConnectionString);
                serverDateTime = da.Connection.GetServerDateTime();
                timeDifference = serverDateTime.Subtract(DateTime.Now);
                da.Dispose();
            }
            while (timeDifference.TotalHours >= Options.SettingInitializer.GetProgramSetting().AllowableHourDifferenceWithServer || timeDifference.TotalHours <= -Options.SettingInitializer.GetProgramSetting().AllowableHourDifferenceWithServer);
            if (this.RegisterSystemUtilityServer)
            {
                int registeredChannels = 0;
                Exception exception = null;
                try
                {
                    System.Runtime.Remoting.Channels.Tcp.TcpChannel _TcpChannel = new System.Runtime.Remoting.Channels.Tcp.TcpChannel(Options.SettingInitializer.GetProgramSetting().NetworkPort);
                    System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(_TcpChannel, false);
                    registeredChannels++;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                try
                {
                    System.Collections.IDictionary properties = new System.Collections.Hashtable();
                    properties["name"] = "tcp6";
                    properties["port"] = Options.SettingInitializer.GetProgramSetting().NetworkPort;
                    properties["bindTo"] = "[::]";
                    System.Runtime.Remoting.Channels.Tcp.TcpServerChannel _TcpChannelV6 = new System.Runtime.Remoting.Channels.Tcp.TcpServerChannel(properties, null);
                    System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(_TcpChannelV6, false);
                    registeredChannels++;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
                if (registeredChannels > 0)
                {
                    try
                    {
                        System.Runtime.Remoting.RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                        System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(Njit.Common.SystemUtility), Options.SettingInitializer.GetProgramSetting().NetworkName, System.Runtime.Remoting.WellKnownObjectMode.Singleton);
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در راه اندازی سرور" + "\r\n\r\n" + ex.Message);
                    }
                }
                else
                {
                    PersianMessageBox.Show(this, "خطا در راه اندازی سرور" + "\r\n\r\n" + exception.Message);
                }
            }
            try
            {
                Cursor = Cursors.WaitCursor;
                Njit.Common.SystemUtility systemUtility = Options.SystemUtility;
                systemUtility.SendMessage(System.Net.Dns.GetHostName(), "--HelloWorld");
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در اتصال به سرور" + "\r\n" + "اتصال به نرم افزار بر روی سرور با خطا مواجه شده است" + "\r\n" + "توجه داشته باشید که این نرم افزار باید بر روی سرور اجرا شده باشد و یک کاربر وارد سیستم شده باشد" + "\r\n\r\n" + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public virtual void UpdateDatabases()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "DatabaseUpdates");
            if (!System.IO.Directory.Exists(path))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    return;
                }
            }
            using (Njit.Program.Forms.DatabseUpdatesInstaller form = new DatabseUpdatesInstaller(Options.MasterDataAccess.Connection.ConnectionString, path))
            {
                form.ShowDialog(this);
            }
        }

        private bool _RegisterSystemUtilityServer = true;
        [DefaultValue(true)]
        public bool RegisterSystemUtilityServer
        {
            get
            {
                return _RegisterSystemUtilityServer;
            }
            set
            {
                _RegisterSystemUtilityServer = value;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Options.SettingInitializer.GetProgramSetting().ShowExitDialog)
            {
                MessageBox.VDialogResult result = PersianMessageBox.Show(this, "مایل به خروج از برنامه هستید؟", "تایید خروج", new Njit.MessageBox.VDialogButton[] { new Njit.MessageBox.VDialogButton(MessageBox.VDialogResult.Yes), new Njit.MessageBox.VDialogButton(MessageBox.VDialogResult.No) }, MessageBox.VDialogIcon.Question, MessageBox.VDialogDefaultButton.Button1, System.Windows.Forms.RightToLeft.Yes, false, null, null, "ApplicationExit", "پیام خروج از برنامه", new MessageBox.VDialogButton[] { new MessageBox.VDialogButton(MessageBox.VDialogResult.No) });
                if (result != MessageBox.VDialogResult.Yes)
                {
                    this.ShutdownWhenExit = false;
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            try
            {
                SaveSettings();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ذخیره تنظیمات" + "\r\n" + ex.Message);
            }
            if (Options.SettingInitializer.GetProgramSetting().ShowExitDialog)
                Options.SettingInitializer.GetProgramSetting().BackupDatabase();
            if (this.ShutdownWhenExit)
                System.Diagnostics.Process.Start("Shutdown.exe", "-s -t 0");
            try
            {
                Application.CurrentInputLanguage = lastInputLanguage;
            }
            catch
            { }
            if (_SingleInstance != null && _SingleInstance.IsMainInstance)
                _SingleInstance.Stop();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            SetDateTime();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.P && e.Alt && e.Control && e.Shift)
            {
                Njit.Program.Forms.SaveAccessPermissionTree f = new Njit.Program.Forms.SaveAccessPermissionTree(Options.SettingInitializer.GetProgramSetting().GetExecutingAssembly(), Options.SettingInitializer.GetSqlSetting().DatabaseConnection.ConnectionString);
                f.ShowDialog();
            }
        }
    }
}
