using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using Njit.MessageBox;

namespace Njit.Sql.Forms
{
    public partial class SetSqlConnection : Form
    {
        public SetSqlConnection(string connectionString, string lockServer = null)
        {
            InitializeComponent();
            this.Connection = new SqlConnectionStringBuilder(connectionString);
            this.LockServer = lockServer;
            if (lockServer == null)
            {
                groupBoxLock.Visible = false;
                this.Height -= groupBoxLock.Height;
                this.Text = this.Text.Replace(" و قفل سخت افزاری", "");
            }
        }

        private bool _AutoLoadServers = true;
        [DefaultValue(true)]
        public bool AutoLoadServers
        {
            get
            {
                return _AutoLoadServers;
            }
            set
            {
                _AutoLoadServers = value;
            }
        }

        private SqlConnectionStringBuilder _Connection = null;
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

        private string _LockServer = null;
        [DefaultValue(null)]
        public string LockServer
        {
            get
            {
                return _LockServer;
            }
            set
            {
                _LockServer = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnOK || this.ActiveControl == txtTimeout))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            if (!CheckValues())
                return;
            SaveValues();
            DataAccess da = new DataAccess(Connection.ConnectionString);
            string ErrorMessage;
            if (!da.TestConnection(out ErrorMessage))
            {
                PersianMessageBox.Show(this, "اتصال با پایگاه داده برقرار نیست" + Environment.NewLine + Environment.NewLine + "Error:" + Environment.NewLine + ErrorMessage, "خطای اتصال", MessageBoxButtons.OK);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private bool CheckValues()
        {
            comboBoxServer.Text = comboBoxServer.Text.Trim();
            if (comboBoxServer.Text == "")
            {
                PersianMessageBox.Show(this, "نام یا ادرس سرور را وارد کنید");
                comboBoxServer.Focus();
                return false;
            }
            if (txtDBName.Text == "")
            {
                PersianMessageBox.Show(this, "نام پایگاه داده را وارد کنید");
                txtDBName.Focus();
                txtDBName.SelectAll();
                return false;
            }
            if (checkBoxWinAuthentication.Checked == false)
            {
                if (txtUsername.Text == "")
                {
                    PersianMessageBox.Show(this, "نام کاربری را وارد کنید");
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                    return false;
                }
            }
            txtTimeout.Text = txtTimeout.Text.Trim();
            if (txtTimeout.Text == "")
                txtTimeout.Text = "15";
            int timeout;
            if (!int.TryParse(txtTimeout.Text, out timeout))
            {
                PersianMessageBox.Show(this, "حداکثر زمان انتظار را به صورت درست وارد کنید");
                txtTimeout.Focus();
                return false;
            }
            if (txtLockServer.Text == "(local)")
                txtLockServer.Text = "";
            if (txtLockServer.Text != "")
            {
                if (!IsIPV4(txtLockServer.Text))
                {
                    PersianMessageBox.Show(this, "آدرس IP قفل سخت افزاری به صورت درست وارد نشده است");
                    txtLockServer.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool IsIPV4(string server)
        {
            string[] ipv4 = server.Split('.');
            if (ipv4.Length != 4)
                return false;
            byte temp;
            foreach (var item in ipv4)
            {
                if (!byte.TryParse(item, out temp))
                    return false;
                if (temp < 0 || temp > 255)
                    return false;
            }
            return true;
        }

        private void SaveValues()
        {
            this.Connection.DataSource = comboBoxServer.Text;
            this.Connection.UserInstance = false;
            if (this.Connection.AttachDBFilename != "")
                this.Connection.AttachDBFilename = "";
            this.Connection.InitialCatalog = txtDBName.Text;
            this.Connection.IntegratedSecurity = checkBoxWinAuthentication.Checked;
            this.Connection.UserID = txtUsername.Text;
            this.Connection.Password = txtPassword.Text;
            txtTimeout.Text = txtTimeout.Text.Trim();
            if (txtTimeout.Text == "")
                txtTimeout.Text = "15";
            int timeout;
            if (!int.TryParse(txtTimeout.Text, out timeout))
                timeout = 15;
            this.Connection.ConnectTimeout = timeout;
            this.LockServer = txtLockServer.Text;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox_win_authentication_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWinAuthentication.Checked)
            {
                txtUsername.Text = Environment.MachineName + "\\" + Environment.UserName;
                txtPassword.Text = "";
                txtUsername.Enabled = txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Text = "sa";
                txtUsername.Enabled = txtPassword.Enabled = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadValues();
        }

        private void LoadValues()
        {
            comboBoxServer.Text = this.Connection.DataSource;
            txtDBName.Text = this.Connection.InitialCatalog;
            checkBoxWinAuthentication.Checked = this.Connection.IntegratedSecurity;
            checkBox_win_authentication_CheckedChanged(this, EventArgs.Empty);
            if (!checkBoxWinAuthentication.Checked)
            {
                txtUsername.Text = this.Connection.UserID;
                txtPassword.Text = this.Connection.Password;
            }
            txtTimeout.Text = this.Connection.ConnectTimeout.ToString();
            txtLockServer.Text = this.LockServer;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (AutoLoadServers)
            {
                if (!backgroundWorkerServerList.IsBusy)
                    backgroundWorkerServerList.RunWorkerAsync();
            }
        }

        private void SetDatabases()
        {
            if (comboBoxServer.Text != "")
            {
                try
                {
                    SaveValues();
                    while (txtDBName.Items.Count > 0)
                    {
                        txtDBName.Items.RemoveAt(0);
                    }
                    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(this.Connection.ConnectionString);
                    csb.InitialCatalog = "master";
                    DataAccess da = new DataAccess(csb.ConnectionString);

                    DataTable databaseList = da.GetData("SELECT * FROM [sys].[databases]");
                    foreach (DataRow row in databaseList.Rows)
                    {
                        if (!IsSystemDB(row["name"].ToString()))
                        {
                            txtDBName.Items.Add(row["name"].ToString());
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private bool IsSystemDB(string name)
        {
            return (name == "master" || name == "model" || name == "tempdb" || name == "msdb");
        }

        private void btn_advanced_setting_Click(object sender, EventArgs e)
        {
            //SaveValues();
            //if (this.FormType == FormTypes.TwoConnection)
            //    Njit.Sql.Forms.Advanced.GetInstance(MainConnectionStringBuilder, SettingConnectionStringBuilder).ShowDialog(this);
            //else
            //    Njit.Sql.Forms.Advanced.GetInstance(MainConnectionStringBuilder).ShowDialog(this);
            //LoadValues();
            //SaveValues();
        }

        private void control_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            if (sender is Control)
            {
                string tooltip = mainToolTip.GetToolTip(sender as Control);
                if (!string.IsNullOrEmpty(tooltip))
                {
                    mainToolTip.Show(tooltip, sender as Control, 0, (sender as Control).Height - 0, 5000);
                }
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.F9)
            //{
            //    this.ActiveControl = btnOK;
            //    InvokeOnClick(btnOK, EventArgs.Empty);
            //}
            //else if (e.KeyData == Keys.F6)
            //{
            //    InvokeOnClick(btnAdvancedSetting, EventArgs.Empty);
            //}
        }

        public void HideAllTooltips(Control control)
        {
            foreach (Control item in control.Controls)
            {
                mainToolTip.Hide(item);
                HideAllTooltips(item);
            }
        }

        private void Form_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HideAllTooltips(this);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!CheckValues())
                return;
            SaveValues();
            string ErrorMessage;
            DataAccess da = new DataAccess(Connection.ConnectionString);
            if (!da.TestConnection(out ErrorMessage))
            {
                PersianMessageBox.Show(this, "اتصال با پایگاه داده برقرار نیست" + Environment.NewLine + Environment.NewLine + "Error:" + Environment.NewLine + ErrorMessage, "خطای اتصال", MessageBoxButtons.OK, MessageBox.VDialogIcon.SecurityError, MessageBox.VDialogDefaultButton.Button1, System.Windows.Forms.RightToLeft.No, "خطا در اتصال");
            }
            else
            {
                PersianMessageBox.Show(this, "اتصال با پایگاه داده برقرار است", "", MessageBoxButtons.OK, MessageBox.VDialogIcon.SecuritySuccess, MessageBox.VDialogDefaultButton.Button1, System.Windows.Forms.RightToLeft.No, "اتصال برقرار است");
            }
        }

        private void btn_server_refresh_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerServerList.IsBusy)
                backgroundWorkerServerList.RunWorkerAsync();
        }

        private void backgroundWorkerServerList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> serverList = new List<string>();
            backgroundWorkerServerList.ReportProgress(0);
            try
            {
                if (backgroundWorkerServerList.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
                if (backgroundWorkerServerList.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                foreach (DataRow item in dt.Rows)
                {
                    Version version = new Version(item["Version"].ToString());
                    if (version.Major >= 9)
                        serverList.Add((item["ServerName"].ToString() == Environment.MachineName ? "." : item["ServerName"].ToString()) + ((item["InstanceName"] == DBNull.Value || item["InstanceName"] == null) ? "" : ((string.IsNullOrEmpty(item["InstanceName"].ToString())) ? "" : "\\" + item["InstanceName"].ToString())));
                }
            }
            catch
            {
            }
            finally
            {
                backgroundWorkerServerList.ReportProgress(100);
                e.Result = serverList;
            }
        }

        private void backgroundWorkerServerList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Error != null)
                return;
            List<string> serverList = e.Result as List<string>;
            while (comboBoxServer.Items.Count > 0)
                comboBoxServer.Items.RemoveAt(0);
            foreach (var item in serverList)
                comboBoxServer.Items.Add(item);
        }

        private void backgroundWorkerServerList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //string text = " (در حال تازه سازی لیست سرورها)";
            if (e.ProgressPercentage == 0)
            {
                this.Refresh();
                //this.Text += text;
                btnServerRefresh.Text = "در حال تازه سازی...";
            }
            else if (e.ProgressPercentage == 100)
            {
                btnServerRefresh.Text = "تازه سازی";
                //this.Text = this.Text.Substring(0, this.Text.Length - text.Length);
            }
        }

        private void txtDBName_DropDown(object sender, EventArgs e)
        {
            SetDatabases();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (backgroundWorkerServerList.IsBusy)
                backgroundWorkerServerList.CancelAsync();
        }
    }
}
