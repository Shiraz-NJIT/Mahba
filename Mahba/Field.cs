namespace NjitSoftware
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class Field : IComparable<Field>
    {
        public Field(int? ID, string Label, string FieldName, int FieldTypeCode, string FieldType, int StatusCode, string Status, int BoxTypeCode, string BoxType, bool AutoComplete, int? MinLength, int? MaxLength, double? MinValue, double? MaxValue, int? ParentID, int index, string defaultValue)
        {
            this.ID = ID;
            this.Label = Label;
            this.FieldName = FieldName;
            this.FieldTypeCode = FieldTypeCode;
            this.FieldType = FieldType;
            this.StatusCode = StatusCode;
            this.Status = Status;
            this.BoxTypeCode = BoxTypeCode;
            this.BoxType = BoxType;
            this.AutoComplete = AutoComplete;
            this.MinLength = MinLength;
            this.MaxLength = MaxLength;
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
            this.ParentID = ParentID;
            this.Index = index;
            this.DefaultValue = defaultValue;
            this.SubFields = new List<Field>();
        }

        public Field(Telerik.WinControls.UI.GridViewRowInfo row)
        {
            this.ID = row.Cells["ID"].Value.IsNullOrEmpty() ? (int?)null : int.Parse(row.Cells["ID"].Value.ToString());
            this.Label = row.Cells["Label"].Value.ToString();
            this.FieldName = row.Cells["FieldName"].Value.IsNullOrEmpty() ? null : row.Cells["FieldName"].Value.ToString();
            this.FieldTypeCode = int.Parse(row.Cells["FieldTypeCode"].Value.ToString());
            this.FieldType = row.Cells["FieldType"].Value.ToString();
            this.StatusCode = int.Parse(row.Cells["StatusCode"].Value.ToString());
            this.Status = row.Cells["Status"].Value.ToString();
            this.BoxTypeCode = int.Parse(row.Cells["BoxTypeCode"].Value.ToString());
            this.BoxType = row.Cells["BoxType"].Value.ToString();
            this.AutoComplete = bool.Parse(row.Cells["AutoComplete"].Value.ToString());
            this.MinLength = row.Cells["MinLength"].Value.IsNullOrEmpty() ? (int?)null : int.Parse(row.Cells["MinLength"].Value.ToString());
            this.MaxLength = row.Cells["MaxLength"].Value.IsNullOrEmpty() ? (int?)null : int.Parse(row.Cells["MaxLength"].Value.ToString());
            this.MinValue = row.Cells["MinValue"].Value.IsNullOrEmpty() ? (double?)null : double.Parse(row.Cells["MinValue"].Value.ToString());
            this.MaxValue = row.Cells["MaxValue"].Value.IsNullOrEmpty() ? (double?)null : double.Parse(row.Cells["MaxValue"].Value.ToString());
            this.ParentID = row.Cells["ParentID"].Value.IsNullOrEmpty() ? (int?)null : int.Parse(row.Cells["ParentID"].Value.ToString());
            this.DefaultValue = (row.Cells["DefaultValue"].Value ?? "").ToString();
            this.Index = row.Index + 1;
            this.SubFields = (row.Tag != null && row.Tag is List<Field>) ? row.Tag as List<Field> : new List<Field>();
        }

        public void SetData(string Label, int FieldTypeCode, string FieldType, int StatusCode, string Status, int BoxTypeCode, string BoxType, bool AutoComplete, int? MinLength, int? MaxLength, double? MinValue, double? MaxValue, int index)
        {
            this.Label = Label;
            this.FieldTypeCode = FieldTypeCode;
            this.FieldType = FieldType;
            this.StatusCode = StatusCode;
            this.Status = Status;
            this.BoxTypeCode = BoxTypeCode;
            this.BoxType = BoxType;
            this.AutoComplete = AutoComplete;
            this.MinLength = MinLength;
            this.MaxLength = MaxLength;
            this.MinValue = MinValue;
            this.MaxValue = MaxValue;
            this.Index = index;
        }

        internal object[] GetData()
        {
            List<object> list = new List<object>();
            list.Add(ID);
            list.Add(Label);
            list.Add(FieldName);
            list.Add(FieldTypeCode);
            list.Add(FieldType);
            list.Add(StatusCode);
            list.Add(Status);
            list.Add(BoxTypeCode);
            list.Add(BoxType);
            list.Add(AutoComplete);
            list.Add(MinLength);
            list.Add(MaxLength);
            list.Add(MinValue);
            list.Add(MaxValue);
            list.Add(ParentID);
            list.Add(DefaultValue);
            list.Add(ParentID.HasValue ? Properties.Resources._lock : Properties.Resources.unlock);
            list.Add(this.SubFields);
            return list.ToArray();
        }

        public int CompareTo(Field other)
        {
            return this.Index.CompareTo(other.Index);
        }

        public int Index { get; set; }

        public int? ID { get; set; }

        public string Label { get; set; }

        public string FieldName { get; set; }

        public int FieldTypeCode { get; set; }

        public string FieldType { get; set; }

        public int StatusCode { get; set; }

        public string Status { get; set; }

        public int BoxTypeCode { get; set; }

        public string BoxType { get; set; }

        public string DefaultValue { get; set; }

        public bool AutoComplete { get; set; }

        public int? MinLength { get; set; }

        public int? MaxLength { get; set; }

        public double? MinValue { get; set; }

        public double? MaxValue { get; set; }

        public int? ParentID { get; set; }

        public List<Field> SubFields { get; set; }
    }
}
