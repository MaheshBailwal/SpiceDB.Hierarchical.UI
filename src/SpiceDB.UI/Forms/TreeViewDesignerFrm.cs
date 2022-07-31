using SpiceDB.Core;
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


            //if (targetNode == null)
            //{
            //    return;
            //}

            AddLinkNodesEx(draggedNode, targetNode);

            if (draggedNode.TreeView == trvLayOut)
            {
                draggedNode.Remove();
            }
        }


        private void AddLinkNodesEx(TreeNode draggedNode, TreeNode targetNode)
        {

            TreeNode parentNode;
            var relation = (Relation)draggedNode.Tag;
            var schemaEntity = (SchemaEntity)draggedNode.Parent.Tag;



            if (trvLayOut.Nodes.Count < 1)
            {
                parentNode = trvLayOut.Nodes.Add($"{relation.ResourceType} (Root)");
                parentNode.Tag = new RelationInfo(relation, false);
            }
            else
            {
                var relationInfo = targetNode.Tag as RelationInfo;



                if (relationInfo.Relation.ResourceType != relation.ResourceType && relationInfo.Relation.ResourceType != relation.SubjectTypeWithoutHash)
                {
                    MessageBox.Show($"{relation.ResourceType} is not compatible  with dropped");
                    return;
                }

                parentNode = targetNode;

                //relationsTag.Add(new RelationInfo(relation, relationsTag.EntityType == relation.SubjectType));
            }

            TreeNode childNode;

            var parentRelationInfo = parentNode.Tag as RelationInfo;


            if (relation.IsSelfRelation)
            {
                childNode = parentNode.Nodes.Add(relation.SubjectType + $"({relation.Name} (S))");

                childNode.Tag = new RelationInfo(relation, true);
            }

            else if (parentRelationInfo.Relation.ResourceType != relation.SubjectTypeWithoutHash)
            {
                childNode = parentNode.Nodes.Add(relation.SubjectType + $"({relation.Name} (R))");

                childNode.Tag = new RelationInfo(relation, false);
            }

            else if (parentRelationInfo.Relation.ResourceType == relation.SubjectTypeWithoutHash)
            {
                childNode = parentNode.Nodes.Add(relation.ResourceType + $"({relation.Name} (S))");

                childNode.Tag = new RelationInfo(relation, true);
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
            var dn = GetDisplayNode(node);

            GenerateDisplayNode(node, dn);

            TreeLayOut.DisplayNode = dn;
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
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                           "The invalid characters are: '@','.', ',', '!'",
                           "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                       "Node Label Edit");
                    e.Node.BeginEdit();
                }
            }
        }
    }


}
