namespace KaiwaProjects
{
    partial class KpImageViewer
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
            DisposeControl();

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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.cbZoom = new System.Windows.Forms.ComboBox();
            this.btnFitToScreen = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.pbFull = new KaiwaProjects.PanelDoubleBuffered();
            this.sbVert = new System.Windows.Forms.VScrollBar();
            this.sbHoriz = new System.Windows.Forms.HScrollBar();
            this.sbPanel = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.pbFull.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoSize = true;
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.cbZoom);
            this.panelMenu.Controls.Add(this.btnFitToScreen);
            this.panelMenu.Controls.Add(this.btnZoomIn);
            this.panelMenu.Controls.Add(this.btnZoomOut);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMenu.Location = new System.Drawing.Point(0, 745);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(960, 23);
            this.panelMenu.TabIndex = 11;
            // 
            // cbZoom
            // 
            this.cbZoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbZoom.FormattingEnabled = true;
            this.cbZoom.Location = new System.Drawing.Point(50, 0);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(883, 21);
            this.cbZoom.TabIndex = 14;
            this.cbZoom.SelectedIndexChanged += new System.EventHandler(this.cbZoom_SelectedIndexChanged);
            this.cbZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbZoom_KeyPress);
            // 
            // btnFitToScreen
            // 
            this.btnFitToScreen.BackColor = System.Drawing.Color.Silver;
            this.btnFitToScreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFitToScreen.Image = global::KaiwaProjects.Properties.Resources.btnFitToScreen;
            this.btnFitToScreen.Location = new System.Drawing.Point(933, 0);
            this.btnFitToScreen.Name = "btnFitToScreen";
            this.btnFitToScreen.Size = new System.Drawing.Size(25, 21);
            this.btnFitToScreen.TabIndex = 13;
            this.btnFitToScreen.UseVisualStyleBackColor = false;
            this.btnFitToScreen.Click += new System.EventHandler(this.btnFitToScreen_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.Silver;
            this.btnZoomIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnZoomIn.Image = global::KaiwaProjects.Properties.Resources.btnZoomIn;
            this.btnZoomIn.Location = new System.Drawing.Point(25, 0);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(25, 21);
            this.btnZoomIn.TabIndex = 12;
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.Silver;
            this.btnZoomOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnZoomOut.Image = global::KaiwaProjects.Properties.Resources.btnZoomOut;
            this.btnZoomOut.Location = new System.Drawing.Point(0, 0);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(25, 21);
            this.btnZoomOut.TabIndex = 11;
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // pbFull
            // 
            this.pbFull.BackColor = System.Drawing.Color.White;
            this.pbFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFull.Controls.Add(this.sbVert);
            this.pbFull.Controls.Add(this.sbHoriz);
            this.pbFull.Controls.Add(this.sbPanel);
            this.pbFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFull.Location = new System.Drawing.Point(0, 0);
            this.pbFull.Name = "pbFull";
            this.pbFull.Size = new System.Drawing.Size(960, 745);
            this.pbFull.TabIndex = 13;
            this.pbFull.Click += new System.EventHandler(this.pbFull_Click);
            this.pbFull.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbFull_DragDrop);
            this.pbFull.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbFull_DragEnter);
            this.pbFull.Paint += new System.Windows.Forms.PaintEventHandler(this.pbFull_Paint);
            this.pbFull.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseDoubleClick);
            this.pbFull.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseDown);
            this.pbFull.MouseEnter += new System.EventHandler(this.pbFull_MouseEnter);
            this.pbFull.MouseLeave += new System.EventHandler(this.pbFull_MouseLeave);
            this.pbFull.MouseHover += new System.EventHandler(this.pbFull_MouseHover);
            this.pbFull.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseMove);
            this.pbFull.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseUp);
            // 
            // sbVert
            // 
            this.sbVert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbVert.Location = new System.Drawing.Point(951, 0);
            this.sbVert.Name = "sbVert";
            this.sbVert.Size = new System.Drawing.Size(17, 727);
            this.sbVert.TabIndex = 0;
            this.sbVert.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbVert_Scroll);
            // 
            // sbHoriz
            // 
            this.sbHoriz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbHoriz.Location = new System.Drawing.Point(0, 726);
            this.sbHoriz.Name = "sbHoriz";
            this.sbHoriz.Size = new System.Drawing.Size(951, 17);
            this.sbHoriz.TabIndex = 1;
            this.sbHoriz.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbHoriz_Scroll);
            // 
            // sbPanel
            // 
            this.sbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbPanel.BackColor = System.Drawing.SystemColors.Info;
            this.sbPanel.Location = new System.Drawing.Point(942, 727);
            this.sbPanel.Name = "sbPanel";
            this.sbPanel.Size = new System.Drawing.Size(16, 16);
            this.sbPanel.TabIndex = 2;
            // 
            // KpImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbFull);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "KpImageViewer";
            this.Size = new System.Drawing.Size(960, 768);
            this.Load += new System.EventHandler(this.KP_ImageViewerV2_Load);
            this.Click += new System.EventHandler(this.KpImageViewer_Click);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.KP_ImageViewerV2_MouseWheel);
            this.Resize += new System.EventHandler(this.KP_ImageViewerV2_Resize);
            this.panelMenu.ResumeLayout(false);
            this.pbFull.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private PanelDoubleBuffered pbFull;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnFitToScreen;
        private System.Windows.Forms.ComboBox cbZoom;
        private System.Windows.Forms.Panel sbPanel;
        private System.Windows.Forms.HScrollBar sbHoriz;
        private System.Windows.Forms.VScrollBar sbVert;
    }
}
