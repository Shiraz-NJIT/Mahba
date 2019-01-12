using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Program.ComponentOne
{
    public class ScannerSetting
    {
        public ScannerSetting()
        {
            this.Scanner = null;
            this.Contrast = 0;
            this.Brightness = 0;
        }

        public ScannerSetting(string scanner, int brightness, int contrast)
        {
            this.Scanner = scanner;
            this.Contrast = contrast;
            this.Brightness = brightness;
        }

        private string _Scanner;
        public string Scanner
        {
            get
            {
                return _Scanner;
            }
            set
            {
                _Scanner = value;
            }
        }

        private int _Brightness;
        public int Brightness
        {
            get
            {
                return _Brightness;
            }
            set
            {
                _Brightness = value;
            }
        }

        private int _Contrast;
        public int Contrast
        {
            get
            {
                return _Contrast;
            }
            set
            {
                _Contrast = value;
            }
        }
    }
}
