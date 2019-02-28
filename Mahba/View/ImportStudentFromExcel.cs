using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class ImportStudentFromExcel : Njit.Program.Forms.OKCancelForm
    {
        private bool PageLoad = true;
        public ImportStudentFromExcel()
        {
            InitializeComponent();

            saveFileDialog1.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.FileName = "اطلاعات دانشجویان برنامه مهبا";
            radGridViewExtended1.BestColumn();
        }
        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0 && Environment.Is64BitOperatingSystem == false)//compare the extension of the file
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";//for below excel 2007
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";//for above excel 2007
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con);//here we read data from sheet1
                    oleAdpt.Fill(dtexcel);//fill excel data into dataTable
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToString().Contains("The Microsoft Access database engine cannot open or write to the file "))
                    {
                        MessageBox.Show("فایل انتخابی بروی سیستم شما باز است.لطفا از فایل انتخابی خارج شوید");
                    }
                    else
                        MessageBox.Show(ex.Message.ToString());
                }
            }
            return dtexcel;
        }
        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string sourcePath = Application.StartupPath;
                File.Copy(sourcePath + "\\ImportStudent.xls", saveFileDialog1.FileName);
                System.Diagnostics.Process.Start(sourcePath + "\\ImportStudent.xls");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            radGridViewExtended1.DataSource = null;
            dataGridView1.DataSource = null;
            btnChoose.Cursor = Cursors.WaitCursor; 
            
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();//open dialog to choose file
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)//if there is a file choosen by the user
            {
                filePath = file.FileName;//get the path of the file
                fileExt = Path.GetExtension(filePath);//get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt);//read excel file
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = dtExcel;

                        #region Validate
                        List<ErrorExcel> _listerro = new List<ErrorExcel>();
                        for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
                        {
                            string PersonnelNumber = "";
                            StringBuilder er = new StringBuilder();
                            try
                            {
                                if (dataGridView1.Rows[rows].Cells[0].Value != null)
                                {
                                    //چک کردن شماره پرسنلی ها
                                        PersonnelNumber = dataGridView1.Rows[rows].Cells[0].Value.ToString();
                                        if (CheckPersonnelNumber(PersonnelNumber) == false)
                                        {
                                            er.Append("کد پرسنلی");
                                            er.Append("'" + PersonnelNumber + "'");
                                            er.Append("در سیستم وجود دارد");
                                        }

                                }
                            }
                            catch (Exception ex)
                            {
                                er.Append(ex);
                            }

                            if (er.Length != 0)
                            {
                                ErrorExcel ex = new ErrorExcel();
                                ex.Row = rows;
                                ex.PerssonelNumber = PersonnelNumber;
                                ex.Error = er;
                                _listerro.Add(ex);
                                continue;
                            }
                        }
                        #endregion
                        if (_listerro.Any())
                        {
                            radGridViewExtended1.DataSource = null;
                            radGridViewExtended1.DataSource = _listerro;
                            radGridViewExtended1.EnableAlternatingRowColor = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.ToString().Contains("not set"))
                            MessageBox.Show("هیچی اطلاعاتی وارد نشده است");
                        else
                            MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);//custom messageBox to show error
            }
            btnChoose.Cursor = Cursors.Default; 
        }
        public bool CheckPersonnelNumber(string PersonnelNumber)
        {
            if (Controller.Archive.DossierController.CheckPersonnelNumberAlreadyExist(PersonnelNumber, null))
            {
                return false;
            }
            else
                return true;

        }
        class ErrorExcel
        {
            [DisplayName("سطر")]
            public int Row { get; set; }
            [DisplayName("شماره پرونده")]
            public string PerssonelNumber { get; set; }
            [DisplayName("خطا")]
            public StringBuilder Error { get; set; }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dossierTypeComboBoxExtended.SelectedValue == null)
            {
                MessageBox.Show("سطح دسترسی پرونده ها را مشخص نکرده اید");
            }
            else if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("اطلاعات دانشجویان وارد نشده است");
            }
            #region CreateDossier
            List<ErrorExcel> _listerro = new List<ErrorExcel>();
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                string PersonnelNumber = "";
                StringBuilder er = new StringBuilder();
                try
                {
                    if (dataGridView1.Rows[rows].Cells[0].Value != null)
                    {
                        //کدپرسنلی
                        PersonnelNumber = dataGridView1.Rows[rows].Cells[0].Value.ToString();
                        //چک کردن شماره پرسنلی ها
                        if (CheckPersonnelNumber(PersonnelNumber)==false) { continue; }
                        else
                        {
                            //اضافه کردن ااطلاعات کدپرسنلی
                            List<Model.Archive.ArchiveTab> archiveTabs = Controller.Archive.ArchiveTabController.GetActiveDossierTabs();
                            Model.Archive.Dossier dossier = Model.Archive.Dossier.GetNewInstance(PersonnelNumber, null, Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase ? Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName : Path.Combine(Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName, Njit.Common.PublicMethods.ReplaceInvalidPathAndFileNameChars(PersonnelNumber, "-")), Convert.ToInt32(dossierTypeComboBoxExtended.SelectedValue));
                            List<System.Data.SqlClient.SqlCommand> sqlCommandList = new List<System.Data.SqlClient.SqlCommand>();
                            foreach (Model.Archive.ArchiveTab tab in archiveTabs)
                            {
                                sqlCommandList.Add(SqlHelper.GetDeleteCommandForArchiveTab(tab, PersonnelNumber));
                                List<Dossier1> listDossier1 = new List<Dossier1>();
                                //نام
                                listDossier1.Add(CreateDossier1(rows, 1, "Field1", "string"));
                                //نام خانوادگی
                                listDossier1.Add(CreateDossier1(rows, 2, "Field2", "string"));
                                //کدملی
                                listDossier1.Add(CreateDossier1(rows, 3, "Field15", "string"));
                                //نام پدر
                                listDossier1.Add(CreateDossier1(rows, 4, "Field1018", "string"));
                                //جنسیت
                                listDossier1.Add(CreateDossier1(rows, 5, "Field1019", "string"));
                                //ش ش
                                listDossier1.Add(CreateDossier1(rows, 6, "Field1020", "int"));
                                // ت ت
                                listDossier1.Add(CreateDossier1(rows, 7, "Field1021", "string"));
                                //تلفن دائم
                                listDossier1.Add(CreateDossier1(rows, 8, "Field1049", "int"));
                                //تلفن ضروری
                                listDossier1.Add(CreateDossier1(rows, 9, "Field1045", "string"));
                                //تلفن همراه
                                listDossier1.Add(CreateDossier1(rows, 10, "Field1041", "string"));
                                //کد پستی
                                listDossier1.Add(CreateDossier1(rows, 11, "Field1043", "string"));
                                //صندوق پستی
                                listDossier1.Add(CreateDossier1(rows, 12, "Field1044", "string"));
                                //استان
                                listDossier1.Add(CreateDossier1(rows, 13, "Field1034", "string"));
                                //شهر
                                listDossier1.Add(CreateDossier1(rows, 14, "Field1035", "string"));
                                //بخش
                                listDossier1.Add(CreateDossier1(rows, 15, "Field1036", "string"));
                                //ادرس
                                listDossier1.Add(CreateDossier1(rows, 16, "Field1029", "string"));
                                //رشته
                                listDossier1.Add(CreateDossier1(rows, 17, "Field1032", "string"));
                                //مقطع
                                listDossier1.Add(CreateDossier1(rows, 18, "Field1033", "string"));
                                //معدل
                                listDossier1.Add(CreateDossier1(rows, 19, "Field1046", "double"));
                                //تاریخ اخذ
                                listDossier1.Add(CreateDossier1(rows, 20, "Field1048", "string"));
                                //نظام وظیفه
                                listDossier1.Add(CreateDossier1(rows, 21, "Field1047", "string"));
                                //دین
                                listDossier1.Add(CreateDossier1(rows, 22, "Field1037", "string"));
                                //مذهب
                                listDossier1.Add(CreateDossier1(rows, 23, "Field1038", "string"));
                                //ملیت
                                listDossier1.Add(CreateDossier1(rows, 24, "Field1042", "string"));
                                //سال قبولی
                                listDossier1.Add(CreateDossier1(rows, 25, "Field1040", "int"));
                                //رتبه
                                listDossier1.Add(CreateDossier1(rows, 26, "Field1039", "int"));
                                //سهمیه نهایی
                                listDossier1.Add(CreateDossier1(rows, 27, "Field1025", "string"));
                                //سهمیه ثبت نام
                                listDossier1.Add(CreateDossier1(rows, 28, "Field1024", "string"));
                                //ترم ورود
                                listDossier1.Add(CreateDossier1(rows, 29, "Field1023", "int"));
                                //تاریخ شروع تحصیل
                                listDossier1.Add(CreateDossier1(rows, 30, "Field1022", "int"));
                                //نیسمال ثبت نام
                                listDossier1.Add(CreateDossier1(rows, 31, "Field1026", "int"));
                                //نوع پذیرش
                                listDossier1.Add(CreateDossier1(rows, 32, "Field1027", "string"));
                                // نوع بورسیه
                                listDossier1.Add(CreateDossier1(rows, 33, "Field1028", "string"));
                                //نوع دوره
                                listDossier1.Add(CreateDossier1(rows, 34, "Field1030", "string"));
                                //دانشکده
                                listDossier1.Add(CreateDossier1(rows, 35, "Field1031", "string"));
                                //شماره قدیم
                                listDossier1.Add(CreateDossier1(rows, 36, "Field1050", "string"));
                                //دانشجو میهمان
                                listDossier1.Add(CreateDossier1(rows, 37, "Field1051", "bool"));
                                listDossier1.Add(CreateDossier1(rows, 38, "Field1052", "bool"));
                                listDossier1.Add(CreateDossier1(rows, 39, "Field1053", "string"));
                                List<System.Data.SqlClient.SqlCommand> sqlCommands = SqlHelper.GetDossier1InsertCommands(listDossier1, tab, PersonnelNumber);
                                sqlCommandList.AddRange(sqlCommands);
                                List<Model.Archive.ContactView> contactView = new List<Model.Archive.ContactView>();
                                List<Model.Archive.AddressView> addressView = new List<Model.Archive.AddressView>();
                                Model.Archive.Info info = null;

                                Controller.Archive.DossierController.Insert(dossier, sqlCommandList, contactView, addressView, info);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    er.Append(ex);
                }

                if (er.Length != 0)
                {
                    ErrorExcel ex = new ErrorExcel();
                    ex.Row = rows;
                    ex.PerssonelNumber = PersonnelNumber;
                    ex.Error = er;
                    _listerro.Add(ex);
                    continue;
                }
            }
            #endregion
            if (_listerro.Any())
            {
                radGridViewExtended1.DataSource = null;
                radGridViewExtended1.DataSource = _listerro;
                radGridViewExtended1.EnableAlternatingRowColor = true;
            }
            else
            {
                MessageBox.Show("تمام اطلاعات با موفقیت ثبت شد");
            }

        }

        private Dossier1 CreateDossier1(int row, int col, string Field, string type)
        {
            Dossier1 d1 = new Dossier1();
            if (dataGridView1.Rows[row].Cells[col] == null) return d1;
            else
            {
                d1.Name = Field;
                if (type == "bool")
                {
                    try
                    {
                        d1.Value = dataGridView1.Rows[row].Cells[col].Value.ToString();
                        if (d1.Value == "true" || d1.Value == "بله" || d1.Value == "1" || d1.Value == "True") d1.Value = "True";
                        if (d1.Value == "false" || d1.Value == "خیر" || d1.Value == "0" || d1.Value == "False") d1.Value = "False";
                    }
                    catch
                    {
                        d1.Value = "False";
                    }
                }
                else if (type == "int")
                {
                    try
                    {
                        d1.Value = Convert.ToInt32(dataGridView1.Rows[row].Cells[col].Value.ToString()).ToString();
                    }
                    catch
                    {
                        d1.Value = "0";
                    }
                }
                else if (type == "double")
                {
                    try
                    {
                        d1.Value = double.Parse(dataGridView1.Rows[row].Cells[col].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture).ToString();
                    }
                    catch
                    {
                        d1.Value = "0";
                    }
                }
                else
                {
                    try
                    {
                        d1.Value = dataGridView1.Rows[row].Cells[col].Value.ToString();
                    }
                    catch
                    {
                        d1.Value = "NULL";
                    }
                }
                return d1;
            }
        }

        private StringBuilder CreateDossier(string PersonnelNumber)
        {
            StringBuilder _Error = new StringBuilder();
            if (CheckPersonnelNumber(PersonnelNumber))
            {

                Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
                Njit.Common.SystemUtility sysUtil = null;
                try
                {
                    sysUtil = Njit.Program.Options.GetSystemUtility(dc.Connection as System.Data.SqlClient.SqlConnection, Setting.Program.ThisProgram.NetworkName, Setting.Program.ThisProgram.NetworkPort);
                }
                catch (Exception ex)
                {
                    _Error.Append("خطا در اتصال به سرور" + "\r\n" + ex.Message);
                }
                try
                {
                    if (Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase == false && !sysUtil.DirectoryExists(Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName))
                        throw new Exception("مسیر ذخیره اسناد نامعتبر است\r\nلطفا در قسمت تنظیمات برنامه مسیر ذخیره اسناد را انتخاب کنید" + "\r\n" + Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName);
                    Model.Archive.Dossier dossier = Model.Archive.Dossier.GetNewInstance(PersonnelNumber, null, Setting.Archive.ThisProgram.LoadedArchiveSettings.UseDatabase ? Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName : Path.Combine(Setting.Archive.ThisProgram.LoadedArchiveSettings.DocumentsPathOrDatabaseName, Njit.Common.PublicMethods.ReplaceInvalidPathAndFileNameChars(PersonnelNumber, "-")), Convert.ToInt32(dossierTypeComboBoxExtended.SelectedValue));
                    List<System.Data.SqlClient.SqlCommand> sqlCommandList = new List<System.Data.SqlClient.SqlCommand>();
                    List<Model.Archive.ContactView> contactView = new List<Model.Archive.ContactView>();
                    List<Model.Archive.AddressView> addressView = new List<Model.Archive.AddressView>();
                    Model.Archive.Info info = null;

                    Controller.Archive.DossierController.Insert(dossier, sqlCommandList, contactView, addressView, info);
                }
                catch (Exception ex)
                {
                    _Error.Append(ex.Message.ToString());
                }

            }
            else
            {
                _Error.Append("کد پرسنلی");
                _Error.Append("'" + PersonnelNumber + "'");
                _Error.Append("در سیستم وجود دارد");
            }
            return _Error;
        }

        private void ImportStudentFromExcel_Load(object sender, EventArgs e)
        {
            if (!(Convert.ToInt32(Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID) == 10))
            {
                this.Close();
            }
        }
        void ImportStudentFromExcel_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                if (!(Convert.ToInt32(Setting.Archive.ThisProgram.SelectedArchiveTree.ArchiveID) == 10))
                {
                    if (PageLoad)
                    {
                        MessageBox.Show("این گزینه مربوط به بایگانی دانشجویان می باشد");
                        this.Hide();
                        this.Parent = null;
                        e.Cancel = true;
                        PageLoad = false;
                    }
                }
            }
            catch { this.Close(); }
        }

        private void ImportStudentFromExcel_Load_1(object sender, EventArgs e)
        {
            System.Data.DataTable tempDataTable = SqlHelper.GetField("DossierType");
            if (tempDataTable.Rows.Count > 0)
            {
                dossierTypeComboBoxExtended.DataSource = tempDataTable;
                dossierTypeComboBoxExtended.DisplayMember = "Title";
                dossierTypeComboBoxExtended.ValueMember = "ID";
            }
            else
            {
                MessageBox.Show(" نوع دسترسی برای پرونده های این بایگانی در نظر گرفته نشده است");
            }
        }
    }
}
