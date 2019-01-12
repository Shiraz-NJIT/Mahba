using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Archive
{
    public partial class ArchiveTab
    {
        internal string GetName()
        {
            switch (this.TypeCode)
            {
                case 1:
                    return "Dossier" + this.ID.ToString();
                case 2:
                    return "Document" + this.ID.ToString();
                default:
                    throw new Exception();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ArchiveTab)
                return (obj as ArchiveTab).ID == this.ID;
            return false;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public static bool operator !=(ArchiveTab left, ArchiveTab right)
        {
            return !(left == right);
        }

        public static bool operator ==(ArchiveTab left, ArchiveTab right)
        {
            if (object.ReferenceEquals(left, null))
                return object.ReferenceEquals(right, null);
            return left.Equals(right);
        }

    }
}
