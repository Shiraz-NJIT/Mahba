using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View
{
    public partial class ShowDetailMessage : Njit.Program.Forms.BaseFormSizable
    {
        public ShowDetailMessage()
        {
            InitializeComponent();
        }
        public void GetMessage(string Title, string Message, string DateSent)
        {
            TxtB_Title.Text = Title;
            TxtB_Text.Text= Message;
            TxtB_SendDate.Text = DateSent;
        }
    }
}
