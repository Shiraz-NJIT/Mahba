namespace Njit.Program.Forms
{
    partial class ComboBoxEditItems
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetAsDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.customItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new Njit.Program.Controls.ButtonExtended();
            this.textBox = new Njit.Program.Controls.TextBoxExtended();
            this.panelCommand = new System.Windows.Forms.Panel();
            this.btnSetAsDefault = new Njit.Program.Controls.ButtonExtended();
            this.btnDelete = new Njit.Program.Controls.ButtonExtended();
            this.btnCancel = new Njit.Program.Controls.ButtonExtended();
            this.btnEdit = new Njit.Program.Controls.ButtonExtended();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelMain.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customItemBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panelMain.Size = new System.Drawing.Size(464, 224);
            this.panelMain.TabIndex = 0;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.listBox);
            this.groupBoxMain.Controls.Add(this.panel1);
            this.groupBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain.Location = new System.Drawing.Point(10, 3);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Padding = new System.Windows.Forms.Padding(5, 2, 5, 5);
            this.groupBoxMain.Size = new System.Drawing.Size(444, 221);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            // 
            // listBox
            // 
            this.listBox.ContextMenuStrip = this.contextMenuStrip;
            this.listBox.DataSource = this.customItemBindingSource;
            this.listBox.DisplayMember = "Caption";
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 14;
            this.listBox.Location = new System.Drawing.Point(5, 46);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(434, 170);
            this.listBox.TabIndex = 1;
            this.listBox.ValueMember = "Value";
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemDelete,
            this.toolStripMenuItemSetAsDefault});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip.Size = new System.Drawing.Size(227, 70);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(226, 22);
            this.toolStripMenuItemEdit.Text = "اصلاح...";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(226, 22);
            this.toolStripMenuItemDelete.Text = "حذف";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripMenuItemSetAsDefault
            // 
            this.toolStripMenuItemSetAsDefault.Name = "toolStripMenuItemSetAsDefault";
            this.toolStripMenuItemSetAsDefault.Size = new System.Drawing.Size(226, 22);
            this.toolStripMenuItemSetAsDefault.Text = "انتخاب به عنوان گزینه پیشفرض";
            this.toolStripMenuItemSetAsDefault.Click += new System.EventHandler(this.toolStripMenuItemSetAsDefault_Click);
            // 
            // customItemBindingSource
            // 
            this.customItemBindingSource.DataSource = typeof(Njit.Program.Controls.ComboBoxExtended.CustomItem);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 17);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(434, 29);
            this.panel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.AllowCheckAccessPermission = false;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(68, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ثبت";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox.Location = new System.Drawing.Point(143, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(288, 22);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // panelCommand
            // 
            this.panelCommand.Controls.Add(this.btnSetAsDefault);
            this.panelCommand.Controls.Add(this.btnDelete);
            this.panelCommand.Controls.Add(this.btnCancel);
            this.panelCommand.Controls.Add(this.btnEdit);
            this.panelCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommand.Location = new System.Drawing.Point(0, 224);
            this.panelCommand.Name = "panelCommand";
            this.panelCommand.Padding = new System.Windows.Forms.Padding(13, 3, 13, 3);
            this.panelCommand.Size = new System.Drawing.Size(464, 29);
            this.panelCommand.TabIndex = 1;
            // 
            // btnSetAsDefault
            // 
            this.btnSetAsDefault.AllowCheckAccessPermission = false;
            this.btnSetAsDefault.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetAsDefault.Location = new System.Drawing.Point(126, 3);
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.Size = new System.Drawing.Size(175, 23);
            this.btnSetAsDefault.TabIndex = 3;
            this.btnSetAsDefault.Text = "انتخاب به عنوان گزینه پیشفرض";
            this.btnSetAsDefault.UseVisualStyleBackColor = true;
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AllowCheckAccessPermission = false;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(301, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AllowCheckAccessPermission = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(13, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "خروج";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AllowCheckAccessPermission = false;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Location = new System.Drawing.Point(376, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "اصلاح...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.RightToLeft = true;
            // 
            // ComboBoxEditItems
            // 
            this.AcceptButton = this.btnOK;
            this.AllowCheckAccessPermission = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 253);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelCommand);
            this.Name = "ComboBoxEditItems";
            this.Text = "ویرایش گزینه ها";
            this.panelMain.ResumeLayout(false);
            this.groupBoxMain.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customItemBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCommand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panelMain;
        protected System.Windows.Forms.GroupBox groupBoxMain;
        protected Controls.ButtonExtended btnOK;
        protected System.Windows.Forms.Panel panelCommand;
        protected Controls.ButtonExtended btnCancel;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        protected System.Windows.Forms.ListBox listBox;
        protected Controls.TextBoxExtended textBox;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.BindingSource customItemBindingSource;
        protected System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        protected Controls.ButtonExtended btnDelete;
        protected Controls.ButtonExtended btnEdit;
        protected Controls.ButtonExtended btnSetAsDefault;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetAsDefault;

    }
}