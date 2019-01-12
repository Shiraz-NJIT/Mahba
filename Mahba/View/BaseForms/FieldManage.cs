using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NjitSoftware.View.BaseForms
{
    public partial class FieldManage : Njit.Program.Forms.CancelableDialogForm
    {
        public FieldManage()
        {
            InitializeComponent();
            radGridView.Rows.CollectionChanged += Rows_CollectionChanged;
        }

        private void Rows_CollectionChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Move)
            {
                try
                {
                    UpdateFieldsIndex();
                }
                catch (Exception ex)
                {
                    PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                }
            }
        }

        protected virtual void UpdateFieldsIndex()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;
            fieldInfo.FillData();
            RefreshData();

            ConditionalFormattingObject c1 = new ConditionalFormattingObject("Green, applied to entire row", ConditionTypes.Equal, "14", "", true);
            c1.RowBackColor = Color.FromArgb(219, 251, 91);
            c1.CellBackColor = Color.FromArgb(219, 251, 91);
            radGridView.Columns["FieldTypeCode"].ConditionalFormattingObjectList.Add(c1);
        }

        protected void RefreshData()
        {
            radGridView.Rows.Clear();
            foreach (var item in this.LoadData())
            {
                object[] data = item.GetData();
                int index = radGridView.Rows.Add(data.Take(data.Length - 1).ToArray());
                radGridView.Rows[index].Tag = data[data.Length - 1];
            }
        }

        protected virtual IEnumerable<Field> LoadData()
        {
            return new List<Field>();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rows = radGridView.SelectedRows.Select(t => t).ToArray();
            bool yesToAll = false;
            foreach (var row in rows)
            {
                Njit.MessageBox.VDialogResult result;
                if (yesToAll)
                    result = Njit.MessageBox.VDialogResult.Yes;
                else
                    result = PersianMessageBox.Show(this, string.Format("فیلد '{0}' حذف شود؟", row.Cells["Label"].Value), "تایید حذف", new Njit.MessageBox.VDialogButton[] { new Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.Yes), new Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.YesToAll), new Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.No), new Njit.MessageBox.VDialogButton(Njit.MessageBox.VDialogResult.NoToAll) }, Njit.MessageBox.VDialogIcon.Question, Njit.MessageBox.VDialogDefaultButton.Button3, System.Windows.Forms.RightToLeft.Yes, false, null, null, null, null, null);

                if (result == Njit.MessageBox.VDialogResult.YesToAll)
                    yesToAll = true;

                if (result == Njit.MessageBox.VDialogResult.Yes || result == Njit.MessageBox.VDialogResult.YesToAll)
                {
                    Field field = new Field(row);
                    if (field.ParentID.HasValue)
                    {
                        PersianMessageBox.Show(this, string.Format("فیلد '{0}' را از اینجا نمی توانید حذف کنید", field.Label));
                        continue;
                    }
                    try
                    {
                        DeleteField(field);
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در حذف فیلد" + "'" + field.Label + "'" + "\r\n\r\n" + ex.Message);
                        continue;
                    }
                }
                else if (result == Njit.MessageBox.VDialogResult.NoToAll)
                    break;
            }
            RefreshData();
        }

        protected virtual void DeleteField(Field field)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            Field field = new Field(radGridView.SelectedRows[0]);
            if (field.ParentID.HasValue)
            {
                PersianMessageBox.Show(this, "این فیلد را از اینجا نمی توانید ویرایش کنید");
                return;
            }
            using (View.BaseForms.FieldEdit f = new View.BaseForms.FieldEdit(field))
            {
                f.EditField += OnEditField;
                f.SetCounterFieldProperties += OnSetCounterFieldProperties;
                f.GetCounterFieldProperties += OnGetCounterFieldProperties;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    RefreshData();
                    SelectRow((int)f.Tag);
                }
            }
        }

        private void OnGetCounterFieldProperties(object sender, FieldEdit.GetCounterFieldEventArgs e)
        {
            e.CounterFieldSetting = this.GetCounterFieldProperties(e.FieldID);
        }

        private void OnSetCounterFieldProperties(object sender, FieldEdit.CounterFieldEventArgs e)
        {
            this.SetCounterFieldProperties(e.FieldID, e.FixedValueType, e.FixedValue, e.Separator);
        }

        private void OnEditField(object sender, FieldEdit.FieldEventArgs e)
        {
            this.EditField(e.OriginalField.ID.Value, e.NewField);
        }

        protected virtual void EditField(int originalID, Field field)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (!(btnMove.Focused || fieldInfo.LastControlFocused))
            {
                Njit.Common.SendKeys.SendKeyDown(Keys.Tab);
                return;
            }
            try
            {
                fieldInfo.ValidateContents();
            }
            catch (Njit.Common.ValidateException ex)
            {
                ex.Control.TextChanged -= ControlTextChanged;
                ex.Control.Leave -= ControlLeave;
                PersianMessageBox.Show(ex.Message);
                ex.Control.Focus();
                ex.Control.TextChanged += ControlTextChanged;
                ex.Control.Leave += ControlLeave;
                errorProvider.SetError(ex.Control, ex.Message);
                return;
            }

            try
            {
                Field field = fieldInfo.GetData();
                View.GetCounterFieldProperties counterFieldPropertiesForm = new GetCounterFieldProperties();
                if (field.FieldTypeCode == (int)Enums.FieldTypes.شمارنده)
                {
                    if (counterFieldPropertiesForm.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                        return;
                }
                int id = AddField(field);
                if (field.FieldTypeCode == (int)Enums.FieldTypes.شمارنده)
                {
                    SetCounterFieldProperties(id, (int)counterFieldPropertiesForm.FixedValueType, counterFieldPropertiesForm.FixedValue, counterFieldPropertiesForm.Separator);
                }
                RefreshData();
                SelectRow(id);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }

            fieldInfo.Reset();
        }

        public virtual void SetCounterFieldProperties(int fieldId, int fixedValueType, string fixedValue, string separator)
        {

        }

        public virtual CounterFieldSetting GetCounterFieldProperties(int fieldID)
        {
            return null;
        }

        private void SelectRow(int id)
        {
            radGridView.ClearSelection();
            foreach (var row in radGridView.Rows.Where(t => int.Parse(t.Cells["ID"].Value.ToString()) == id))
            {
                row.IsSelected = true;
                radGridView.CurrentRow = row;
            }
        }

        protected virtual int AddField(Field field)
        {
            return 0;
        }

        private void ControlLeave(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void ControlTextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        protected virtual void OnGridViewSelectionChanged()
        {

        }

        private void radGridView_SelectionChanged(object sender, EventArgs e)
        {
            OnGridViewSelectionChanged();
        }
    }
}
