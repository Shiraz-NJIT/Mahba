namespace Njit.Program.Controls
{
    partial class TextBoxExtended
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUndo,
            this.toolStripSeparator1,
            this.toolStripMenuItemCut,
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemPaste,
            this.toolStripSeparator2,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemSelectAll});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(131, 148);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // toolStripMenuItemUndo
            // 
            this.toolStripMenuItemUndo.Name = "toolStripMenuItemUndo";
            this.toolStripMenuItemUndo.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemUndo.Text = "لغو";
            this.toolStripMenuItemUndo.ToolTipText = "لغو آخرین عمل انجام شده";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStripMenuItemCut
            // 
            this.toolStripMenuItemCut.Name = "toolStripMenuItemCut";
            this.toolStripMenuItemCut.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemCut.Text = "Cut";
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemCopy.Text = "Copy";
            // 
            // toolStripMenuItemPaste
            // 
            this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
            this.toolStripMenuItemPaste.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemPaste.Text = "Paste";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemDelete.Text = "حذف";
            // 
            // toolStripMenuItemSelectAll
            // 
            this.toolStripMenuItemSelectAll.Name = "toolStripMenuItemSelectAll";
            this.toolStripMenuItemSelectAll.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItemSelectAll.Text = "انتخاب همه";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            // 
            // TextBoxExtended
            // 
            this.ContextMenuStrip = this.contextMenuStrip;
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUndo;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCut;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaste;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectAll;
        protected System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}
