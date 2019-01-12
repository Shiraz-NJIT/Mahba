using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.ElegantProgram.Forms
{
    public partial class MainForm : Njit.Program.Forms.MainForm
    {
        public MainForm()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                ApplicationCommands.ExitCommand.Executed += ExitCommand_Executed;
            }
        }

        public override void SetDateTime()
        {
            lblDate.Text = (Njit.Common.PersianCalendar.GetDayOfWeekName(DateTime.Now) + " " + Njit.Common.PersianCalendar.GetDateWithMonthName(DateTime.Now, " ")).PadRight(35);
            lblTime.Text = DateTime.Now.ToLongTimeString().PadRight(25);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            timerDateTime.Start();
        }

        private void ExitCommand_Executed(object sender, Elegant.Ui.CommandExecutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (Options.SettingInitializer != null)
            {
                if (!Options.SettingInitializer.GetUserSetting().Logout())
                {
                    Options.SettingInitializer.GetProgramSetting().ShowExitDialog = false;
                    this.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            this.ShutdownWhenExit = true;
            this.Close();
        }

    }
}
