using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.UserManageForms
{
    public partial class UserLog : Njit.Program.ComponentOne.Forms.ListForm
    {
        public UserLog()
        {
            InitializeComponent();
            Setting.Program.ThisProgram.LoadFormState(this);
            ProgramEvents.UserLogsChanged += ProgramEvents_UserLogsChanged;
        }

        private void ProgramEvents_UserLogsChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        Dictionary<int, string> ListArchive;
        private static UserLog _Instance;
        public static UserLog Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UserLog();
                if (_Instance.IsDisposed)
                    _Instance = new UserLog();
                return _Instance;
            }
        }
        private void LoadArchives()
        {
            ListArchive = new Dictionary<int, string>();
            foreach (var item in Controller.Common.ArchiveController.GetActiveArchives())
            {
                ListArchive.Add(item.ID, item.Title);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadArchives();
            comboBoxUsers.SelectedValueChanged -= comboBoxUsers_SelectedValueChanged;
            dateFromTextBox.TextChanged -= dateFromTextBox_TextChanged;
            dateToTextBox.TextChanged -= dateToTextBox_TextChanged;
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            membershipBindingSource.DataSource = dc.Users.ToArray().Where(t => Setting.User.ThisProgram.IsMembershipActiveAndVisible(t)).Select(t => t).ToList();
            membershipBindingSource.Insert(0, Model.Common.User.GetNewInstance(-1, "", "", "همه کاربران", "", null, "", "", null, false, false, null, ""));
            comboBoxUsers.SelectedValue = -1;
            dateFromTextBox.SetDate(DateTime.Now);
            dateFromTextBox.Month = dateFromTextBox.Month - 1;
            dateFromTextBox.Day = 1;
            dateToTextBox.SetDate(DateTime.Now);
            comboBoxUsers.SelectedValueChanged += comboBoxUsers_SelectedValueChanged;
            dateFromTextBox.TextChanged += dateFromTextBox_TextChanged;
            dateToTextBox.TextChanged += dateToTextBox_TextChanged;
            //this.RefreshData();
            mainRibbon.Minimized = true;
            mainRibbon.Visible = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            ProgramEvents.UserLogsChanged -= ProgramEvents_UserLogsChanged;
        }

        public override void RefreshData()
        {
            base.RefreshData();
            if (comboBoxUsers.SelectedValue == null)
            {
                this.userLogBindingSource.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            if (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text) == Njit.Program.Controls.DateControl.CheckDateResult.Error)
            {
                this.userLogBindingSource.DataSource = new List<NjitSoftware.UserLogView>();
                return;
            }
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            IQueryable<Model.Common.UserLog> data;
            if (((int)comboBoxUsers.SelectedValue == -1))
                data = dc.UserLogs.Select(t => t);
            else
                data = dc.UserLogs.Where(t => t.UserCode == (int)comboBoxUsers.SelectedValue).Select(t => t).OrderByDescending(q => q.ID);

            List<NjitSoftware.UserLogView> userLogs = new List<NjitSoftware.UserLogView>();

            int index = 0;
            foreach (var item in data)
            {
                try
                {
                    NjitSoftware.UserLogView userlog = Setting.User.ThisProgram.GetUserLogView(item);
                    userlog.Radif = ++index;
                    userlog.Operation = GetOperation(userlog.Operation);
                    if (userlog.Unit != null)
                    {
                        userlog.Unit = GetUnit(userlog.Unit);
                        if (userlog.Unit == GetUnit((Convert.ToInt32(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده)).ToString()))
                            continue;
                    }
                    userlog.ArchiveID = ListArchive.FirstOrDefault(q => q.Key.ToString() == userlog.ArchiveID).Value;
                    userLogs.Add(userlog);
                }
                catch (System.Security.Cryptography.CryptographicException)
                {
                    PersianMessageBox.Show(this, "داده نامعتبر پیدا شد");
                }
            }

            switch (Njit.Program.Controls.DateControl.CompareDate(dateFromTextBox.Text, dateToTextBox.Text))
            {
                case Njit.Program.Controls.DateControl.CheckDateResult.Both:
                    this.userLogBindingSource.DataSource = userLogs.Where(t => t.Date.CompareTo(dateFromTextBox.Text) >= 0 && t.Date.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date1:
                    this.userLogBindingSource.DataSource = userLogs.Where(t => t.Date.CompareTo(dateFromTextBox.Text) >= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Date2:
                    this.userLogBindingSource.DataSource = userLogs.Where(t => t.Date.CompareTo(dateToTextBox.Text) <= 0);
                    break;
                case Njit.Program.Controls.DateControl.CheckDateResult.Error:
                    return;
                case Njit.Program.Controls.DateControl.CheckDateResult.Free:
                    this.userLogBindingSource.DataSource = userLogs;
                    break;
            }
            radGridView.BestFitColumnsSmart();
            radGridView.ClipboardCopyMode = Telerik.WinControls.UI.GridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
        }

        public string GetUnit(string code)
        {
            try
            {
                return Enum.GetName(typeof(Setting.User.UserOparatesPlaceNames), short.Parse(code)).Replace("_", " ");
            }
            catch { return ""; }
        }

        public string GetOperation(string code)
        {
            try
            {
                return Enum.GetName(typeof(Setting.User.UserOparatesNames), short.Parse(code)).Replace("_", " ");
            }
            catch { return ""; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateFromTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateToTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBoxUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

       
    }
}
