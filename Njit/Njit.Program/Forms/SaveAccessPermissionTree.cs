using Njit.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

using System.Windows.Forms;

namespace Njit.Program.Forms
{
    public partial class SaveAccessPermissionTree : Form
    {
        public SaveAccessPermissionTree(Assembly assembly, string databaseConnectionString)
        {
            InitializeComponent();
            this.Assembly = assembly;
            this.Connection = new SqlConnectionStringBuilder(databaseConnectionString);
        }

        public SaveAccessPermissionTree()
        {
            InitializeComponent();
        }

        private Assembly _Assembly;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual Assembly Assembly
        {
            get
            {
                if (_Assembly == null)
                    _Assembly = System.Reflection.Assembly.GetExecutingAssembly();
                return _Assembly;
            }
            set
            {
                _Assembly = value;
            }
        }

        SqlConnectionStringBuilder _Connection;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected virtual SqlConnectionStringBuilder Connection
        {
            get
            {
                if (_Connection == null)
                    _Connection = Options.SettingInitializer.GetSqlSetting().DatabaseConnection;
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }

        private Njit.Sql.DataAccess _DataAccess;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected Njit.Sql.DataAccess DataAccess
        {
            get
            {
                if (_DataAccess == null)
                    _DataAccess = new Njit.Sql.DataAccess(this.Connection.ConnectionString);
                return _DataAccess;
            }
            set
            {
                _DataAccess = value;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (this.Connection == null)
            {
                PersianMessageBox.Show("پایگاه داده مشخص نشده است");
                return;
            }
            bool tableExist = this.DataAccess.GetData("SELECT * FROM [sys].[tables] WHERE [name]='AccessPermissionTree'").Rows.Count == 1;
            if (!tableExist)
            {
                PersianMessageBox.Show("پایگاه داده برنامه جدولی با نام \r\n" + "AccessPermissionTree" + "\r\n ندارد");
                return;
            }
            LoadData();
        }

        private void LoadData()
        {
            Type[] types = this.Assembly.GetTypes().Where(t => ((t.IsSubclassOf(typeof(Njit.Program.Forms.BaseForm)) || (t.GetInterface(typeof(Njit.Common.IAccessPermission).FullName) != null)) && !t.IsSubclassOf(typeof(Njit.Program.Forms.MainForm)))).ToArray();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Model.MainModelDataContext dc = new Model.MainModelDataContext(this.Connection.ConnectionString);

                treeView.SuspendLayout();
                treeView.Nodes.Clear();

                foreach (var item in dc.AccessPermissionTrees.ToArray().Where(t => t.Group == null))
                {
                    TreeNode node = AddNode(null, item, types);
                    AddSubNodes(dc, node, item, types);
                }
                CheckNodesForControls(treeView.Nodes);
                AddFormsThatIsNotExist(types);

                treeView.ExpandAll();
                treeView.ResumeLayout(true);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AddFormsThatIsNotExist(Type[] types)
        {
            foreach (Type type in types)
            {
                Form form = GetForm(type);
                if (form == null)
                    continue;
                if (!FormExistInNodes(treeView.Nodes, form))
                {
                    TreeNode node = new TreeNode(form == null ? type.Name : (form.Text.IsNullOrEmpty() ? form.Name : form.Text));
                    treeView.Nodes.Add(node);
                    node.ToolTipText = form.Name;
                    node.Tag = form;
                    node.Checked = true;

                    IEnumerable<Control> fields = GetFields(form);
                    foreach (Control control in fields)
                    {
                        if (control is Njit.Program.Controls.ComboBoxExtended && ((control as Njit.Program.Controls.ComboBoxExtended).EditItemsEnabled == false))
                            continue;
                        if (form.CancelButton != control)
                        {
                            TreeNode subNode1 = new TreeNode(control.Text.IsNullOrEmpty() ? control.Name : control.Text);
                            subNode1.Tag = control;
                            subNode1.ToolTipText = control.Name;
                            subNode1.Checked = true;
                            node.Nodes.Add(subNode1);
                            if (control is Njit.Program.Controls.TabControlExtended)
                            {
                                foreach (TabPage tabpage in (control as Njit.Program.Controls.TabControlExtended).TabPages)
                                {
                                    TreeNode subNode2 = new TreeNode(tabpage.Text.IsNullOrEmpty() ? tabpage.Name : tabpage.Text);
                                    subNode2.Tag = tabpage;
                                    subNode2.ToolTipText = tabpage.Name;
                                    subNode2.Checked = true;
                                    node.Nodes.Add(subNode2);
                                }
                            }
                        }
                    }
                }
            }
        }

        private IEnumerable<Control> GetFields(Control control)
        {
            List<Control> list = new List<Control>();
            foreach (Control c in control.Controls)
            {
                if (c.GetType().GetInterface(typeof(Njit.Common.IAccessPermission).FullName) != null)
                    list.Add(c);
                GetFields(c, list);
            }
            return list;
        }

        private void GetFields(Control control, List<Control> list)
        {
            foreach (Control c in control.Controls)
            {
                if (c.GetType().GetInterface(typeof(Njit.Common.IAccessPermission).FullName) != null)
                    list.Add(c);
                GetFields(c, list);
            }
        }

        private void CheckNodesForControls(TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Tag is Form)
                    CheckNodeForControls(node, node.Tag as Form);
                CheckNodesForControls(node.Nodes);
            }
        }

        private void CheckNodeForControls(TreeNode node, Form form)
        {
            IEnumerable<Control> fields = GetFields(form);
            foreach (Control control in fields)
            {
                if (!NodeContainsField(node, control))
                {
                    if (control is Njit.Program.Controls.ComboBoxExtended && ((control as Njit.Program.Controls.ComboBoxExtended).EditItemsEnabled == false))
                        continue;
                    if (form.CancelButton != control)
                    {
                        TreeNode newnode = new TreeNode(control.Text.IsNullOrEmpty() ? control.Name : control.Text);
                        newnode.Tag = control;
                        newnode.ToolTipText = control.Name;
                        newnode.Checked = true;
                        node.Nodes.Add(newnode);
                    }
                }
            }
        }

        private bool NodeContainsField(TreeNode node, Control c)
        {
            foreach (TreeNode item in node.Nodes)
            {
                if ((item.Tag is Control) && (item.Tag as Control).Name == c.Name)
                    return true;
            }
            return false;
        }

        System.Collections.Generic.Dictionary<ParameterInfo, object> parametersValues = new System.Collections.Generic.Dictionary<ParameterInfo, object>();
        System.Collections.Generic.Dictionary<string, Form> formsObject = new Dictionary<string, Form>();

        private Form GetForm(Type type)
        {
            Form form;
            if (formsObject.ContainsKey(type.FullName))
                form = formsObject[type.FullName];
            else
            {
                if (TypeHaveParameterLessConstructor(type))
                {
                    form = (Form)Activator.CreateInstance(type);
                }
                else
                {
                    ConstructorInfo firstConstructor = type.GetConstructors()[0];
                    ParameterInfo[] constructorParameters = firstConstructor.GetParameters();
                    List<object> args = new List<object>(constructorParameters.Length);
                    foreach (var parameter in constructorParameters)
                    {
                        Forms.GetValue getParameterForm = new GetValue("مقدار دهی پارامتر " + parameter.Name, "پارامتر " + parameter.Name + " سازنده فرم " + type.Name + " را وارد کنید", GetDefaultValue(parameter.ParameterType));
                        getParameterForm.ShowDialog();
                        if (parametersValues.ContainsKey(parameter))
                            args.Add(parametersValues[parameter]);
                        else
                        {
                            object convertedVaue = getParameterForm.Value == "NULL" ? null : getParameterForm.Value;
                            Njit.Common.PublicMethods.ConvertValue(getParameterForm.Value, ref convertedVaue, parameter.ParameterType);
                            args.Add(convertedVaue);
                            parametersValues.Add(parameter, convertedVaue);
                        }
                    }
                    try
                    {
                        form = (Form)Activator.CreateInstance(type, args.ToArray());
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در ایجاد شی از فرم\r\n" + type.Name + "\r\n\r\n" + ex.Message);
                        form = null;
                    }
                }
                formsObject.Add(type.FullName, form);
            }
            return form;
        }

        private object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);
            else
                return null;
        }

        private bool TypeHaveParameterLessConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo item in constructors)
            {
                if (item.GetParameters().Length == 0)
                    return true;
            }
            return false;
        }

        private bool FormExistInNodes(TreeNodeCollection treeNodeCollection, Form form)
        {
            if (form == null)
                return false;
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Tag is Form && ((node.Tag as Form).Name == form.Name))
                    return true;
                bool flag = FormExistInNodes(node.Nodes, form);
                if (flag)
                    return true;
            }
            return false;
        }

        private void AddSubNodes(Model.MainModelDataContext dc, TreeNode groupNode, Model.AccessPermissionTree accessPermissionTree, Type[] types)
        {
            foreach (var item in dc.AccessPermissionTrees.Where(t => t.Group == accessPermissionTree.Item))
            {
                TreeNode node = AddNode(groupNode, item, types);
                AddSubNodes(dc, node, item, types);
            }
        }

        private TreeNode AddNode(TreeNode groupNode, Model.AccessPermissionTree accessPermissionTree, Type[] types)
        {
            TreeNode node = new TreeNode(accessPermissionTree.Title);
            object control = GetControl(accessPermissionTree, types);
            if (control != null)
            {
                node.Tag = control;
                if (control is Control)
                    node.ToolTipText = (control as Control).Name;
            }
            if (groupNode == null)
                treeView.Nodes.Add(node);
            else
                groupNode.Nodes.Add(node);
            node.Checked = accessPermissionTree.Visible;
            node.Name = accessPermissionTree.ID.ToString();
            return node;
        }

        private object GetControl(Model.AccessPermissionTree accessPermissionTree, Type[] types)
        {
            var query = types.Where(t => t.Name == accessPermissionTree.Item);
            if (query.Count() == 1)
            {
                return GetForm(query.Single());
            }
            else
            {
                if (accessPermissionTree.Group != null)
                {
                    var subquery = types.Where(t => t.Name == accessPermissionTree.Group);
                    if (subquery.Count() == 1)
                    {
                        Form form = GetForm(subquery.Single());
                        if (form != null)
                            return GetControl(form, accessPermissionTree.Item);
                    }
                    return null;
                }
                return null;
            }
        }

        private object GetControl(Form form, string name)
        {
            var fields = GetFields(form);
            var query = fields.Where(t => GetControlName(t) == name);
            if (query.Count() == 1)
                return query.Single();
            return null;
        }

        #region Drag
        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            treeView.DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            //if (e.KeyState == 5)
            //    e.Effect = DragDropEffects.Copy;
            //else
            e.Effect = DragDropEffects.Move;
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode dragedNode;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = treeView.PointToClient(new Point(e.X, e.Y));
                TreeNode destinationNode = treeView.GetNodeAt(pt);
                dragedNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (destinationNode != null && destinationNode != dragedNode)
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        if (dragedNode.Tag is Control && !(dragedNode.Tag is Form))
                        {
                            PersianMessageBox.Show("کامپوننت ها را نمیتوانید جابجا کنید");
                            return;
                        }
                        else if (destinationNode.Tag is Control && !(destinationNode.Tag is Form))
                        {
                            PersianMessageBox.Show("نود ها را نمی توانید زیر یک کامپوننت قرار دهید");
                            return;
                        }
                        dragedNode.Remove();
                        destinationNode.Nodes.Add(dragedNode);
                        destinationNode.EnsureVisible();
                        dragedNode.EnsureVisible();
                    }
                }
            }
        }
        #endregion

        #region Menu items
        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Parent == null)
                {
                    TreeNode newGroup = new TreeNode("گروه جدید");
                    TreeNode currentNode = treeView.SelectedNode;
                    currentNode.Remove();
                    newGroup.Nodes.Add(currentNode);
                    treeView.Nodes.Add(newGroup);
                    treeView.SelectedNode = newGroup;
                    newGroup.Expand();
                    newGroup.EnsureVisible();
                }
                else
                {
                    TreeNode newGroup = new TreeNode("گروه جدید");
                    TreeNode currentNode = treeView.SelectedNode;
                    TreeNode parent = currentNode.Parent;
                    currentNode.Remove();
                    newGroup.Nodes.Add(currentNode);
                    parent.Nodes.Add(newGroup);
                    treeView.SelectedNode = newGroup;
                    newGroup.Expand();
                    newGroup.EnsureVisible();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
                treeView.SelectedNode.Remove();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.treeView.SelectedNode == null)
                moveToLevel1ToolStripMenuItem.Enabled = cutToolStripMenuItem.Enabled = addGroupToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = false;
            else
                moveToLevel1ToolStripMenuItem.Enabled = cutToolStripMenuItem.Enabled = addGroupToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = true;
            if (treeNodeData == null)
                pasteToolStripMenuItem.Enabled = false;
            else
                pasteToolStripMenuItem.Enabled = true;
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode item in e.Node.Nodes)
            {
                item.Checked = e.Node.Checked;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckNodesForName(treeView.Nodes))
                return;

            if (this.Connection == null)
            {
                PersianMessageBox.Show("پایگاه داده مشخص نشده است");
                return;
            }


            this.DataAccess.Execute("UPDATE [AccessPermissionTree] SET [Flag]=@p", "@p", true);

            Model.MainModelDataContext dc = new Model.MainModelDataContext(this.Connection.ConnectionString);
            SaveNodes(treeView.Nodes, dc);
            dc.SubmitChanges();

            this.DataAccess.Execute("DELETE FROM [AccessPermissionTree] WHERE [Flag]=@p", "@p", true);

            PersianMessageBox.Show("ذخیره شد");
        }

        private bool CheckNodesForName(TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.GetNodeCount(true) != 0)
                {
                    if (IsAnotherNode(treeView.Nodes, node))
                    {
                        PersianMessageBox.Show("نام تکراری وجود دارد");
                        treeView.SelectedNode = node;
                        node.EnsureVisible();
                        treeView.Focus();
                        return false;
                    }
                }
                if (!CheckNodesForName(node.Nodes))
                    return false;
            }
            return true;
        }

        private bool IsAnotherNode(TreeNodeCollection nodes, TreeNode node)
        {
            foreach (TreeNode item in nodes)
            {
                if (item != node && item.GetNodeCount(true) > 0 && item.Checked)
                    if (item.Text == node.Text)
                        return true;
                if (IsAnotherNode(item.Nodes, node))
                    return true;
            }
            return false;
        }

        private void SaveNodes(TreeNodeCollection treeNodeCollection, Model.MainModelDataContext dc)
        {
            foreach (TreeNode item in treeNodeCollection)
            {
                //int code;
                //var codeQuery = dc.AccessPermissionTrees.Select(t => t.ID).ToArray();
                //if (codeQuery.Count() == 0)
                //    code = 1;
                //else
                //    code = codeQuery.Max() + 1;

                Control c = item.Tag as Control;
                Model.AccessPermissionTree entity = Model.AccessPermissionTree.GetNewInstance(c == null ? item.Text : GetControlName(c), item.Parent == null ? null : GetParentName(item), item.Text, item.Checked, false);
                int originalCode;
                if (int.TryParse(item.Name, out originalCode))
                {
                    var query = dc.AccessPermissionTrees.Where(t => t.ID == originalCode);
                    if (query.Count() == 1)
                    {
                        Model.AccessPermissionTree originalEntity = query.Single();
                        //Model.AccessPermissionTree.Copy(originalEntity, entity);
                        this.DataAccess.UpdateWithObject(entity, originalEntity);
                        //originalEntity.ID = originalCode;
                    }
                }
                else
                {
                    this.DataAccess.InsertObject(entity);
                    //dc.AccessPermissionTrees.InsertOnSubmit(entity);
                }
                dc.SubmitChanges();

                if (item.Nodes.Count > 0)
                    SaveNodes(item.Nodes, dc);
            }
        }

        private string GetParentName(TreeNode item)
        {
            if (item.Parent == null)
                return null;
            if (item.Parent.Tag is Control)
                return (item.Parent.Tag as Control).Name;
            return item.Parent.Text;
        }

        private string GetControlName(System.Windows.Forms.Control control)
        {
            string name = control.Name;
            System.Windows.Forms.Control parent = control.Parent;
            while (parent != null)
            {
                name += " " + parent.Name;
                parent = parent.Parent;
            }
            return name;
        }

        private Njit.Common.CryptoService.MD5CryptoService _MD5CryptoService;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected Njit.Common.CryptoService.MD5CryptoService MD5CryptoService
        {
            get
            {
                if (_MD5CryptoService == null)
                    _MD5CryptoService = new Njit.Common.CryptoService.MD5CryptoService();
                return _MD5CryptoService;
            }
            set
            {
                _MD5CryptoService = value;
            }
        }

        private string GetHashCode(string data)
        {
            return MD5CryptoService.ComputeHash(data);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                if (treeView.SelectedNode != null)
                {
                    PersianMessageBox.Show((treeView.SelectedNode.Tag ?? "").ToString());
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (treeView.SelectedNode != null && treeView.SelectedNode.IsEditing == false)
                    treeView.SelectedNode.BeginEdit();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (treeView.SelectedNode != null && treeView.SelectedNode.IsEditing == false)
                    treeView.SelectedNode.Remove();
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.IsSelected)
                treeView.SelectedNode = e.Node;
        }

        TreeNode treeNodeData;

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Tag is Control && !(treeView.SelectedNode.Tag is Form))
                {
                    PersianMessageBox.Show("کامپوننت ها را نمیتوانید جابجا کنید");
                    return;
                }
                treeNodeData = treeView.SelectedNode;
                treeNodeData.Remove();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                if (treeNodeData != null)
                {
                    treeView.SelectedNode.Nodes.Add(treeNodeData);
                    treeNodeData = null;
                }
            }
        }

        private void moveToLevel1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Tag is Control && !(treeView.SelectedNode.Tag is Form))
                {
                    PersianMessageBox.Show("کامپوننت ها را نمیتوانید جابجا کنید");
                    return;
                }
                TreeNode currentNode = treeView.SelectedNode;
                currentNode.Remove();
                treeView.Nodes.Add(currentNode);
                treeView.SelectedNode = currentNode;
                currentNode.EnsureVisible();
            }
        }

        private void btnDeleteAndRecreate_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("ساختار درختی ذخیره شده حذف شود؟", "تایید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                this.DataAccess.Execute("DELETE FROM [AccessPermissionTree]");
                LoadData();
            }
        }

    }
}
