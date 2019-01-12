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
    public partial class ListForm : Njit.Program.ComponentOne.Forms.BaseFormSizable
    {
        public ListForm()
        {
            InitializeComponent();
        }

        private bool _AutoLoadState = true;
        [DefaultValue(true)]
        public bool AutoLoadState
        {
            get
            {
                return _AutoLoadState;
            }
            set
            {
                _AutoLoadState = value;
            }
        }

        private bool _AutoSaveState = true;
        [DefaultValue(true)]
        public bool AutoSaveState
        {
            get
            {
                return _AutoSaveState;
            }
            set
            {
                _AutoSaveState = value;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.AutoLoadState && !this.DesignMode)
                Options.SettingInitializer.GetProgramSetting().LoadFormState(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (this.AutoSaveState && !this.DesignMode)
                Options.SettingInitializer.GetProgramSetting().SaveFormState(this);
        }

        public virtual void RefreshData()
        {

        }

    }
}
