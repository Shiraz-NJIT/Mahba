using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Archive
{
    partial class ArchiveSubGroupField
    {
        public string GetName()
        {
            return "Field_" + this.ArchiveField.ArchiveTab.ID.ToString() + "_" + this.ArchiveField.ID.ToString() + "_" + this.ID.ToString();
        }

        public bool IsNumber()
        {
            if (this.FieldTypeCode == (int)Enums.FieldTypes.عدد_صحیح || this.FieldTypeCode == (int)Enums.FieldTypes.عدد_صحیح_بزرگ || this.FieldTypeCode == (int)Enums.FieldTypes.عدد_اعشاری || this.FieldTypeCode == (int)Enums.FieldTypes.عدد_اعشاری_بزرگ || this.FieldTypeCode == (int)Enums.FieldTypes.مبلغ)
                return true;
            else
                return false;
        }
    }
}
