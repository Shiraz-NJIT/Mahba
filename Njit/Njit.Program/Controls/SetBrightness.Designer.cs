namespace Njit.Program.Controls
{
    partial class SetBrightness
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar.Location = new System.Drawing.Point(0, 0);
            this.trackBar.Maximum = 255;
            this.trackBar.Minimum = -255;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(373, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.TickFrequency = 10;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReset.Location = new System.Drawing.Point(279, 51);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(91, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "تنظیم مجدد";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // SetBrightness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.trackBar);
            this.Name = "SetBrightness";
            this.Size = new System.Drawing.Size(373, 81);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button btnReset;
    }
}
