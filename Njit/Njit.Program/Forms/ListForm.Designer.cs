namespace Njit.Program.Forms
{
    partial class ListForm
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
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnExit = new Njit.Program.Controls.ButtonExtended();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnExit);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 333);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.panelCommand.Size = new System.Drawing.Size(584, 29);
            this.panelCommand.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.Location = new System.Drawing.Point(13, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.panelMain.Size = new System.Drawing.Size(584, 333);
            this.panelMain.TabIndex = 4;
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelCommand);
            this.Name = "ListForm";
            this.panelCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelCommand;
        public Controls.ButtonExtended btnExit;
        public System.Windows.Forms.Panel panelMain;
    }
}