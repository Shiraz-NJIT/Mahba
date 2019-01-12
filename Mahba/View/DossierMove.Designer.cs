namespace NjitSoftware.View
{
    partial class DossierMove
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDossier1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArchive1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmArchive = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDossier2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(769, 119);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 119);
            this.panelCommand.Size = new System.Drawing.Size(769, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label6);
            this.groupBoxMain.Controls.Add(this.txtDossier2);
            this.groupBoxMain.Controls.Add(this.label5);
            this.groupBoxMain.Controls.Add(this.cmArchive);
            this.groupBoxMain.Controls.Add(this.label4);
            this.groupBoxMain.Controls.Add(this.txtArchive1);
            this.groupBoxMain.Controls.Add(this.label2);
            this.groupBoxMain.Controls.Add(this.txtDossier1);
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Size = new System.Drawing.Size(749, 116);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(606, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(681, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "پرونده ای با شماره :";
            // 
            // txtDossier1
            // 
            this.txtDossier1.Location = new System.Drawing.Point(452, 29);
            this.txtDossier1.Name = "txtDossier1";
            this.txtDossier1.Size = new System.Drawing.Size(180, 22);
            this.txtDossier1.TabIndex = 1;
            this.txtDossier1.Leave += new System.EventHandler(this.txtDossier1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "از بایگانی:  ";
            // 
            // txtArchive1
            // 
            this.txtArchive1.Location = new System.Drawing.Point(125, 29);
            this.txtArchive1.Name = "txtArchive1";
            this.txtArchive1.ReadOnly = true;
            this.txtArchive1.Size = new System.Drawing.Size(225, 22);
            this.txtArchive1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "به بایگانی :";
            // 
            // cmArchive
            // 
            this.cmArchive.FormattingEnabled = true;
            this.cmArchive.Location = new System.Drawing.Point(452, 79);
            this.cmArchive.Name = "cmArchive";
            this.cmArchive.Size = new System.Drawing.Size(180, 22);
            this.cmArchive.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "با شماره پرونده:";
            // 
            // txtDossier2
            // 
            this.txtDossier2.Location = new System.Drawing.Point(125, 79);
            this.txtDossier2.Name = "txtDossier2";
            this.txtDossier2.Size = new System.Drawing.Size(225, 22);
            this.txtDossier2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "انتقال پبدا کند .";
            // 
            // DossierMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 148);
            this.Name = "DossierMove";
            this.Text = "انتفال پرونده";
            this.Load += new System.EventHandler(this.DossierMove_Load);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmArchive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArchive1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDossier1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDossier2;
        private System.Windows.Forms.Label label5;
    }
}