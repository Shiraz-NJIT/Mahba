using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Njit.MessageBox;

namespace Njit.Program.ElegantProgram.Controls
{
    public partial class ElegantButton : Elegant.Ui.Button, Njit.Common.IAccessPermission
    {
        public ElegantButton()
        {
            InitializeComponent();
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

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            if (this.AllowCheckAccessPermission && levent.AffectedControl == this && !this.DesignMode)
            {
                if (Njit.Program.Options.SettingInitializer != null)
                {
                    if (!Njit.Program.Options.SettingInitializer.GetUserSetting().CheckUserAccessPermission(this))
                        this.Enabled = false;
                    else
                        this.Enabled = true;
                }
            }
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
                    Control parent = this.Parent;
                    while (parent != null)
                    {
                        if (parent is Njit.Common.IAccessPermission)
                            if ((parent as Njit.Common.IAccessPermission).AllowCheckAccessPermission == false)
                                return false;
                        parent = parent.Parent;
                    }
                    return _AllowCheckAccessPermission;
                }
            }
            set
            {
                _AllowCheckAccessPermission = value;
            }
        }

        public string GetPath()
        {
            string name = this.Name;
            System.Windows.Forms.Control parent = this.Parent;
            while (parent != null)
            {
                name += " " + parent.Name;
                parent = parent.Parent;
            }
            return name;
        }
    }
}
