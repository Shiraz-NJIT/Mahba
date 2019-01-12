namespace Njit.Program.ComponentOne.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.mainRibbon = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenuMain = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonConfigToolBarMain = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQatMain = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTabExit = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroupExit = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnLogout = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparatorExitButtons = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnExit = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonGroupShutdown = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnShutdown = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.statusBar = new C1.Win.C1Ribbon.C1StatusBar();
            this.ribbonLabelProgramTitle = new C1.Win.C1Ribbon.RibbonLabel();
            this.lblProgramTitle = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonLabelUser = new C1.Win.C1Ribbon.RibbonLabel();
            this.lblUser = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonLabelDate = new C1.Win.C1Ribbon.RibbonLabel();
            this.lblDate = new C1.Win.C1Ribbon.RibbonLabel();
            this.ribbonLabelTime = new C1.Win.C1Ribbon.RibbonLabel();
            this.lblTime = new C1.Win.C1Ribbon.RibbonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timerDateTime
            // 
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // mainRibbon
            // 
            this.mainRibbon.ApplicationMenuHolder = this.ribbonApplicationMenuMain;
            this.mainRibbon.ConfigToolBarHolder = this.ribbonConfigToolBarMain;
            this.mainRibbon.Location = new System.Drawing.Point(0, 0);
            this.mainRibbon.Name = "mainRibbon";
            this.mainRibbon.QatHolder = this.ribbonQatMain;
            this.mainRibbon.Size = new System.Drawing.Size(892, 153);
            this.mainRibbon.Tabs.Add(this.ribbonTabExit);
            // 
            // ribbonApplicationMenuMain
            // 
            this.ribbonApplicationMenuMain.Name = "ribbonApplicationMenuMain";
            // 
            // ribbonConfigToolBarMain
            // 
            this.ribbonConfigToolBarMain.Name = "ribbonConfigToolBarMain";
            // 
            // ribbonQatMain
            // 
            this.ribbonQatMain.Name = "ribbonQatMain";
            // 
            // ribbonTabExit
            // 
            this.ribbonTabExit.Groups.Add(this.ribbonGroupExit);
            this.ribbonTabExit.Groups.Add(this.ribbonGroupShutdown);
            this.ribbonTabExit.Name = "ribbonTabExit";
            this.ribbonTabExit.Text = "خروج";
            // 
            // ribbonGroupExit
            // 
            this.ribbonGroupExit.Items.Add(this.btnLogout);
            this.ribbonGroupExit.Items.Add(this.ribbonSeparatorExitButtons);
            this.ribbonGroupExit.Items.Add(this.btnExit);
            this.ribbonGroupExit.Name = "ribbonGroupExit";
            this.ribbonGroupExit.Text = "     خروج از برنامه و خروج کاربر     ";
            // 
            // btnLogout
            // 
            this.btnLogout.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.exit_user;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.SmallImage")));
            this.btnLogout.Text = "خروج کاربر";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ribbonSeparatorExitButtons
            // 
            this.ribbonSeparatorExitButtons.Name = "ribbonSeparatorExitButtons";
            // 
            // btnExit
            // 
            this.btnExit.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.exit;
            this.btnExit.Name = "btnExit";
            this.btnExit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExit.SmallImage")));
            this.btnExit.Text = "خروج از برنامه";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ribbonGroupShutdown
            // 
            this.ribbonGroupShutdown.Items.Add(this.btnShutdown);
            this.ribbonGroupShutdown.Name = "ribbonGroupShutdown";
            this.ribbonGroupShutdown.Text = "     خاموش کردن     ";
            // 
            // btnShutdown
            // 
            this.btnShutdown.LargeImage = global::Njit.Program.ComponentOne.Properties.Resources.shutdown;
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnShutdown.SmallImage")));
            this.btnShutdown.Text = "خاموش کردن سیستم";
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // statusBar
            // 
            this.statusBar.LeftPaneItems.Add(this.ribbonLabelProgramTitle);
            this.statusBar.LeftPaneItems.Add(this.lblProgramTitle);
            this.statusBar.LeftPaneItems.Add(this.ribbonLabelUser);
            this.statusBar.LeftPaneItems.Add(this.lblUser);
            this.statusBar.LeftPaneItems.Add(this.ribbonLabelDate);
            this.statusBar.LeftPaneItems.Add(this.lblDate);
            this.statusBar.LeftPaneItems.Add(this.ribbonLabelTime);
            this.statusBar.LeftPaneItems.Add(this.lblTime);
            this.statusBar.Location = new System.Drawing.Point(0, 571);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(892, 23);
            // 
            // ribbonLabelProgramTitle
            // 
            this.ribbonLabelProgramTitle.Name = "ribbonLabelProgramTitle";
            this.ribbonLabelProgramTitle.Text = "نام شرکت:";
            // 
            // lblProgramTitle
            // 
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.Text = "                              ";
            // 
            // ribbonLabelUser
            // 
            this.ribbonLabelUser.Name = "ribbonLabelUser";
            this.ribbonLabelUser.Text = "کاربر:";
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Text = "                              ";
            // 
            // ribbonLabelDate
            // 
            this.ribbonLabelDate.Name = "ribbonLabelDate";
            this.ribbonLabelDate.Text = "تاریخ:";
            // 
            // lblDate
            // 
            this.lblDate.Name = "lblDate";
            this.lblDate.Text = "                              ";
            // 
            // ribbonLabelTime
            // 
            this.ribbonLabelTime.Name = "ribbonLabelTime";
            this.ribbonLabelTime.Text = "ساعت:";
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "                              ";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(892, 594);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainRibbon);
            this.KeyPreview = true;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Timer timerDateTime;
        protected C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenuMain;
        protected C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBarMain;
        protected C1.Win.C1Ribbon.RibbonQat ribbonQatMain;
        protected C1.Win.C1Ribbon.RibbonTab ribbonTabExit;
        protected C1.Win.C1Ribbon.RibbonGroup ribbonGroupExit;
        protected Controls.RibbonButton btnLogout;
        protected C1.Win.C1Ribbon.RibbonSeparator ribbonSeparatorExitButtons;
        protected Controls.RibbonButton btnExit;
        protected C1.Win.C1Ribbon.RibbonGroup ribbonGroupShutdown;
        protected Controls.RibbonButton btnShutdown;
        protected C1.Win.C1Ribbon.RibbonLabel ribbonLabelProgramTitle;
        protected C1.Win.C1Ribbon.RibbonLabel lblProgramTitle;
        protected C1.Win.C1Ribbon.RibbonLabel ribbonLabelUser;
        protected C1.Win.C1Ribbon.RibbonLabel lblUser;
        protected C1.Win.C1Ribbon.RibbonLabel ribbonLabelDate;
        protected C1.Win.C1Ribbon.RibbonLabel lblDate;
        protected C1.Win.C1Ribbon.RibbonLabel ribbonLabelTime;
        protected C1.Win.C1Ribbon.RibbonLabel lblTime;
        public C1.Win.C1Ribbon.C1Ribbon mainRibbon;
        public C1.Win.C1Ribbon.C1StatusBar statusBar;
    }
}