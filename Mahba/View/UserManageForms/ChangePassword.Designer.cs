namespace NjitSoftware.View.UserManageForms
{
    partial class ChangePassword
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
            this.txtCurrent = new Njit.Program.Controls.TextBoxExtended();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtConfirm = new Njit.Program.Controls.TextBoxExtended();
            this.lblNew = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtNew = new Njit.Program.Controls.TextBoxExtended();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(369, 137);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 137);
            this.panelCommand.Size = new System.Drawing.Size(369, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Size = new System.Drawing.Size(349, 134);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(206, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(281, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(33, 25);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(223, 22);
            this.txtCurrent.TabIndex = 7;
            this.txtCurrent.UseSystemPasswordChar = true;
            this.txtCurrent.WaterMark = "رمزعبور فعلی را اینجا وارد کنید";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(262, 28);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(81, 14);
            this.lblCurrent.TabIndex = 6;
            this.lblCurrent.Text = "رمز عبور فعلی:";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(33, 83);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(223, 22);
            this.txtConfirm.TabIndex = 11;
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.WaterMark = "رمزعبور جدید را مجددا وارد کنید";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(262, 57);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(79, 14);
            this.lblNew.TabIndex = 8;
            this.lblNew.Text = "رمز عبور جدید:";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(262, 86);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(75, 14);
            this.lblConfirm.TabIndex = 10;
            this.lblConfirm.Text = "تکرار رمز عبور:";
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(33, 54);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(223, 22);
            this.txtNew.TabIndex = 9;
            this.txtNew.UseSystemPasswordChar = true;
            this.txtNew.WaterMark = "رمزعبور جدید را اینجا وارد کنید";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 166);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtNew);
            this.Name = "ChangePassword";
            this.RightToLeftLayout = false;
            this.Text = "تغییر رمز عبور پنل کاربری";
            this.Controls.SetChildIndex(this.panelCommand, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.Controls.SetChildIndex(this.txtNew, 0);
            this.Controls.SetChildIndex(this.lblConfirm, 0);
            this.Controls.SetChildIndex(this.lblNew, 0);
            this.Controls.SetChildIndex(this.txtConfirm, 0);
            this.Controls.SetChildIndex(this.lblCurrent, 0);
            this.Controls.SetChildIndex(this.txtCurrent, 0);
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Njit.Program.Controls.TextBoxExtended txtCurrent;
        protected System.Windows.Forms.Label lblCurrent;
        protected Njit.Program.Controls.TextBoxExtended txtConfirm;
        protected System.Windows.Forms.Label lblNew;
        protected System.Windows.Forms.Label lblConfirm;
        protected Njit.Program.Controls.TextBoxExtended txtNew;
    }
}