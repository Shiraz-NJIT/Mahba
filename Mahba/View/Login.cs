using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class Login : Njit.Program.Forms.LoginForm
    {
        public Login()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            this.Refresh();
            View.Main.Instance.Refresh();
            base.OnShown(e);
        }

        public override bool CheckSqlConnection()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataAccess.CommonDataAccess da = new DataAccess.CommonDataAccess();
                if (!da.TestConnection())
                {
                    System.Windows.Forms.DialogResult result = PersianMessageBox.Show(this, "ارتباط با سرور پایگاه داده برقرار نیست\r\nمایل به تغییر تنظیمات شبکه هستید؟", "تغییر تنظیمات شبکه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                        ChangeNetworkSettings();
                    return false;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            return true;
        }

        public override void LoadUsers()
        {
            this.membershipBindingSource.DataSource = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().Users.ToArray().Where(t => Setting.User.ThisProgram.IsMembershipActiveAndVisible(t)).Select(t => t).ToList();
        }

        public override void ChangeNetworkSettings()
        {
            using (Njit.Sql.Forms.SetSqlConnection f = new Njit.Sql.Forms.SetSqlConnection(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString, Setting.Sql.ThisProgram.LockServer))
            {
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        Setting.Sql.ThisProgram.DatabaseConnection = new System.Data.SqlClient.SqlConnectionStringBuilder(f.Connection.ConnectionString);
                        Setting.Sql.ThisProgram.LockServer = f.LockServer;
                        Setting.Sql.ThisProgram.Save();
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در ذخیره تنظیمات سرور" + "\r\n\r\n" + ex.Message);
                    }
                    LoadUsers();
                }
            }
        }

    }
}
