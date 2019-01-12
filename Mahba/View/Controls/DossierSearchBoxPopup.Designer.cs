namespace NjitSoftware.View.Controls
{
    partial class DossierSearchBoxPopup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.searchMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxExtendedValue = new Njit.Program.Controls.TextBoxExtended();
            this.comboBoxExtendedMethod = new Njit.Program.Controls.ComboBoxExtended();
            this.btnAdd = new Njit.Program.Controls.ButtonExtended();
            this.contextMenuStripSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddToCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMakeNew = new System.Windows.Forms.ToolStripMenuItem();
            this.lblField = new System.Windows.Forms.Label();
            this.comboBoxExtendedAndOr = new Njit.Program.Controls.ComboBoxExtended();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchMethodBindingSource)).BeginInit();
            this.contextMenuStripSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // searchMethodBindingSource
            // 
            this.searchMethodBindingSource.DataSource = typeof(NjitSoftware.SearchMethod);
            // 
            // textBoxExtendedValue
            // 
            this.textBoxExtendedValue.Location = new System.Drawing.Point(90, 14);
            this.textBoxExtendedValue.Name = "textBoxExtendedValue";
            this.textBoxExtendedValue.Size = new System.Drawing.Size(154, 22);
            this.textBoxExtendedValue.TabIndex = 3;
            // 
            // comboBoxExtendedMethod
            // 
            this.comboBoxExtendedMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxExtendedMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedMethod.DataSource = this.searchMethodBindingSource;
            this.comboBoxExtendedMethod.DisplayMember = "Title";
            this.comboBoxExtendedMethod.FormattingEnabled = true;
            this.comboBoxExtendedMethod.Location = new System.Drawing.Point(250, 14);
            this.comboBoxExtendedMethod.Name = "comboBoxExtendedMethod";
            this.comboBoxExtendedMethod.Size = new System.Drawing.Size(134, 22);
            this.comboBoxExtendedMethod.TabIndex = 2;
            this.comboBoxExtendedMethod.ValueMember = "Code";
            this.comboBoxExtendedMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxExtendedMethod_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.ContextMenuStrip = this.contextMenuStripSelect;
            this.btnAdd.Location = new System.Drawing.Point(9, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "افزودن";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // contextMenuStripSelect
            // 
            this.contextMenuStripSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddToCurrent,
            this.menuMakeNew});
            this.contextMenuStripSelect.Name = "contextMenuStripSelect";
            this.contextMenuStripSelect.Size = new System.Drawing.Size(198, 48);
            // 
            // menuAddToCurrent
            // 
            this.menuAddToCurrent.Name = "menuAddToCurrent";
            this.menuAddToCurrent.Size = new System.Drawing.Size(197, 22);
            this.menuAddToCurrent.Text = "افزودن به شرط انتخاب شده";
            this.menuAddToCurrent.Click += new System.EventHandler(this.menuAddToCurrent_Click);
            // 
            // menuMakeNew
            // 
            this.menuMakeNew.Name = "menuMakeNew";
            this.menuMakeNew.Size = new System.Drawing.Size(197, 22);
            this.menuMakeNew.Text = "ایجاد شرط جدید";
            this.menuMakeNew.Click += new System.EventHandler(this.menuMakeNew_Click);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(390, 17);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(49, 14);
            this.lblField.TabIndex = 1;
            this.lblField.Text = "نام فیلد:";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxExtendedAndOr
            // 
            this.comboBoxExtendedAndOr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxExtendedAndOr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedAndOr.FormattingEnabled = true;
            this.comboBoxExtendedAndOr.Items.AddRange(new object[] {
            "و",
            "یا"});
            this.comboBoxExtendedAndOr.Location = new System.Drawing.Point(445, 14);
            this.comboBoxExtendedAndOr.Name = "comboBoxExtendedAndOr";
            this.comboBoxExtendedAndOr.Size = new System.Drawing.Size(39, 22);
            this.comboBoxExtendedAndOr.TabIndex = 0;
            this.comboBoxExtendedAndOr.Text = "و";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::NjitSoftware.Properties.Resources.Close;
            this.pictureBoxClose.Location = new System.Drawing.Point(496, 17);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxClose.TabIndex = 5;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // DossierSearchBoxPopup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Wheat;
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.comboBoxExtendedAndOr);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.textBoxExtendedValue);
            this.Controls.Add(this.comboBoxExtendedMethod);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "DossierSearchBoxPopup";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(518, 49);
            ((System.ComponentModel.ISupportInitialize)(this.searchMethodBindingSource)).EndInit();
            this.contextMenuStripSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource searchMethodBindingSource;
        private Njit.Program.Controls.TextBoxExtended textBoxExtendedValue;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedMethod;
        private Njit.Program.Controls.ButtonExtended btnAdd;
        private System.Windows.Forms.Label lblField;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedAndOr;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSelect;
        private System.Windows.Forms.ToolStripMenuItem menuAddToCurrent;
        private System.Windows.Forms.ToolStripMenuItem menuMakeNew;
    }
}
