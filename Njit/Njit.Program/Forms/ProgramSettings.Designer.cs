namespace Njit.Program.Forms
{
    partial class ProgramSettings
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
            this.tabControlExtended = new Njit.Program.Controls.TabControlExtended();
            this.tabPageProgramSettings = new System.Windows.Forms.TabPage();
            this.tabPageSavedResponse = new System.Windows.Forms.TabPage();
            this.dataGridViewSavedResponse = new Njit.Program.Controls.DataGridViewExtended();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.persianMessageBoxInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelSavedResponseActions = new System.Windows.Forms.Panel();
            this.btnDeleteSavedResponse = new Njit.Program.Controls.ButtonExtended();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabControlExtended.SuspendLayout();
            this.tabPageSavedResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSavedResponse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianMessageBoxInfoBindingSource)).BeginInit();
            this.panelSavedResponseActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(784, 433);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 433);
            this.panelCommand.Size = new System.Drawing.Size(784, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.tabControlExtended);
            this.groupBoxMain.Size = new System.Drawing.Size(764, 430);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(621, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(696, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControlExtended
            // 
            this.tabControlExtended.Controls.Add(this.tabPageProgramSettings);
            this.tabControlExtended.Controls.Add(this.tabPageSavedResponse);
            this.tabControlExtended.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlExtended.Location = new System.Drawing.Point(3, 18);
            this.tabControlExtended.Name = "tabControlExtended";
            this.tabControlExtended.RightToLeftLayout = true;
            this.tabControlExtended.SelectedIndex = 0;
            this.tabControlExtended.Size = new System.Drawing.Size(758, 409);
            this.tabControlExtended.TabIndex = 0;
            // 
            // tabPageProgramSettings
            // 
            this.tabPageProgramSettings.Location = new System.Drawing.Point(4, 23);
            this.tabPageProgramSettings.Name = "tabPageProgramSettings";
            this.tabPageProgramSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProgramSettings.Size = new System.Drawing.Size(750, 382);
            this.tabPageProgramSettings.TabIndex = 0;
            this.tabPageProgramSettings.Text = "تنظیمات برنامه";
            this.tabPageProgramSettings.UseVisualStyleBackColor = true;
            // 
            // tabPageSavedResponse
            // 
            this.tabPageSavedResponse.Controls.Add(this.dataGridViewSavedResponse);
            this.tabPageSavedResponse.Controls.Add(this.panelSavedResponseActions);
            this.tabPageSavedResponse.Location = new System.Drawing.Point(4, 23);
            this.tabPageSavedResponse.Name = "tabPageSavedResponse";
            this.tabPageSavedResponse.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.tabPageSavedResponse.Size = new System.Drawing.Size(750, 382);
            this.tabPageSavedResponse.TabIndex = 1;
            this.tabPageSavedResponse.Text = "پاسخ های ذخیره شده";
            this.tabPageSavedResponse.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSavedResponse
            // 
            this.dataGridViewSavedResponse.AutoGenerateColumns = false;
            this.dataGridViewSavedResponse.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSavedResponse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewSavedResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSavedResponse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.resultDataGridViewTextBoxColumn,
            this.resultDescriptionDataGridViewTextBoxColumn});
            this.dataGridViewSavedResponse.DataSource = this.persianMessageBoxInfoBindingSource;
            this.dataGridViewSavedResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSavedResponse.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewSavedResponse.Name = "dataGridViewSavedResponse";
            this.dataGridViewSavedResponse.Size = new System.Drawing.Size(730, 343);
            this.dataGridViewSavedResponse.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "نام";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultDataGridViewTextBoxColumn
            // 
            this.resultDataGridViewTextBoxColumn.DataPropertyName = "Result";
            this.resultDataGridViewTextBoxColumn.HeaderText = "Result";
            this.resultDataGridViewTextBoxColumn.Name = "resultDataGridViewTextBoxColumn";
            this.resultDataGridViewTextBoxColumn.ReadOnly = true;
            this.resultDataGridViewTextBoxColumn.Visible = false;
            // 
            // resultDescriptionDataGridViewTextBoxColumn
            // 
            this.resultDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resultDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ResultDescription";
            this.resultDescriptionDataGridViewTextBoxColumn.HeaderText = "مقدار ذخیره شده";
            this.resultDescriptionDataGridViewTextBoxColumn.Name = "resultDescriptionDataGridViewTextBoxColumn";
            this.resultDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // persianMessageBoxInfoBindingSource
            // 
            this.persianMessageBoxInfoBindingSource.DataSource = typeof(Njit.MessageBox.PersianMessageBoxInfo);
            // 
            // panelSavedResponseActions
            // 
            this.panelSavedResponseActions.Controls.Add(this.btnDeleteSavedResponse);
            this.panelSavedResponseActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSavedResponseActions.Location = new System.Drawing.Point(10, 353);
            this.panelSavedResponseActions.Name = "panelSavedResponseActions";
            this.panelSavedResponseActions.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.panelSavedResponseActions.Size = new System.Drawing.Size(730, 29);
            this.panelSavedResponseActions.TabIndex = 1;
            // 
            // btnDeleteSavedResponse
            // 
            this.btnDeleteSavedResponse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteSavedResponse.Location = new System.Drawing.Point(628, 3);
            this.btnDeleteSavedResponse.Name = "btnDeleteSavedResponse";
            this.btnDeleteSavedResponse.Size = new System.Drawing.Size(89, 23);
            this.btnDeleteSavedResponse.TabIndex = 0;
            this.btnDeleteSavedResponse.Text = "حذف";
            this.btnDeleteSavedResponse.UseVisualStyleBackColor = true;
            this.btnDeleteSavedResponse.Click += new System.EventHandler(this.btnDeleteSavedResponse_Click);
            // 
            // ProgramSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Name = "ProgramSettings";
            this.Text = "تنظیمات برنامه";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabControlExtended.ResumeLayout(false);
            this.tabPageSavedResponse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSavedResponse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.persianMessageBoxInfoBindingSource)).EndInit();
            this.panelSavedResponseActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.TabControlExtended tabControlExtended;
        protected System.Windows.Forms.TabPage tabPageProgramSettings;
        protected System.Windows.Forms.TabPage tabPageSavedResponse;
        protected System.Windows.Forms.Panel panelSavedResponseActions;
        protected Controls.ButtonExtended btnDeleteSavedResponse;
        protected System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn resultDescriptionDataGridViewTextBoxColumn;
        private Controls.DataGridViewExtended dataGridViewSavedResponse;
        private System.Windows.Forms.BindingSource persianMessageBoxInfoBindingSource;

    }
}