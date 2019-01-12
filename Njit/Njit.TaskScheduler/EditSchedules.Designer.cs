namespace Njit.TaskScheduler
{
    partial class EditSchedules
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnAdd = new Njit.Program.Controls.ButtonExtended();
            this.btnEdit = new Njit.Program.Controls.ButtonExtended();
            this.btnDelete = new Njit.Program.Controls.ButtonExtended();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repeatTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnDelete);
            this.panelCommand.Controls.Add(this.btnEdit);
            this.panelCommand.Controls.Add(this.btnAdd);
            this.panelCommand.Location = new System.Drawing.Point(0, 369);
            this.panelCommand.Size = new System.Drawing.Size(768, 29);
            this.panelCommand.TabIndex = 1;
            this.panelCommand.Controls.SetChildIndex(this.btnExit, 0);
            this.panelCommand.Controls.SetChildIndex(this.btnAdd, 0);
            this.panelCommand.Controls.SetChildIndex(this.btnEdit, 0);
            this.panelCommand.Controls.SetChildIndex(this.btnDelete, 0);
            // 
            // btnExit
            // 
            this.btnExit.TabIndex = 3;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridView);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Size = new System.Drawing.Size(768, 369);
            this.panelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(10, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(748, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "برنامه های زمانی ثبت شده:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.scheduleTypeDataGridViewTextBoxColumn,
            this.repeatTypeDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.scheduleBindingSource;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(10, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(748, 333);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(592, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(163, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ثبت برنامه زمانی جدید...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Location = new System.Drawing.Point(512, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "ویرایش...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(432, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "نام";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "توضیحات";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // scheduleTypeDataGridViewTextBoxColumn
            // 
            this.scheduleTypeDataGridViewTextBoxColumn.DataPropertyName = "ScheduleType";
            this.scheduleTypeDataGridViewTextBoxColumn.HeaderText = "ScheduleType";
            this.scheduleTypeDataGridViewTextBoxColumn.Name = "scheduleTypeDataGridViewTextBoxColumn";
            this.scheduleTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.scheduleTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // repeatTypeDataGridViewTextBoxColumn
            // 
            this.repeatTypeDataGridViewTextBoxColumn.DataPropertyName = "RepeatType";
            this.repeatTypeDataGridViewTextBoxColumn.HeaderText = "RepeatType";
            this.repeatTypeDataGridViewTextBoxColumn.Name = "repeatTypeDataGridViewTextBoxColumn";
            this.repeatTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.repeatTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // scheduleBindingSource
            // 
            this.scheduleBindingSource.DataSource = typeof(Njit.TaskScheduler.Schedule);
            // 
            // EditSchedules
            // 
            this.AutoLoadState = false;
            this.AutoSaveState = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 398);
            this.Name = "EditSchedules";
            this.Text = "برنامه های زمانی";
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource scheduleBindingSource;
        private Njit.Program.Controls.ButtonExtended btnDelete;
        private Njit.Program.Controls.ButtonExtended btnEdit;
        private Njit.Program.Controls.ButtonExtended btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduleTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repeatTypeDataGridViewTextBoxColumn;
    }
}