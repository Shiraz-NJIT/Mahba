namespace Njit.Program.ElegantProgram.Forms
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
            this.components = new System.ComponentModel.Container();
            Elegant.Ui.ThemeSelector themeSelector;
            this.mainRibbon = new Elegant.Ui.Ribbon();
            this.ribbonTabPageCommand = new Elegant.Ui.RibbonTabPage();
            this.formFrameSkinner = new Elegant.Ui.FormFrameSkinner();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            themeSelector = new Elegant.Ui.ThemeSelector(this.components);
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageCommand)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 467);
            this.panelCommand.Size = new System.Drawing.Size(792, 29);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxSearch);
            this.panelMain.Location = new System.Drawing.Point(0, 150);
            this.panelMain.Size = new System.Drawing.Size(792, 317);
            // 
            // mainRibbon
            // 
            this.mainRibbon.ApplicationButtonVisible = false;
            this.mainRibbon.CurrentTabPage = this.ribbonTabPageCommand;
            this.mainRibbon.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainRibbon.Id = "d58fa35c-041a-4133-85d3-5d75d1d301da";
            this.mainRibbon.Location = new System.Drawing.Point(0, 0);
            this.mainRibbon.Name = "mainRibbon";
            this.mainRibbon.QuickAccessToolbarDropDownVisible = false;
            this.mainRibbon.Size = new System.Drawing.Size(792, 150);
            this.mainRibbon.TabIndex = 0;
            this.mainRibbon.TabPages.AddRange(new Elegant.Ui.RibbonTabPage[] {
            this.ribbonTabPageCommand});
            // 
            // ribbonTabPageCommand
            // 
            this.ribbonTabPageCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonTabPageCommand.KeyTip = null;
            this.ribbonTabPageCommand.Location = new System.Drawing.Point(0, 0);
            this.ribbonTabPageCommand.Name = "ribbonTabPageCommand";
            this.ribbonTabPageCommand.Size = new System.Drawing.Size(792, 96);
            this.ribbonTabPageCommand.TabIndex = 0;
            this.ribbonTabPageCommand.Text = "عملیات";
            // 
            // formFrameSkinner
            // 
            this.formFrameSkinner.Form = this;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearch.Location = new System.Drawing.Point(10, 3);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(772, 55);
            this.groupBoxSearch.TabIndex = 1;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "جستجو";
            this.groupBoxSearch.Visible = false;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 496);
            this.Controls.Add(this.mainRibbon);
            this.Name = "ListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Controls.SetChildIndex(this.mainRibbon, 0);
            this.Controls.SetChildIndex(this.panelCommand, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonTabPageCommand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Elegant.Ui.Ribbon mainRibbon;
        public Elegant.Ui.RibbonTabPage ribbonTabPageCommand;
        public Elegant.Ui.FormFrameSkinner formFrameSkinner;
        public System.Windows.Forms.GroupBox groupBoxSearch;


    }
}