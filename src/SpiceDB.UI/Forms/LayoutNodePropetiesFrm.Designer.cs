namespace SpiceDB.UI.Forms
{
    partial class LayoutNodePropetiesFrm
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
            this.txtRelationWithParent = new System.Windows.Forms.TextBox();
            this.txtResourceType = new System.Windows.Forms.TextBox();
            this.txtDone = new System.Windows.Forms.Button();
            this.chkCompareSubject = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisplayFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParentType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRelationWithParent
            // 
            this.txtRelationWithParent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRelationWithParent.Location = new System.Drawing.Point(161, 60);
            this.txtRelationWithParent.Name = "txtRelationWithParent";
            this.txtRelationWithParent.Size = new System.Drawing.Size(207, 25);
            this.txtRelationWithParent.TabIndex = 32;
            // 
            // txtResourceType
            // 
            this.txtResourceType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtResourceType.Location = new System.Drawing.Point(161, 5);
            this.txtResourceType.Name = "txtResourceType";
            this.txtResourceType.Size = new System.Drawing.Size(207, 25);
            this.txtResourceType.TabIndex = 31;
            // 
            // txtDone
            // 
            this.txtDone.Location = new System.Drawing.Point(113, 162);
            this.txtDone.Name = "txtDone";
            this.txtDone.Size = new System.Drawing.Size(106, 23);
            this.txtDone.TabIndex = 30;
            this.txtDone.Text = "Done";
            this.txtDone.UseVisualStyleBackColor = true;
            // 
            // chkCompareSubject
            // 
            this.chkCompareSubject.AutoSize = true;
            this.chkCompareSubject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkCompareSubject.Location = new System.Drawing.Point(8, 132);
            this.chkCompareSubject.Name = "chkCompareSubject";
            this.chkCompareSubject.Size = new System.Drawing.Size(288, 21);
            this.chkCompareSubject.TabIndex = 29;
            this.chkCompareSubject.Text = "Compare Parent Value With Relation Subject ";
            this.chkCompareSubject.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(8, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "RelationShipWithParent ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(8, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Resource Type";
            // 
            // txtDisplayFormat
            // 
            this.txtDisplayFormat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDisplayFormat.Location = new System.Drawing.Point(161, 88);
            this.txtDisplayFormat.Name = "txtDisplayFormat";
            this.txtDisplayFormat.Size = new System.Drawing.Size(207, 25);
            this.txtDisplayFormat.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(8, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "DisplayFormat ";
            // 
            // txtParentType
            // 
            this.txtParentType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtParentType.Location = new System.Drawing.Point(161, 32);
            this.txtParentType.Name = "txtParentType";
            this.txtParentType.Size = new System.Drawing.Size(207, 25);
            this.txtParentType.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Parent Type";
            // 
            // LayoutNodePropetiesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 204);
            this.Controls.Add(this.txtParentType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRelationWithParent);
            this.Controls.Add(this.txtResourceType);
            this.Controls.Add(this.txtDone);
            this.Controls.Add(this.chkCompareSubject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDisplayFormat);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayoutNodePropetiesFrm";
            this.Text = "LayoutNodePropetiesFrm";
            this.Load += new System.EventHandler(this.LayoutNodePropetiesFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtRelationWithParent;
        private TextBox txtResourceType;
        private Button txtDone;
        private CheckBox chkCompareSubject;
        private Label label6;
        private Label label4;
        private TextBox txtDisplayFormat;
        private Label label3;
        private TextBox txtParentType;
        private Label label1;
    }
}