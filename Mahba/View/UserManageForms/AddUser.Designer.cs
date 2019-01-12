namespace NjitSoftware.View.UserManageForms
{
    partial class AddUser
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
            this.userRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxState.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // roleComboBox
            // 
            this.roleComboBox.DataSource = this.userRoleBindingSource;
            this.roleComboBox.DisplayMember = "Name";
            this.roleComboBox.ValueMember = "ID";
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(469, 252);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 252);
            this.panelCommand.Size = new System.Drawing.Size(469, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Size = new System.Drawing.Size(449, 249);
            this.groupBoxMain.Controls.SetChildIndex(this.passwordTextBox, 0);
            this.groupBoxMain.Controls.SetChildIndex(this.passwordConfirmTextBox, 0);
            this.groupBoxMain.Controls.SetChildIndex(this.fullNameTextBox, 0);
            this.groupBoxMain.Controls.SetChildIndex(this.groupBoxState, 0);
            this.groupBoxMain.Controls.SetChildIndex(this.roleComboBox, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(306, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(381, 3);
            // 
            // userRoleBindingSource
            // 
            this.userRoleBindingSource.DataSource = typeof(NjitSoftware.Model.Common.UserRole);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 281);
            this.Name = "AddUser";
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource userRoleBindingSource;
    }
}