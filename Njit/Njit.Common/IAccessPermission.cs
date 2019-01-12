using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public interface IAccessPermission
    {
        bool AllowCheckAccessPermission { get; set; }
        string GetPath();
        string Text { get; set; }
        string Name { get; set; }
    }
}
