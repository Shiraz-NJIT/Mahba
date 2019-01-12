using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.Forms
{
    public partial class FolderBrowser : Njit.Program.Forms.BaseFormDialog
    {
        public FolderBrowser()
        {
            InitializeComponent();
        }

        public Njit.Common.SystemUtility SystemUtility
        {
            get
            {
                return folderBrowserControl.SystemUtility;
            }
            set
            {
                folderBrowserControl.SystemUtility = value;
            }
        }

        public string SelectedPath
        {
            get
            {
                return folderBrowserControl.SelectedPath;
            }
            //set
            //{
            //    _SelectedPath = value;
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (folderBrowserControl.SelectedPath == null)
                return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserControl.SelectedPath == null)
                return;
            Forms.GetValue f = new GetValue("ساخت پوشه جدید", "نام پوشه را وارد کنید", "");
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    folderBrowserControl.CreateDirectory(f.Value);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ایجاد پوشه" + "\r\n\r\n" + ex.Message);
                    return;
                }
            }
        }

        private void FolderBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
