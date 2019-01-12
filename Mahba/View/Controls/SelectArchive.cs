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
    public partial class SelectArchive : UserControl
    {
        public SelectArchive()
        {
            InitializeComponent();
        }

        private void archiveTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (archiveTreeView.SelectedNode == null)
            {
                return;
            }
            Model.Common.ArchiveTree groupTree = archiveTreeView.SelectedNode.Tag as Model.Common.ArchiveTree;
            Model.Common.ArchiveTree.NodeTypes nodeType = groupTree.GetNodeType();
            switch (nodeType)
            {
                case Model.Common.ArchiveTree.NodeTypes.Node:
                case Model.Common.ArchiveTree.NodeTypes.ArchiveGroup:
                    return;
                case Model.Common.ArchiveTree.NodeTypes.Archive:
                case Model.Common.ArchiveTree.NodeTypes.Filter:
                case Model.Common.ArchiveTree.NodeTypes.GroupBy:
                    break;
                default:
                    throw new Exception();
            }
            Setting.Archive.ThisProgram.SelectedArchiveTree = groupTree;
        }
    }
}
