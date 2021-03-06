namespace Njit.Program.Forms
{
    partial class RestoreBackupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreBackupForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnRestore = new Njit.Program.Controls.ButtonExtended();
            this.btnBrowse = new Njit.Program.Controls.ButtonExtended();
            this.btnCancel = new Njit.Program.Controls.ButtonExtended();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelCommand.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "db.jpg");
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "انتخاب پشتیبان";
            // 
            // btnRestore
            // 
            this.btnRestore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(519, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(87, 25);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "بازیابی";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowse.Location = new System.Drawing.Point(366, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(153, 25);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "جستجوی پشتیبان...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(6, 34);
            this.treeView.Name = "treeView";
            this.treeView.RightToLeftLayout = true;
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(609, 374);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.DoubleClick += new System.EventHandler(this.treeView_DoubleClick);
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnBrowse);
            this.panelCommand.Controls.Add(this.btnRestore);
            this.panelCommand.Controls.Add(this.btnCancel);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(6, 408);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(3);
            this.panelCommand.Size = new System.Drawing.Size(609, 31);
            this.panelCommand.TabIndex = 4;
            this.panelCommand.Tag = "ButtonsPanel";
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(6, 5);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Padding = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.panelTitle.Size = new System.Drawing.Size(609, 29);
            this.panelTitle.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(480, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(123, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "پشتیبان های برنامه:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RestoreBackupForm
            // 
            this.AcceptButton = this.btnRestore;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(621, 444);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.panelCommand);
            this.Controls.Add(this.panelTitle);
            this.Name = "RestoreBackupForm";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Text = "بازگردانی پشتیبان";
            this.Load += new System.EventHandler(this.FormRestore_Load);
            this.panelCommand.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label lblTitle;
        private Njit.Program.Controls.ButtonExtended btnRestore;
        private Njit.Program.Controls.ButtonExtended btnCancel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelCommand;
        private Njit.Program.Controls.ButtonExtended btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}