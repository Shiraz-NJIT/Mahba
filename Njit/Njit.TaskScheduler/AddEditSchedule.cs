using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.TaskScheduler
{
    public partial class AddEditSchedule : Njit.Program.Forms.OKCancelForm
    {
        public AddEditSchedule(Njit.TaskScheduler.ScheduleType.ScheduleTypes allowedScheduleTypes, Schedule schedule)
            : this(allowedScheduleTypes)
        {
            txtName.Text = schedule.Name;
            txtDescription.Text = schedule.Description;
            comboBoxScheduleType.SelectedItem = comboBoxScheduleType.Items.Cast<ScheduleType>().Where(t => t.Title == schedule.ScheduleType.Title).Single();
            comboBoxRepeat.SelectedItem = comboBoxRepeat.Items.Cast<ScheduleRepeat>().Where(t => t.Title == schedule.RepeatType.Title).Single();

            ScheduleRepeat selectedScheduleRepeat = (ScheduleRepeat)comboBoxRepeat.SelectedItem;
            if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.NoRepeat)
            {
                ScheduleRepeatTypes.NoRepeat st = (schedule.RepeatType as ScheduleRepeatTypes.NoRepeat);
                txtStartDateNoRepeat.Text = st.StartDate;
                txtStartTimeNoRepeat.Text = st.StartTime;
            }
            else if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Daily)
            {
                ScheduleRepeatTypes.Daily st = (schedule.RepeatType as ScheduleRepeatTypes.Daily);
                txtStartDateDaily.Text = st.StartDate;
                txtEndDateDaily.Text = st.EndDate;
                txtTimeDaily.Text = st.ExecuteTime;
            }
            else if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Weekly)
            {
                ScheduleRepeatTypes.Weekly st = (schedule.RepeatType as ScheduleRepeatTypes.Weekly);
                txtStartDateWeekly.Text = st.StartDate;
                txtStartTimeWeekly.Text = st.StartTime;
                txtEndDateWeekly.Text = st.EndDate;
                txtEndTimeWeekly.Text = st.EndTime;
                txtTimeWeekly.Text = st.ExecuteTime;
                weekdaysSelect.SelectedWeeks = st.WeekDays;
            }
            else if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Monthly)
            {
                ScheduleRepeatTypes.Monthly st = (schedule.RepeatType as ScheduleRepeatTypes.Monthly);
                txtStartDateMonthly.Text = st.StartDate;
                txtStartTimeMonthly.Text = st.StartTime;
                txtEndDateMonthly.Text = st.EndDate;
                txtEndTimeMonthly.Text = st.EndTime;
                txtTimeMonthly.Text = st.ExecuteTime;
                txtMonthDay.Text = st.MonthDay.ToString();
                monthsSelect.SelectedMonths = st.Months;
            }

            ScheduleType selectedScheduleType = (ScheduleType)comboBoxScheduleType.SelectedItem;
            if (selectedScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.BackupDatabase)
            {
                ScheduleTypes.BackupDatabase st = (schedule.ScheduleType as ScheduleTypes.BackupDatabase);
                //SetDatabaseName(new SqlConnectionStringBuilder(ScheduleTypes.BackupDatabase.ConnectionString));
                txtBackupPath.Text = st.SaveTo;
                txtBackupName.Text = st.FileName;
                comboBoxSetBackupNameType.SelectedIndex = (int)st.SetNameType;
            }
            else if (selectedScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.ExecuteProgram)
            {
                ScheduleTypes.ExecuteProgram st = (schedule.ScheduleType as ScheduleTypes.ExecuteProgram);
                txtProgramFilePath.Text = st.FilePath;
                txtProgramParameter.Text = st.Parameter;
            }
            else if (selectedScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.ShowMessage)
            {
                ScheduleTypes.ShowMessage st = (schedule.ScheduleType as ScheduleTypes.ShowMessage);
                txtMessageTitle.Text = st.MessageTitle;
                txtMessageBody.Text = st.MessageBody;
            }

        }

        public AddEditSchedule(Njit.TaskScheduler.ScheduleType.ScheduleTypes allowedScheduleTypes)
        {
            InitializeComponent();
            comboBoxSetBackupNameType.SelectedIndex = 0;
            List<ScheduleRepeat> repeatTypeList = new List<ScheduleRepeat>();
            repeatTypeList.Add(new ScheduleRepeatTypes.NoRepeat());
            repeatTypeList.Add(new ScheduleRepeatTypes.Daily());
            repeatTypeList.Add(new ScheduleRepeatTypes.Weekly());
            repeatTypeList.Add(new ScheduleRepeatTypes.Monthly());
            this.repeatTypeBindingSource.DataSource = repeatTypeList;
            this.repeatTypeBindingSource.Position = 2;

            List<ScheduleType> scheduleTypeList = new List<ScheduleType>();
            if ((allowedScheduleTypes & ScheduleType.ScheduleTypes.BackupDatabase) == ScheduleType.ScheduleTypes.BackupDatabase)
                scheduleTypeList.Add(new ScheduleTypes.BackupDatabase());
            if ((allowedScheduleTypes & ScheduleType.ScheduleTypes.ShowMessage) == ScheduleType.ScheduleTypes.ShowMessage)
                scheduleTypeList.Add(new ScheduleTypes.ShowMessage());
            if ((allowedScheduleTypes & ScheduleType.ScheduleTypes.ExecuteProgram) == ScheduleType.ScheduleTypes.ExecuteProgram)
                scheduleTypeList.Add(new ScheduleTypes.ExecuteProgram());
            this.scheduleTypeBindingSource.DataSource = scheduleTypeList;
        }

        private void comboBoxRepeat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxRepeat.SelectedValue == null)
                return;
            SelectScheduleRepeatPage();
        }

        private void SelectScheduleRepeatPage()
        {
            ScheduleRepeat selectedValue = (ScheduleRepeat)comboBoxRepeat.SelectedItem;
            if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.NoRepeat)
            {
                panelScheduleRepeat.SelectedPage = pageNoRepeat;
            }
            else if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Daily)
            {
                panelScheduleRepeat.SelectedPage = pageRepeatDaily;
            }
            else if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Weekly)
            {
                panelScheduleRepeat.SelectedPage = pageRepeatWeekly;
            }
            else if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Monthly)
            {
                panelScheduleRepeat.SelectedPage = pageRepeatMonthly;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateContent();
            }
            catch (Njit.Common.ValidateException ex)
            {
                PersianMessageBox.Show(ex.Message);
                ex.Control.Leave -= Control_Leave;
                ex.Control.Focus();
                ex.Control.Leave += Control_Leave;
                errorProvider.SetError(ex.Control, ex.Message);
                return;
            }
            ScheduleType scheduleType = GetScheduleType();
            ScheduleRepeat scheduleRepeat = GetScheduleRepeat();
            Schedule schedule = new Schedule(txtName.Text, txtDescription.Text, scheduleType, scheduleRepeat);
            this.Tag = schedule;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private ScheduleRepeat GetScheduleRepeat()
        {
            ScheduleRepeat selectedValue = (ScheduleRepeat)comboBoxRepeat.SelectedItem;
            if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.NoRepeat)
            {
                return new ScheduleRepeatTypes.NoRepeat(txtStartDateNoRepeat.Text, txtStartTimeNoRepeat.Text);
            }
            else if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Daily)
            {
                return new ScheduleRepeatTypes.Daily(txtStartDateDaily.Text, txtEndDateDaily.Text, txtTimeDaily.Text);
            }
            else if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Weekly)
            {
                return new ScheduleRepeatTypes.Weekly(txtStartDateWeekly.Text, txtStartTimeWeekly.Text, txtEndDateWeekly.Text, txtEndTimeWeekly.Text, txtTimeWeekly.Text, weekdaysSelect.SelectedWeeks.ToArray());
            }
            else if (selectedValue.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Monthly)
            {
                return new ScheduleRepeatTypes.Monthly(txtStartDateMonthly.Text, txtStartTimeMonthly.Text, txtEndDateMonthly.Text, txtEndTimeMonthly.Text, txtTimeMonthly.Text, monthsSelect.SelectedMonths.ToArray(), txtMonthDay.Text.ToInt());
            }
            throw new Exception();
        }

        private ScheduleType GetScheduleType()
        {
            ScheduleType selectedValue = (ScheduleType)comboBoxScheduleType.SelectedItem;
            if (selectedValue.TypeOfSchedule == ScheduleType.ScheduleTypes.BackupDatabase)
            {
                return new ScheduleTypes.BackupDatabase(txtBackupPath.Text, txtBackupName.Text, (ScheduleTypes.BackupDatabase.SetNameTypes)comboBoxSetBackupNameType.SelectedIndex);
            }
            else if (selectedValue.TypeOfSchedule == ScheduleType.ScheduleTypes.ExecuteProgram)
            {
                return new ScheduleTypes.ExecuteProgram(txtProgramFilePath.Text, txtProgramParameter.Text);
            }
            else if (selectedValue.TypeOfSchedule == ScheduleType.ScheduleTypes.ShowMessage)
            {
                return new ScheduleTypes.ShowMessage(txtMessageTitle.Text, txtMessageBody.Text);
            }
            throw new Exception();
        }

        void Control_Leave(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void ValidateContent()
        {
            if (txtName.Text.Trim() == "")
                throw new Njit.Common.ValidateException(txtName, "نام برنامه زمانی را وارد کنید");
            if (comboBoxScheduleType.SelectedValue == null)
                throw new Njit.Common.ValidateException(comboBoxScheduleType, "نوع برنامه زمانی را انتخاب کنید");
            if (comboBoxRepeat.SelectedValue == null)
                throw new Njit.Common.ValidateException(comboBoxRepeat, "نوع تکرار برنامه زمانی را انتخاب کنید");
            ScheduleType selectedScheduleType = (ScheduleType)comboBoxScheduleType.SelectedItem;
            if (selectedScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.BackupDatabase)
            {
                //if (txtDatabaseName.Text == "")
                //    throw new Njit.Common.ValidateException(txtDatabaseName, "پایگاه داده انتخاب نشده است");
                if (txtBackupPath.Text == "")
                    throw new Njit.Common.ValidateException(txtBackupPath, "مسیر ذخیره فایل های پشتیبان انتخاب نشده است");
                if (!System.IO.Directory.Exists(txtBackupPath.Text))
                    throw new Njit.Common.ValidateException(txtBackupPath, "مسیر ذخیره فایل های پشتیبان نامعتبر است");
                if (txtBackupName.Enabled && txtBackupName.Text == "")
                    throw new Njit.Common.ValidateException(txtBackupName, "نام فایل پشتیبان وارد نشده است");
            }
            else if (selectedScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.ExecuteProgram)
            {
                if (txtProgramFilePath.Text.Trim() == "")
                    throw new Njit.Common.ValidateException(txtProgramFilePath, "هیچ برنامه ای انتخاب نشده است");
                if (!System.IO.File.Exists(txtProgramFilePath.Text))
                    throw new Njit.Common.ValidateException(txtProgramFilePath, "فایل انتخاب شده وجود ندارد");
            }
            else if (selectedScheduleType.TypeOfSchedule == ScheduleType.ScheduleTypes.ShowMessage)
            {
                if (txtMessageBody.Text.Trim() == "" && txtMessageTitle.Text.Trim() == "")
                    throw new Njit.Common.ValidateException(txtMessageTitle, "عنوان یا متنی برای پیام وارد نشده است");
            }
            ScheduleRepeat selectedScheduleRepeat = (ScheduleRepeat)comboBoxRepeat.SelectedItem;
            if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.NoRepeat)
            {
                if (txtStartDateNoRepeat.DateIsFree)
                    throw new Njit.Common.ValidateException(txtStartDateNoRepeat, "تاریخ انجام وارد نشده است");
                if (!txtStartDateNoRepeat.DateIsCorrect)
                    throw new Njit.Common.ValidateException(txtStartDateNoRepeat, "تاریخ انجام به صورت درست وارد نشده است");
                if (txtStartTimeNoRepeat.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtStartTimeNoRepeat, "ساعت انجام وارد نشده است");
                if (!txtStartTimeNoRepeat.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtStartTimeNoRepeat, "ساعت انجام به صورت درست وارد نشده است");
            }
            else if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Daily)
            {
                if (txtStartDateDaily.DateIsFree)
                    throw new Njit.Common.ValidateException(txtStartDateDaily, "تاریخ شروع وارد نشده است");
                if (!txtStartDateDaily.DateIsCorrect)
                    throw new Njit.Common.ValidateException(txtStartDateDaily, "تاریخ شروع به صورت درست وارد نشده است");

                if (txtEndDateDaily.DateIsFree)
                    throw new Njit.Common.ValidateException(txtEndDateDaily, "تاریخ پایان وارد نشده است");
                if (!txtEndDateDaily.DateIsCorrect)
                    throw new Njit.Common.ValidateException(txtEndDateDaily, "تاریخ پایان به صورت درست وارد نشده است");

                if (txtTimeDaily.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtTimeDaily, "مشخص نشده است هر روز چه ساعتی برنامه زمانی اجرا شود");
                if (!txtTimeDaily.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtTimeDaily, "ساعت اجرای برنامه زمانی به صورت درست وارد نشده است");
            }
            else if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Weekly)
            {
                if (txtStartDateWeekly.DateIsFree)
                    throw new Njit.Common.ValidateException(txtStartDateWeekly, "تاریخ شروع وارد نشده است");
                if (!txtStartDateWeekly.DateIsCorrect)
                    throw new Njit.Common.ValidateException(txtStartDateWeekly, "تاریخ شروع به صورت درست وارد نشده است");
                if (txtStartTimeWeekly.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtStartTimeWeekly, "ساعت شروع وارد نشده است");
                if (!txtStartTimeWeekly.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtStartTimeWeekly, "ساعت شروع به صورت درست وارد نشده است");

                if (txtEndDateWeekly.DateIsFree)
                    throw new Njit.Common.ValidateException(txtEndDateWeekly, "تاریخ پایان وارد نشده است");
                if (!txtEndDateWeekly.DateIsCorrect)
                    throw new Njit.Common.ValidateException(txtEndDateWeekly, "تاریخ پایان به صورت درست وارد نشده است");
                if (txtEndTimeWeekly.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtEndTimeWeekly, "ساعت پایان وارد نشده است");
                if (!txtEndTimeWeekly.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtEndTimeWeekly, "ساعت پایان به صورت درست وارد نشده است");

                if (weekdaysSelect.SelectedWeeks.Count() == 0)
                    throw new Njit.Common.ValidateException(weekdaysSelect, "هیچ روزی انتخاب نشده است");

                if (txtTimeWeekly.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtTimeWeekly, "مشخص نشده است چه ساعتی برنامه زمانی اجرا شود");
                if (!txtTimeWeekly.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtTimeWeekly, "ساعت اجرای برنامه زمانی به صورت درست وارد نشده است");
            }
            else if (selectedScheduleRepeat.TypeOfRepeat == ScheduleRepeat.ScheduleRepeats.Monthly)
            {
                if (txtStartDateMonthly.DateIsFree)
                    throw new Njit.Common.ValidateException(txtStartDateMonthly, "تاریخ شروع وارد نشده است");
                if (!txtStartDateMonthly.DateIsCorrect)
                    throw new Njit.Common.ValidateException(txtStartDateMonthly, "تاریخ شروع به صورت درست وارد نشده است");
                if (txtStartTimeMonthly.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtStartTimeMonthly, "ساعت شروع وارد نشده است");
                if (!txtStartTimeMonthly.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtStartTimeMonthly, "ساعت شروع به صورت درست وارد نشده است");

                if (txtEndDateMonthly.DateIsFree)
                    throw new Njit.Common.ValidateException(txtEndDateMonthly, "تاریخ پایان وارد نشده است");
                if (!txtEndDateMonthly.DateIsCorrect)
                    throw new Njit.Common.ValidateException(txtEndDateMonthly, "تاریخ پایان به صورت درست وارد نشده است");
                if (txtEndTimeMonthly.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtEndTimeMonthly, "ساعت پایان وارد نشده است");
                if (!txtEndTimeMonthly.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtEndTimeMonthly, "ساعت پایان به صورت درست وارد نشده است");

                if (monthsSelect.SelectedMonths.Count() == 0)
                    throw new Njit.Common.ValidateException(monthsSelect, "هیچ ماهی انتخاب نشده است");

                if (txtMonthDay.Text == "")
                    throw new Njit.Common.ValidateException(txtMonthDay, "روز ماه مشخص نشده است");

                if (txtMonthDay.Text.TryToInt().HasValue == false)
                    throw new Njit.Common.ValidateException(txtMonthDay, "روز ماه به درستی مشخص نشده است");

                if (txtTimeMonthly.TimeIsFree)
                    throw new Njit.Common.ValidateException(txtTimeMonthly, "مشخص نشده است چه ساعتی برنامه زمانی اجرا شود");
                if (!txtTimeMonthly.TimeIsCorrect)
                    throw new Njit.Common.ValidateException(txtTimeMonthly, "ساعت اجرای برنامه زمانی به صورت درست وارد نشده است");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxScheduleType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxScheduleType.SelectedItem == null)
                return;
            SelectScheduleTypePage();
        }

        private void SelectScheduleTypePage()
        {
            ScheduleType selectedValue = (ScheduleType)comboBoxScheduleType.SelectedItem;
            if (selectedValue.TypeOfSchedule == ScheduleType.ScheduleTypes.BackupDatabase)
            {
                panelScheduleType.SelectedPage = pageBackup;
            }
            else if (selectedValue.TypeOfSchedule == ScheduleType.ScheduleTypes.ExecuteProgram)
            {
                panelScheduleType.SelectedPage = pageExecute;
            }
            else if (selectedValue.TypeOfSchedule == ScheduleType.ScheduleTypes.ShowMessage)
            {
                panelScheduleType.SelectedPage = pageMessage;
            }
        }

        private void btnSelectProgram_Click(object sender, EventArgs e)
        {
            if (openAppDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtProgramFilePath.Text = openAppDialog.FileName;
            }
        }

        private void comboBoxSetBackupNameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSetBackupNameType.SelectedIndex)
            {
                case 1:
                case 2:
                    txtBackupName.Enabled = true;
                    break;
                case 0:
                    txtBackupName.Text = "";
                    txtBackupName.Enabled = false;
                    break;
            }
        }

        //private void btnSelectDatabase_Click(object sender, EventArgs e)
        //{
        //    Njit.Sql.Forms.SetSqlConnection f = txtDatabaseName.Tag == null ? new Sql.Forms.SetSqlConnection("") : new Sql.Forms.SetSqlConnection(txtDatabaseName.Tag.ToString());
        //    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        SetDatabaseName(f.Connection);
        //    }
        //}

        //private void SetDatabaseName(SqlConnectionStringBuilder csb)
        //{
        //    txtDatabaseName.Text = /*"Server=" + csb.DataSource + " Database=" +*/ csb.InitialCatalog;
        //    txtDatabaseName.Tag = csb.ConnectionString;
        //}

        private void btnSelectBackupPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

    }
}
