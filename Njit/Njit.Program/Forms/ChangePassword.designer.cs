namespace Njit.Program.Forms
{
    partial class ChangePassword
    {
        /// <summary>
        /// ReqFormsred designer variable.
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
        /// ReqFormsred method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new Njit.Program.Controls.ButtonExtended();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrent = new Njit.Program.Controls.TextBoxExtended();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNew = new Njit.Program.Controls.TextBoxExtended();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new Njit.Program.Controls.TextBoxExtended();
            this.btnOk = new Njit.Program.Controls.ButtonExtended();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.groupBoxMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Location = new System.Drawing.Point(232, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "انصراف";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(287, 24);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(81, 14);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "رمز عبور فعلی:";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(58, 21);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(223, 22);
            this.txtCurrent.TabIndex = 1;
            this.txtCurrent.UseSystemPasswordChar = true;
            this.txtCurrent.WaterMark = "رمزعبور فعلی را اینجا وارد کنید";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(287, 53);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(79, 14);
            this.lblNew.TabIndex = 2;
            this.lblNew.Text = "رمز عبور جدید:";
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(58, 50);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(223, 22);
            this.txtNew.TabIndex = 3;
            this.txtNew.UseSystemPasswordChar = true;
            this.txtNew.WaterMark = "رمزعبور جدید را اینجا وارد کنید";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(287, 82);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(75, 14);
            this.lblConfirm.TabIndex = 4;
            this.lblConfirm.Text = "تکرار رمز عبور:";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(58, 79);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(223, 22);
            this.txtConfirm.TabIndex = 5;
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.WaterMark = "رمزعبور جدید را مجددا وارد کنید";
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(319, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "ثبت";
            this.btnOk.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.txtCurrent);
            this.groupBoxMain.Controls.Add(this.lblCurrent);
            this.groupBoxMain.Controls.Add(this.txtConfirm);
            this.groupBoxMain.Controls.Add(this.lblNew);
            this.groupBoxMain.Controls.Add(this.lblConfirm);
            this.groupBoxMain.Controls.Add(this.txtNew);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Location = new System.Drawing.Point(12, 0);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(409, 126);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnExit);
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(12, 126);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(3);
            this.panelButtons.Size = new System.Drawing.Size(409, 29);
            this.panelButtons.TabIndex = 1;
            // 
            // ChangePassword
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(433, 155);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.panelButtons);
            this.Name = "ChangePassword";
            this.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.Text = "تغییر رمز عبور";
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Njit.Program.Controls.ButtonExtended btnExit;
        protected System.Windows.Forms.Label lblCurrent;
        protected Njit.Program.Controls.TextBoxExtended txtCurrent;
        protected System.Windows.Forms.Label lblNew;
        protected Njit.Program.Controls.TextBoxExtended txtNew;
        protected System.Windows.Forms.Label lblConfirm;
        protected Njit.Program.Controls.TextBoxExtended txtConfirm;
        protected Njit.Program.Controls.ButtonExtended btnOk;
        protected System.Windows.Forms.GroupBox groupBoxMain;
        protected System.Windows.Forms.Panel panelButtons;

    }
}