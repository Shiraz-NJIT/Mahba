namespace NjitSoftware.View
{
    partial class Login
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
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // usersComboBox
            // 
            this.usersComboBox.DataSource = this.membershipBindingSource;
            this.usersComboBox.DisplayMember = "FullName";
            this.usersComboBox.Size = new System.Drawing.Size(194, 22);
            this.usersComboBox.ValueMember = "Code";
            // 
            // btnOK
            // 
            this.btnOK.AllowCheckAccessPermission = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowCheckAccessPermission = false;
            // 
            // membershipBindingSource
            // 
            this.membershipBindingSource.DataSource = typeof(NjitSoftware.Model.Common.User);
            // 
            // Login
            // 
            this.AllowCheckAccessPermission = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 205);
            this.Name = "Login";
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource membershipBindingSource;
    }
}