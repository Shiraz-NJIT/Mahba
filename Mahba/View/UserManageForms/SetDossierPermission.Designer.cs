namespace NjitSoftware.View.UserManageForms
{
    partial class SetDossierPermission
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSelect = new System.Windows.Forms.CheckBox();
            this.cblTitle = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmUsers = new System.Windows.Forms.ComboBox();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(486, 240);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 240);
            this.panelCommand.Size = new System.Drawing.Size(486, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label3);
            this.groupBoxMain.Controls.Add(this.txtSearch);
            this.groupBoxMain.Controls.Add(this.cbSelect);
            this.groupBoxMain.Controls.Add(this.cblTitle);
            this.groupBoxMain.Controls.Add(this.label2);
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Controls.Add(this.cmUsers);
            this.groupBoxMain.Size = new System.Drawing.Size(466, 237);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(323, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(398, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "جستجو:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(6, 56);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(231, 22);
            this.txtSearch.TabIndex = 29;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cbSelect
            // 
            this.cbSelect.AutoSize = true;
            this.cbSelect.Location = new System.Drawing.Point(317, 58);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(84, 18);
            this.cbSelect.TabIndex = 28;
            this.cbSelect.Text = "انتخاب همه";
            this.cbSelect.UseVisualStyleBackColor = true;
            this.cbSelect.CheckedChanged += new System.EventHandler(this.cbSelect_CheckedChanged);
            // 
            // cblTitle
            // 
            this.cblTitle.ColumnWidth = 300;
            this.cblTitle.FormattingEnabled = true;
            this.cblTitle.Location = new System.Drawing.Point(6, 97);
            this.cblTitle.MultiColumn = true;
            this.cblTitle.Name = "cblTitle";
            this.cblTitle.Size = new System.Drawing.Size(379, 123);
            this.cblTitle.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(385, 97);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1);
            this.label2.Size = new System.Drawing.Size(68, 105);
            this.label2.TabIndex = 26;
            this.label2.Text = "نوع دسترسی:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "کاربران:";
            // 
            // cmUsers
            // 
            this.cmUsers.FormattingEnabled = true;
            this.cmUsers.Location = new System.Drawing.Point(6, 21);
            this.cmUsers.Name = "cmUsers";
            this.cmUsers.Size = new System.Drawing.Size(396, 22);
            this.cmUsers.TabIndex = 24;
            this.cmUsers.SelectedIndexChanged += new System.EventHandler(this.cmUsers_SelectedIndexChanged);
            // 
            // SetDossierPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 269);
            this.Name = "SetDossierPermission";
            this.Text = "سطح دسترسی کاربران در پرونده";
            this.Load += new System.EventHandler(this.SetDossierPermission_Load);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox cbSelect;
        private System.Windows.Forms.CheckedListBox cblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmUsers;
    }
}