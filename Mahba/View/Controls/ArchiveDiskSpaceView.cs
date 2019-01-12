using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.Controls
{
    public partial class ArchiveDiskSpaceView : UserControl
    {
        public ArchiveDiskSpaceView(string ArchiveName, char Drive)
        {
            InitializeComponent();
            this.ArchiveName = ArchiveName;
            this.Drive = Drive;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshValues();
        }

        private string _ArchiveName = "";
        [DefaultValue("")]
        public string ArchiveName
        {
            get
            {
                return _ArchiveName;
            }
            set
            {
                _ArchiveName = value;
            }
        }

        private char _Drive = ' ';
        [DefaultValue(' ')]
        public char Drive
        {
            get
            {
                return _Drive;
            }
            set
            {
                _Drive = value;
            }
        }

        private System.IO.DriveInfo GetDriveInfo()
        {
            return Njit.Program.Options.SystemUtility.GetDriveInfo(_Drive.ToString());
        }

        private void RefreshValues()
        {
            System.IO.DriveInfo drive = GetDriveInfo();
            lblArchiveName.Text = this.ArchiveName + " - " + drive.VolumeLabel + " (" + _Drive + ":)";
            lblSize.Text = GetDiskSizeText(drive);
            diskSpaceProgress.Value = GetDiskSpaceUsedPercent(drive);
        }

        private int GetDiskSpaceUsedPercent(System.IO.DriveInfo drive)
        {
            if (_Drive == ' ')
                return 0;
            try
            {
                if (drive.IsReady == false)
                    return 0;
                return (int)(100 * (drive.TotalSize - drive.TotalFreeSpace) / drive.TotalSize);
            }
            catch
            {
                return 0;
            }
        }

        private string GetDiskSizeText(System.IO.DriveInfo drive)
        {
            return Njit.Common.PublicMethods.GetShortBytesText(drive.TotalFreeSpace) + " خالی از " + Njit.Common.PublicMethods.GetShortBytesText(drive.TotalSize);
        }
    }
}
