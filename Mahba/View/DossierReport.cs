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
    public partial class DossierReport : Njit.Program.Forms.ListForm
    {
        public DossierReport()
        {
            InitializeComponent();
        }

        private static DossierReport _Instance;
        public static DossierReport Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DossierReport();
                if (_Instance.IsDisposed)
                    _Instance = new DossierReport();
                return _Instance;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadFields();
            RefreshReports();
        }

        private void LoadFields()
        {
            List<Model.Archive.ArchiveTab> archiveTabs = Controller.Archive.ArchiveTabController.GetActiveArchiveTabs();
            foreach (var tab in archiveTabs.Where(t => t.TypeCode == 1))
            {
                TreeNode tabNode = dossierFieldsTreeView.Nodes.Add(tab.Title);
                tabNode.Tag = tab;
                foreach (var field in Controller.Archive.ArchiveTabController.GetArchiveFieldsThatIsNotSubGroup(tab.ID))
                {
                    TreeNode fieldNode = tabNode.Nodes.Add(field.Label);
                    fieldNode.Tag = field;
                }
                dossierFieldsTreeView.ExpandAll();
            }
            foreach (var tab in archiveTabs.Where(t => t.TypeCode == 2))
            {
                TreeNode tabNode = documentsFieldsTreeView.Nodes.Add(tab.Title);
                tabNode.Tag = tab;
                foreach (var field in Controller.Archive.ArchiveTabController.GetArchiveFieldsThatIsNotSubGroup(tab.ID))
                {
                    TreeNode fieldNode = tabNode.Nodes.Add(field.Label);
                    fieldNode.Tag = field;
                }
                documentsFieldsTreeView.ExpandAll();
            }
        }

        Njit.Common.Popup.Popup popup;
        Controls.DossierSearchBoxPopup control;

        private void dossierFieldsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Model.Archive.ArchiveField)
            {
                if (control != null)
                    control.Dispose();
                if (popup != null)
                {
                    popup.Close();
                    popup.Dispose();
                }
                control = new Controls.DossierSearchBoxPopup(e.Node.Tag as Model.Archive.ArchiveField, queryTreeView.Nodes.Count > 0);
                control.OK += controlOK;
                popup = new Njit.Common.Popup.Popup(control, true, true, true, false, Njit.Common.Popup.PopupAnimations.Slide | Njit.Common.Popup.PopupAnimations.TopToBottom, 200, Njit.Common.Popup.PopupAnimations.Blend, 150);
                popup.Show(Form.MousePosition.X - control.Width, Form.MousePosition.Y);
            }
        }

        private void controlOK(object sender, Controls.DossierSearchBoxPopup.OkEventArgs e)
        {
            if (e.CreateNewFilter)
            {
                TreeNode node = queryTreeView.Nodes.Add(e.SearchField.ToString());
                node.Tag = e.SearchField;
                queryTreeView.SelectedNode = node;
            }
            else
            {
                if (queryTreeView.SelectedNode == null)
                {
                    PersianMessageBox.Show(this, "هیچ شرطی انتخاب نشده است ");
                    return;
                }
                TreeNode node = queryTreeView.SelectedNode.Nodes.Add(e.SearchField.ToString());
                node.Tag = e.SearchField;
                queryTreeView.SelectedNode.Expand();
            }
        }

        private void controlOKForEdit(object sender, Controls.DossierSearchBoxPopup.OkEventArgs e)
        {
            queryTreeView.SelectedNode.Tag = e.SearchField;
            queryTreeView.SelectedNode.Text = e.SearchField.ToString();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (queryTreeView.SelectedNode != null && queryTreeView.SelectedNode.Tag is SearchField)
            {
                EditFilter(queryTreeView.SelectedNode);
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            queryTreeView.Nodes.Remove(queryTreeView.SelectedNode);
        }

        private void contextMenuStripFilter_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemDeleteFilter.Enabled = toolStripMenuItemEditFilter.Enabled = (queryTreeView.SelectedNode != null);
        }

        private void queryTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                queryTreeView.SelectedNode = e.Node;
        }

        private void queryTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode treeNode = e.Item as TreeNode;
            if (treeNode != null)
                queryTreeView.DoDragDrop(treeNode, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void queryTreeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode dragedNode;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode destinationNode = queryTreeView.GetNodeAt(queryTreeView.PointToClient(new Point(e.X, e.Y)));
                dragedNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (destinationNode != null && destinationNode != dragedNode)
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        destinationNode.Nodes.Add((TreeNode)dragedNode.Clone());
                        dragedNode.Remove();
                        destinationNode.ExpandAll();
                    }
                    else if (e.Effect == DragDropEffects.Copy)
                    {
                        destinationNode.Nodes.Add((TreeNode)dragedNode.Clone());
                        destinationNode.ExpandAll();
                    }
                }
                else if (destinationNode == null)
                {
                    if (e.Effect == DragDropEffects.Move)
                    {
                        queryTreeView.Nodes.Add((TreeNode)dragedNode.Clone());
                        dragedNode.Remove();
                        queryTreeView.ExpandAll();
                    }
                    else if (e.Effect == DragDropEffects.Copy)
                    {
                        queryTreeView.Nodes.Add((TreeNode)dragedNode.Clone());
                        queryTreeView.ExpandAll();
                    }
                }
                if ((queryTreeView.Nodes[0].Tag as SearchField).Relation != SearchField.Relations.None)
                {
                    SetAllEmptyRelationsToAnd(queryTreeView.Nodes);
                    SearchField searchField = queryTreeView.Nodes[0].Tag as SearchField;
                    searchField.Relation = SearchField.Relations.None;
                    queryTreeView.Nodes[0].Tag = searchField;
                    queryTreeView.Nodes[0].Text = searchField.ToString();
                }
            }
        }

        private void SetAllEmptyRelationsToAnd(TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode item in treeNodeCollection)
            {
                SearchField searchField = item.Tag as SearchField;
                if (searchField.Relation == SearchField.Relations.None)
                {
                    searchField.Relation = SearchField.Relations.And;
                    item.Tag = searchField;
                    item.Text = searchField.ToString();
                }
                SetAllEmptyRelationsToAnd(item.Nodes);
            }
        }

        private void queryTreeView_DragOver(object sender, DragEventArgs e)
        {
            TreeNode dragedNode;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode destinationNode = queryTreeView.GetNodeAt(queryTreeView.PointToClient(new Point(e.X, e.Y)));
                dragedNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if ((destinationNode != null && destinationNode != dragedNode) || (destinationNode == null))
                {
                    if (e.KeyState == 9)
                        e.Effect = DragDropEffects.Copy;
                    else
                        e.Effect = DragDropEffects.Move;
                }
                else
                    e.Effect = DragDropEffects.None;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (savedReportsListBox.SelectedIndex == 0)
                ClearAll();
            else
                savedReportsListBox.SelectedIndex = 0;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            string name;
            using (Njit.Program.Forms.GetValue f = new Njit.Program.Forms.GetValue("نام گزارش", "نام گزارش را وارد کنید"))
            {
                if (savedReportsListBox.SelectedIndex > 0)
                {
                    f.Value = savedReportsListBox.SelectedItem.ToString();
                }
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    name = f.Value;
                else
                    return;
            }

            Model.Archive.Report report = null;
            try
            {
                List<SearchField> searchFields = new List<SearchField>();
                AddToSearchFields(searchFields, queryTreeView.Nodes);
                List<Model.Archive.ArchiveField> displayFields = new List<Model.Archive.ArchiveField>();
                AddToDisplayFields(displayFields, dossierFieldsTreeView.Nodes);
                AddToDisplayFields(displayFields, documentsFieldsTreeView.Nodes);
                report = Controller.Archive.ReportController.AddReport(name, searchFields, displayFields);
            }
            catch (Exception ex)
            {
                PersianMessageBox.Show(this, "خطا در ثبت اطلاعات" + "\r\n\r\n" + ex.Message);
                return;
            }
            RefreshReports(report.ID);
        }

        private void RefreshReports(int selectedID = -1)
        {
            savedReportsListBox.SelectedIndexChanged -= SavedReportsListBoxSelectedIndexChanged;
            savedReportsListBox.Items.Clear();
            savedReportsListBox.Items.Add(Model.Archive.Report.GetNewInstance(-1, ""));
            foreach (Model.Archive.Report report in Controller.Archive.ReportController.GetReports())
                savedReportsListBox.Items.Add(report);
            foreach (var item in savedReportsListBox.Items)
            {
                if ((item as Model.Archive.Report).ID == selectedID)
                {
                    savedReportsListBox.SelectedItem = item;
                    savedReportsListBox.SelectedIndexChanged += SavedReportsListBoxSelectedIndexChanged;
                    return;
                }
            }
            savedReportsListBox.SelectedIndexChanged += SavedReportsListBoxSelectedIndexChanged;
        }

        private void viewToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<SearchField> searchFields = new List<SearchField>();
                AddToSearchFields(searchFields, queryTreeView.Nodes);
                List<Model.Archive.ArchiveField> displayFields = new List<Model.Archive.ArchiveField>();
                if (tabControlFields.SelectedTab == tabPageDossier)
                    AddToDisplayFields(displayFields, dossierFieldsTreeView.Nodes);
                else
                    AddToDisplayFields(displayFields, documentsFieldsTreeView.Nodes);
                using (View.DossierReportView form = new DossierReportView(searchFields, displayFields, (tabControlFields.SelectedTab == tabPageDossier) ? DossierReportView.DisplayTypes.Dossier : DossierReportView.DisplayTypes.Document))
                {
                    form.ShowDialog();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AddToDisplayFields(List<Model.Archive.ArchiveField> displayFields, TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if ((node.Tag is Model.Archive.ArchiveField) && node.Checked)
                {
                    Model.Archive.ArchiveField f = node.Tag as Model.Archive.ArchiveField;
                    displayFields.Add(f);
                }
                AddToDisplayFields(displayFields, node.Nodes);
            }
        }

        private void AddToSearchFields(List<SearchField> searchFields, TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                SearchField f = node.Tag as SearchField;
                f.SearchFields = new List<SearchField>();
                AddToSearchFields(f.SearchFields, node.Nodes);
                searchFields.Add(f);
            }
        }

        private void SavedReportsListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedReport();
        }

        private void LoadSelectedReport()
        {
            if (savedReportsListBox.SelectedIndex > 0)
            {
                queryTreeView.Nodes.Clear();
                IEnumerable<SearchField> searchFields = Controller.Archive.ReportController.LoadReport((savedReportsListBox.SelectedItem as Model.Archive.Report).ID);
                foreach (SearchField item in searchFields)
                {
                    TreeNode node = queryTreeView.Nodes.Add(item.ToString());
                    node.Tag = item;
                    AddNodes(node, item);
                    node.ExpandAll();
                }
                List<Model.Archive.ArchiveField> displayFields = Controller.Archive.DisplayFieldController.GetDisplayFields((savedReportsListBox.SelectedItem as Model.Archive.Report).ID);
                CheckNodes(dossierFieldsTreeView.Nodes, displayFields);
                CheckNodes(documentsFieldsTreeView.Nodes, displayFields);
            }
            else
            {
                ClearAll();
            }
        }

        private void ClearAll()
        {
            queryTreeView.Nodes.Clear();
            SetNodesCheck(dossierFieldsTreeView.Nodes, false);
            SetNodesCheck(documentsFieldsTreeView.Nodes, false);
        }

        private void SetNodesCheck(TreeNodeCollection treeNodeCollection, bool value)
        {
            foreach (TreeNode n in treeNodeCollection)
            {
                n.Checked = value;
                SetNodesCheck(n.Nodes, value);
            }
        }

        private void CheckNodes(TreeNodeCollection treeNodeCollection, List<Model.Archive.ArchiveField> displayFields)
        {
            foreach (TreeNode n in treeNodeCollection)
            {
                Model.Archive.ArchiveField f = n.Tag as Model.Archive.ArchiveField;
                if (f != null && displayFields.Contains(f))
                    n.Checked = true;
                else
                    n.Checked = false;
                CheckNodes(n.Nodes, displayFields);
            }
        }

        private void AddNodes(TreeNode node, SearchField item)
        {
            foreach (SearchField f in item.SearchFields)
            {
                TreeNode newnode = node.Nodes.Add(f.ToString());
                newnode.Tag = f;
                AddNodes(newnode, f);
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (savedReportsListBox.SelectedIndex > 0)
            {
                var res = PersianMessageBox.Show(this, string.Format("گزارش '{0}' حذف شود؟", savedReportsListBox.SelectedItem.ToString()), "تایید حذف گزارش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Controller.Archive.ReportController.DeleteReport((savedReportsListBox.SelectedItem as Model.Archive.Report).ID);
                        RefreshReports();
                        LoadSelectedReport();
                    }
                    catch (Exception ex)
                    {
                        PersianMessageBox.Show(this, "خطا در حذف گزارش" + "\r\n\r\n" + ex.Message);
                    }
                }
            }
        }

        private void queryTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (queryTreeView.SelectedNode != null && queryTreeView.SelectedNode.Tag is SearchField)
            {
                EditFilter(queryTreeView.SelectedNode);
            }
        }

        private void EditFilter(TreeNode treeNode)
        {
            if (control != null)
                control.Dispose();
            if (popup != null)
            {
                popup.Close();
                popup.Dispose();
            }
            control = new Controls.DossierSearchBoxPopup(treeNode.Tag as SearchField);
            control.OK += controlOKForEdit;
            popup = new Njit.Common.Popup.Popup(control, true, true, true, false, Njit.Common.Popup.PopupAnimations.Blend, 250, Njit.Common.Popup.PopupAnimations.Blend, 250);
            popup.Show(Form.MousePosition.X - control.Width, Form.MousePosition.Y);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
