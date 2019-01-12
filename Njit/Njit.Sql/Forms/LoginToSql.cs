using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Njit.Sql.Forms
{
    public partial class LoginToSql : Form
    {
        public LoginToSql()
        {
            InitializeComponent();
            comboBoxAuthentication.SelectedIndex = 0;
            ComboBoxAuthenticationSelectedIndexChanged(this.comboBoxAuthentication, EventArgs.Empty);
        }
        public LoginToSql(string ConnectionString)
        {
            InitializeComponent();
            if (ConnectionString != null)
            {
                this.Connection = new SqlConnectionStringBuilder(ConnectionString);
                comboBoxServer.Text = this.Connection.DataSource;
                comboBoxAuthentication.SelectedIndex = this.Connection.IntegratedSecurity ? 0 : 1;
                ComboBoxAuthenticationSelectedIndexChanged(this.comboBoxAuthentication, EventArgs.Empty);
                txtUsername.Text = this.Connection.UserID;
                txtPassword.Text = this.Connection.Password;
                txtInitialCatalog.Text = this.Connection.InitialCatalog;
            }
        }

        private static Forms.LoginToSql _Instance;
        public static Forms.LoginToSql Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Forms.LoginToSql();
                if (_Instance.IsDisposed)
                    _Instance = new Forms.LoginToSql();
                return _Instance;
            }
        }

        private SqlConnectionStringBuilder _Connection = null;
        [Browsable(false)]
        [DefaultValue(null)]
        public SqlConnectionStringBuilder Connection
        {
            get
            {
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }

        private string _UserName = null;
        [DefaultValue(null)]
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        private void ComboBoxAuthenticationSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAuthentication.SelectedIndex == 0)
            {
                txtUsername.Text = Environment.MachineName + @"\" + Environment.UserName;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Text = "";
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private List<string> _DataSources;
        public List<string> DataSources
        {
            get
            {
                if (_DataSources == null)
                    _DataSources = new List<string>();
                return _DataSources;
            }
            set
            {
                _DataSources = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnConnect || this.ActiveControl == txtInitialCatalog))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            if (comboBoxServer.Text == "")
            {
                PersianMessageBox.Show(this, "نام یا آدرس سرور را وارد کنید");
                comboBoxServer.Focus();
                comboBoxServer.SelectAll();
                return;
            }
            string connectionString;
            if (comboBoxAuthentication.SelectedIndex == 0)
            {
                connectionString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", comboBoxServer.Text, txtInitialCatalog.Text);
            }
            else
            {
                connectionString = string.Format(@"Data Source={0};Initial Catalog={3};User ID={1};Password={2}", comboBoxServer.Text, txtUsername.Text, txtPassword.Text, txtInitialCatalog.Text);
            }
            DataAccess da = new DataAccess(connectionString);
            string error;
            if (!da.TestConnection(out error))
            {
                PersianMessageBox.Show(this, "خطا در اتصال" + Environment.NewLine + Environment.NewLine + error);
                return;
            }
            this.Connection = new SqlConnectionStringBuilder(connectionString);
            UserName = txtUsername.Text;
            this.Tag = connectionString;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void backgroundWorkerServers_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorkerServers.ReportProgress(0);
            DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            if (backgroundWorkerServers.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            foreach (DataRow item in dt.Rows)
            {
                string name = item["ServerName"].ToString() + ((item["InstanceName"] == DBNull.Value || item["InstanceName"] == null || (item["InstanceName"] is string && ((string)item["InstanceName"]) == "")) ? ("") : ("\\" + item["InstanceName"].ToString()));
                this.DataSources.Add(name.Replace(Environment.MachineName, "(local)"));
            }
        }

        private void backgroundWorkerServers_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblServersRefresh.Text = "...";
        }

        private void backgroundWorkerServers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Error != null)
                PersianMessageBox.Show(e.Error.Message);
            lblServersRefresh.Text = "";
            foreach (var item in this.DataSources)
            {
                if (comboBoxServer.Items.Contains(item) == false)
                    comboBoxServer.Items.Insert(0, item);
            }
        }
    }
}
