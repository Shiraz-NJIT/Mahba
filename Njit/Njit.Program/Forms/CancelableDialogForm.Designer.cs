namespace Njit.Program.Forms
{
    partial class CancelableDialogForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnCancel = new Njit.Program.Controls.ButtonExtended();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 0);
            this.panelMain.Size = new System.Drawing.Size(434, 173);
            this.panelMain.TabIndex = 0;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Location = new System.Drawing.Point(10, 3);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(414, 170);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnCancel);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 173);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.panelCommand.Size = new System.Drawing.Size(434, 29);
            this.panelCommand.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(346, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.RightToLeft = true;
            // 
            // CancelableDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 202);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelCommand);
            this.Name = "CancelableDialogForm";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelMain;
        protected System.Windows.Forms.Panel panelCommand;
        protected System.Windows.Forms.GroupBox groupBoxMain;
        protected Njit.Program.Controls.ButtonExtended btnCancel;
        protected System.Windows.Forms.ErrorProvider errorProvider;

    }
}