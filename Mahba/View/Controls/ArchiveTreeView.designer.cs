namespace NjitSoftware.View.Controls
{
    partial class ArchiveTreeView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddToNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddArchiveGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddArchiveGroupTab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddGroupBy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddToNewGroup,
            this.toolStripMenuItemAddNode,
            this.toolStripMenuItemAddArchiveGroup,
            this.toolStripMenuItemAddArchive,
            this.toolStripMenuItemAddArchiveGroupTab,
            this.toolStripMenuItemAddFilter,
            this.toolStripMenuItemAddGroupBy,
            this.toolStripSeparator,
            this.toolStripMenuItemRename,
            this.toolStripMenuItemDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(167, 186);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // toolStripMenuItemAddToNewGroup
            // 
            this.toolStripMenuItemAddToNewGroup.Name = "toolStripMenuItemAddToNewGroup";
            this.toolStripMenuItemAddToNewGroup.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemAddToNewGroup.Tag = "Node,ArchiveGroup";
            this.toolStripMenuItemAddToNewGroup.Text = "انتقال به گروه جدید";
            // 
            // toolStripMenuItemAddNode
            // 
            this.toolStripMenuItemAddNode.Name = "toolStripMenuItemAddNode";
            this.toolStripMenuItemAddNode.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemAddNode.Tag = "Node";
            this.toolStripMenuItemAddNode.Text = "ایجاد گروه";
            // 
            // toolStripMenuItemAddArchiveGroup
            // 
            this.toolStripMenuItemAddArchiveGroup.Name = "toolStripMenuItemAddArchiveGroup";
            this.toolStripMenuItemAddArchiveGroup.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemAddArchiveGroup.Tag = "Node,ArchiveGroup";
            this.toolStripMenuItemAddArchiveGroup.Text = "ایجاد گروه بایگانی";
            // 
            // toolStripMenuItemAddArchiveGroupTab
            // 
            this.toolStripMenuItemAddArchiveGroupTab.Name = "toolStripMenuItemAddArchiveGroupTab";
            this.toolStripMenuItemAddArchiveGroupTab.Size = new System.Drawing.Size(250, 22);
            this.toolStripMenuItemAddArchiveGroupTab.Tag = "ArchiveGroup";
            this.toolStripMenuItemAddArchiveGroupTab.Text = "مدیریت گروه های اطلاعاتی و فیلدها";
            // 
            // toolStripMenuItemAddArchive
            // 
            this.toolStripMenuItemAddArchive.Name = "toolStripMenuItemAddArchive";
            this.toolStripMenuItemAddArchive.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemAddArchive.Tag = "ArchiveGroup";
            this.toolStripMenuItemAddArchive.Text = "ایجاد بایگانی";
            // 
            // toolStripMenuItemAddFilter
            // 
            this.toolStripMenuItemAddFilter.Name = "toolStripMenuItemAddFilter";
            this.toolStripMenuItemAddFilter.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemAddFilter.Tag = "Archive";
            this.toolStripMenuItemAddFilter.Text = "ایجاد فیلتر";
            // 
            // toolStripMenuItemAddGroupBy
            // 
            this.toolStripMenuItemAddGroupBy.Name = "toolStripMenuItemAddGroupBy";
            this.toolStripMenuItemAddGroupBy.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemAddGroupBy.Tag = "Archive";
            this.toolStripMenuItemAddGroupBy.Text = "ایجاد گروه بندی";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(163, 6);
            // 
            // toolStripMenuItemRename
            // 
            this.toolStripMenuItemRename.Name = "toolStripMenuItemRename";
            this.toolStripMenuItemRename.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemRename.Text = "تغییر عنوان";
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItemDelete.Text = "حذف";
            // 
            // ArchiveTreeView
            // 
            this.AllowDrop = true;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.LabelEdit = true;
            this.LineColor = System.Drawing.Color.Black;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddNode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddArchiveGroup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddArchive;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddGroupBy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRename;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddToNewGroup;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddArchiveGroupTab;
    }
}
