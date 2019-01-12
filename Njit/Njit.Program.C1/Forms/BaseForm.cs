using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.ComponentOne.Forms
{
    public partial class BaseForm : C1.Win.C1Ribbon.C1RibbonForm, Njit.Common.IAccessPermission
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            this.Show(null);
        }

        public new void Show(IWin32Window owner)
        {
            if (this.AllowCheckAccessPermission && !this.DesignMode)
            {
                if (Njit.Program.Options.SettingInitializer != null)
                {
                    if (!Njit.Program.Options.SettingInitializer.GetUserSetting().CheckUserAccessPermission(this))
                    {
                        PersianMessageBox.Show(owner, this.SecurityErrorMessage);
                        return;
                    }
                }
            }
            if (owner == null)
                base.Show();
            else
                base.Show(owner);
        }

        public new DialogResult ShowDialog()
        {
            return this.ShowDialog(null);
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            if (this.AllowCheckAccessPermission && !this.DesignMode)
            {
                if (Njit.Program.Options.SettingInitializer != null)
                {
                    if (!Njit.Program.Options.SettingInitializer.GetUserSetting().CheckUserAccessPermission(this))
                    {
                        PersianMessageBox.Show(owner, this.SecurityErrorMessage);
                        return System.Windows.Forms.DialogResult.Cancel;
                    }
                }
            }
            if (owner == null)
                return base.ShowDialog();
            else
                return base.ShowDialog(owner);
        }

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

        private bool _AllowCheckAccessPermission = true;
        [DefaultValue(true)]
        public bool AllowCheckAccessPermission
        {
            get
            {
                return _AllowCheckAccessPermission;
            }
            set
            {
                _AllowCheckAccessPermission = value;
            }
        }

        public string GetPath()
        {
            return this.Name;
        }
    }
}
