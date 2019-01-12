namespace NjitSoftware.View
{
    partial class ImageView
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
            this.mhR_ImageView1 = new Njit.ImageView.MHR_ImageView();
            this.SuspendLayout();
            // 
            // mhR_ImageView1
            // 
            this.mhR_ImageView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.mhR_ImageView1.cmTilte = -1;
            this.mhR_ImageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mhR_ImageView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mhR_ImageView1.GifAnimation = false;
            this.mhR_ImageView1.GifFPS = 15D;
            this.mhR_ImageView1.Image = null;
            this.mhR_ImageView1.Location = new System.Drawing.Point(0, 0);
            this.mhR_ImageView1.MenuColor = System.Drawing.Color.LightSteelBlue;
            this.mhR_ImageView1.MenuPanelColor = System.Drawing.Color.LightSteelBlue;
            this.mhR_ImageView1.MinimumSize = new System.Drawing.Size(960, 768);
            this.mhR_ImageView1.MyWarning = "";
            this.mhR_ImageView1.Name = "mhR_ImageView1";
            this.mhR_ImageView1.NavigationPanelColor = System.Drawing.Color.LightSteelBlue;
            this.mhR_ImageView1.NavigationTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mhR_ImageView1.OpenButton = false;
            this.mhR_ImageView1.PerssonelNumber = "";
            this.mhR_ImageView1.PreviewButton = true;
            this.mhR_ImageView1.PreviewPanelColor = System.Drawing.Color.LightSteelBlue;
            this.mhR_ImageView1.PreviewText = "Preview";
            this.mhR_ImageView1.PreviewTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mhR_ImageView1.Rotation = 0;
            this.mhR_ImageView1.Scrollbars = false;
            this.mhR_ImageView1.ShowPreview = true;
            this.mhR_ImageView1.Size = new System.Drawing.Size(960, 768);
            this.mhR_ImageView1.TabIndex = 0;
            this.mhR_ImageView1.TextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mhR_ImageView1.Zoom = 100D;
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 729);
            this.Controls.Add(this.mhR_ImageView1);
            this.Name = "ImageView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشاهده سند";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ImageView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.ImageView.MHR_ImageView mhR_ImageView1;




































    }
}