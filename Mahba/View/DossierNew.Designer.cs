namespace NjitSoftware.View
{
    partial class DossierNew
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBoxComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressViewBindingSource)).BeginInit();
            this.panelCommand.SuspendLayout();
            this.PnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlExtended
            // 
            this.tabControlExtended.Size = new System.Drawing.Size(813, 547);
            // 
            // btnSaveDossier
            // 
            this.btnSaveDossier.Location = new System.Drawing.Point(12, 269);
            this.btnSaveDossier.Size = new System.Drawing.Size(120, 39);
            this.btnSaveDossier.TabIndex = 1;
            this.btnSaveDossier.Click += new System.EventHandler(this.btnSaveDossier_Click);
            // 
            // btnNewDossier
            // 
            this.btnNewDossier.Image = global::NjitSoftware.Properties.Resources.DossierNew;
            this.btnNewDossier.TabIndex = 0;
            this.btnNewDossier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewDossier.Click += new System.EventHandler(this.btnNewDossier_Click);
            // 
            // btnImportFiles
            // 
            this.btnImportFiles.Location = new System.Drawing.Point(12, 318);
            this.btnImportFiles.Size = new System.Drawing.Size(120, 69);
            // 
            // btnShowDocuments
            // 
            this.btnShowDocuments.Location = new System.Drawing.Point(12, 390);
            // 
            // label1
            // 
            this.label1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.TabIndex = 6;
            // 
            // dossierTypeComboBoxExtended
            // 
            this.dossierTypeComboBoxExtended.Size = new System.Drawing.Size(115, 22);
            this.dossierTypeComboBoxExtended.TabIndex = 7;
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(10, 550);
            // 
            // txtDocumentsCount
            // 
            this.txtDocumentsCount.TabIndex = 9;
            // 
            // areaComboBoxExtended
            // 
            this.areaComboBoxExtended.Size = new System.Drawing.Size(103, 22);
            // 
            // provinceComboBoxExtended
            // 
            this.provinceComboBoxExtended.Size = new System.Drawing.Size(121, 22);
            // 
            // PnlLeft
            // 
            this.PnlLeft.Size = new System.Drawing.Size(143, 547);
            // 
            // label8
            // 
            this.label8.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 311);
            this.label2.TabIndex = 2;
            // 
            // DossierNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 579);
            this.Name = "DossierNew";
            this.Text = "ایجاد پرونده";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBoxComment.ResumeLayout(false);
            this.groupBoxComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressViewBindingSource)).EndInit();
            this.panelCommand.ResumeLayout(false);
            this.PnlLeft.ResumeLayout(false);
            this.PnlLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

    }
}