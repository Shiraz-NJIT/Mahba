using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.Setting
{
    class Program : Njit.Program.Setting.ProgramSetting
    {
        private static Program _ThisProgram;
        public static Program ThisProgram
        {
            get
            {
                if (_ThisProgram == null)
                    _ThisProgram = new Program();
                return _ThisProgram;
            }
        }

        public override string BackupExtension
        {
            get
            {
                return ".MahbaBak";
            }
        }

        public override void CloseSplashScreen()
        {
            if (!View.SplashScreen.InstanceIsNull)
                View.SplashScreen.Instance.AllowClose = true;
        }

        public override void ShowSplashScreen()
        {
            View.SplashScreen.Instance.Show();
        }

        public override void BackupDatabase()
        {
            BackupDatabase(Setting.Archive.ThisProgram.LoadedArchiveSettings.AutoBackup, true);
        }

        public override void BackupDatabase(bool AutoBackup, bool ShowAutoBackupCheckBox)
        {
            using (View.Backup f = new View.Backup(Setting.Sql.ThisProgram.ArchiveConnection.InitialCatalog, Setting.Archive.ThisProgram.LoadedArchiveSettings.BackupPath, null, null, Setting.Program.ThisProgram.BackupExtension, AutoBackup, ShowAutoBackupCheckBox))
            {
                f.ShowDialog();
            }
        }

        public override void RestoreDatabase()
        {
            using (View.RestoreBackup f = new View.RestoreBackup(Setting.Archive.ThisProgram.LoadedArchiveSettings.BackupPath, Setting.Program.ThisProgram.BackupExtension, Setting.Sql.ThisProgram.ArchiveConnection.InitialCatalog, null))
            {
                f.ShowDialog();
            }
        }
        public static string GetMacAddress()
        {
            string hostName = System.Net.Dns.GetHostName(); // Retrive the Name of HOST  
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP; 
        }
        public override void LoadFormState(System.Windows.Forms.Form form)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == form.Name);
            if (query.Count() == 1)
            {
                Model.Common.FormState state = query.Single();
                switch ((System.Windows.Forms.FormWindowState)state.WindowState)
                {
                    case System.Windows.Forms.FormWindowState.Maximized:
                        form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        break;
                    case System.Windows.Forms.FormWindowState.Minimized:
                        break;
                    case System.Windows.Forms.FormWindowState.Normal:
                        form.WindowState = System.Windows.Forms.FormWindowState.Normal;
                        //form.Tag = form.MinimumSize;
                        //form.MinimumSize = new System.Drawing.Size(state.Width, state.Height);
                        form.Width = state.Width;
                        form.Height = state.Height;
                        //form.Shown += Form_Shown;
                        if (state.X == 0 && state.Y == 0)
                            form.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - form.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2 - form.Height / 2);
                        else
                        {
                            form.Left = state.X;
                            form.Top = state.Y;
                        }
                        break;
                }
            }
            else
            {
                form.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2 - form.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2 - form.Height / 2);
            }
        }

        //private void Form_Shown(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.Form form = sender as System.Windows.Forms.Form;
        //    System.Drawing.Size? size = (form.Tag as System.Drawing.Size?);
        //    form.MinimumSize = size == null ? System.Drawing.Size.Empty : size.Value;
        //    form.Shown -= Form_Shown;
        //}

        public override void SaveFormState(System.Windows.Forms.Form form)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            Model.Common.FormState state = Model.Common.FormState.GetNewInstance(Environment.MachineName, form.Name, (int)form.WindowState, form.Width, form.Height, form.Location.X, form.Location.Y);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == form.Name);
            if (query.Count() == 1)
            {
                Model.Common.FormState originalState = query.Single();
                Model.Common.FormState.Copy(originalState, state);
                dc.SubmitChanges();
            }
            else
            {
                Model.Common.FormState.Insert(dc, state);
                dc.SubmitChanges();
            }
        }

        string _NetworkName;
        public override string NetworkName
        {
            get
            {
                if (_NetworkName == null)
                    _NetworkName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.Replace(" ", "").Replace(".", "");
                return _NetworkName;
            }
        }

        //int _NetworkPort;
        public override int NetworkPort
        {
            get
            {
                //if (_NetworkPort == 0)
                //    _NetworkPort = GetNetworkNameCode(NetworkName);
                return 1002;
            }
        }

        //private int GetNetworkNameCode(string networkName)
        //{
        //    int temp = 0;
        //    foreach (char ch in networkName)
        //    {
        //        temp += (int)ch;
        //    }
        //    return temp;
        //}

        System.IO.MemoryStream backgroundImageStream;

        System.Drawing.Image _BackgroundImage;
        public System.Drawing.Image BackgroundImage
        {
            get
            {
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings == null)
                    return Properties.Resources.Background;
                if (Setting.Archive.ThisProgram.LoadedArchiveSettings.Background == null)
                    return Properties.Resources.Background;
                if (backgroundImageStream == null || (backgroundImageStream != null && backgroundImageStream.Length != Setting.Archive.ThisProgram.LoadedArchiveSettings.Background.Length))
                {
                    if (backgroundImageStream != null)
                    {
                        this._BackgroundImage.Dispose();
                        this.backgroundImageStream.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    this.backgroundImageStream = new System.IO.MemoryStream();
                    this.backgroundImageStream.Write(Setting.Archive.ThisProgram.LoadedArchiveSettings.Background.ToArray(), 0, Setting.Archive.ThisProgram.LoadedArchiveSettings.Background.Length);
                    this._BackgroundImage = System.Drawing.Image.FromStream(this.backgroundImageStream);
                }
                return this._BackgroundImage;
            }
        }

        public override int MinuteDifferenceWithServerToShowMessage
        {
            get
            {
                return 10;
            }
        }

        public override int AllowableHourDifferenceWithServer
        {
            get
            {
                return 6;
            }
        }

        public override System.Reflection.Assembly GetExecutingAssembly()
        {
            return System.Reflection.Assembly.GetExecutingAssembly();
        }

        internal string GetReportPath(string file)
        {
            return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Reports - Backup", file);
        }

        public override bool ShowBackupFormOnExit
        {
            get
            {
                return Setting.Archive.ThisProgram.LoadedCommonSettings.ShowBackupFormOnExit;
            }
        }

        Njit.Common.CryptoService.DESCryptoService des;
        internal Njit.Common.CryptoService.DESCryptoService GetExpiryDateCryptoService()
        {
            if (des == null)
            {
                des = new Njit.Common.CryptoService.DESCryptoService();
                des.SetKey("d2f56esf5d", "f2w6f6dsad");
            }
            return des;
        }

        internal DateTime GetLastRunDate()
        {
            Njit.Common.CryptoService.DESCryptoService des = GetExpiryDateCryptoService();
            string date = null;
            if (!string.IsNullOrEmpty(Setting.Archive.ThisProgram.LoadedCommonSettings.LastRunDate))
            {
                try
                {
                    date = des.DecryptFromBase64(Setting.Archive.ThisProgram.LoadedCommonSettings.LastRunDate);
                }
                catch
                {
                    return DateTime.Parse("2100/01/01");
                }
                return DateTime.Parse(date);
            }
            else
                return DateTime.Parse("2100/01/01");
        }

        internal void SetLastRunDate()
        {
            if (Setting.Program.ThisProgram.ShowExitDialog)
            {
                Njit.Common.CryptoService.DESCryptoService des = GetExpiryDateCryptoService();
                string date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                Setting.Archive.ThisProgram.LoadedCommonSettings.LastRunDate = des.EncryptToBase64(date);
                Setting.Archive.ThisProgram.SaveAndReloadCommonSettings(Model.Common.ProgramSetting.GetNewInstance(Setting.Archive.ThisProgram.LoadedCommonSettings.ShowBackupFormOnExit, Setting.Archive.ThisProgram.LoadedCommonSettings.ExpiryDate, des.EncryptToBase64(date)));
            }
        }

        internal static int MaxArchiveCount()
        {
            return 4;
            //string fileName = "Tiny.ocx";
            //if (!System.IO.File.Exists(fileName))
            //    fileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Tiny.ocx");
            //if (!System.IO.File.Exists(fileName))
            //    throw new Njit.Common.CheckLockException(-1000);
            //Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
            ////if (md5.GetFileMD5(fileName) != "TJKM9pyOg+//raCCvG2UNw==")
            ////    throw new Njit.Common.CheckLockException(-1001);
            //TINYLib.TinyPlusCtrl tiny = new TINYLib.TinyPlusCtrl();
            //short errorCode = 0;
            //if (Njit.Common.PublicMethods.ServerIsLocal(Setting.Sql.ThisProgram.LockServer))
            //{
            //    errorCode = tiny.FindFirstTPlus("6D2F77838D67E3BCC7C3261C737B9FF", "0F53C9F493D977FBA6453434FE9DB895D75F7A0FC33BF180AFEE569CBB4AAFD75D780B92CA40537EF068AEB15CBBE3697827", "AF4F19087B09B94B648D9E3EC0EB223C8C1A13308DCD8F68597F1F5D4C43737BC93417783EBEE91E9569EBD841258B17CCB1");
            //}
            //else
            //{
            //    errorCode = tiny.FindNetTPlus(Setting.Sql.ThisProgram.LockServer, "6D2F77838D67E3BCC7C3261C737B9FF");
            //}
            //if (errorCode != 0)
            //    throw new Njit.Common.CheckLockException(errorCode);
            //string[] request = new string[20] { "E81E98ABBAA0A842610C", "1666C4E3F2EE469CAF4A", "5F370D283B9547B75265", "1747C5D4F3054B33DEE1", "EF479DAC4BCB41F98A9D", "CD43FB8AA998E8627510", "9B13BD58075AD20837D2", "59A91718C7BAE2687B26", "B2CE60730296C6445772", "F767A5B453CF33E18CAB", "4C446E0D1CEA46984756", "E74F95B05FE53595A443", "2252D0FF9A3961E9F8A7", "1B4FCBDAF92C50DAF988", "D43E84A34E9D57BF5A79", "BFE76D7C0F8C50BA596A", "DD578BB655423A70032E", "3048D2F19C786C36D5E4", "7AE2283BE648F8060934", "204CC2E1F0F377A14C5F" };
            //string[] response = new string[20] { "72E8724B644747352003", "954DF7E2D97F2F5D5843", "AE1E103B3230065E0940", "C2FA849BBEB5FBFB98B9", "5ECE80B7E2D95BDB3247", "199717F0D54F871514F7", "7202A0CB2624B4E2DFCC", "FC74BED39E4484021BD8", "5C883A33EC15ED776E59", "A21A647B1E99C57F7455", "6B6B59C4BB7420722F48", "920254772A94EC546B0E", "EC048AA7548B3BCBE40D", "67A32740258460DEC740", "D77537227D70BE9EC9F4", "8E6EF0E71E2460FE675E", "29ABE7DCC10CDC2AE300", "B727A590731125E78EC5", "0484C2DB980199D7DAF5", "C72BB5A0977D093F3449" };
            //Random r = new Random((int)DateTime.Now.Ticks);
            //int i = r.Next(20);
            //if (tiny.GetTPlusQuery(request[i]) != response[i])
            //    throw new Njit.Common.CheckLockException(-1);
            //string spid = tiny.GetTPlusData(TINYLib.EnumTPlusData.TPLUS_SPECIALID);
            //if (spid != "SAM@MOJ!15153030")
            //    throw new Njit.Common.CheckLockException(-1003);
            //return tiny.GetTPlusData(TINYLib.EnumTPlusData.TPLUS_COUNTER);
        }
    }
}
