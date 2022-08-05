namespace SpiceDB.UI.Forms
{
    public partial class LayoutNodePropetiesFrm : Form
    {
        LayOutNodeTag _layOutNodeTag;
        public LayoutNodePropetiesFrm(LayOutNodeTag layOutNodeTag)
        {
            InitializeComponent();
            _layOutNodeTag = layOutNodeTag;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void LayoutNodePropetiesFrm_Load(object sender, EventArgs e)
        {
            txtResourceType.Text = _layOutNodeTag.ComapreParentWithSubject ? _layOutNodeTag.Relation.ResourceType : _layOutNodeTag.Relation.SubjectType;
            txtParentType.Text = _layOutNodeTag.ComapreParentWithSubject ? _layOutNodeTag.Relation.SubjectType : _layOutNodeTag.Relation.ResourceType;
            txtRelationWithParent.Text = _layOutNodeTag.Relation.Name;
            txtDisplayFormat.Text = _layOutNodeTag.DisplayFormat;
            chkCompareSubject.Checked = _layOutNodeTag.ComapreParentWithSubject;
            txtRelationWithParent.Enabled = txtResourceType.Enabled = false;
        }

        private void txtDone_Click(object sender, EventArgs e)
        {
            _layOutNodeTag.ComapreParentWithSubject = chkCompareSubject.Checked;
            _layOutNodeTag.DisplayFormat = txtDisplayFormat.Text;
            Close();
        }
    }
}
