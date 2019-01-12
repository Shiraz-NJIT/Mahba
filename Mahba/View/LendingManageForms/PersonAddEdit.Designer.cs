namespace NjitSoftware.View.LendingManageForms
{
    partial class PersonAddEdit
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
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(433, 116);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 116);
            this.panelCommand.Size = new System.Drawing.Size(433, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(nameLabel);
            this.groupBoxMain.Controls.Add(this.nameTextBox);
            this.groupBoxMain.Size = new System.Drawing.Size(413, 113);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(345, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(325, 48);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(25, 14);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "نام:";
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.Person);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.personBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(71, 45);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(248, 22);
            this.nameTextBox.TabIndex = 1;
            // 
            // PersonAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 145);
            this.Name = "PersonAddEdit";
            this.Text = "ثبت اطلاعات شخص";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingSource personBindingSource;
    }
}