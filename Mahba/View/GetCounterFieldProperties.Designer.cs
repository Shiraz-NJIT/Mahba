namespace NjitSoftware.View
{
    partial class GetCounterFieldProperties
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
            this.radioButtonUserCurrentYear = new System.Windows.Forms.RadioButton();
            this.radioButtonUseFixedValue = new System.Windows.Forms.RadioButton();
            this.txtFixedValue = new System.Windows.Forms.TextBox();
            this.radioButtonDontUserFixedValue = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(445, 201);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 201);
            this.panelCommand.Size = new System.Drawing.Size(445, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.groupBox1);
            this.groupBoxMain.Controls.Add(this.txtSeparator);
            this.groupBoxMain.Controls.Add(this.label2);
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.groupBoxMain.Size = new System.Drawing.Size(425, 198);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(282, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(357, 3);
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // radioButtonUserCurrentYear
            // 
            this.radioButtonUserCurrentYear.AutoSize = true;
            this.radioButtonUserCurrentYear.Checked = true;
            this.radioButtonUserCurrentYear.Location = new System.Drawing.Point(41, 22);
            this.radioButtonUserCurrentYear.Name = "radioButtonUserCurrentYear";
            this.radioButtonUserCurrentYear.Size = new System.Drawing.Size(333, 18);
            this.radioButtonUserCurrentYear.TabIndex = 0;
            this.radioButtonUserCurrentYear.TabStop = true;
            this.radioButtonUserCurrentYear.Text = "سال جاری به عنوان مقدار ثابت به همراه شمارنده ذخیره شود";
            this.radioButtonUserCurrentYear.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseFixedValue
            // 
            this.radioButtonUseFixedValue.AutoSize = true;
            this.radioButtonUseFixedValue.Location = new System.Drawing.Point(128, 51);
            this.radioButtonUseFixedValue.Name = "radioButtonUseFixedValue";
            this.radioButtonUseFixedValue.Size = new System.Drawing.Size(246, 18);
            this.radioButtonUseFixedValue.TabIndex = 1;
            this.radioButtonUseFixedValue.TabStop = true;
            this.radioButtonUseFixedValue.Text = "مقدار ثابت زیر به همراه شمارنده ذخیره شود";
            this.radioButtonUseFixedValue.UseVisualStyleBackColor = true;
            this.radioButtonUseFixedValue.CheckedChanged += new System.EventHandler(this.radioButtonUseFixedValue_CheckedChanged);
            // 
            // txtFixedValue
            // 
            this.txtFixedValue.Enabled = false;
            this.txtFixedValue.Location = new System.Drawing.Point(41, 75);
            this.txtFixedValue.Name = "txtFixedValue";
            this.txtFixedValue.Size = new System.Drawing.Size(185, 22);
            this.txtFixedValue.TabIndex = 3;
            // 
            // radioButtonDontUserFixedValue
            // 
            this.radioButtonDontUserFixedValue.AutoSize = true;
            this.radioButtonDontUserFixedValue.Location = new System.Drawing.Point(194, 103);
            this.radioButtonDontUserFixedValue.Name = "radioButtonDontUserFixedValue";
            this.radioButtonDontUserFixedValue.Size = new System.Drawing.Size(180, 18);
            this.radioButtonDontUserFixedValue.TabIndex = 4;
            this.radioButtonDontUserFixedValue.TabStop = true;
            this.radioButtonDontUserFixedValue.Text = "شمارنده بدون مقدار ثابت باشد";
            this.radioButtonDontUserFixedValue.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "مقدار ثابت:";
            // 
            // txtSeparator
            // 
            this.txtSeparator.Location = new System.Drawing.Point(20, 162);
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(185, 22);
            this.txtSeparator.TabIndex = 2;
            this.txtSeparator.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "جدا کننده مقدار ثابت و مقدار غیرثابت:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonUserCurrentYear);
            this.groupBox1.Controls.Add(this.radioButtonUseFixedValue);
            this.groupBox1.Controls.Add(this.radioButtonDontUserFixedValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFixedValue);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // GetCounterFieldProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 230);
            this.Name = "GetCounterFieldProperties";
            this.Text = "تنظیم خصوصیات فیلد شمارنده";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUserCurrentYear;
        private System.Windows.Forms.RadioButton radioButtonUseFixedValue;
        private System.Windows.Forms.RadioButton radioButtonDontUserFixedValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFixedValue;
        private System.Windows.Forms.TextBox txtSeparator;
        private System.Windows.Forms.Label label2;
    }
}