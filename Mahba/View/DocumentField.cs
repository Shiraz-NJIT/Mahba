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
    public delegate void SendDataGridToFrmArchiveDocumentManagment(Dictionary<string, string> value, Dictionary<string, string> NewData, string type);

    public partial class DocumentField : Njit.Program.Forms.BaseFormSizable
    {
        public event SendDataGridToFrmArchiveDocumentManagment SentDataToForm;

        public DocumentField()
        {

            InitializeComponent();

        }
        public string SafeFarsiStr(string input)
        {
            return input.Replace("ی", "ی").Replace("ک", "ک").Replace("ي", "ی");
        }
        bool isSearch = true;//اگر این مقدار ترو بود سرچ انجام میشود -وقتی که روی دیتا گرید کلیک شد این متغیر فالس میشود تا سرچ انجام نشود و وقتی هم مقدار تکست باکس خالی شد باز ترو میشود
        string TypeClickF1 = "";//زمانی که داده از فرم2میره به فرم1این بر اساس این مقدار متوجه میشیم کدام بخش بوده است
        Dictionary<string, string> ListData;
        #region گرفتن داده از فرم قبل و پر کردن دیتاگریدویوو

        public void getData(Dictionary<string, string> Data, string type)
        {
            ListData = Data;
            switch (type)
            {
                case "Field12":
                    this.Text = "عنوان نامه";
                    break;
                case "Field10":
                    this.Text = "مخاطب نامه";
                    break;
                case "Field14":
                    this.Text = "اقدام کننده";
                    break;
                default:
                    break;
            }
            TypeClickF1 = type;
            GridViewData.DataSource = "";
            GridViewData.DataSource = Data;

        }
        #endregion
        #region تابع ذخیره و ویرایش

        private void Add_update()
        {
            try
            {


                if (ListData.Where(a => a.Key == int.Parse(txtB_id.Text).ToString()).Count() > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("این کد وجود دارد آیا میخواهید ویرایش کنید", "سوال", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);

                            (da ?? (Njit.Program.Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("UPDATE [{0}] SET [{1}]=@p1 WHERE [{2}]=@p2", TypeClickF1, "Title", "ID"), "@p1", txtB_title.Text, "@p2", int.Parse(txtB_id.Text));
                        }
                        catch
                        {
                            MessageBox.Show(" خطا در ویرایش");
                        }

                    }

                }
                else
                {
                    DialogResult dialogResultAdd = MessageBox.Show("آیا میخواهید اضافه کنید", "سوال", MessageBoxButtons.YesNo);
                    if (dialogResultAdd == DialogResult.Yes)
                    {
                        try
                        {
                            if (txtB_title.Text.Count() > 0)
                            {
                                Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                                (da ?? (Njit.Program.Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("INSERT INTO [{0}] ([{1}]) VALUES(@p)", TypeClickF1, "Title"), "@p", txtB_title.Text);
                            }
                            else
                            {
                                MessageBox.Show("عنوان را وارد کنید");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("دباره تلاش کنید");
                        }
                    }
                }
                txtB_title.Clear();
                txtB_id.Clear();
                ChangeDataGrid(TypeClickF1);
            }
            catch
            {
            }
        }
        #endregion
        #region ارسال داده ها به فرم قبل
        void SentData()
        {
            string title = GridViewData.SelectedRows[0].Cells["title"].Value.ToString();
            string id = GridViewData.SelectedRows[0].Cells["id"].Value.ToString();
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add(id, title);
            SentDataToForm(list, ListData, TypeClickF1);
            SentDataToForm = null;
        }
        #endregion
        #region کلیک روی دیتاگرید ویوو
        private void GridViewData_Click(object sender, EventArgs e)
        {
            isSearch = false;

            try
            {
                string id = GridViewData.SelectedRows[0].Cells["id"].Value.ToString();
                string title = GridViewData.SelectedRows[0].Cells["title"].Value.ToString();

                txtB_title.Text = title;
                txtB_id.Text = id;
            }
            catch { }

        }
        #endregion
        #region داده گرید ویوو را تغییر میدهد
        private void ChangeDataGrid(string type)
        {
            ListData = new Dictionary<string, string>();

            System.Data.DataTable listRow2 = SqlHelper.GetField(TypeClickF1);
            if (listRow2.Rows.Count > 0)
            {
                for (int i = 0; i < listRow2.Rows.Count; i++)
                {
                    ListData.Add(listRow2.Rows[i][0].ToString(), SafeFarsiStr(listRow2.Rows[i][1].ToString()));
                }
            }
            #region MyRegion

            //switch (type)
            //{
            //    case "Field12":
            //        System.Data.DataTable listRow2 = SqlHelper.GetField("Field12");
            //        if (listRow2.Rows.Count > 0)
            //        {
            //            for (int i = 0; i < listRow2.Rows.Count; i++)
            //            {
            //                ListData.Add(listRow2.Rows[i][0].ToString(), SafeFarsiStr(listRow2.Rows[i][1].ToString()));
            //            }
            //        }
            //        break;
            //    case "Field10":
            //        System.Data.DataTable listRow = SqlHelper.GetField("Field10");
            //        if (listRow.Rows.Count > 0)
            //        {
            //            for (int i = 0; i < listRow.Rows.Count; i++)
            //            {
            //                ListMokhatab.Add(listRow.Rows[i][0].ToString(), SafeFarsiStr(listRow.Rows[i][1].ToString()));
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}
            #endregion

            GridViewData.DataSource = "";
            GridViewData.DataSource = ListData;
        }
        #endregion
        #region کلیک روی دکمه ذخیره
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Add_update();
        }
        #endregion
        #region سرچ روی ای دی
        private void txtB_id_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            if (txtB_id.Text.Length == 0)
                isSearch = true;
            if (isSearch)
                GridViewData.DataSource = ListData.Where(a => a.Key.ToString().Contains(txtB_id.Text)).ToList();
        }
        #endregion
        #region سرچ روی عنوان
        private void txtB_title_TextChanging(object sender, Telerik.WinControls.TextChangingEventArgs e)
        {
            if (txtB_title.Text.Length == 0)
                isSearch = true;
            if (isSearch)
                GridViewData.DataSource = ListData.Where(a => a.Value.Contains(txtB_title.Text)).ToList();
        }
        #endregion
        #region ابنتر روی دیتاگرید
        private void GridViewData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SentData();
                this.Close();
            }
        }
        #endregion
        #region دابل کلیک روی دیتا گرید ویوو
        private void GridViewData_DoubleClick(object sender, EventArgs e)
        {
            SentData();
            this.Close();
        }
        #endregion
        #region دکمه حذف
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        #endregion
        #region تابع حذف
        private void Delete()
        {
            if (txtB_id.Text.Count() != 0)
            {

                try
                {

                    int id = int.Parse(txtB_id.Text);
                    DialogResult dialogResult = PersianMessageBox.Show("آیا میخواهید حذف کنید", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Njit.Sql.DataAccess da = new Njit.Sql.DataAccess(Setting.Sql.ThisProgram.ArchiveConnection.ConnectionString);
                            (da ?? (Njit.Program.Options.SettingInitializer.GetDataAccess())).Execute(CommandType.Text, string.Format("DELETE FROM [{0}] WHERE [{1}]=@p", TypeClickF1, "ID"), "@p", id);
                        }
                        catch
                        {
                        }

                    }
                    ChangeDataGrid(TypeClickF1);
                    txtB_title.Clear();
                    txtB_id.Clear();
                }
                catch
                {

                    MessageBox.Show("لطفا یک سطر را انتخاب کنید");
                }
            }
        }
        #endregion
        #region ctrl+S
        private void btn_Save_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.S)
            {
                Add_update();
            }
        }
        #endregion
        #region ctrl+D
        private void Btn_Delete_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.D)
            {
                Delete();
            }
        }
        #endregion
        #region Down or Up Title

        private void txtB_title_KeyDown(object sender, KeyEventArgs e)
        {
            FocusInDataGridVie(e);
        }
        #endregion
        #region  تابع =>دکمه بالا یا پایین را فشار دهند فکوس روی دیتاگرید میرود

        public void FocusInDataGridVie(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                GridViewData.Focus();
            }
        }
        #endregion
        #region Down or Up id

        private void txtB_id_KeyDown(object sender, KeyEventArgs e)
        {
            FocusInDataGridVie(e);
        }
        #endregion
        #region Up or Douwn btn delete
        private void Btn_Delete_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38 || e.KeyValue == 40)//38=up 40=douwn
            {
                GridViewData.Focus();
            }
        }
        #endregion
        #region Up or Douwn btn save
        private void btn_Save_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38 || e.KeyValue == 40)//38=up 40=douwn
            {
                GridViewData.Focus();
            }
        }
        #endregion

        private void DocumentField_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

    }
}
