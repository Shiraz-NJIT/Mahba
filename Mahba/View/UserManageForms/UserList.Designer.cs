namespace NjitSoftware.View.UserManageForms
{
    partial class UserList
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
            this.membershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxState.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // usersComboBox
            // 
            this.usersComboBox.DataSource = this.membershipBindingSource;
            this.usersComboBox.DisplayMember = "FullName";
            this.usersComboBox.ValueMember = "Code";
            // 
            // roleComboBox
            // 
            this.roleComboBox.DataSource = this.userRoleBindingSource;
            this.roleComboBox.DisplayMember = "Name";
            this.roleComboBox.Size = new System.Drawing.Size(285, 22);
            this.roleComboBox.ValueMember = "ID";
            this.groupBox1.Controls.SetChildIndex(this.txtExpire, 0);
            this.groupBox1.Controls.SetChildIndex(this.cbGuest, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupBoxState, 0);
            this.groupBox1.Controls.SetChildIndex(this.roleComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.fullNameTextBox, 0);
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(455, 307);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 307);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Size = new System.Drawing.Size(435, 304);
            this.groupBoxMain.Controls.SetChildIndex(this.usersComboBox, 0);
            this.groupBoxMain.Controls.SetChildIndex(this.lblLine, 0);
            this.groupBoxMain.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // membershipBindingSource
            // 
            this.membershipBindingSource.DataSource = typeof(NjitSoftware.Model.Common.User);
            // 
            // userRoleBindingSource
            // 
            this.userRoleBindingSource.DataSource = typeof(NjitSoftware.Model.Common.UserRole);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 336);
            this.Name = "UserList";
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource membershipBindingSource;
        private System.Windows.Forms.BindingSource userRoleBindingSource;
    }
}