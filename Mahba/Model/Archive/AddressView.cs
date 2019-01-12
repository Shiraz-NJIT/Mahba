using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NjitSoftware.Model.Archive
{
   partial class AddressView
    {
       public static AddressView GetNewInstance(int ID, string PersonnelNumber, int AddressTypeID, string Title, int ProvinceID, string ProvinceTitle, string Township, int MetropolitanAreaID, string AreaTitle, string Street, string Alley, string PostalCode)
       {
           AddressView _Instance = new AddressView();
           _Instance.ID = ID;
           _Instance.PersonnelNumber = PersonnelNumber;
           _Instance.AddressTypeID = AddressTypeID;
           _Instance.Title = Title;
           _Instance.ProvinceID = ProvinceID;
           _Instance._ProvinceTitle = ProvinceTitle;
           _Instance.Township = Township;
           _Instance.MetropolitanAreaID = MetropolitanAreaID;
           _Instance.AreaTitle = AreaTitle;
           _Instance.Street = Street;
           _Instance.Alley = Alley;
           _Instance.PostalCode = PostalCode;
           return _Instance;
       }
    }
}
