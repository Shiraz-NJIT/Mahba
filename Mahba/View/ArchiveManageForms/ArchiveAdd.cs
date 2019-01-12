using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.ArchiveManageForms
{
    public partial class ArchiveAdd : Njit.Program.Forms.OKCancelForm
    {
        public ArchiveAdd()
        {
            InitializeComponent();
        }

        private string _SelectedDatabasePath;
        public string SelectedDatabasePath
        {
            get
            {
                return _SelectedDatabasePath;
            }
            set
            {
                _SelectedDatabasePath = value;
            }
        }

        private bool _UseDatabase;
        public bool UseDatabase
        {
            get
            {
                return _UseDatabase;
            }
            set
            {
                _UseDatabase = value;
            }
        }

        private string _SelectedDocumentsPathOrDatabasePath;
        public string SelectedDocumentsPathOrDatabasePath
        {
            get
            {
                return _SelectedDocumentsPathOrDatabasePath;
            }
            set
            {
                _SelectedDocumentsPathOrDatabasePath = value;
            }
        }

        public void ValidateContents()
        {
            if (txtDatabasePath.Text.Trim() == "")
                throw new Njit.Common.ValidateException(txtDatabasePath, "مسیر ذخیره فایل های پایگاه داده را وارد کنید");
            if (txtDocumentsPath.Text.Trim() == "")
                throw new Njit.Common.ValidateException(txtDocumentsPath, string.Format("مسیر ذخیره {0} را وارد کنید", radioButtonSaveDocsToFile.Checked ? "اسناد" : "پایگاه داده مربوط به اسناد"));
            string serverName;
            try
            {
                serverName = Njit.Program.Options.SystemUtility.GetComputerName();
            }
            catch
            {
                throw new Njit.Common.ValidateException(this, "خطا در اتصال به سرور");
            }
            if (serverName == System.Net.Dns.GetHostName())
            {
                if (!System.IO.Directory.Exists(txtDatabasePath.Text))
                    throw new Njit.Common.ValidateException(txtDatabasePath, "مسیر ذخیره فایل های پایگاه داده نامعتبر است");
                if (!System.IO.Directory.Exists(txtDocumentsPath.Text))
                    throw new Njit.Common.ValidateException(txtDocumentsPath, string.Format("مسیر ذخیره {0} نامعتبر است", radioButtonSaveDocsToFile.Checked ? "اسناد" : "پایگاه داده مربوط به اسناد"));
            }
            else
            {
                if (!Njit.Program.Options.SystemUtility.DirectoryExists(txtDatabasePath.Text))
                    throw new Njit.Common.ValidateException(txtDatabasePath, "مسیر ذخیره فایل های پایگاه داده نامعتبر است\r\nتوجه داشته باشید که پایگاه داده بر روی سرور ایجاد می شود و مسیر ذخیره فایل های پایگاه داده باید بر روی سرور موجود باشد");
                if (!Njit.Program.Options.SystemUtility.DirectoryExists(txtDocumentsPath.Text))
                    throw new Njit.Common.ValidateException(txtDocumentsPath, string.Format("مسیر ذخیره {0} نامعتبر است\r\nتوجه داشته باشید که اسناد بر روی سرور ذخیره می شوند و مسیر ذخیره {0} باید بر روی سرور موجود باشد", radioButtonSaveDocsToFile.Checked ? "اسناد" : "پایگاه داده مربوط به اسناد"));
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSaveDocsToFile.Checked)
            {
                lblDocumentsPath.Text = "مسیر ذخیره اسناد:";
                browseButtonDocument.Description = "مسیر ذخیره اسناد";
            }
            else
            {
                lblDocumentsPath.Text = "مسیر ذخیره پایگاه داده اسناد:";
                browseButtonDocument.Description = "مسیر ذخیره پایگاه داده مربوط به اسناد";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnOK || this.ActiveControl == btnOK))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            try
            {
                ValidateContents();
            }
            catch (Njit.Common.ValidateException ex)
            {
                if (ex.Control != null)
                {
                    ex.Control.TextChanged -= ControlTextChanged;
                    ex.Control.Leave -= ControlLeave;
                }
                PersianMessageBox.Show(ex.Message);
                if (ex.Control != null)
                {
                    ex.Control.Focus();
                    ex.Control.TextChanged += ControlTextChanged;
                    ex.Control.Leave += ControlLeave;
                    errorProvider.SetError(ex.Control, ex.Message);
                }
                return;
            }
            this.SelectedDatabasePath = txtDatabasePath.Text;
            this.UseDatabase = radioButtonSaveDocsToDatabase.Checked;
            this.SelectedDocumentsPathOrDatabasePath = txtDocumentsPath.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }
    }
}
