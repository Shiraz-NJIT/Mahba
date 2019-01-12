namespace NjitSoftware.View.LendingManageForms
{
    partial class SelectDisplayFields
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
            this.comboBoxExtended = new Njit.Program.Controls.ComboBoxExtended();
            this.archiveTabBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.label = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCommand.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveTabBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Size = new System.Drawing.Size(625, 395);
            // 
            // panelCommand
            // 
            this.panelCommand.Location = new System.Drawing.Point(0, 395);
            this.panelCommand.Size = new System.Drawing.Size(625, 29);
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.label);
            this.groupBoxMain.Controls.Add(this.checkedListBox);
            this.groupBoxMain.Controls.Add(this.comboBoxExtended);
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.groupBoxMain.Size = new System.Drawing.Size(605, 392);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(13, 3);
            this.btnCancel.Text = "خروج";
            // 
            // comboBoxExtended
            // 
            this.comboBoxExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtended.DataSource = this.archiveTabBindingSource;
            this.comboBoxExtended.DisplayMember = "Title";
            this.comboBoxExtended.FormattingEnabled = true;
            this.comboBoxExtended.Location = new System.Drawing.Point(244, 21);
            this.comboBoxExtended.Name = "comboBoxExtended";
            this.comboBoxExtended.Size = new System.Drawing.Size(244, 22);
            this.comboBoxExtended.TabIndex = 1;
            this.comboBoxExtended.ValueMember = "ID";
            this.comboBoxExtended.SelectedValueChanged += new System.EventHandler(this.comboBoxExtended_SelectedValueChanged);
            // 
            // archiveTabBindingSource
            // 
            this.archiveTabBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.ArchiveTab);
            // 
            // checkedListBox
            // 
            this.checkedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(13, 49);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(579, 310);
            this.checkedListBox.TabIndex = 2;
            this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(494, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(83, 14);
            this.label.TabIndex = 0;
            this.label.Text = "گروه اطلاعاتی:";
            // 
            // SelectDisplayFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 424);
            this.Name = "SelectDisplayFields";
            this.Text = "انتخاب فیلد ها برای نمایش";
            this.panelMain.ResumeLayout(false);
            this.panelCommand.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveTabBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtended;
        private System.Windows.Forms.BindingSource archiveTabBindingSource;
    }
}