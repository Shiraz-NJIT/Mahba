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
    public partial class DataGridViewExtended : System.Windows.Forms.DataGridView
    {
        public DataGridViewExtended()
        {
            InitializeComponent();
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.BackgroundColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ReadOnly = true;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersVisible = false;
            this.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private bool _AutoBestFitColumns = true;
        [DefaultValue(true)]
        public bool AutoBestFitColumns
        {
            get
            {
                return _AutoBestFitColumns;
            }
            set
            {
                _AutoBestFitColumns = value;
                if (value)
                    BestFitColumns();
            }
        }

        public void BestFitColumns()
        {
            if (this.Rows.Count == 0 || (this.AllowUserToAddRows && this.Rows.Count == 1))
                this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            else
            {
                this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                int columnsWidth = 0;
                foreach (System.Windows.Forms.DataGridViewColumn c in this.Columns)
                {
                    if (c.Visible)
                        columnsWidth += c.Width;
                }
                if (columnsWidth <= this.Width)
                    this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public int GetColumnMaxWidth(System.Windows.Forms.DataGridViewColumn column)
        {
            int w = column.Width;
            Size size = TextRenderer.MeasureText(column.HeaderText, this.Font);
            if (size.Width > w)
                w = size.Width;
            for (int i = 0; i < this.Rows.Count; i++)
            {
                if (!(this.Rows[i].Cells[column.Name].Value.IsNullOrEmpty()))
                {
                    size = TextRenderer.MeasureText(this.Rows[i].Cells[column.Name].Value.ToString(), this.Font);
                    if (size.Width > w)
                        w = size.Width;
                }
            }
            return w;
        }

        //protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        //{
        //    base.OnCellEndEdit(e);
        //    if (AutoBestFitColumns)
        //        BestFitColumns();
        //}

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            if (AutoBestFitColumns)
                BestFitColumns();
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            if (AutoBestFitColumns)
                BestFitColumns();
        }

        [DefaultValue(typeof(DataGridViewEditMode), "EditOnEnter")]
        public new DataGridViewEditMode EditMode
        {
            get
            {
                return base.EditMode;
            }
            set
            {
                base.EditMode = value;
            }
        }

        [DefaultValue(false)]
        public new bool AllowUserToAddRows
        {
            get
            {
                return base.AllowUserToAddRows;
            }
            set
            {
                base.AllowUserToAddRows = value;
            }
        }

        [DefaultValue(false)]
        public new bool AllowUserToDeleteRows
        {
            get
            {
                return base.AllowUserToDeleteRows;
            }
            set
            {
                base.AllowUserToDeleteRows = value;
            }
        }

        [DefaultValue(true)]
        public new bool AllowUserToOrderColumns
        {
            get
            {
                return base.AllowUserToOrderColumns;
            }
            set
            {
                base.AllowUserToOrderColumns = value;
            }
        }

        [DefaultValue(typeof(Color), "Control")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [DefaultValue(typeof(Color), "Control")]
        public new Color BackgroundColor
        {
            get
            {
                return base.BackgroundColor;
            }
            set
            {
                base.BackgroundColor = value;
            }
        }

        [DefaultValue(typeof(BorderStyle), "Fixed3D")]
        public new BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                base.BorderStyle = value;
            }
        }

        [DefaultValue(true)]
        public new bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }

        [DefaultValue(typeof(DataGridViewSelectionMode), "FullRowSelect")]
        public new DataGridViewSelectionMode SelectionMode
        {
            get
            {
                return base.SelectionMode;
            }
            set
            {
                base.SelectionMode = value;
            }
        }

        [DefaultValue(false)]
        public new bool RowHeadersVisible
        {
            get
            {
                return base.RowHeadersVisible;
            }
            set
            {
                base.RowHeadersVisible = value;
            }
        }
    }
}
