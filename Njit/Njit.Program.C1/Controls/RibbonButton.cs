using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.ComponentOne.Controls
{
    public class RibbonButton : C1.Win.C1Ribbon.RibbonButton, Njit.Common.IAccessPermission
    {
        const string _ConstSecurityErrorMessage = "مجوز دسترسی به این قسمت برای شما صادر نشده است";
        private string _SecurityErrorMessage = _ConstSecurityErrorMessage;
        [DefaultValue(_ConstSecurityErrorMessage)]
        protected virtual string SecurityErrorMessage
        {
            get
            {
                return _SecurityErrorMessage;
            }
            set
            {
                _SecurityErrorMessage = value;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            Form form = this.FindForm();
            try
            {
                if (form != null)
                    form.Cursor = Cursors.WaitCursor;
                if (this.AllowCheckAccessPermission && !this.DesignMode)
                {
                    if (Njit.Program.Options.SettingInitializer != null)
                    {
                        if (!Njit.Program.Options.SettingInitializer.GetUserSetting().CheckUserAccessPermission(this))
                        {
                            PersianMessageBox.Show(this.SecurityErrorMessage);
                            return;
                        }
                    }
                }
                base.OnClick(e);
            }
            finally
            {
                if (form != null)
                    form.Cursor = Cursors.Default;
            }
        }

        private Form FindForm()
        {
            if (this.OwnerControl == null)
                return null;
            return this.OwnerControl.FindForm();
        }

        public string GetPath()
        {
            string name = this.Name;
            System.Windows.Forms.Control parent = this.OwnerControl;
            while (parent != null)
            {
                name += " " + parent.Name;
                parent = parent.Parent;
            }
            return name;
        }

        private bool _AllowCheckAccessPermission = true;
        [DefaultValue(true)]
        public bool AllowCheckAccessPermission
        {
            get
            {
                if (this.DesignMode)
                    return _AllowCheckAccessPermission;
                else
                {
                    if (this.OwnerControl is Njit.Common.IAccessPermission)
                        if ((this.OwnerControl as Njit.Common.IAccessPermission).AllowCheckAccessPermission == false)
                            return false;
                    Form form = this.FindForm();
                    if (form != null && form is Njit.Common.IAccessPermission)
                        if ((form as Njit.Common.IAccessPermission).AllowCheckAccessPermission == false)
                            return false;
                    return _AllowCheckAccessPermission;
                }
            }
            set
            {
                _AllowCheckAccessPermission = value;
            }
        }
    }
}
