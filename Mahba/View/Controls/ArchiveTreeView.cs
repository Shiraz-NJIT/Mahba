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
    public partial class ArchiveTreeView : Njit.Program.Controls.TreeViewExtended
    {
        public ArchiveTreeView()
        {
            InitializeComponent();
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ImageList = imageList;
            foreach (ToolStripItem item in contextMenuStrip.Items)
                item.Click += toolStripItemClick;
        }

        private void toolStripItemClick(object sender, EventArgs e)
        {
            #region AddArchiveGroup
            if (sender == toolStripMenuItemAddArchiveGroup)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {
                    Model.Common.ArchiveGroup archiveGroup = Model.Common.ArchiveGroup.GetNewInstance("گروه بایگانی جدید", this.SelectedNode == null ? null : (this.SelectedNode.Tag as Model.Common.ArchiveTree).ArchiveGroupID);
                    dc.ArchiveGroups.InsertOnSubmit(archiveGroup);
                    dc.SubmitChanges();

                    Model.Common.ArchiveTree groupTree = Model.Common.ArchiveTree.GetNewInstance(null, archiveGroup.ID, null, null, null, this.SelectedNode == null ? null : (int?)(this.SelectedNode.Tag as Model.Common.ArchiveTree).ID, this.SelectedNode == null ? GetMaxIndex(this.Nodes) + 1 : GetMaxIndex(this.SelectedNode.Nodes) + 1);
                    dc.ArchiveTrees.InsertOnSubmit(groupTree);
                    dc.SubmitChanges();

                    TreeNode node = AddNode(this.SelectedNode == null ? null : this.SelectedNode, groupTree);
                    this.SelectedNode = node;
                    node.EnsureVisible();
                    node.BeginEdit();
                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            #endregion
            #region AddArchive
            else if (sender == toolStripMenuItemAddArchive)
            {
                try
                {
                    int maxArchiveCount = Setting.Program.MaxArchiveCount();
                    if (Controller.Common.ArchiveController.GetActiveArchivesCount() >= maxArchiveCount)
                    {
                        PersianMessageBox.Show(this, "امکان تعریف بیش از " + maxArchiveCount.ToString() + " بایگانی وجود ندارد");
                        return;
                    }
                    View.ArchiveManageForms.ArchiveAdd _ArchiveAddForm = new View.ArchiveManageForms.ArchiveAdd();
                    if (_ArchiveAddForm.ShowDialog() != DialogResult.OK)
                        return;
                    Model.Common.ArchiveTree groupTree = Controller.Common.ArchiveController.AddArchive(this.SelectedNode == null ? null : (this.SelectedNode.Tag as Model.Common.ArchiveTree).ArchiveGroupID, _ArchiveAddForm.SelectedDatabasePath, _ArchiveAddForm.UseDatabase, _ArchiveAddForm.SelectedDocumentsPathOrDatabasePath, this.SelectedNode == null ? GetMaxIndex(this.Nodes) + 1 : GetMaxIndex(this.SelectedNode.Nodes) + 1, this.SelectedNode == null ? null : (int?)(this.SelectedNode.Tag as Model.Common.ArchiveTree).ID);
                    TreeNode node = AddNode(this.SelectedNode == null ? null : this.SelectedNode, groupTree);
                    this.SelectedNode = node;
                    node.EnsureVisible();
                    node.BeginEdit();
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا" + "\r\n" + ex.Message);
                }
            }
            #endregion
            #region AddFilter
            else if (sender == toolStripMenuItemAddFilter)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {

                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            #endregion
            #region AddGroupBy
            else if (sender == toolStripMenuItemAddGroupBy)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {

                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            #endregion
            #region AddNode
            else if (sender == toolStripMenuItemAddNode)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {
                    Model.Common.ArchiveTree groupTree = Model.Common.ArchiveTree.GetNewInstance("گروه جدید", null, null, null, null, this.SelectedNode == null ? null : (int?)(this.SelectedNode.Tag as Model.Common.ArchiveTree).ID, this.SelectedNode == null ? GetMaxIndex(this.Nodes) + 1 : GetMaxIndex(this.SelectedNode.Nodes) + 1);
                    dc.ArchiveTrees.InsertOnSubmit(groupTree);
                    dc.SubmitChanges();
                    TreeNode node = AddNode(this.SelectedNode == null ? null : this.SelectedNode, groupTree);
                    this.SelectedNode = node;
                    node.EnsureVisible();
                    node.BeginEdit();
                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            #endregion
            #region Rename
            else if (sender == toolStripMenuItemRename)
            {
                this.SelectedNode.BeginEdit();
            }
            #endregion
            #region Delete
            else if (sender == toolStripMenuItemDelete)
            {
                if (this.SelectedNode.Nodes.Count > 0)
                {
                    PersianMessageBox.Show(this, "فقط گره های خالی را می توانید حذف کنید");
                    return;
                }
                Model.Common.ArchiveTree groupTree = this.SelectedNode.Tag as Model.Common.ArchiveTree;
                string title = null;
                string groupTreeType = null;
                switch (groupTree.GetNodeType())
                {
                    case NjitSoftware.Model.Common.ArchiveTree.NodeTypes.Node:
                        title = groupTree.Title;
                        groupTreeType = null;
                        break;
                    case NjitSoftware.Model.Common.ArchiveTree.NodeTypes.ArchiveGroup:
                        title = groupTree.ArchiveGroup.Title;
                        groupTreeType = "گروه بایگانی";
                        break;
                    case NjitSoftware.Model.Common.ArchiveTree.NodeTypes.Archive:
                        title = groupTree.Archive.Title;
                        groupTreeType = "بایگانی";
                        break;
                    case NjitSoftware.Model.Common.ArchiveTree.NodeTypes.Filter:
                        title = groupTree.Title;
                        groupTreeType = "فیلتر";
                        break;
                    case NjitSoftware.Model.Common.ArchiveTree.NodeTypes.GroupBy:
                        title = groupTree.Title;
                        groupTreeType = "گروه بندی";
                        break;
                }
                if (groupTreeType != null)
                {
                    var result = PersianMessageBox.Show(this, string.Format("{0} '{1}' حذف شود؟", groupTreeType, title), "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result != DialogResult.Yes)
                        return;
                }
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {
                    switch (groupTree.GetNodeType())
                    {
                        case Model.Common.ArchiveTree.NodeTypes.Node:
                            dc.ArchiveTrees.DeleteAllOnSubmit(dc.ArchiveTrees.Where(t => t.ID == groupTree.ID));
                            dc.SubmitChanges();
                            break;
                        case Model.Common.ArchiveTree.NodeTypes.ArchiveGroup:
                            dc.ArchiveTrees.DeleteAllOnSubmit(dc.ArchiveTrees.Where(t => t.ID == groupTree.ID));
                            dc.SubmitChanges();

                            var fields = dc.ArchiveGroupFields.Where(t => t.ArchiveGroupID == groupTree.ArchiveGroupID);
                            var tabs = dc.ArchiveGroupTabs.Where(t => t.ArchiveGroupID == groupTree.ArchiveGroupID);

                            dc.ArchiveGroupFields.DeleteAllOnSubmit(fields);
                            dc.SubmitChanges();

                            dc.ArchiveGroupTabs.DeleteAllOnSubmit(tabs);
                            dc.SubmitChanges();

                            dc.ArchiveGroups.DeleteAllOnSubmit(dc.ArchiveGroups.Where(t => t.ID == groupTree.ArchiveGroupID));
                            dc.SubmitChanges();
                            break;
                        case Model.Common.ArchiveTree.NodeTypes.Archive:
                            dc.ArchiveTrees.DeleteAllOnSubmit(dc.ArchiveTrees.Where(t => t.ID == groupTree.ID));
                            dc.SubmitChanges();
                            var archive = dc.Archives.Where(t => t.ID == groupTree.ArchiveID);
                            foreach (var item in archive)
                                item.Active = false;
                            dc.SubmitChanges();
                            break;
                        case Model.Common.ArchiveTree.NodeTypes.Filter:
                            dc.ArchiveTrees.DeleteAllOnSubmit(dc.ArchiveTrees.Where(t => t.ID == groupTree.ID));
                            dc.SubmitChanges();
                            break;
                        case Model.Common.ArchiveTree.NodeTypes.GroupBy:
                            dc.ArchiveTrees.DeleteAllOnSubmit(dc.ArchiveTrees.Where(t => t.ID == groupTree.ID));
                            dc.SubmitChanges();
                            break;
                        default:
                            throw new Exception();
                    }
                    Controller.Common.AccessPermissionTree.SaveArchivesTrees(dc);
                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    PersianMessageBox.Show(this, "خطا در حذف" + "\r\n\r\n" + ex.Message);
                    return;
                }
                dc.Transaction.Commit();
                dc.Connection.Close();
                TreeNode node = this.SelectedNode;
                this.SelectedNode = (node.PrevNode ?? node.NextNode) ?? node.Parent;
                node.Remove();
            }
            #endregion
            #region AddToNewGroup
            else if (sender == toolStripMenuItemAddToNewGroup)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {
                    Model.Common.ArchiveTree groupTree = Model.Common.ArchiveTree.GetNewInstance("گروه جدید", null, null, null, null, this.SelectedNode.Parent == null ? null : (int?)(this.SelectedNode.Parent.Tag as Model.Common.ArchiveTree).ID, this.SelectedNode.Parent == null ? GetMaxIndex(this.Nodes) + 1 : GetMaxIndex(this.SelectedNode.Parent.Nodes) + 1);
                    dc.ArchiveTrees.InsertOnSubmit(groupTree);
                    dc.SubmitChanges();
                    foreach (var item in dc.ArchiveTrees.Where(t => t.ID == (this.SelectedNode.Tag as Model.Common.ArchiveTree).ID))
                        item.ParentID = groupTree.ID;
                    dc.SubmitChanges();
                    TreeNode node = AddNode(this.SelectedNode.Parent == null ? null : this.SelectedNode.Parent, groupTree);
                    TreeNode currentNode = this.SelectedNode;
                    currentNode.Remove();
                    node.Nodes.Add(currentNode);
                    this.SelectedNode = node;
                    node.Expand();
                    node.EnsureVisible();
                    node.BeginEdit();
                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
            else if (sender == toolStripMenuItemAddArchiveGroupTab)
            {
                try
                {
                    NjitSoftware.Model.Common.ArchiveTree T = (NjitSoftware.Model.Common.ArchiveTree)this.SelectedNode.Tag;
                    new View.ArchiveManageForms.ArchiveGroupTab(T.ArchiveGroupID.Value, 1).ShowDialog();
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در نمایش فرم مدیریت گروه های اطلاعاتی" + "\r\n\r\n" + ex.Message);
                    return;
                }
            }

            #endregion
        }

        private int GetMaxIndex(TreeNodeCollection treeNodeCollection)
        {
            int max = 0;
            foreach (TreeNode item in treeNodeCollection)
            {
                Model.Common.ArchiveTree gt = item.Tag as Model.Common.ArchiveTree;
                if (gt.Index > max)
                    max = gt.Index;
            }
            return max;
        }

        [DefaultValue(typeof(System.Windows.Forms.RightToLeft), "Yes")]
        public new System.Windows.Forms.RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        [DefaultValue(true)]
        public new bool RightToLeftLayout
        {
            get
            {
                return base.RightToLeftLayout;
            }
            set
            {
                base.RightToLeftLayout = value;
            }
        }

        #region icons
        [DefaultValue(null)]
        [Category("Icons")]
        public Image NodeIcon
        {
            get
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Node)))
                    return imageList.Images[Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Node)];
                return null;
            }
            set
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Node)))
                    imageList.Images.RemoveByKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Node));
                imageList.Images.Add(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Node), value);
            }
        }

        [DefaultValue(null)]
        [Category("Icons")]
        public Image ArchiveGroupIcon
        {
            get
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.ArchiveGroup)))
                    return imageList.Images[Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.ArchiveGroup)];
                return null;
            }
            set
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.ArchiveGroup)))
                    imageList.Images.RemoveByKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.ArchiveGroup));
                imageList.Images.Add(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.ArchiveGroup), value);
            }
        }

        [DefaultValue(null)]
        [Category("Icons")]
        public Image ArchiveIcon
        {
            get
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Archive)))
                    return imageList.Images[Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Archive)];
                return null;
            }
            set
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Archive)))
                    imageList.Images.RemoveByKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Archive));
                imageList.Images.Add(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Archive), value);
            }
        }

        [DefaultValue(null)]
        [Category("Icons")]
        public Image FilterIcon
        {
            get
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Filter)))
                    return imageList.Images[Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Filter)];
                return null;
            }
            set
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Filter)))
                    imageList.Images.RemoveByKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Filter));
                imageList.Images.Add(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.Filter), value);
            }
        }

        [DefaultValue(null)]
        [Category("Icons")]
        public Image GroupByIcon
        {
            get
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.GroupBy)))
                    return imageList.Images[Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.GroupBy)];
                return null;
            }
            set
            {
                if (imageList.Images.ContainsKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.GroupBy)))
                    imageList.Images.RemoveByKey(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.GroupBy));
                imageList.Images.Add(Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), Model.Common.ArchiveTree.NodeTypes.GroupBy), value);
            }
        }
        #endregion

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            base.OnNodeMouseClick(e);
            if (this.SelectedNode != e.Node)
                this.SelectedNode = e.Node;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode)
                return;
            if (this.IsHandleCreated)
                LoadData();
        }

        public void LoadData()
        {
            if (this.DesignMode)
                return;
            try
            {
                this.SuspendLayout();
                this.Nodes.Clear();
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var data = dc.ArchiveTrees;
                foreach (var item in data.Where(t => t.ParentID == null).OrderBy(t => t.Index))
                {
                    TreeNode node = AddNode(null, item);
                    AddNodes(node, data, item);
                }
                if (this.Nodes.Count > 0)
                {
                    this.ExpandAll();
                    this.SelectedNode = this.Nodes[0];
                    this.SelectedNode.EnsureVisible();
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در بارگذاری اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
            finally
            {
                this.ResumeLayout(false);
            }
        }

        private void AddNodes(TreeNode node, IEnumerable<Model.Common.ArchiveTree> groupTrees, Model.Common.ArchiveTree groupTree)
        {
            foreach (var i in groupTrees.Where(t => t.ParentID == groupTree.ID).OrderBy(t => t.Index))
            {
                TreeNode newnode = AddNode(node, i);
                AddNodes(newnode, groupTrees, i);
            }
        }

        private TreeNode AddNode(TreeNode node, Model.Common.ArchiveTree item)
        {
            TreeNode newNode = new TreeNode();
            string title;
            if (item.GroupBy != null)
                title = item.GroupBy;
            else if (item.Filter != null)
                title = item.Filter;
            else if (item.Archive != null)
                title = item.Archive.Title;
            else if (item.ArchiveGroup != null)
                title = item.ArchiveGroup.Title;
            else if (item.Title != null)
                title = item.Title;
            else
                title = "";
            newNode.Text = title;
            newNode.Tag = item;
            newNode.Name = item.ID.ToString();
            newNode.SelectedImageKey = newNode.ImageKey = Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), item.GetNodeType());
            if (node == null)
                this.Nodes.Add(newNode);
            else
                node.Nodes.Add(newNode);
            if (item.GetNodeType() == Model.Common.ArchiveTree.NodeTypes.GroupBy)
            {
                IEnumerable<string> groupItems = GetGroupItems(item.ArchiveID.Value, item.GroupBy);
                if (groupItems != null)
                {
                    foreach (string groupItem in groupItems)
                    {
                        Model.Common.ArchiveTree newArchiveTree = Model.Common.ArchiveTree.GetNewInstance(groupItem, item.ArchiveGroupID, item.ArchiveID, item.GroupBy + "=" + groupItem, null, item.ID, 0);
                        AddNode(node, newArchiveTree);
                    }
                }
            }
            return newNode;
        }

        public virtual IEnumerable<string> GetGroupItems(long archiveCode, string column)
        {
            return null;
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            this.SelectedNode = this.GetNodeAt(this.PointToClient(Cursor.Position));
            if (this.SelectedNode == null)
            {
                foreach (ToolStripItem item in contextMenuStrip.Items)
                    item.Visible = false;
                toolStripMenuItemAddArchiveGroup.Visible = toolStripMenuItemAddNode.Visible = true;
                toolStripMenuItemAddArchiveGroup.Text = "ایجاد گروه بایگانی";
            }
            else
            {
                foreach (ToolStripItem item in contextMenuStrip.Items)
                {
                    if (item.Tag is string && ContainsStringInValues(((string)item.Tag), Enum.GetName(typeof(Model.Common.ArchiveTree.NodeTypes), (this.SelectedNode.Tag as Model.Common.ArchiveTree).GetNodeType())))
                        item.Visible = true;
                    else if (!(item.Tag is string))
                        item.Visible = true;
                    else
                        item.Visible = false;
                    if (item.Name == toolStripMenuItemAddArchiveGroup.Name)
                    {
                        if ((this.SelectedNode.Tag as Model.Common.ArchiveTree).GetNodeType() == Model.Common.ArchiveTree.NodeTypes.ArchiveGroup)
                            item.Text = "ایجاد زیر گروه بایگانی";
                        else
                            item.Text = "ایجاد گروه بایگانی";
                    }
                }
            }
        }

        private bool ContainsStringInValues(string values, string s)
        {
            string[] arr = values.Split(',');
            foreach (string item in arr)
            {
                if (item == s)
                    return true;
            }
            return false;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.F2 && this.SelectedNode != null)
                this.SelectedNode.BeginEdit();
            else if (e.KeyCode == Keys.F5)
                this.LoadData();
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            base.OnItemDrag(e);
            TreeNode treeNode = e.Item as TreeNode;
            if (treeNode != null)
            {
                Model.Common.ArchiveTree groupTree = treeNode.Tag as Model.Common.ArchiveTree;
                if (groupTree != null)
                {
                    if (groupTree.GetNodeType() == Model.Common.ArchiveTree.NodeTypes.Node || groupTree.GetNodeType() == Model.Common.ArchiveTree.NodeTypes.ArchiveGroup)
                        this.DoDragDrop(e.Item, DragDropEffects.All);
                }
            }
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
            if (drgevent.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode destinationNode = this.GetNodeAt(this.PointToClient(new Point(drgevent.X, drgevent.Y)));
                TreeNode dragedNode = (TreeNode)drgevent.Data.GetData("System.Windows.Forms.TreeNode");
                if (drgevent.KeyState == 5
                    && (destinationNode != null && destinationNode != dragedNode && destinationNode.Parent == dragedNode.Parent))
                    drgevent.Effect = DragDropEffects.Copy;
                else if (drgevent.KeyState == 1
                    && (destinationNode != dragedNode
                    && ((destinationNode != null && (destinationNode.Tag as Model.Common.ArchiveTree).GetNodeType() == NjitSoftware.Model.Common.ArchiveTree.NodeTypes.Node) || destinationNode == null)
                    && ((dragedNode.Parent != null && (dragedNode.Parent.Tag as Model.Common.ArchiveTree).GetNodeType() != NjitSoftware.Model.Common.ArchiveTree.NodeTypes.ArchiveGroup) || dragedNode.Parent == null)
                    && ((destinationNode != null && !NodeIsSubNode(destinationNode, dragedNode)) || destinationNode == null)))
                    drgevent.Effect = DragDropEffects.Move;
                else
                    drgevent.Effect = DragDropEffects.None;
            }
            else
                drgevent.Effect = DragDropEffects.None;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            if (drgevent.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode destinationNode = this.GetNodeAt(this.PointToClient(new Point(drgevent.X, drgevent.Y)));
                TreeNode dragedNode = (TreeNode)drgevent.Data.GetData("System.Windows.Forms.TreeNode");
                if (drgevent.Effect == DragDropEffects.Move)
                {
                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    dc.Connection.Open();
                    dc.Transaction = dc.Connection.BeginTransaction();
                    try
                    {
                        if (destinationNode != null)
                        {
                            Model.Common.ArchiveTree destinationNodeTree = destinationNode.Tag as Model.Common.ArchiveTree;
                            Model.Common.ArchiveTree dragedNodeTree = dragedNode.Tag as Model.Common.ArchiveTree;
                            foreach (var item in dc.ArchiveTrees.Where(t => t.ID == dragedNodeTree.ID))
                            {
                                item.ParentID = destinationNodeTree.ID;
                                item.Index = GetMaxIndex(destinationNode.Nodes) + 1;
                            }
                        }
                        else
                        {
                            Model.Common.ArchiveTree dragedNodeTree = dragedNode.Tag as Model.Common.ArchiveTree;
                            foreach (var item in dc.ArchiveTrees.Where(t => t.ID == dragedNodeTree.ID))
                            {
                                item.ParentID = null;
                                item.Index = GetMaxIndex(this.Nodes) + 1;
                            }
                        }
                        dc.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        dc.Transaction.Rollback();
                        dc.Connection.Close();
                        PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                        return;
                    }
                    dc.Transaction.Commit();
                    dc.Connection.Close();

                    dragedNode.Remove();
                    if (destinationNode != null)
                        destinationNode.Nodes.Add(dragedNode);
                    else
                        this.Nodes.Add(dragedNode);

                    this.SelectedNode = dragedNode;

                    dragedNode.EnsureVisible();
                }
                else if (drgevent.Effect == DragDropEffects.Copy)
                {
                    Model.Common.ArchiveTree destinationNodeTree = (destinationNode.Tag as Model.Common.ArchiveTree);
                    Model.Common.ArchiveTree dragedNodeTree = (dragedNode.Tag as Model.Common.ArchiveTree);

                    int temp = dragedNodeTree.Index;
                    dragedNodeTree.Index = destinationNodeTree.Index;
                    destinationNodeTree.Index = temp;

                    Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                    dc.Connection.Open();
                    dc.Transaction = dc.Connection.BeginTransaction();
                    try
                    {
                        foreach (var item in dc.ArchiveTrees.Where(t => t.ID == dragedNodeTree.ID))
                        {
                            item.Index = dragedNodeTree.Index;
                        }
                        foreach (var item in dc.ArchiveTrees.Where(t => t.ID == destinationNodeTree.ID))
                        {
                            item.Index = destinationNodeTree.Index;
                        }
                        dc.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        dc.Transaction.Rollback();
                        dc.Connection.Close();
                        PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                        return;
                    }
                    dc.Transaction.Commit();
                    dc.Connection.Close();

                    this.SelectedNode = dragedNode;
                    dragedNode.EnsureVisible();
                    LoadData();
                }
            }
        }

        private bool NodeIsSubNode(TreeNode childNode, TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node == childNode)
                    return true;
                else if (NodeIsSubNode(childNode, node))
                    return true;
            }
            return false;
        }

        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            base.OnAfterLabelEdit(e);
            if (e.Label != null)
            {
                Model.Common.ArchiveTree groupTree = e.Node.Tag as Model.Common.ArchiveTree;
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                dc.Connection.Open();
                dc.Transaction = dc.Connection.BeginTransaction();
                try
                {
                    switch (groupTree.GetNodeType())
                    {
                        case Model.Common.ArchiveTree.NodeTypes.Filter:
                        case Model.Common.ArchiveTree.NodeTypes.GroupBy:
                        case Model.Common.ArchiveTree.NodeTypes.Node:
                            groupTree.Title = e.Label;
                            var data1 = dc.ArchiveTrees.Where(t => t.ID == groupTree.ID);
                            foreach (var item in data1)
                                item.Title = e.Label;
                            dc.SubmitChanges();
                            break;
                        case Model.Common.ArchiveTree.NodeTypes.ArchiveGroup:
                            groupTree.ArchiveGroup.Title = e.Label;
                            var data2 = dc.ArchiveGroups.Where(t => t.ID == groupTree.ArchiveGroupID);
                            foreach (var item in data2)
                                item.Title = e.Label;
                            dc.SubmitChanges();
                            break;
                        case Model.Common.ArchiveTree.NodeTypes.Archive:
                            string originalArchiveTitle = groupTree.Archive.Title;
                            groupTree.Archive.Title = e.Label;
                            var data3 = dc.Archives.Where(t => t.ID == groupTree.ArchiveID);
                            foreach (var item in data3)
                                item.Title = e.Label;
                            dc.SubmitChanges();
                            try
                            {
                                Setting.User.ThisProgram.AddLog(dc, Setting.User.UserOparatesPlaceNames.بایگانی, Setting.User.UserOparatesNames.ویرایش, "", "تغییر نام بایگانی '" + originalArchiveTitle + "' به '" + e.Label + "'");
                            }
                            catch
                            {
                                throw new Exception("خطا در ذخیره عملکرد کاربر جاری");
                            }
                            Controller.Common.AccessPermissionTree.SaveArchivesTrees(dc);
                            break;
                        default:
                            throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    dc.Transaction.Rollback();
                    dc.Connection.Close();
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }
                dc.Transaction.Commit();
                dc.Connection.Close();
            }
        }
    }
}
