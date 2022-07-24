namespace AuthClient
{
    public partial class TestFrm : Form
    {
        AuthDB _authDB;
        public TestFrm(AuthDB authDB)
        {
            _authDB = authDB;
            InitializeComponent();
        }

    
        private async void btnOrgPermission_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var orgs = await _authDB.GetUserOrgsAsync(txtUser.Text, txtOrg.Text);
            BindResult(orgs);
            Cursor = Cursors.Default;
        }

        private async void btnAssets_Click(object sender, EventArgs e)
        {
            Cursor= Cursors.WaitCursor;
            var assets = await _authDB.GetUserAssestsAsync(txtUser.Text, txtOrg.Text);
            BindResult(assets);
            Cursor = Cursors.Default;
        }

        private async void btnRbac_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var rbacs = await _authDB.GetUserRbacEntitiesAsync(txtUser.Text, txtOrg.Text);
           BindResult(rbacs);
            Cursor = Cursors.Default;    
        }

        private void BindResult(List<string> result)
        {
            lstResult.DataSource = result;
            grpResult.Text = $"Result ({result.Count})";
            if (result.Count == 0)
            {
                lstResult.DataSource = null;
                lstResult.Items.Add("No Result Found");
                
            }
        }
        private void lstResult_SizeChanged(object sender, EventArgs e)
        {

        }

        private void TestFrm_Load(object sender, EventArgs e)
        {
            lstResult.ItemHeight = 50;
        }

        private async void btnRole_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var assets = await _authDB.GetUserRolesAsync(txtUser.Text, txtOrg.Text);
            BindResult(assets);
            Cursor = Cursors.Default;
        }

        private async void btnDevices_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var assets = await _authDB.GetUserDevicesAsync(txtUser.Text, txtOrg.Text);
            BindResult(assets);
            Cursor = Cursors.Default;
        }
    }
}
