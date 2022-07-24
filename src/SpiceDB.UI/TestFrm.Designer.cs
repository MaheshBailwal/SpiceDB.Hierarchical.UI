namespace AuthClient
{
    partial class TestFrm
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
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.grpAuthContext = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAssets = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRbac = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOrgPermission = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRole = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDevices = new System.Windows.Forms.Button();
            this.grpResult.SuspendLayout();
            this.grpAuthContext.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lstResult);
            this.grpResult.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpResult.Location = new System.Drawing.Point(473, 12);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(401, 423);
            this.grpResult.TabIndex = 10;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Result";
            // 
            // lstResult
            // 
            this.lstResult.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstResult.FormattingEnabled = true;
            this.lstResult.HorizontalScrollbar = true;
            this.lstResult.ItemHeight = 17;
            this.lstResult.Location = new System.Drawing.Point(15, 21);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(380, 395);
            this.lstResult.Sorted = true;
            this.lstResult.TabIndex = 12;
            this.lstResult.SizeChanged += new System.EventHandler(this.lstResult_SizeChanged);
            // 
            // grpAuthContext
            // 
            this.grpAuthContext.Controls.Add(this.label2);
            this.grpAuthContext.Controls.Add(this.label1);
            this.grpAuthContext.Controls.Add(this.txtOrg);
            this.grpAuthContext.Controls.Add(this.txtUser);
            this.grpAuthContext.Location = new System.Drawing.Point(12, 8);
            this.grpAuthContext.Name = "grpAuthContext";
            this.grpAuthContext.Size = new System.Drawing.Size(432, 65);
            this.grpAuthContext.TabIndex = 11;
            this.grpAuthContext.TabStop = false;
            this.grpAuthContext.Text = "Authentication Context";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(191, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Organization";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "User";
            // 
            // txtOrg
            // 
            this.txtOrg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrg.Location = new System.Drawing.Point(277, 24);
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Size = new System.Drawing.Size(146, 25);
            this.txtOrg.TabIndex = 9;
            this.txtOrg.Text = "consitemine";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUser.Location = new System.Drawing.Point(44, 24);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(146, 25);
            this.txtUser.TabIndex = 8;
            this.txtUser.Text = "wencoadmin";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAssets);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 64);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Assets Permission";
            // 
            // btnAssets
            // 
            this.btnAssets.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAssets.Location = new System.Drawing.Point(50, 24);
            this.btnAssets.Name = "btnAssets";
            this.btnAssets.Size = new System.Drawing.Size(224, 28);
            this.btnAssets.TabIndex = 9;
            this.btnAssets.Text = "Get Assets";
            this.btnAssets.UseVisualStyleBackColor = true;
            this.btnAssets.Click += new System.EventHandler(this.btnAssets_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRbac);
            this.groupBox3.Location = new System.Drawing.Point(18, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 64);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rbac Entities Permissions";
            // 
            // btnRbac
            // 
            this.btnRbac.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRbac.Location = new System.Drawing.Point(50, 23);
            this.btnRbac.Name = "btnRbac";
            this.btnRbac.Size = new System.Drawing.Size(224, 28);
            this.btnRbac.TabIndex = 10;
            this.btnRbac.Text = "Get Rbac Entities";
            this.btnRbac.UseVisualStyleBackColor = true;
            this.btnRbac.Click += new System.EventHandler(this.btnRbac_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOrgPermission);
            this.groupBox4.Location = new System.Drawing.Point(20, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(426, 64);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Organization Permissions";
            // 
            // btnOrgPermission
            // 
            this.btnOrgPermission.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOrgPermission.Location = new System.Drawing.Point(50, 22);
            this.btnOrgPermission.Name = "btnOrgPermission";
            this.btnOrgPermission.Size = new System.Drawing.Size(224, 28);
            this.btnOrgPermission.TabIndex = 10;
            this.btnOrgPermission.Text = "Get Organization ";
            this.btnOrgPermission.UseVisualStyleBackColor = true;
            this.btnOrgPermission.Click += new System.EventHandler(this.btnOrgPermission_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRole);
            this.groupBox1.Location = new System.Drawing.Point(18, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 64);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Role Permissions";
            // 
            // btnRole
            // 
            this.btnRole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRole.Location = new System.Drawing.Point(50, 22);
            this.btnRole.Name = "btnRole";
            this.btnRole.Size = new System.Drawing.Size(224, 28);
            this.btnRole.TabIndex = 10;
            this.btnRole.Text = "Get Roles";
            this.btnRole.UseVisualStyleBackColor = true;
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDevices);
            this.groupBox5.Location = new System.Drawing.Point(20, 371);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(426, 64);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Device Permissions";
            // 
            // btnDevices
            // 
            this.btnDevices.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDevices.Location = new System.Drawing.Point(50, 22);
            this.btnDevices.Name = "btnDevices";
            this.btnDevices.Size = new System.Drawing.Size(224, 28);
            this.btnDevices.TabIndex = 10;
            this.btnDevices.Text = "Get Devices";
            this.btnDevices.UseVisualStyleBackColor = true;
            this.btnDevices.Click += new System.EventHandler(this.btnDevices_Click);
            // 
            // TestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 455);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpAuthContext);
            this.Controls.Add(this.grpResult);
            this.Name = "TestFrm";
            this.Text = "Test User Permissions";
            this.Load += new System.EventHandler(this.TestFrm_Load);
            this.grpResult.ResumeLayout(false);
            this.grpAuthContext.ResumeLayout(false);
            this.grpAuthContext.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox grpResult;
        private ListBox lstResult;
        private GroupBox grpAuthContext;
        private Label label2;
        private Label label1;
        private TextBox txtOrg;
        private TextBox txtUser;
        private GroupBox groupBox2;
        private Button btnAssets;
        private GroupBox groupBox3;
        private Button btnRbac;
        private GroupBox groupBox4;
        private Button btnOrgPermission;
        private GroupBox groupBox1;
        private Button btnRole;
        private GroupBox groupBox5;
        private Button btnDevices;
    }
}