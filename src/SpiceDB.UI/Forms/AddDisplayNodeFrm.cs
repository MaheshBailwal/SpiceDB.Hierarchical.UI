using SpiceDB.UI.Events;

namespace SpiceDB.UI.Forms
{
    public partial class AddDisplayNodeFrm : Form
    {
        string _parentRescourceType;
        public AddDisplayNodeFrm(string parentRescourceType)
        {
            InitializeComponent();
            _parentRescourceType = parentRescourceType;
        }

        private void AddDisplayNodeFrm_Load(object sender, EventArgs e)
        {
            foreach (var resType in SpiceDBService.Instance.SchemaEntities)
            {
                cmbRescourceType.Items.Add(resType.ResourceType);
            }

            if(!string.IsNullOrEmpty(_parentRescourceType))
            {
                cmbRescourceType.SelectedItem = _parentRescourceType;
            }
        }

        private void cmbRescourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rsType = SpiceDBService.Instance.SchemaEntities.First(x => x.ResourceType == cmbRescourceType.Text);

            foreach (var rel in rsType.Relationships)
            {
                cmbRelationShipWithParent.Items.Add(rel.Name);
            }
        }

        private void txtDone_Click(object sender, EventArgs e)
        {
            DisplayNode displayNode = new DisplayNode()
            {
                TemplateId = txtTemplateId.Text,
                CompareParentWithSubject = chkCompareSubject.Checked,
                DisplayFormat = txtDisplayFormat.Text,
                IsIdNode = chkIsIdNode.Checked,
                IsWrapperNode = chkIsWrapperNode.Checked,
                MapeToTemplateId = txtMapeToTemplateId.Text,
                RelationShipWithParent = cmbRelationShipWithParent.Text,
                EntityType = cmbRescourceType.Text,
                WrapperNodeName = txtWrapperNodeName.Text
            };

            EventContainer.PublishEvent(EventType.LayOutNodeUpdated.ToString(), new EventArg(displayNode));
            
        }
    }
}
