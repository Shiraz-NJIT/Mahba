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
    public partial class RadioButtonList : UserControl
    {
        public RadioButtonList()
        {
            InitializeComponent();
        }

        private System.Collections.ObjectModel.ObservableCollection<Item> _Items = null;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Collections.ObjectModel.ObservableCollection<Item> Items
        {
            get
            {
                if (_Items == null)
                {
                    _Items = new System.Collections.ObjectModel.ObservableCollection<Item>();
                    _Items.CollectionChanged += Items_CollectionChanged;
                }
                return _Items;
            }
            set
            {
                _Items = value;
                RefreshRadioButtons();
            }
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        AddItem(item as Item);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        private void RefreshRadioButtons()
        {
            DeleteRadioButtons();
            foreach (var item in _Items)
                AddItem(item);
        }

        private void AddItem(Item item)
        {
            RadioButton r = new RadioButton();
            r.Text = item.Text;
            r.Tag = item.Key;
            this.Controls.Add(r);
            r.Dock = DockStyle.Top;
            r.BringToFront();
        }

        private void DeleteRadioButtons()
        {
            while (this.Controls.Count > 0)
            {
                this.Controls[0].Dispose();
                this.Controls.RemoveAt(0);
            }
        }

        public class Item
        {
            public Item(string key, string text)
            {
                this.Key = key;
                this.Text = text;
            }
            public string Key { get; set; }
            public string Text { get; set; }
        }

    }
}
