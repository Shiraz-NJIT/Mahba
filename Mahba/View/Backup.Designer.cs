namespace NjitSoftware.View
{
    partial class Backup
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
            this.commandLinkSchedule = new Njit.MessageBox.CommandLink();
            this.panelButtons.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Location = new System.Drawing.Point(10, 163);
            this.panelButtons.Size = new System.Drawing.Size(504, 29);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(323, 3);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(398, 3);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.commandLinkSchedule);
            this.groupBox.Size = new System.Drawing.Size(504, 160);
            this.groupBox.Controls.SetChildIndex(this.lblBackupPath, 0);
            this.groupBox.Controls.SetChildIndex(this.lblBackupName, 0);
            this.groupBox.Controls.SetChildIndex(this.checkBoxAuto, 0);
            this.groupBox.Controls.SetChildIndex(this.txtBackupPath, 0);
            this.groupBox.Controls.SetChildIndex(this.btnBrowse, 0);
            this.groupBox.Controls.SetChildIndex(this.txtBackupName, 0);
            this.groupBox.Controls.SetChildIndex(this.commandLinkSchedule, 0);
            // 
            // commandLinkSchedule
            // 
            this.commandLinkSchedule.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.commandLinkSchedule.Location = new System.Drawing.Point(126, 102);
            this.commandLinkSchedule.Name = "commandLinkSchedule";
            this.commandLinkSchedule.Size = new System.Drawing.Size(287, 41);
            this.commandLinkSchedule.TabIndex = 6;
            this.commandLinkSchedule.TabStop = false;
            this.commandLinkSchedule.Text = "تنظیم زمان بندی برای پشتیبان گیری";
            this.commandLinkSchedule.Click += new System.EventHandler(this.commandLinkSchedule_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 192);
            this.FileName = "1392-04-05 15-26-24";
            this.Name = "Backup";
            this.panelButtons.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.MessageBox.CommandLink commandLinkSchedule;
    }
}