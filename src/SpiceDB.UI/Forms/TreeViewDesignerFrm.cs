using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiceDB.UI.Forms
{
    public partial class TreeViewDesignerFrm : Form
    {
        public TreeViewDesignerFrm()
        {
            InitializeComponent();
        }

        private void TreeViewDesignerFrm_Load(object sender, EventArgs e)
        {
            LoadSchema();
        }

        private void LoadSchema()
        {
            foreach (var enitity in SpiceDBService.Instance.SchemaEntities)
            {
                var entityNode = trvSchema.Nodes.Add(enitity.ResourceType, enitity.ResourceType);
                entityNode.Tag = enitity;

                foreach (var relation in enitity.Relationships)
                {
                    var relationNode = entityNode.Nodes.Add(relation.Name, relation.Name);
                    relationNode.Tag = relation;
                }

            }
        }
    }
}
