namespace Njit.Program.Model
{
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
}
