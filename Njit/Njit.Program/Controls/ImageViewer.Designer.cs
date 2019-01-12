namespace Njit.Program.Controls
{
    partial class ImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
            this.panelPageNavigation = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelDescription = new System.Windows.Forms.ToolStripLabel();
            this.imageBox = new Njit.Program.Controls.ImageBox();
            this.toolStripButtonNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrevious = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.btnBrightness = new System.Windows.Forms.ToolStripButton();
            this.btnContrast = new System.Windows.Forms.ToolStripButton();
            this.btnGamma = new System.Windows.Forms.ToolStripButton();
            this.btnPagePrev = new Njit.Program.Controls.ButtonExtended();
            this.btnPageNext = new Njit.Program.Controls.ButtonExtended();
            this.panelPageNavigation.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPageNavigation
            // 
            this.panelPageNavigation.Controls.Add(this.btnPagePrev);
            this.panelPageNavigation.Controls.Add(this.btnPageNext);
            this.panelPageNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPageNavigation.Location = new System.Drawing.Point(0, 375);
            this.panelPageNavigation.Name = "panelPageNavigation";
            this.panelPageNavigation.Size = new System.Drawing.Size(403, 25);
            this.panelPageNavigation.TabIndex = 2;
            this.panelPageNavigation.Visible = false;
            this.panelPageNavigation.VisibleChanged += new System.EventHandler(this.panelPageNavigation_VisibleChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNext,
            this.toolStripButtonPrevious,
            this.toolStripSeparator1,
            this.toolStripButtonRotateRight,
            this.toolStripButtonRotateLeft,
            this.toolStripSeparator2,
            this.toolStripButtonDelete,
            this.toolStripButtonClear,
            this.toolStripSeparator3,
            this.btnBrightness,
            this.btnContrast,
            this.btnGamma,
            this.toolStripLabelDescription});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip.Size = new System.Drawing.Size(403, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelDescription
            // 
            this.toolStripLabelDescription.Name = "toolStripLabelDescription";
            this.toolStripLabelDescription.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabelDescription.Text = "          ";
            // 
            // imageBox
            // 
            this.imageBox.AutoScroll = true;
            this.imageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox.Location = new System.Drawing.Point(0, 25);
            this.imageBox.Name = "imageBox";
            this.imageBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.imageBox.Size = new System.Drawing.Size(403, 350);
            this.imageBox.TabIndex = 1;
            // 
            // toolStripButtonNext
            // 
            this.toolStripButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNext.Image = global::Njit.Program.Properties.Resources.next16;
            this.toolStripButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNext.Name = "toolStripButtonNext";
            this.toolStripButtonNext.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNext.Text = "بعدی";
            this.toolStripButtonNext.Click += new System.EventHandler(this.toolStripButtonNext_Click);
            // 
            // toolStripButtonPrevious
            // 
            this.toolStripButtonPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrevious.Image = global::Njit.Program.Properties.Resources.previous16;
            this.toolStripButtonPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrevious.Name = "toolStripButtonPrevious";
            this.toolStripButtonPrevious.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrevious.Text = "قبلی";
            this.toolStripButtonPrevious.Click += new System.EventHandler(this.toolStripButtonPrevious_Click);
            // 
            // toolStripButtonRotateRight
            // 
            this.toolStripButtonRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateRight.Image = global::Njit.Program.Properties.Resources.RotateRight;
            this.toolStripButtonRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateRight.Name = "toolStripButtonRotateRight";
            this.toolStripButtonRotateRight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotateRight.Text = "چرخش به راست";
            this.toolStripButtonRotateRight.Click += new System.EventHandler(this.toolStripButtonRotateRight_Click);
            // 
            // toolStripButtonRotateLeft
            // 
            this.toolStripButtonRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateLeft.Image = global::Njit.Program.Properties.Resources.RotateLeft;
            this.toolStripButtonRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRotateLeft.Name = "toolStripButtonRotateLeft";
            this.toolStripButtonRotateLeft.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRotateLeft.Text = "چرخش به چپ";
            this.toolStripButtonRotateLeft.Click += new System.EventHandler(this.toolStripButtonRotateLeft_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = global::Njit.Program.Properties.Resources.delete_small;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "حذف";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = global::Njit.Program.Properties.Resources.Clear;
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClear.Text = "حذف همه";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // btnBrightness
            // 
            this.btnBrightness.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBrightness.Image = global::Njit.Program.Properties.Resources.brightness;
            this.btnBrightness.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBrightness.Name = "btnBrightness";
            this.btnBrightness.Size = new System.Drawing.Size(23, 22);
            this.btnBrightness.Text = "روشنایی";
            this.btnBrightness.Click += new System.EventHandler(this.btnBrightness_Click);
            // 
            // btnContrast
            // 
            this.btnContrast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnContrast.Image = global::Njit.Program.Properties.Resources.contrast;
            this.btnContrast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(23, 22);
            this.btnContrast.Text = "کنتراست";
            this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
            // 
            // btnGamma
            // 
            this.btnGamma.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGamma.Image = ((System.Drawing.Image)(resources.GetObject("btnGamma.Image")));
            this.btnGamma.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGamma.Name = "btnGamma";
            this.btnGamma.Size = new System.Drawing.Size(23, 22);
            this.btnGamma.Text = "گاما";
            this.btnGamma.Visible = false;
            this.btnGamma.Click += new System.EventHandler(this.btnGamma_Click);
            // 
            // btnPagePrev
            // 
            this.btnPagePrev.Image = global::Njit.Program.Properties.Resources.previous16;
            this.btnPagePrev.Location = new System.Drawing.Point(182, 0);
            this.btnPagePrev.Name = "btnPagePrev";
            this.btnPagePrev.Size = new System.Drawing.Size(25, 25);
            this.btnPagePrev.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnPagePrev, "صفحه قبل");
            this.btnPagePrev.UseVisualStyleBackColor = true;
            this.btnPagePrev.Click += new System.EventHandler(this.btnPagePrev_Click);
            // 
            // btnPageNext
            // 
            this.btnPageNext.Image = global::Njit.Program.Properties.Resources.next16;
            this.btnPageNext.Location = new System.Drawing.Point(206, 0);
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Size = new System.Drawing.Size(25, 25);
            this.btnPageNext.TabIndex = 0;
            this.toolTip.SetToolTip(this.btnPageNext, "صفحه بعد");
            this.btnPageNext.UseVisualStyleBackColor = true;
            this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
            // 
            // ImageViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.panelPageNavigation);
            this.Name = "ImageViewer";
            this.Size = new System.Drawing.Size(403, 400);
            this.panelPageNavigation.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageBox imageBox;
        private ButtonExtended btnPagePrev;
        private ButtonExtended btnPageNext;
        private System.Windows.Forms.Panel panelPageNavigation;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonNext;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrevious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateLeft;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabelDescription;
        private System.Windows.Forms.ToolStripButton btnBrightness;
        private System.Windows.Forms.ToolStripButton btnContrast;
        private System.Windows.Forms.ToolStripButton btnGamma;
    }
}
