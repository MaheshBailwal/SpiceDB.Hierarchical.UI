namespace SpiceDB.UI.Forms
{
    partial class TreeViewDesignerFrm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewDesignerFrm));
            this.trvSchema = new System.Windows.Forms.TreeView();
            this.trvLayOut = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvSchema
            // 
            this.trvSchema.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trvSchema.Location = new System.Drawing.Point(13, 24);
            this.trvSchema.Name = "trvSchema";
            this.trvSchema.Size = new System.Drawing.Size(406, 468);
            this.trvSchema.TabIndex = 0;
            this.trvSchema.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvSchema_ItemDrag);
            // 
            // trvLayOut
            // 
            this.trvLayOut.AllowDrop = true;
            this.trvLayOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trvLayOut.Location = new System.Drawing.Point(13, 25);
            this.trvLayOut.Name = "trvLayOut";
            this.trvLayOut.ShowNodeToolTips = true;
            this.trvLayOut.Size = new System.Drawing.Size(539, 468);
            this.trvLayOut.TabIndex = 1;
            this.trvLayOut.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.trvLayOut_AfterLabelEdit);
            this.trvLayOut.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvLayOut_ItemDrag);
            this.trvLayOut.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvLayOut_DragDrop);
            this.trvLayOut.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvLayOut_DragEnter);
            this.trvLayOut.DragOver += new System.Windows.Forms.DragEventHandler(this.trvLayOut_DragOver);
            this.trvLayOut.DragLeave += new System.EventHandler(this.trvLayOut_DragLeave);
            this.trvLayOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trvLayOut_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvSchema);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 507);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schema";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trvLayOut);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(460, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 507);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tree Layout";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1038, 34);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(5);
            this.btnOpen.Size = new System.Drawing.Size(54, 31);
            this.btnOpen.Text = "Open";
            this.btnOpen.ToolTipText = "Open Tree Layout File";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(49, 31);
            this.btnSave.Text = "Save";
            this.btnSave.ToolTipText = "Save Changes";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveAs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Padding = new System.Windows.Forms.Padding(5);
            this.btnSaveAs.Size = new System.Drawing.Size(67, 31);
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.ToolTipText = "Save As Layout File";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(5);
            this.btnNew.Size = new System.Drawing.Size(48, 31);
            this.btnNew.Text = "New";
            this.btnNew.ToolTipText = "New Tree Layout File";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // TreeViewDesignerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 553);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TreeViewDesignerFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tree View LayOut Designer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TreeViewDesignerFrm_FormClosing);
            this.Load += new System.EventHandler(this.TreeViewDesignerFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView trvSchema;
        private TreeView trvLayOut;
        private ContextMenuStrip contextMenuStrip1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ToolStrip toolStrip1;
        private ToolStripButton btnOpen;
        private ToolStripButton btnSave;
        private ToolStripButton btnSaveAs;
        private ToolStripButton btnNew;
    }
}