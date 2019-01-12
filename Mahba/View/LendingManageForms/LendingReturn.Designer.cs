namespace NjitSoftware.View.LendingManageForms
{
    partial class LendingReturn
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
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label timeLabel;
            this.lblTitle = new System.Windows.Forms.Label();
            this.dateDateControl = new Njit.Program.Controls.DateControl();
            this.timeTimeControl = new Njit.Program.Controls.TimeControl();
            this.groupBoxDossier = new NjitSoftware.View.Controls.DossierInfo();
            dateLabel = new System.Windows.Forms.Label();
            timeLabel = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(596, 193);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 193);
            this.panelCommand.Size = new System.Drawing.Size(596, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(dateLabel);
            this.groupBoxMain.Controls.Add(this.dateDateControl);
            this.groupBoxMain.Controls.Add(timeLabel);
            this.groupBoxMain.Controls.Add(this.timeTimeControl);
            this.groupBoxMain.Controls.Add(this.groupBoxDossier);
            this.groupBoxMain.Controls.Add(this.lblTitle);
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.groupBoxMain.Size = new System.Drawing.Size(576, 190);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(433, 3);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(508, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dateLabel
            // 
            dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(480, 147);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(78, 14);
            dateLabel.TabIndex = 2;
            dateLabel.Text = "تاریخ بازگشت:";
            // 
            // timeLabel
            // 
            timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            timeLabel.AutoSize = true;
            timeLabel.Location = new System.Drawing.Point(278, 147);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(90, 14);
            timeLabel.TabIndex = 4;
            timeLabel.Text = "ساعت بازگشت:";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(10, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(556, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "مشخصات پرونده:";
            // 
            // dateDateControl
            // 
            this.dateDateControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDateControl.Location = new System.Drawing.Point(374, 144);
            this.dateDateControl.Name = "dateDateControl";
            this.dateDateControl.Size = new System.Drawing.Size(100, 22);
            this.dateDateControl.TabIndex = 3;
            // 
            // timeTimeControl
            // 
            this.timeTimeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTimeControl.Location = new System.Drawing.Point(202, 144);
            this.timeTimeControl.Name = "timeTimeControl";
            this.timeTimeControl.Size = new System.Drawing.Size(70, 22);
            this.timeTimeControl.TabIndex = 5;
            // 
            // groupBoxDossier
            // 
            this.groupBoxDossier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupBoxDossier.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDossier.Location = new System.Drawing.Point(10, 38);
            this.groupBoxDossier.Name = "groupBoxDossier";
            this.groupBoxDossier.Size = new System.Drawing.Size(556, 92);
            this.groupBoxDossier.TabIndex = 1;
            // 
            // LendingReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 222);
            this.Name = "LendingReturn";
            this.Text = "بازگشت امانت";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DossierInfo groupBoxDossier;
        private System.Windows.Forms.Label lblTitle;
        private Njit.Program.Controls.DateControl dateDateControl;
        private Njit.Program.Controls.TimeControl timeTimeControl;
    }
}