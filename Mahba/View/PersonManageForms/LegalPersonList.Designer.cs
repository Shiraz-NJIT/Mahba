namespace NjitSoftware.View.PersonManageForms
{
    partial class LegalPersonList
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegalPersonList));
            this.radGridView = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.btnEdit = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.btnDelete = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.btnAdd = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.ribbonSeparator2 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.legalPersonViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legalPersonViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.radGridView);
            // 
            // ribbonGroupOperations
            // 
            this.ribbonGroupOperations.Items.Add(this.btnAdd);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator1);
            this.ribbonGroupOperations.Items.Add(this.btnEdit);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator2);
            this.ribbonGroupOperations.Items.Add(this.btnDelete);
            // 
            // radGridView
            // 
            this.radGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView.Location = new System.Drawing.Point(10, 3);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AllowAddNewRow = false;
            this.radGridView.MasterTemplate.AllowDeleteRow = false;
            this.radGridView.MasterTemplate.AllowEditRow = false;
            this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "Id";
            gridViewDecimalColumn1.FormatString = "";
            gridViewDecimalColumn1.HeaderText = "Id";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "Id";
            gridViewDecimalColumn1.Width = 95;
            gridViewTextBoxColumn1.FieldName = "Name";
            gridViewTextBoxColumn1.HeaderText = "نام";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 178;
            gridViewTextBoxColumn2.FieldName = "CompanyNumber";
            gridViewTextBoxColumn2.HeaderText = "شماره ثبت";
            gridViewTextBoxColumn2.IsAutoGenerated = true;
            gridViewTextBoxColumn2.Name = "CompanyNumber";
            gridViewTextBoxColumn2.Width = 108;
            gridViewTextBoxColumn3.FieldName = "EconomicNumber";
            gridViewTextBoxColumn3.HeaderText = "کد اقتصادی";
            gridViewTextBoxColumn3.IsAutoGenerated = true;
            gridViewTextBoxColumn3.Name = "EconomicNumber";
            gridViewTextBoxColumn3.Width = 108;
            gridViewTextBoxColumn4.FieldName = "Address";
            gridViewTextBoxColumn4.HeaderText = "آدرس";
            gridViewTextBoxColumn4.IsAutoGenerated = true;
            gridViewTextBoxColumn4.Name = "Address";
            gridViewTextBoxColumn4.Width = 41;
            gridViewTextBoxColumn5.FieldName = "Tel";
            gridViewTextBoxColumn5.HeaderText = "تلفن";
            gridViewTextBoxColumn5.IsAutoGenerated = true;
            gridViewTextBoxColumn5.Name = "Tel";
            gridViewTextBoxColumn5.Width = 108;
            gridViewTextBoxColumn6.FieldName = "Manager";
            gridViewTextBoxColumn6.HeaderText = "مدیرعامل";
            gridViewTextBoxColumn6.IsAutoGenerated = true;
            gridViewTextBoxColumn6.Name = "Manager";
            gridViewTextBoxColumn6.Width = 108;
            gridViewTextBoxColumn7.FieldName = "ManagerTel";
            gridViewTextBoxColumn7.HeaderText = "تلفن مدیرعامل";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "ManagerTel";
            gridViewTextBoxColumn7.Width = 106;
            this.radGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.radGridView.MasterTemplate.DataSource = this.legalPersonViewBindingSource;
            this.radGridView.MasterTemplate.EnableFiltering = true;
            this.radGridView.MasterTemplate.MultiSelect = true;
            this.radGridView.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView.Name = "radGridView";
            this.radGridView.ReadOnly = true;
            this.radGridView.Size = new System.Drawing.Size(772, 304);
            this.radGridView.TabIndex = 4;
            // 
            // btnEdit
            // 
            this.btnEdit.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.LargeImage")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.SmallImage")));
            this.btnEdit.Text = "ویرایش...";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.LargeImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.SmallImage")));
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.LargeImage = global::NjitSoftware.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.SmallImage")));
            this.btnAdd.Text = "ثبت اطلاعات شخص حقوقی جدید...";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // legalPersonViewBindingSource
            // 
            this.legalPersonViewBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.LegalPersonView);
            // 
            // LegalPersonList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 492);
            this.Name = "LegalPersonList";
            this.Text = "لیست اشخاص حقوقی";
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legalPersonViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridView;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnEdit;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnAdd;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator2;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnDelete;
        private System.Windows.Forms.BindingSource legalPersonViewBindingSource;
    }
}