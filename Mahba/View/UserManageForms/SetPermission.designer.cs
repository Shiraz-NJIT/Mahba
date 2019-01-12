namespace NjitSoftware.View.UserManageForms
{
    partial class SetPermission
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
            this.accessPermissionTreeView = new Njit.Program.Controls.AccessPermissionTreeView();
            this.comboBoxUserRole = new Njit.Program.Controls.ComboBoxExtended();
            this.userRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.membershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(514, 411);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 411);
            this.panelCommand.Size = new System.Drawing.Size(514, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Controls.Add(this.comboBoxUserRole);
            this.groupBoxMain.Controls.Add(this.accessPermissionTreeView);
            this.groupBoxMain.Size = new System.Drawing.Size(494, 408);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(351, 3);
            this.btnCancel.Text = "خروج";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(426, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // accessPermissionTreeView
            // 
            this.accessPermissionTreeView.CheckBoxes = true;
            this.accessPermissionTreeView.Location = new System.Drawing.Point(6, 49);
            this.accessPermissionTreeView.Name = "accessPermissionTreeView";
            this.accessPermissionTreeView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.accessPermissionTreeView.RightToLeftLayout = true;
            this.accessPermissionTreeView.Size = new System.Drawing.Size(482, 353);
            this.accessPermissionTreeView.TabIndex = 2;
            // 
            // comboBoxUserRole
            // 
            this.comboBoxUserRole.DataSource = this.userRoleBindingSource;
            this.comboBoxUserRole.DisplayMember = "Name";
            this.comboBoxUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserRole.FormattingEnabled = true;
            this.comboBoxUserRole.Location = new System.Drawing.Point(175, 21);
            this.comboBoxUserRole.Name = "comboBoxUserRole";
            this.comboBoxUserRole.Size = new System.Drawing.Size(241, 22);
            this.comboBoxUserRole.TabIndex = 1;
            this.comboBoxUserRole.ValueMember = "Code";
            this.comboBoxUserRole.SelectedValueChanged += new System.EventHandler(this.ComboBoxUserRoleSelectedValueChanged);
            // 
            // userRoleBindingSource
            // 
            this.userRoleBindingSource.DataSource = typeof(NjitSoftware.Model.Common.UserRole);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "گروه کاربر:";
            // 
            // membershipBindingSource
            // 
            this.membershipBindingSource.DataSource = typeof(NjitSoftware.Model.Common.User);
            // 
            // UserSetPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 440);
            this.Name = "SetPermission";
            this.Text = "تنظیم سطح دسترسی کاربران";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membershipBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.ComboBoxExtended comboBoxUserRole;
        private Njit.Program.Controls.AccessPermissionTreeView accessPermissionTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource membershipBindingSource;
        private System.Windows.Forms.BindingSource userRoleBindingSource;
    }
}