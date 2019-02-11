namespace NjitSoftware.View.BaseForms
{
    partial class TabManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabManage));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnCreate = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnDelete = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator2 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnRename = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.btnEdit = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.radGridView1 = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.radbtnDocument = new System.Windows.Forms.RadioButton();
            this.radbtnDossier = new System.Windows.Forms.RadioButton();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 486);
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.radGridView1);
            this.panelMain.Controls.Add(this.pnlTop);
            this.panelMain.Size = new System.Drawing.Size(792, 333);
            // 
            // ribbonTabOperations
            // 
            this.ribbonTabOperations.Groups.Add(this.ribbonGroup1);
            // 
            // ribbonGroupOperations
            // 
            this.ribbonGroupOperations.Items.Add(this.btnCreate);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator1);
            this.ribbonGroupOperations.Items.Add(this.btnDelete);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator2);
            this.ribbonGroupOperations.Items.Add(this.btnRename);
            this.ribbonGroupOperations.Text = "     مدیریت گروه اطلاعاتی     ";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.btnEdit);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "     مدیریت فیلدها     ";
            // 
            // btnCreate
            // 
            this.btnCreate.LargeImage = global::NjitSoftware.Properties.Resources.add;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCreate.SmallImage")));
            this.btnCreate.Text = "ایجاد گروه اطلاعاتی";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
            this.btnDelete.Text = "حذف گروه اطلاعاتی";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // btnRename
            // 
            this.btnRename.LargeImage = global::NjitSoftware.Properties.Resources.rename;
            this.btnRename.Name = "btnRename";
            this.btnRename.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRename.SmallImage")));
            this.btnRename.Text = "تغییر نام";
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.LargeImage = global::NjitSoftware.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.SmallImage")));
            this.btnEdit.Text = "مدیریت فیلدها";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGridView1.Location = new System.Drawing.Point(10, 32);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AllowRowReorder = true;
            //this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.Width = 46;
            gridViewTextBoxColumn2.HeaderText = "IDParent";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "IDParent";
            gridViewTextBoxColumn2.Width = 46;
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "ردیف";
            gridViewTextBoxColumn3.MaxWidth = 80;
            gridViewTextBoxColumn3.Name = "Row";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 78;
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "نام گروه اطلاعاتی";
            gridViewTextBoxColumn4.Name = "Label";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 674;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.radGridView1.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(772, 298);
            this.radGridView1.TabIndex = 3;
            this.radGridView1.Text = "radGridView1";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.radbtnDocument);
            this.pnlTop.Controls.Add(this.radbtnDossier);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(10, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTop.Size = new System.Drawing.Size(772, 29);
            this.pnlTop.TabIndex = 2;
            // 
            // radbtnDocument
            // 
            this.radbtnDocument.AutoSize = true;
            this.radbtnDocument.Dock = System.Windows.Forms.DockStyle.Right;
            this.radbtnDocument.Location = new System.Drawing.Point(381, 3);
            this.radbtnDocument.Name = "radbtnDocument";
            this.radbtnDocument.Size = new System.Drawing.Size(184, 23);
            this.radbtnDocument.TabIndex = 1;
            this.radbtnDocument.TabStop = true;
            this.radbtnDocument.Text = "مدیریت اطلاعات گروه های سند";
            this.radbtnDocument.UseVisualStyleBackColor = true;
            this.radbtnDocument.CheckedChanged += new System.EventHandler(this.radbtnDossier_CheckedChanged);
            // 
            // radbtnDossier
            // 
            this.radbtnDossier.Dock = System.Windows.Forms.DockStyle.Right;
            this.radbtnDossier.Location = new System.Drawing.Point(565, 3);
            this.radbtnDossier.Name = "radbtnDossier";
            this.radbtnDossier.Size = new System.Drawing.Size(204, 23);
            this.radbtnDossier.TabIndex = 0;
            this.radbtnDossier.TabStop = true;
            this.radbtnDossier.Text = "مدیریت اطلاعات گروه های پرونده";
            this.radbtnDossier.UseVisualStyleBackColor = true;
            this.radbtnDossier.CheckedChanged += new System.EventHandler(this.radbtnDossier_CheckedChanged);
            // 
            // TabManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 515);
            this.Name = "TabManage";
            this.Text = "مدیریت گروه های اطلاعاتی";
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnCreate;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnDelete;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator2;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnRename;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnEdit;
        protected internal Njit.Program.Telerik.Controls.RadGridViewExtended radGridView1;
        private System.Windows.Forms.Panel pnlTop;
        protected System.Windows.Forms.RadioButton radbtnDocument;
        protected System.Windows.Forms.RadioButton radbtnDossier;
    }
}