using NjitSoftware.Controller.Common;
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
    public delegate void SendMessageToFormShowMessage(string Title, string Message, string DateSent);

    public partial class ShowMessage : Njit.Program.Forms.BaseFormSizable
    {
        public SendMessageToFormShowMessage SendMessage;

        public ShowMessage()
        {
            InitializeComponent();
        }
        private void ShowMessage_Load(object sender, EventArgs e)
        {
            DGVMessage.DataSource = MessageUserController.ListMessage(null, null);
        }
        #region کلیک روی هر سطر و فرستادن پیام به فرم نمایش جزئیات پیام

        private void DGVMessage_Click(object sender, EventArgs e)
        {
            try
            {


                long Id = Convert.ToInt64(DGVMessage.SelectedRows[0].Cells["Id"].Value.ToString());
                string Title = DGVMessage.SelectedRows[0].Cells["Title"].Value.ToString();
                string Text = DGVMessage.SelectedRows[0].Cells["Text"].Value.ToString();
                string DateSand = DGVMessage.SelectedRows[0].Cells["DateSand"].Value.ToString();
                ShowDetailMessage f = new ShowDetailMessage();
                this.SendMessage += f.GetMessage;
                SendMessage(Title, Text, DateSand);

                if (MessageUserController.UpdateState(Id))
                {
                    DGVMessage.DataSource = "";
                    DGVMessage.DataSource = MessageUserController.ListMessage(null, null);
                }
                f.ShowDialog();
            }
            catch
            {

            }
        }
        #endregion

        private void btn_Search_Click(object sender, EventArgs e)
        {
            DateTime StartDate;
            DateTime EndDate;
            try
            {
                
                StartDate = ConvertTo_PersianOREnglish_Date.GetEglishDate(TxtB_FromDate.Text);
                EndDate = ConvertTo_PersianOREnglish_Date.GetEglishDate(TxtB_UntilDate.Text);

                DGVMessage.DataSource = MessageUserController.ListMessage(StartDate, EndDate);
            }
            catch
            {
                PersianMessageBox.Show("فرم تاریخ اشتباه وارد شده است", "خطا");
            }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            TxtB_FromDate.Text = "";
            TxtB_UntilDate.Text = "";
            DGVMessage.DataSource = MessageUserController.ListMessage(null, null);

        }
    }
}
