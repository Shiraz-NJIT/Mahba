namespace Njit.Program.Forms
{
    partial class BackupProgress
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
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 34);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "در حال پشتیبان گیری از اطلاعات...";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackingUp
            // 
            this.Angle = 5;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(256, 54);
            this.Controls.Add(this.lblTitle);
            this.DropShadow = false;
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.HidingAnimation = Njit.Program.Forms.PopupForm.PopupAnimations.Blend;
            this.HidingDuration = 300;
            this.Name = "BackingUpForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowingAnimation = Njit.Program.Forms.PopupForm.PopupAnimations.Blend;
            this.ShowingDuration = 300;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
    }
}