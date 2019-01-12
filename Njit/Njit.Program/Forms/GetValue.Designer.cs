namespace Njit.Program.Forms
{
    partial class GetValue
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
            this.txtName = new Njit.Program.Controls.TextBoxExtended();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(422, 140);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 140);
            this.panelCommand.Size = new System.Drawing.Size(422, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.lblTitle);
            this.groupBoxMain.Controls.Add(this.txtName);
            this.groupBoxMain.Size = new System.Drawing.Size(402, 137);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(259, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(334, 3);
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(28, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(338, 22);
            this.txtName.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(28, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(341, 44);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GetValue
            // 
            this.AllowCheckAccessPermission = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 169);
            this.Name = "GetValue";
            this.Text = "";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.TextBoxExtended txtName;
        private System.Windows.Forms.Label lblTitle;
    }
}