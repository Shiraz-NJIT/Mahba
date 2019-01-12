using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Controller.Archive
{
    static class ImageFormatController
    {
        public static Model.Archive.ImageFormat[] GetImageFormats()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            return dc.ImageFormats.ToArray();
        }
    }
}
