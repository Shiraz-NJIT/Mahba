namespace Njit.Program.Forms
{
    partial class ComboBoxEditItemsEdit
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
            this.textBox = new Njit.Program.Controls.TextBoxExtended();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(382, 97);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 97);
            this.panelCommand.Size = new System.Drawing.Size(382, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.textBox);
            this.groupBoxMain.Size = new System.Drawing.Size(362, 94);
            // 
            // btnCancel
            // 
            this.btnCancel.AllowCheckAccessPermission = false;
            this.btnCancel.Location = new System.Drawing.Point(219, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AllowCheckAccessPermission = false;
            this.btnOK.Location = new System.Drawing.Point(294, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(36, 33);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(288, 22);
            this.textBox.TabIndex = 0;
            // 
            // ComboBoxEditItemsEdit
            // 
            this.AllowCheckAccessPermission = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 126);
            this.Name = "ComboBoxEditItemsEdit";
            this.Text = "اصلاح...";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TextBoxExtended textBox;
    }
}