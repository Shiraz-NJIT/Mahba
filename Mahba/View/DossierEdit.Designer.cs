namespace NjitSoftware.View
{
    partial class DossierEdit
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
            this.btnEditPersonnelNumber = new Njit.Program.Controls.ButtonExtended();
            this.buttonExtended1 = new Njit.Program.Controls.ButtonExtended();
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
            this.tabControlExtended.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabControlExtended.ItemSize = new System.Drawing.Size(92, 21);
            this.tabControlExtended.Multiline = true;
            this.tabControlExtended.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControlExtended.Size = new System.Drawing.Size(813, 582);
            // 
            // btnSaveDossier
            // 
            this.btnSaveDossier.Location = new System.Drawing.Point(13, 317);
            this.btnSaveDossier.TabIndex = 3;
            this.btnSaveDossier.Click += new System.EventHandler(this.btnSaveDossier_Click);
            // 
            // btnNewDossier
            // 
            this.btnNewDossier.Click += new System.EventHandler(this.btnNewDossier_Click);
            // 
            // btnImportFiles
            // 
            this.btnImportFiles.Enabled = false;
            this.btnImportFiles.Location = new System.Drawing.Point(13, 414);
            this.btnImportFiles.TabIndex = 5;
            // 
            // btnShowDocuments
            // 
            this.btnShowDocuments.Enabled = false;
            this.btnShowDocuments.Location = new System.Drawing.Point(13, 359);
            this.btnShowDocuments.Size = new System.Drawing.Size(120, 54);
            this.btnShowDocuments.TabIndex = 6;
            this.btnShowDocuments.Text = "ثبت و مشاهده اسناد";
            this.btnShowDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(7, 21);
            this.txtComment.Size = new System.Drawing.Size(771, 72);
            // 
            // txtWebsite
            // 
            this.txtWebsite.Size = new System.Drawing.Size(226, 23);
            // 
            // txtEmail
            // 
            this.txtEmail.Size = new System.Drawing.Size(226, 23);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 539);
            this.label1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(63, 495);
            this.label3.TabIndex = 8;
            // 
            // dossierTypeComboBoxExtended
            // 
            this.dossierTypeComboBoxExtended.Location = new System.Drawing.Point(13, 515);
            this.dossierTypeComboBoxExtended.Size = new System.Drawing.Size(120, 22);
            this.dossierTypeComboBoxExtended.TabIndex = 9;
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(10, 585);
            // 
            // txtDocumentsCount
            // 
            this.txtDocumentsCount.Location = new System.Drawing.Point(12, 555);
            this.txtDocumentsCount.Size = new System.Drawing.Size(120, 22);
            this.txtDocumentsCount.TabIndex = 11;
            // 
            // areaComboBoxExtended
            // 
            this.areaComboBoxExtended.Size = new System.Drawing.Size(103, 24);
            // 
            // provinceComboBoxExtended
            // 
            this.provinceComboBoxExtended.Size = new System.Drawing.Size(121, 24);
            // 
            // PnlLeft
            // 
            this.PnlLeft.Controls.Add(this.buttonExtended1);
            this.PnlLeft.Controls.Add(this.btnEditPersonnelNumber);
            this.PnlLeft.Size = new System.Drawing.Size(143, 582);
            this.PnlLeft.Controls.SetChildIndex(this.label2, 0);
            this.PnlLeft.Controls.SetChildIndex(this.label8, 0);
            this.PnlLeft.Controls.SetChildIndex(this.btnImportFiles, 0);
            this.PnlLeft.Controls.SetChildIndex(this.btnNewDossier, 0);
            this.PnlLeft.Controls.SetChildIndex(this.btnSaveDossier, 0);
            this.PnlLeft.Controls.SetChildIndex(this.btnShowDocuments, 0);
            this.PnlLeft.Controls.SetChildIndex(this.dossierTypeComboBoxExtended, 0);
            this.PnlLeft.Controls.SetChildIndex(this.label1, 0);
            this.PnlLeft.Controls.SetChildIndex(this.label3, 0);
            this.PnlLeft.Controls.SetChildIndex(this.txtDocumentsCount, 0);
            this.PnlLeft.Controls.SetChildIndex(this.btnEditPersonnelNumber, 0);
            this.PnlLeft.Controls.SetChildIndex(this.buttonExtended1, 0);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 474);
            this.label8.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 369);
            this.label2.TabIndex = 4;
            // 
            // btnEditPersonnelNumber
            // 
            this.btnEditPersonnelNumber.Location = new System.Drawing.Point(13, 281);
            this.btnEditPersonnelNumber.Name = "btnEditPersonnelNumber";
            this.btnEditPersonnelNumber.Size = new System.Drawing.Size(120, 34);
            this.btnEditPersonnelNumber.TabIndex = 2;
            this.btnEditPersonnelNumber.Text = "ویرایش شماره پرونده";
            this.btnEditPersonnelNumber.UseVisualStyleBackColor = true;
            this.btnEditPersonnelNumber.Click += new System.EventHandler(this.btnEditPersonnelNumber_Click);
            // 
            // buttonExtended1
            // 
            this.buttonExtended1.Image = global::NjitSoftware.Properties.Resources.NewDossier;
            this.buttonExtended1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonExtended1.Location = new System.Drawing.Point(13, 459);
            this.buttonExtended1.Name = "buttonExtended1";
            this.buttonExtended1.Size = new System.Drawing.Size(120, 34);
            this.buttonExtended1.TabIndex = 12;
            this.buttonExtended1.Text = "ایجاد پرونده";
            this.buttonExtended1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExtended1.UseVisualStyleBackColor = true;
            this.buttonExtended1.Click += new System.EventHandler(this.buttonExtended1_Click);
            // 
            // DossierEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 614);
            this.Name = "DossierEdit";
            this.Text = "مشاهده پرونده";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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

        private Njit.Program.Controls.ButtonExtended btnEditPersonnelNumber;
        private Njit.Program.Controls.ButtonExtended buttonExtended1;
    }
}