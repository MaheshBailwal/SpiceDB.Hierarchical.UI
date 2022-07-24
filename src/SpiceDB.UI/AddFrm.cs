using System.Data;
using System.Text.RegularExpressions;
using Wenco.Library.Authorization;
using Wenco.Library.Authorization.Types;

namespace AuthClient
{
    public partial class AddFrm : Form
    {
        TreeNode _treeNode;
        AuthDB _authDB;
        Action _reloadTree;
        string defaultText = "comma separated values or single value";
        public AddFrm(TreeNode treeNode, AuthDB authDB, Action reloadTree)
        {
            _treeNode = treeNode;
            _authDB = authDB;
            _reloadTree = reloadTree;
            InitializeComponent();
        }

        private void AddRFrm_Load(object sender, EventArgs e)
        {
            label1.Text = _treeNode.Text.RemoveParenthesis();
            groupBox1.Visible = false;
            grpRelation.Visible = false;
            textBox1.Text = defaultText;


            switch (_treeNode.Tag?.ToString())
            {
                case AuthorizationDB.RT_DEVICE:
                    return;
                case AuthorizationDB.RT_ASSET:
                    InitForAssets();
                    return;
                case AuthorizationDB.RT_USER:
                    InitForOrgUser();
                    return;
                case AuthorizationDB.RT_ROLE:
                    InitForRoles();
                    return;
                case AuthorizationDB.RT_ROLE + AuthorizationDB.RT_USER:
                    InitForRoleUser();
                    return;
                case AuthorizationDB.RT_ROLE + AuthorizationDB.RT_ENTITY:
                    groupBox1.Visible = true;
                    return;
            }

            switch (_treeNode.Parent?.Tag.ToString())
            {
                case AuthorizationDB.RT_ASSET:
                    InitForAssetDevice();
                    return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnCancel.Enabled = button1.Enabled = false;

            try
            {

                switch (_treeNode.Tag?.ToString())
                {
                    case AuthorizationDB.RT_DEVICE:
                        AddDeviceToOrg();
                        break;
                    case AuthorizationDB.RT_ASSET:
                        AddAssets();
                        break;
                    case AuthorizationDB.RT_USER:
                        AddUsersToOrg();
                        break;
                    case AuthorizationDB.RT_ROLE:
                        AddRoles();
                        break;
                    case AuthorizationDB.RT_ROLE + AuthorizationDB.RT_USER:
                        AddUsersToRole();
                        break;
                    case AuthorizationDB.RT_ROLE + AuthorizationDB.RT_ENTITY:
                        AddRbac();
                        break;
                    default:
                        if (_treeNode.Parent?.Tag.ToString() == AuthorizationDB.RT_ASSET)
                        {
                            AddDeviceToAsset();
                        }
                        break;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                btnCancel.Enabled = button1.Enabled = true;
            }

            this.Close();
            _reloadTree();
        }
        private void InitForRoles()
        {
            grpRelation.Visible = true;
            cmbRelation.Items.Clear();

            var lst = Enum.GetValues(typeof(OrganizationRoleRelationship)).Cast<OrganizationRoleRelationship>().ToList();

            foreach (var item in lst)
            {
                cmbRelation.Items.Add(item.ToString());
            }

            cmbRelation.SelectedText = OrganizationRoleRelationship.Manager.ToString();
        }

        private void InitForRoleUser()
        {
            this.Text = $"Add Users to Role ({_treeNode.Parent.Text.RemoveParenthesis()})";
        }

        private void InitForAssets()
        {
            grpRelation.Visible = true;
            cmbRelation.Items.Clear();

            this.Text = $"Add Assets to Org ({_treeNode.Parent.Text.RemoveParenthesis()})";
            label1.Text = " Asset Id(s)";

            var organizationAssetRelationships = Enum.GetValues(typeof(OrganizationAssetRelationship)).Cast<OrganizationAssetRelationship>().ToList();

            foreach (var item in organizationAssetRelationships)
            {
                cmbRelation.Items.Add(item.ToString());
            }

            cmbRelation.SelectedText = OrganizationAssetRelationship.Manager.ToString();
        }

        private void InitForAssetDevice()
        {
            this.Text = $"Add device to Asset ({_treeNode.Text.RemoveParenthesis()})";
            label1.Text = " Device Id";
            textBox1.Text = "";
        }

        private void InitForOrgUser()
        {
            grpRelation.Visible = true;
            this.Text = $"Add users to Org ({_treeNode.Parent.Text.RemoveParenthesis()})";
            label1.Text = " User Id(s)";

            var organizationAssetRelationships = Enum.GetValues(typeof(UserOrganizationRelationship)).Cast<UserOrganizationRelationship>().ToList();

            foreach (var item in organizationAssetRelationships)
            {
                cmbRelation.Items.Add(item.ToString());
            }

            cmbRelation.SelectedText = UserOrganizationRelationship.NonAdmin.ToString();
        }

        private void AddRoles()
        {
            string org = _treeNode.Parent.Text;
            var roles = textBox1.Text.Split(",");
            _authDB.AddRoles(org, roles, cmbRelation.Text);
        }

        private void AddAssets()
        {
            string org = _treeNode.Parent.Text.RemoveParenthesis();
            var roles = textBox1.Text.Split(",");
            _authDB.AddAssets(org, roles, cmbRelation.Text);
        }

        private void AddDeviceToAsset()
        {
            string asset = _treeNode.Text.RemoveParenthesis();
            var device = textBox1.Text;
            _authDB.AddDeviceToAsset(asset, device);
        }

        private void AddDeviceToOrg()
        {
            string org = _treeNode.Parent.Text.RemoveParenthesis();
            var devices = textBox1.Text.Split(",");
            _authDB.AddDevicesToOrg(org, devices);
        }
        private void AddUsersToRole()
        {
            string role = _treeNode.Parent.Text.RemoveParenthesis();
            string org = _treeNode.Parent.Parent.Parent.Text;
            var user = textBox1.Text.Split(",");
            _authDB.AddUsersToRole(org, role, user);
        }

        private void AddUsersToOrg()
        {
            string org = _treeNode.Parent.Text;
            var users = textBox1.Text.Split(",");
            _authDB.AddUsersToOrg(org, users, cmbRelation.Text);
        }

        private void AddRbac()
        {
            List<RoleRbacEntityRelationship> permissions = new List<RoleRbacEntityRelationship>();

            if (chkCreate.Checked)
                permissions.Add(RoleRbacEntityRelationship.Creator);
            if (chkRead.Checked)
                permissions.Add(RoleRbacEntityRelationship.Reader);
            if (chckUpdate.Checked)
                permissions.Add(RoleRbacEntityRelationship.Updater);
            if (chckDelete.Checked)
                permissions.Add(RoleRbacEntityRelationship.Deleter);

            string role = _treeNode.Parent.Text.RemoveParenthesis();

            foreach (var item in GetEntries())
            {
                _authDB.AddRbac(role, item, permissions);
            }
        }

        private string[] GetEntries()
        {
            return textBox1.Text.Split(",");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == defaultText)
                textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-'  && e.KeyChar != '/' && e.KeyChar != '_' && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                if (!char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
