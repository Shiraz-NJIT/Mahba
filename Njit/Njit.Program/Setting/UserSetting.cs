using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Program.Setting
{
    /// <summary>
    /// تنظیمات مربوط به کاربران
    /// </summary>
    public abstract class UserSetting
    {
        /// <summary>
        /// وضعیت های یک کاربر
        /// </summary>
        public enum UserStates
        {
            Active = 1,
            Inactive = 2
        }

        /// <summary>
        /// خروج از سیستم
        /// </summary>
        /// <returns></returns>
        public abstract bool Logout();

        /// <summary>
        /// ورود به سیستم
        /// </summary>
        /// <returns></returns>
        public abstract bool Login();

        /// <summary>
        /// بستن تمام فرم ها
        /// </summary>
        /// <param name="except">همه فرم ها بسته شود بجز؟</param>
        public virtual void CloseForms(params string[] except)
        {
            int Count = System.Windows.Forms.Application.OpenForms.Count;
            System.Windows.Forms.Form[] forms = new System.Windows.Forms.Form[Count];
            for (int i = 0; i < Count; i++)
            {
                forms[i] = System.Windows.Forms.Application.OpenForms[i];
            }
            for (int i = 0; i < Count; i++)
            {
                if (!except.Contains(forms[i].Name))
                    forms[i].Close();
            }
        }

        private object _CurrentUser;
        /// <summary>
        /// مقدار دهی کاربر جاری
        /// </summary>
        /// <typeparam name="U">نوع کلاس کاربر</typeparam>
        /// <param name="value">مقدار</param>
        public virtual void SetCurrentUser<U>(U value)
        {
            _CurrentUser = value;
            OnCurrentUserChanged<U>(value);
        }

        /// <summary>
        /// دریافت کاربر جاری
        /// </summary>
        /// <typeparam name="U">نوع کلاس کاربر</typeparam>
        public virtual U GetCurrentUser<U>()
        {
            return (U)_CurrentUser;
        }

        public class CurrentUserChangedEventArgs<U> : EventArgs
        {
            public CurrentUserChangedEventArgs(U membership)
            {
                this.Membership = membership;
            }
            private U _Membership;
            public U Membership
            {
                get
                {
                    return _Membership;
                }
                set
                {
                    _Membership = value;
                }
            }
        }

        /// <summary>
        /// وقتی اتفاق می افتد که کاربر جاری تغییر کند
        /// </summary>
        public event EventHandler<CurrentUserChangedEventArgs<object>> CurrentUserChanged;
        public virtual void OnCurrentUserChanged<U>(U currentUser)
        {
            if (CurrentUserChanged != null)
                CurrentUserChanged(null, new CurrentUserChangedEventArgs<object>(currentUser));
        }

        /// <summary>
        /// اعتبار سنجی
        /// </summary>
        /// <param name="username">نام کاربری</param>
        /// <param name="password">رمزعبور</param>
        public abstract bool Authenticate(string username, string password);

        /// <summary>
        /// اعتبار سنجی
        /// </summary>
        /// <param name="userID">کد کاربر</param>
        /// <param name="password">رمزعبور</param>
        public abstract bool Authenticate(int userID, string password);

        /// <summary>
        /// هش کردن داده
        /// </summary>
        /// <param name="data">مقدار داده</param>
        /// <returns>مقدار هش شده برگشت داده می شود</returns>
        public virtual string HashData(string data)
        {
            Njit.Common.CryptoService.MD5CryptoService md5 = new Njit.Common.CryptoService.MD5CryptoService();
            return md5.ComputeHash(data);
        }

        /// <summary>
        /// چک کردن اینکه آیا کاربر اجازه دسترسی به کامپوننت را دارد
        /// </summary>
        /// <param name="control">کامپوننت</param>
        public abstract bool CheckUserAccessPermission(System.Windows.Forms.Control control);

        /// <summary>
        /// چک کردن اینکه آیا کاربر اجازه دسترسی به کامپوننت را دارد
        /// </summary>
        /// <param name="component">کامپوننت</param>
        public abstract bool CheckUserAccessPermission(System.ComponentModel.Component component);


        /// <summary>
        /// دریافت کاربر بر اساس نام کاربری
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        public abstract object GetUserByUserName(string userName);


        /// <summary>
        /// دریافت کاربر بر اساس کد 
        /// </summary>
        /// <param name="userName">نام کاربری</param>
        public abstract string GetUserByCode(int code);
    }
}
