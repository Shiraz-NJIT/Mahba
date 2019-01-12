namespace NjitSoftware.View
{
    partial class DossierReport
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
            this.tabControlFields = new System.Windows.Forms.TabControl();
            this.tabPageDossier = new System.Windows.Forms.TabPage();
            this.dossierFieldsTreeView = new Njit.Program.Controls.TreeViewExtended();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageDocument = new System.Windows.Forms.TabPage();
            this.documentsFieldsTreeView = new Njit.Program.Controls.TreeViewExtended();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.savedReportsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.queryTreeView = new Njit.Program.Controls.TreeViewExtended();
            this.contextMenuStripFilter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControlFields.SuspendLayout();
            this.tabPageDossier.SuspendLayout();
            this.tabPageDocument.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStripFilter.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 449);
            this.panelCommand.Size = new System.Drawing.Size(818, 29);
            this.panelCommand.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControlFields);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.queryTreeView);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Location = new System.Drawing.Point(0, 39);
            this.panelMain.Padding = new System.Windows.Forms.Padding(10, 10, 10, 3);
            this.panelMain.Size = new System.Drawing.Size(818, 410);
            this.panelMain.TabIndex = 0;
            // 
            // tabControlFields
            // 
            this.tabControlFields.Controls.Add(this.tabPageDossier);
            this.tabControlFields.Controls.Add(this.tabPageDocument);
            this.tabControlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFields.Location = new System.Drawing.Point(189, 10);
            this.tabControlFields.Name = "tabControlFields";
            this.tabControlFields.RightToLeftLayout = true;
            this.tabControlFields.SelectedIndex = 0;
            this.tabControlFields.Size = new System.Drawing.Size(619, 246);
            this.tabControlFields.TabIndex = 0;
            // 
            // tabPageDossier
            // 
            this.tabPageDossier.Controls.Add(this.dossierFieldsTreeView);
            this.tabPageDossier.Controls.Add(this.label1);
            this.tabPageDossier.Location = new System.Drawing.Point(4, 23);
            this.tabPageDossier.Name = "tabPageDossier";
            this.tabPageDossier.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageDossier.Size = new System.Drawing.Size(611, 219);
            this.tabPageDossier.TabIndex = 0;
            this.tabPageDossier.Text = "     پرونده     ";
            this.tabPageDossier.UseVisualStyleBackColor = true;
            // 
            // dossierFieldsTreeView
            // 
            this.dossierFieldsTreeView.CheckBoxes = true;
            this.dossierFieldsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dossierFieldsTreeView.Location = new System.Drawing.Point(10, 35);
            this.dossierFieldsTreeView.Name = "dossierFieldsTreeView";
            this.dossierFieldsTreeView.RightToLeftLayout = true;
            this.dossierFieldsTreeView.Size = new System.Drawing.Size(591, 174);
            this.dossierFieldsTreeView.TabIndex = 1;
            this.dossierFieldsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dossierFieldsTreeView_AfterSelect);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "انتخاب فیلد ها:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageDocument
            // 
            this.tabPageDocument.Controls.Add(this.documentsFieldsTreeView);
            this.tabPageDocument.Controls.Add(this.label3);
            this.tabPageDocument.Location = new System.Drawing.Point(4, 23);
            this.tabPageDocument.Name = "tabPageDocument";
            this.tabPageDocument.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageDocument.Size = new System.Drawing.Size(377, 142);
            this.tabPageDocument.TabIndex = 1;
            this.tabPageDocument.Text = "     سند     ";
            this.tabPageDocument.UseVisualStyleBackColor = true;
            // 
            // documentsFieldsTreeView
            // 
            this.documentsFieldsTreeView.CheckBoxes = true;
            this.documentsFieldsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentsFieldsTreeView.Location = new System.Drawing.Point(10, 35);
            this.documentsFieldsTreeView.Name = "documentsFieldsTreeView";
            this.documentsFieldsTreeView.RightToLeftLayout = true;
            this.documentsFieldsTreeView.Size = new System.Drawing.Size(357, 97);
            this.documentsFieldsTreeView.TabIndex = 3;
            this.documentsFieldsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dossierFieldsTreeView_AfterSelect);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "انتخاب فیلد ها:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.savedReportsListBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.panel1.Size = new System.Drawing.Size(179, 397);
            this.panel1.TabIndex = 2;
            // 
            // savedReportsListBox
            // 
            this.savedReportsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedReportsListBox.FormattingEnabled = true;
            this.savedReportsListBox.ItemHeight = 14;
            this.savedReportsListBox.Location = new System.Drawing.Point(5, 25);
            this.savedReportsListBox.Name = "savedReportsListBox";
            this.savedReportsListBox.Size = new System.Drawing.Size(169, 372);
            this.savedReportsListBox.TabIndex = 1;
            this.savedReportsListBox.SelectedIndexChanged += new System.EventHandler(this.SavedReportsListBoxSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "گزارشات ذخیره شده:";
            // 
            // queryTreeView
            // 
            this.queryTreeView.AllowDrop = true;
            this.queryTreeView.ContextMenuStrip = this.contextMenuStripFilter;
            this.queryTreeView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.queryTreeView.HideSelection = false;
            this.queryTreeView.Location = new System.Drawing.Point(189, 281);
            this.queryTreeView.Name = "queryTreeView";
            this.queryTreeView.RightToLeftLayout = true;
            this.queryTreeView.Size = new System.Drawing.Size(619, 126);
            this.queryTreeView.TabIndex = 1;
            this.queryTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.queryTreeView_ItemDrag);
            this.queryTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.queryTreeView_NodeMouseClick);
            this.queryTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.queryTreeView_NodeMouseDoubleClick);
            this.queryTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.queryTreeView_DragDrop);
            this.queryTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.queryTreeView_DragOver);
            // 
            // contextMenuStripFilter
            // 
            this.contextMenuStripFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditFilter,
            this.toolStripMenuItemDeleteFilter});
            this.contextMenuStripFilter.Name = "contextMenuStripFilter";
            this.contextMenuStripFilter.Size = new System.Drawing.Size(120, 48);
            this.contextMenuStripFilter.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripFilter_Opening);
            // 
            // toolStripMenuItemEditFilter
            // 
            this.toolStripMenuItemEditFilter.Name = "toolStripMenuItemEditFilter";
            this.toolStripMenuItemEditFilter.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItemEditFilter.Text = "ویرایش...";
            this.toolStripMenuItemEditFilter.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDeleteFilter
            // 
            this.toolStripMenuItemDeleteFilter.Name = "toolStripMenuItemDeleteFilter";
            this.toolStripMenuItemDeleteFilter.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItemDeleteFilter.Text = "حذف";
            this.toolStripMenuItemDeleteFilter.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(189, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(619, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "شرط ها:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator1,
            this.viewToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(818, 39);
            this.mainToolStrip.TabIndex = 6;
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.Image = global::NjitSoftware.Properties.Resources.PageAdd;
            this.newToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(105, 36);
            this.newToolStripButton.Text = "گزارش جدید";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Image = global::NjitSoftware.Properties.Resources.Save2;
            this.saveToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(109, 36);
            this.saveToolStripButton.Text = "ذخیره گزارش";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.Image = global::NjitSoftware.Properties.Resources.delete;
            this.deleteToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(105, 36);
            this.deleteToolStripButton.Text = "حذف گزارش";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // viewToolStripButton
            // 
            this.viewToolStripButton.Image = global::NjitSoftware.Properties.Resources.DocumentSearch;
            this.viewToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewToolStripButton.Name = "viewToolStripButton";
            this.viewToolStripButton.Size = new System.Drawing.Size(124, 36);
            this.viewToolStripButton.Text = "مشاهده گزارش";
            this.viewToolStripButton.Click += new System.EventHandler(this.viewToolStripButton_Click);
            // 
            // DossierReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 478);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "DossierReport";
            this.Text = "گزارشات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.panelCommand, 0);
            this.Controls.SetChildIndex(this.mainToolStrip, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.tabControlFields.ResumeLayout(false);
            this.tabPageDossier.ResumeLayout(false);
            this.tabPageDocument.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStripFilter.ResumeLayout(false);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlFields;
        private System.Windows.Forms.TabPage tabPageDossier;
        private Njit.Program.Controls.TreeViewExtended dossierFieldsTreeView;
        private System.Windows.Forms.TabPage tabPageDocument;
        private Njit.Program.Controls.TreeViewExtended queryTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox savedReportsListBox;
        private System.Windows.Forms.Label label2;
        private Njit.Program.Controls.TreeViewExtended documentsFieldsTreeView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton viewToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
    }
}