namespace Njit.Program.Controls
{
    partial class AccessPermissionTreeView
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
            this.toolStripMenuItemCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCheckNone = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCheckAll,
            this.toolStripMenuItemCheckNone});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(184, 48);
            // 
            // toolStripMenuItemCheckAll
            // 
            this.toolStripMenuItemCheckAll.Name = "toolStripMenuItemCheckAll";
            this.toolStripMenuItemCheckAll.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItemCheckAll.Text = "همه علامت دار شود";
            // 
            // toolStripMenuItemCheckNone
            // 
            this.toolStripMenuItemCheckNone.Name = "toolStripMenuItemCheckNone";
            this.toolStripMenuItemCheckNone.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItemCheckNone.Text = "علامت همه برداشته شود";
            // 
            // AccessPermissionTreeView
            // 
            this.ContextMenuStrip = this.contextMenuStrip;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCheckAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCheckNone;
    }
}
