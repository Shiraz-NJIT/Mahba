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
    public partial class ComboBoxEditItems : BaseFormDialog
    {
        public ComboBoxEditItems()
        {
            InitializeComponent();
        }

        public ComboBoxEditItems(Njit.Sql.IDataAccess dataAccess, string tableName, string keyField, string captionField, string isDefaultField = null)
        {
            InitializeComponent();
            this.TableName = tableName;
            this.KeyField = keyField;
            this.CaptionField = captionField;
            this.DataAccess = dataAccess;
            this.IsDefaultField = isDefaultField;
            toolStripMenuItemSetAsDefault.Visible = btnSetAsDefault.Visible = (isDefaultField != null);
        }

        private Njit.Sql.IDataAccess _DataAccess = null;
        [DefaultValue(null)]
        [Browsable(false)]
        public Njit.Sql.IDataAccess DataAccess
        {
            get
            {
                return _DataAccess;
            }
            set
            {
                _DataAccess = value;
            }
        }

        private string _TableName = null;
        [DefaultValue(null)]
        protected string TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

        private string _KeyField = null;
        [DefaultValue(null)]
        protected string KeyField
        {
            get
            {
                return _KeyField;
            }
            set
            {
                _KeyField = value;
            }
        }

        private string _CaptionField = null;
        [DefaultValue(null)]
        protected string CaptionField
        {
            get
            {
                return _CaptionField;
            }
            set
            {
                _CaptionField = value;
            }
        }

        private string _IsDefaultField = null;
        [DefaultValue(null)]
        protected string IsDefaultField
        {
            get
            {
                return _IsDefaultField;
            }
            set
            {
                _IsDefaultField = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            RefreshData();
        }

        protected virtual void RefreshData()
        {
            DataTable dt = (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).GetData(string.Format("SELECT * FROM [{0}]", this.TableName));
            List<Njit.Program.Controls.ComboBoxExtended.CustomItem> list = new List<Controls.ComboBoxExtended.CustomItem>();
            foreach (DataRow row in dt.Rows)
            {
                if (this.IsDefaultField != null)
                {
                    if (!row[this.IsDefaultField].IsNullOrEmpty() && ((bool)row[this.IsDefaultField]) == true)
                        list.Add(new Njit.Program.Controls.ComboBoxExtended.CustomItem(row[this.KeyField], "* " + row[this.CaptionField].ToString()));
                    else
                        list.Add(new Njit.Program.Controls.ComboBoxExtended.CustomItem(row[this.KeyField], "  " + row[this.CaptionField].ToString()));
                }
                else
                    list.Add(new Njit.Program.Controls.ComboBoxExtended.CustomItem(row[this.KeyField], row[this.CaptionField].ToString()));
            }
            customItemBindingSource.DataSource = list;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Trim() == "")
            {
                PersianMessageBox.Show(this, "مقدار وارد نشده است");
                errorProvider.SetError(textBox, "مقدار وارد نشده است");
                textBox.Focus();
                return;
            }
            try
            {
                if (this.IsDefaultField != null)
                    (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("INSERT INTO [{0}] ([{1}]) VALUES(@p1,@p2)", this.TableName, this.CaptionField), "@p", textBox.Text, "@p2", false);
                else
                    (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("INSERT INTO [{0}] ([{1}]) VALUES(@p)", this.TableName, this.CaptionField), "@p", textBox.Text);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
            RefreshData();
            textBox.Text = "";
            textBox.Focus();
        }

        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Njit.Program.Controls.ComboBoxExtended.CustomItem obj = ((Njit.Program.Controls.ComboBoxExtended.CustomItem)listBox.SelectedItem);
                try
                {
                    (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("DELETE FROM [{0}] WHERE [{1}]=@p", this.TableName, this.KeyField), "@p", obj.Value);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.ErrorCode == -2146232060 && ex.Number == 547)
                    {
                        PersianMessageBox.Show(this, "'" + obj.Caption + "' قابل حذف نیست. از این اطلاعات در جای دیگر استفاده شده است");
                    }
                    else
                    {
                        PersianMessageBox.Show(this, "خطا در حذف '" + obj.Caption + "'" + Environment.NewLine + Environment.NewLine + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در حذف '" + obj.Caption + "'" + Environment.NewLine + Environment.NewLine + ex.Message);
                    return;
                }
                RefreshData();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Njit.Program.Controls.ComboBoxExtended.CustomItem obj = ((Njit.Program.Controls.ComboBoxExtended.CustomItem)listBox.SelectedItem);
                using (Forms.ComboBoxEditItemsEdit f = new ComboBoxEditItemsEdit(obj.Caption))
                {
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("UPDATE [{0}] SET [{1}]=@p1 WHERE [{2}]=@p2", this.TableName, this.CaptionField, this.KeyField), "@p1", f.Value, "@p2", obj.Value);
                        }
                        catch (Exception ex)
                        {
                            PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                            return;
                        }
                        RefreshData();
                    }
                }
            }
        }

        protected void listBox_DoubleClick(object sender, EventArgs e)
        {
            InvokeOnClick(btnEdit, EventArgs.Empty);
        }

        protected void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            InvokeOnClick(btnEdit, EventArgs.Empty);
        }

        protected void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            InvokeOnClick(btnDelete, EventArgs.Empty);
        }

        private void toolStripMenuItemSetAsDefault_Click(object sender, EventArgs e)
        {
            InvokeOnClick(btnSetAsDefault, EventArgs.Empty);
        }

        private void btnSetAsDefault_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Njit.Program.Controls.ComboBoxExtended.CustomItem obj = ((Njit.Program.Controls.ComboBoxExtended.CustomItem)listBox.SelectedItem);
                try
                {
                    (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("UPDATE [{0}] SET [{1}]=@p1", this.TableName, this.IsDefaultField), "@p1", false);
                    (this.DataAccess ?? (Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("UPDATE [{0}] SET [{1}]=@p1 WHERE [{2}]=@p2", this.TableName, this.IsDefaultField, this.KeyField), "@p1", true, "@p2", obj.Value);
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                    return;
                }
                RefreshData();
            }
        }

    }
}
