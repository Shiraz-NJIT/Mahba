namespace NjitSoftware.View.ArchiveManageForms
{
    partial class ArchiveAdd
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonSaveDocsToFile = new System.Windows.Forms.RadioButton();
            this.radioButtonSaveDocsToDatabase = new System.Windows.Forms.RadioButton();
            this.browseButtonDocument = new Njit.Program.Controls.BrowseButton();
            this.txtDocumentsPath = new Njit.Program.Controls.TextBoxExtended();
            this.lblDocumentsPath = new System.Windows.Forms.Label();
            this.groupBoxDatabasePath = new System.Windows.Forms.GroupBox();
            this.browseButtonDatabase = new Njit.Program.Controls.BrowseButton();
            this.txtDatabasePath = new Njit.Program.Controls.TextBoxExtended();
            this.label4 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBoxDatabasePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(737, 207);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 207);
            this.panelCommand.Size = new System.Drawing.Size(737, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.groupBox3);
            this.groupBoxMain.Controls.Add(this.groupBoxDatabasePath);
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.groupBoxMain.Size = new System.Drawing.Size(717, 204);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(574, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(649, 3);
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonSaveDocsToFile);
            this.groupBox3.Controls.Add(this.radioButtonSaveDocsToDatabase);
            this.groupBox3.Controls.Add(this.browseButtonDocument);
            this.groupBox3.Controls.Add(this.txtDocumentsPath);
            this.groupBox3.Controls.Add(this.lblDocumentsPath);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(10, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(697, 96);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "مسیر ذخیره اسناد";
            // 
            // radioButtonSaveDocsToFile
            // 
            this.radioButtonSaveDocsToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSaveDocsToFile.AutoSize = true;
            this.radioButtonSaveDocsToFile.Location = new System.Drawing.Point(237, 21);
            this.radioButtonSaveDocsToFile.Name = "radioButtonSaveDocsToFile";
            this.radioButtonSaveDocsToFile.Size = new System.Drawing.Size(178, 18);
            this.radioButtonSaveDocsToFile.TabIndex = 1;
            this.radioButtonSaveDocsToFile.Text = "اسناد بر روی فایل ذخیره شوند";
            this.radioButtonSaveDocsToFile.UseVisualStyleBackColor = true;
            this.radioButtonSaveDocsToFile.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSaveDocsToDatabase
            // 
            this.radioButtonSaveDocsToDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSaveDocsToDatabase.AutoSize = true;
            this.radioButtonSaveDocsToDatabase.Checked = true;
            this.radioButtonSaveDocsToDatabase.Location = new System.Drawing.Point(421, 21);
            this.radioButtonSaveDocsToDatabase.Name = "radioButtonSaveDocsToDatabase";
            this.radioButtonSaveDocsToDatabase.Size = new System.Drawing.Size(208, 18);
            this.radioButtonSaveDocsToDatabase.TabIndex = 0;
            this.radioButtonSaveDocsToDatabase.TabStop = true;
            this.radioButtonSaveDocsToDatabase.Text = "اسناد بر روی پایگاه داده ذخیره شوند";
            this.radioButtonSaveDocsToDatabase.UseVisualStyleBackColor = true;
            this.radioButtonSaveDocsToDatabase.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // browseButtonDocument
            // 
            this.browseButtonDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButtonDocument.Description = "مسیر ذخیره اسناد";
            this.browseButtonDocument.Location = new System.Drawing.Point(13, 51);
            this.browseButtonDocument.Name = "browseButtonDocument";
            this.browseButtonDocument.PathControl = this.txtDocumentsPath;
            this.browseButtonDocument.Size = new System.Drawing.Size(109, 23);
            this.browseButtonDocument.TabIndex = 4;
            this.browseButtonDocument.Text = "انتخاب مسیر...";
            this.browseButtonDocument.UseVisualStyleBackColor = true;
            // 
            // txtDocumentsPath
            // 
            this.txtDocumentsPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentsPath.Location = new System.Drawing.Point(128, 52);
            this.txtDocumentsPath.Name = "txtDocumentsPath";
            this.txtDocumentsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDocumentsPath.Size = new System.Drawing.Size(364, 22);
            this.txtDocumentsPath.TabIndex = 3;
            // 
            // lblDocumentsPath
            // 
            this.lblDocumentsPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocumentsPath.AutoSize = true;
            this.lblDocumentsPath.Location = new System.Drawing.Point(498, 55);
            this.lblDocumentsPath.Name = "lblDocumentsPath";
            this.lblDocumentsPath.Size = new System.Drawing.Size(160, 14);
            this.lblDocumentsPath.TabIndex = 2;
            this.lblDocumentsPath.Text = "مسیر ذخیره پایگاه داده اسناد:";
            // 
            // groupBoxDatabasePath
            // 
            this.groupBoxDatabasePath.Controls.Add(this.browseButtonDatabase);
            this.groupBoxDatabasePath.Controls.Add(this.label4);
            this.groupBoxDatabasePath.Controls.Add(this.txtDatabasePath);
            this.groupBoxDatabasePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDatabasePath.Location = new System.Drawing.Point(10, 18);
            this.groupBoxDatabasePath.Name = "groupBoxDatabasePath";
            this.groupBoxDatabasePath.Size = new System.Drawing.Size(697, 74);
            this.groupBoxDatabasePath.TabIndex = 0;
            this.groupBoxDatabasePath.TabStop = false;
            this.groupBoxDatabasePath.Text = "مسیر ذخیره فایل های پایگاه داده";
            // 
            // browseButtonDatabase
            // 
            this.browseButtonDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButtonDatabase.Description = "مسیر ذخیره فایل های پایگاه داده";
            this.browseButtonDatabase.Location = new System.Drawing.Point(13, 25);
            this.browseButtonDatabase.Name = "browseButtonDatabase";
            this.browseButtonDatabase.PathControl = this.txtDatabasePath;
            this.browseButtonDatabase.Size = new System.Drawing.Size(109, 23);
            this.browseButtonDatabase.TabIndex = 2;
            this.browseButtonDatabase.Text = "انتخاب مسیر...";
            this.browseButtonDatabase.UseVisualStyleBackColor = true;
            // 
            // txtDatabasePath
            // 
            this.txtDatabasePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabasePath.Location = new System.Drawing.Point(128, 26);
            this.txtDatabasePath.Name = "txtDatabasePath";
            this.txtDatabasePath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDatabasePath.Size = new System.Drawing.Size(364, 22);
            this.txtDatabasePath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "مسیر ذخیره فایل های پایگاه داده:";
            // 
            // ArchiveAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 236);
            this.Name = "ArchiveAdd";
            this.Text = "افزودن بایگانی";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxDatabasePath.ResumeLayout(false);
            this.groupBoxDatabasePath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonSaveDocsToFile;
        private System.Windows.Forms.RadioButton radioButtonSaveDocsToDatabase;
        private Njit.Program.Controls.BrowseButton browseButtonDocument;
        private Njit.Program.Controls.TextBoxExtended txtDocumentsPath;
        private System.Windows.Forms.Label lblDocumentsPath;
        private System.Windows.Forms.GroupBox groupBoxDatabasePath;
        private Njit.Program.Controls.BrowseButton browseButtonDatabase;
        private Njit.Program.Controls.TextBoxExtended txtDatabasePath;
        private System.Windows.Forms.Label label4;
    }
}