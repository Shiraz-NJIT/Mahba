namespace Njit.Program.ElegantProgram.Forms
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
            Elegant.Ui.ThemeSelector themeSelector;
            this.mainRibbon = new Elegant.Ui.Ribbon();
            this.mainApplicationMenu = new Elegant.Ui.ApplicationMenu(this.components);
            this.ribbonTabPageExit = new Elegant.Ui.RibbonTabPage();
            this.ribbonGroupExitLogout = new Elegant.Ui.RibbonGroup();
            this.btnLogout = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.btnExit = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.ribbonGroupShutdown = new Elegant.Ui.RibbonGroup();
            this.btnShutdown = new Njit.Program.ElegantProgram.Controls.ElegantButton();
            this.formFrameSkinner = new Elegant.Ui.FormFrameSkinner();
            this.statusBar = new Elegant.Ui.StatusBar();
            this.statusBarNotificationsAreaMain = new Elegant.Ui.StatusBarNotificationsArea();
            this.statusBarPaneNotifications = new Elegant.Ui.StatusBarPane();
            this.statusBarControlsAreaMain = new Elegant.Ui.StatusBarControlsArea();
            this.statusBarPaneControls = new Elegant.Ui.StatusBarPane();
            this.programTitleLabel = new Elegant.Ui.Label();
            this.lblProgramTitle = new Elegant.Ui.Label();
            this.userLabel = new Elegant.Ui.Label();
            this.lblUser = new Elegant.Ui.Label();
            this.dateLabel = new Elegant.Ui.Label();
            this.lblDate = new Elegant.Ui.Label();
            this.timeLabel = new Elegant.Ui.Label();
            this.lblTime = new Elegant.Ui.Label();
            themeSelector = new Elegant.Ui.ThemeSelector(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainApplicationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageExit)).BeginInit();
            this.ribbonTabPageExit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroupExitLogout)).BeginInit();
            this.ribbonGroupExitLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroupShutdown)).BeginInit();
            this.ribbonGroupShutdown.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.statusBarNotificationsAreaMain.SuspendLayout();
            this.statusBarControlsAreaMain.SuspendLayout();
            this.statusBarPaneControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRibbon
            // 
            this.mainRibbon.ApplicationButtonPopup = this.mainApplicationMenu;
            this.mainRibbon.CurrentTabPage = this.ribbonTabPageExit;
            this.mainRibbon.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainRibbon.Id = "6ffc6202-d433-4821-913f-2fb48e329efc";
            this.mainRibbon.Location = new System.Drawing.Point(0, 0);
            this.mainRibbon.Name = "mainRibbon";
            this.mainRibbon.QuickAccessToolbarDropDownVisible = false;
            this.mainRibbon.Size = new System.Drawing.Size(892, 150);
            this.mainRibbon.TabIndex = 0;
            this.mainRibbon.TabPages.AddRange(new Elegant.Ui.RibbonTabPage[] {
            this.ribbonTabPageExit});
            // 
            // mainApplicationMenu
            // 
            this.mainApplicationMenu.ContentMinimumHeight = 0;
            this.mainApplicationMenu.ExitButtonCommandName = "ExitCommand";
            this.mainApplicationMenu.ExitButtonText = "خروج";
            this.mainApplicationMenu.KeepPopupsWithOffsetPlacementWithinPlacementArea = false;
            this.mainApplicationMenu.OptionsButtonCommandName = "ProgramSettingShowCommand";
            this.mainApplicationMenu.OptionsButtonText = "تنظیمات برنامه";
            this.mainApplicationMenu.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
            this.mainApplicationMenu.Size = new System.Drawing.Size(100, 100);
            // 
            // ribbonTabPageExit
            // 
            this.ribbonTabPageExit.Controls.Add(this.ribbonGroupExitLogout);
            this.ribbonTabPageExit.Controls.Add(this.ribbonGroupShutdown);
            this.ribbonTabPageExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonTabPageExit.KeyTip = "خ";
            this.ribbonTabPageExit.Location = new System.Drawing.Point(0, 0);
            this.ribbonTabPageExit.Name = "ribbonTabPageExit";
            this.ribbonTabPageExit.Size = new System.Drawing.Size(892, 96);
            this.ribbonTabPageExit.TabIndex = 0;
            this.ribbonTabPageExit.Text = "خروج";
            // 
            // ribbonGroupExitLogout
            // 
            this.ribbonGroupExitLogout.Controls.Add(this.btnLogout);
            this.ribbonGroupExitLogout.Controls.Add(this.btnExit);
            this.ribbonGroupExitLogout.Location = new System.Drawing.Point(1, 1);
            this.ribbonGroupExitLogout.Name = "ribbonGroupExitLogout";
            this.ribbonGroupExitLogout.Size = new System.Drawing.Size(192, 91);
            this.ribbonGroupExitLogout.TabIndex = 0;
            this.ribbonGroupExitLogout.Text = "     خروج از برنامه و خروج کاربر     ";
            // 
            // btnLogout
            // 
            this.btnLogout.AllowCheckAccessPermission = false;
            this.btnLogout.Id = "ccd977c5-f551-4c01-b50c-b0abd2e1f742";
            this.btnLogout.KeyTip = "1";
            this.btnLogout.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.exit_user)});
            this.btnLogout.Location = new System.Drawing.Point(52, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(42, 69);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "خروج کاربر";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.AllowCheckAccessPermission = false;
            this.btnExit.Id = "1782fe3d-5f8e-4957-be21-2aec23d1bfce";
            this.btnExit.KeyTip = "2";
            this.btnExit.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.exit)});
            this.btnExit.Location = new System.Drawing.Point(96, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(42, 69);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "خروج از برنامه";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ribbonGroupShutdown
            // 
            this.ribbonGroupShutdown.Controls.Add(this.btnShutdown);
            this.ribbonGroupShutdown.Location = new System.Drawing.Point(193, 1);
            this.ribbonGroupShutdown.Name = "ribbonGroupShutdown";
            this.ribbonGroupShutdown.Size = new System.Drawing.Size(127, 91);
            this.ribbonGroupShutdown.TabIndex = 1;
            this.ribbonGroupShutdown.Text = "     خاموش کردن     ";
            // 
            // btnShutdown
            // 
            this.btnShutdown.AllowCheckAccessPermission = false;
            this.btnShutdown.Id = "5ff7ee72-2e41-40d1-8867-97fe7c6d298c";
            this.btnShutdown.KeyTip = "3";
            this.btnShutdown.LargeImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Njit.Program.ElegantProgram.Properties.Resources.shutdown)});
            this.btnShutdown.Location = new System.Drawing.Point(27, 2);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(71, 69);
            this.btnShutdown.TabIndex = 0;
            this.btnShutdown.Text = "خاموش کردن سیستم";
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // formFrameSkinner
            // 
            this.formFrameSkinner.Form = this;
            // 
            // statusBar
            // 
            this.statusBar.Controls.Add(this.statusBarNotificationsAreaMain);
            this.statusBar.Controls.Add(this.statusBarControlsAreaMain);
            this.statusBar.ControlsArea = this.statusBarControlsAreaMain;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Location = new System.Drawing.Point(0, 577);
            this.statusBar.Name = "statusBar";
            this.statusBar.NotificationsArea = this.statusBarNotificationsAreaMain;
            this.statusBar.Size = new System.Drawing.Size(892, 22);
            this.statusBar.TabIndex = 1;
            // 
            // statusBarNotificationsAreaMain
            // 
            this.statusBarNotificationsAreaMain.Controls.Add(this.statusBarPaneNotifications);
            this.statusBarNotificationsAreaMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBarNotificationsAreaMain.Location = new System.Drawing.Point(0, 0);
            this.statusBarNotificationsAreaMain.MaximumSize = new System.Drawing.Size(0, 22);
            this.statusBarNotificationsAreaMain.MinimumSize = new System.Drawing.Size(0, 22);
            this.statusBarNotificationsAreaMain.Name = "statusBarNotificationsAreaMain";
            this.statusBarNotificationsAreaMain.Size = new System.Drawing.Size(138, 22);
            this.statusBarNotificationsAreaMain.TabIndex = 1;
            // 
            // statusBarPaneNotifications
            // 
            this.statusBarPaneNotifications.Location = new System.Drawing.Point(0, 0);
            this.statusBarPaneNotifications.MaximumSize = new System.Drawing.Size(0, 22);
            this.statusBarPaneNotifications.MinimumSize = new System.Drawing.Size(0, 22);
            this.statusBarPaneNotifications.Name = "statusBarPaneNotifications";
            this.statusBarPaneNotifications.Size = new System.Drawing.Size(20, 22);
            this.statusBarPaneNotifications.TabIndex = 0;
            // 
            // statusBarControlsAreaMain
            // 
            this.statusBarControlsAreaMain.Controls.Add(this.statusBarPaneControls);
            this.statusBarControlsAreaMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.statusBarControlsAreaMain.Location = new System.Drawing.Point(138, 0);
            this.statusBarControlsAreaMain.MaximumSize = new System.Drawing.Size(0, 22);
            this.statusBarControlsAreaMain.MinimumSize = new System.Drawing.Size(0, 22);
            this.statusBarControlsAreaMain.Name = "statusBarControlsAreaMain";
            this.statusBarControlsAreaMain.Size = new System.Drawing.Size(754, 22);
            this.statusBarControlsAreaMain.TabIndex = 0;
            // 
            // statusBarPaneControls
            // 
            this.statusBarPaneControls.Controls.Add(this.programTitleLabel);
            this.statusBarPaneControls.Controls.Add(this.lblProgramTitle);
            this.statusBarPaneControls.Controls.Add(this.userLabel);
            this.statusBarPaneControls.Controls.Add(this.lblUser);
            this.statusBarPaneControls.Controls.Add(this.dateLabel);
            this.statusBarPaneControls.Controls.Add(this.lblDate);
            this.statusBarPaneControls.Controls.Add(this.timeLabel);
            this.statusBarPaneControls.Controls.Add(this.lblTime);
            this.statusBarPaneControls.Location = new System.Drawing.Point(0, 0);
            this.statusBarPaneControls.MaximumSize = new System.Drawing.Size(0, 22);
            this.statusBarPaneControls.MinimumSize = new System.Drawing.Size(0, 22);
            this.statusBarPaneControls.Name = "statusBarPaneControls";
            this.statusBarPaneControls.Size = new System.Drawing.Size(702, 22);
            this.statusBarPaneControls.TabIndex = 0;
            this.statusBarPaneControls.WrapContents = false;
            // 
            // programTitleLabel
            // 
            this.programTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.programTitleLabel.Location = new System.Drawing.Point(5, 4);
            this.programTitleLabel.Name = "programTitleLabel";
            this.programTitleLabel.Size = new System.Drawing.Size(56, 14);
            this.programTitleLabel.TabIndex = 0;
            this.programTitleLabel.Text = "نام شرکت:";
            // 
            // lblProgramTitle
            // 
            this.lblProgramTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblProgramTitle.Location = new System.Drawing.Point(67, 4);
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.Size = new System.Drawing.Size(120, 14);
            this.lblProgramTitle.TabIndex = 1;
            this.lblProgramTitle.Text = "                              ";
            // 
            // userLabel
            // 
            this.userLabel.BackColor = System.Drawing.Color.Transparent;
            this.userLabel.Location = new System.Drawing.Point(193, 4);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(26, 14);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "کاربر:";
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Location = new System.Drawing.Point(225, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(120, 14);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "                              ";
            // 
            // dateLabel
            // 
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.Location = new System.Drawing.Point(351, 4);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(26, 14);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "تاریخ:";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Location = new System.Drawing.Point(383, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(120, 14);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "                              ";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Location = new System.Drawing.Point(509, 4);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(38, 14);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = "ساعت:";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Location = new System.Drawing.Point(553, 4);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(120, 14);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "                              ";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(892, 599);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainRibbon);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainApplicationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageExit)).EndInit();
            this.ribbonTabPageExit.ResumeLayout(false);
            this.ribbonTabPageExit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroupExitLogout)).EndInit();
            this.ribbonGroupExitLogout.ResumeLayout(false);
            this.ribbonGroupExitLogout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonGroupShutdown)).EndInit();
            this.ribbonGroupShutdown.ResumeLayout(false);
            this.ribbonGroupShutdown.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.statusBarNotificationsAreaMain.ResumeLayout(false);
            this.statusBarNotificationsAreaMain.PerformLayout();
            this.statusBarControlsAreaMain.ResumeLayout(false);
            this.statusBarControlsAreaMain.PerformLayout();
            this.statusBarPaneControls.ResumeLayout(false);
            this.statusBarPaneControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Elegant.Ui.Ribbon mainRibbon;
        protected Elegant.Ui.FormFrameSkinner formFrameSkinner;
        protected Elegant.Ui.RibbonTabPage ribbonTabPageExit;
        protected Elegant.Ui.RibbonGroup ribbonGroupExitLogout;
        protected Njit.Program.ElegantProgram.Controls.ElegantButton btnLogout;
        protected Njit.Program.ElegantProgram.Controls.ElegantButton btnExit;
        protected Elegant.Ui.RibbonGroup ribbonGroupShutdown;
        protected Njit.Program.ElegantProgram.Controls.ElegantButton btnShutdown;
        protected Elegant.Ui.ApplicationMenu mainApplicationMenu;
        protected Elegant.Ui.StatusBarNotificationsArea statusBarNotificationsAreaMain;
        protected Elegant.Ui.StatusBarPane statusBarPaneNotifications;
        protected Elegant.Ui.StatusBarControlsArea statusBarControlsAreaMain;
        protected Elegant.Ui.StatusBarPane statusBarPaneControls;
        protected Elegant.Ui.Label programTitleLabel;
        protected Elegant.Ui.Label lblProgramTitle;
        protected Elegant.Ui.Label userLabel;
        protected Elegant.Ui.Label lblUser;
        protected Elegant.Ui.Label dateLabel;
        protected Elegant.Ui.Label lblDate;
        protected Elegant.Ui.Label timeLabel;
        protected Elegant.Ui.Label lblTime;
        public Elegant.Ui.StatusBar statusBar;

    }
}