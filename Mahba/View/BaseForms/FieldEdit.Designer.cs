namespace NjitSoftware.View.BaseForms
{
    partial class FieldEdit
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
            this.fieldInfo = new NjitSoftware.View.Controls.FieldInfo();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(786, 143);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 143);
            this.panelCommand.Size = new System.Drawing.Size(786, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.fieldInfo);
            this.groupBoxMain.Size = new System.Drawing.Size(766, 140);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(623, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(698, 3);
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fieldInfo
            // 
            this.fieldInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.fieldInfo.Location = new System.Drawing.Point(10, 21);
            this.fieldInfo.Name = "fieldInfo";
            this.fieldInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fieldInfo.Size = new System.Drawing.Size(750, 113);
            this.fieldInfo.TabIndex = 0;
            // 
            // FieldEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 172);
            this.Name = "FieldEdit";
            this.Text = "اصلاح فیلد";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FieldInfo fieldInfo;

    }
}