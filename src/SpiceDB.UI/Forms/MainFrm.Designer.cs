namespace SpiceDB.UI
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.lblLoadingData = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SNo = new System.Windows.Forms.ColumnHeader();
            this.RescourceType = new System.Windows.Forms.ColumnHeader();
            this.RescourceId = new System.Windows.Forms.ColumnHeader();
            this.Relation = new System.Windows.Forms.ColumnHeader();
            this.SubjectType = new System.Windows.Forms.ColumnHeader();
            this.SubjectId = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnSchema = new System.Windows.Forms.ToolStripButton();
            this.btnAddRelation = new System.Windows.Forms.ToolStripButton();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnOpenTreeViewDesigner = new System.Windows.Forms.ToolStripButton();
            this.btnChangeTreeLayout = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Blank.PNG");
            this.imageList1.Images.SetKeyName(1, "truck.PNG");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Location = new System.Drawing.Point(11, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblLoadingData);
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(1186, 421);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 12;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(392, 421);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // lblLoadingData
            // 
            this.lblLoadingData.AutoEllipsis = true;
            this.lblLoadingData.AutoSize = true;
            this.lblLoadingData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblLoadingData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoadingData.Location = new System.Drawing.Point(225, 218);
            this.lblLoadingData.Name = "lblLoadingData";
            this.lblLoadingData.Padding = new System.Windows.Forms.Padding(10);
            this.lblLoadingData.Size = new System.Drawing.Size(150, 41);
            this.lblLoadingData.TabIndex = 14;
            this.lblLoadingData.Text = "Loading Data . . . .";
            this.lblLoadingData.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SNo,
            this.RescourceType,
            this.RescourceId,
            this.Relation,
            this.SubjectType,
            this.SubjectId});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(790, 421);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // SNo
            // 
            this.SNo.Text = "SNo";
            // 
            // RescourceType
            // 
            this.RescourceType.Text = "Rescource Type";
            this.RescourceType.Width = 120;
            // 
            // RescourceId
            // 
            this.RescourceId.Text = "Rescource Id";
            this.RescourceId.Width = 120;
            // 
            // Relation
            // 
            this.Relation.Text = "Relation";
            this.Relation.Width = 120;
            // 
            // SubjectType
            // 
            this.SubjectType.Text = "Subject Type";
            this.SubjectType.Width = 120;
            // 
            // SubjectId
            // 
            this.SubjectId.Text = "Subject Id";
            this.SubjectId.Width = 120;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnSchema,
            this.btnAddRelation,
            this.btnTest,
            this.btnImport,
            this.btnExport,
            this.btnOpenTreeViewDesigner,
            this.btnChangeTreeLayout,
            this.btnRefresh,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1209, 34);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Padding = new System.Windows.Forms.Padding(5);
            this.btnConnect.Size = new System.Drawing.Size(69, 31);
            this.btnConnect.Text = "Connect";
            this.btnConnect.ToolTipText = "Connect To SpiceDB Server";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSchema
            // 
            this.btnSchema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSchema.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSchema.Image = ((System.Drawing.Image)(resources.GetObject("btnSchema.Image")));
            this.btnSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSchema.Name = "btnSchema";
            this.btnSchema.Padding = new System.Windows.Forms.Padding(5);
            this.btnSchema.Size = new System.Drawing.Size(98, 31);
            this.btnSchema.Text = "View Schema";
            this.btnSchema.Click += new System.EventHandler(this.btnSchema_Click);
            // 
            // btnAddRelation
            // 
            this.btnAddRelation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddRelation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddRelation.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRelation.Image")));
            this.btnAddRelation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRelation.Name = "btnAddRelation";
            this.btnAddRelation.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddRelation.Size = new System.Drawing.Size(97, 31);
            this.btnAddRelation.Text = "Add Relation";
            this.btnAddRelation.Click += new System.EventHandler(this.btnAddRelation_Click);
            // 
            // btnTest
            // 
            this.btnTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTest.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Padding = new System.Windows.Forms.Padding(5);
            this.btnTest.Size = new System.Drawing.Size(45, 31);
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnImport
            // 
            this.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(5);
            this.btnImport.Size = new System.Drawing.Size(61, 31);
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(5);
            this.btnExport.Size = new System.Drawing.Size(60, 31);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnOpenTreeViewDesigner
            // 
            this.btnOpenTreeViewDesigner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenTreeViewDesigner.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenTreeViewDesigner.Image")));
            this.btnOpenTreeViewDesigner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenTreeViewDesigner.Name = "btnOpenTreeViewDesigner";
            this.btnOpenTreeViewDesigner.Padding = new System.Windows.Forms.Padding(5);
            this.btnOpenTreeViewDesigner.Size = new System.Drawing.Size(119, 31);
            this.btnOpenTreeViewDesigner.Text = "Tree View Desginer";
            this.btnOpenTreeViewDesigner.Click += new System.EventHandler(this.btnOpenTreeViewDesigner_Click);
            // 
            // btnChangeTreeLayout
            // 
            this.btnChangeTreeLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnChangeTreeLayout.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTreeLayout.Image")));
            this.btnChangeTreeLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeTreeLayout.Name = "btnChangeTreeLayout";
            this.btnChangeTreeLayout.Padding = new System.Windows.Forms.Padding(5);
            this.btnChangeTreeLayout.Size = new System.Drawing.Size(101, 31);
            this.btnChangeTreeLayout.Text = "Change Layout";
            this.btnChangeTreeLayout.Click += new System.EventHandler(this.btnChangeTreeLayout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Size = new System.Drawing.Size(66, 31);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Padding = new System.Windows.Forms.Padding(5);
            this.btnHelp.Size = new System.Drawing.Size(49, 31);
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 469);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainFrm";
            this.Text = "SpiceDB UI v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ImageList imageList1;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private ListView listView1;
        private ColumnHeader RescourceType;
        private ColumnHeader RescourceId;
        private ColumnHeader SNo;
        private ColumnHeader Relation;
        private ColumnHeader SubjectType;
        private ColumnHeader SubjectId;
        private ToolStrip toolStrip1;
        private ToolStripButton btnOpenTreeViewDesigner;
        private ToolStripButton btnChangeTreeLayout;
        private ToolStripButton btnConnect;
        private ToolStripButton btnTest;
        private ToolStripButton btnImport;
        private ToolStripButton btnExport;
        private ToolStripButton btnAddRelation;
        private ToolStripButton btnHelp;
        private ToolStripButton btnSchema;
        private ToolStripButton btnRefresh;
        private Label lblLoadingData;
    }
}