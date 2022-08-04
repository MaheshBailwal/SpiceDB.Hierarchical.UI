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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRelationWithParent = new System.Windows.Forms.TextBox();
            this.txtResourceType = new System.Windows.Forms.TextBox();
            this.chkCompareSubject = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisplayFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDone = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRelationWithParent);
            this.groupBox1.Controls.Add(this.txtResourceType);
            this.groupBox1.Controls.Add(this.txtDone);
            this.groupBox1.Controls.Add(this.chkCompareSubject);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDisplayFormat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(29, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 238);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtRelationWithParent
            // 
            this.txtRelationWithParent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRelationWithParent.Location = new System.Drawing.Point(176, 81);
            this.txtRelationWithParent.Name = "txtRelationWithParent";
            this.txtRelationWithParent.Size = new System.Drawing.Size(207, 25);
            this.txtRelationWithParent.TabIndex = 24;
            // 
            // txtResourceType
            // 
            this.txtResourceType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtResourceType.Location = new System.Drawing.Point(176, 53);
            this.txtResourceType.Name = "txtResourceType";
            this.txtResourceType.Size = new System.Drawing.Size(207, 25);
            this.txtResourceType.TabIndex = 23;
            // 
            // chkCompareSubject
            // 
            this.chkCompareSubject.AutoSize = true;
            this.chkCompareSubject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkCompareSubject.Location = new System.Drawing.Point(23, 164);
            this.chkCompareSubject.Name = "chkCompareSubject";
            this.chkCompareSubject.Size = new System.Drawing.Size(127, 21);
            this.chkCompareSubject.TabIndex = 17;
            this.chkCompareSubject.Text = "CompareSubject ";
            this.chkCompareSubject.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(23, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "RelationShipWithParent ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resource Type";
            // 
            // txtDisplayFormat
            // 
            this.txtDisplayFormat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDisplayFormat.Location = new System.Drawing.Point(176, 111);
            this.txtDisplayFormat.Name = "txtDisplayFormat";
            this.txtDisplayFormat.Size = new System.Drawing.Size(207, 25);
            this.txtDisplayFormat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "DisplayFormat ";
            // 
            // txtDone
            // 
            this.txtDone.Location = new System.Drawing.Point(230, 196);
            this.txtDone.Name = "txtDone";
            this.txtDone.Size = new System.Drawing.Size(75, 23);
            this.txtDone.TabIndex = 22;
            this.txtDone.Text = "Done";
            this.txtDone.UseVisualStyleBackColor = true;
            this.txtDone.Click += new System.EventHandler(this.txtDone_Click);
            // 
            // LayoutNodePropetiesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 268);
            this.Controls.Add(this.groupBox1);
            this.Name = "LayoutNodePropetiesFrm";
            this.Text = "LayoutNodePropetiesFrm";
            this.Load += new System.EventHandler(this.LayoutNodePropetiesFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtRelationWithParent;
        private TextBox txtResourceType;
        private CheckBox chkCompareSubject;
        private Label label6;
        private Label label4;
        private TextBox txtDisplayFormat;
        private Label label3;
        private Button txtDone;
    }
}