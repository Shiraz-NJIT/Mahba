using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.TaskScheduler
{
    public partial class SelectMonth : UserControl
    {
        public SelectMonth()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<int> SelectedMonths
        {
            get
            {
                List<int> list = new List<int>();
                foreach (CheckBox item in this.Controls)
                {
                    if (item.Checked)
                        list.Add(item.Tag.ToString().ToInt());
                }
                return list;
            }
            set
            {
                foreach (int item in value)
                {
                    foreach (CheckBox c in this.Controls)
                    {
                        if (c.Tag.ToString().ToInt() == item)
                        {
                            c.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

    }
}
