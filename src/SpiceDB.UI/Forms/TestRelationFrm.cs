namespace SpiceDB.UI
{
    public partial class TestRelationFrm : Form
    {
       public TestRelationFrm()
        {
            InitializeComponent();
        }

        private void TestRelationFrm_Load(object sender, EventArgs e)
        {
            cmbResourceType.Items.Add("Select");
            cmbSubjectType.Items.Add("Select");

            foreach (var entity in SpiceDBService.Instance.SchemaEntities)
            {
                cmbResourceType.Items.Add(entity.ResourceType);
                cmbSubjectType.Items.Add(entity.ResourceType);
            }

            cmbResourceType.SelectedIndex = cmbSubjectType.SelectedIndex = 0;
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {

            if (cmbSubjectType.SelectedIndex == 0
                || cmbResourceType.SelectedIndex == 0
                || cmbPermission.SelectedIndex == 0
                || string.IsNullOrEmpty(txtSubjectId.Text))
            {
                MessageBox.Show("Please select/fill all fields");
                return;
            }

            var permissions = await SpiceDBService.Instance.GetResourcePermissions(cmbResourceType.Text,
                                                               cmbPermission.Text,
                                                               cmbSubjectType.Text,
                                                               txtSubjectId.Text);
            lstResult.Items.Clear();

            foreach (var permission in permissions)
            {
                lstResult.Items.Add(permission);
            }

            grpResult.Text = $"Result ({lstResult.Items.Count})";
        }

        private void cmbResourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResourceType.SelectedIndex == 0)
                return;

            var schemaEntity = SpiceDBService.Instance.SchemaEntities.First(x => x.ResourceType == cmbResourceType.Text);

            cmbPermission.Items.Clear();
            cmbPermission.Items.Add("Select");

            foreach (var relation in schemaEntity?.Permissions)
            {
                cmbPermission.Items.Add(relation.Name);
            }

            cmbPermission.SelectedIndex = 0;
        }
    }
}
