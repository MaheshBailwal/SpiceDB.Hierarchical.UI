namespace SpiceDB.UI.Forms
{
    public partial class AddDisplayNodeFrm : Form
    {
        public AddDisplayNodeFrm()
        {
            InitializeComponent();
        }

        private void AddDisplayNodeFrm_Load(object sender, EventArgs e)
        {
            foreach (var resType in SpiceDBService.Instance.SchemaEntities)
            {
                cmbRescourceType.Items.Add(resType.ResourceType);
            }
        }

        private void cmbRescourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
          var rsType =  SpiceDBService.Instance.SchemaEntities.First(x => x.ResourceType == cmbRescourceType.Text);

            foreach (var rel in rsType.Relationships)
            {
                cmbRelationShipWithParent.Items.Add(rel.Name);
            }
        }
    }
}
