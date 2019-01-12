using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace NjitSoftware.View.Controls
{
    public partial class PersonSearch : UserControl, Njit.Program.ISearchControl
    {
        public PersonSearch()
        {
            InitializeComponent();
        }

        private void ProgramEvents_PersonsChanged(object sender, EventArgs e)
        {
            SearchAll();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ProgramEvents.PersonsChanged += ProgramEvents_PersonsChanged;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            ProgramEvents.PersonsChanged -= ProgramEvents_PersonsChanged;
        }

        private static PersonSearch _Instance;
        public static PersonSearch Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new PersonSearch();
                if (_Instance.IsDisposed)
                    _Instance = new PersonSearch();
                return _Instance;
            }
        }

        private static PersonSearch _Instance2;
        public static PersonSearch Instance2
        {
            get
            {
                if (_Instance2 == null)
                    _Instance2 = new PersonSearch();
                if (_Instance2.IsDisposed)
                    _Instance2 = new PersonSearch();
                return _Instance2;
            }
        }

        public event EventHandler<Njit.Common.ItemSelectedEventArgs> ItemSelected;
        public virtual void OnItemSelected(object SelectedItem)
        {
            if (ItemSelected != null)
                ItemSelected(this, new Njit.Common.ItemSelectedEventArgs(SelectedItem));
        }

        public int SearchAny(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            ParameterExpression parameter_ex = Expression.Parameter(typeof(Model.Archive.Person), "ParameterName");
            MethodCallExpression methodCall_ex = Expression.Call(Expression.Call(Expression.PropertyOrField(parameter_ex, this.TextBoxSearch.DisplayMember), typeof(object).GetMethod("ToString")), typeof(string).GetMethod("Contains"), Expression.Constant(value));
            Expression<Func<Model.Archive.Person, bool>> lambda_ex = LambdaExpression.Lambda<Func<Model.Archive.Person, bool>>(methodCall_ex, parameter_ex);
            IQueryable<Model.Archive.Person> data = dc.Persons.Where(lambda_ex).Select(t => t);
            personBindingSource.DataSource = data;
            return data.Count();
        }

        public void SearchAll()
        {
            var dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();
            IQueryable<Model.Archive.Person> data = dc.Persons.Select(t => t);
            personBindingSource.DataSource = data;
        }

        public object Search(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();

            ParameterExpression parameter_ex = Expression.Parameter(typeof(Model.Archive.Person), "ParameterName");
            object convertedValue = value;
            if (GetPropertyType(typeof(Model.Archive.Person), this.TextBoxSearch.DisplayMember) != typeof(string))
                if (!(Njit.Common.PublicMethods.ConvertValue(value, ref convertedValue, GetPropertyType(typeof(Model.Archive.Person), this.TextBoxSearch.DisplayMember))))
                    return null;
            BinaryExpression equal_ex = Expression.Equal(Expression.PropertyOrField(parameter_ex, this.TextBoxSearch.DisplayMember), Expression.Constant(convertedValue));
            Expression<Func<Model.Archive.Person, bool>> lambda_ex = LambdaExpression.Lambda<Func<Model.Archive.Person, bool>>(equal_ex, parameter_ex);
            IQueryable<Model.Archive.Person> data = dc.Persons.Where(lambda_ex).Select(t => t);

            if (data != null && data.Count() > 0)
                return data.First();
            return null;
        }

        //private bool ConvertValue(string value, ref object convertedValue, Type type)
        //{
        //    if (type == typeof(int) || type == typeof(int?))
        //    {
        //        int v;
        //        if (int.TryParse(value, out v))
        //        {
        //            convertedValue = v;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    if (type == typeof(long) || type == typeof(long?))
        //    {
        //        long v;
        //        if (long.TryParse(value, out v))
        //        {
        //            convertedValue = v;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    if (type == typeof(short) || type == typeof(short?))
        //    {
        //        short v;
        //        if (short.TryParse(value, out v))
        //        {
        //            convertedValue = v;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    if (type == typeof(float) || type == typeof(float?))
        //    {
        //        float v;
        //        if (float.TryParse(value, out v))
        //        {
        //            convertedValue = v;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    if (type == typeof(double) || type == typeof(double?))
        //    {
        //        double v;
        //        if (double.TryParse(value, out v))
        //        {
        //            convertedValue = v;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    if (type == typeof(decimal) || type == typeof(decimal?))
        //    {
        //        decimal v;
        //        if (decimal.TryParse(value, out v))
        //        {
        //            convertedValue = v;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    return false;
        //}

        private Type GetPropertyType(Type type, string Property)
        {
            return type.GetProperty(Property).PropertyType;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Close()
        {
            Njit.Common.Popup.Popup popup = this.Parent as Njit.Common.Popup.Popup;
            if (popup != null)
                popup.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count > 0)
            {
                OnItemSelected(radGridView.SelectedRows[0].DataBoundItem);
                Close();
            }
        }

        public void GoNextRow()
        {
            if (radGridView.SelectedRows.Count == 1)
            {
                int index = radGridView.SelectedRows[0].Index;
                if (index + 1 < radGridView.Rows.Count)
                    radGridView.Rows[index + 1].IsCurrent = true;
            }
            else
                if (radGridView.Rows.Count > 0)
                    radGridView.Rows[0].IsCurrent = true;
        }

        public void GoPrevRow()
        {
            if (radGridView.SelectedRows.Count == 1)
            {
                int index = radGridView.SelectedRows[0].Index;
                if (index - 1 >= 0)
                    radGridView.Rows[index - 1].IsCurrent = true;
            }
            else
                if (radGridView.Rows.Count > 0)
                    radGridView.Rows[0].IsCurrent = true;
        }

        public void SelectCurrentRow()
        {
            if (this.Visible)
                InvokeOnClick(btnOK, EventArgs.Empty);
        }

        private void radGridView_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            InvokeOnClick(btnOK, EventArgs.Empty);
        }

        private Njit.Program.Controls.TextBoxSearch _TextBoxSearch;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public Njit.Program.Controls.TextBoxSearch TextBoxSearch
        {
            get
            {
                return _TextBoxSearch;
            }
            set
            {
                _TextBoxSearch = value;
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (radGridView.SelectedRows.Count != 1)
                return;
            Model.Archive.Person person = radGridView.SelectedRows[0].DataBoundItem as Model.Archive.Person;
            using (View.LendingManageForms.PersonAddEdit f = new View.LendingManageForms.PersonAddEdit(person.ID))
            {
                bool flag = (this.Parent as Njit.Common.Popup.Popup).AutoClose;
                (this.Parent as Njit.Common.Popup.Popup).AutoClose = true;
                f.ShowDialog();
                (this.Parent as Njit.Common.Popup.Popup).AutoClose = flag;
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (var row in radGridView.SelectedRows)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ((Model.Archive.Person)row.DataBoundItem).Name;
                item.Tag = (Model.Archive.Person)row.DataBoundItem;
                items.Add(item);
            }
            if (items.Count > 0)
            {
                using (Njit.Program.Forms.DeleteForm f = new Njit.Program.Forms.DeleteForm(items, "از حذف اطلاعات اشخاص زیر اطمینان دارید؟"))
                {
                    f.DeleteAll += DeleteForm_DeleteAll;
                    bool flag = (this.Parent as Njit.Common.Popup.Popup).AutoClose;
                    (this.Parent as Njit.Common.Popup.Popup).AutoClose = true;
                    f.ShowDialog();
                    (this.Parent as Njit.Common.Popup.Popup).AutoClose = flag;
                }
            }
        }

        void DeleteForm_DeleteAll(object sender, Njit.Program.Forms.DeleteForm.DeleteAllEventArgs e)
        {
            foreach (ListViewItem item in e.Items)
            {
                Model.Archive.Person person = (Model.Archive.Person)item.Tag;
                try
                {
                    Controller.Archive.PersonController.Delete(person.ID);
                }
                catch (Exception ex)
                {
                    e.ErrorList.Add(ex.Message);
                }
            }
            ProgramEvents.OnPersonsChanged();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            using (View.LendingManageForms.PersonAddEdit f = new View.LendingManageForms.PersonAddEdit())
            {
                bool flag = (this.Parent as Njit.Common.Popup.Popup).AutoClose;
                (this.Parent as Njit.Common.Popup.Popup).AutoClose = true;
                f.ShowDialog();
                (this.Parent as Njit.Common.Popup.Popup).AutoClose = flag;
            }
        }

        public object SearchByValueMember(object value)
        {
            if (value.IsNullOrEmpty())
                return null;
            Model.Archive.ArchiveDataClassesDataContext dc = Model.Archive.ArchiveDataClassesDataContext.GetNewInstance();

            ParameterExpression parameter_ex = Expression.Parameter(typeof(Model.Archive.Person), "ParameterName");
            BinaryExpression equal_ex = Expression.Equal(Expression.PropertyOrField(parameter_ex, this.TextBoxSearch.ValueMember), Expression.Constant(value));
            Expression<Func<Model.Archive.Person, bool>> lambda_ex = LambdaExpression.Lambda<Func<Model.Archive.Person, bool>>(equal_ex, parameter_ex);
            IQueryable<Model.Archive.Person> data = dc.Persons.Where(lambda_ex).Select(t => t);

            if (data != null && data.Count() > 0)
                return data.First();
            return null;
        }
    }
}
