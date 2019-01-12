namespace NjitSoftware.View.BaseForms
{
    partial class AlertBase
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "عنوان";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.pictureBoxClose);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(2, 2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(280, 25);
            this.topPanel.TabIndex = 0;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxClose.Image = global::NjitSoftware.Properties.Resources.minimize;
            this.pictureBoxClose.Location = new System.Drawing.Point(253, 0);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(27, 25);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxClose.TabIndex = 0;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(2, 27);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentPanel.Size = new System.Drawing.Size(280, 233);
            this.contentPanel.TabIndex = 1;
            // 
            // AlertBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.topPanel);
            this.HidingAnimation = Njit.Program.Forms.PopupForm.PopupAnimations.None;
            this.Name = "AlertBase";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowingAnimation = Njit.Program.Forms.PopupForm.PopupAnimations.Blend;
            this.ShowingDuration = 300;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.Panel topPanel;
        protected System.Windows.Forms.PictureBox pictureBoxClose;
        protected System.Windows.Forms.Panel contentPanel;
    }
}