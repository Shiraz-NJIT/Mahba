﻿namespace NjitSoftware.View.UserManageForms
{
    partial class UserRoleList
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRoleList));
            this.userRoleReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radGridView = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.btnAdd = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnEdit = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator2 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnDelete = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
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
            this.panelMain.Controls.Add(this.radGridView);
            this.panelMain.Size = new System.Drawing.Size(792, 333);
            // 
            // ribbonGroupOperations
            // 
            this.ribbonGroupOperations.Items.Add(this.btnAdd);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator1);
            this.ribbonGroupOperations.Items.Add(this.btnEdit);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator2);
            this.ribbonGroupOperations.Items.Add(this.btnDelete);
            // 
            // userRoleReportBindingSource
            // 
            this.userRoleReportBindingSource.DataSource = typeof(NjitSoftware.Model.Common.UserRoleReport);
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
            //this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "Code";
            gridViewDecimalColumn1.FormatString = "";
            gridViewDecimalColumn1.HeaderText = "Code";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "Code";
            gridViewDecimalColumn1.Width = 223;
            gridViewTextBoxColumn1.FieldName = "Name";
            gridViewTextBoxColumn1.HeaderText = "عنوان گروه";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 751;
            gridViewCheckBoxColumn1.FieldName = "Locked";
            gridViewCheckBoxColumn1.FormatString = "";
            gridViewCheckBoxColumn1.HeaderText = "Locked";
            gridViewCheckBoxColumn1.IsAutoGenerated = true;
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.Name = "Locked";
            gridViewCheckBoxColumn1.Width = 334;
            this.radGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1});
            this.radGridView.MasterTemplate.DataSource = this.userRoleReportBindingSource;
            this.radGridView.MasterTemplate.EnableFiltering = true;
            this.radGridView.MasterTemplate.MultiSelect = true;
            this.radGridView.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView.Name = "radGridView";
            this.radGridView.ReadOnly = true;
            this.radGridView.Size = new System.Drawing.Size(772, 327);
            this.radGridView.TabIndex = 2;
            this.radGridView.SelectionChanged += new System.EventHandler(this.radGridView_SelectionChanged);
            this.radGridView.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.LargeImage = global::NjitSoftware.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.SmallImage")));
            this.btnAdd.Text = "ثبت گروه جدید...";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // btnEdit
            // 
            this.btnEdit.LargeImage = global::NjitSoftware.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.SmallImage")));
            this.btnEdit.Text = "ویرایش...";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // btnDelete
            // 
            this.btnDelete.LargeImage = global::NjitSoftware.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.SmallImage")));
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // UserRoleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 515);
            this.Name = "UserRoleList";
            this.Text = "لیست گروه های کاربران";
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridView;
        private System.Windows.Forms.BindingSource userRoleReportBindingSource;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnAdd;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnEdit;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator2;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnDelete;
    }
}