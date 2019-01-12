using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public interface ICustomizedControl
    {
        void SetError(string errorText, bool showErrorIcon);
        void FocusAndSetError(string errorText);
        void ClearError();
    }
}
