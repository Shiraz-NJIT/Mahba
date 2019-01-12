using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NjitSoftware.View.Controls
{
    public partial class DossierInfo : Panel
    {
        public DossierInfo()
        {
            InitializeComponent();
            this.Text = "مشخصات پرونده";
            this.AutoScroll = true;
        }

        [DefaultValue(true)]
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = value;
            }
        }

        [DefaultValue("مشخصات پرونده")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        static Padding _DefaultPadding = new Padding(10, 10, 10, 10);
        protected override Padding DefaultPadding
        {
            get
            {
                return _DefaultPadding;
            }
        }

        private string _PersonnelNumber;
        [DefaultValue(null)]
        public string PersonnelNumber
        {
            get
            {
                return _PersonnelNumber;
            }
            set
            {
                _PersonnelNumber = value;
                if (this.DesignMode)
                    return;
                for (int i = 0; i < this.Controls.Count; i++)
                    this.Controls[i].Dispose();
                this.Controls.Clear();
                if (_PersonnelNumber != null)
                {
                    AddLable(Setting.Archive.ThisProgram.LoadedArchiveSettings.PersonnelNumber_Label + ": " + _PersonnelNumber);
                    Dictionary<Model.Archive.ArchiveTab, List<Model.Archive.ArchiveField>> dic = Controller.Archive.DisplayFieldController.GetDisplayFieldsGroupedByTab(Enums.DisplayFieldCodes.امانت);
                    foreach (var item in dic.Keys)
                    {
                        AddLable("(" + item.Title + "):");
                        foreach (var i in dic[item])
                        {
                            AddLable(i.Label + ": " + Controller.Archive.ArchiveFieldController.GetFieldValue(i, _PersonnelNumber));
                        }
                    }
                }
            }
        }

        private void AddLable(string text)
        {
            System.Windows.Forms.Label label = new Label();
            label.AutoSize = false;
            label.Height = 20;
            label.Text = text;
            this.Controls.Add(label);
            label.Dock = DockStyle.Top;
            label.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawVisualStyleBorder(e.Graphics, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }
}
