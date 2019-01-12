namespace NjitSoftware.View.UserManageForms
{
    partial class ChangePasswordWithAdmin
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
            this.cmUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(331, 80);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 80);
            this.panelCommand.Size = new System.Drawing.Size(331, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Controls.Add(this.cmUsers);
            this.groupBoxMain.Size = new System.Drawing.Size(311, 77);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(168, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(243, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmUsers
            // 
            this.cmUsers.FormattingEnabled = true;
            this.cmUsers.Location = new System.Drawing.Point(38, 37);
            this.cmUsers.Name = "cmUsers";
            this.cmUsers.Size = new System.Drawing.Size(195, 22);
            this.cmUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "کاربران:";
            // 
            // ChangePasswordWithAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 109);
            this.Name = "ChangePasswordWithAdmin";
            this.Text = "تغییر رمز عبور کاربران";
            this.Load += new System.EventHandler(this.ChangePasswordWithAdmin_Load);
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
    }
}