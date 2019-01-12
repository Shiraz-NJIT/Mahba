using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Resources;

namespace Njit.Program.Controls.Design
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class MultiLayerPanelDesigner : ParentControlDesigner
    {
        private DesignerVerbCollection verbs;
        private DesignerVerb removeVerb, addVerb, switchVerb;
        Page selectedPage;
        bool inTransaction = false;

        private void CheckVerbStatus()
        {
            if (Control == null)
                removeVerb.Enabled = addVerb.Enabled = switchVerb.Enabled = false;
            else
            {
                addVerb.Enabled = true;
                removeVerb.Enabled = (Control.Controls.Count > 1);
                switchVerb.Enabled = (Control.Controls.Count > 1);
            }
        }

        private MultiPanePageDesigner GetSelectedPageDesigner()
        {
            Page multiPanePage = selectedPage;
            if (multiPanePage == null)
                return null;
            MultiPanePageDesigner designer = null;
            IDesignerHost srv = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (srv != null)
                designer = (MultiPanePageDesigner)srv.GetDesigner(multiPanePage);
            return designer;
        }

        private static Page GetPageOfControl(object control)
        {
            if (!(control is Control))
                return null;
            Control parent = (Control)control;
            while ((parent != null) && !(parent is Page))
                parent = parent.Parent;
            return (Page)parent;
        }

        private object Transaction_AddPage(IDesignerHost host, object param)
        {
            MultiLayerPanel ctl = DesignedControl;
            Page newPage = (Page)host.CreateComponent(typeof(Page));
            MemberDescriptor memControls = TypeDescriptor.GetProperties(ctl)["Controls"];
            RaiseComponentChanging(memControls);
            ctl.Controls.Add(newPage);
            DesignerSelectedPage = newPage;
            RaiseComponentChanged(memControls, null, null);
            return null;
        }

        private object Transaction_RemovePage(IDesignerHost theHost, object theParam)
        {
            if (selectedPage == null)
                return null;
            MultiLayerPanel aCtl = DesignedControl;
            MemberDescriptor aMember_Controls = TypeDescriptor.GetProperties(aCtl)["Controls"];
            RaiseComponentChanging(aMember_Controls);
            try
            {
                theHost.DestroyComponent(selectedPage);
            }
            catch { }
            RaiseComponentChanged(aMember_Controls, null, null);
            return null;
        }

        private object Transaction_UpdateSelectedPage(IDesignerHost theHost, object theParam)
        {
            MultiLayerPanel aCtl = DesignedControl;
            Page aPgTemp = selectedPage;
            int aCurIndex = aCtl.Controls.IndexOf(selectedPage);
            if (selectedPage == aCtl.SelectedPage)
            {
                MemberDescriptor aMember_SelectedPage = TypeDescriptor.GetProperties(aCtl)["SelectedPage"];
                RaiseComponentChanging(aMember_SelectedPage);
                if (aCtl.Controls.Count > 1)
                {
                    if (aCurIndex == aCtl.Controls.Count - 1)
                        aCtl.SelectedPage = (Page)aCtl.Controls[aCurIndex - 1];
                    else
                        aCtl.SelectedPage = (Page)aCtl.Controls[aCurIndex + 1];
                }
                else
                    aCtl.SelectedPage = null;
                RaiseComponentChanged(aMember_SelectedPage, null, null);
            }
            else
            {
                if (aCtl.Controls.Count > 1)
                {
                    if (aCurIndex == aCtl.Controls.Count - 1)
                        DesignerSelectedPage = (Page)aCtl.Controls[aCurIndex - 1];
                    else
                        DesignerSelectedPage = (Page)aCtl.Controls[aCurIndex + 1];
                }
                else
                    DesignerSelectedPage = null;
            }
            return null;
        }

        private object Transaction_SetSelectedPageAsConcrete(IDesignerHost theHost, object theParam)
        {
            MultiLayerPanel aCtl = DesignedControl;
            MemberDescriptor aMember_SelectedPage = TypeDescriptor.GetProperties(aCtl)["SelectedPage"];
            RaiseComponentChanging(aMember_SelectedPage);
            aCtl.SelectedPage = (Page)theParam;
            RaiseComponentChanged(aMember_SelectedPage, null, null);
            return null;
        }

        private void Handler_SelectedPageChanged(object theSender, EventArgs theArgs)
        {
            selectedPage = DesignedControl.SelectedPage;
        }
        private void Handler_AddPage(object theSender, EventArgs theArgs)
        {
            IDesignerHost aHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (aHost == null)
                return;
            inTransaction = true;
            DesignerTransactionUtility.DoInTransaction
            (
                aHost,
                "MultiPaneControlAddPage",
                new TransactionAwareParammedMethod(Transaction_AddPage),
                null
            );
            inTransaction = false;
        }

        private void Handler_RemovePage(object sender, EventArgs eevent)
        {
            MultiLayerPanel aCtl = DesignedControl;
            if (aCtl == null)
                return;
            else if (aCtl.Controls.Count < 1)
                return;
            IDesignerHost aHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (aHost == null)
                return;
            inTransaction = true;
            DesignerTransactionUtility.DoInTransaction
            (
                aHost,
                "MultiPaneControlRemovePage",
                new TransactionAwareParammedMethod(Transaction_RemovePage),
                null
            );
            inTransaction = false;
        }

        private void Handler_SwitchPage(object theSender, EventArgs theArgs)
        {
            MultiLayerPanelSwitchPages form = new MultiLayerPanelSwitchPages(this);
            DialogResult aRes = form.ShowDialog();
            if (aRes != DialogResult.OK)
                return;
            if (form.SetSelectedPage)
            {
                IDesignerHost aHost = (IDesignerHost)GetService(typeof(IDesignerHost));
                if (aHost != null)
                    DesignerTransactionUtility.DoInTransaction
                    (
                        aHost,
                        "MultiPaneControlSetSelectedPageAsConcrete",
                        new TransactionAwareParammedMethod(Transaction_SetSelectedPageAsConcrete),
                        form.FutureSelection
                    );
            }
            else
                DesignerSelectedPage = form.FutureSelection;
        }

        private void Handler_ComponentChanged(object theSender, ComponentChangedEventArgs theArgs)
        {
            CheckVerbStatus();
        }

        private void Handler_ComponentRemoving(object theSender, ComponentEventArgs theArgs)
        {
            if (!(theArgs.Component is Page))
                return;
            MultiLayerPanel aCtl = DesignedControl;
            Page aPg = (Page)theArgs.Component;
            if (!aCtl.Controls.Contains(aPg))
                return;
            IDesignerHost aHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (!inTransaction)
            {
                inTransaction = true;
                DesignerTransactionUtility.DoInTransaction
                (
                    aHost,
                    "MultiPaneControlRemoveComponent",
                    new TransactionAwareParammedMethod(Transaction_UpdateSelectedPage),
                    null
                );
                inTransaction = false;
            }
            else
                Transaction_UpdateSelectedPage(aHost, null);

            CheckVerbStatus();
        }

        private void Handler_SelectionChanged(object sender, EventArgs e)
        {
            ISelectionService aSrv = (ISelectionService)GetService(typeof(ISelectionService));
            if (aSrv == null)
                return;
            ICollection aSel = aSrv.GetSelectedComponents();
            MultiLayerPanel aCtl = DesignedControl;
            foreach (object aIt in aSel)
            {
                Page aPage = GetPageOfControl(aIt);
                if ((aPage != null) && (aPage.Parent == aCtl))
                {
                    DesignerSelectedPage = aPage;
                    break;
                }
            }
        }

        protected override void OnDragDrop(DragEventArgs theDragEvents)
        {
            MultiPanePageDesigner dsgnSel = GetSelectedPageDesigner();
            if (dsgnSel != null)
                dsgnSel.InternalOnDragDrop(theDragEvents);
        }

        protected override void OnDragEnter(DragEventArgs theDragEvents)
        {
            MultiPanePageDesigner aDsgn_Sel = GetSelectedPageDesigner();
            if (aDsgn_Sel != null)
                aDsgn_Sel.InternalOnDragEnter(theDragEvents);
        }

        protected override void OnDragLeave(EventArgs theArgs)
        {
            MultiPanePageDesigner aDsgn_Sel = GetSelectedPageDesigner();
            if (aDsgn_Sel != null)
                aDsgn_Sel.InternalOnDragLeave(theArgs);
        }

        protected override void OnDragOver(DragEventArgs theDragEvents)
        {
            MultiLayerPanel aCtl = DesignedControl;
            Point pt = aCtl.PointToClient(new Point(theDragEvents.X, theDragEvents.Y));

            if (!aCtl.DisplayRectangle.Contains(pt))
                theDragEvents.Effect = DragDropEffects.None;
            else
            {
                MultiPanePageDesigner aDsgn_Sel = GetSelectedPageDesigner();
                if (aDsgn_Sel != null)
                    aDsgn_Sel.InternalOnDragOver(theDragEvents);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            MultiPanePageDesigner aDsgn_Sel = GetSelectedPageDesigner();
            if (aDsgn_Sel != null)
                aDsgn_Sel.InternalOnGiveFeedback(e);
        }

        public override void Initialize(IComponent theComponent)
        {
            base.Initialize(theComponent);
            ISelectionService aSrv_Sel = (ISelectionService)GetService(typeof(ISelectionService));
            if (aSrv_Sel != null)
                aSrv_Sel.SelectionChanged += new EventHandler(Handler_SelectionChanged);
            IComponentChangeService aSrv_CH = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            if (aSrv_CH != null)
            {
                aSrv_CH.ComponentRemoving += new ComponentEventHandler(Handler_ComponentRemoving);
                aSrv_CH.ComponentChanged += new ComponentChangedEventHandler(Handler_ComponentChanged);
            }
            DesignedControl.SelectedPageChanged += new EventHandler(Handler_SelectedPageChanged);
            addVerb = new DesignerVerb("ÇÝÒæÏä ÕÝÍå", new EventHandler(Handler_AddPage));
            removeVerb = new DesignerVerb("ÍÐÝ ÕÝÍå", new EventHandler(Handler_RemovePage));
            switchVerb = new DesignerVerb("ÇäÊÎÇÈ ÕÝÍå...", new EventHandler(Handler_SwitchPage));
            verbs = new DesignerVerbCollection();
            verbs.AddRange(new DesignerVerb[] { addVerb, removeVerb, switchVerb });
        }

        protected override void Dispose(bool theDisposing)
        {
            if (theDisposing)
            {
                ISelectionService aSrv_Sel = (ISelectionService)GetService(typeof(ISelectionService));
                if (aSrv_Sel != null)
                    aSrv_Sel.SelectionChanged -= new EventHandler(Handler_SelectionChanged);
                IComponentChangeService aSrv_CH = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                if (aSrv_CH != null)
                {
                    aSrv_CH.ComponentRemoving -= new ComponentEventHandler(Handler_ComponentRemoving);
                    aSrv_CH.ComponentChanged -= new ComponentChangedEventHandler(Handler_ComponentChanged);
                }
                DesignedControl.SelectedPageChanged -= new EventHandler(Handler_SelectedPageChanged);
            }
            base.Dispose(theDisposing);
        }

        public override bool CanParent(Control theControl)
        {
            if (theControl is Page)
                return !Control.Contains(theControl);
            else
                return false;
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                return verbs;
            }
        }

        public MultiLayerPanel DesignedControl
        {
            get
            {
                return (MultiLayerPanel)Control;
            }
        }

        public Page DesignerSelectedPage
        {
            get
            {
                return selectedPage;
            }
            set
            {
                if (selectedPage != null)
                    selectedPage.Visible = false;
                selectedPage = value;
                if (selectedPage != null)
                    selectedPage.Visible = true;
            }
        }
    }

    internal class MultiPanePageDesigner : ScrollableControlDesigner
    {
        private Pen
            myBorderPen_Light,
            myBorderPen_Dark;
        private int myOrigX = -1;
        private int myOrigY = -1;
        private bool myMouseMovement = false;
        protected override void Dispose(bool theDisposing)
        {
            if (theDisposing)
            {
                if (myBorderPen_Dark != null)
                    myBorderPen_Dark.Dispose();

                if (myBorderPen_Light != null)
                    myBorderPen_Light.Dispose();
            }

            base.Dispose(theDisposing);
        }

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            //DrawBorder(pe.Graphics);
            base.OnPaintAdornments(pe);
        }

        public override bool CanBeParentedTo(IDesigner theParentDesigner)
        {
            if (theParentDesigner != null)
                return (theParentDesigner.Component is MultiLayerPanel);

            else
                return false;
        }

        protected override bool GetHitTest(System.Drawing.Point pt)
        {
            return false;
        }

        protected override void OnMouseDragBegin(int theX, int theY)
        {
            myOrigX = theX;
            myOrigY = theY;
        }

        protected override void OnMouseDragMove(int theX, int theY)
        {
            if (theX > myOrigX + 3 || theX < myOrigX - 3 ||
                     theY > myOrigY + 3 || theY < myOrigY - 3)
            {
                myMouseMovement = true;

                base.OnMouseDragBegin(myOrigX, myOrigY);
                base.OnMouseDragMove(theX, theY);
            }
        }

        protected override void OnMouseDragEnd(bool theCancel)
        {
            bool aProcess = !myMouseMovement && Control.Parent != null;
            if (aProcess)
            {
                ISelectionService aSrv = (ISelectionService)GetService(typeof(ISelectionService));

                if (aSrv != null)
                    aSrv.SetSelectedComponents(new Control[] { Control.Parent });
                else
                    aProcess = false;
            }

            if (!aProcess)
                base.OnMouseDragEnd(theCancel);

            myMouseMovement = false;
        }

        private Pen InternalEnsureDarkPenCreated()
        {
            if (myBorderPen_Dark == null)
                myBorderPen_Dark = InternalCreatePen(Color.Black);
            return myBorderPen_Dark;
        }

        private Pen InternalEnsureLightPenCreated()
        {
            if (myBorderPen_Light == null)
                myBorderPen_Light = InternalCreatePen(Color.White);
            return myBorderPen_Light;
        }

        private static Pen InternalCreatePen(Color theClr)
        {
            Pen aPen = new Pen(theClr);
            aPen.DashStyle = DashStyle.Dash;
            return aPen;
        }

        internal void InternalOnDragDrop(DragEventArgs theArgs)
        {
            OnDragDrop(theArgs);
        }

        internal void InternalOnDragEnter(DragEventArgs theArgs)
        {
            OnDragEnter(theArgs);
        }

        internal void InternalOnDragLeave(EventArgs theArgs)
        {
            OnDragLeave(theArgs);
        }

        internal void InternalOnGiveFeedback(GiveFeedbackEventArgs theArgs)
        {
            OnGiveFeedback(theArgs);
        }

        internal void InternalOnDragOver(DragEventArgs theArgs)
        {
            OnDragOver(theArgs);
        }

        protected void DrawBorder(Graphics theG)
        {
            Page ctl = DesignedControl;
            if (ctl == null)
                return;
            else if (!ctl.Visible)
                return;
            Rectangle aRct = ctl.ClientRectangle;
            aRct.Width--;
            aRct.Height--;
            theG.DrawRectangle(BorderPen, aRct);
        }

        private MultiLayerPanelDesigner GetParentControlDesigner()
        {
            MultiLayerPanelDesigner aDesigner = null;
            if (Control != null)
                if (Control.Parent != null)
                {
                    IDesignerHost aSrv = (IDesignerHost)GetService(typeof(IDesignerHost));
                    if (aSrv != null)
                        aDesigner = (MultiLayerPanelDesigner)aSrv.GetDesigner(Control.Parent);
                }

            return aDesigner;
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules aSelRules = base.SelectionRules;

                if (Control.Parent is MultiLayerPanel)
                    aSelRules &= ~SelectionRules.AllSizeable; // do not allow any handlers

                return aSelRules;
            }
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection aRet = new DesignerVerbCollection();
                foreach (DesignerVerb aIt in base.Verbs)
                    aRet.Add(aIt);
                MultiLayerPanelDesigner aDs = GetParentControlDesigner();
                if (aDs != null)
                    foreach (DesignerVerb aIt in aDs.Verbs)
                        aRet.Add(aIt);
                return aRet;
            }
        }

        protected Page DesignedControl
        {
            get
            {
                return (Page)Control;
            }
        }

        protected Pen BorderPen
        {
            get
            {
                if (Control.BackColor.GetBrightness() < 0.5)
                    return InternalEnsureLightPenCreated();
                else
                    return InternalEnsureDarkPenCreated();
            }
        }
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [Serializable]
    public class MultiPaneControlToolboxItem : ToolboxItem
    {
        public MultiPaneControlToolboxItem()
            : base(typeof(MultiLayerPanel))
        {
        }

        public MultiPaneControlToolboxItem(SerializationInfo theInfo, StreamingContext theContext)
        {
            Deserialize(theInfo, theContext);
        }

        protected override IComponent[] CreateComponentsCore(IDesignerHost theHost)
        {
            return DesignerTransactionUtility.DoInTransaction
            (
                theHost,
                "MultiPaneControlTooblxItem_CreateControl",
                new TransactionAwareParammedMethod(CreateControlWithOnePage),
                null
            ) as IComponent[];
        }

        public object CreateControlWithOnePage(IDesignerHost theHost, object theParam)
        {
            MultiLayerPanel aCtl = (MultiLayerPanel)theHost.CreateComponent(typeof(MultiLayerPanel));
            Page aPg = (Page)theHost.CreateComponent(typeof(Page));
            aCtl.Controls.Add(aPg);
            return new IComponent[] { aCtl };
        }
    }

    internal class MultiPaneControlSelectedPageEditor : ObjectSelectorEditor
    {
        protected override void FillTreeWithData(Selector theSel,
            ITypeDescriptorContext theCtx, IServiceProvider theProvider)
        {
            base.FillTreeWithData(theSel, theCtx, theProvider);
            MultiLayerPanel aCtl = (MultiLayerPanel)theCtx.Instance;
            foreach (Page aIt in aCtl.Controls)
            {
                SelectorNode aNd = new SelectorNode(aIt.Name, aIt);

                theSel.Nodes.Add(aNd);

                if (aIt == aCtl.SelectedPage)
                    theSel.SelectedNode = aNd;
            }
        }
    }
}
