using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    internal partial class SplashScreen : Njit.Program.Forms.PopupForm
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.ShowingAnimation = PopupAnimations.Blend;
            this.HidingAnimation = PopupAnimations.Blend;
            this.ShowingDuration = 900;
            this.HidingDuration = 300;
            //this.DropShadow = false;
            this.Angle = 0;
        }

        public static bool InstanceIsNull
        {
            get
            {
                if (_Instance == null)
                    return true;
                if (_Instance.IsDisposed)
                    return true;
                return false;
            }
        }

        private bool _AllowClose = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool AllowClose
        {
            get
            {
                return _AllowClose;
            }
            set
            {
                _AllowClose = value;
            }
        }

        private static SplashScreen _Instance;
        public static SplashScreen Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SplashScreen();
                if (_Instance.IsDisposed)
                    _Instance = new SplashScreen();
                return _Instance;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.AllowClose)
            {
                timer.Stop();
                this.Close();
            }
        }

    }
}
