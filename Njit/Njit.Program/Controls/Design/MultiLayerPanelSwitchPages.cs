using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Resources;

namespace Njit.Program.Controls.Design
{
	public class MultiLayerPanelSwitchPages : Form
	{
		private System.Windows.Forms.Label lblSwitchPage;
		private System.Windows.Forms.ComboBox cmbItems;
		private System.Windows.Forms.CheckBox chkSetSelectedPage;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;

		MultiLayerPanelDesigner designer;
		Page futureSelectedItem;
		bool setSelectedPage;

		class MultiPanePageItem
		{
			public MultiPanePageItem(Page page)
			{
                _Page = page;
			}

            Page _Page;
            public Page Page
            {
                get
                {
                    return _Page;
                }
            }

			public override string ToString()
			{
                return _Page.Name;
			}
		}

		public MultiLayerPanelSwitchPages(MultiLayerPanelDesigner designer)
		{
			this.designer = designer;
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			foreach (Page aIt in designer.DesignedControl.Controls)
			{
				MultiPanePageItem aItem = new MultiPanePageItem(aIt);
				cmbItems.Items.Add(aItem);
				if (designer.DesignerSelectedPage == aIt)
					cmbItems.SelectedItem = aItem;
			}
		}

		public Page FutureSelection
		{
            get
            {
                return futureSelectedItem;
            }
		}

		public bool SetSelectedPage
		{
            get
            {
                return setSelectedPage;
            }
		}

		private void Handler_OK(object sender, EventArgs e)
		{
			futureSelectedItem = ((MultiPanePageItem)cmbItems.SelectedItem).Page;
			setSelectedPage = chkSetSelectedPage.Checked;
		}

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
            this.lblSwitchPage = new System.Windows.Forms.Label();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.chkSetSelectedPage = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myCtlLblSwitchPage
            // 
            this.lblSwitchPage.AutoSize = true;
            this.lblSwitchPage.Location = new System.Drawing.Point(296, 32);
            this.lblSwitchPage.Name = "myCtlLblSwitchPage";
            this.lblSwitchPage.Size = new System.Drawing.Size(41, 14);
            this.lblSwitchPage.TabIndex = 0;
            this.lblSwitchPage.Text = "صفحه:";
            // 
            // myCtlCmbItems
            // 
            this.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItems.Location = new System.Drawing.Point(38, 29);
            this.cmbItems.Name = "myCtlCmbItems";
            this.cmbItems.Size = new System.Drawing.Size(252, 22);
            this.cmbItems.TabIndex = 1;
            // 
            // myCtlChkSetSelectedPage
            // 
            this.chkSetSelectedPage.AutoSize = true;
            this.chkSetSelectedPage.Location = new System.Drawing.Point(38, 57);
            this.chkSetSelectedPage.Name = "myCtlChkSetSelectedPage";
            this.chkSetSelectedPage.Size = new System.Drawing.Size(252, 18);
            this.chkSetSelectedPage.TabIndex = 2;
            this.chkSetSelectedPage.Text = "همچنین خصوصیت SelectedPage را ست کن";
            // 
            // myCtlBtnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(286, 109);
            this.btnOK.Name = "myCtlBtnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "تایید";
            this.btnOK.Click += new System.EventHandler(this.Handler_OK);
            // 
            // myCtlBtnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(205, 109);
            this.btnCancel.Name = "myCtlBtnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصراف";
            // 
            // MultiLayerPanelSwitchPages
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(369, 140);
            this.Controls.Add(this.lblSwitchPage);
            this.Controls.Add(this.cmbItems);
            this.Controls.Add(this.chkSetSelectedPage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiLayerPanelSwitchPages";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انتخاب صفحه";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
	}
}