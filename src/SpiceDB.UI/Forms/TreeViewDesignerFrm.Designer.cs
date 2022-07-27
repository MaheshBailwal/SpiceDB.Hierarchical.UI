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
            this.SuspendLayout();
            // 
            // trvSchema
            // 
            this.trvSchema.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trvSchema.Location = new System.Drawing.Point(37, 47);
            this.trvSchema.Name = "trvSchema";
            this.trvSchema.Size = new System.Drawing.Size(296, 324);
            this.trvSchema.TabIndex = 0;
            // 
            // trvLayOut
            // 
            this.trvLayOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trvLayOut.Location = new System.Drawing.Point(457, 47);
            this.trvLayOut.Name = "trvLayOut";
            this.trvLayOut.Size = new System.Drawing.Size(296, 324);
            this.trvLayOut.TabIndex = 1;
            // 
            // TreeViewDesignerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}