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
    public partial class DossierReportView : Njit.Program.Forms.ListForm
    {
        public DossierReportView()
        {
            InitializeComponent();
        }

        public DossierReportView(List<SearchField> searchFields, List<Model.Archive.ArchiveField> displayFields, DisplayTypes displayType)
        {
            InitializeComponent();
            this.searchFields = searchFields;
            this.displayFields = displayFields;
            this.displayType = displayType;
        }

        List<SearchField> searchFields;
        List<Model.Archive.ArchiveField> displayFields;
        DisplayTypes displayType;

        public enum DisplayTypes
        {
            Dossier,
            Document
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var firstDossierTab = Controller.Archive.ArchiveTabController.GetFirstDossierTab();
            var firstDocumentTab = Controller.Archive.ArchiveTabController.GetFirstDocumentTab();
            switch (this.displayType)
            {
                case DisplayTypes.Dossier:
                    if (firstDossierTab == null)
                    {
                        PersianMessageBox.Show(this, "هنوز هیچ گروه اطلاعاتی تعریف نشده است");
                        this.Close();
                        return;
                    }
                    if (displayFields != null && displayFields.Count > 0)
                        this.RefreshData(Controller.Archive.DossierController.GetDossierList(displayFields, searchFields.ToArray()));
                    else
                        this.RefreshData(Controller.Archive.DossierController.GetDossierList(firstDossierTab, searchFields.ToArray()));
                    break;
                case DisplayTypes.Document:
                    if (firstDocumentTab == null)
                    {
                        PersianMessageBox.Show(this, "هنوز هیچ گروه اطلاعاتی برای اسناد تعریف نشده است");
                        this.Close();
                        return;
                    }
                    if (displayFields != null && displayFields.Count > 0)
                        this.RefreshData(Controller.Archive.DossierController.GetDocumentList(displayFields, searchFields.ToArray()));
                    else
                        this.RefreshData(Controller.Archive.DossierController.GetDocumentList(firstDocumentTab, searchFields.ToArray()));
                    break;
            }
        }

        private void RefreshData(DataTable dataTable)
        {
            //اضافه کردن ستون
            DataTable ResultTable = new DataTable();

            DataColumn AutoNumberColumn = new DataColumn();

            AutoNumberColumn.ColumnName = "ردیف";

            AutoNumberColumn.DataType = typeof(int);

            AutoNumberColumn.AutoIncrement = true;

            AutoNumberColumn.AutoIncrementSeed = 1;

            AutoNumberColumn.AutoIncrementStep = 1;

            ResultTable.Columns.Add(AutoNumberColumn);

            ResultTable.Merge(dataTable);
            radGridView.DataSource = ResultTable;
            radGridView.BestFitColumnsSmart();
            lblNumber.Text = radGridView.Rows.Count.ToString("N3");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (radGridView.Rows.Count == 0)
                return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Njit.Program.FastReportExtensions.Forms.PrintPreview form = new Njit.Program.FastReportExtensions.Forms.PrintPreview(Setting.Program.ThisProgram.GetReportPath("Report.frx"), Njit.Program.FastReportExtensions.Forms.PrintPreview.PrintSizes.A4, null, 1);
                form.ReportDocument.SetParameterValue("CompanyName", Setting.Archive.ThisProgram.LoadedArchiveSettings.OrganName);
                form.ReportDocument.SetParameterValue("ReportPrintDate", Njit.Common.PersianCalendar.GetDate(DateTime.Now));
                form.ReportDocument.SetParameterValue("ReportPrintTime", Njit.Common.PersianCalendar.GetTime());
                Njit.Program.Forms.GetValue f = new Njit.Program.Forms.GetValue("دریافت عنوان", "عنوان گزارش را وارد کنید:");
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    form.ReportDocument.SetParameterValue("Title", f.Value);
                FastReport.ReportPage page = form.ReportDocument.Pages[0] as FastReport.ReportPage;
                FastReport.DataBand databand = page.Bands[0] as FastReport.DataBand;
                float width = databand.Width;
                foreach (var item in radGridView.Columns)
                {
                    FastReport.TextObject bandText = new FastReport.TextObject();
                    bandText.CreateUniqueName();
                    bandText.HorzAlign = FastReport.HorzAlign.Center;
                    int currentWidth = item.Width;
                    bandText.Bounds = new RectangleF(width - currentWidth, 0.0f, currentWidth, databand.Height);
                    bandText.Border.Lines = FastReport.BorderLines.All;
                    //bandText.AutoWidth = true;
                    bandText.RightToLeft = true;
                    bandText.Font = new System.Drawing.Font("B Nazanin", 9);
                    bandText.Text = "[ReportData." + item.Name + "]";
                    databand.AddChild(bandText);
                    width -= item.Width;// bandText.CalcWidth();
                }
         
                //databand.AfterLayout += databand_AfterLayout;
                DataTable dt = (radGridView.DataSource as DataTable).Clone();
                dt.Rows.InsertAt(dt.NewRow(), 0);
                GetColumnsHeaders(dt.Rows[0]);
                foreach (DataRow row in (radGridView.DataSource as DataTable).Rows)
                    dt.Rows.Add(row.ItemArray);
                form.ReportDocument.RegisterData(dt, "ReportData");
                form.ReportDocument.GetDataSource("ReportData").Enabled = true;
                databand.DataSource = form.ReportDocument.GetDataSource("ReportData");
                form.ShowDialog(this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void GetColumnsHeaders(DataRow row)
        {
            for (int i = 0; i < radGridView.Columns.Count; i++)
            {
                try
                {
                    if (!(radGridView.Columns[i].HeaderText.ToUpper() == "False".ToUpper() || radGridView.Columns[i].HeaderText.ToUpper() == "true".ToUpper()))
                    row[i] = radGridView.Columns[i].HeaderText;

                }
                catch { continue; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }


        private void ExportToExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < radGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < radGridView.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = radGridView.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = radGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 0;
                saveDialog.RestoreDirectory = true;
                saveDialog.CreatePrompt = true;
                saveDialog.FileName = "گزارش برنامه مهبا";
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("فایل اکسل با موفقیت ساخته شد.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        } 
        //private void databand_AfterLayout(object sender, EventArgs e)
        //{
        //FastReport.DataBand databand = sender as FastReport.DataBand;
        //float width = 0;
        //foreach (FastReport.TextObject item in databand.ChildObjects)
        //{
        //    float currentWidth = item.CalcWidth();
        //    item.Bounds = new RectangleF(width, 0.0f, currentWidth, 0.5f * FastReport.Utils.Units.Centimeters);
        //    width += currentWidth;
        //}
        //}
    }
}
