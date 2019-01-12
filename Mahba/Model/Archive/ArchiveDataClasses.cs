namespace NjitSoftware.Model.Archive
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public partial class Address
    {
        public static Address GetNewInstance(long ID, string PersonnelNumber, int AddressTypeID, int ProvinceID, string Township, int MetropolitanAreaID, string Street, string Alley, string PostalCode)
        {
            Address _Instance = new Address();
            _Instance.ID = ID;
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.AddressTypeID = AddressTypeID;
            _Instance.ProvinceID = ProvinceID;
            _Instance.Township = Township;
            _Instance.MetropolitanAreaID = MetropolitanAreaID;
            _Instance.Street = Street;
            _Instance.Alley = Alley;
            _Instance.PostalCode = PostalCode;
            return _Instance;
        }
        public static Address GetNewInstance(string PersonnelNumber, int AddressTypeID, int ProvinceID, string Township, int MetropolitanAreaID, string Street, string Alley, string PostalCode)
        {
            Address _Instance = new Address();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.AddressTypeID = AddressTypeID;
            _Instance.ProvinceID = ProvinceID;
            _Instance.Township = Township;
            _Instance.MetropolitanAreaID = MetropolitanAreaID;
            _Instance.Street = Street;
            _Instance.Alley = Alley;
            _Instance.PostalCode = PostalCode;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Address";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Address NewInstance)
        {
            DataContext.GetTable<Address>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Address OriginalInstance, Address NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.AddressTypeID = NewInstance.AddressTypeID;
            OriginalInstance.ProvinceID = NewInstance.ProvinceID;
            OriginalInstance.Township = NewInstance.Township;
            OriginalInstance.MetropolitanAreaID = NewInstance.MetropolitanAreaID;
            OriginalInstance.Street = NewInstance.Street;
            OriginalInstance.Alley = NewInstance.Alley;
            OriginalInstance.PostalCode = NewInstance.PostalCode;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Address OriginalInstance)
        {
            DataContext.GetTable<Address>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class AddressType
    {
        public static AddressType GetNewInstance(int ID, string Title)
        {
            AddressType _Instance = new AddressType();
            _Instance.ID = ID;
            _Instance.Title = Title;
            return _Instance;
        }
        public static AddressType GetNewInstance(string Title)
        {
            AddressType _Instance = new AddressType();
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "AddressType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, AddressType NewInstance)
        {
            DataContext.GetTable<AddressType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(AddressType OriginalInstance, AddressType NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, AddressType OriginalInstance)
        {
            DataContext.GetTable<AddressType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class AllowedExtension
    {
        public static AllowedExtension GetNewInstance(int ID, string Extension, bool IsImage)
        {
            AllowedExtension _Instance = new AllowedExtension();
            _Instance.ID = ID;
            _Instance.Extension = Extension;
            _Instance.IsImage = IsImage;
            return _Instance;
        }
        public static AllowedExtension GetNewInstance(string Extension, bool IsImage)
        {
            AllowedExtension _Instance = new AllowedExtension();
            _Instance.Extension = Extension;
            _Instance.IsImage = IsImage;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "AllowedExtension";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, AllowedExtension NewInstance)
        {
            DataContext.GetTable<AllowedExtension>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(AllowedExtension OriginalInstance, AllowedExtension NewInstance)
        {
            OriginalInstance.Extension = NewInstance.Extension;
            OriginalInstance.IsImage = NewInstance.IsImage;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, AllowedExtension OriginalInstance)
        {
            DataContext.GetTable<AllowedExtension>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveField
    {
        public static ArchiveField GetNewInstance(int ID, int ArchiveTabID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, System.Nullable<int> IDParent, int Index)
        {
            ArchiveField _Instance = new ArchiveField();
            _Instance.ID = ID;
            _Instance.ArchiveTabID = ArchiveTabID;
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
            _Instance.IDParent = IDParent;
            _Instance.Index = Index;
            return _Instance;
        }
        public static ArchiveField GetNewInstance(int ArchiveTabID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, System.Nullable<int> IDParent, int Index)
        {
            ArchiveField _Instance = new ArchiveField();
            _Instance.ArchiveTabID = ArchiveTabID;
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
            _Instance.IDParent = IDParent;
            _Instance.Index = Index;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveField";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveField NewInstance)
        {
            DataContext.GetTable<ArchiveField>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveField OriginalInstance, ArchiveField NewInstance)
        {
            OriginalInstance.ArchiveTabID = NewInstance.ArchiveTabID;
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
            OriginalInstance.IDParent = NewInstance.IDParent;
            OriginalInstance.Index = NewInstance.Index;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveField OriginalInstance)
        {
            DataContext.GetTable<ArchiveField>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveSetting
    {
        public static ArchiveSetting GetNewInstance(
                    int ID,
                    System.Data.Linq.Binary Background,
                    string BackupPath,
                    bool AutoBackup,
                    string OrganName,
                    System.Data.Linq.Binary Logo,
                    string DocumentsPathOrDatabaseName,
                    string PersonnelNumber_Label,
                    int PersonnelNumber_MinLength,
                    int PersonnelNumber_MaxLength,
                    bool InfoGroupTab,
                    bool UseDatabase,
                    string DatabasePath,
                    string DefaultFilesSavePath,
                    System.Nullable<int> DefaultImageFormatCode,
                    System.Nullable<int> DefaultCompressionTypeCode,
                    int MaxDocumentsSize)
        {
            ArchiveSetting _Instance = new ArchiveSetting();
            _Instance.ID = ID;
            _Instance.Background = Background;
            _Instance.BackupPath = BackupPath;
            _Instance.AutoBackup = AutoBackup;
            _Instance.OrganName = OrganName;
            _Instance.Logo = Logo;
            _Instance.DocumentsPathOrDatabaseName = DocumentsPathOrDatabaseName;
            _Instance.PersonnelNumber_Label = PersonnelNumber_Label;
            _Instance.PersonnelNumber_MinLength = PersonnelNumber_MinLength;
            _Instance.PersonnelNumber_MaxLength = PersonnelNumber_MaxLength;
            _Instance.InfoGroupTab = InfoGroupTab;
            _Instance.UseDatabase = UseDatabase;
            _Instance.DatabasePath = DatabasePath;
            _Instance.DefaultFilesSavePath = DefaultFilesSavePath;
            _Instance.DefaultImageFormatCode = DefaultImageFormatCode;
            _Instance.DefaultCompressionTypeCode = DefaultCompressionTypeCode;
            _Instance.MaxDocumentsSize = MaxDocumentsSize;
            return _Instance;
        }
        public static ArchiveSetting GetNewInstance(
                    System.Data.Linq.Binary Background,
                    string BackupPath,
                    bool AutoBackup,
                    string OrganName,
                    System.Data.Linq.Binary Logo,
                    string DocumentsPathOrDatabaseName,
                    string PersonnelNumber_Label,
                    int PersonnelNumber_MinLength,
                    int PersonnelNumber_MaxLength,
                    bool InfoGroupTab,
                    bool UseDatabase,
                    string DatabasePath,
                    string DefaultFilesSavePath,
                    System.Nullable<int> DefaultImageFormatCode,
                    System.Nullable<int> DefaultCompressionTypeCode,
                    int MaxDocumentsSize)
        {
            ArchiveSetting _Instance = new ArchiveSetting();
            _Instance.Background = Background;
            _Instance.BackupPath = BackupPath;
            _Instance.AutoBackup = AutoBackup;
            _Instance.OrganName = OrganName;
            _Instance.Logo = Logo;
            _Instance.DocumentsPathOrDatabaseName = DocumentsPathOrDatabaseName;
            _Instance.PersonnelNumber_Label = PersonnelNumber_Label;
            _Instance.PersonnelNumber_MinLength = PersonnelNumber_MinLength;
            _Instance.PersonnelNumber_MaxLength = PersonnelNumber_MaxLength;
            _Instance.InfoGroupTab = InfoGroupTab;
            _Instance.UseDatabase = UseDatabase;
            _Instance.DatabasePath = DatabasePath;
            _Instance.DefaultFilesSavePath = DefaultFilesSavePath;
            _Instance.DefaultImageFormatCode = DefaultImageFormatCode;
            _Instance.DefaultCompressionTypeCode = DefaultCompressionTypeCode;
            _Instance.MaxDocumentsSize = MaxDocumentsSize;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveSetting";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveSetting NewInstance)
        {
            DataContext.GetTable<ArchiveSetting>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveSetting OriginalInstance, ArchiveSetting NewInstance)
        {
            OriginalInstance.Background = NewInstance.Background;
            OriginalInstance.BackupPath = NewInstance.BackupPath;
            OriginalInstance.AutoBackup = NewInstance.AutoBackup;
            OriginalInstance.OrganName = NewInstance.OrganName;
            OriginalInstance.Logo = NewInstance.Logo;
            OriginalInstance.DocumentsPathOrDatabaseName = NewInstance.DocumentsPathOrDatabaseName;
            OriginalInstance.PersonnelNumber_Label = NewInstance.PersonnelNumber_Label;
            OriginalInstance.PersonnelNumber_MinLength = NewInstance.PersonnelNumber_MinLength;
            OriginalInstance.PersonnelNumber_MaxLength = NewInstance.PersonnelNumber_MaxLength;
            OriginalInstance.InfoGroupTab = NewInstance.InfoGroupTab;
            OriginalInstance.UseDatabase = NewInstance.UseDatabase;
            OriginalInstance.DatabasePath = NewInstance.DatabasePath;
            OriginalInstance.DefaultFilesSavePath = NewInstance.DefaultFilesSavePath;
            OriginalInstance.DefaultImageFormatCode = NewInstance.DefaultImageFormatCode;
            OriginalInstance.DefaultCompressionTypeCode = NewInstance.DefaultCompressionTypeCode;
            OriginalInstance.MaxDocumentsSize = NewInstance.MaxDocumentsSize;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveSetting OriginalInstance)
        {
            DataContext.GetTable<ArchiveSetting>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveSubGroupField
    {
        public static ArchiveSubGroupField GetNewInstance(int ID, int ArchiveFieldID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, System.Nullable<int> IDParent, int Index)
        {
            ArchiveSubGroupField _Instance = new ArchiveSubGroupField();
            _Instance.ID = ID;
            _Instance.ArchiveFieldID = ArchiveFieldID;
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
            _Instance.IDParent = IDParent;
            _Instance.Index = Index;
            return _Instance;
        }
        public static ArchiveSubGroupField GetNewInstance(int ArchiveFieldID, string Label, string FieldName, int FieldTypeCode, int StatusCode, int BoxTypeCode, bool AutoComplete, System.Nullable<int> MinLength, System.Nullable<int> MaxLength, System.Nullable<double> MinValue, System.Nullable<double> MaxValue, string DefaultValue, System.Nullable<int> IDParent, int Index)
        {
            ArchiveSubGroupField _Instance = new ArchiveSubGroupField();
            _Instance.ArchiveFieldID = ArchiveFieldID;
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
            _Instance.IDParent = IDParent;
            _Instance.Index = Index;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveSubGroupField";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveSubGroupField NewInstance)
        {
            DataContext.GetTable<ArchiveSubGroupField>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveSubGroupField OriginalInstance, ArchiveSubGroupField NewInstance)
        {
            OriginalInstance.ArchiveFieldID = NewInstance.ArchiveFieldID;
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
            OriginalInstance.IDParent = NewInstance.IDParent;
            OriginalInstance.Index = NewInstance.Index;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveSubGroupField OriginalInstance)
        {
            DataContext.GetTable<ArchiveSubGroupField>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveTab
    {
        public static ArchiveTab GetNewInstance(int ID, int TypeCode, int Index, string Name, string Title, bool Exist, bool HaveAttachment, System.Nullable<int> IDParent, bool Deleted)
        {
            ArchiveTab _Instance = new ArchiveTab();
            _Instance.ID = ID;
            _Instance.TypeCode = TypeCode;
            _Instance.Index = Index;
            _Instance.Name = Name;
            _Instance.Title = Title;
            _Instance.Exist = Exist;
            _Instance.HaveAttachment = HaveAttachment;
            _Instance.IDParent = IDParent;
            _Instance.Deleted = Deleted;
            return _Instance;
        }
        public static ArchiveTab GetNewInstance(int TypeCode, int Index, string Name, string Title, bool Exist, bool HaveAttachment, System.Nullable<int> IDParent, bool Deleted)
        {
            ArchiveTab _Instance = new ArchiveTab();
            _Instance.TypeCode = TypeCode;
            _Instance.Index = Index;
            _Instance.Name = Name;
            _Instance.Title = Title;
            _Instance.Exist = Exist;
            _Instance.HaveAttachment = HaveAttachment;
            _Instance.IDParent = IDParent;
            _Instance.Deleted = Deleted;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveTab";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveTab NewInstance)
        {
            DataContext.GetTable<ArchiveTab>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveTab OriginalInstance, ArchiveTab NewInstance)
        {
            OriginalInstance.TypeCode = NewInstance.TypeCode;
            OriginalInstance.Index = NewInstance.Index;
            OriginalInstance.Name = NewInstance.Name;
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.Exist = NewInstance.Exist;
            OriginalInstance.HaveAttachment = NewInstance.HaveAttachment;
            OriginalInstance.IDParent = NewInstance.IDParent;
            OriginalInstance.Deleted = NewInstance.Deleted;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveTab OriginalInstance)
        {
            DataContext.GetTable<ArchiveTab>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ArchiveTabType
    {
        public static ArchiveTabType GetNewInstance(int Code, string Title)
        {
            ArchiveTabType _Instance = new ArchiveTabType();
            _Instance.Code = Code;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ArchiveTabType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ArchiveTabType NewInstance)
        {
            DataContext.GetTable<ArchiveTabType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ArchiveTabType OriginalInstance, ArchiveTabType NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ArchiveTabType OriginalInstance)
        {
            DataContext.GetTable<ArchiveTabType>().DeleteOnSubmit(OriginalInstance);
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
    public partial class CallType
    {
        public static CallType GetNewInstance(int ID, string Title)
        {
            CallType _Instance = new CallType();
            _Instance.ID = ID;
            _Instance.Title = Title;
            return _Instance;
        }
        public static CallType GetNewInstance(string Title)
        {
            CallType _Instance = new CallType();
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "CallType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, CallType NewInstance)
        {
            DataContext.GetTable<CallType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(CallType OriginalInstance, CallType NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, CallType OriginalInstance)
        {
            DataContext.GetTable<CallType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class CompressionType
    {
        public static CompressionType GetNewInstance(int Code, string Title)
        {
            CompressionType _Instance = new CompressionType();
            _Instance.Code = Code;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "CompressionType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, CompressionType NewInstance)
        {
            DataContext.GetTable<CompressionType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(CompressionType OriginalInstance, CompressionType NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, CompressionType OriginalInstance)
        {
            DataContext.GetTable<CompressionType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Contact
    {
        public static Contact GetNewInstance(long ID, string PersonnelNumber, int CallTypeID, string Number, string Comment)
        {
            Contact _Instance = new Contact();
            _Instance.ID = ID;
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.CallTypeID = CallTypeID;
            _Instance.Number = Number;
            _Instance.Comment = Comment;
            return _Instance;
        }
        public static Contact GetNewInstance(string PersonnelNumber, int CallTypeID, string Number, string Comment)
        {
            Contact _Instance = new Contact();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.CallTypeID = CallTypeID;
            _Instance.Number = Number;
            _Instance.Comment = Comment;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Contact";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Contact NewInstance)
        {
            DataContext.GetTable<Contact>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Contact OriginalInstance, Contact NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.CallTypeID = NewInstance.CallTypeID;
            OriginalInstance.Number = NewInstance.Number;
            OriginalInstance.Comment = NewInstance.Comment;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Contact OriginalInstance)
        {
            DataContext.GetTable<Contact>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class CounterFieldSetting
    {
        public static CounterFieldSetting GetNewInstance(int ID, int ArchiveFieldID, int FixedValueType, string FixedValue, string Separator)
        {
            CounterFieldSetting _Instance = new CounterFieldSetting();
            _Instance.ID = ID;
            _Instance.ArchiveFieldID = ArchiveFieldID;
            _Instance.FixedValueType = FixedValueType;
            _Instance.FixedValue = FixedValue;
            _Instance.Separator = Separator;
            return _Instance;
        }
        public static CounterFieldSetting GetNewInstance(int ArchiveFieldID, int FixedValueType, string FixedValue, string Separator)
        {
            CounterFieldSetting _Instance = new CounterFieldSetting();
            _Instance.ArchiveFieldID = ArchiveFieldID;
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
            OriginalInstance.ArchiveFieldID = NewInstance.ArchiveFieldID;
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
    public partial class DisplayField
    {
        public static DisplayField GetNewInstance(int ID, int Code, System.Nullable<int> ReportID, int ArchiveFieldID)
        {
            DisplayField _Instance = new DisplayField();
            _Instance.ID = ID;
            _Instance.Code = Code;
            _Instance.ReportID = ReportID;
            _Instance.ArchiveFieldID = ArchiveFieldID;
            return _Instance;
        }
        public static DisplayField GetNewInstance(int Code, System.Nullable<int> ReportID, int ArchiveFieldID)
        {
            DisplayField _Instance = new DisplayField();
            _Instance.Code = Code;
            _Instance.ReportID = ReportID;
            _Instance.ArchiveFieldID = ArchiveFieldID;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "DisplayField";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, DisplayField NewInstance)
        {
            DataContext.GetTable<DisplayField>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(DisplayField OriginalInstance, DisplayField NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.ReportID = NewInstance.ReportID;
            OriginalInstance.ArchiveFieldID = NewInstance.ArchiveFieldID;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, DisplayField OriginalInstance)
        {
            DataContext.GetTable<DisplayField>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class DisplayFieldCode
    {
        public static DisplayFieldCode GetNewInstance(int Code, string Title)
        {
            DisplayFieldCode _Instance = new DisplayFieldCode();
            _Instance.Code = Code;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "DisplayFieldCode";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, DisplayFieldCode NewInstance)
        {
            DataContext.GetTable<DisplayFieldCode>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(DisplayFieldCode OriginalInstance, DisplayFieldCode NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, DisplayFieldCode OriginalInstance)
        {
            DataContext.GetTable<DisplayFieldCode>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Document
    {
        public static Document GetNewInstance(int ID, string PersonnelNumber, string Number, string FileName, System.Nullable<int> ArchiveTabID, bool AttachedToDossier, System.Nullable<int> ParentDocumentID, int Index)
        {
            Document _Instance = new Document();
            _Instance.ID = ID;
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.Number = Number;
            _Instance.FileName = FileName;
            _Instance.ArchiveTabID = ArchiveTabID;
            _Instance.AttachedToDossier = AttachedToDossier;
            _Instance.ParentDocumentID = ParentDocumentID;
            _Instance.Index = Index;
            return _Instance;
        }
        public static Document GetNewInstance(string PersonnelNumber, string Number, string FileName, System.Nullable<int> ArchiveTabID, bool AttachedToDossier, System.Nullable<int> ParentDocumentID, int Index)
        {
            Document _Instance = new Document();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.Number = Number;
            _Instance.FileName = FileName;
            _Instance.ArchiveTabID = ArchiveTabID;
            _Instance.AttachedToDossier = AttachedToDossier;
            _Instance.ParentDocumentID = ParentDocumentID;
            _Instance.Index = Index;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Document";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Document NewInstance)
        {
            DataContext.GetTable<Document>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Document OriginalInstance, Document NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.Number = NewInstance.Number;
            OriginalInstance.FileName = NewInstance.FileName;
            OriginalInstance.ArchiveTabID = NewInstance.ArchiveTabID;
            OriginalInstance.AttachedToDossier = NewInstance.AttachedToDossier;
            OriginalInstance.ParentDocumentID = NewInstance.ParentDocumentID;
            OriginalInstance.Index = NewInstance.Index;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Document OriginalInstance)
        {
            DataContext.GetTable<Document>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class DocumentSaveLocation
    {
        public static DocumentSaveLocation GetNewInstance(int ID, string Title, string DatabaseNameOrFilesPath, bool IsActive)
        {
            DocumentSaveLocation _Instance = new DocumentSaveLocation();
            _Instance.ID = ID;
            _Instance.Title = Title;
            _Instance.DatabaseNameOrFilesPath = DatabaseNameOrFilesPath;
            _Instance.IsActive = IsActive;
            return _Instance;
        }
        public static DocumentSaveLocation GetNewInstance(string Title, string DatabaseNameOrFilesPath, bool IsActive)
        {
            DocumentSaveLocation _Instance = new DocumentSaveLocation();
            _Instance.Title = Title;
            _Instance.DatabaseNameOrFilesPath = DatabaseNameOrFilesPath;
            _Instance.IsActive = IsActive;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "DocumentSaveLocation";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, DocumentSaveLocation NewInstance)
        {
            DataContext.GetTable<DocumentSaveLocation>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(DocumentSaveLocation OriginalInstance, DocumentSaveLocation NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.DatabaseNameOrFilesPath = NewInstance.DatabaseNameOrFilesPath;
            OriginalInstance.IsActive = NewInstance.IsActive;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, DocumentSaveLocation OriginalInstance)
        {
            DataContext.GetTable<DocumentSaveLocation>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Dossier
    {
        public static Dossier GetNewInstance(string PersonnelNumber, System.Data.Linq.Binary PersonnelImage, string FilesPathOrDatabaseName, int DossierSecurityID)
        {
            Dossier _Instance = new Dossier();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.PersonnelImage = PersonnelImage;
            _Instance.FilesPathOrDatabaseName = FilesPathOrDatabaseName;
            _Instance.DossierSecurityID = DossierSecurityID;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Dossier";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Dossier NewInstance)
        {
            DataContext.GetTable<Dossier>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Dossier OriginalInstance, Dossier NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.PersonnelImage = NewInstance.PersonnelImage;
            OriginalInstance.FilesPathOrDatabaseName = NewInstance.FilesPathOrDatabaseName;
            OriginalInstance.DossierSecurityID = NewInstance.DossierSecurityID;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Dossier OriginalInstance)
        {
            DataContext.GetTable<Dossier>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Dossier1
    {
        public static Dossier1 GetNewInstance(string PersonnelNumber, System.Nullable<int> Field1, System.Nullable<int> Field2)
        {
            Dossier1 _Instance = new Dossier1();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.Field1 = Field1;
            _Instance.Field2 = Field2;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Dossier1";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Dossier1 NewInstance)
        {
            DataContext.GetTable<Dossier1>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Dossier1 OriginalInstance, Dossier1 NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.Field1 = NewInstance.Field1;
            OriginalInstance.Field2 = NewInstance.Field2;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Dossier1 OriginalInstance)
        {
            DataContext.GetTable<Dossier1>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class DossierType
    {
        public static DossierType GetNewInstance(int ID, string Title, System.Nullable<bool> IsDefault)
        {
            DossierType _Instance = new DossierType();
            _Instance.ID = ID;
            _Instance.Title = Title;
            _Instance.IsDefault = IsDefault;
            return _Instance;
        }
        public static DossierType GetNewInstance(string Title, System.Nullable<bool> IsDefault)
        {
            DossierType _Instance = new DossierType();
            _Instance.Title = Title;
            _Instance.IsDefault = IsDefault;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "DossierType";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, DossierType NewInstance)
        {
            DataContext.GetTable<DossierType>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(DossierType OriginalInstance, DossierType NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
            OriginalInstance.IsDefault = NewInstance.IsDefault;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, DossierType OriginalInstance)
        {
            DataContext.GetTable<DossierType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Field_1_3
    {
        public static Field_1_3 GetNewInstance(int ID, string PersonnelNumber, System.Nullable<int> Field_1_3_1, System.Nullable<int> Field_1_3_2)
        {
            Field_1_3 _Instance = new Field_1_3();
            _Instance.ID = ID;
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.Field_1_3_1 = Field_1_3_1;
            _Instance.Field_1_3_2 = Field_1_3_2;
            return _Instance;
        }
        public static Field_1_3 GetNewInstance(string PersonnelNumber, System.Nullable<int> Field_1_3_1, System.Nullable<int> Field_1_3_2)
        {
            Field_1_3 _Instance = new Field_1_3();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.Field_1_3_1 = Field_1_3_1;
            _Instance.Field_1_3_2 = Field_1_3_2;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Field_1_3";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Field_1_3 NewInstance)
        {
            DataContext.GetTable<Field_1_3>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Field_1_3 OriginalInstance, Field_1_3 NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.Field_1_3_1 = NewInstance.Field_1_3_1;
            OriginalInstance.Field_1_3_2 = NewInstance.Field_1_3_2;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Field_1_3 OriginalInstance)
        {
            DataContext.GetTable<Field_1_3>().DeleteOnSubmit(OriginalInstance);
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
        public static FieldType GetNewInstance(int Code, string Title)
        {
            FieldType _Instance = new FieldType();
            _Instance.Code = Code;
            _Instance.Title = Title;
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
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, FieldType OriginalInstance)
        {
            DataContext.GetTable<FieldType>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ImageFormat
    {
        public static ImageFormat GetNewInstance(int Code, string Title)
        {
            ImageFormat _Instance = new ImageFormat();
            _Instance.Code = Code;
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ImageFormat";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ImageFormat NewInstance)
        {
            DataContext.GetTable<ImageFormat>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ImageFormat OriginalInstance, ImageFormat NewInstance)
        {
            OriginalInstance.Code = NewInstance.Code;
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ImageFormat OriginalInstance)
        {
            DataContext.GetTable<ImageFormat>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Info
    {
        public static Info GetNewInstance(int ID, string PersonnelNumber, string Comment, string Email, string Website)
        {
            Info _Instance = new Info();
            _Instance.ID = ID;
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.Comment = Comment;
            _Instance.Email = Email;
            _Instance.Website = Website;
            return _Instance;
        }
        public static Info GetNewInstance(string PersonnelNumber, string Comment, string Email, string Website)
        {
            Info _Instance = new Info();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.Comment = Comment;
            _Instance.Email = Email;
            _Instance.Website = Website;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Info";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Info NewInstance)
        {
            DataContext.GetTable<Info>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Info OriginalInstance, Info NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.Comment = NewInstance.Comment;
            OriginalInstance.Email = NewInstance.Email;
            OriginalInstance.Website = NewInstance.Website;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Info OriginalInstance)
        {
            DataContext.GetTable<Info>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class LegalPerson
    {
        public static LegalPerson GetNewInstance(int Id, string Name, string CompanyNumber, string EconomicNumber, string Address, string Tel, string Manager, string ManagerTel)
        {
            LegalPerson _Instance = new LegalPerson();
            _Instance.Id = Id;
            _Instance.Name = Name;
            _Instance.CompanyNumber = CompanyNumber;
            _Instance.EconomicNumber = EconomicNumber;
            _Instance.Address = Address;
            _Instance.Tel = Tel;
            _Instance.Manager = Manager;
            _Instance.ManagerTel = ManagerTel;
            return _Instance;
        }
        public static LegalPerson GetNewInstance(string Name, string CompanyNumber, string EconomicNumber, string Address, string Tel, string Manager, string ManagerTel)
        {
            LegalPerson _Instance = new LegalPerson();
            _Instance.Name = Name;
            _Instance.CompanyNumber = CompanyNumber;
            _Instance.EconomicNumber = EconomicNumber;
            _Instance.Address = Address;
            _Instance.Tel = Tel;
            _Instance.Manager = Manager;
            _Instance.ManagerTel = ManagerTel;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "LegalPerson";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, LegalPerson NewInstance)
        {
            DataContext.GetTable<LegalPerson>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(LegalPerson OriginalInstance, LegalPerson NewInstance)
        {
            OriginalInstance.Name = NewInstance.Name;
            OriginalInstance.CompanyNumber = NewInstance.CompanyNumber;
            OriginalInstance.EconomicNumber = NewInstance.EconomicNumber;
            OriginalInstance.Address = NewInstance.Address;
            OriginalInstance.Tel = NewInstance.Tel;
            OriginalInstance.Manager = NewInstance.Manager;
            OriginalInstance.ManagerTel = NewInstance.ManagerTel;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, LegalPerson OriginalInstance)
        {
            DataContext.GetTable<LegalPerson>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Lending
    {
        public static Lending GetNewInstance(int ID, string PersonnelNumber, int PersonID, string Intention, string Date, string Time, int DurationDay, int DurationHour, string ReturnDate, string ReturnTime, System.Nullable<int> RealDurationDay, System.Nullable<int> RealDurationHour,string PersonSender)
        {
            Lending _Instance = new Lending();
            _Instance.ID = ID;
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.PersonID = PersonID;
            _Instance.Intention = Intention;
            _Instance.Date = Date;
            _Instance.Time = Time;
            _Instance.DurationDay = DurationDay;
            _Instance.DurationHour = DurationHour;
            _Instance.ReturnDate = ReturnDate;
            _Instance.ReturnTime = ReturnTime;
            _Instance.RealDurationDay = RealDurationDay;
            _Instance.RealDurationHour = RealDurationHour;
            _Instance.PersonSender = PersonSender;
            return _Instance;
        }
        public static Lending GetNewInstance(string PersonnelNumber, int PersonID, string Intention, string Date, string Time, int DurationDay, int DurationHour, string ReturnDate, string ReturnTime, System.Nullable<int> RealDurationDay, System.Nullable<int> RealDurationHour, string PersonSender)
        {
            Lending _Instance = new Lending();
            _Instance.PersonnelNumber = PersonnelNumber;
            _Instance.PersonID = PersonID;
            _Instance.Intention = Intention;
            _Instance.Date = Date;
            _Instance.Time = Time;
            _Instance.DurationDay = DurationDay;
            _Instance.DurationHour = DurationHour;
            _Instance.ReturnDate = ReturnDate;
            _Instance.ReturnTime = ReturnTime;
            _Instance.RealDurationDay = RealDurationDay;
            _Instance.RealDurationHour = RealDurationHour;
            _Instance.PersonSender = PersonSender;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Lending";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Lending NewInstance)
        {
            DataContext.GetTable<Lending>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Lending OriginalInstance, Lending NewInstance)
        {
            OriginalInstance.PersonnelNumber = NewInstance.PersonnelNumber;
            OriginalInstance.PersonID = NewInstance.PersonID;
            OriginalInstance.Intention = NewInstance.Intention;
            OriginalInstance.Date = NewInstance.Date;
            OriginalInstance.Time = NewInstance.Time;
            OriginalInstance.DurationDay = NewInstance.DurationDay;
            OriginalInstance.DurationHour = NewInstance.DurationHour;
            OriginalInstance.ReturnDate = NewInstance.ReturnDate;
            OriginalInstance.ReturnTime = NewInstance.ReturnTime;
            OriginalInstance.RealDurationDay = NewInstance.RealDurationDay;
            OriginalInstance.RealDurationHour = NewInstance.RealDurationHour;
            OriginalInstance.PersonSender = NewInstance.PersonSender;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Lending OriginalInstance)
        {
            DataContext.GetTable<Lending>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class LendingIntention
    {
        public static LendingIntention GetNewInstance(int ID, string Title)
        {
            LendingIntention _Instance = new LendingIntention();
            _Instance.ID = ID;
            _Instance.Title = Title;
            return _Instance;
        }
        public static LendingIntention GetNewInstance(string Title)
        {
            LendingIntention _Instance = new LendingIntention();
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "LendingIntention";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, LendingIntention NewInstance)
        {
            DataContext.GetTable<LendingIntention>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(LendingIntention OriginalInstance, LendingIntention NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, LendingIntention OriginalInstance)
        {
            DataContext.GetTable<LendingIntention>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class MetropolitanArea
    {
        public static MetropolitanArea GetNewInstance(int ID, string Title)
        {
            MetropolitanArea _Instance = new MetropolitanArea();
            _Instance.ID = ID;
            _Instance.Title = Title;
            return _Instance;
        }
        public static MetropolitanArea GetNewInstance(string Title)
        {
            MetropolitanArea _Instance = new MetropolitanArea();
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "MetropolitanArea";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, MetropolitanArea NewInstance)
        {
            DataContext.GetTable<MetropolitanArea>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(MetropolitanArea OriginalInstance, MetropolitanArea NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, MetropolitanArea OriginalInstance)
        {
            DataContext.GetTable<MetropolitanArea>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Person
    {
        public static Person GetNewInstance(int ID, string Name)
        {
            Person _Instance = new Person();
            _Instance.ID = ID;
            _Instance.Name = Name;
            return _Instance;
        }
        public static Person GetNewInstance(string Name)
        {
            Person _Instance = new Person();
            _Instance.Name = Name;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Person";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Person NewInstance)
        {
            DataContext.GetTable<Person>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Person OriginalInstance, Person NewInstance)
        {
            OriginalInstance.Name = NewInstance.Name;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Person OriginalInstance)
        {
            DataContext.GetTable<Person>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Province
    {
        public static Province GetNewInstance(int ID, string Title)
        {
            Province _Instance = new Province();
            _Instance.ID = ID;
            _Instance.Title = Title;
            return _Instance;
        }
        public static Province GetNewInstance(string Title)
        {
            Province _Instance = new Province();
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Province";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Province NewInstance)
        {
            DataContext.GetTable<Province>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Province OriginalInstance, Province NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Province OriginalInstance)
        {
            DataContext.GetTable<Province>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class Report
    {
        public static Report GetNewInstance(int ID, string Title)
        {
            Report _Instance = new Report();
            _Instance.ID = ID;
            _Instance.Title = Title;
            return _Instance;
        }
        public static Report GetNewInstance(string Title)
        {
            Report _Instance = new Report();
            _Instance.Title = Title;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "Report";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, Report NewInstance)
        {
            DataContext.GetTable<Report>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(Report OriginalInstance, Report NewInstance)
        {
            OriginalInstance.Title = NewInstance.Title;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, Report OriginalInstance)
        {
            DataContext.GetTable<Report>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class ReportDetail
    {
        public static ReportDetail GetNewInstance(int ID, System.Nullable<int> ReportID, int ArchiveFieldID, int RelationCode, int MethodCode, string Value, System.Nullable<int> ParentID)
        {
            ReportDetail _Instance = new ReportDetail();
            _Instance.ID = ID;
            _Instance.ReportID = ReportID;
            _Instance.ArchiveFieldID = ArchiveFieldID;
            _Instance.RelationCode = RelationCode;
            _Instance.MethodCode = MethodCode;
            _Instance.Value = Value;
            _Instance.ParentID = ParentID;
            return _Instance;
        }
        public static ReportDetail GetNewInstance(System.Nullable<int> ReportID, int ArchiveFieldID, int RelationCode, int MethodCode, string Value, System.Nullable<int> ParentID)
        {
            ReportDetail _Instance = new ReportDetail();
            _Instance.ReportID = ReportID;
            _Instance.ArchiveFieldID = ArchiveFieldID;
            _Instance.RelationCode = RelationCode;
            _Instance.MethodCode = MethodCode;
            _Instance.Value = Value;
            _Instance.ParentID = ParentID;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "ReportDetail";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, ReportDetail NewInstance)
        {
            DataContext.GetTable<ReportDetail>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(ReportDetail OriginalInstance, ReportDetail NewInstance)
        {
            OriginalInstance.ReportID = NewInstance.ReportID;
            OriginalInstance.ArchiveFieldID = NewInstance.ArchiveFieldID;
            OriginalInstance.RelationCode = NewInstance.RelationCode;
            OriginalInstance.MethodCode = NewInstance.MethodCode;
            OriginalInstance.Value = NewInstance.Value;
            OriginalInstance.ParentID = NewInstance.ParentID;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, ReportDetail OriginalInstance)
        {
            DataContext.GetTable<ReportDetail>().DeleteOnSubmit(OriginalInstance);
        }
    }
    public partial class RightfulPerson
    {
        public static RightfulPerson GetNewInstance(int Id, string Firstname, string Lastname, string Fathername, string NationalCode, string IdentityNumber, string Birthdate, string Address, string Tel, string Mobile, string WorkAddress, string BackAccount)
        {
            RightfulPerson _Instance = new RightfulPerson();
            _Instance.Id = Id;
            _Instance.Firstname = Firstname;
            _Instance.Lastname = Lastname;
            _Instance.Fathername = Fathername;
            _Instance.NationalCode = NationalCode;
            _Instance.IdentityNumber = IdentityNumber;
            _Instance.Birthdate = Birthdate;
            _Instance.Address = Address;
            _Instance.Tel = Tel;
            _Instance.Mobile = Mobile;
            _Instance.WorkAddress = WorkAddress;
            _Instance.BackAccount = BackAccount;
            return _Instance;
        }
        public static RightfulPerson GetNewInstance(string Firstname, string Lastname, string Fathername, string NationalCode, string IdentityNumber, string Birthdate, string Address, string Tel, string Mobile, string WorkAddress, string BackAccount)
        {
            RightfulPerson _Instance = new RightfulPerson();
            _Instance.Firstname = Firstname;
            _Instance.Lastname = Lastname;
            _Instance.Fathername = Fathername;
            _Instance.NationalCode = NationalCode;
            _Instance.IdentityNumber = IdentityNumber;
            _Instance.Birthdate = Birthdate;
            _Instance.Address = Address;
            _Instance.Tel = Tel;
            _Instance.Mobile = Mobile;
            _Instance.WorkAddress = WorkAddress;
            _Instance.BackAccount = BackAccount;
            return _Instance;
        }
        public static string GetTableName()
        {
            return "RightfulPerson";
        }
        public static void Insert(System.Data.Linq.DataContext DataContext, RightfulPerson NewInstance)
        {
            DataContext.GetTable<RightfulPerson>().InsertOnSubmit(NewInstance);
        }
        public static void Copy(RightfulPerson OriginalInstance, RightfulPerson NewInstance)
        {
            OriginalInstance.Firstname = NewInstance.Firstname;
            OriginalInstance.Lastname = NewInstance.Lastname;
            OriginalInstance.Fathername = NewInstance.Fathername;
            OriginalInstance.NationalCode = NewInstance.NationalCode;
            OriginalInstance.IdentityNumber = NewInstance.IdentityNumber;
            OriginalInstance.Birthdate = NewInstance.Birthdate;
            OriginalInstance.Address = NewInstance.Address;
            OriginalInstance.Tel = NewInstance.Tel;
            OriginalInstance.Mobile = NewInstance.Mobile;
            OriginalInstance.WorkAddress = NewInstance.WorkAddress;
            OriginalInstance.BackAccount = NewInstance.BackAccount;
        }
        public static void Delete(System.Data.Linq.DataContext DataContext, RightfulPerson OriginalInstance)
        {
            DataContext.GetTable<RightfulPerson>().DeleteOnSubmit(OriginalInstance);
        }
    }
}
