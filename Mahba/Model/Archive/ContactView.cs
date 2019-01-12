using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Archive
{
    partial class ContactView
    {
        public static ContactView GetNewInstance(string PersonnelNumber, int CallTypeID, string Title, string Number, string Comment)
        {
            ContactView _Instance = new ContactView();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.CallTypeID = CallTypeID;
            _Instance.Title = Title;
            _Instance.Number = Number;
            _Instance.Comment = Comment;
            return _Instance;
        }
    }
}
