using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.LendingManageForms
{
    public partial class LendingReturn : Njit.Program.Forms.OKCancelForm
    {
        public LendingReturn()
        {
            InitializeComponent();
        }

        public LendingReturn(int lendingID)
        {
            InitializeComponent();
            this.Lending = Controller.Archive.LendingController.GetLending(lendingID: lendingID);
            if (this.Lending.ReturnDate != null)
            {
                dateDateControl.Text = this.Lending.ReturnDate;
                timeTimeControl.Text = this.Lending.ReturnTime;
            }
            else
            {
                dateDateControl.SetDate();
                timeTimeControl.SetTime();
            }
            groupBoxDossier.PersonnelNumber = this.Lending.PersonnelNumber;
        }

        private Model.Archive.Lending _Lending;
        private Model.Archive.Lending Lending
        {
            get
            {
                return _Lending;
            }
            set
            {
                _Lending = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(btnOK.Focused || timeTimeControl.Focused))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            try
            {
                ValidateContent();
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
            try
            {
                if (dateDateControl.DateIsFree)
                    Controller.Archive.LendingController.UnReturnLending(this.Lending.ID);
                else
                    Controller.Archive.LendingController.ReturnLending(this.Lending.ID, dateDateControl.Text, timeTimeControl.Text);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
            ProgramEvents.OnLendingsChanged();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void ValidateContent()
        {
            if (dateDateControl.DateIsFree && !timeTimeControl.TimeIsFree)
                throw new Njit.Common.ValidateException(dateDateControl, "تاریخ را وارد کنید");
            if (!dateDateControl.DateIsFree && dateDateControl.DateIsCorrect == false)
                throw new Njit.Common.ValidateException(dateDateControl, "تاریخ وارد شده نامعتبر است");
            if (!dateDateControl.DateIsFree && dateDateControl.Text.CompareTo(this.Lending.Date) < 0)
                throw new Njit.Common.ValidateException(dateDateControl, "تاریخ بازگشت نمیتواند از تاریخ امانت کوچکتر باشد");
            if ((!dateDateControl.DateIsFree && !timeTimeControl.TimeIsFree) && dateDateControl.Text.CompareTo(this.Lending.Date) == 0 && timeTimeControl.Text.CompareTo(this.Lending.Time) < 0)
                throw new Njit.Common.ValidateException(timeTimeControl, "زمان بازگشت نمیتواند از زمان امانت کوچکتر باشد");
            if (!dateDateControl.DateIsFree && timeTimeControl.TimeIsFree)
                throw new Njit.Common.ValidateException(timeTimeControl, "ساعت را وارد کنید");
            if (!timeTimeControl.TimeIsFree && timeTimeControl.TimeIsCorrect == false)
                throw new Njit.Common.ValidateException(timeTimeControl, "ساعت وارد شده نامعتبر است");
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
