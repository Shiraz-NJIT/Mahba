using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.Controls
{
    [ToolboxBitmap(typeof(TabControl))]
    public partial class TabControlExtended : System.Windows.Forms.TabControl/*, Njit.Common.IAccessPermission*/
    {
        public TabControlExtended()
        {
            InitializeComponent();
        }

        //const string _ConstSecurityErrorMessage = "مجوز دسترسی به این قسمت برای شما صادر نشده است";
        //private string _SecurityErrorMessage = _ConstSecurityErrorMessage;
        //[DefaultValue(_ConstSecurityErrorMessage)]
        //protected virtual string SecurityErrorMessage
        //{
        //    get
        //    {
        //        return _SecurityErrorMessage;
        //    }
        //    set
        //    {
        //        _SecurityErrorMessage = value;
        //    }
        //}

        //protected override void OnCreateControl()
        //{
        //    base.OnCreateControl();
            //if (this.AllowCheckAccessPermission && !this.DesignMode)
            //{
            //    if (Njit.Program.Options.SettingInitializer != null && this.SelectedTab != null)
            //    {
            //        if (!Njit.Program.Options.SettingInitializer.GetUserSetting().CheckUserAccessPermission(this.SelectedTab))
            //            this.SelectedTab.Enabled = false;
            //        else
            //            this.SelectedTab.Enabled = true;
            //    }
            //}
        //}

        //protected override void OnSelecting(TabControlCancelEventArgs e)
        //{
        //    if (this.AllowCheckAccessPermission && !this.DesignMode)
        //    {
        //        if (Njit.Program.Options.SettingInitializer != null)
        //        {
        //            if (!Njit.Program.Options.SettingInitializer.GetUserSetting().CheckUserAccessPermission(e.TabPage))
        //            {
        //                e.Cancel = true;
        //                PersianMessageBox.Show(this.SecurityErrorMessage);
        //            }
        //        }
        //    }
        //    base.OnSelecting(e);
        //}

        //private bool _AllowCheckAccessPermission = true;
        //[DefaultValue(true)]
        //public bool AllowCheckAccessPermission
        //{
        //    get
        //    {
        //        if (this.DesignMode)
        //            return _AllowCheckAccessPermission;
        //        else
        //        {
        //            Control parent = this.Parent;
        //            while (parent != null)
        //            {
        //                if (parent is Njit.Common.IAccessPermission)
        //                    if ((parent as Njit.Common.IAccessPermission).AllowCheckAccessPermission == false)
        //                        return false;
        //                parent = parent.Parent;
        //            }
        //            return _AllowCheckAccessPermission;
        //        }
        //    }
        //    set
        //    {
        //        _AllowCheckAccessPermission = value;
        //    }
        //}
    }
}
