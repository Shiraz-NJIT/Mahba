namespace NjitSoftware.View.BaseForms
{
    partial class FieldManage
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn5 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn6 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn9 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.groupBoxAddField = new System.Windows.Forms.GroupBox();
            this.fieldInfo = new NjitSoftware.View.Controls.FieldInfo();
            this.btnMove = new System.Windows.Forms.Button();
            this.groupBoxFields = new System.Windows.Forms.GroupBox();
            this.radGridView = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.btnDelete = new Njit.Program.Controls.ButtonExtended();
            this.btnEdit = new Njit.Program.Controls.ButtonExtended();
            this.panelEditDelete = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBoxAddField.SuspendLayout();
            this.groupBoxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
            this.panelEditDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(904, 457);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 457);
            this.panelCommand.Padding = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.panelCommand.Size = new System.Drawing.Size(904, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.groupBoxFields);
            this.groupBoxMain.Controls.Add(this.groupBoxAddField);
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 5);
            this.groupBoxMain.Size = new System.Drawing.Size(884, 454);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(30, 3);
            this.btnCancel.Text = "خروج";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxAddField
            // 
            this.groupBoxAddField.Controls.Add(this.fieldInfo);
            this.groupBoxAddField.Controls.Add(this.btnMove);
            this.groupBoxAddField.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxAddField.Location = new System.Drawing.Point(10, 18);
            this.groupBoxAddField.Name = "groupBoxAddField";
            this.groupBoxAddField.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxAddField.Size = new System.Drawing.Size(864, 149);
            this.groupBoxAddField.TabIndex = 0;
            this.groupBoxAddField.TabStop = false;
            this.groupBoxAddField.Text = "افزودن فیلد جدید";
            // 
            // fieldInfo
            // 
            this.fieldInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.fieldInfo.Location = new System.Drawing.Point(100, 20);
            this.fieldInfo.Name = "fieldInfo";
            this.fieldInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fieldInfo.Size = new System.Drawing.Size(751, 116);
            this.fieldInfo.TabIndex = 0;
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.AutoEllipsis = true;
            this.btnMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMove.Image = global::NjitSoftware.Properties.Resources.addDark16;
            this.btnMove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMove.Location = new System.Drawing.Point(13, 101);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(81, 25);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "افزودن";
            this.btnMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // groupBoxFields
            // 
            this.groupBoxFields.Controls.Add(this.radGridView);
            this.groupBoxFields.Controls.Add(this.panelEditDelete);
            this.groupBoxFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFields.Location = new System.Drawing.Point(10, 167);
            this.groupBoxFields.Name = "groupBoxFields";
            this.groupBoxFields.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.groupBoxFields.Size = new System.Drawing.Size(864, 282);
            this.groupBoxFields.TabIndex = 1;
            this.groupBoxFields.TabStop = false;
            this.groupBoxFields.Text = "فیلدهای ثبت شده";
            // 
            // radGridView
            // 
            this.radGridView.DeleteButton = this.btnDelete;
            this.radGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView.EditButton = this.btnEdit;
            this.radGridView.EnableCustomSorting = true;
            this.radGridView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView.Location = new System.Drawing.Point(10, 25);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AllowAddNewRow = false;
            this.radGridView.MasterTemplate.AllowColumnReorder = false;
            this.radGridView.MasterTemplate.AllowRowReorder = true;
            this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.FieldName = "ID";
            gridViewDecimalColumn1.HeaderText = "ID";
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Name = "ID";
            gridViewTextBoxColumn1.FieldName = "Label";
            gridViewTextBoxColumn1.HeaderText = "نام";
            gridViewTextBoxColumn1.Name = "Label";
            gridViewTextBoxColumn1.Width = 197;
            gridViewTextBoxColumn2.FieldName = "FieldName";
            gridViewTextBoxColumn2.HeaderText = "FieldName";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FieldName";
            gridViewDecimalColumn2.FieldName = "FieldTypeCode";
            gridViewDecimalColumn2.HeaderText = "FieldTypeCode";
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Name = "FieldTypeCode";
            gridViewTextBoxColumn3.FieldName = "FieldType";
            gridViewTextBoxColumn3.HeaderText = "نوع فیلد";
            gridViewTextBoxColumn3.Name = "FieldType";
            gridViewTextBoxColumn3.Width = 165;
            gridViewDecimalColumn3.FieldName = "StatusCode";
            gridViewDecimalColumn3.HeaderText = "StatusCode";
            gridViewDecimalColumn3.IsVisible = false;
            gridViewDecimalColumn3.Name = "StatusCode";
            gridViewTextBoxColumn4.FieldName = "Status";
            gridViewTextBoxColumn4.HeaderText = "وضعیت";
            gridViewTextBoxColumn4.Name = "Status";
            gridViewTextBoxColumn4.Width = 189;
            gridViewDecimalColumn4.FieldName = "BoxTypeCode";
            gridViewDecimalColumn4.HeaderText = "BoxTypeCode";
            gridViewDecimalColumn4.IsVisible = false;
            gridViewDecimalColumn4.Name = "BoxTypeCode";
            gridViewTextBoxColumn5.FieldName = "BoxType";
            gridViewTextBoxColumn5.HeaderText = "نوع کادر";
            gridViewTextBoxColumn5.Name = "BoxType";
            gridViewTextBoxColumn5.Width = 143;
            gridViewCheckBoxColumn1.FieldName = "AutoComplete";
            gridViewCheckBoxColumn1.HeaderText = "تکمیل خودکار";
            gridViewCheckBoxColumn1.Name = "AutoComplete";
            gridViewCheckBoxColumn1.Width = 89;
            gridViewDecimalColumn5.FieldName = "MinLength";
            gridViewDecimalColumn5.HeaderText = "MinLength";
            gridViewDecimalColumn5.IsVisible = false;
            gridViewDecimalColumn5.Name = "MinLength";
            gridViewDecimalColumn6.FieldName = "MaxLength";
            gridViewDecimalColumn6.HeaderText = "MaxLength";
            gridViewDecimalColumn6.IsVisible = false;
            gridViewDecimalColumn6.Name = "MaxLength";
            gridViewDecimalColumn7.FieldName = "MinValue";
            gridViewDecimalColumn7.HeaderText = "MinValue";
            gridViewDecimalColumn7.IsVisible = false;
            gridViewDecimalColumn7.Name = "MinValue";
            gridViewDecimalColumn8.FieldName = "MaxValue";
            gridViewDecimalColumn8.HeaderText = "MaxValue";
            gridViewDecimalColumn8.IsVisible = false;
            gridViewDecimalColumn8.Name = "MaxValue";
            gridViewDecimalColumn9.FieldName = "ParentID";
            gridViewDecimalColumn9.HeaderText = "ParentID";
            gridViewDecimalColumn9.IsVisible = false;
            gridViewDecimalColumn9.Name = "ParentID";
            gridViewDecimalColumn9.Width = 47;
            gridViewTextBoxColumn6.FieldName = "DefaultValue";
            gridViewTextBoxColumn6.HeaderText = "DefaultValue";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "DefaultValue";
            gridViewTextBoxColumn6.Width = 48;
            gridViewImageColumn1.HeaderText = "وضعیت";
            gridViewImageColumn1.Name = "StatusImage";
            gridViewImageColumn1.Width = 45;
            gridViewTextBoxColumn7.FieldName = "Width";
            gridViewTextBoxColumn7.HeaderText = "Width";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "Width";
            gridViewTextBoxColumn7.Width = 48;
            this.radGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn2,
            gridViewTextBoxColumn3,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn4,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn5,
            gridViewCheckBoxColumn1,
            gridViewDecimalColumn5,
            gridViewDecimalColumn6,
            gridViewDecimalColumn7,
            gridViewDecimalColumn8,
            gridViewDecimalColumn9,
            gridViewTextBoxColumn6,
            gridViewImageColumn1,
            gridViewTextBoxColumn7});
            this.radGridView.MasterTemplate.EnableCustomSorting = true;
            this.radGridView.MasterTemplate.EnableGrouping = false;
            this.radGridView.MasterTemplate.MultiSelect = true;
            this.radGridView.Name = "radGridView";
            this.radGridView.ReadOnly = true;
            this.radGridView.Size = new System.Drawing.Size(844, 221);
            this.radGridView.TabIndex = 0;
            this.radGridView.SelectionChanged += new System.EventHandler(this.radGridView_SelectionChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Image = global::NjitSoftware.Properties.Resources.recycleBinDark16;
            this.btnDelete.Location = new System.Drawing.Point(671, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 25);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Image = global::NjitSoftware.Properties.Resources.penDark16;
            this.btnEdit.Location = new System.Drawing.Point(756, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 25);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panelEditDelete
            // 
            this.panelEditDelete.Controls.Add(this.btnDelete);
            this.panelEditDelete.Controls.Add(this.btnEdit);
            this.panelEditDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEditDelete.Location = new System.Drawing.Point(10, 246);
            this.panelEditDelete.Name = "panelEditDelete";
            this.panelEditDelete.Padding = new System.Windows.Forms.Padding(3);
            this.panelEditDelete.Size = new System.Drawing.Size(844, 31);
            this.panelEditDelete.TabIndex = 1;
            // 
            // FieldManage
            // 
            this.AcceptButton = this.btnMove;
            this.AutoLoadState = true;
            this.AutoSaveState = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 486);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FieldManage";
            this.ShowIcon = false;
            this.Tag = "";
            this.Text = "مدیریت فیلدها";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBoxAddField.ResumeLayout(false);
            this.groupBoxFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            this.panelEditDelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBoxFields;
        protected Njit.Program.Telerik.Controls.RadGridViewExtended radGridView;
        protected System.Windows.Forms.Panel panelEditDelete;
        protected System.Windows.Forms.GroupBox groupBoxAddField;
        protected Controls.FieldInfo fieldInfo;
        protected System.Windows.Forms.Button btnMove;
        protected Njit.Program.Controls.ButtonExtended btnDelete;
        protected Njit.Program.Controls.ButtonExtended btnEdit;
    }
}