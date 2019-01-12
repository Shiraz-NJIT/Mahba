﻿namespace Njit.Program.Controls
{
    partial class DateControl
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemToday = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorTwo = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemToday,
            this.toolStripSeparatorTwo,
            this.toolStripMenuItemCut,
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemPaste,
            this.toolStripSeparatorOne,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemSelectAll});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip.Size = new System.Drawing.Size(144, 142);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // toolStripMenuItemCut
            // 
            this.toolStripMenuItemCut.Name = "toolStripMenuItemCut";
            this.toolStripMenuItemCut.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItemCut.Text = "بریدن تاریخ";
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItemCopy.Text = "کپی تاریخ";
            // 
            // toolStripMenuItemPaste
            // 
            this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
            this.toolStripMenuItemPaste.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItemPaste.Text = "چسباندن تاریخ";
            // 
            // toolStripSeparatorOne
            // 
            this.toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            this.toolStripSeparatorOne.Size = new System.Drawing.Size(140, 6);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItemDelete.Text = "حذف همه";
            // 
            // toolStripMenuItemSelectAll
            // 
            this.toolStripMenuItemSelectAll.Name = "toolStripMenuItemSelectAll";
            this.toolStripMenuItemSelectAll.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItemSelectAll.Text = "انتخاب همه";
            // 
            // toolStripMenuItemToday
            // 
            this.toolStripMenuItemToday.Name = "toolStripMenuItemToday";
            this.toolStripMenuItemToday.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItemToday.Text = "تاریخ امروز";
            // 
            // toolStripSeparatorTwo
            // 
            this.toolStripSeparatorTwo.Name = "toolStripSeparatorTwo";
            this.toolStripSeparatorTwo.Size = new System.Drawing.Size(140, 6);
            // 
            // DateControl
            // 
            this.ContextMenuStrip = this.contextMenuStrip;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolTip toolTip;
        protected System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCut;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaste;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemToday;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorTwo;
    }
}
