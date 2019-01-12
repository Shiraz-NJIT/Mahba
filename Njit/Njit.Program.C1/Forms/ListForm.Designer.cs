namespace Njit.Program.ComponentOne.Forms
{
    partial class ListForm
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
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnExit = new Njit.Program.Controls.ButtonExtended();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.mainRibbon = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenuMain = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonConfigToolBarMain = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQatMain = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTabOperations = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroupOperations = new C1.Win.C1Ribbon.RibbonGroup();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnExit);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 463);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.panelCommand.Size = new System.Drawing.Size(792, 29);
            this.panelCommand.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.Location = new System.Drawing.Point(13, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxSearch);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 153);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.panelMain.Size = new System.Drawing.Size(792, 310);
            this.panelMain.TabIndex = 4;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearch.Location = new System.Drawing.Point(10, 3);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(772, 55);
            this.groupBoxSearch.TabIndex = 2;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "جستجو";
            this.groupBoxSearch.Visible = false;
            // 
            // mainRibbon
            // 
            this.mainRibbon.ApplicationMenuHolder = this.ribbonApplicationMenuMain;
            this.mainRibbon.ConfigToolBarHolder = this.ribbonConfigToolBarMain;
            this.mainRibbon.Location = new System.Drawing.Point(0, 0);
            this.mainRibbon.Name = "mainRibbon";
            this.mainRibbon.QatHolder = this.ribbonQatMain;
            this.mainRibbon.Size = new System.Drawing.Size(792, 153);
            this.mainRibbon.Tabs.Add(this.ribbonTabOperations);
            // 
            // ribbonApplicationMenuMain
            // 
            this.ribbonApplicationMenuMain.Enabled = false;
            this.ribbonApplicationMenuMain.Name = "ribbonApplicationMenuMain";
            this.ribbonApplicationMenuMain.Visible = false;
            // 
            // ribbonConfigToolBarMain
            // 
            this.ribbonConfigToolBarMain.Name = "ribbonConfigToolBarMain";
            // 
            // ribbonQatMain
            // 
            this.ribbonQatMain.Name = "ribbonQatMain";
            // 
            // ribbonTabOperations
            // 
            this.ribbonTabOperations.Groups.Add(this.ribbonGroupOperations);
            this.ribbonTabOperations.Name = "ribbonTabOperations";
            this.ribbonTabOperations.Text = "عملیات";
            // 
            // ribbonGroupOperations
            // 
            this.ribbonGroupOperations.Name = "ribbonGroupOperations";
            this.ribbonGroupOperations.Text = "گروه";
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(792, 492);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.mainRibbon);
            this.Controls.Add(this.panelCommand);
            this.Name = "ListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Panel panelCommand;
        protected Njit.Program.Controls.ButtonExtended btnExit;
        protected System.Windows.Forms.Panel panelMain;
        protected C1.Win.C1Ribbon.C1Ribbon mainRibbon;
        protected System.Windows.Forms.GroupBox groupBoxSearch;
        protected C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenuMain;
        protected C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBarMain;
        protected C1.Win.C1Ribbon.RibbonQat ribbonQatMain;
        protected C1.Win.C1Ribbon.RibbonTab ribbonTabOperations;
        protected C1.Win.C1Ribbon.RibbonGroup ribbonGroupOperations;
    }
}