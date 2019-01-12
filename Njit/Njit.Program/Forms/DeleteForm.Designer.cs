namespace Njit.Program.Forms
{
    partial class DeleteForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnCancel = new Njit.Program.Controls.ButtonExtended();
            this.btnDelete = new Njit.Program.Controls.ButtonExtended();
            this.listView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCommand.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(49, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(390, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "از حذف اطلاعات زیر اطمینان دارید؟";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnCancel);
            this.panelCommand.Controls.Add(this.btnDelete);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(10, 170);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.panelCommand.Size = new System.Drawing.Size(440, 29);
            this.panelCommand.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(246, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "خیر";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(321, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "بله";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Location = new System.Drawing.Point(10, 60);
            this.listView.Name = "listView";
            this.listView.RightToLeftLayout = true;
            this.listView.Size = new System.Drawing.Size(440, 110);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(440, 50);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Njit.Program.Properties.Resources.AlertIcon;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // DeleteForm
            // 
            this.AllowCheckAccessPermission = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(460, 199);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCommand);
            this.Name = "DeleteForm";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.Text = "حذف اطلاعات";
            this.panelCommand.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Panel panelCommand;
        public System.Windows.Forms.ListView listView;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public Controls.ButtonExtended btnCancel;
        protected Controls.ButtonExtended btnDelete;

    }
}