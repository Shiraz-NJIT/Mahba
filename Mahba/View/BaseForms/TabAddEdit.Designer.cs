namespace NjitSoftware.View.BaseForms
{
    partial class TabAddEdit
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
            this.txtGroupName = new Njit.Program.Controls.TextBoxExtended();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(434, 107);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 107);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Controls.Add(this.txtGroupName);
            this.groupBoxMain.Size = new System.Drawing.Size(414, 104);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Text = "ایجاد";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(28, 39);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(266, 22);
            this.txtGroupName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام گروه اطلاعاتی:";
            // 
            // TabAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 136);
            this.Name = "TabAddEdit";
            this.Text = "ثبت و ویرایش گروه اطلاعاتی";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected Njit.Program.Controls.TextBoxExtended txtGroupName;
    }
}