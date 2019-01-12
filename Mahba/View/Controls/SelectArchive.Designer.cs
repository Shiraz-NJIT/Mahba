namespace NjitSoftware.View.Controls
{
    partial class SelectArchive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectArchive));
            this.archiveTreeView = new NjitSoftware.View.Controls.ArchiveTreeView();
            this.SuspendLayout();
            // 
            // archiveTreeView
            // 
            this.archiveTreeView.AllowDrop = true;
            this.archiveTreeView.ArchiveGroupIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.ArchiveGroupIcon")));
            this.archiveTreeView.ArchiveIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.ArchiveIcon")));
            this.archiveTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.archiveTreeView.FilterIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.FilterIcon")));
            this.archiveTreeView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.archiveTreeView.GroupByIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.GroupByIcon")));
            this.archiveTreeView.HideSelection = false;
            this.archiveTreeView.ImageIndex = 0;
            this.archiveTreeView.LabelEdit = true;
            this.archiveTreeView.Location = new System.Drawing.Point(0, 0);
            this.archiveTreeView.Name = "archiveTreeView";
            this.archiveTreeView.NodeIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.NodeIcon")));
            this.archiveTreeView.SelectedImageIndex = 0;
            this.archiveTreeView.Size = new System.Drawing.Size(500, 450);
            this.archiveTreeView.TabIndex = 1;
            this.archiveTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.archiveTreeView_NodeMouseDoubleClick);
            // 
            // SelectArchive
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.archiveTreeView);
            this.Name = "SelectArchive";
            this.Size = new System.Drawing.Size(500, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private ArchiveTreeView archiveTreeView;
    }
}
