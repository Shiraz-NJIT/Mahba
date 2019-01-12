using System.Windows.Forms;
namespace NjitSoftware.View.LendingManageForms
{
    partial class LendingList
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
            this.radGridView = new Njit.Program.Telerik.Controls.RadGridViewExtended();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnEdit = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonSeparator1 = new C1.Win.C1Ribbon.RibbonSeparator();
            this.btnDelete = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnReturn = new Njit.Program.ComponentOne.Controls.RibbonButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBacked = new System.Windows.Forms.CheckBox();
            this.cbNotBack = new System.Windows.Forms.CheckBox();
            this.panelCommand.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.radGridView);
            this.panelMain.Controls.Add(this.radGridView);
            // 
            // ribbonTabOperations
            // 
            this.ribbonTabOperations.Groups.Add(this.ribbonGroup1);
            // 
            // ribbonGroupOperations
            // 
            this.ribbonGroupOperations.Items.Add(this.btnEdit);
            this.ribbonGroupOperations.Items.Add(this.ribbonSeparator1);
            this.ribbonGroupOperations.Items.Add(this.btnDelete);
            this.ribbonGroupOperations.Text = "عملیات";
            // 
            // btnEdit
            // 
            this.btnEdit.LargeImage = global::NjitSoftware.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SmallImage = global::NjitSoftware.Properties.Resources.edit;
            this.btnEdit.Text = "ویرایش...";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // btnDelete
            // 
            this.btnDelete.LargeImage = global::NjitSoftware.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SmallImage = global::NjitSoftware.Properties.Resources.delete;
            this.btnDelete.Text = "حذف";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.btnReturn);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "     بازگشت     ";
            // 
            // btnReturn
            // 
            this.btnReturn.LargeImage = global::NjitSoftware.Properties.Resources.Convert;
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.SmallImage = global::NjitSoftware.Properties.Resources.Convert;
            this.btnReturn.Text = "بازگشت امانت";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // radGridView
            // 
            this.radGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radGridView.Location = new System.Drawing.Point(10, 3);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AllowAddNewRow = false;
            this.radGridView.MasterTemplate.AllowDeleteRow = false;
            this.radGridView.MasterTemplate.AllowEditRow = false;
            this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView.MasterTemplate.EnableFiltering = true;
            this.radGridView.MasterTemplate.MultiSelect = true;
            this.radGridView.MasterTemplate.ShowGroupedColumns = true;
            this.radGridView.Name = "radGridView";
            this.radGridView.ReadOnly = true;
            this.radGridView.Size = new System.Drawing.Size(772, 304);
            this.radGridView.TabIndex = 3;
            this.radGridView.Padding = new Padding(0, 35, 0, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNotBack);
            this.groupBox1.Controls.Add(this.cbBacked);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 38);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فیلتر";
            // 
            // cbBacked
            // 
            this.cbBacked.AutoSize = true;
            this.cbBacked.Location = new System.Drawing.Point(356, 14);
            this.cbBacked.Name = "cbBacked";
            this.cbBacked.Size = new System.Drawing.Size(118, 18);
            this.cbBacked.TabIndex = 0;
            this.cbBacked.Text = "برگشت داده شده";
            this.cbBacked.UseVisualStyleBackColor = true;
            // 
            // cbNotBack
            // 
            this.cbNotBack.AutoSize = true;
            this.cbNotBack.Checked = true;
            this.cbNotBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNotBack.Location = new System.Drawing.Point(623, 14);
            this.cbNotBack.Name = "cbNotBack";
            this.cbNotBack.Size = new System.Drawing.Size(122, 18);
            this.cbNotBack.TabIndex = 1;
            this.cbNotBack.Text = "برگشت داده نشده";
            this.cbNotBack.UseVisualStyleBackColor = true;
            
            // 
            // LendingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 492);
            this.Controls.Add(this.groupBox1);
            this.Name = "LendingList";
            this.Text = "گزارش پرونده های به امانت برده شده";
            this.Controls.SetChildIndex(this.panelCommand, 0);
            this.Controls.SetChildIndex(this.mainRibbon, 0);
            this.Controls.SetChildIndex(this.panelMain, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.panelCommand.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Njit.Program.ComponentOne.Controls.RibbonButton btnEdit;
        private C1.Win.C1Ribbon.RibbonSeparator ribbonSeparator1;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnDelete;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private Njit.Program.ComponentOne.Controls.RibbonButton btnReturn;
        private Njit.Program.Telerik.Controls.RadGridViewExtended radGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbBacked;
        private System.Windows.Forms.CheckBox cbNotBack;
    }
}