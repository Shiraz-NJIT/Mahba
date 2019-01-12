using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.ElegantProgram
{
    public static class ScannerSettingManager
    {
        private static ObservableCollection<ScannerSetting> _Settings;
        public static ObservableCollection<ScannerSetting> Settings
        {
            get
            {
                if (_Settings == null)
                    Load();
                return _Settings;
            }
            set
            {
                _Settings = value;
                SaveAndReload();
            }
        }

        static string settingFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "ScannerSetting.data");

        public static void SaveAndReload()
        {
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(_Settings);
            System.IO.File.WriteAllText(settingFile, data);
            Load();
        }

        public static void Load()
        {
            if (File.Exists(settingFile))
            {
                string data = File.ReadAllText(settingFile);
                _Settings = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<ScannerSetting>>(data);
            }
            else
            {
                _Settings = new ObservableCollection<ScannerSetting>();
            }
        }
    }
}
