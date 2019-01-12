namespace NjitSoftware.View.UserManageForms
{
    partial class UserRoleAddEdit
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
            System.Windows.Forms.Label nameLabel;
            this.userRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new Njit.Program.Controls.TextBoxExtended();
            nameLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(437, 121);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 121);
            this.panelCommand.Size = new System.Drawing.Size(437, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(nameLabel);
            this.groupBoxMain.Controls.Add(this.nameTextBox);
            this.groupBoxMain.Size = new System.Drawing.Size(417, 118);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(349, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // userRoleBindingSource
            // 
            this.userRoleBindingSource.DataSource = typeof(NjitSoftware.Model.Common.UserRole);
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(308, 52);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 14);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "عنوان:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userRoleBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(80, 49);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(222, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // UserRoleAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 150);
            this.Name = "UserRoleAddEdit";
            this.Text = "اطلاعات گروه کاربر";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.TextBoxExtended nameTextBox;
        private System.Windows.Forms.BindingSource userRoleBindingSource;
    }
}