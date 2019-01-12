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
    public partial class SetBrightness : UserControl
    {
        public SetBrightness()
        {
            InitializeComponent();
        }

        [DefaultValue(-255)]
        public int Minimum
        {
            get
            {
                return trackBar.Minimum;
            }
            set
            {
                trackBar.Minimum = value;
            }
        }

        [DefaultValue(255)]
        public int Maximum
        {
            get
            {
                return trackBar.Maximum;
            }
            set
            {
                trackBar.Maximum = value;
            }
        }

        [DefaultValue(0)]
        public int Value
        {
            get
            {
                return trackBar.Value;
            }
            set
            {
                trackBar.Value = value;
            }
        }

        private static SetBrightness _Instance;
        public static SetBrightness Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SetBrightness();
                if (_Instance.IsDisposed)
                    _Instance = new SetBrightness();
                return _Instance;
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            OnValueChanged(EventArgs.Empty);
        }

        public event EventHandler Reset;
        protected virtual void OnReset(EventArgs e)
        {
            if (Reset != null)
                Reset(this, e);
        }

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            trackBar.Value = 0;
            OnReset(EventArgs.Empty);
        }

    }
}
