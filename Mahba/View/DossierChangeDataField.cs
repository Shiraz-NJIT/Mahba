using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NjitSoftware.View
{
    public partial class DossierChangeDataField : Njit.Program.Forms.OKCancelForm
    {
        List<Model.Archive.ArchiveField> listarchiveField;
        public DossierChangeDataField()
        {
            InitializeComponent();
            SetPersonnelNumberAutoComplate();
        }

        private void groupBoxMain_Enter(object sender, EventArgs e)
        {

        }
        private void SetPersonnelNumberAutoComplate()
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange(Controller.Archive.DossierController.GetAllPersonnelNumbers());
            txtPN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPN.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPN.AutoCompleteCustomSource = autoCompleteStringCollection;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Archive.ArchiveField CurrentField = new Model.Archive.ArchiveField();
                if (comboBox1.SelectedValue != null)
                    CurrentField = listarchiveField.Where(q => q.ID.ToString() == comboBox1.SelectedValue.ToString()).FirstOrDefault();
                if (CurrentField != null)
                {
                    DialogResult dr = MessageBox.Show("اطلاعات پرونده ها تغییر کند؟", "تغییر گروهی اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            {
                                foreach (var item in radGridViewExtended1.Rows)
                                {
                                    string _PN = item.Cells[0].Value.ToString();
                                    if (_PN != null)
                                    {
                                        try
                                        {
                                            switch (CurrentField.BoxTypeCode)
                                            {
                                                case (int)Enums.BoxTypes.کادر_متن:
                                                    string value = pnlInfo.Controls[0].Text;
                                                    if (value == null) value = "_";
                                                    SqlHelper.UpdateDossier1(_PN, CurrentField.FieldName, value);
                                                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش, _PN, "ویرایش اطلاعات پرونده به صورت گروهی به مقدار:" + value);
                                                    break;
                                                case (int)Enums.BoxTypes.کادر_ورود_تاریخ:
                                                       string value2 = pnlInfo.Controls[0].Text;
                                                       if (value2 == null) value2 = "_";
                                                    SqlHelper.UpdateDossier1(_PN, CurrentField.FieldName, value2);
                                                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش, _PN, "ویرایش اطلاعات پرونده به صورت گروهی به مقدار:"+value2);
                                                    break;

                                                case (int)Enums.BoxTypes.کادر_بازشو:
                                                    Njit.Program.Controls.ComboBoxExtended comboBoxExtended =(Njit.Program.Controls.ComboBoxExtended) pnlInfo.Controls[0];
                                                    SqlHelper.UpdateDossier1(_PN, CurrentField.FieldName, comboBoxExtended.Text);
                                                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش, _PN, "ویرایش اطلاعات پرونده به صورت گروهی به مقدار:" + comboBox1.Text);
                                                    break;
                                                case (int)Enums.BoxTypes.کادر_انتخاب:
                                                    CheckBox checkBox = (CheckBox)pnlInfo.Controls[0];
                                                    SqlHelper.UpdateDossier1(_PN, CurrentField.FieldName, checkBox.Checked);
                                                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش, _PN, "ویرایش اطلاعات پرونده به صورت گروهی به مقدار:" + checkBox.Checked);
                                                    break;
                                                case (int)Enums.FieldTypes.ساعت:
                                                       string value3 = pnlInfo.Controls[0].Text;
                                                       if (value3 == null) value3 = "_";
                                                    SqlHelper.UpdateDossier1(_PN, CurrentField.FieldName, value3);
                                                    Setting.User.ThisProgram.AddLog(Setting.User.UserOparatesPlaceNames.لاگیری_سند_و_پرونده, Setting.User.UserOparatesNames.ویرایش, _PN, "ویرایش اطلاعات پرونده به صورت گروهی به مقدار:" + value3);
                                                    break;

                                               
                                            }
                                        }
                                        catch { continue; }
                                    }
                                }
                                MessageBox.Show("اطلاعات با موفقیت ویرایش شد.");
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(ex.Message);
            }
        }
        private void CreateObject(string TabPageName, Model.Archive.ArchiveField CurrentField, int XLabel, int YLabel, int XText, int YText)
        {
            try
            {

                switch (CurrentField.BoxTypeCode)
                {
                    case (int)Enums.BoxTypes.کادر_متن:
                        Njit.Program.Controls.TextBoxExtended textBoxExtended = DossierFormHelper.CreateTextBox(CurrentField.Label, CurrentField.FieldName, CurrentField.FieldTypeCode, CurrentField.MinLength, CurrentField.MaxLength, CurrentField.MinValue, CurrentField.MaxValue, CurrentField.DefaultValue, XText, YText);
                        textBoxExtended.Size = new Size(200, 20);
                        textBoxExtended.RightToLeft = RightToLeft.Yes;
                        pnlInfo.Controls.Add(textBoxExtended);
                        break;
                    case (int)Enums.BoxTypes.کادر_ورود_تاریخ:

                        Njit.Program.Controls.DateControl dateControl = DossierFormHelper.CreateDateBox(CurrentField, XText, YText);
                        dateControl.Size = new Size(200, 20);
                        pnlInfo.Controls.Add(dateControl);
                        break;

                    case (int)Enums.BoxTypes.کادر_بازشو:
                        Njit.Program.Controls.ComboBoxExtended comboBoxExtended = DossierFormHelper.CreateComboBox(CurrentField, XText, YText);
                        comboBoxExtended.Size = new Size(200, 20);
                        comboBoxExtended.RightToLeft = RightToLeft.Yes;
                        pnlInfo.Controls.Add(comboBoxExtended);
                        break;
                    case (int)Enums.BoxTypes.کادر_انتخاب:
                        CheckBox checkBox = DossierFormHelper.CreateChekBox(CurrentField, XLabel, YLabel);
                        checkBox.Size = new Size(200, 20);
                        checkBox.RightToLeft = RightToLeft.Yes;
                        pnlInfo.Controls.Add(checkBox);
                        break;
                    case (int)Enums.FieldTypes.ساعت:
                        Njit.Program.Controls.TimeControl timeControl = DossierFormHelper.CreateTimeBox(CurrentField, XText, YText);
                        timeControl.Size = new Size(200, 20);
                        timeControl.RightToLeft = RightToLeft.Yes;
                        pnlInfo.Controls.Add(timeControl);
                        break;

                    
                }
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show("خطا در بارگذاری اطلاعات" + "\r\n\r\n" + ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        class ChangeData
        {
            [DisplayName("شماره پرسنلی")]
            public string PN { get; set; }
            [DisplayName("نام ")]
            public string Name { get; set; }
            [DisplayName("نام خانوادگی ")]
            public string Family { get; set; }
            [DisplayName("کد ملی ")]
            public string NN { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ChangeData cd = new ChangeData();
            Model.Archive.Dossier Dossier1 = Controller.Archive.DossierController.Get(txtPN.Text);
            if (Dossier1 != null)
            {
                cd.PN = Dossier1.PersonnelNumber;
                object obj = SqlHelper.GetArchiveFieldValue("Dossier1", "Field1", this.txtPN.Text);
                if (obj != null)
                {

                    cd.Name = obj.ToString();
                    object obj2 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field2", txtPN.Text);
                    if (obj2 != null)
                    {
                        cd.Family = obj2.ToString();
                    }
                }
                //کد ملی
                object obj3 = SqlHelper.GetArchiveFieldValue("Dossier1", "Field15", this.txtPN.Text);
                if (obj3 != null)
                {
                    cd.NN = obj3.ToString();
                }
                bool isEnter = true;
                foreach (var item in radGridViewExtended1.Rows)
                {
                    if (item.Cells[0].Value.ToString() == cd.PN)
                    {
                        isEnter = false;
                    }
                }
                if (isEnter)
                    radGridViewExtended1.Rows.Add(cd.PN, cd.Name, cd.Family, cd.NN);
            }

        }

        private void DossierChangeDataField_Load(object sender, EventArgs e)
        {
            radGridViewExtended1.DataSource = new List<ChangeData>();
            txtPN.Focus();
            listarchiveField = Controller.Archive.ArchiveTabController.GetArchiveFields(1);
            comboBox1.DataSource = listarchiveField;
            comboBox1.DisplayMember = "Label";
            comboBox1.ValueMember = "ID";
            if (comboBox1.SelectedValue != null)
            {
                Model.Archive.ArchiveField af = listarchiveField.Where(q => q.ID.ToString() == comboBox1.SelectedValue.ToString()).FirstOrDefault();
                if (af != null)
                    CreateObject("Dossier1", af, 0, 0, 200, 200);
            }
        }

        private void radGridViewExtended1_Click(object sender, EventArgs e)
        {
            if (this.radGridViewExtended1.SelectedRows.Count > 0)
            {
                GridViewDataRowInfo[] rows = new GridViewDataRowInfo[this.radGridViewExtended1.SelectedRows.Count];
                this.radGridViewExtended1.SelectedRows.CopyTo(rows, 0);

                this.radGridViewExtended1.GridElement.BeginUpdate();

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].Delete();
                }

                this.radGridViewExtended1.GridElement.EndUpdate();
            }
        }

        private void txtPN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{

            //    button1.PerformClick();
            //    // these last two lines will stop the beep sound
            //    e.Handled = true;
            //}
        }

        private void txtPN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    button1.PerformClick();
            //    // these last two lines will stop the beep sound
            //    base.OnClick(e);
            //}

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                foreach (Control control in pnlInfo.Controls)
                {
                    pnlInfo.Controls.Remove(control);
                }
                Model.Archive.ArchiveField af = listarchiveField.Where(q => q.ID.ToString() == comboBox1.SelectedValue.ToString()).FirstOrDefault();
                if (af != null)
                {

                    int Distance = 0;
                    int StartPointLabel_X = 0;
                    int StartPointLabel_Y = 6;
                    int StartPointControl_X = 0;
                    int StartPointControl_Y = 5;
                    CreateObject("Dossier1", af, StartPointLabel_X, StartPointLabel_Y + Distance * 28, StartPointControl_X, StartPointControl_Y + Distance * 28);
                }
            }

        }





    }
}
