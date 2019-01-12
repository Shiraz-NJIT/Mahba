namespace NjitSoftware.View.Controls
{
    partial class ArchiveDiskSpaceView
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
            this.lblArchiveName = new System.Windows.Forms.Label();
            this.diskSpaceProgress = new Njit.Program.Controls.DiskSpaceProgress();
            this.lblSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblArchiveName
            // 
            this.lblArchiveName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblArchiveName.Location = new System.Drawing.Point(0, 0);
            this.lblArchiveName.Name = "lblArchiveName";
            this.lblArchiveName.Size = new System.Drawing.Size(200, 28);
            this.lblArchiveName.TabIndex = 0;
            this.lblArchiveName.Text = "نام بایگانی";
            this.lblArchiveName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // diskSpaceProgress
            // 
            this.diskSpaceProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.diskSpaceProgress.Location = new System.Drawing.Point(0, 28);
            this.diskSpaceProgress.Name = "diskSpaceProgress";
            this.diskSpaceProgress.Size = new System.Drawing.Size(200, 14);
            this.diskSpaceProgress.TabIndex = 1;
            // 
            // lblSize
            // 
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.ForeColor = System.Drawing.Color.DarkGray;
            this.lblSize.Location = new System.Drawing.Point(0, 42);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(200, 28);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "حجم";
            // 
            // ArchiveDiskSpaceView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.diskSpaceProgress);
            this.Controls.Add(this.lblArchiveName);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "ArchiveDiskSpaceView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(200, 70);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblArchiveName;
        private Njit.Program.Controls.DiskSpaceProgress diskSpaceProgress;
        private System.Windows.Forms.Label lblSize;
    }
}
