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
    /// <summary>
    /// نمایش ساختار درختی
    /// </summary>
    [Description("نمایش ساختار درختی")]
    [ToolboxBitmap(typeof(TreeView))]
    public partial class AccessPermissionTreeView : TreeViewExtended
    {
        public AccessPermissionTreeView()
        {
            InitializeComponent();
            this.CheckBoxes = true;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.toolStripMenuItemCheckAll.Click += toolStripMenuItemCheckAll_Click;
            this.toolStripMenuItemCheckNone.Click += toolStripMenuItemCheckNone_Click;
        }

        void toolStripMenuItemCheckNone_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in this.GetNodes(this.Nodes))
            {
                item.Checked = false;
            }
        }

        void toolStripMenuItemCheckAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode item in this.GetNodes(this.Nodes))
            {
                item.Checked = true;
            }
        }

        public class AccessPermission
        {
            public AccessPermission(int AccessPermissionTreeCode, string AccessPermissionTreeItem, string AccessPermissionTreeGroup, string AccessPermissionTreeTitle, bool Allow)
            {
                this.AccessPermissionTreeCode = AccessPermissionTreeCode;
                this.AccessPermissionTreeItem = AccessPermissionTreeItem;
                this.AccessPermissionTreeGroup = AccessPermissionTreeGroup;
                this.AccessPermissionTreeTitle = AccessPermissionTreeTitle;
                this.Allow = Allow;
            }
            private int _AccessPermissionTreeCode;
            public int AccessPermissionTreeCode
            {
                get
                {
                    return _AccessPermissionTreeCode;
                }
                set
                {
                    _AccessPermissionTreeCode = value;
                }
            }
            private string _AccessPermissionTreeItem;
            public string AccessPermissionTreeItem
            {
                get
                {
                    return _AccessPermissionTreeItem;
                }
                set
                {
                    _AccessPermissionTreeItem = value;
                }
            }
            private string _AccessPermissionTreeGroup;
            public string AccessPermissionTreeGroup
            {
                get
                {
                    return _AccessPermissionTreeGroup;
                }
                set
                {
                    _AccessPermissionTreeGroup = value;
                }
            }
            private string _AccessPermissionTreeTitle;
            public string AccessPermissionTreeTitle
            {
                get
                {
                    return _AccessPermissionTreeTitle;
                }
                set
                {
                    _AccessPermissionTreeTitle = value;
                }
            }
            private bool _Allow;
            public bool Allow
            {
                get
                {
                    return _Allow;
                }
                set
                {
                    _Allow = value;
                }
            }
            private TreeNode _Node;
            public TreeNode Node
            {
                get
                {
                    return _Node;
                }
                set
                {
                    _Node = value;
                }
            }
        }

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);
            foreach (TreeNode item in GetNodes(e.Node))
            {
                item.Checked = e.Node.Checked;
            }
        }

        /// <summary>
        /// دریافت تمامی نود ها
        /// </summary>
        /// <param name="treeNodeCollection"></param>
        /// <returns></returns>
        public List<TreeNode> GetNodes(TreeNodeCollection treeNodeCollection)
        {
            List<TreeNode> list = new List<TreeNode>();
            foreach (TreeNode node in treeNodeCollection)
            {
                list.Add(node);
                AddNodesToList(list, node);
            }
            return list;
        }

        /// <summary>
        /// دریافت تمامی نود های یک نود
        /// </summary>
        public List<TreeNode> GetNodes(TreeNode treeNode)
        {
            List<TreeNode> list = new List<TreeNode>();
            foreach (TreeNode node in treeNode.Nodes)
            {
                list.Add(node);
                AddNodesToList(list, node);
            }
            return list;
        }

        private void AddNodesToList(List<TreeNode> list, TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                list.Add(node);
                AddNodesToList(list, node);
            }
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            if (this.SelectedNode != e.Node)
                this.SelectedNode = e.Node;
        }

        /// <summary>
        /// مقدار دهی داده ها
        /// </summary>
        public void SetData(IEnumerable<AccessPermission> accessPermissions)
        {
            this.Nodes.Clear();
            if (accessPermissions == null)
                return;
            //this.SuspendLayout();
            foreach (var item in accessPermissions.Where(t => t.AccessPermissionTreeGroup == null))
            {
                TreeNode node = AddNode(null, item);
                AddNodes(node, accessPermissions, item);
            }
            if (this.Nodes.Count > 0)
            {
                this.ExpandAll();
                this.SelectedNode = this.Nodes[0];
                this.SelectedNode.EnsureVisible();
            }
            this.Refresh();
            //this.ResumeLayout(true);
        }

        /// <summary>
        /// دریافت داده ها
        /// </summary>
        public List<AccessPermission> GetData()
        {
            List<AccessPermission> list = new List<AccessPermission>();
            foreach (TreeNode node in this.Nodes)
            {
                list.Add(new AccessPermission((node.Tag as AccessPermission).AccessPermissionTreeCode, (node.Tag as AccessPermission).AccessPermissionTreeItem, null, node.Text, node.Checked) { Node = node });
                AddNodesToList(list, node);
            }
            return list;
        }

        private void AddNodesToList(List<AccessPermission> list, TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                list.Add(new AccessPermission((node.Tag as AccessPermission).AccessPermissionTreeCode, (node.Tag as AccessPermission).AccessPermissionTreeItem, node.Parent.Tag as string, node.Text, node.Checked) { Node = node });
                AddNodesToList(list, node);
            }
        }

        private void AddNodes(TreeNode node, IEnumerable<AccessPermission> accessPermissions, AccessPermission item)
        {
            foreach (var i in accessPermissions.Where(t => t.AccessPermissionTreeGroup == item.AccessPermissionTreeItem))
            {
                TreeNode newnode = AddNode(node, i);
                AddNodes(newnode, accessPermissions, i);
            }
        }

        private TreeNode AddNode(TreeNode node, AccessPermission item)
        {
            TreeNode newnode = new TreeNode(item.AccessPermissionTreeTitle);
            newnode.Tag = item;
            newnode.Checked = item.Allow;
            if (node == null)
                this.Nodes.Add(newnode);
            else
                node.Nodes.Add(newnode);
            return newnode;
        }

    }
}
