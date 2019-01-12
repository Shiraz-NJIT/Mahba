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
    public partial class ProgramSettings : Njit.Program.Forms.OKCancelForm
    {
        public ProgramSettings()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadSettings();
        }

        public virtual void LoadSettings()
        {
            this.persianMessageBoxInfoBindingSource.DataSource = PersianMessageBox.SavedResponses.ToList();
            nameDataGridViewTextBoxColumn.Visible = false;
        }

        public virtual bool SaveSettings()
        {
            try
            {
                PersianMessageBox.SavedResponses = this.persianMessageBoxInfoBindingSource.DataSource as List<PersianMessageBoxInfo>;
                PersianMessageBox.Save();
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ذخیره پاسخ های ذخیره شده" + Environment.NewLine + Environment.NewLine + ex.Message);
                tabControlExtended.SelectedTab = tabPageSavedResponse;
                return false;
            }
            return true;
        }

        private bool _ContentChanged = false;
        [DefaultValue(false)]
        [Browsable(false)]
        public bool ContentChanged
        {
            get
            {
                return _ContentChanged;
            }
            set
            {
                _ContentChanged = value;
            }
        }

        private void btnDeleteSavedResponse_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewSavedResponse.SelectedRows)
            {
                persianMessageBoxInfoBindingSource.Remove(row.DataBoundItem);
                this.ContentChanged = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!btnOK.Focused)
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
                ex.Control.TextChanged -= OnControlTextChanged;
                ex.Control.Leave -= OnControlLeave;
                PersianMessageBox.Show(ex.Message);
                ex.Control.Focus();
                ex.Control.TextChanged += OnControlTextChanged;
                ex.Control.Leave += OnControlLeave;
                errorProvider.SetError(ex.Control, ex.Message);
                if (ex.Tag is TabPage)
                    tabControlExtended.SelectedTab = ex.Tag as TabPage;
                return;
            }
            if (SaveSettings())
            {
                this.ContentChanged = false;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        public virtual void OnControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as Control, null);
        }

        public virtual void OnControlLeave(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as Control, null);
        }

        public virtual void ValidateContents()
        {

        }
    }
}
