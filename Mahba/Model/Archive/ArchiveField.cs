using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Archive
{
    public partial class ArchiveField
    {
        internal string GetName()
        {
            if (this.FieldTypeCode == (int)Enums.FieldTypes.زیرگروه_جدولی)
                return "Field_" + this.ArchiveTab.ID.ToString() + "_" + this.ID.ToString();
            return "Field" + this.ID.ToString();
        }

        public override string ToString()
        {
            return this.Label;
        }

        public bool IsNumber()
        {
            if (this.FieldTypeCode == (int)Enums.FieldTypes.عدد_صحیح || this.FieldTypeCode == (int)Enums.FieldTypes.عدد_صحیح_بزرگ || this.FieldTypeCode == (int)Enums.FieldTypes.عدد_اعشاری || this.FieldTypeCode == (int)Enums.FieldTypes.عدد_اعشاری_بزرگ || this.FieldTypeCode == (int)Enums.FieldTypes.مبلغ)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is ArchiveField)
                return (obj as ArchiveField).ID == this.ID;
            return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public static bool operator !=(ArchiveField left, ArchiveField right)
        {
            return !(left == right);
        }

        public static bool operator ==(ArchiveField left, ArchiveField right)
        {
            if (object.ReferenceEquals(left, null))
                return object.ReferenceEquals(right, null);
            return left.Equals(right);
        }
    }
}
