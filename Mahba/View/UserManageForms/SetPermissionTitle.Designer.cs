namespace NjitSoftware.View.UserManageForms
{
    partial class SetPermissionTitle
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmUsers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cblTitle = new System.Windows.Forms.CheckedListBox();
            this.cbSelect = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(820, 449);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 449);
            this.panelCommand.Size = new System.Drawing.Size(820, 29);
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
            this.groupBoxMain.Size = new System.Drawing.Size(800, 446);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(657, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(732, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(722, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "کاربران:";
            // 
            // cmUsers
            // 
            this.cmUsers.FormattingEnabled = true;
            this.cmUsers.Location = new System.Drawing.Point(43, 21);
            this.cmUsers.Name = "cmUsers";
            this.cmUsers.Size = new System.Drawing.Size(679, 22);
            this.cmUsers.TabIndex = 2;
            this.cmUsers.SelectedIndexChanged += new System.EventHandler(this.cmUsers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(722, 83);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1);
            this.label2.Size = new System.Drawing.Size(44, 61);
            this.label2.TabIndex = 5;
            this.label2.Text = "عناوین اسناد: ";
            // 
            // cblTitle
            // 
            this.cblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cblTitle.ColumnWidth = 300;
            this.cblTitle.FormattingEnabled = true;
            this.cblTitle.Location = new System.Drawing.Point(43, 82);
            this.cblTitle.MultiColumn = true;
            this.cblTitle.Name = "cblTitle";
            this.cblTitle.Size = new System.Drawing.Size(679, 344);
            this.cblTitle.TabIndex = 6;
            this.cblTitle.ThreeDCheckBoxes = true;
            // 
            // cbSelect
            // 
            this.cbSelect.AutoSize = true;
            this.cbSelect.Location = new System.Drawing.Point(637, 58);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(84, 18);
            this.cbSelect.TabIndex = 7;
            this.cbSelect.Text = "انتخاب همه";
            this.cbSelect.UseVisualStyleBackColor = true;
            this.cbSelect.CheckedChanged += new System.EventHandler(this.cbSelect_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(43, 56);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(452, 22);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "جستجو:";
            // 
            // SetPermissionTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 478);
            this.Name = "SetPermissionTitle";
            this.Text = "تعیین سطح دسترسی کاربران بر اساس عناوین اسناد";
            this.Load += new System.EventHandler(this.SetPermissionTitle_Load);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cblTitle;
        private System.Windows.Forms.CheckBox cbSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
    }
}