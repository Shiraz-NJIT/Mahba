using NjitSoftware.Controller.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class SendMessage : Njit.Program.Forms.BaseFormSizable
    {
        public SendMessage()
        {
            InitializeComponent();
        }

        private void radRibbonBarButtonGroup1_Click(object sender, EventArgs e)
        {
            //radrichTextBox1.Font = new Font(Font.FontFamily, 16); ;
        }
        int id_User = 0;
        private void SendgMessage_Load(object sender, EventArgs e)
        {
            var user = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().Users.ToList();
            var us = ToDataTable(user);
            cblTitle.DataSource = us;
            cblTitle.DisplayMember = "UserName";
            cblTitle.ValueMember = "Code";

            Model.Common.ArchiveCommonDataClassesDataContext sdc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            id_User= Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;

        }
        #region انتخاب تمام چک باکس ها
        private void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAll.Checked)
                for (int i = 0; i < cblTitle.Items.Count; i++)
                {
                    cblTitle.SetItemChecked(i, true);
                }

            else
                for (int i = 0; i < cblTitle.Items.Count; i++)
                {
                    cblTitle.SetItemChecked(i, false);
                }
        }
        #endregion
        #region ذخیره پیام
        
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtB_Title.Text.Count() > 0 && cblTitle.CheckedItems.Count > 0)
            {


                Model.Common.Message NewMessage = new Model.Common.Message()
                {
                    SendDate = DateTime.Now,
                    Text = editorMessage.BodyText,
                    Title = txtB_Title.Text,
                    Type = 1,
                    UserCode = id_User,
                };


                bool Result = MessageController.Insert(NewMessage);
                if (Result)
                {
                    int id = 0;
                    foreach (DataRowView checkedItem in cblTitle.CheckedItems)
                    {
                        id = Convert.ToInt32(checkedItem[cblTitle.ValueMember].ToString());
                        MessageUserController.Insert(new Model.Common.MessageUser()
                        {
                            UserCode = id,
                            MessageID = NewMessage.ID,
                            State = (int)Enums.StateTypeMessage.خوانده_نشده,
                            DateShow = DateTime.Now
                        });
                    }
                    PersianMessageBox.Show("پیام ارسال شد", "پیام");
                    this.Close();
                }

            }
            else
            {
                PersianMessageBox.Show("لطفا عنوان و گیرنندگان را مشخص نید","پیام");
            }
        }
        #endregion
        #region تبدیل لیست به دیتاتیبل        
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        #endregion

        private void Unchecked_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAll.Checked)
                for (int i = 0; i < cblTitle.Items.Count; i++)
                {
                    cblTitle.SetItemChecked(i, false);
                }

        }

    }
}
