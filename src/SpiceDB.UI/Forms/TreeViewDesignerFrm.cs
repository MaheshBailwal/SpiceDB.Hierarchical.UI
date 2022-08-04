using Newtonsoft.Json;
using SpiceDB.Core;

namespace SpiceDB.UI.Forms
{
    public partial class TreeViewDesignerFrm : Form
    {
        private const string AddWrapperNode = $"Add Wrapper Node";
        private TreeNode _selectedNode;

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
                    var relationNode = entityNode.Nodes.Add(relation.Name, $"{relation.Name} ({relation.SubjectTypeWithoutHash})");
                    relationNode.Tag = relation;
                }

            }
        }

        private void trvSchema_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.  
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

        }

        private void trvLayOut_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = trvLayOut.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = trvLayOut.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (draggedNode.Tag is SchemaEntity)
            {
                MessageBox.Show("Only relationships are allowed");
                return;
            }

            if (draggedNode.TreeView == trvSchema)
                AddLinkNodesEx(draggedNode, targetNode);
            else
                NodeMoved(draggedNode, targetNode);
          
        }


        private void AddLinkNodesEx(TreeNode draggedNode, TreeNode targetNode)
        {

            TreeNode parentNode;
            Relation relation;
            relation = (Relation)draggedNode.Tag;
            //if (draggedNode.TreeView == trvSchema)
            //{
            //    relation = (Relation)draggedNode.Tag;
            //}
            //else
            //{
            //    var relationInfo = (RelationInfo)draggedNode.Tag;
            //    relation = relationInfo.Relation;
            //}



            if (trvLayOut.Nodes.Count < 1)
            {
                var rootNode = trvLayOut.Nodes.Add("Root");
                rootNode.Tag = new RelationInfo(true);

                parentNode = rootNode.Nodes.Add($"{relation.ResourceType} (Root)");
                parentNode.Tag = new RelationInfo(relation, false);
            }
            else
            {
                var relationInfo = targetNode.Tag as RelationInfo;

                if (relationInfo.Relation.ResourceType != relation.ResourceType &&
                    relationInfo.Relation.ResourceType != relation.SubjectTypeWithoutHash)
                {
                    MessageBox.Show($"{relation.ResourceType} is not compatible  with dropped");
                    return;
                }

                parentNode = targetNode;

                //relationsTag.Add(new RelationInfo(relation, relationsTag.EntityType == relation.SubjectType));
            }
            AddChildLayoutTreeNode(parentNode, relation);

        }

        private void NodeMoved(TreeNode draggedNode, TreeNode targetNode)
        {
            var relationInfo = (RelationInfo)draggedNode.Tag;

            var targetRelationInfo = (RelationInfo)targetNode.Tag;

            if (targetRelationInfo.IsWrapperNode)
            {
                int index = draggedNode.Parent.Nodes.IndexOf(draggedNode);
                draggedNode.Parent.Nodes.RemoveAt(index);
                targetNode.Nodes.Add(draggedNode);
            }
        }

        private TreeNode AddChildLayoutTreeNode(TreeNode parentNode, Relation relation)
        {
            TreeNode childNode = null;
            var parentRelationInfo = parentNode.Tag as RelationInfo;

            //if(parentRelationInfo.IsWrapperNode)
            //{
            //    parentRelationInfo = parentNode.Parent.Tag as RelationInfo;
            //}


            if (relation.IsSelfRelation)
            {
                childNode = GetNewLayOutNode(parentNode, relation.SubjectType + $"({relation.Name} (S))");
                childNode.Tag = new RelationInfo(relation, true);
            }

            else if (parentRelationInfo.Relation.ResourceType != relation.SubjectTypeWithoutHash)
            {
                childNode = GetNewLayOutNode(parentNode, relation.SubjectType + $"({relation.Name} (R))");
                childNode.Tag = new RelationInfo(relation, false);
            }

            else if (parentRelationInfo.Relation.ResourceType == relation.SubjectTypeWithoutHash)
            {
                childNode = GetNewLayOutNode(parentNode, relation.ResourceType + $"({relation.Name} (S))");
                childNode.Tag = new RelationInfo(relation, true);
            }

            return childNode;
        }

        private TreeNode GetNewLayOutNode(TreeNode parentNode, string text)
        {
            if (parentNode == null)
                return trvLayOut.Nodes.Add(text);
            else
                return parentNode.Nodes.Add(text);
        }

        private void LoadDisplayNode(DisplayNode displayNode, TreeNode parent)
        {
            TreeNode node = null;

            if (displayNode.IsWrapperNode)
            {
                node = GetNewLayOutNode(parent, displayNode.WrapperNodeName);
                node.Tag = new RelationInfo(true);
            }
            else
            {
                var arr = displayNode.RelationShipWithParent.Split('.');
                var entity = SpiceDBService.Instance.SchemaEntities.First(x => x.ResourceType == arr[0]);
                var relation = entity.Relationships.FirstOrDefault(x => x.Name == arr[1]);

                //TODO: mutiple relation support
                node = GetNewLayOutNode(parent, $"{displayNode.EntityType} ({displayNode.RelationShipWithParent})");
                node.Tag = new RelationInfo(relation, displayNode.CompareParentWithSubject);
            }

            foreach (var dn in displayNode.ChildNodes)
            {
                LoadDisplayNode(dn, node);
            }
        }

        private void GenerateDisplayNode(TreeNode treeNode, DisplayNode displayNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                DisplayNode childDisplayNode = GetDisplayNode(node);

                displayNode.ChildNodes.Add(childDisplayNode);

                GenerateDisplayNode(node, childDisplayNode);
            }
        }

        private static DisplayNode GetDisplayNode(TreeNode node)
        {
            var childDisplayNode = new DisplayNode();

            var relationInfo = node.Tag as RelationInfo;

            if (relationInfo.IsWrapperNode)
            {
                childDisplayNode.IsWrapperNode = true;
                childDisplayNode.WrapperNodeName = node.Text;
                return childDisplayNode;
            }

            childDisplayNode.EntityType = relationInfo.Relation.ResourceType;
            //this fail in case of role or user not sure
            childDisplayNode.TemplateId = relationInfo.Relation.ResourceType;

            if (relationInfo.Relation.IsSelfRelation)
                childDisplayNode.MapeToTemplateId = childDisplayNode.TemplateId;

            childDisplayNode.CompareParentWithSubject = relationInfo.ComapreParentWithSubject;
            childDisplayNode.RelationShipWithParent = $"{relationInfo.Relation.ResourceType}.{relationInfo.Relation.Name}";
            return childDisplayNode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var node = trvLayOut.Nodes[0];
            var displayNode = GetDisplayNode(node);

            GenerateDisplayNode(node, displayNode);

            var json = JsonConvert.SerializeObject(displayNode);

            var file = GetFileToSave();
            if (!string.IsNullOrWhiteSpace(file))
            {
                File.WriteAllText(file, json);
            }

            // TreeLayOut.DisplayNode = displayNode;
        }
        private string GetFileToSave()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "json File|*.json";
            saveFileDialog1.Title = "Save Tree Layout File";
            saveFileDialog1.ShowDialog();
            return saveFileDialog1.FileName;
        }
        private class RelationInfo
        {
            public RelationInfo(bool isWrapperNode)
            {
                IsWrapperNode = isWrapperNode;
            }
            public RelationInfo(Relation relation, bool comapreParentWithSubject)
            {
                Relation = relation;
                ComapreParentWithSubject = comapreParentWithSubject;
            }
            public Relation Relation { get; private set; }

            public bool ComapreParentWithSubject { get; private set; }

            public bool IsWrapperNode { get; private set; }

            public override string ToString()
            {
                return $"{Relation.Name}-> {"Subject:"} { ComapreParentWithSubject}";
            }

        }

        private void trvLayOut_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void trvLayOut_DragLeave(object sender, EventArgs e)
        {

        }

        private void trvLayOut_DragOver(object sender, DragEventArgs e)
        {

        }

        private void trvLayOut_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.  
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void trvLayOut_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //var info = e.Node.Tag as RelationInfo;
            //MessageBox.Show(info.ToString());

            // e.Node.Remove();
        }

        private void trvLayOut_MouseHover(object sender, EventArgs e)
        {
            //TreeNode selNode = (TreeNode)trvLayOut.GetNodeAt(trvLayOut.PointToClient(Cursor.Position));

            //if (selNode != null)
            //{
            //    if (selNode.Tag != null)
            //    {
            //        var relationInfo = selNode.Tag as RelationInfo;
            //        selNode.ToolTipText = relationInfo.ToString();
            //    }

            //}
        }

        private void trvLayOut_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _selectedNode = trvLayOut.SelectedNode;
                contextMenuStrip1.Items.Clear();

                if (_selectedNode == null)
                    return;

                if ((_selectedNode.Tag as RelationInfo).IsWrapperNode)
                    contextMenuStrip1.Items.Add($"Rename");

                contextMenuStrip1.Items.Add(AddWrapperNode);
                contextMenuStrip1.Items.Add($"Delete");
                contextMenuStrip1.Items.Add($"Properties");

                _selectedNode.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case AddWrapperNode:
                    AddWrapperNodeFun();
                    break;
                case "Delete":
                    _selectedNode.Remove();
                    break;
                case "Rename":
                    _selectedNode.BeginEdit();
                    break;
            }
        }

        private void AddWrapperNodeFun()
        {

            var parent = _selectedNode.Parent;
            int index = parent.Nodes.IndexOf(_selectedNode);
            parent.Nodes.RemoveAt(index);

            var wrapperNode = new TreeNode("Enetr Name");
            wrapperNode.Tag = new RelationInfo(true);

            parent.Nodes.Insert(index, wrapperNode);
            wrapperNode.Nodes.Add(_selectedNode);



            trvLayOut.SelectedNode = wrapperNode;
            trvLayOut.LabelEdit = true;
            if (!wrapperNode.IsEditing)
            {
                wrapperNode.BeginEdit();
            }
        }



        private void trvLayOut_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                           "The invalid characters are: '@','.', ',', '!'",
                           "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                       "Node Label Edit");
                    e.Node.BeginEdit();
                }
            }
        }

        private void btnOpenLayout_Click(object sender, EventArgs e)
        {
            LaodLayoutHandler();
        }

        private async void LaodLayoutHandler()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "json file |*.json";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                string file = openFileDialog1.FileName;

                var json = File.ReadAllText(file);
                var displayNode = JsonConvert.DeserializeObject<DisplayNode>(json);

                LoadDisplayNode(displayNode, null);
                Cursor.Current = Cursors.Default;
            }
        }
    }


}
