namespace SpiceDB.UI.Forms
{
    partial class AddDisplayNodeFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTemplateId = new System.Windows.Forms.TextBox();
            this.txtWrapperNodeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMapeToTemplateId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkCompareSubject = new System.Windows.Forms.CheckBox();
            this.chkIsWrapperNode = new System.Windows.Forms.CheckBox();
            this.chkIsIdNode = new System.Windows.Forms.CheckBox();
            this.cmbRescourceType = new System.Windows.Forms.ComboBox();
            this.cmbRelationShipWithParent = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRelationShipWithParent);
            this.groupBox1.Controls.Add(this.cmbRescourceType);
            this.groupBox1.Controls.Add(this.chkIsIdNode);
            this.groupBox1.Controls.Add(this.chkIsWrapperNode);
            this.groupBox1.Controls.Add(this.chkCompareSubject);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMapeToTemplateId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDisplayFormat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtWrapperNodeName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTemplateId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 316);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "TemplateId ";
            // 
            // txtTemplateId
            // 
            this.txtTemplateId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTemplateId.Location = new System.Drawing.Point(176, 121);
            this.txtTemplateId.Name = "txtTemplateId";
            this.txtTemplateId.Size = new System.Drawing.Size(207, 25);
            this.txtTemplateId.TabIndex = 1;
            // 
            // txtWrapperNodeName
            // 
            this.txtWrapperNodeName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWrapperNodeName.Location = new System.Drawing.Point(176, 167);
            this.txtWrapperNodeName.Name = "txtWrapperNodeName";
            this.txtWrapperNodeName.Size = new System.Drawing.Size(207, 25);
            this.txtWrapperNodeName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "WrapperNodeName ";
            // 
            // txtDisplayFormat
            // 
            this.txtDisplayFormat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDisplayFormat.Location = new System.Drawing.Point(176, 210);
            this.txtDisplayFormat.Name = "txtDisplayFormat";
            this.txtDisplayFormat.Size = new System.Drawing.Size(207, 25);
            this.txtDisplayFormat.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "DisplayFormat ";
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
            // txtMapeToTemplateId
            // 
            this.txtMapeToTemplateId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMapeToTemplateId.Location = new System.Drawing.Point(176, 263);
            this.txtMapeToTemplateId.Name = "txtMapeToTemplateId";
            this.txtMapeToTemplateId.Size = new System.Drawing.Size(207, 25);
            this.txtMapeToTemplateId.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(23, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "MapeToTemplateId ";
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
            // chkCompareSubject
            // 
            this.chkCompareSubject.AutoSize = true;
            this.chkCompareSubject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkCompareSubject.Location = new System.Drawing.Point(536, 49);
            this.chkCompareSubject.Name = "chkCompareSubject";
            this.chkCompareSubject.Size = new System.Drawing.Size(127, 21);
            this.chkCompareSubject.TabIndex = 17;
            this.chkCompareSubject.Text = "CompareSubject ";
            this.chkCompareSubject.UseVisualStyleBackColor = true;
            // 
            // chkIsWrapperNode
            // 
            this.chkIsWrapperNode.AutoSize = true;
            this.chkIsWrapperNode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkIsWrapperNode.Location = new System.Drawing.Point(536, 77);
            this.chkIsWrapperNode.Name = "chkIsWrapperNode";
            this.chkIsWrapperNode.Size = new System.Drawing.Size(125, 21);
            this.chkIsWrapperNode.TabIndex = 18;
            this.chkIsWrapperNode.Text = "IsWrapperNode ";
            this.chkIsWrapperNode.UseVisualStyleBackColor = true;
            // 
            // chkIsIdNode
            // 
            this.chkIsIdNode.AutoSize = true;
            this.chkIsIdNode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkIsIdNode.Location = new System.Drawing.Point(536, 106);
            this.chkIsIdNode.Name = "chkIsIdNode";
            this.chkIsIdNode.Size = new System.Drawing.Size(84, 21);
            this.chkIsIdNode.TabIndex = 19;
            this.chkIsIdNode.Text = "IsIdNode ";
            this.chkIsIdNode.UseVisualStyleBackColor = true;
            // 
            // cmbRescourceType
            // 
            this.cmbRescourceType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRescourceType.FormattingEnabled = true;
            this.cmbRescourceType.Location = new System.Drawing.Point(172, 50);
            this.cmbRescourceType.Name = "cmbRescourceType";
            this.cmbRescourceType.Size = new System.Drawing.Size(211, 25);
            this.cmbRescourceType.TabIndex = 20;
            this.cmbRescourceType.SelectedIndexChanged += new System.EventHandler(this.cmbRescourceType_SelectedIndexChanged);
            // 
            // cmbRelationShipWithParent
            // 
            this.cmbRelationShipWithParent.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRelationShipWithParent.FormattingEnabled = true;
            this.cmbRelationShipWithParent.Location = new System.Drawing.Point(172, 81);
            this.cmbRelationShipWithParent.Name = "cmbRelationShipWithParent";
            this.cmbRelationShipWithParent.Size = new System.Drawing.Size(211, 25);
            this.cmbRelationShipWithParent.TabIndex = 21;
            // 
            // AddDisplayNodeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddDisplayNodeFrm";
            this.Text = "AddDisplayNodeFrm";
            this.Load += new System.EventHandler(this.AddDisplayNodeFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private TextBox txtMapeToTemplateId;
        private Label label5;
        private Label label4;
        private TextBox txtDisplayFormat;
        private Label label3;
        private TextBox txtWrapperNodeName;
        private Label label2;
        private TextBox txtTemplateId;
        private Label label1;
        private CheckBox chkIsIdNode;
        private CheckBox chkIsWrapperNode;
        private CheckBox chkCompareSubject;
        private ComboBox cmbRescourceType;
        private ComboBox cmbRelationShipWithParent;
    }
}