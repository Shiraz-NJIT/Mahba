using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Njit.Program.Telerik.Controls
{
    public class RadGridViewExtended : global::Telerik.WinControls.UI.RadGridView
    {
        public RadGridViewExtended()
        {
            this.CellDoubleClick += RadGridViewExtended_CellDoubleClick;
            this.SelectionChanged += RadGridViewExtended_SelectionChanged;
            //this.RowsChanged += RadGridViewExtended_RowsChanged;
        }

       

        public void BestFitColumnsSmart()
        {
            this.AutoSizeColumnsMode = global:: Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.None;
            foreach (var item in this.Columns)
                item.MaxWidth = 300;
            this.BestFitColumns();
            int width = 0;
            foreach (var item in this.Columns.Where(t => t.IsVisible))
                width += item.Width;
            if (width <= this.Width)
                this.AutoSizeColumnsMode = global:: Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            else
                this.AutoSizeColumnsMode = global::Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.None;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.Rows.Count == 0)
            {
                if (this.EditButton != null)
                    this.EditButton.Enabled = false;
                if (this.DeleteButton != null)
                    this.DeleteButton.Enabled = false;
            }
        }
        void radGridViewExtended1_ContextMenuOpening2(object sender, ContextMenuOpeningEventArgs e, CellFormattingEventArgs ee)
        { 
        
        }
        //private void RadGridViewExtended_RowsChanged(object sender, global::Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        //{
        //    //if (this.Rows.Count == 0)
        //    //{
        //    //    if (this.EditButton != null)
        //    //        this.EditButton.Enabled = false;
        //    //    if (this.DeleteButton != null)
        //    //        this.DeleteButton.Enabled = false;
        //    //}
        //}
        private void RadGridViewExtended_cellchanged(object sender, EventArgs e)
        {
        
        }
        private void RadGridViewExtended_SelectionChanged(object sender, EventArgs e)
        {
            if (this.SelectedRows.Count == 0)
            {
                if (this.EditButton != null)
                    this.EditButton.Enabled = false;
                if (this.DeleteButton != null)
                    this.DeleteButton.Enabled = false;
            }
            else if (this.SelectedRows.Count == 1)
            {
                if (this.EditButton != null)
                    this.EditButton.Enabled = true;
                if (this.DeleteButton != null)
                    this.DeleteButton.Enabled = true;
            }
            else
            {
                if (this.EditButton != null)
                    this.EditButton.Enabled = false;
                if (this.DeleteButton != null)
                    this.DeleteButton.Enabled = true;
            }
        }

        private System.Windows.Forms.Control _EditButton = null;
        [DefaultValue(null)]
        public System.Windows.Forms.Control EditButton
        {
            get
            {
                return _EditButton;
            }
            set
            {
                _EditButton = value;
            }
        }

        private System.Windows.Forms.Control _DeleteButton = null;
        [DefaultValue(null)]
        public System.Windows.Forms.Control DeleteButton
        {
            get
            {
                return _DeleteButton;
            }
            set
            {
                _DeleteButton = value;
            }
        }

        private void RadGridViewExtended_CellDoubleClick(object sender, global::Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (this.EditButton != null)
            {
                this.EditButton.Focus();
                System.Windows.Forms.Form form = this.FindForm();
                if (form != null)
                    form.ActiveControl = this.EditButton;
                InvokeOnClick(this.EditButton, EventArgs.Empty);
            }
        }

    }
}
