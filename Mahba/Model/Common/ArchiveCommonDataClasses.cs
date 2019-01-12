namespace NjitSoftware
{
    partial class UserAccessPermission
    {
    }
}
namespace NjitSoftware.Model.Common
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    partial class ArchiveCommonDataClassesDataContext
    {
    }

    public partial class AccessPermissionTree
    {
        public static AccessPermissionTree GetNewInstance(int ID, string Item, string Group, string Title, bool Visible, bool Flag)
        {
            AccessPermissionTree _Instance = new AccessPermissionTree();
            _Instance.ID = ID;
            _Instance.Item = Item;
            _Instance.Group = Group;
            _Instance.Title = Title;
            _Instance.Visible = Visible;
            _Instance.Flag = Flag;
            return _Instance;
        }
        public static AccessPermissionTree GetNewInstance(string Item, string Group, string Title, bool Visible, bool Flag)
        {
            AccessPermissionTree _Instance = new AccessPermissionTree();
            _Instance.Item = Item;
            _Instance.Group = Group;
            _Instance.Title = Title;
            _Instance.Visible = Visible;
            _Instance.Flag = Flag;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "AccessPermissionTree";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, AccessPermissionTree NewInstance)
        {
            DataContext.GetTable<AccessPermissionTree>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(AccessPermissionTree OriginalInstance, AccessPermissionTree NewInstance)
        {
            OriginalInstance.Item = NewInstance.Item;
            OriginalInstance.Group = NewInstance.Group;
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.Visible = NewInstance.Visible;
            OriginalInstance.Flag = NewInstance.Flag;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, AccessPermissionTree OriginalInstance)
        {
            DataContext.GetTable<AccessPermissionTree>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Archive
    {
        public static Archive GetNewInstance(int ID, string Name, string Title, string DatabasePath, bool Active, bool Default, System.Nullable<int> ArchiveGroupID)
        {
            Archive _Instance = new Archive();
            _Instance.ID = ID;
            _Instance.Name = Name;
            _Instance.Title = Title;
            _Instance.DatabasePath = DatabasePath;
            _Instance.Active = Active;
            _Instance.Default = Default;
            _Instance.ArchiveGroupID = ArchiveGroupID;
            return _Instance;
        }
        public static Archive GetNewInstance(string Name, string Title, string DatabasePath, bool Active, bool Default, System.Nullable<int> ArchiveGroupID)
        {
            Archive _Instance = new Archive();
            _Instance.Name = Name;
            _Instance.Title = Title;
            _Instance.DatabasePath = DatabasePath;
            _Instance.Active = Active;
            _Instance.Default = Default;
            _Instance.ArchiveGroupID = ArchiveGroupID;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Archive";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Archive NewInstance)
        {
            DataContext.GetTable<Archive>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Archive OriginalInstance, Archive NewInstance)
        {
            OriginalInstance.Name = NewInstance.Name;
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.DatabasePath = NewInstance.DatabasePath;
            OriginalInstance.Active = NewInstance.Active;
            OriginalInstance.Default = NewInstance.Default;
            OriginalInstance.ArchiveGroupID = NewInstance.ArchiveGroupID;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Archive OriginalInstance)
        {
            DataContext.GetTable<Archive>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveGroup
    {
        public static ArchiveGroup GetNewInstance(int ID, string Title, System.Nullable<int> ParentID)
        {
            ArchiveGroup _Instance = new ArchiveGroup();
            _Instance.ID = ID;
            _Instance.Title = Title;
            _Instance.ParentID = ParentID;
            return _Instance;
        }
        public static ArchiveGroup GetNewInstance(string Title, System.Nullable<int> ParentID)
        {
            ArchiveGroup _Instance = new ArchiveGroup();
            _Instance.Title = Title;
            _Instance.ParentID = ParentID;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveGroup";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveGroup NewInstance)
        {
            DataContext.GetTable<ArchiveGroup>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveGroup OriginalInstance, ArchiveGroup NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.ParentID = NewInstance.ParentID;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveGroup OriginalInstance)
        {
            DataContext.GetTable<ArchiveGroup>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveGroupField
    {
        public static ArchiveGroupField GetNewInstance(int ID, int ArchiveGroupID, int ArchiveGroupTabID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, int Index)
        {
            ArchiveGroupField _Instance = new ArchiveGroupField();
            _Instance.ID = ID;
            _Instance.ArchiveGroupID = ArchiveGroupID;
            _Instance.ArchiveGroupTabID = ArchiveGroupTabID;
            _Instance.Label = Label;
            _Instance.FieldName = FieldName;
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.StatusCode = StatusCode;
            _Instance.BoxTypeCode = BoxTypeCode;
            _Instance.AutoComplete = AutoComplete;
            _Instance.MinLength = MinLength;
            _Instance.MaxLength = MaxLength;
            _Instance.MinValue = MinValue;
            _Instance.MaxValue = MaxValue;
            _Instance.DefaultValue = DefaultValue;
            _Instance.Index = Index;
            return _Instance;
        }
        public static ArchiveGroupField GetNewInstance(int ArchiveGroupID, int ArchiveGroupTabID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, int Index)
        {
            ArchiveGroupField _Instance = new ArchiveGroupField();
            _Instance.ArchiveGroupID = ArchiveGroupID;
            _Instance.ArchiveGroupTabID = ArchiveGroupTabID;
            _Instance.Label = Label;
            _Instance.FieldName = FieldName;
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.StatusCode = StatusCode;
            _Instance.BoxTypeCode = BoxTypeCode;
            _Instance.AutoComplete = AutoComplete;
            _Instance.MinLength = MinLength;
            _Instance.MaxLength = MaxLength;
            _Instance.MinValue = MinValue;
            _Instance.MaxValue = MaxValue;
            _Instance.DefaultValue = DefaultValue;
            _Instance.Index = Index;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveGroupField";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveGroupField NewInstance)
        {
            DataContext.GetTable<ArchiveGroupField>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveGroupField OriginalInstance, ArchiveGroupField NewInstance)
        {
            OriginalInstance.ArchiveGroupID = NewInstance.ArchiveGroupID;
            OriginalInstance.ArchiveGroupTabID = NewInstance.ArchiveGroupTabID;
            OriginalInstance.Label = NewInstance.Label;
            OriginalInstance.FieldName = NewInstance.FieldName;
            OriginalInstance.FieldTypeCode = NewInstance.FieldTypeCode;
            OriginalInstance.StatusCode = NewInstance.StatusCode;
            OriginalInstance.BoxTypeCode = NewInstance.BoxTypeCode;
            OriginalInstance.AutoComplete = NewInstance.AutoComplete;
            OriginalInstance.MinLength = NewInstance.MinLength;
            OriginalInstance.MaxLength = NewInstance.MaxLength;
            OriginalInstance.MinValue = NewInstance.MinValue;
            OriginalInstance.MaxValue = NewInstance.MaxValue;
            OriginalInstance.DefaultValue = NewInstance.DefaultValue;
            OriginalInstance.Index = NewInstance.Index;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveGroupField OriginalInstance)
        {
            DataContext.GetTable<ArchiveGroupField>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveGroupSubGroupField
    {
        public static ArchiveGroupSubGroupField GetNewInstance(int ID, int ArchiveGroupFieldID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, int Index)
        {
            ArchiveGroupSubGroupField _Instance = new ArchiveGroupSubGroupField();
            _Instance.ID = ID;
            _Instance.ArchiveGroupFieldID = ArchiveGroupFieldID;
            _Instance.Label = Label;
            _Instance.FieldName = FieldName;
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.StatusCode = StatusCode;
            _Instance.BoxTypeCode = BoxTypeCode;
            _Instance.AutoComplete = AutoComplete;
            _Instance.MinLength = MinLength;
            _Instance.MaxLength = MaxLength;
            _Instance.MinValue = MinValue;
            _Instance.MaxValue = MaxValue;
            _Instance.DefaultValue = DefaultValue;
            _Instance.Index = Index;
            return _Instance;
        }
        public static ArchiveGroupSubGroupField GetNewInstance(int ArchiveGroupFieldID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, int Index)
        {
            ArchiveGroupSubGroupField _Instance = new ArchiveGroupSubGroupField();
            _Instance.ArchiveGroupFieldID = ArchiveGroupFieldID;
            _Instance.Label = Label;
            _Instance.FieldName = FieldName;
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.StatusCode = StatusCode;
            _Instance.BoxTypeCode = BoxTypeCode;
            _Instance.AutoComplete = AutoComplete;
            _Instance.MinLength = MinLength;
            _Instance.MaxLength = MaxLength;
            _Instance.MinValue = MinValue;
            _Instance.MaxValue = MaxValue;
            _Instance.DefaultValue = DefaultValue;
            _Instance.Index = Index;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveGroupSubGroupField";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveGroupSubGroupField NewInstance)
        {
            DataContext.GetTable<ArchiveGroupSubGroupField>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveGroupSubGroupField OriginalInstance, ArchiveGroupSubGroupField NewInstance)
        {
            OriginalInstance.ArchiveGroupFieldID = NewInstance.ArchiveGroupFieldID;
            OriginalInstance.Label = NewInstance.Label;
            OriginalInstance.FieldName = NewInstance.FieldName;
            OriginalInstance.FieldTypeCode = NewInstance.FieldTypeCode;
            OriginalInstance.StatusCode = NewInstance.StatusCode;
            OriginalInstance.BoxTypeCode = NewInstance.BoxTypeCode;
            OriginalInstance.AutoComplete = NewInstance.AutoComplete;
            OriginalInstance.MinLength = NewInstance.MinLength;
            OriginalInstance.MaxLength = NewInstance.MaxLength;
            OriginalInstance.MinValue = NewInstance.MinValue;
            OriginalInstance.MaxValue = NewInstance.MaxValue;
            OriginalInstance.DefaultValue = NewInstance.DefaultValue;
            OriginalInstance.Index = NewInstance.Index;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveGroupSubGroupField OriginalInstance)
        {
            DataContext.GetTable<ArchiveGroupSubGroupField>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveGroupTab
    {
        public static ArchiveGroupTab GetNewInstance(int ID, int ArchiveGroupID, int TypeCode, int Index, string Title)
        {
            ArchiveGroupTab _Instance = new ArchiveGroupTab();
            _Instance.ID = ID;
            _Instance.ArchiveGroupID = ArchiveGroupID;
            _Instance.TypeCode = TypeCode;
            _Instance.Index = Index;
            _Instance.Title = Title;
            return _Instance;
        }
        public static ArchiveGroupTab GetNewInstance(int ArchiveGroupID, int TypeCode, int Index, string Title)
        {
            ArchiveGroupTab _Instance = new ArchiveGroupTab();
            _Instance.ArchiveGroupID = ArchiveGroupID;
            _Instance.TypeCode = TypeCode;
            _Instance.Index = Index;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveGroupTab";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveGroupTab NewInstance)
        {
            DataContext.GetTable<ArchiveGroupTab>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveGroupTab OriginalInstance, ArchiveGroupTab NewInstance)
        {
            OriginalInstance.ArchiveGroupID = NewInstance.ArchiveGroupID;
            OriginalInstance.TypeCode = NewInstance.TypeCode;
            OriginalInstance.Index = NewInstance.Index;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveGroupTab OriginalInstance)
        {
            DataContext.GetTable<ArchiveGroupTab>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveGroupTabType
    {
        public static ArchiveGroupTabType GetNewInstance(int Code, string Title)
        {
            ArchiveGroupTabType _Instance = new ArchiveGroupTabType();
            _Instance.Code = Code;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveGroupTabType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveGroupTabType NewInstance)
        {
            DataContext.GetTable<ArchiveGroupTabType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveGroupTabType OriginalInstance, ArchiveGroupTabType NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveGroupTabType OriginalInstance)
        {
            DataContext.GetTable<ArchiveGroupTabType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveTree
    {
        public static ArchiveTree GetNewInstance(int ID, string Title, System.Nullable<int> ArchiveGroupID, System.Nullable<int> ArchiveID, string Filter, string GroupBy, System.Nullable<int> ParentID, int Index)
        {
            ArchiveTree _Instance = new ArchiveTree();
            _Instance.ID = ID;
            _Instance.Title = Title;
            _Instance.ArchiveGroupID = ArchiveGroupID;
            _Instance.ArchiveID = ArchiveID;
            _Instance.Filter = Filter;
            _Instance.GroupBy = GroupBy;
            _Instance.ParentID = ParentID;
            _Instance.Index = Index;
            return _Instance;
        }
        public static ArchiveTree GetNewInstance(string Title, System.Nullable<int> ArchiveGroupID, System.Nullable<int> ArchiveID, string Filter, string GroupBy, System.Nullable<int> ParentID, int Index)
        {
            ArchiveTree _Instance = new ArchiveTree();
            _Instance.Title = Title;
            _Instance.ArchiveGroupID = ArchiveGroupID;
            _Instance.ArchiveID = ArchiveID;
            _Instance.Filter = Filter;
            _Instance.GroupBy = GroupBy;
            _Instance.ParentID = ParentID;
            _Instance.Index = Index;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveTree";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveTree NewInstance)
        {
            DataContext.GetTable<ArchiveTree>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveTree OriginalInstance, ArchiveTree NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.ArchiveGroupID = NewInstance.ArchiveGroupID;
            OriginalInstance.ArchiveID = NewInstance.ArchiveID;
            OriginalInstance.Filter = NewInstance.Filter;
            OriginalInstance.GroupBy = NewInstance.GroupBy;
            OriginalInstance.ParentID = NewInstance.ParentID;
            OriginalInstance.Index = NewInstance.Index;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveTree OriginalInstance)
        {
            DataContext.GetTable<ArchiveTree>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class BoxOfFieldType
    {
        public static BoxOfFieldType GetNewInstance(int ID, int FieldTypeCode, int BoxTypeCode)
        {
            BoxOfFieldType _Instance = new BoxOfFieldType();
            _Instance.ID = ID;
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.BoxTypeCode = BoxTypeCode;
            return _Instance;
        }
        public static BoxOfFieldType GetNewInstance(int FieldTypeCode, int BoxTypeCode)
        {
            BoxOfFieldType _Instance = new BoxOfFieldType();
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.BoxTypeCode = BoxTypeCode;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "BoxOfFieldType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, BoxOfFieldType NewInstance)
        {
            DataContext.GetTable<BoxOfFieldType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(BoxOfFieldType OriginalInstance, BoxOfFieldType NewInstance)
        {
            OriginalInstance.FieldTypeCode = NewInstance.FieldTypeCode;
            OriginalInstance.BoxTypeCode = NewInstance.BoxTypeCode;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, BoxOfFieldType OriginalInstance)
        {
            DataContext.GetTable<BoxOfFieldType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class BoxType
    {
        public static BoxType GetNewInstance(int Code, string Title)
        {
            BoxType _Instance = new BoxType();
            _Instance.Code = Code;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "BoxType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, BoxType NewInstance)
        {
            DataContext.GetTable<BoxType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(BoxType OriginalInstance, BoxType NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, BoxType OriginalInstance)
        {
            DataContext.GetTable<BoxType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class CounterFieldSetting
    {
        public static CounterFieldSetting GetNewInstance(int ID, int ArchiveGroupFieldID, int FixedValueType, string FixedValue, string Separator)
        {
            CounterFieldSetting _Instance = new CounterFieldSetting();
            _Instance.ID = ID;
            _Instance.ArchiveGroupFieldID = ArchiveGroupFieldID;
            _Instance.FixedValueType = FixedValueType;
            _Instance.FixedValue = FixedValue;
            _Instance.Separator = Separator;
            return _Instance;
        }
        public static CounterFieldSetting GetNewInstance(int ArchiveGroupFieldID, int FixedValueType, string FixedValue, string Separator)
        {
            CounterFieldSetting _Instance = new CounterFieldSetting();
            _Instance.ArchiveGroupFieldID = ArchiveGroupFieldID;
            _Instance.FixedValueType = FixedValueType;
            _Instance.FixedValue = FixedValue;
            _Instance.Separator = Separator;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "CounterFieldSetting";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, CounterFieldSetting NewInstance)
        {
            DataContext.GetTable<CounterFieldSetting>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(CounterFieldSetting OriginalInstance, CounterFieldSetting NewInstance)
        {
            OriginalInstance.ArchiveGroupFieldID = NewInstance.ArchiveGroupFieldID;
            OriginalInstance.FixedValueType = NewInstance.FixedValueType;
            OriginalInstance.FixedValue = NewInstance.FixedValue;
            OriginalInstance.Separator = NewInstance.Separator;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, CounterFieldSetting OriginalInstance)
        {
            DataContext.GetTable<CounterFieldSetting>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class DatabaseVersion
    {
        public static DatabaseVersion GetNewInstance(int ID, string Version, System.Nullable<System.Guid> ApplicationID)
        {
            DatabaseVersion _Instance = new DatabaseVersion();
            _Instance.ID = ID;
            _Instance.Version = Version;
            _Instance.ApplicationID = ApplicationID;
            return _Instance;
        }
        public static DatabaseVersion GetNewInstance(string Version, System.Nullable<System.Guid> ApplicationID)
        {
            DatabaseVersion _Instance = new DatabaseVersion();
            _Instance.Version = Version;
            _Instance.ApplicationID = ApplicationID;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "DatabaseVersion";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, DatabaseVersion NewInstance)
        {
            DataContext.GetTable<DatabaseVersion>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(DatabaseVersion OriginalInstance, DatabaseVersion NewInstance)
        {
            OriginalInstance.Version = NewInstance.Version;
            OriginalInstance.ApplicationID = NewInstance.ApplicationID;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, DatabaseVersion OriginalInstance)
        {
            DataContext.GetTable<DatabaseVersion>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class FieldStatus
    {
        public static FieldStatus GetNewInstance(int Code, string Title)
        {
            FieldStatus _Instance = new FieldStatus();
            _Instance.Code = Code;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "FieldStatus";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, FieldStatus NewInstance)
        {
            DataContext.GetTable<FieldStatus>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(FieldStatus OriginalInstance, FieldStatus NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, FieldStatus OriginalInstance)
        {
            DataContext.GetTable<FieldStatus>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class FieldType
    {
        public static FieldType GetNewInstance(int Code, string Title, int Index)
        {
            FieldType _Instance = new FieldType();
            _Instance.Code = Code;
            _Instance.Title = Title;
            _Instance.Index = Index;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "FieldType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, FieldType NewInstance)
        {
            DataContext.GetTable<FieldType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(FieldType OriginalInstance, FieldType NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.Index = NewInstance.Index;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, FieldType OriginalInstance)
        {
            DataContext.GetTable<FieldType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class DocumentsFailure {
        public static DocumentsFailure GetNewInstance(int ID, int ArchiveID, string PerssonelNumber, string DocumnetNumber, int documentID, int Title, string Description, int UserSender, int Userchecker, bool isRead, DateTime DateSender, DateTime DateChecker)
        {
            DocumentsFailure _Instance = new DocumentsFailure();
            _Instance.ID = ID;
            _Instance.ArchiveID = ArchiveID;
            _Instance.PerssonelNumber = PerssonelNumber;
            _Instance.documentID = documentID;
            _Instance.Title = Title;
            _Instance.Description = Description;
            _Instance.UserSender = UserSender;
            _Instance.Userchecker = Userchecker;
            _Instance.Title = Title;
            _Instance.isRead = isRead;
            _Instance.DateChecker = DateChecker;
            _Instance.DateSender = DateSender;
            _Instance.DocumnetNumber = DocumnetNumber;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "DocumentsFailure";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, DocumentsFailure NewInstance)
        {
            DataContext.GetTable<DocumentsFailure>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(DocumentsFailure OriginalInstance, DocumentsFailure NewInstance)
        {
            OriginalInstance.ID = NewInstance.ID;
            OriginalInstance.ArchiveID = NewInstance.ArchiveID;
            OriginalInstance.PerssonelNumber = NewInstance.PerssonelNumber;
            OriginalInstance.documentID = NewInstance.documentID;
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.Description = NewInstance.Description;
            OriginalInstance.UserSender = NewInstance.UserSender;
            OriginalInstance.Userchecker = NewInstance.Userchecker;
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.isRead = NewInstance.isRead;
            OriginalInstance.DateChecker = NewInstance.DateChecker;
            OriginalInstance.DocumnetNumber = NewInstance.DocumnetNumber;
            OriginalInstance.DateSender = NewInstance.DateSender;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, DocumentsFailure OriginalInstance)
        {
            DataContext.GetTable<DocumentsFailure>().DeleteOnSubmit(OriginalInstance);
        }
    
    }

    public partial class PermissionSecurity
    {
        public static PermissionSecurity GetNewInstance(int ID, int PK_User, int PK_Archive, int PK_SecurityORField18)
        {
            PermissionSecurity _Instance = new PermissionSecurity();
            _Instance.ID = ID;
            _Instance.PK_User = PK_User;
            _Instance.PK_Archive = PK_Archive;
            _Instance.PK_SecurityORField18 = PK_SecurityORField18;
            
            return _Instance;
        }
        public static string GetTableName()
        {
            return "PermissionSecurity";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, PermissionSecurity NewInstance)
        {
            DataContext.GetTable<PermissionSecurity>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(PermissionSecurity OriginalInstance, PermissionSecurity NewInstance)
        {
            OriginalInstance.ID = NewInstance.ID;
            OriginalInstance.PK_Archive = NewInstance.PK_Archive;
            OriginalInstance.PK_User = NewInstance.PK_User;
            OriginalInstance.PK_SecurityORField18 = NewInstance.PK_SecurityORField18;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, PermissionSecurity OriginalInstance)
        {
            DataContext.GetTable<PermissionSecurity>().DeleteOnSubmit(OriginalInstance);
        }

    }
    public partial class PermissionTitle
    {
        public static PermissionTitle GetNewInstance(int ID, int PK_User, int PK_Archive, int _PK_TitleORField11)
        {
            PermissionTitle _Instance = new PermissionTitle();
            _Instance.ID = ID;
            _Instance.PK_User = PK_User;
            _Instance.PK_Archive = PK_Archive;
            _Instance._PK_TitleORField11 = _PK_TitleORField11;

            return _Instance;
        }
        public static string GetTableName()
        {
            return "PermissionTitle";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, PermissionTitle NewInstance)
        {
            DataContext.GetTable<PermissionTitle>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(PermissionTitle OriginalInstance, PermissionTitle NewInstance)
        {
            OriginalInstance.ID = NewInstance.ID;
            OriginalInstance.PK_Archive = NewInstance.PK_Archive;
            OriginalInstance.PK_User = NewInstance.PK_User;
            OriginalInstance._PK_TitleORField11 = NewInstance._PK_TitleORField11;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, PermissionTitle OriginalInstance)
        {
            DataContext.GetTable<PermissionTitle>().DeleteOnSubmit(OriginalInstance);
        }

    }
    public partial class PermissionDossier
    {
        public static PermissionDossier GetNewInstance(int ID, int PK_User, int PK_Archive, int DossierTypess)
        {
            PermissionDossier _Instance = new PermissionDossier();
            _Instance.ID = ID;
            _Instance.PK_User = PK_User;
            _Instance.PK_Archive = PK_Archive;
            _Instance.DossierType = DossierTypess;

            return _Instance;
        }
        public static string GetTableName()
        {
            return "PermissionDossier";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, PermissionDossier NewInstance)
        {
            DataContext.GetTable<PermissionDossier>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(PermissionDossier OriginalInstance, PermissionDossier NewInstance)
        {
            OriginalInstance.ID = NewInstance.ID;
            OriginalInstance.PK_Archive = NewInstance.PK_Archive;
            OriginalInstance.PK_User = NewInstance.PK_User;
            OriginalInstance.DossierType = NewInstance.DossierType;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, PermissionDossier OriginalInstance)
        {
            DataContext.GetTable<PermissionDossier>().DeleteOnSubmit(OriginalInstance);
        }

    }
    public partial class FormState
    {
        public static FormState GetNewInstance(string MachineName, string FormName, int WindowState, int Width, int Height, int X, int Y)
        {
            FormState _Instance = new FormState();
            _Instance.MachineName = MachineName;
            _Instance.FormName = FormName;
            _Instance.WindowState = WindowState;
            _Instance.Width = Width;
            _Instance.Height = Height;
            _Instance.X = X;
            _Instance.Y = Y;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "FormState";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, FormState NewInstance)
        {
            DataContext.GetTable<FormState>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(FormState OriginalInstance, FormState NewInstance)
        {
            OriginalInstance.MachineName = NewInstance.MachineName;
            OriginalInstance.FormName = NewInstance.FormName;
            OriginalInstance.WindowState = NewInstance.WindowState;
            OriginalInstance.Width = NewInstance.Width;
            OriginalInstance.Height = NewInstance.Height;
            OriginalInstance.X = NewInstance.X;
            OriginalInstance.Y = NewInstance.Y;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, FormState OriginalInstance)
        {
            DataContext.GetTable<FormState>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ProgramSetting
    {
        public static ProgramSetting GetNewInstance(int ID, bool ShowBackupFormOnExit, string ExpiryDate, string LastRunDate)
        {
            ProgramSetting _Instance = new ProgramSetting();
            _Instance.ID = ID;
            _Instance.ShowBackupFormOnExit = ShowBackupFormOnExit;
            _Instance.ExpiryDate = ExpiryDate;
            _Instance.LastRunDate = LastRunDate;
            return _Instance;
        }
        public static ProgramSetting GetNewInstance(bool ShowBackupFormOnExit, string ExpiryDate, string LastRunDate)
        {
            ProgramSetting _Instance = new ProgramSetting();
            _Instance.ShowBackupFormOnExit = ShowBackupFormOnExit;
            _Instance.ExpiryDate = ExpiryDate;
            _Instance.LastRunDate = LastRunDate;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ProgramSetting";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ProgramSetting NewInstance)
        {
            DataContext.GetTable<ProgramSetting>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ProgramSetting OriginalInstance, ProgramSetting NewInstance)
        {
            OriginalInstance.ShowBackupFormOnExit = NewInstance.ShowBackupFormOnExit;
            OriginalInstance.ExpiryDate = NewInstance.ExpiryDate;
            OriginalInstance.LastRunDate = NewInstance.LastRunDate;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ProgramSetting OriginalInstance)
        {
            DataContext.GetTable<ProgramSetting>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class StatusOfFieldType
    {
        public static StatusOfFieldType GetNewInstance(int ID, int FieldTypeCode, int StatusCode)
        {
            StatusOfFieldType _Instance = new StatusOfFieldType();
            _Instance.ID = ID;
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.StatusCode = StatusCode;
            return _Instance;
        }
        public static StatusOfFieldType GetNewInstance(int FieldTypeCode, int StatusCode)
        {
            StatusOfFieldType _Instance = new StatusOfFieldType();
            _Instance.FieldTypeCode = FieldTypeCode;
            _Instance.StatusCode = StatusCode;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "StatusOfFieldType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, StatusOfFieldType NewInstance)
        {
            DataContext.GetTable<StatusOfFieldType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(StatusOfFieldType OriginalInstance, StatusOfFieldType NewInstance)
        {
            OriginalInstance.FieldTypeCode = NewInstance.FieldTypeCode;
            OriginalInstance.StatusCode = NewInstance.StatusCode;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, StatusOfFieldType OriginalInstance)
        {
            DataContext.GetTable<StatusOfFieldType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class TaskSchedule
    {
        public static TaskSchedule GetNewInstance(
                    int ID,
                    string TaskCode,
                    string Name,
                    string Description,
                    string AdditionalInfo,
                    int RepeatTypeCode,
                    int ScheduleTypeCode,
                    string BackupPath,
                    string BackupFileName,
                    System.Nullable<int> BackupNameType,
                    string ExecuteFilePath,
                    string ExecuteParameter,
                    string MessageTitle,
                    string MessageBody,
                    string StartDate,
                    string StartTime,
                    string EndDate,
                    string EndTime,
                    string ExecuteTime,
                    string WeekDays,
                    string Months,
                    System.Nullable<int> MonthDay,
                    bool Flag)
        {
            TaskSchedule _Instance = new TaskSchedule();
            _Instance.ID = ID;
            _Instance.TaskCode = TaskCode;
            _Instance.Name = Name;
            _Instance.Description = Description;
            _Instance.AdditionalInfo = AdditionalInfo;
            _Instance.RepeatTypeCode = RepeatTypeCode;
            _Instance.ScheduleTypeCode = ScheduleTypeCode;
            _Instance.BackupPath = BackupPath;
            _Instance.BackupFileName = BackupFileName;
            _Instance.BackupNameType = BackupNameType;
            _Instance.ExecuteFilePath = ExecuteFilePath;
            _Instance.ExecuteParameter = ExecuteParameter;
            _Instance.MessageTitle = MessageTitle;
            _Instance.MessageBody = MessageBody;
            _Instance.StartDate = StartDate;
            _Instance.StartTime = StartTime;
            _Instance.EndDate = EndDate;
            _Instance.EndTime = EndTime;
            _Instance.ExecuteTime = ExecuteTime;
            _Instance.WeekDays = WeekDays;
            _Instance.Months = Months;
            _Instance.MonthDay = MonthDay;
            _Instance.Flag = Flag;
            return _Instance;
        }
        public static TaskSchedule GetNewInstance(
                    string TaskCode,
                    string Name,
                    string Description,
                    string AdditionalInfo,
                    int RepeatTypeCode,
                    int ScheduleTypeCode,
                    string BackupPath,
                    string BackupFileName,
                    System.Nullable<int> BackupNameType,
                    string ExecuteFilePath,
                    string ExecuteParameter,
                    string MessageTitle,
                    string MessageBody,
                    string StartDate,
                    string StartTime,
                    string EndDate,
                    string EndTime,
                    string ExecuteTime,
                    string WeekDays,
                    string Months,
                    System.Nullable<int> MonthDay,
                    bool Flag)
        {
            TaskSchedule _Instance = new TaskSchedule();
            _Instance.TaskCode = TaskCode;
            _Instance.Name = Name;
            _Instance.Description = Description;
            _Instance.AdditionalInfo = AdditionalInfo;
            _Instance.RepeatTypeCode = RepeatTypeCode;
            _Instance.ScheduleTypeCode = ScheduleTypeCode;
            _Instance.BackupPath = BackupPath;
            _Instance.BackupFileName = BackupFileName;
            _Instance.BackupNameType = BackupNameType;
            _Instance.ExecuteFilePath = ExecuteFilePath;
            _Instance.ExecuteParameter = ExecuteParameter;
            _Instance.MessageTitle = MessageTitle;
            _Instance.MessageBody = MessageBody;
            _Instance.StartDate = StartDate;
            _Instance.StartTime = StartTime;
            _Instance.EndDate = EndDate;
            _Instance.EndTime = EndTime;
            _Instance.ExecuteTime = ExecuteTime;
            _Instance.WeekDays = WeekDays;
            _Instance.Months = Months;
            _Instance.MonthDay = MonthDay;
            _Instance.Flag = Flag;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "TaskSchedule";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, TaskSchedule NewInstance)
        {
            DataContext.GetTable<TaskSchedule>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(TaskSchedule OriginalInstance, TaskSchedule NewInstance)
        {
            OriginalInstance.TaskCode = NewInstance.TaskCode;
            OriginalInstance.Name = NewInstance.Name;
            OriginalInstance.Description = NewInstance.Description;
            OriginalInstance.AdditionalInfo = NewInstance.AdditionalInfo;
            OriginalInstance.RepeatTypeCode = NewInstance.RepeatTypeCode;
            OriginalInstance.ScheduleTypeCode = NewInstance.ScheduleTypeCode;
            OriginalInstance.BackupPath = NewInstance.BackupPath;
            OriginalInstance.BackupFileName = NewInstance.BackupFileName;
            OriginalInstance.BackupNameType = NewInstance.BackupNameType;
            OriginalInstance.ExecuteFilePath = NewInstance.ExecuteFilePath;
            OriginalInstance.ExecuteParameter = NewInstance.ExecuteParameter;
            OriginalInstance.MessageTitle = NewInstance.MessageTitle;
            OriginalInstance.MessageBody = NewInstance.MessageBody;
            OriginalInstance.StartDate = NewInstance.StartDate;
            OriginalInstance.StartTime = NewInstance.StartTime;
            OriginalInstance.EndDate = NewInstance.EndDate;
            OriginalInstance.EndTime = NewInstance.EndTime;
            OriginalInstance.ExecuteTime = NewInstance.ExecuteTime;
            OriginalInstance.WeekDays = NewInstance.WeekDays;
            OriginalInstance.Months = NewInstance.Months;
            OriginalInstance.MonthDay = NewInstance.MonthDay;
            OriginalInstance.Flag = NewInstance.Flag;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, TaskSchedule OriginalInstance)
        {
            DataContext.GetTable<TaskSchedule>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class User
    {
        public static User GetNewInstance(int Code, string UserName, string Password, string FullName, string NikName, System.Nullable<System.DateTime> LastLogin, string RoleCode, string StateCode, string Visible, bool isGuest, bool isLogin, DateTime? Expire, string IPAddress)
        {
            User _Instance = new User();
            _Instance.Code = Code;
            _Instance.UserName = UserName;
            _Instance.Password = Password;
            _Instance.FullName = FullName;
            _Instance.NikName = NikName;
            _Instance.LastLogin = LastLogin;
            _Instance.RoleCode = RoleCode;
            _Instance.StateCode = StateCode;
            _Instance.Visible = Visible;
            _Instance.isGuest = isGuest;
            _Instance.isLogin = isLogin;
            _Instance.Expire = Expire;
            _Instance.IPAddress = IPAddress;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "User";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, User NewInstance)
        {
            DataContext.GetTable<User>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(User OriginalInstance, User NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.UserName = NewInstance.UserName;
            OriginalInstance.Password = NewInstance.Password;
            OriginalInstance.FullName = NewInstance.FullName;
            OriginalInstance.NikName = NewInstance.NikName;
            OriginalInstance.LastLogin = NewInstance.LastLogin;
            OriginalInstance.RoleCode = NewInstance.RoleCode;
            OriginalInstance.StateCode = NewInstance.StateCode;
            OriginalInstance.Visible = NewInstance.Visible;
            OriginalInstance.isLogin = NewInstance.isLogin;
            OriginalInstance.isGuest = NewInstance.isGuest;
            OriginalInstance.Expire = NewInstance.Expire;
            OriginalInstance.IPAddress = NewInstance.IPAddress;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, User OriginalInstance)
        {
            DataContext.GetTable<User>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class UserAccessPermission
    {
        public static UserAccessPermission GetNewInstance(int ID, string ItemCode, int UserCode, string Allow)
        {
            UserAccessPermission _Instance = new UserAccessPermission();
            _Instance.ID = ID;
            _Instance.ItemCode = ItemCode;
            _Instance.UserCode = UserCode;
            _Instance.Allow = Allow;
            return _Instance;
        }
        public static UserAccessPermission GetNewInstance(string ItemCode, int UserCode, string Allow)
        {
            UserAccessPermission _Instance = new UserAccessPermission();
            _Instance.ItemCode = ItemCode;
            _Instance.UserCode = UserCode;
            _Instance.Allow = Allow;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "UserAccessPermission";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, UserAccessPermission NewInstance)
        {
            DataContext.GetTable<UserAccessPermission>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(UserAccessPermission OriginalInstance, UserAccessPermission NewInstance)
        {
            OriginalInstance.ItemCode = NewInstance.ItemCode;
            OriginalInstance.UserCode = NewInstance.UserCode;
            OriginalInstance.Allow = NewInstance.Allow;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, UserAccessPermission OriginalInstance)
        {
            DataContext.GetTable<UserAccessPermission>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class UserLog
    {
        public static UserLog GetNewInstance(int ID, int UserCode, string OperationPlaceCode, string OperationCode, string Code, string Description, string Date, string Time, System.Nullable<int> ArchiveID, string IPAddress)
        {
            UserLog _Instance = new UserLog();
            _Instance.ID = ID;
            _Instance.UserCode = UserCode;
            _Instance.OperationPlaceCode = OperationPlaceCode;
            _Instance.OperationCode = OperationCode;
            _Instance.Code = Code;
            _Instance.Description = Description;
            _Instance.Date = Date;
            _Instance.Time = Time;
            _Instance.ArchiveID = ArchiveID;
            _Instance.IPAddress = IPAddress;
            return _Instance;
        }
        public static UserLog GetNewInstance(int UserCode, string OperationPlaceCode, string OperationCode, string Code, string Description, string Date, string Time, System.Nullable<int> ArchiveID, string IPAddress)
        {
            UserLog _Instance = new UserLog();
            _Instance.UserCode = UserCode;
            _Instance.OperationPlaceCode = OperationPlaceCode;
            _Instance.OperationCode = OperationCode;
            _Instance.Code = Code;
            _Instance.Description = Description;
            _Instance.Date = Date;
            _Instance.Time = Time;
            _Instance.ArchiveID = ArchiveID;
            _Instance.IPAddress = IPAddress;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "UserLog";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, UserLog NewInstance)
        {
            DataContext.GetTable<UserLog>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(UserLog OriginalInstance, UserLog NewInstance)
        {
            OriginalInstance.UserCode = NewInstance.UserCode;
            OriginalInstance.OperationPlaceCode = NewInstance.OperationPlaceCode;
            OriginalInstance.OperationCode = NewInstance.OperationCode;
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Description = NewInstance.Description;
            OriginalInstance.Date = NewInstance.Date;
            OriginalInstance.Time = NewInstance.Time;
            OriginalInstance.ArchiveID = NewInstance.ArchiveID;
            OriginalInstance.IPAddress = NewInstance.IPAddress;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, UserLog OriginalInstance)
        {
            DataContext.GetTable<UserLog>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class UserRole
    {
        public static UserRole GetNewInstance(int ID, string Name, bool Locked)
        {
            UserRole _Instance = new UserRole();
            _Instance.ID = ID;
            _Instance.Name = Name;
            _Instance.Locked = Locked;
            return _Instance;
        }
        public static UserRole GetNewInstance(string Name, bool Locked)
        {
            UserRole _Instance = new UserRole();
            _Instance.Name = Name;
            _Instance.Locked = Locked;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "UserRole";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, UserRole NewInstance)
        {
            DataContext.GetTable<UserRole>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(UserRole OriginalInstance, UserRole NewInstance)
        {
            OriginalInstance.Name = NewInstance.Name;
            OriginalInstance.Locked = NewInstance.Locked;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, UserRole OriginalInstance)
        {
            DataContext.GetTable<UserRole>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class UserRoleAccessPermission
    {
        public static UserRoleAccessPermission GetNewInstance(int ID, string ItemCode, int RoleID, string Allow)
        {
            UserRoleAccessPermission _Instance = new UserRoleAccessPermission();
            _Instance.ID = ID;
            _Instance.ItemCode = ItemCode;
            _Instance.RoleID = RoleID;
            _Instance.Allow = Allow;
            return _Instance;
        }
        public static UserRoleAccessPermission GetNewInstance(string ItemCode, int RoleID, string Allow)
        {
            UserRoleAccessPermission _Instance = new UserRoleAccessPermission();
            _Instance.ItemCode = ItemCode;
            _Instance.RoleID = RoleID;
            _Instance.Allow = Allow;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "UserRoleAccessPermission";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, UserRoleAccessPermission NewInstance)
        {
            DataContext.GetTable<UserRoleAccessPermission>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(UserRoleAccessPermission OriginalInstance, UserRoleAccessPermission NewInstance)
        {
            OriginalInstance.ItemCode = NewInstance.ItemCode;
            OriginalInstance.RoleID = NewInstance.RoleID;
            OriginalInstance.Allow = NewInstance.Allow;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, UserRoleAccessPermission OriginalInstance)
        {
            DataContext.GetTable<UserRoleAccessPermission>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class UserSetting
    {
        public static UserSetting GetNewInstance(int UserCode, int ArchiveDocumentsZoom)
        {
            UserSetting _Instance = new UserSetting();
            _Instance.UserCode = UserCode;
            _Instance.ArchiveDocumentsZoom = ArchiveDocumentsZoom;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "UserSetting";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, UserSetting NewInstance)
        {
            DataContext.GetTable<UserSetting>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(UserSetting OriginalInstance, UserSetting NewInstance)
        {
            OriginalInstance.UserCode = NewInstance.UserCode;
            OriginalInstance.ArchiveDocumentsZoom = NewInstance.ArchiveDocumentsZoom;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, UserSetting OriginalInstance)
        {
            DataContext.GetTable<UserSetting>().DeleteOnSubmit(OriginalInstance);
        }
    }
}
