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
    public partial class ChangePasswordWithAdmin : Njit.Program.Forms.OKCancelForm
    {
        public ChangePasswordWithAdmin()
        {
            InitializeComponent();
        }

        private void ChangePasswordWithAdmin_Load(object sender, EventArgs e)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            List<Model.Common.User> query = dc.Users.ToList().Where(q => q.Visible == Setting.User.ThisProgram.GetUserVisible(q.Code, true)).ToList();
            if (query.Any())
            {
                cmUsers.DataSource = query;
                cmUsers.DisplayMember = "FullName";
                cmUsers.ValueMember = "Code";
            }
        }

        public virtual string HashData(string data)
        {
            Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
            return md5.ComputeHash(data);
        }
       


        private void btnOK_Click(object sender, EventArgs e)
        {
            Model.Common.ArchiveCommonDataClassesDataContext sdc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            try
            {
                Model.Common.User member = sdc.Users.Where(t => t.Code == Convert.ToInt32(cmUsers.SelectedValue)).Single();
                member.Password = HashData(member.Code.ToString() + "1234");
                sdc.SubmitChanges();
                Setting.User.ThisProgram.AddLog(sdc, Setting.User.UserOparatesPlaceNames.تغییر_رمز_عبور, Setting.User.UserOparatesNames.ویرایش, null, ": تغییر رمز عبور  کاربر '"+member.FullName+" توسط : " + Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().FullName + "'");
                MessageBox.Show("پسورد کاربر مورد نظر به '1234' تغییر پیدا کرد");
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
            }

        }
    }
}
