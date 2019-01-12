namespace Njit.Controls
{
    partial class PictureSelectBox
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
                if (_DataStream != null)
                    _DataStream.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelete = new Program.Controls.ButtonExtended();
            this.btnSelect = new Program.Controls.ButtonExtended();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.myPictureBox = new Njit.Program.Controls.PictureBoxExtended();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(0, 152);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(163, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "حذف تصویر";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSelect.Location = new System.Drawing.Point(0, 129);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(163, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "انتخاب تصویر";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Images|*.jpg;*.bmp;*.png;*.tif|All Files|*.*\"";
            this.openFileDialog.Title = "انتخاب تصویر";
            // 
            // myPictureBox
            // 
            this.myPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPictureBox.Location = new System.Drawing.Point(0, 0);
            this.myPictureBox.Name = "myPictureBox";
            this.myPictureBox.Size = new System.Drawing.Size(163, 129);
            this.myPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myPictureBox.TabIndex = 0;
            this.myPictureBox.TabStop = false;
            this.myPictureBox.Click += new System.EventHandler(this.myPictureBox_Click);
            // 
            // PictureBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.myPictureBox);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnDelete);
            this.Name = "PictureSelectBox";
            this.Size = new System.Drawing.Size(163, 175);
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.PictureBoxExtended myPictureBox;
        private Njit.Program.Controls.ButtonExtended btnDelete;
        private Njit.Program.Controls.ButtonExtended btnSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
