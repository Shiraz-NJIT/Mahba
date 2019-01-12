namespace NjitSoftware.View.Controls
{
    partial class DossierSearchBox
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
            this.btnSearch_Advance = new Njit.Program.Controls.ButtonExtended();
            this.btnSearch_Simple = new Njit.Program.Controls.ButtonExtended();
            this.textBoxExtendedValue_Simple = new Njit.Program.Controls.TextBoxExtended();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxExtendedMethod_Simple = new Njit.Program.Controls.ComboBoxExtended();
            this.searchMethodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxExtendedField_Simple = new Njit.Program.Controls.ComboBoxExtended();
            this.archiveFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxExtendedTab_Simple = new Njit.Program.Controls.ComboBoxExtended();
            this.archiveTabBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxSearch = new System.Windows.Forms.ListBox();
            this.contextMenuStripSearchField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxExtendedField_Advance = new Njit.Program.Controls.ComboBoxExtended();
            this.comboBoxExtendedMethod_Advance = new Njit.Program.Controls.ComboBoxExtended();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExtendedValue_Advance = new Njit.Program.Controls.TextBoxExtended();
            this.btnAdd = new Njit.Program.Controls.ButtonExtended();
            this.comboBoxExtendedAndOr_Advance = new Njit.Program.Controls.ComboBoxExtended();
            this.comboBoxExtendedTab_Advance = new Njit.Program.Controls.ComboBoxExtended();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radGridViewSimple = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.radGridViewAdvanced = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.radGridViewAll = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            ((System.ComponentModel.ISupportInitialize)(this.searchMethodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveFieldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveTabBindingSource)).BeginInit();
            this.contextMenuStripSearchField.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSimple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSimple.MasterTemplate)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAdvanced)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAdvanced.MasterTemplate)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAll.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch_Advance
            // 
            this.btnSearch_Advance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch_Advance.Location = new System.Drawing.Point(554, 126);
            this.btnSearch_Advance.Name = "btnSearch_Advance";
            this.btnSearch_Advance.Size = new System.Drawing.Size(91, 23);
            this.btnSearch_Advance.TabIndex = 9;
            this.btnSearch_Advance.Text = "جستجو";
            this.btnSearch_Advance.UseVisualStyleBackColor = true;
            this.btnSearch_Advance.Click += new System.EventHandler(this.btnGroupSearch_Click);
            // 
            // btnSearch_Simple
            // 
            this.btnSearch_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch_Simple.Location = new System.Drawing.Point(104, 40);
            this.btnSearch_Simple.Name = "btnSearch_Simple";
            this.btnSearch_Simple.Size = new System.Drawing.Size(91, 23);
            this.btnSearch_Simple.TabIndex = 6;
            this.btnSearch_Simple.Text = "جستجو";
            this.btnSearch_Simple.UseVisualStyleBackColor = true;
            this.btnSearch_Simple.Click += new System.EventHandler(this.btnAddOrSearch_Click);
            // 
            // textBoxExtendedValue_Simple
            // 
            this.textBoxExtendedValue_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExtendedValue_Simple.Location = new System.Drawing.Point(201, 40);
            this.textBoxExtendedValue_Simple.Name = "textBoxExtendedValue_Simple";
            this.textBoxExtendedValue_Simple.Size = new System.Drawing.Size(154, 22);
            this.textBoxExtendedValue_Simple.TabIndex = 1;
            this.textBoxExtendedValue_Simple.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxExtendedValue_Simple_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "فیلد:";
            // 
            // comboBoxExtendedMethod_Simple
            // 
            this.comboBoxExtendedMethod_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtendedMethod_Simple.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxExtendedMethod_Simple.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedMethod_Simple.DataSource = this.searchMethodBindingSource;
            this.comboBoxExtendedMethod_Simple.DisplayMember = "Title";
            this.comboBoxExtendedMethod_Simple.FormattingEnabled = true;
            this.comboBoxExtendedMethod_Simple.Location = new System.Drawing.Point(361, 40);
            this.comboBoxExtendedMethod_Simple.Name = "comboBoxExtendedMethod_Simple";
            this.comboBoxExtendedMethod_Simple.Size = new System.Drawing.Size(134, 22);
            this.comboBoxExtendedMethod_Simple.TabIndex = 4;
            this.comboBoxExtendedMethod_Simple.ValueMember = "Code";
            this.comboBoxExtendedMethod_Simple.SelectedValueChanged += new System.EventHandler(this.comboBoxExtendedMethod_SelectedValueChanged);
            // 
            // searchMethodBindingSource
            // 
            this.searchMethodBindingSource.DataSource = typeof(NjitSoftware.SearchMethod);
            // 
            // comboBoxExtendedField_Simple
            // 
            this.comboBoxExtendedField_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtendedField_Simple.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxExtendedField_Simple.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedField_Simple.DataSource = this.archiveFieldBindingSource;
            this.comboBoxExtendedField_Simple.DisplayMember = "Label";
            this.comboBoxExtendedField_Simple.FormattingEnabled = true;
            this.comboBoxExtendedField_Simple.Location = new System.Drawing.Point(501, 40);
            this.comboBoxExtendedField_Simple.Name = "comboBoxExtendedField_Simple";
            this.comboBoxExtendedField_Simple.Size = new System.Drawing.Size(139, 22);
            this.comboBoxExtendedField_Simple.TabIndex = 3;
            this.comboBoxExtendedField_Simple.ValueMember = "ID";
            // 
            // archiveFieldBindingSource
            // 
            this.archiveFieldBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.ArchiveField);
            // 
            // comboBoxExtendedTab_Simple
            // 
            this.comboBoxExtendedTab_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtendedTab_Simple.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxExtendedTab_Simple.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedTab_Simple.BackColor = System.Drawing.Color.White;
            this.comboBoxExtendedTab_Simple.DataSource = this.archiveTabBindingSource;
            this.comboBoxExtendedTab_Simple.DisplayMember = "Title";
            this.comboBoxExtendedTab_Simple.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBoxExtendedTab_Simple.ForeColor = System.Drawing.Color.Black;
            this.comboBoxExtendedTab_Simple.FormattingEnabled = true;
            this.comboBoxExtendedTab_Simple.Location = new System.Drawing.Point(450, 12);
            this.comboBoxExtendedTab_Simple.Name = "comboBoxExtendedTab_Simple";
            this.comboBoxExtendedTab_Simple.Size = new System.Drawing.Size(190, 22);
            this.comboBoxExtendedTab_Simple.TabIndex = 1;
            this.comboBoxExtendedTab_Simple.ValueMember = "ID";
            this.comboBoxExtendedTab_Simple.SelectedValueChanged += new System.EventHandler(this.comboBoxExtendedTab_SelectedValueChanged);
            // 
            // archiveTabBindingSource
            // 
            this.archiveTabBindingSource.DataSource = typeof(NjitSoftware.Model.Archive.ArchiveTab);
            // 
            // listBoxSearch
            // 
            this.listBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSearch.ContextMenuStrip = this.contextMenuStripSearchField;
            this.listBoxSearch.FormattingEnabled = true;
            this.listBoxSearch.ItemHeight = 14;
            this.listBoxSearch.Location = new System.Drawing.Point(27, 60);
            this.listBoxSearch.Name = "listBoxSearch";
            this.listBoxSearch.Size = new System.Drawing.Size(618, 60);
            this.listBoxSearch.TabIndex = 8;
            this.listBoxSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxSearch_MouseDown);
            // 
            // contextMenuStripSearchField
            // 
            this.contextMenuStripSearchField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDelete});
            this.contextMenuStripSearchField.Name = "contextMenuStripSearchField";
            this.contextMenuStripSearchField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStripSearchField.Size = new System.Drawing.Size(100, 26);
            this.contextMenuStripSearchField.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripSearchField_Opening);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(99, 22);
            this.toolStripMenuItemDelete.Text = "حذف";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // comboBoxExtendedField_Advance
            // 
            this.comboBoxExtendedField_Advance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtendedField_Advance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxExtendedField_Advance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedField_Advance.DataSource = this.archiveFieldBindingSource;
            this.comboBoxExtendedField_Advance.DisplayMember = "Label";
            this.comboBoxExtendedField_Advance.FormattingEnabled = true;
            this.comboBoxExtendedField_Advance.Location = new System.Drawing.Point(424, 31);
            this.comboBoxExtendedField_Advance.Name = "comboBoxExtendedField_Advance";
            this.comboBoxExtendedField_Advance.Size = new System.Drawing.Size(139, 22);
            this.comboBoxExtendedField_Advance.TabIndex = 4;
            this.comboBoxExtendedField_Advance.ValueMember = "ID";
            // 
            // comboBoxExtendedMethod_Advance
            // 
            this.comboBoxExtendedMethod_Advance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtendedMethod_Advance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxExtendedMethod_Advance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedMethod_Advance.DataSource = this.searchMethodBindingSource;
            this.comboBoxExtendedMethod_Advance.DisplayMember = "Title";
            this.comboBoxExtendedMethod_Advance.FormattingEnabled = true;
            this.comboBoxExtendedMethod_Advance.Location = new System.Drawing.Point(284, 31);
            this.comboBoxExtendedMethod_Advance.Name = "comboBoxExtendedMethod_Advance";
            this.comboBoxExtendedMethod_Advance.Size = new System.Drawing.Size(134, 22);
            this.comboBoxExtendedMethod_Advance.TabIndex = 5;
            this.comboBoxExtendedMethod_Advance.ValueMember = "Code";
            this.comboBoxExtendedMethod_Advance.SelectedValueChanged += new System.EventHandler(this.comboBoxExtendedMethod_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(569, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "فیلد:";
            // 
            // textBoxExtendedValue_Advance
            // 
            this.textBoxExtendedValue_Advance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExtendedValue_Advance.Location = new System.Drawing.Point(124, 31);
            this.textBoxExtendedValue_Advance.Name = "textBoxExtendedValue_Advance";
            this.textBoxExtendedValue_Advance.Size = new System.Drawing.Size(154, 22);
            this.textBoxExtendedValue_Advance.TabIndex = 1;
            this.textBoxExtendedValue_Advance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxExtendedValue_Advance_KeyDown);
            this.textBoxExtendedValue_Advance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxExtendedValue_Advance_KeyUp);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(27, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "افزودن";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // comboBoxExtendedAndOr_Advance
            // 
            this.comboBoxExtendedAndOr_Advance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtendedAndOr_Advance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxExtendedAndOr_Advance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedAndOr_Advance.Enabled = false;
            this.comboBoxExtendedAndOr_Advance.FormattingEnabled = true;
            this.comboBoxExtendedAndOr_Advance.Items.AddRange(new object[] {
            "و",
            "یا"});
            this.comboBoxExtendedAndOr_Advance.Location = new System.Drawing.Point(606, 31);
            this.comboBoxExtendedAndOr_Advance.Name = "comboBoxExtendedAndOr_Advance";
            this.comboBoxExtendedAndOr_Advance.Size = new System.Drawing.Size(39, 22);
            this.comboBoxExtendedAndOr_Advance.TabIndex = 2;
            this.comboBoxExtendedAndOr_Advance.Text = "و";
            // 
            // comboBoxExtendedTab_Advance
            // 
            this.comboBoxExtendedTab_Advance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxExtendedTab_Advance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxExtendedTab_Advance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxExtendedTab_Advance.BackColor = System.Drawing.Color.White;
            this.comboBoxExtendedTab_Advance.DataSource = this.archiveTabBindingSource;
            this.comboBoxExtendedTab_Advance.DisplayMember = "Title";
            this.comboBoxExtendedTab_Advance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBoxExtendedTab_Advance.ForeColor = System.Drawing.Color.Black;
            this.comboBoxExtendedTab_Advance.FormattingEnabled = true;
            this.comboBoxExtendedTab_Advance.Location = new System.Drawing.Point(455, 3);
            this.comboBoxExtendedTab_Advance.Name = "comboBoxExtendedTab_Advance";
            this.comboBoxExtendedTab_Advance.Size = new System.Drawing.Size(190, 22);
            this.comboBoxExtendedTab_Advance.TabIndex = 1;
            this.comboBoxExtendedTab_Advance.ValueMember = "ID";
            this.comboBoxExtendedTab_Advance.SelectedValueChanged += new System.EventHandler(this.comboBoxExtendedTab_Advance_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "گروه اطلاعاتی:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 427);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radGridViewSimple);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(744, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "جستجوی ساده";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // radGridViewSimple
            // 
            this.radGridViewSimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewSimple.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridViewSimple.Location = new System.Drawing.Point(3, 77);
            // 
            // radGridViewSimple
            // 
            this.radGridViewSimple.MasterTemplate.AllowAddNewRow = false;
            this.radGridViewSimple.MasterTemplate.AllowDeleteRow = false;
            this.radGridViewSimple.MasterTemplate.AllowEditRow = false;
            this.radGridViewSimple.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.radGridViewSimple.MasterTemplate.EnableFiltering = true;
            this.radGridViewSimple.MasterTemplate.MultiSelect = true;
            this.radGridViewSimple.MasterTemplate.ShowGroupedColumns = true;
            this.radGridViewSimple.Name = "radGridViewSimple";
            this.radGridViewSimple.ReadOnly = true;
            this.radGridViewSimple.ShowNoDataText = false;
            this.radGridViewSimple.Size = new System.Drawing.Size(738, 320);
            this.radGridViewSimple.TabIndex = 8;
            this.radGridViewSimple.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridViews_CellDoubleClick);
            this.radGridViewSimple.DoubleClick += new System.EventHandler(this.radGridViewSimple_DoubleClick);
            this.radGridViewSimple.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radGridViewSimple_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxExtendedTab_Simple);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxExtendedField_Simple);
            this.panel1.Controls.Add(this.btnSearch_Simple);
            this.panel1.Controls.Add(this.textBoxExtendedValue_Simple);
            this.panel1.Controls.Add(this.comboBoxExtendedMethod_Simple);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 74);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(646, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "گروه اطلاعاتی:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.radGridViewAdvanced);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "جستجوی پیشرفته";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // radGridViewAdvanced
            // 
            this.radGridViewAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewAdvanced.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridViewAdvanced.Location = new System.Drawing.Point(3, 157);
            // 
            // radGridViewAdvanced
            // 
            this.radGridViewAdvanced.MasterTemplate.AllowAddNewRow = false;
            this.radGridViewAdvanced.MasterTemplate.AllowDeleteRow = false;
            this.radGridViewAdvanced.MasterTemplate.AllowEditRow = false;
            this.radGridViewAdvanced.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.radGridViewAdvanced.MasterTemplate.EnableFiltering = true;
            this.radGridViewAdvanced.MasterTemplate.MultiSelect = true;
            this.radGridViewAdvanced.MasterTemplate.ShowGroupedColumns = true;
            this.radGridViewAdvanced.Name = "radGridViewAdvanced";
            this.radGridViewAdvanced.ReadOnly = true;
            this.radGridViewAdvanced.ShowNoDataText = false;
            this.radGridViewAdvanced.Size = new System.Drawing.Size(738, 240);
            this.radGridViewAdvanced.TabIndex = 11;
            this.radGridViewAdvanced.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridViews_CellDoubleClick);
            this.radGridViewAdvanced.DoubleClick += new System.EventHandler(this.radGridViewAdvanced_DoubleClick);
            this.radGridViewAdvanced.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radGridViewAdvanced_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxExtendedTab_Advance);
            this.panel2.Controls.Add(this.comboBoxExtendedAndOr_Advance);
            this.panel2.Controls.Add(this.listBoxSearch);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxExtendedValue_Advance);
            this.panel2.Controls.Add(this.comboBoxExtendedMethod_Advance);
            this.panel2.Controls.Add(this.comboBoxExtendedField_Advance);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnSearch_Advance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 154);
            this.panel2.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.radGridViewAll);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(744, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "نمایش همه پرونده ها";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // radGridViewAll
            // 
            this.radGridViewAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridViewAll.Location = new System.Drawing.Point(3, 3);
            // 
            // radGridViewAll
            // 
            this.radGridViewAll.MasterTemplate.AllowAddNewRow = false;
            this.radGridViewAll.MasterTemplate.AllowDeleteRow = false;
            this.radGridViewAll.MasterTemplate.AllowEditRow = false;
            this.radGridViewAll.MasterTemplate.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.radGridViewAll.MasterTemplate.EnableFiltering = true;
            this.radGridViewAll.MasterTemplate.MultiSelect = true;
            this.radGridViewAll.MasterTemplate.ShowGroupedColumns = true;
            this.radGridViewAll.Name = "radGridViewAll";
            this.radGridViewAll.ReadOnly = true;
            this.radGridViewAll.ShowNoDataText = false;
            this.radGridViewAll.Size = new System.Drawing.Size(738, 394);
            this.radGridViewAll.TabIndex = 9;
            this.radGridViewAll.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridViews_CellDoubleClick);
            this.radGridViewAll.DoubleClick += new System.EventHandler(this.radGridViewAll_DoubleClick);
            this.radGridViewAll.KeyUp += new System.Windows.Forms.KeyEventHandler(this.radGridViewAll_KeyUp);
            // 
            // DossierSearchBox
            // 
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "DossierSearchBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(752, 427);
            ((System.ComponentModel.ISupportInitialize)(this.searchMethodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveFieldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archiveTabBindingSource)).EndInit();
            this.contextMenuStripSearchField.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSimple.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewSimple)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAdvanced.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAdvanced)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAll.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Njit.Program.Controls.TextBoxExtended textBoxExtendedValue_Simple;
        private System.Windows.Forms.Label label2;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedMethod_Simple;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedField_Simple;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedTab_Simple;
        private System.Windows.Forms.ListBox listBoxSearch;
        private System.Windows.Forms.BindingSource searchMethodBindingSource;
        private System.Windows.Forms.BindingSource archiveFieldBindingSource;
        private System.Windows.Forms.BindingSource archiveTabBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSearchField;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedField_Advance;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedMethod_Advance;
        private System.Windows.Forms.Label label3;
        private Njit.Program.Controls.TextBoxExtended textBoxExtendedValue_Advance;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedAndOr_Advance;
        private Njit.Program.Controls.ComboBoxExtended comboBoxExtendedTab_Advance;
        private System.Windows.Forms.Label label4;
        public Njit.Program.Controls.ButtonExtended btnSearch_Advance;
        public Njit.Program.Controls.ButtonExtended btnSearch_Simple;
        public Njit.Program.Controls.ButtonExtended btnAdd;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridViewSimple;
        private System.Windows.Forms.Panel panel1;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridViewAdvanced;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage3;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridViewAll;
        private System.Windows.Forms.Label label1;
    }
}
