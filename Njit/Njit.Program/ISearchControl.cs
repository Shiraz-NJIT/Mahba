using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Program
{
    /// <summary>
    /// اینترفیس برای پیاده سازی کامپوننت جستجو
    /// </summary>
    public interface ISearchControl
    {
        event EventHandler<Njit.Common.ItemSelectedEventArgs> ItemSelected;
        void OnItemSelected(object SelectedItem);
        void SearchAll();
        int SearchAny(string value);
        object Search(string value);
        void GoNextRow();
        void GoPrevRow();
        void SelectCurrentRow();
        Njit.Program.Controls.TextBoxSearch TextBoxSearch { get; set; }
        object SearchByValueMember(object value);
    }
}
