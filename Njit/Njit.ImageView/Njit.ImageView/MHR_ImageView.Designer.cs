using KaiwaProjects;

namespace Njit.ImageView
{
    partial class MHR_ImageView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            DisposeControl();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPreview = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbZoom = new System.Windows.Forms.ComboBox();
            this.btnFitToScreen = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnRotate270 = new System.Windows.Forms.Button();
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.lblNavigation = new System.Windows.Forms.Label();
            this.tbNavigation = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.pbPanel = new System.Windows.Forms.PictureBox();
            this.btnError = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmTitile = new System.Windows.Forms.ComboBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPerssonel = new System.Windows.Forms.TextBox();
            this.pbFull = new KaiwaProjects.PanelDoubleBuffered();
            this.sbHoriz = new System.Windows.Forms.HScrollBar();
            this.sbPanel = new System.Windows.Forms.Panel();
            this.sbVert = new System.Windows.Forms.VScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.panelPreview.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanel)).BeginInit();
            this.pbFull.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreview.Controls.Add(this.lblPreview);
            this.panelPreview.Location = new System.Drawing.Point(815, 0);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(140, 28);
            this.panelPreview.TabIndex = 12;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPreview.Location = new System.Drawing.Point(3, -1);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(59, 18);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Preview";
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.btnBack2);
            this.panelMenu.Controls.Add(this.btnNext2);
            this.panelMenu.Controls.Add(this.btnSave);
            this.panelMenu.Controls.Add(this.btnPrint);
            this.panelMenu.Controls.Add(this.btnMode);
            this.panelMenu.Controls.Add(this.btnPreview);
            this.panelMenu.Controls.Add(this.cbZoom);
            this.panelMenu.Controls.Add(this.btnFitToScreen);
            this.panelMenu.Controls.Add(this.btnZoomIn);
            this.panelMenu.Controls.Add(this.btnZoomOut);
            this.panelMenu.Controls.Add(this.btnRotate270);
            this.panelMenu.Controls.Add(this.btnRotate90);
            this.panelMenu.Controls.Add(this.btnOpen);
            this.panelMenu.Location = new System.Drawing.Point(15, -1);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(800, 29);
            this.panelMenu.TabIndex = 11;
            // 
            // btnBack2
            // 
            this.btnBack2.Image = global::Njit.ImageView.Properties.Resources.btnBack;
            this.btnBack2.Location = new System.Drawing.Point(281, 1);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(23, 25);
            this.btnBack2.TabIndex = 20;
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // btnNext2
            // 
            this.btnNext2.Image = global::Njit.ImageView.Properties.Resources.btnNext;
            this.btnNext2.Location = new System.Drawing.Point(312, 1);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(23, 25);
            this.btnNext2.TabIndex = 19;
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Njit.ImageView.Properties.Resources.btnOpen;
            this.btnSave.Location = new System.Drawing.Point(250, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 25);
            this.btnSave.TabIndex = 18;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Njit.ImageView.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(224, 1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 25);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "پرینت";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMode
            // 
            this.btnMode.Image = global::Njit.ImageView.Properties.Resources.btnSelect;
            this.btnMode.Location = new System.Drawing.Point(139, 1);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(33, 25);
            this.btnMode.TabIndex = 16;
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::Njit.ImageView.Properties.Resources.btnPreview;
            this.btnPreview.Location = new System.Drawing.Point(198, 1);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(23, 25);
            this.btnPreview.TabIndex = 15;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cbZoom
            // 
            this.cbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZoom.FormattingEnabled = true;
            this.cbZoom.Location = new System.Drawing.Point(733, 3);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(60, 21);
            this.cbZoom.TabIndex = 14;
            this.cbZoom.SelectedIndexChanged += new System.EventHandler(this.cbZoom_SelectedIndexChanged);
            this.cbZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbZoom_KeyPress);
            // 
            // btnFitToScreen
            // 
            this.btnFitToScreen.Image = global::Njit.ImageView.Properties.Resources.btnFitToScreen;
            this.btnFitToScreen.Location = new System.Drawing.Point(58, 1);
            this.btnFitToScreen.Name = "btnFitToScreen";
            this.btnFitToScreen.Size = new System.Drawing.Size(23, 25);
            this.btnFitToScreen.TabIndex = 13;
            this.btnFitToScreen.UseVisualStyleBackColor = true;
            this.btnFitToScreen.Click += new System.EventHandler(this.btnFitToScreen_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = global::Njit.ImageView.Properties.Resources.btnZoomIn;
            this.btnZoomIn.Location = new System.Drawing.Point(2, 1);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 25);
            this.btnZoomIn.TabIndex = 12;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::Njit.ImageView.Properties.Resources.btnZoomOut;
            this.btnZoomOut.Location = new System.Drawing.Point(30, 1);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 25);
            this.btnZoomOut.TabIndex = 11;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnRotate270
            // 
            this.btnRotate270.Image = global::Njit.ImageView.Properties.Resources.btnRotate270;
            this.btnRotate270.Location = new System.Drawing.Point(86, 1);
            this.btnRotate270.Name = "btnRotate270";
            this.btnRotate270.Size = new System.Drawing.Size(23, 25);
            this.btnRotate270.TabIndex = 10;
            this.btnRotate270.UseVisualStyleBackColor = true;
            this.btnRotate270.Click += new System.EventHandler(this.btnRotate270_Click);
            // 
            // btnRotate90
            // 
            this.btnRotate90.Image = global::Njit.ImageView.Properties.Resources.btnRotate90;
            this.btnRotate90.Location = new System.Drawing.Point(114, 1);
            this.btnRotate90.Name = "btnRotate90";
            this.btnRotate90.Size = new System.Drawing.Size(23, 25);
            this.btnRotate90.TabIndex = 9;
            this.btnRotate90.UseVisualStyleBackColor = true;
            this.btnRotate90.Click += new System.EventHandler(this.btnRotate90_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::Njit.ImageView.Properties.Resources.btnOpen;
            this.btnOpen.Location = new System.Drawing.Point(173, 1);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 25);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Visible = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // panelNavigation
            // 
            this.panelNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNavigation.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNavigation.Controls.Add(this.lblNavigation);
            this.panelNavigation.Controls.Add(this.tbNavigation);
            this.panelNavigation.Controls.Add(this.btnBack);
            this.panelNavigation.Controls.Add(this.btnNext);
            this.panelNavigation.Location = new System.Drawing.Point(815, 147);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(140, 29);
            this.panelNavigation.TabIndex = 13;
            this.panelNavigation.Visible = false;
            // 
            // lblNavigation
            // 
            this.lblNavigation.AutoSize = true;
            this.lblNavigation.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavigation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNavigation.Location = new System.Drawing.Point(41, 4);
            this.lblNavigation.Name = "lblNavigation";
            this.lblNavigation.Size = new System.Drawing.Size(24, 18);
            this.lblNavigation.TabIndex = 1;
            this.lblNavigation.Text = "/ 0";
            // 
            // tbNavigation
            // 
            this.tbNavigation.Location = new System.Drawing.Point(4, 4);
            this.tbNavigation.Name = "tbNavigation";
            this.tbNavigation.Size = new System.Drawing.Size(31, 20);
            this.tbNavigation.TabIndex = 19;
            this.tbNavigation.Text = "0";
            this.tbNavigation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNavigation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNavigation_KeyPress);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(93, 1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 25);
            this.btnBack.TabIndex = 18;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(121, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 25);
            this.btnNext.TabIndex = 17;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtWarning
            // 
            this.txtWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarning.Location = new System.Drawing.Point(815, 378);
            this.txtWarning.Multiline = true;
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWarning.Size = new System.Drawing.Size(140, 139);
            this.txtWarning.TabIndex = 20;
            // 
            // pbPanel
            // 
            this.pbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPanel.Location = new System.Drawing.Point(815, 34);
            this.pbPanel.Name = "pbPanel";
            this.pbPanel.Size = new System.Drawing.Size(140, 110);
            this.pbPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPanel.TabIndex = 10;
            this.pbPanel.TabStop = false;
            this.pbPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseDown);
            this.pbPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseMove);
            this.pbPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseUp);
            // 
            // btnError
            // 
            this.btnError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnError.Image = global::Njit.ImageView.Properties.Resources.warning;
            this.btnError.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnError.Location = new System.Drawing.Point(815, 523);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(140, 23);
            this.btnError.TabIndex = 15;
            this.btnError.Text = "اعلام خرابی سند";
            this.btnError.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(819, 298);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "عنوان خرابی:";
            // 
            // cmTitile
            // 
            this.cmTitile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmTitile.FormattingEnabled = true;
            this.cmTitile.Items.AddRange(new object[] {
            "شماره نامه",
            "تاریخ نامه",
            "مخاطب نامه",
            "عنوان نامه",
            "اقدام کننده",
            "متفرقه"});
            this.cmTitile.Location = new System.Drawing.Point(815, 324);
            this.cmTitile.Name = "cmTitile";
            this.cmTitile.Size = new System.Drawing.Size(140, 21);
            this.cmTitile.TabIndex = 17;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(960, 768);
            this.shapeContainer1.TabIndex = 21;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 821;
            this.lineShape3.X2 = 952;
            this.lineShape3.Y1 = 295;
            this.lineShape3.Y2 = 295;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 820;
            this.lineShape2.X2 = 951;
            this.lineShape2.Y1 = 178;
            this.lineShape2.Y2 = 178;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(813, 182);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(140, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "نام و نام خانوادگی:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(813, 225);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "شماره پرسنلی:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.HideSelection = false;
            this.txtName.Location = new System.Drawing.Point(822, 204);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(127, 20);
            this.txtName.TabIndex = 24;
            // 
            // txtPerssonel
            // 
            this.txtPerssonel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerssonel.HideSelection = false;
            this.txtPerssonel.Location = new System.Drawing.Point(822, 253);
            this.txtPerssonel.Name = "txtPerssonel";
            this.txtPerssonel.ReadOnly = true;
            this.txtPerssonel.Size = new System.Drawing.Size(127, 20);
            this.txtPerssonel.TabIndex = 25;
            // 
            // pbFull
            // 
            this.pbFull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFull.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFull.Controls.Add(this.sbHoriz);
            this.pbFull.Controls.Add(this.sbPanel);
            this.pbFull.Controls.Add(this.sbVert);
            this.pbFull.Location = new System.Drawing.Point(13, 35);
            this.pbFull.Name = "pbFull";
            this.pbFull.Size = new System.Drawing.Size(800, 730);
            this.pbFull.TabIndex = 0;
            this.pbFull.Click += new System.EventHandler(this.pbFull_Click);
            this.pbFull.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbFull_DragDrop);
            this.pbFull.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbFull_DragEnter);
            this.pbFull.Paint += new System.Windows.Forms.PaintEventHandler(this.pbFull_Paint);
            this.pbFull.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseDoubleClick);
            this.pbFull.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseDown);
            this.pbFull.MouseEnter += new System.EventHandler(this.pbFull_MouseEnter);
            this.pbFull.MouseLeave += new System.EventHandler(this.pbFull_MouseLeave);
            this.pbFull.MouseHover += new System.EventHandler(this.pbFull_MouseHover);
            this.pbFull.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseMove);
            this.pbFull.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseUp);
            // 
            // sbHoriz
            // 
            this.sbHoriz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbHoriz.Location = new System.Drawing.Point(0, 1438);
            this.sbHoriz.Name = "sbHoriz";
            this.sbHoriz.Size = new System.Drawing.Size(622, 17);
            this.sbHoriz.TabIndex = 1;
            this.sbHoriz.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbHoriz_Scroll);
            // 
            // sbPanel
            // 
            this.sbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbPanel.BackColor = System.Drawing.SystemColors.Info;
            this.sbPanel.Location = new System.Drawing.Point(613, 712);
            this.sbPanel.Name = "sbPanel";
            this.sbPanel.Size = new System.Drawing.Size(14, 16);
            this.sbPanel.TabIndex = 2;
            // 
            // sbVert
            // 
            this.sbVert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbVert.Location = new System.Drawing.Point(784, -2);
            this.sbVert.Name = "sbVert";
            this.sbVert.Size = new System.Drawing.Size(15, 1439);
            this.sbVert.TabIndex = 0;
            this.sbVert.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbVert_Scroll);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label4.Location = new System.Drawing.Point(813, 348);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(140, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "توضیحات:";
            // 
            // MHR_ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPerssonel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmTitile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.txtWarning);
            this.Controls.Add(this.pbFull);
            this.Controls.Add(this.pbPanel);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.shapeContainer1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(960, 768);
            this.Name = "MHR_ImageView";
            this.Size = new System.Drawing.Size(960, 768);
            this.Load += new System.EventHandler(this.KP_ImageViewerV2_Load);
            this.Click += new System.EventHandler(this.MHR_ImageView_Click);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.KP_ImageViewerV2_MouseWheel);
            this.Resize += new System.EventHandler(this.KP_ImageViewerV2_Resize);
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            this.panelNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanel)).EndInit();
            this.pbFull.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pbPanel;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRotate270;
        private System.Windows.Forms.Button btnRotate90;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnFitToScreen;
        private System.Windows.Forms.ComboBox cbZoom;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Panel sbPanel;
        private System.Windows.Forms.HScrollBar sbHoriz;
        private System.Windows.Forms.VScrollBar sbVert;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack2;
        private System.Windows.Forms.Button btnNext2;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbNavigation;
        private System.Windows.Forms.Label lblNavigation;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.TextBox txtWarning;
        private PanelDoubleBuffered pbFull;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmTitile;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPerssonel;
        private System.Windows.Forms.Label label4;
    }
}
