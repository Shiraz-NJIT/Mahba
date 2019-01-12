using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.Controls
{
    public partial class BrowseButton : ButtonExtended
    {
        public BrowseButton()
        {
            InitializeComponent();
        }

        private BrowseTypes _BrowseType = BrowseTypes.SelectFolder;
        [DefaultValue(typeof(BrowseTypes), "SelectFolder")]
        public BrowseTypes BrowseType
        {
            get
            {
                return _BrowseType;
            }
            set
            {
                _BrowseType = value;
            }
        }

        private Forms.FolderBrowser _ServerFolderBrowser = null;
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Forms.FolderBrowser ServerFolderBrowser
        {
            get
            {
                if (_ServerFolderBrowser == null)
                    _ServerFolderBrowser = new Forms.FolderBrowser();
                return _ServerFolderBrowser;
            }
            set
            {
                _ServerFolderBrowser = value;
            }
        }

        private bool _UseServerFolderBrowser = true;
        [DefaultValue(true)]
        public bool UseServerFolderBrowser
        {
            get
            {
                return _UseServerFolderBrowser;
            }
            set
            {
                _UseServerFolderBrowser = value;
            }
        }

        public enum BrowseTypes
        {
            SelectFile,
            SelectFolder
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.PathControl != null)
            {
                if (this.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    switch (this.BrowseType)
                    {
                        case BrowseTypes.SelectFile:
                            this.PathControl.Text = openFileDialog.FileName;
                            break;
                        case BrowseTypes.SelectFolder:
                            if (this.UseServerFolderBrowser == false)
                                this.PathControl.Text = folderBrowserDialog.SelectedPath;
                            else
                            {
                                if (Options.SettingInitializer.GetDataAccess().Connection.ServerIsLocal())
                                    this.PathControl.Text = folderBrowserDialog.SelectedPath;
                                else
                                    this.PathControl.Text = ServerFolderBrowser.SelectedPath;
                            }
                            break;
                    }
                }
            }
        }

        private DialogResult ShowDialog()
        {
            if (this.PathControl != null)
                switch (this.BrowseType)
                {
                    case BrowseTypes.SelectFile:
                        openFileDialog.FileName = PathControl.Text;
                        return openFileDialog.ShowDialog();
                    case BrowseTypes.SelectFolder:
                        folderBrowserDialog.SelectedPath = PathControl.Text;
                        if (this.UseServerFolderBrowser == false)
                            return folderBrowserDialog.ShowDialog();
                        else
                        {
                            if (Options.SettingInitializer.GetDataAccess().Connection.ServerIsLocal())
                                return folderBrowserDialog.ShowDialog();
                            else
                                return ServerFolderBrowser.ShowDialog();
                        }
                }
            return System.Windows.Forms.DialogResult.None;
        }

        private Control _PathControl = null;
        [DefaultValue(null)]
        public Control PathControl
        {
            get
            {
                return _PathControl;
            }
            set
            {
                _PathControl = value;
            }
        }

        [DefaultValue("")]
        public string FileName
        {
            get
            {
                return openFileDialog.FileName;
            }
            set
            {
                openFileDialog.FileName = value;
            }
        }

        [DefaultValue("")]
        public string Filter
        {
            get
            {
                return openFileDialog.Filter;
            }
            set
            {
                openFileDialog.Filter = value;
            }
        }

        [DefaultValue("")]
        public string Title
        {
            get
            {
                return openFileDialog.Title;
            }
            set
            {
                openFileDialog.Title = value;
            }
        }

        public string Description
        {
            get
            {
                return folderBrowserDialog.Description;
            }
            set
            {
                folderBrowserDialog.Description = value;
            }
        }

        [DefaultValue("")]
        public string SelectedPath
        {
            get
            {
                return folderBrowserDialog.SelectedPath;
            }
            set
            {
                folderBrowserDialog.SelectedPath = value;
            }
        }

        [DefaultValue(true)]
        public bool ShowNewFolderButton
        {
            get
            {
                return folderBrowserDialog.ShowNewFolderButton;
            }
            set
            {
                folderBrowserDialog.ShowNewFolderButton = value;
            }
        }
    }
}
