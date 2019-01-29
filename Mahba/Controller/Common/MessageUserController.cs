using NjitSoftware.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Common
{
    class MessageUserController
    {
        #region تعداد پیام های کاربر جاری 
        internal static int GetCountMessageForUser()
        {

            int id_User = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;
            Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return db.MessageUsers.Where(a => a.UserCode == id_User).Count();

        }
        #endregion

        #region ذخیره پیام برای کاربران

        internal static bool Insert(Model.Common.MessageUser model)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                db.MessageUsers.InsertOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion
        #region لیست پیام ها برای نمایش
        /// <summary>
        /// لیست پیام ها را می اوردد
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns> اگر تاریخ نال نباشد بر اساس تاریخ لیست را برمیگرداند و اگر نال باشد کل پیام های کاربر جاری را برمیگرداند</returns>
        internal static List<MessageViwModel> ListMessage(DateTime? StartDate, DateTime? EndDate)
        {
            int index = 1;
            Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            int id_User = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;

            List<Model.Common.MessageUser> Messages = db.MessageUsers.Where(a => a.UserCode == id_User).ToList();
            if (StartDate != null && EndDate != null)//search
                Messages = Messages.Where(a => a.Message.SendDate > StartDate && a.Message.SendDate < EndDate).ToList();

            List<MessageViwModel> ListMessages = new List<MessageViwModel>();
            foreach (var item in Messages)
            {
                var message = new MessageViwModel();
                message.Counter = index++;
                message.DateSand = ConvertTo_PersianOREnglish_Date.GetPersianDate(item.Message.SendDate);
                message.Id = item.ID;
                message.Title = item.Message.Title;
                message.Text = item.Message.Text;
                message.Sender = item.Message.User.FullName;
                message.State = item.State == (int)StateTypeMessage.خوانده_شده ? "خوانده شده" : "خوانده نشده";
                ListMessages.Add(message);
            }
            return ListMessages;
        }
        #endregion
        #region تغییر وضعییت خوانده نشده به خوانده شده

        internal static bool UpdateState(long id)
        {
            try
            {
                Model.Common.ArchiveCommonDataClassesDataContext db = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                var message = db.MessageUsers.Where(a => a.ID == id).FirstOrDefault();
                if (message.State == (int)Enums.StateTypeMessage.خوانده_نشده)
                {
                    message.State = (int)Enums.StateTypeMessage.خوانده_شده;
                    message.DateShow = DateTime.Now;
                    db.SubmitChanges();
                    return true;

                }
                else
                    return false;

            }
            catch
            {
                return false;
            }

        }
        #endregion

    }
    public class MessageViwModel
    {
        public int Counter { get; set; }
        public long Id { get; set; }
        public string Sender { get; set; }
        public string Title { get; set; }
        public string DateSand { get; set; }
        public string State { get; set; }
        public string Text { get; set; }

    }
}
