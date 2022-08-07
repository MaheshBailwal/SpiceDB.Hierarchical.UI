using SpiceDB.Core;

namespace SpiceDB.UI
{
    public partial class AddRelationFrm : Form
    {
        public AddRelationFrm()
        {
            InitializeComponent();
        }

        private void AddRelationFrm_Load(object sender, EventArgs e)
        {
            cmbResourceType.Items.Add("Select Resource Type");

            foreach (var entity in SpiceDBService.Instance.SchemaEntities)
            {
                cmbResourceType.Items.Add(entity.ResourceType);
            }

            cmbResourceType.SelectedIndex = 0;

            tableLayoutPanel2.MaximumSize = new Size(tableLayoutPanel2.Width, tableLayoutPanel2.Height);
            tableLayoutPanel2.AutoScroll = true;


        }

        private void AddRow(Relation relation)
        {
            var panel = tableLayoutPanel2;
            RowStyle temp = panel.RowStyles[panel.RowCount - 1];

            panel.RowCount++;

            //add a new RowStyle as a copy of the previous one
            panel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));

            var padding = new Padding(0, 10, 0, 0);
            var font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);


            var lbl = new Label() { Text = relation.Name };
            lbl.Margin = padding;
            lbl.Font = font;
            lbl.AutoSize = true;
            panel.Controls.Add(lbl, 0, panel.RowCount - 1);
            //add your three controls

            lbl = new Label() { Text = relation.SubjectType.Split('#')[0] };
            lbl.Width = 100;
            lbl.Margin = padding;
            lbl.AutoSize = true;
            lbl.Font = font;
            panel.Controls.Add(lbl, 1, panel.RowCount - 1);

            var txt = new TextBox();
            txt.Margin = padding;
            txt.Width = 150;
            txt.Font = font;
            txt.Tag = relation;
            panel.Controls.Add(txt, 2, panel.RowCount - 1);

        }

        private void cmbEntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var schema = SpiceDBService.Instance.SchemaEntities.FirstOrDefault(x => x.ResourceType == cmbResourceType.Text);

            var rowCount = tableLayoutPanel2.RowCount;

            for (var i = 2; i <= rowCount; i++)
                RemoveArbitraryRow(tableLayoutPanel2, tableLayoutPanel2.RowCount - 1);

            if (schema == null)
                return;

            foreach (var relation in schema.Relationships)
            {
                AddRow(relation);
            }
        }


        public static void RemoveArbitraryRow(TableLayoutPanel panel, int rowIndex)
        {
            if (rowIndex >= panel.RowCount)
            {
                return;
            }

            // delete all controls of row that we want to delete
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                var control = panel.GetControlFromPosition(i, rowIndex);
                panel.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = rowIndex + 1; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    var control = panel.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        panel.SetRow(control, i - 1);
                    }
                }
            }

            var removeStyle = panel.RowCount - 1;

            if (panel.RowStyles.Count > removeStyle)
                panel.RowStyles.RemoveAt(removeStyle);

            panel.RowCount--;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResourceName.Text))
            {
                MessageBox.Show("Resource Name can not be empty");
                return;
            }
            var resourceIds = txtResourceName.Text.Split(',');
            var relationAddedCount = 0;

            for (var i = 1; i < tableLayoutPanel2.RowCount; i++)
            {
                var txtSubject = (TextBox)tableLayoutPanel2.GetControlFromPosition(2, i);

                if (string.IsNullOrEmpty(txtSubject.Text))
                    continue;

                var relation = (Relation)txtSubject.Tag;
                var arr = relation.SubjectType.Split('#');
                var relationName = relation.Name;
                var optionalSubjectRelation = string.Empty;

                if (arr.Length > 1)
                    optionalSubjectRelation = arr[1];

                foreach (var resourceId in resourceIds)
                {
                    var subjectIds = txtSubject.Text.Split(',');

                    foreach (var subjectId in subjectIds)
                    {
                        AddRelation(cmbResourceType.Text,
                                            resourceId,
                                            relationName,
                                            relation.SubjectTypeWithoutHash,
                                            subjectId,
                                            optionalSubjectRelation);
                        relationAddedCount++;
                        txtSubject.Text = String.Empty;
                    }
                }
            }

            if (relationAddedCount < 1)
            {
                MessageBox.Show("No subject id found, please add");
            }
            else
            {
                MessageBox.Show($"{relationAddedCount} Relation Added Successfully");
            }
        }

        private void AddRelation(string resourceType, string resourceId, string relation,
               string subjectType, string subjectId, string optionalSubjectRelation = "")

        {
            SpiceDBService.Instance.AddRelation(cmbResourceType.Text,
                                               resourceId,
                                               relation,
                                               subjectType,
                                               subjectId,
                                               optionalSubjectRelation);

            ListViewItem item = new ListViewItem(new[] {listView1.Items.Count.ToString(),
                    resourceType,resourceId,relation,
                    subjectType,subjectId                    });

            listView1.Items.Add(item);
        }

    }

}
