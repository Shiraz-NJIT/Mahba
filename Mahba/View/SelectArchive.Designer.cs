namespace NjitSoftware.View
{
    partial class SelectArchive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectArchive));
            this.archiveTreeView = new NjitSoftware.View.Controls.ArchiveTreeView();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnSelect = new Njit.Program.Controls.ButtonExtended();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.contentPanel.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Size = new System.Drawing.Size(359, 35);
            this.lblTitle.Text = "انتخاب و مدیریت بایگانی ها";
            // 
            // topPanel
            // 
            this.topPanel.Size = new System.Drawing.Size(386, 35);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Location = new System.Drawing.Point(359, 0);
            this.pictureBoxClose.Size = new System.Drawing.Size(27, 35);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.archiveTreeView);
            this.contentPanel.Controls.Add(this.panelCommand);
            this.contentPanel.Location = new System.Drawing.Point(2, 37);
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.contentPanel.Size = new System.Drawing.Size(386, 431);
            // 
            // archiveTreeView
            // 
            this.archiveTreeView.AllowDrop = true;
            this.archiveTreeView.ArchiveGroupIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.ArchiveGroupIcon")));
            this.archiveTreeView.ArchiveIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.ArchiveIcon")));
            this.archiveTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.archiveTreeView.FilterIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.FilterIcon")));
            this.archiveTreeView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.archiveTreeView.GroupByIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.GroupByIcon")));
            this.archiveTreeView.HideSelection = false;
            this.archiveTreeView.ImageIndex = 0;
            this.archiveTreeView.LabelEdit = true;
            this.archiveTreeView.Location = new System.Drawing.Point(10, 10);
            this.archiveTreeView.Name = "archiveTreeView";
            this.archiveTreeView.NodeIcon = ((System.Drawing.Image)(resources.GetObject("archiveTreeView.NodeIcon")));
            this.archiveTreeView.SelectedImageIndex = 0;
            this.archiveTreeView.Size = new System.Drawing.Size(366, 392);
            this.archiveTreeView.TabIndex = 0;
            this.archiveTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.archiveTreeView_AfterSelect);
            this.archiveTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.archiveTreeView_NodeMouseDoubleClick);
            // 
            // panelCommand
            // 
            this.panelCommand.BackColor = System.Drawing.Color.Transparent;
            this.panelCommand.Controls.Add(this.btnSelect);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(10, 402);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(3);
            this.panelCommand.Size = new System.Drawing.Size(366, 29);
            this.panelCommand.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelect.Location = new System.Drawing.Point(288, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // SelectArchive
            // 
            this.Angle = 1;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(390, 470);
            this.Name = "SelectArchive";
            this.Opacity = 0.8D;
            this.ShowingAnimation = Njit.Program.Forms.PopupForm.PopupAnimations.None;
            this.Text = "انتخاب و مدیریت بایگانی ها";
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ArchiveTreeView archiveTreeView;
        private System.Windows.Forms.Panel panelCommand;
        private Njit.Program.Controls.ButtonExtended btnSelect;

    }
}