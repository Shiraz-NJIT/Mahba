using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class CompressionTypeController
    {
        public static Model.Archive.CompressionType[] GetCompressionTypes()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.CompressionTypes.ToArray();
        }
    }
}
