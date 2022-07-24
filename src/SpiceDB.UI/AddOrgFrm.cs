namespace AuthClient
{
    public partial class AddOrgFrm : Form
    {

        AuthDB _authDB;
        Action _reloadTree;

        public AddOrgFrm(AuthDB authDB, Action reloadTree, string parentOrg = "")
        {
            _authDB = authDB;
            _reloadTree = reloadTree;
            InitializeComponent();
            txtParentOrg.Text = parentOrg;
            txtOrg.KeyPress += textBox_KeyPress;
            txtParentOrg.KeyPress += textBox_KeyPress;
            txtCreatorOrg.KeyPress += textBox_KeyPress;
            txtAdminUser.KeyPress += textBox_KeyPress;
            txtNonAdminUser.KeyPress += textBox_KeyPress;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(txtParentOrg.Text) &&
               string.IsNullOrWhiteSpace(txtCreatorOrg.Text) &&
               string.IsNullOrWhiteSpace(txtAdminUser.Text) &&
               string.IsNullOrWhiteSpace(txtNonAdminUser.Text))
            {
                MessageBox.Show("Atleaset on realtionship is needed");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                btnCancel.Enabled = btnOk.Enabled = false;
                _authDB.AddOrg(
                    txtOrg.Text,
                    txtParentOrg.Text,
                    txtCreatorOrg.Text,
                    txtAdminUser.Text,
                    txtNonAdminUser.Text);
            }
            finally
            {
                Cursor cursor = Cursors.Default;
                btnCancel.Enabled = btnOk.Enabled = true;
            }

            Close();
            _reloadTree();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddOrgFrm_Load(object sender, EventArgs e)
        {

        }

        private void textBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-' && e.KeyChar != '/' && e.KeyChar != '_' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                if (!char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
