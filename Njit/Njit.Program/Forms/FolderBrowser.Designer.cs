namespace Njit.Program.Forms
{
    partial class FolderBrowser
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
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnNewFolder = new Njit.Program.Controls.ButtonExtended();
            this.btnOK = new Njit.Program.Controls.ButtonExtended();
            this.folderBrowserControl = new Njit.Program.Controls.FolderBrowserControl();
            this.panelCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnNewFolder);
            this.panelCommand.Controls.Add(this.btnOK);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(10, 302);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.panelCommand.Size = new System.Drawing.Size(384, 29);
            this.panelCommand.TabIndex = 1;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNewFolder.Location = new System.Drawing.Point(10, 3);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(125, 23);
            this.btnNewFolder.TabIndex = 1;
            this.btnNewFolder.Text = "ساخته پوشه جدید";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // btnOK
            // 
            this.btnOK.AllowCheckAccessPermission = false;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(309, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "انتخاب";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // folderBrowserControl
            // 
            this.folderBrowserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderBrowserControl.Location = new System.Drawing.Point(10, 10);
            this.folderBrowserControl.Name = "folderBrowserControl";
            this.folderBrowserControl.Size = new System.Drawing.Size(384, 292);
            this.folderBrowserControl.TabIndex = 0;
            // 
            // FolderBrowser
            // 
            this.AcceptButton = this.btnOK;
            this.AllowCheckAccessPermission = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 331);
            this.Controls.Add(this.folderBrowserControl);
            this.Controls.Add(this.panelCommand);
            this.KeyPreview = true;
            this.Name = "FolderBrowser";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.Text = "انتخاب مسیر";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FolderBrowser_KeyDown);
            this.panelCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelCommand;
        protected Controls.ButtonExtended btnOK;
        private Controls.FolderBrowserControl folderBrowserControl;
        private Controls.ButtonExtended btnNewFolder;
    }
}