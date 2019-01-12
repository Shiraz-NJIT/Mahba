namespace Njit.Program.Forms
{
    partial class SaveAccessPermissionTree
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLoad = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToLevel1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteAndReCreate = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(616, 383);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(101, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "بارگذاری";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.CheckBoxes = true;
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.HideSelection = false;
            this.treeView.LabelEdit = true;
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.RightToLeftLayout = true;
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(705, 365);
            this.treeView.TabIndex = 0;
            this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_DragOver);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.moveToLevel1ToolStripMenuItem,
            this.toolStripSeparator2,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(184, 126);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.addGroupToolStripMenuItem.Text = "انتقال به گروه جدید";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // moveToLevel1ToolStripMenuItem
            // 
            this.moveToLevel1ToolStripMenuItem.Name = "moveToLevel1ToolStripMenuItem";
            this.moveToLevel1ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.moveToLevel1ToolStripMenuItem.Text = "انتقال به آخر سطح اول";
            this.moveToLevel1ToolStripMenuItem.Click += new System.EventHandler(this.moveToLevel1ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cutToolStripMenuItem.Text = "بریدن";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.pasteToolStripMenuItem.Text = "چسباندن";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.deleteToolStripMenuItem.Text = "حذف";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Assembly|*.exe;*.dll";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(535, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(254, 383);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteAndReCreate
            // 
            this.btnDeleteAndReCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAndReCreate.Location = new System.Drawing.Point(335, 383);
            this.btnDeleteAndReCreate.Name = "btnDeleteAndReCreate";
            this.btnDeleteAndReCreate.Size = new System.Drawing.Size(194, 23);
            this.btnDeleteAndReCreate.TabIndex = 3;
            this.btnDeleteAndReCreate.Text = "حذف ساختار درختی ذخیره شده";
            this.btnDeleteAndReCreate.UseVisualStyleBackColor = true;
            this.btnDeleteAndReCreate.Click += new System.EventHandler(this.btnDeleteAndRecreate_Click);
            // 
            // SaveAccessPermissionTree
            // 
            this.AcceptButton = this.btnLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(729, 418);
            this.Controls.Add(this.btnDeleteAndReCreate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.btnLoad);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.KeyPreview = true;
            this.Name = "SaveAccessPermissionTree";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ساختار درختی فرم ها و کامپوننت ها";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem moveToLevel1ToolStripMenuItem;
        private System.Windows.Forms.Button btnDeleteAndReCreate;
    }
}

