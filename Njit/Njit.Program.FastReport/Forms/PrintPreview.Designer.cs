namespace Njit.Program.FastReportExtensions.Forms
{
    partial class PrintPreview
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
            this.previewControl = new FastReport.Preview.PreviewControl();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 482);
            this.panelCommand.Size = new System.Drawing.Size(784, 29);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.previewControl);
            this.panelMain.Size = new System.Drawing.Size(784, 482);
            // 
            // previewControl
            // 
            this.previewControl.AutoSize = true;
            this.previewControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl.FastScrolling = true;
            this.previewControl.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl.Location = new System.Drawing.Point(10, 3);
            this.previewControl.Name = "previewControl";
            this.previewControl.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl.Size = new System.Drawing.Size(764, 476);
            this.previewControl.TabIndex = 0;
            this.previewControl.UIStyle = FastReport.Utils.UIStyle.Office2003;
            // 
            // PrintPreview
            // 
            this.AllowCheckAccessPermission = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Name = "PrintPreview";
            this.Text = "پیشنمایش چاپ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public FastReport.Preview.PreviewControl previewControl;

    }
}