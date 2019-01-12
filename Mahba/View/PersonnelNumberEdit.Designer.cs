namespace NjitSoftware.View
{
    partial class PersonnelNumberEdit
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.textBox = new Njit.Program.Controls.TextBoxExtended();
            this.textBoxLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(417, 146);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 146);
            this.panelCommand.Size = new System.Drawing.Size(417, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.textBox);
            this.groupBoxMain.Controls.Add(this.textBoxLabel);
            this.groupBoxMain.Controls.Add(this.lblTitle);
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxMain.Size = new System.Drawing.Size(397, 143);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(254, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(329, 3);
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(10, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(377, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "شماره پرونده:";
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox.Location = new System.Drawing.Point(10, 100);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(377, 22);
            this.textBox.TabIndex = 1;
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxLabel.Location = new System.Drawing.Point(10, 77);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(377, 23);
            this.textBoxLabel.TabIndex = 2;
            this.textBoxLabel.Text = "شماره پرونده جدید:";
            // 
            // PersonnelNumberEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 175);
            this.Name = "PersonnelNumberEdit";
            this.Text = "ویرایش شماره پرونده";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.TextBoxExtended textBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label textBoxLabel;
    }
}