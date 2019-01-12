using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Njit.Program.Forms
{
    public partial class DeleteForm : BaseFormDialog
    {
        private DeleteForm()
        {
            InitializeComponent();
        }
        public DeleteForm(IEnumerable<ListViewItem> items, string title)
            : this()
        {
            if (items != null)
            {
                ListViewItems = items;
                listView.Items.AddRange(items.ToArray());
            }
            lblTitle.Text = title;
        }
        public DeleteForm(IEnumerable<ListViewItem> items)
            : this()
        {
            if (items != null)
            {
                ListViewItems = items;
                listView.Items.AddRange(items.ToArray());
            }
        }

        public event EventHandler<DeleteAllEventArgs> DeleteAll;
        public virtual void OnDeleteAll(DeleteAllEventArgs e)
        {
            if (this.DeleteAll != null)
                this.DeleteAll(this, e);
        }

        private IEnumerable<ListViewItem> _ListViewItems;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IEnumerable<ListViewItem> ListViewItems
        {
            get
            {
                return _ListViewItems;
            }
            set
            {
                _ListViewItems = value;
            }
        }

        public class DeleteAllEventArgs : EventArgs
        {
            public DeleteAllEventArgs(IEnumerable<ListViewItem> items)
            {
                this.Items = items;
                this.ErrorList = new List<string>();
            }
            private IEnumerable<ListViewItem> _Items;
            public IEnumerable<ListViewItem> Items
            {
                get
                {
                    return _Items;
                }
                set
                {
                    _Items = value;
                }
            }
            private List<string> _ErrorList;
            public List<string> ErrorList
            {
                get
                {
                    return _ErrorList;
                }
                set
                {
                    _ErrorList = value;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAllEventArgs args = new DeleteAllEventArgs(this.ListViewItems);
            OnDeleteAll(args);
            if (args.ErrorList.Count > 0)
            {
                using (Forms.ErrorList errorList = new Forms.ErrorList(args.ErrorList))
                {
                    errorList.ShowDialog(this);
                }
            }
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (this.DesignMode)
                return;
            System.Media.SystemSounds.Exclamation.Play();
        }

    }
}
