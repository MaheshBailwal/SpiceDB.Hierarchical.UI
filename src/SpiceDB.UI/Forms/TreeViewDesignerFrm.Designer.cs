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
            this.trvSchema = new System.Windows.Forms.TreeView();
            this.trvLayOut = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvSchema
            // 
            this.trvSchema.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trvSchema.Location = new System.Drawing.Point(37, 47);
            this.trvSchema.Name = "trvSchema";
            this.trvSchema.Size = new System.Drawing.Size(394, 363);
            this.trvSchema.TabIndex = 0;
            this.trvSchema.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvSchema_ItemDrag);
            // 
            // trvLayOut
            // 
            this.trvLayOut.AllowDrop = true;
            this.trvLayOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trvLayOut.Location = new System.Drawing.Point(481, 47);
            this.trvLayOut.Name = "trvLayOut";
            this.trvLayOut.ShowNodeToolTips = true;
            this.trvLayOut.Size = new System.Drawing.Size(541, 363);
            this.trvLayOut.TabIndex = 1;
            this.trvLayOut.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvLayOut_ItemDrag);
            this.trvLayOut.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvLayOut_NodeMouseDoubleClick);
            this.trvLayOut.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvLayOut_DragDrop);
            this.trvLayOut.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvLayOut_DragEnter);
            this.trvLayOut.DragOver += new System.Windows.Forms.DragEventHandler(this.trvLayOut_DragOver);
            this.trvLayOut.DragLeave += new System.EventHandler(this.trvLayOut_DragLeave);
            this.trvLayOut.MouseHover += new System.EventHandler(this.trvLayOut_MouseHover);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TreeViewDesignerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 517);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trvLayOut);
            this.Controls.Add(this.trvSchema);
            this.Name = "TreeViewDesignerFrm";
            this.Text = "TreeViewDesignerFrm";
            this.Load += new System.EventHandler(this.TreeViewDesignerFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView trvSchema;
        private TreeView trvLayOut;
        private Button button1;
    }
}