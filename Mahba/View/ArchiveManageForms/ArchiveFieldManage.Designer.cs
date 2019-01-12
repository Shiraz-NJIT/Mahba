namespace NjitSoftware.View
{
    partial class ArchiveFieldManage
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
            this.btnEditFields = new Njit.Program.Controls.ButtonExtended();
            this.groupBoxFields.SuspendLayout();
            this.panelEditDelete.SuspendLayout();
            this.groupBoxAddField.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEditDelete
            // 
            this.panelEditDelete.Controls.Add(this.btnEditFields);
            this.panelEditDelete.Controls.SetChildIndex(this.btnEditFields, 0);
            // 
            // fieldInfo
            // 
            this.fieldInfo.Location = new System.Drawing.Point(100, 19);
            // 
            // btnEditFields
            // 
            this.btnEditFields.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditFields.Location = new System.Drawing.Point(562, 3);
            this.btnEditFields.Name = "btnEditFields";
            this.btnEditFields.Size = new System.Drawing.Size(109, 25);
            this.btnEditFields.TabIndex = 2;
            this.btnEditFields.Text = "ویرایش فیلدها";
            this.btnEditFields.UseVisualStyleBackColor = true;
            this.btnEditFields.Click += new System.EventHandler(this.btnEditFields_Click);
            // 
            // ArchiveFieldManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(904, 486);
            this.Name = "ArchiveFieldManage";
            this.Text = "مدیریت فیلد های بایگانی";
            this.groupBoxFields.ResumeLayout(false);
            this.panelEditDelete.ResumeLayout(false);
            this.groupBoxAddField.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.ButtonExtended btnEditFields;
    }
}