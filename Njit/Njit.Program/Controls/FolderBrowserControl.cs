using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Njit.MessageBox;

namespace Njit.Program.Controls
{
    public partial class FolderBrowserControl : UserControl
    {
        public FolderBrowserControl()
        {
            InitializeComponent();
        }

        private Njit.Common.SystemUtility _SystemUtility;
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Njit.Common.SystemUtility SystemUtility
        {
            get
            {
                return _SystemUtility;
            }
            set
            {
                _SystemUtility = value;
            }
        }

        [DefaultValue(null)]
        public string SelectedPath
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return null;
                return (treeView.SelectedNode.Tag as string);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                if (SystemUtility == null)
                    _SystemUtility = Options.SystemUtility;
                string[] drives;
                try
                {
                    drives = _SystemUtility.GetDrives();
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در دریافت لیست درایوها" + "\r\n\r\n" + ex.Message);
                    return;
                }
                treeView.Nodes.Clear();
                foreach (string drive in drives)
                {
                    TreeNode node = new TreeNode(drive.Substring(0, 1));
                    node.SelectedImageKey = node.ImageKey = "logicalDrive";
                    node.Tag = drive;
                    treeView.Nodes.Add(node);
                }
            }
        }

        private void ExpandDirectoryToNode(string path, TreeNode treeNode)
        {
            if (treeNode.Level == 0)
                treeNode.SelectedImageKey = treeNode.ImageKey = "logicalDrive";
            else
                treeNode.SelectedImageKey = treeNode.ImageKey = "folderOpen";
            foreach (string directory in _SystemUtility.GetFolders(path, "*", SearchOption.TopDirectoryOnly))
            {
                TreeNode node = new TreeNode(System.IO.Path.GetFileName(directory));
                node.SelectedImageKey = node.ImageKey = "folderClose";
                node.Tag = directory;
                treeNode.Nodes.Add(node);
                treeNode.Expand();
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is string)
            {
                string path = e.Node.Tag as string;
                try
                {
                    ExpandDirectoryToNode(path, e.Node);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا" + "\r\n" + ex.Message);
                }
            }
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && this.treeView.SelectedNode != null && this.treeView.SelectedNode.Tag is string)
            {
                string path = this.treeView.SelectedNode.Tag as string;
                try
                {
                    ExpandDirectoryToNode(path, this.treeView.SelectedNode);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا" + "\r\n" + ex.Message);
                }
            }
        }

        internal void CreateDirectory(string name)
        {
            if (this.SelectedPath == null)
                return;
            string directory = Path.Combine(this.SelectedPath, name);
            this.SystemUtility.CreateDirectory(directory);
            TreeNode node = new TreeNode(name);
            node.SelectedImageKey = node.ImageKey = "folderOpen";
            node.Tag = directory;
            this.treeView.SelectedNode.Nodes.Add(node);
            this.treeView.SelectedNode = node;
        }
    }
}
