namespace NjitSoftware.View
{
    partial class ScannerSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmResolation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.comboBoxImageType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = " پیش فرض:";
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.Location = new System.Drawing.Point(66, 34);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(187, 22);
            this.comboBoxSource.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = " خروجی:";
            // 
            // cmResolation
            // 
            this.cmResolation.FormattingEnabled = true;
            this.cmResolation.Items.AddRange(new object[] {
            "dpi 75 ",
            "dpi 100 ",
            "dpi 200 ",
            "dpi 300 ",
            "dpi 600 ",
            "dpi 1200 "});
            this.cmResolation.Location = new System.Drawing.Point(66, 116);
            this.cmResolation.Name = "cmResolation";
            this.cmResolation.Size = new System.Drawing.Size(187, 22);
            this.cmResolation.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "رزولیشن:";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(164, 154);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(89, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "ذخیره";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // comboBoxImageType
            // 
            this.comboBoxImageType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImageType.FormattingEnabled = true;
            this.comboBoxImageType.Location = new System.Drawing.Point(66, 70);
            this.comboBoxImageType.Name = "comboBoxImageType";
            this.comboBoxImageType.Size = new System.Drawing.Size(187, 22);
            this.comboBoxImageType.TabIndex = 16;
            // 
            // ScannerSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 190);
            this.Controls.Add(this.comboBoxImageType);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmResolation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSource);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScannerSetting";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تظیمات اسکنر سریع";
            this.Load += new System.EventHandler(this.ScannerSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmResolation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ComboBox comboBoxImageType;
    }
}