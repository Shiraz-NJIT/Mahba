using KaupischITC.ScanWIA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class ScannerSetting : Form
    {
        public ScannerSetting()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "Scanner");
            if (query.Count() == 1)
            {
                query.FirstOrDefault().X = comboBoxImageType.SelectedIndex;
                query.FirstOrDefault().Y = comboBoxSource.SelectedIndex;
                query.FirstOrDefault().Width = cmResolation.SelectedIndex;
                query.FirstOrDefault().Height = cmResolation.SelectedIndex;
                dc.SubmitChanges();
            }
            else
            {
                Model.Common.FormState state = Model.Common.FormState.GetNewInstance(Environment.MachineName, "Scanner", 1, comboBoxImageType.SelectedIndex, comboBoxSource.SelectedIndex, cmResolation.SelectedIndex, cmResolation.SelectedIndex);
                Model.Common.FormState.Insert(dc, state);
                dc.SubmitChanges();
            }

            PersianMessageBox.Show("اطلاعات با موفقیت ذخیره شد.");
        }
        private class ScanSource
        {
            public string Name { get; set; }
            public DocumentHandlingSelect DocumentHandlingSelect { get; set; }
        }
        private class Resolation
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        private void ScannerSetting_Load(object sender, EventArgs e)
        {
            List<ScanSource> scanSources = new List<ScanSource>();
            scanSources.Add(new ScanSource { Name = "Feeder ", DocumentHandlingSelect = DocumentHandlingSelect.Feeder });
            scanSources.Add(new ScanSource { Name = "Flatbed", DocumentHandlingSelect = DocumentHandlingSelect.Flatbed });
            this.comboBoxSource.DataSource = scanSources;
            this.comboBoxSource.DisplayMember = "Name";
            this.comboBoxSource.ValueMember = "DocumentHandlingSelect";
            // Auswahlmöglichkeiten für Farbschema
            this.comboBoxImageType.DataSource = new[]
            {
                new { Name = "سیاه و سفید", CurrentIntent = CurrentIntent.ImageTypeText },
                new { Name = "Gray Style", CurrentIntent = CurrentIntent.ImageTypeGrayscale },
                new { Name = "رنگی", CurrentIntent = CurrentIntent.ImageTypeColor },
            };
            this.comboBoxImageType.DisplayMember = "Name";
            this.comboBoxImageType.ValueMember = "CurrentIntent";
            List<Resolation> listr = new List<Resolation>();
            listr.Add(new Resolation() { Name = "75dpi", Value = 75 });
            listr.Add(new Resolation() { Name = "100dpi", Value = 100 });
            listr.Add(new Resolation() { Name = "200dpi", Value = 200 });
            listr.Add(new Resolation() { Name = "300dpi", Value = 300 });
            listr.Add(new Resolation() { Name = "600dpi", Value = 600 });
            listr.Add(new Resolation() { Name = "1200dpi", Value = 1200 });
            this.cmResolation.DataSource = listr;

            this.cmResolation.DisplayMember = "Name";
            this.cmResolation.ValueMember = "Value";
            loadData();
        }

        private void loadData()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.FormStates.Where(t => t.MachineName == Environment.MachineName && t.FormName == "Scanner");
            if (query.Count() == 1)
            {
                comboBoxImageType.SelectedIndex = query.FirstOrDefault().X;
                comboBoxSource.SelectedIndex = query.FirstOrDefault().Y;
                cmResolation.SelectedIndex = query.FirstOrDefault().Width;
                cmResolation.SelectedIndex = query.FirstOrDefault().Height;
            }

        }
    }
}
