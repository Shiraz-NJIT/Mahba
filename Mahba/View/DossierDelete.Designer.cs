namespace NjitSoftware.View
{
    partial class DossierDelete
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
            this.groupBoxDossier = new NjitSoftware.View.Controls.DossierInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(602, 168);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 168);
            this.panelCommand.Size = new System.Drawing.Size(602, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Controls.Add(this.groupBoxDossier);
            this.groupBoxMain.Size = new System.Drawing.Size(582, 165);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(335, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(410, 3);
            this.btnOK.Size = new System.Drawing.Size(179, 23);
            this.btnOK.Text = "حذف پرونده و تمام اسناد آن";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBoxDossier
            // 
            this.groupBoxDossier.Location = new System.Drawing.Point(6, 44);
            this.groupBoxDossier.Name = "groupBoxDossier";
            this.groupBoxDossier.Size = new System.Drawing.Size(567, 112);
            this.groupBoxDossier.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "از حذف پرونده با مشخصات زیر اطمینان دارید؟";
            // 
            // DossierDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 197);
            this.Name = "DossierDelete";
            this.Text = "حذف پرونده";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.DossierInfo groupBoxDossier;
    }
}