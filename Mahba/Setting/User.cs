using Njit.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.Setting
{
    public class User : Njit.Program.Setting.UserSetting
    {
        private static User _ThisProgram;
        public static User ThisProgram
        {
            get
            {
                if (_ThisProgram == null)
                    _ThisProgram = new User();
                return _ThisProgram;
            }
        }

        public enum UserRoles
        {
            Administrator = 1,
            User = 2,
            Expert = 3
        }

        public enum UserOparatesNames : short
        {
            ورود_به_سیستم = 1,
            ثبت = 2,
            ویرایش = 3,
            حذف = 4,
            چاپ = 5,
            تنظیمات = 6,
            خروج_کاربر = 7,
            خروج_از_برنامه = 8,
            افزودن = 9,
            پشتیبان_گیری_از_اسناد = 10,
            ذخیره = 11,
            اضافه_کردن_اطلاعات_سند = 12,
            چاپ_سند = 13,
            ذخیره_سند = 14,
            مشاهده_سند = 15,
            مشاهده_اسناد = 16,
            حذف_سند = 17,
            مشاهده_پرونده = 18,
            کپی_سند = 19,
            انتقال_سند = 20,
            چرخش_به_چپ=21,
            چرخش_به_راست=22,
            افزایش_روشنایی=23,
            کاهش_روشنایی=24,
            افزایش_کنتراست=25,
            کاهش_کنتراست=26,
            اضافه_کردن_سند_به_پرونده=27,
            تغییر_شماره_پرونده=28,
            ویرایش_اطلاعات_سند = 29,
        }

        public enum UserOparatesPlaceNames : short
        {
            None = 0,
            پرونده = 1,
            سند = 2,
            گروه_اطلاعاتی_پرونده = 3,
            گروه_اطلاعاتی_سند = 4,
            امانت = 5,
            بازگشت_امانت = 6,
            بایگانی = 7,
            گروه_بایگانی = 8,
            کاربران = 9,
            تغییر_رمز_عبور = 10,
            سطح_دسترسی = 11,
            تغییر_شماره_پرسنلی = 12,
            لاگیری_سند_و_پرونده = 13,
    

        }

        private Model.Common.UserSetting _LoadedUserSetting;
        public Model.Common.UserSetting LoadedUserSetting
        {
            get
            {
                if (_LoadedUserSetting == null)
                    Load();
                return _LoadedUserSetting;
            }
        }

        public void Load()
        {
            var dc = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
            Model.Common.User currentUser = this.GetCurrentUser<Model.Common.User>();
            if (currentUser != null)
            {
                if (dc.UserSettings.Where(t => t.UserCode == currentUser.Code).Count() > 0)
                    _LoadedUserSetting = dc.UserSettings.Where(t => t.UserCode == currentUser.Code).First();
                else
                    _LoadedUserSetting = GetDefaultUserSetting();
            }
            else
                _LoadedUserSetting = GetDefaultUserSetting();
        }

        private Model.Common.UserSetting GetDefaultUserSetting()
        {
            Model.Common.User currentUser = this.GetCurrentUser<Model.Common.User>();
            return Model.Common.UserSetting.GetNewInstance(currentUser == null ? -1 : currentUser.Code, 200);
        }

        public void SaveAndReload()
        {
            SaveAndReload(this.LoadedUserSetting);
        }

        public void SaveAndReload(NjitSoftware.Model.Common.UserSetting instance)
        {
            try
            {
                var dc = NjitSoftware.Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
                Model.Common.User currentUser = this.GetCurrentUser<Model.Common.User>();
                var query = dc.UserSettings.Where(t => t.UserCode == currentUser.Code).Select(t => t);
                if (query.Count() > 0)
                {
                    NjitSoftware.Model.Common.UserSetting original = query.First();
                    NjitSoftware.Model.Common.UserSetting.Copy(original, instance);
                }
                else
                {
                    NjitSoftware.Model.Common.UserSetting.Insert(dc, instance);
                }
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در ذخیره تنظیمات" + "\r\n\r\n" + ex.Message);
            }
            Load();
        }

        public void AddLog(UserOparatesPlaceNames operatingPlaceCode, UserOparatesNames operatingCode, string code, string description)
        {
            using (Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString))
            {
                AddLog(dc, operatingPlaceCode, operatingCode, code, description);
            }
        }

        public void AddLog(Model.Common.ArchiveCommonDataClassesDataContext dc, UserOparatesPlaceNames operatingPlaceCode, UserOparatesNames operatingCode, string code, string description)
        {
            int userCode = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code;

            var des = GetUserLogCryptoService(userCode);

            string code_encrypted = ((code == null) ? null : des.EncryptToBase64(code));
            string operatingPlaceCode_encrypted = ((operatingPlaceCode == UserOparatesPlaceNames.None) ? null : des.EncryptToBase64(((short)operatingPlaceCode).ToString()));
            string operatingCode_encrypted = des.EncryptToBase64(((short)operatingCode).ToString());
            string sysdate_encrypted = des.EncryptToBase64(DataAccess.CommonDataAccess.GetNewInstance().Connection.GetServerPersianDate());
            string systime_encrypted = des.EncryptToBase64(DataAccess.CommonDataAccess.GetNewInstance().Connection.GetServerTime());
            string description_encrypted = ((description == null) ? null : des.EncryptToBase64(description));

            Model.Common.UserLog userlog = Model.Common.UserLog.GetNewInstance(userCode, operatingPlaceCode_encrypted, operatingCode_encrypted, code_encrypted, description_encrypted, sysdate_encrypted, systime_encrypted, Setting.Archive.ThisProgram.SelectedArchiveTree == null ? null : (int?)Setting.Archive.ThisProgram.SelectedArchiveTree.Archive.ID, Setting.Program.GetMacAddress().ToString());
            Model.Common.UserLog.Insert(dc, userlog);
            dc.SubmitChanges();

            ProgramEvents.OnUserLogsChanged();
        }

        public override bool Authenticate(int userID, string password)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var memberships = dc.Users.Where(t => t.Code == userID);
            if (memberships.Count() != 1)
                return false;
            Model.Common.User member = memberships.Single();
            return member.Password == this.HashData(member.Code.ToString() + password) && member.StateCode == this.HashData(member.Code.ToString() + ((int)UserStates.Active).ToString());
        }

        public override bool Authenticate(string username, string password)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var memberships = dc.Users.Where(t => t.UserName == username);
            if (memberships.Count() != 1)
                return false;
            Model.Common.User member = memberships.Single();
            return member.Password == this.HashData(member.Code.ToString() + password) && member.StateCode == this.HashData(member.Code.ToString() + ((int)UserStates.Active).ToString());
        }

        internal bool IsMembershipActive(Model.Common.User membership)
        {
            string activeCode = this.HashData(membership.Code.ToString() + ((int)Setting.User.UserStates.Active).ToString());
            return membership.StateCode == activeCode;
        }

        internal bool IsMembershipActiveAndVisible(Model.Common.User membership)
        {
            string activeCode = this.HashData(membership.Code.ToString() + ((int)Setting.User.UserStates.Active).ToString());
            string visibleCode = this.HashData(membership.Code.ToString() + true.ToString());
            return membership.StateCode == activeCode && membership.Visible == visibleCode;
        }

        internal bool IsMembershipInAdministartorRole(Model.Common.User membership)
        {
            string roleCode = this.HashData(membership.Code.ToString() + (1).ToString());
            return membership.RoleCode == roleCode;
        }

        internal int GetMembershipRoleCode(Model.Common.User membership)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var roleCodes = dc.UserRoles.Select(t => t.ID);
            foreach (var item in roleCodes)
            {
                string roleHashCode = this.HashData(membership.Code.ToString() + item.ToString());
                if (membership.RoleCode == roleHashCode)
                    return item;
            }
            throw new Exception("نقش کاربر نا معتبر است");
        }

        internal int GetMembershipStateCode(Model.Common.User membership)
        {
            string activeCode = this.HashData(membership.Code.ToString() + ((int)Setting.User.UserStates.Active).ToString());
            string inactiveCode = this.HashData(membership.Code.ToString() + ((int)Setting.User.UserStates.Inactive).ToString());
            if (membership.StateCode == activeCode)
                return ((int)Setting.User.UserStates.Active);
            if (membership.StateCode == inactiveCode)
                return ((int)Setting.User.UserStates.Inactive);
            return ((int)Setting.User.UserStates.Inactive);
        }

        public override bool Login()
        {
            List<string> list = new List<string>();
            list.Add(View.Main.Instance.Name);
            if (!View.SplashScreen.InstanceIsNull)
                list.Add(View.SplashScreen.Instance.Name);
            //list.Add(UI.SelectArchive.Instance.Name);
            this.CloseForms(list.ToArray());
            System.Windows.Forms.DialogResult result;
            using (View.Login login = new View.Login())
            {
                result = login.ShowDialog();
            }
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
                Model.Common.User membership = dc.Users.Where(t => t.Code == Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>().Code).Single();
                membership.LastLogin = DateTime.Now;
                if (membership.isGuest)
                {
                    try
                    {
                        DateTime Expire = Convert.ToDateTime(membership.Expire);
                        DateTime Today = ConvertTo_PersianOREnglish_Date.GetEglishDate(DataAccess.CommonDataAccess.GetNewInstance().Connection.GetServerPersianDate());
                        if (Today >= Expire)
                        {
                            membership.Visible = Options.SettingInitializer.GetUserSetting().HashData(membership.Code.ToString() + (int)Njit.Program.Setting.UserSetting.UserStates.Inactive);
                            dc.SubmitChanges();
                            MessageBox.Show("تاریخ انقضا پنل کاربری شما به اتمام رسیده است.");
                            Logout();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("تاریخ انقضا پنل کاربری شما در سیستم درست وارد نشده است. به مدیر سیستم اطلاع داده تا تاریخ انقضا پنل کاربریتان را تغییر بدهد. ");
                    }

                }
                //اگر ادمین باشد نیازی نیست
                if (!Setting.User.ThisProgram.IsMembershipInAdministartorRole(Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>()))
                {

                    if (membership.isLogin == true && membership.IPAddress==null)
                    {
                        MessageBox.Show(" با اطلاعات وارد شده یک کاربر دیگر وجود دارد در غیر اینصورت از مدیر سیستم بخواهید تا اطلاعات شما را ویرایش کند.");
                        Logout();
                    }

                    if (membership.isLogin == true && membership.IPAddress != Setting.Program.GetMacAddress().ToString())
                        {
                            MessageBox.Show(" با اطلاعات وارد شده یک کاربر دیگر وجود دارد در غیر اینصورت از مدیر سیستم بخواهید تا اطلاعات شما را ویرایش کند.");
                            Logout();
                        }
                    
                }

                membership.IPAddress = Setting.Program.GetMacAddress().ToString();
                membership.isLogin = true;
                dc.SubmitChanges();

                AddLog(dc, UserOparatesPlaceNames.None, UserOparatesNames.ورود_به_سیستم, null, null);

                if (View.SelectArchive.Instance.Visible == false)
                    View.SelectArchive.Instance.Show(View.Main.Instance);
                this.Load();

                //View.Main.Instance.StartCheckLock();

                return true;
            }
            return false;
        }

        public override bool Logout()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            AddLog(dc, UserOparatesPlaceNames.None, UserOparatesNames.خروج_کاربر, null, null);
            Setting.User.ThisProgram.SetCurrentUser<Model.Common.User>(null);
            Setting.Archive.ThisProgram.SelectedArchiveTree = null;
            return Login();
        }

        internal string GetRoleCodeHash(Model.Common.User member, int roleCode)
        {
            return this.HashData(member.Code.ToString() + roleCode.ToString());
        }

        internal string GetRoleCodeHash(int userCode, int roleCode)
        {
            return this.HashData(userCode.ToString() + roleCode.ToString());
        }

        internal string GetStateCodeHash(Model.Common.User member, int stateCode)
        {
            return this.HashData(member.Code.ToString() + stateCode.ToString());
        }

        internal string GetStateCodeHash(int userCode, int stateCode)
        {
            return this.HashData(userCode.ToString() + stateCode.ToString());
        }

        public enum AccessPermissionUnits
        {
            Archive,
            DossierType
        }

        public bool CheckUserAccessPermission(AccessPermissionUnits unit, string value)
        {
            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser == null)
                return true;
            if (IsMembershipInAdministartorRole(currentUser))
                return true;
            return this.CheckUserAccessPermission(currentUser, value, GetAccessPermissionUnitGroupName(unit));
        }

        public string GetAccessPermissionUnitGroupName(AccessPermissionUnits unit)
        {
            return "AccessPermissionUnits" + "->" + unit.ToString();
        }

        public override bool CheckUserAccessPermission(System.Windows.Forms.Control control)
        {
            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser == null)
                return true;
            if (IsMembershipInAdministartorRole(currentUser))
                return true;
            if (!(control.TopLevelControl is System.Windows.Forms.Form))
                return true;
            System.Windows.Forms.Form form = (control is System.Windows.Forms.Form) ? null : control.FindForm();
            if (form is View.Main)
                return true;
            if (control is View.Login)
                return true;
            if (control is View.Main)
                return true;
            //اینها اگر فالس باشد فقط ادمین می تواند به آن دسترسی داشته باشد
            //if (control is View.DossierDocumentsManage2)
            //    return true;
            //if (control is View.UserManageForms.ChangePassword)
            //    return true;
            //if (control is Njit.Program.Forms.PopupForm)
            //    return true;
            //if (control is View.UserManageForms.AddUser)
            //    return true;
            //if (control is View.UserManageForms.UserList)
            //    return true;
            //if (control is View.UserManageForms.UserRoleAddEdit)
            //    return true;
            //if (control is View.UserManageForms.UserRoleList)
            //    return true;
            //if (control is View.UserManageForms.SetPermission)
            //    return true;
            //if (control is View.UserManageForms.UserLog)
            //    return true;
            if (form != null && control is System.Windows.Forms.Button)
            {
                if (form.CancelButton == (control as System.Windows.Forms.Button))
                    return true;
            }
            return this.CheckUserAccessPermission(currentUser, (control as Njit.Common.IAccessPermission).GetPath(), form != null ? form.Name : null);
        }

        public override bool CheckUserAccessPermission(System.ComponentModel.Component component)
        {
            Model.Common.User currentUser = Setting.User.ThisProgram.GetCurrentUser<Model.Common.User>();
            if (currentUser == null)
                return true;
            if (IsMembershipInAdministartorRole(currentUser))
                return true;
            if (component is Njit.Program.ComponentOne.Controls.RibbonButton)
            {
                Njit.Program.ComponentOne.Controls.RibbonButton button = component as Njit.Program.ComponentOne.Controls.RibbonButton;
                if (button.OwnerControl == null)
                    return true;
                System.Windows.Forms.Form form = button.OwnerControl.FindForm();
                if (form == null)
                    return true;
                return this.CheckUserAccessPermission(currentUser, (button as Njit.Common.IAccessPermission).GetPath(), form.Name);
            }
            else
                return true;
        }

        public bool CheckUserAccessPermission(Model.Common.User membership, string item, string group)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);

            int roleCode = GetMembershipRoleCode(membership);

            IQueryable<Model.Common.AccessPermissionTree> trees;
            if (group != null)
                trees = dc.AccessPermissionTrees.Where(t => t.Item == item && t.Group == group);
            else
                trees = dc.AccessPermissionTrees.Where(t => t.Item == item);
            if (trees.Count() != 1)
                return false;
            var accessPermissionTree = trees.Single();

            Model.Common.AccessPermissionTree tempTree = accessPermissionTree;
            while (tempTree.Group != null)
            {
                var groupTrees = dc.AccessPermissionTrees.Where(t => t.Item == tempTree.Group);
                var accessPermissionTreeGroup = groupTrees.Single();
                string groupItemCode = HashData("mahba3905" + accessPermissionTreeGroup.Item);
                if (GetRoleAccessPermission(roleCode, groupItemCode) == false)
                    return false;
                //if (GetMembershipAccessPermission(membership.Code, groupItemCode) == false)
                //    return false;
                tempTree = accessPermissionTreeGroup;
            }

            string itemCode = HashData("mahba3905" + item);

            if (GetRoleAccessPermission(roleCode, itemCode) == false)
                return false;
            return true;
            //return GetMembershipAccessPermission(membership.Code, itemCode);
        }

        internal int GetRoleMembershipCount(int roleCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.Users.ToArray().Where(t => t.RoleCode == this.HashData(t.Code.ToString() + roleCode.ToString())).Count();
        }

        internal List<Model.Common.User> GetRoleMemberships(int roleCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            return dc.Users.ToArray().Where(t => t.RoleCode == this.HashData(t.Code.ToString() + roleCode.ToString())).ToList();
        }

        internal bool GetRoleAccessPermission(int roleCode, string itemCode)
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            var query = dc.UserRoleAccessPermissions.Where(t => t.ItemCode == itemCode && t.RoleID == roleCode);
            if (query.Count() == 1)
            {
                var userRoleAccessPermission = query.Single();
                string value = Setting.User.ThisProgram.HashData("mahba3905" + userRoleAccessPermission.RoleID.ToString() + "True");
                return userRoleAccessPermission.Allow == value;
            }
            else
                return false;
        }

        //internal bool GetMembershipAccessPermission(int userCode, string itemCode)
        //{
        //    ArchiveCommonModel.Common.ArchiveCommonDataClassesDataContext dc = new ArchiveCommonModel.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
        //    var query = dc.MembershipAccessPermissions.Where(t => t.ItemCode == itemCode && t.MembershipCode == userCode);
        //    if (query.Count() == 1)
        //    {
        //        var membershipAccessPermission = query.Single();
        //        string value = Setting.User.ThisProgram.HashData(membershipAccessPermission.Code.ToString() + membershipAccessPermission.MembershipCode.ToString() + "True");
        //        return membershipAccessPermission.Allow == value;
        //    }
        //    else
        //        return false;
        //}

        internal void SetRoleAccessPermission(int roleCode, string itemCode, bool allow)
        {
            var dc = Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance();
            dc.Connection.Open();
            dc.Transaction = dc.Connection.BeginTransaction();
            try
            {
                var query = dc.UserRoleAccessPermissions.Where(t => t.ItemCode == itemCode && t.RoleID == roleCode);
                if (query.Count() == 1)
                {
                    var userRoleAccessPermission = query.Single();
                    string value = Setting.User.ThisProgram.HashData("mahba3905" + userRoleAccessPermission.RoleID.ToString() + (allow ? "True" : "False"));
                    userRoleAccessPermission.Allow = value;
                    dc.SubmitChanges();
                }
                else
                {
                    //object id = DataAccess.CommonDataAccess.GetNewInstance().ExecuteScalar("SELECT IDENT_CURRENT('" + Model.Common.UserRoleAccessPermission.GetTableName() + "')");
                    //int code = dc.UserRoleAccessPermissions.Count() == 0 ? 1 : ((id.IsNullOrEmpty() ? 0 : int.Parse(id.ToString())) + 1);
                    //var codeQuery = dc.UserRoleAccessPermissions.Select(t => t.ID);
                    //code = codeQuery.Count() > 0 ? (codeQuery.Max() + 1) : 1;
                    Model.Common.UserRoleAccessPermission userRoleAccessPermission = Model.Common.UserRoleAccessPermission.GetNewInstance(itemCode, roleCode, "");
                    Model.Common.UserRoleAccessPermission.Insert(dc, userRoleAccessPermission);
                    dc.SubmitChanges();
                    string value = Setting.User.ThisProgram.HashData("mahba3905" + userRoleAccessPermission.RoleID.ToString() + (allow ? "True" : "False"));
                    userRoleAccessPermission.Allow = value;
                    dc.SubmitChanges();
                }
                dc.Transaction.Commit();
            }
            catch
            {
                dc.Transaction.Rollback();
                throw;
            }
            finally
            {
                if ((dc.Connection.State & System.Data.ConnectionState.Open) == System.Data.ConnectionState.Open)
                    dc.Connection.Close();
            }
        }

        //internal void SetMembershipAccessPermission(int userCode, string itemCode, bool allow)
        //{
        //    ArchiveCommonModel.Common.ArchiveCommonDataClassesDataContext dc = new ArchiveCommonModel.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
        //    var query = dc.MembershipAccessPermissions.Where(t => t.ItemCode == itemCode && t.MembershipCode == userCode);
        //    if (query.Count() == 1)
        //    {
        //        var membershipAccessPermission = query.Single();
        //        string value = Setting.User.ThisProgram.HashData(membershipAccessPermission.Code.ToString() + membershipAccessPermission.MembershipCode.ToString() + (allow ? "True" : "False"));
        //        membershipAccessPermission.Allow = value;
        //        dc.SubmitChanges();
        //    }
        //    else
        //    {
        //        int code;
        //        var codeQuery = dc.MembershipAccessPermissions.Select(t => t.Code);
        //        code = codeQuery.Count() > 0 ? (codeQuery.Max() + 1) : 1;
        //        ArchiveCommonModel.UserAccessPermission membershipAccessPermission = ArchiveCommonModel.UserAccessPermission.GetNewInstance(code, itemCode, userCode, "");
        //        string value = Setting.User.ThisProgram.HashData(membershipAccessPermission.Code.ToString() + membershipAccessPermission.MembershipCode.ToString() + (allow ? "True" : "False"));
        //        membershipAccessPermission.Allow = value;
        //        ArchiveCommonModel.UserAccessPermission.Insert(dc, membershipAccessPermission);
        //        dc.SubmitChanges();
        //    }
        //}

        internal string GetUserVisible(int code, bool value)
        {
            return this.HashData(code.ToString() + value.ToString());
        }

        public override object GetUserByUserName(string userName)
        {
            return Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().Users.Where(t => t.UserName == userName).Single();
        }
        public override string GetUserByCode(int code)
        {
            return Model.Common.ArchiveCommonDataClassesDataContext.GetNewInstance().Users.Where(t => t.Code == code).Single().FullName;
        }
        Njit.Common.CryptoService.DESCryptoService _UserLogCryptoService;
        internal Njit.Common.CryptoService.DESCryptoService GetUserLogCryptoService(int code)
        {
            if (_UserLogCryptoService == null)
                _UserLogCryptoService = new Njit.Common.CryptoService.DESCryptoService();
            _UserLogCryptoService.SetKey(code.ToString() + "qwe", code.ToString() + "asd");
            return _UserLogCryptoService;
        }

        internal UserLogView GetUserLogView(Model.Common.UserLog item)
        {
            Njit.Common.CryptoService.DESCryptoService des = GetUserLogCryptoService(item.UserCode);
            return new NjitSoftware.UserLogView(item.ID, item.UserCode, item.User.FullName, item.OperationPlaceCode == null ? null : des.DecryptFromBase64(item.OperationPlaceCode), des.DecryptFromBase64(item.OperationCode), item.Code == null ? null : des.DecryptFromBase64(item.Code), item.Description == null ? null : des.DecryptFromBase64(item.Description), des.DecryptFromBase64(item.Date), des.DecryptFromBase64(item.Time), item.IPAddress, item.ArchiveID.ToString());
        }
        internal DateTime GetFirstUserLogDate()
        {
            Model.Common.ArchiveCommonDataClassesDataContext dc = new Model.Common.ArchiveCommonDataClassesDataContext(Setting.Sql.ThisProgram.DatabaseConnection.ConnectionString);
            if (dc.UserLogs.Count() > 0)
                return Njit.Common.PersianCalendar.ToDateTime(GetUserLogView(dc.UserLogs.First()).Date);
            return DateTime.Now;
        }
    }
}
