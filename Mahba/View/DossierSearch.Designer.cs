namespace NjitSoftware.View
{
    partial class DossierSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DossierSearch));
            this.btnView = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnDelete = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator2 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnPrintList = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator3 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnLend = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator4 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnDocs = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.btnSelect = new Njit.Program.Controls.ButtonExtended();
            this.dossierSearchBox = new NjitSoftware.View.Controls.DossierSearchBox();
            this.ribbonSeparator5 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnPrintDossiersBarcode = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnSelect);
            this.panelCommand.Location = new System.Drawing.Point(0, 486);
            this.panelCommand.Controls.SetChildIndex(this.btnExit, 0);
            this.panelCommand.Controls.SetChildIndex(this.btnSelect, 0);
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dossierSearchBox);
            this.panelMain.Size = new System.Drawing.Size(792, 333);
            // 
            // ribbonGroupOperations
            // 
            //this.ribbonGroupOperations.Items.Add(this.btnView);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator1);
            this.ribbonGroupOperations.Items.Add(this.btnDelete);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator2);
            this.ribbonGroupOperations.Items.Add(this.btnPrintList);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator3);
            this.ribbonGroupOperations.Items.Add(this.btnLend);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator4);
            this.ribbonGroupOperations.Items.Add(this.btnDocs);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator5);
            this.ribbonGroupOperations.Items.Add(this.btnPrintDossiersBarcode);
            // 
            // btnView
            // 
            this.btnView.LargeImage = global::NjitSoftware.Properties.Resources.ShowDossier;
            this.btnView.Name = "btnView";
            this.btnView.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnView.SmallImage")));
            this.btnView.Text = "مشاهده پرونده";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // btnDelete
            // 
            this.btnDelete.LargeImage = global::NjitSoftware.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.SmallImage")));
            this.btnDelete.Text = "حذف پرونده";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // btnPrintList
            // 
            this.btnPrintList.Name = "btnPrintList";
            this.btnPrintList.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnPrintList.SmallImage")));
            this.btnPrintList.Text = "چاپ لیست";
            this.btnPrintList.Visible = false;
            // 
            // ribbonSeparator3
            // 
            this.ribbonSeparator3.Name = "ribbonSeparator3";
            this.ribbonSeparator3.Visible = false;
            // 
            // btnLend
            // 
            this.btnLend.LargeImage = global::NjitSoftware.Properties.Resources.documentOutAdd;
            this.btnLend.Name = "btnLend";
            this.btnLend.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnLend.SmallImage")));
            this.btnLend.Text = "امانت دادن پرونده";
            this.btnLend.Click += new System.EventHandler(this.btnLend_Click);
            // 
            // ribbonSeparator4
            // 
            this.ribbonSeparator4.Name = "ribbonSeparator4";
            // 
            // btnDocs
            // 
            this.btnDocs.LargeImage = global::NjitSoftware.Properties.Resources.DocumentSearch;
            this.btnDocs.Name = "btnDocs";
            this.btnDocs.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDocs.SmallImage")));
            this.btnDocs.Text = "مشاهده و ثبت اسناد پرونده";
            this.btnDocs.Click += new System.EventHandler(this.btnDocs_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelect.Location = new System.Drawing.Point(704, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Visible = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dossierSearchBox
            // 
            this.dossierSearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dossierSearchBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dossierSearchBox.Location = new System.Drawing.Point(10, 3);
            this.dossierSearchBox.Name = "dossierSearchBox";
            this.dossierSearchBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dossierSearchBox.Size = new System.Drawing.Size(772, 327);
            this.dossierSearchBox.TabIndex = 0;
            // 
            // ribbonSeparator5
            // 
            this.ribbonSeparator5.Name = "ribbonSeparator5";
            // 
            // btnPrintDossiersBarcode
            // 
            this.btnPrintDossiersBarcode.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPrintDossiersBarcode.LargeImage")));
            this.btnPrintDossiersBarcode.Name = "btnPrintDossiersBarcode";
            this.btnPrintDossiersBarcode.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnPrintDossiersBarcode.SmallImage")));
            this.btnPrintDossiersBarcode.Text = "چاپ بارکد پرونده های انتخاب شده";
            this.btnPrintDossiersBarcode.Click += new System.EventHandler(this.btnPrintDossiersBarcode_Click);
            // 
            // DossierSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(792, 515);
            this.Name = "DossierSearch";
            this.Text = "جستجوی پرونده";
            this.panelCommand.ResumeLayout(false);
            this.ShowInTaskbar = false;
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

       

        #endregion

        private Njit.Program.ComponentOne.Controls.RibbonButton btnView;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnDelete;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator2;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnPrintList;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator3;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnLend;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator4;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnDocs;
        private Njit.Program.Controls.ButtonExtended btnSelect;
        private Controls.DossierSearchBox dossierSearchBox;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator5;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnPrintDossiersBarcode;
    }
}