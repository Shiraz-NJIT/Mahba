namespace NjitSoftware.View
{
    partial class DocumentField
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtB_id = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtB_title = new Telerik.WinControls.UI.RadTextBox();
            this.Btn_Delete = new Telerik.WinControls.UI.RadButton();
            this.btn_Save = new Telerik.WinControls.UI.RadButton();
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.GridViewData = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.gridViewTemplate1 = new Telerik.WinControls.UI.GridViewTemplate();
            this.panelData = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB_title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Save)).BeginInit();
            this.panelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).BeginInit();
            this.panelData.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(608, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(53, 44);
            this.radLabel1.TabIndex = 10;
            this.radLabel1.Text = "کد";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtB_id
            // 
            this.txtB_id.AutoSize = false;
            this.txtB_id.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtB_id.Location = new System.Drawing.Point(469, 0);
            this.txtB_id.Name = "txtB_id";
            this.txtB_id.Size = new System.Drawing.Size(139, 44);
            this.txtB_id.TabIndex = 1;
            this.txtB_id.TabStop = false;
            this.txtB_id.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtB_id_TextChanging);
            this.txtB_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtB_id_KeyDown);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.radLabel2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(408, 0);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(61, 44);
            this.radLabel2.TabIndex = 12;
            this.radLabel2.Text = "عنوان";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtB_title
            // 
            this.txtB_title.AutoSize = false;
            this.txtB_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtB_title.Location = new System.Drawing.Point(0, 0);
            this.txtB_title.Name = "txtB_title";
            this.txtB_title.Size = new System.Drawing.Size(408, 44);
            this.txtB_title.TabIndex = 0;
            this.txtB_title.TabStop = false;
            this.txtB_title.TextChanging += new Telerik.WinControls.TextChangingEventHandler(this.txtB_title_TextChanging);
            this.txtB_title.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtB_title_KeyDown);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Delete.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Delete.Image = global::NjitSoftware.Properties.Resources.delete;
            this.Btn_Delete.Location = new System.Drawing.Point(0, 0);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(93, 44);
            this.Btn_Delete.TabIndex = 1;
            this.Btn_Delete.Text = "حذف";
            this.Btn_Delete.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            this.Btn_Delete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Btn_Delete_KeyDown);
            this.Btn_Delete.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Btn_Delete_KeyUp);
            // 
            // btn_Save
            // 
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = global::NjitSoftware.Properties.Resources.Save2;
            this.btn_Save.Location = new System.Drawing.Point(127, 0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(101, 44);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "ذخیره";
            this.btn_Save.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            this.btn_Save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_Save_KeyDown);
            this.btn_Save.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btn_Save_KeyUp);
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.Controls.Add(this.GridViewData);
            this.panelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGridView.Location = new System.Drawing.Point(0, 44);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(889, 567);
            this.panelDataGridView.TabIndex = 2;
            // 
            // GridViewData
            // 
            this.GridViewData.BackColor = System.Drawing.SystemColors.Control;
            this.GridViewData.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewData.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridViewData.ForeColor = System.Drawing.Color.Black;
            this.GridViewData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GridViewData.Location = new System.Drawing.Point(0, 0);
            // 
            // GridViewData
            // 
            this.GridViewData.MasterTemplate.AllowAddNewRow = false;
            this.GridViewData.MasterTemplate.AllowColumnReorder = false;
            this.GridViewData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = true;
            gridViewTextBoxColumn1.FieldName = "Key";
            gridViewTextBoxColumn1.HeaderText = "کد";
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 209;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Value";
            gridViewTextBoxColumn2.HeaderText = "عنوان";
            gridViewTextBoxColumn2.Name = "title";
            gridViewTextBoxColumn2.Width = 639;
            this.GridViewData.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.GridViewData.MasterTemplate.EnableAlternatingRowColor = true;
            this.GridViewData.MasterTemplate.EnableFiltering = true;
            this.GridViewData.MasterTemplate.EnableGrouping = false;
            this.GridViewData.MasterTemplate.Templates.AddRange(new Telerik.WinControls.UI.GridViewTemplate[] {
            this.gridViewTemplate1});
            this.GridViewData.Name = "GridViewData";
            this.GridViewData.ReadOnly = true;
            this.GridViewData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GridViewData.Size = new System.Drawing.Size(889, 567);
            this.GridViewData.TabIndex = 5;
            this.GridViewData.Text = "radGridViewExtended1";
            this.GridViewData.Click += new System.EventHandler(this.GridViewData_Click);
            this.GridViewData.DoubleClick += new System.EventHandler(this.GridViewData_DoubleClick);
            this.GridViewData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridViewData_KeyPress);
            // 
            // gridViewTemplate1
            // 
            this.gridViewTemplate1.EnableAlternatingRowColor = true;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.panel2);
            this.panelData.Controls.Add(this.panel1);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(889, 44);
            this.panelData.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtB_title);
            this.panel2.Controls.Add(this.radLabel2);
            this.panel2.Controls.Add(this.txtB_id);
            this.panel2.Controls.Add(this.radLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(228, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 44);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.Btn_Delete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 44);
            this.panel1.TabIndex = 1;
            // 
            // DocumentField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 611);
            this.Controls.Add(this.panelDataGridView);
            this.Controls.Add(this.panelData);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "DocumentField";
            this.Text = "";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DocumentField_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB_title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btn_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Save)).EndInit();
            this.panelDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox txtB_id;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtB_title;
        private Telerik.WinControls.UI.RadButton Btn_Delete;
        private Telerik.WinControls.UI.RadButton btn_Save;
        private System.Windows.Forms.Panel panelDataGridView;
        private Njit.Program.Telerik.Controls.RadGridViewExtended GridViewData;
        private Telerik.WinControls.UI.GridViewTemplate gridViewTemplate1;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}