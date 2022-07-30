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


            RelationsTag parentRelationsTag;
            if (trvLayOut.Nodes.Count < 1)
            {
                parentNode = trvLayOut.Nodes.Add($"{relation.ResourceType} (Root)");
                //  parentRelationsTag = new RelationsTag();
                // parentRelationsTag.Add(new RelationInfo(relation, false));
                //    parentRelationsTag.EntityType = relation.ResourceType;
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

            else if(parentRelationInfo.Relation.ResourceType != relation.SubjectTypeWithoutHash)
            {
                childNode = parentNode.Nodes.Add(relation.SubjectType + $"({relation.Name} (R))");

                childNode.Tag = new RelationInfo(relation, false);
            }

            else if (parentRelationInfo.Relation.ResourceType == relation.SubjectTypeWithoutHash)
            {
                childNode = parentNode.Nodes.Add(relation.ResourceType + $"({relation.Name} (S))");

                childNode.Tag = new RelationInfo(relation, true);
            }
            //else if (parentRelationInfo.Relation.ResourceType == relation.SubjectType)
            //{
            //    childNode = parentNode.Nodes.Add(relation.ResourceType + $"({relation.Name} (R))");

            //    childNode.Tag = new RelationInfo(relation, false);
            //}
            //else
            //{
            //    childNode = parentNode.Nodes.Add(relation.SubjectType + $"({relation.Name} (S))");

            //    childNode.Tag = new RelationInfo(relation, true);
            //}

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

            childDisplayNode.EntityType = relationInfo.Relation.ResourceType;
            //this fail in case of role or user not sure
            childDisplayNode.TemplateId = relationInfo.Relation.ResourceType;
        
            if(relationInfo.Relation.IsSelfRelation)
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

        private void AddLinkNodes(TreeNode draggedNode, TreeNode targetNode)
        {

            TreeNode node;
            var relation = (Relation)draggedNode.Tag;
            var schemaEntity = (SchemaEntity)draggedNode.Parent.Tag;

            var upstreamLinkInfo = GetUpStreamNode(draggedNode, targetNode);



            if (trvLayOut.Nodes.Count < 1)
            {
                node = trvLayOut.Nodes.Add($"{upstreamLinkInfo.RescourceType}");
            }
            else
            {
                var tt = $"{upstreamLinkInfo.RescourceType} {upstreamLinkInfo.UpStream?.Relation}" + "\u2191";
                tt += $"{upstreamLinkInfo.RescourceType} {upstreamLinkInfo.DownStream?.Relation}" + "\u2193";
                node = trvLayOut.Nodes.Add(tt);
            }

            node.Tag = upstreamLinkInfo;

            var downStreamLinkInfo = GetDownStreamNode(draggedNode, node);

            var tt1 = $"{downStreamLinkInfo.RescourceType} {downStreamLinkInfo.UpStream?.Relation.Name}" + "\u2191";
            tt1 += $"{downStreamLinkInfo.RescourceType}";

            if (downStreamLinkInfo.DownStream != null && downStreamLinkInfo.DownStream.Relation != null)
            {
                tt1 += downStreamLinkInfo.DownStream?.Relation.Name + "\u2193";
            }




            node = node.Nodes.Add(tt1);

            node.Tag = downStreamLinkInfo;
        }

        private LinkInfo GetUpStreamNode(TreeNode draggedNode, TreeNode targetNode)
        {
            var relation = (Relation)draggedNode.Tag;
            var schemaEntity = (SchemaEntity)draggedNode.Parent.Tag;


            if (targetNode == null)
            {
                return new LinkInfo()
                {
                    RescourceType = schemaEntity.ResourceType,
                    DownStream = new RelationInfo { Relation = relation, ComapreParentWithSubject = true }
                };
            }

            var targetLinkInfo = targetNode.Tag as LinkInfo;



            if (relation.SubjectType == targetLinkInfo.RescourceType)
            {
                targetLinkInfo.DownStream = new RelationInfo()
                {
                    Relation = relation,
                    ComapreParentWithSubject = true,
                };
            }

            else if (relation.ResourceType == targetLinkInfo.RescourceType)
            {
                targetLinkInfo.DownStream = new RelationInfo()
                {
                    Relation = relation,
                    ComapreParentWithSubject = false,
                };
            }

            return targetLinkInfo;
        }

        private LinkInfo GetDownStreamNode(TreeNode draggedNode, TreeNode targetNode)
        {
            var relation = (Relation)draggedNode.Tag;
            var schemaEntity = (SchemaEntity)draggedNode.Parent.Tag;

            var parentLinkInfo = targetNode.Tag as LinkInfo;

            var childLinkInfo = new LinkInfo();

            if (relation.SubjectType == parentLinkInfo.RescourceType)
            {
                childLinkInfo.RescourceType = relation.ResourceType;
                childLinkInfo.UpStream = new RelationInfo()
                {
                    Relation = relation,
                    ComapreParentWithSubject = false,
                };
            }

            else if (relation.ResourceType == parentLinkInfo.RescourceType)
            {
                childLinkInfo.RescourceType = relation.SubjectType;
                childLinkInfo.UpStream = new RelationInfo()
                {
                    Relation = relation,
                    ComapreParentWithSubject = true,
                };
            }

            return childLinkInfo;
        }

        private class RelationInfo
        {
            public RelationInfo()
            {

            }
            public RelationInfo(Relation relation, bool comapreParentWithSubject)
            {
                Relation = relation;
                ComapreParentWithSubject = comapreParentWithSubject;
            }
            public Relation Relation { get; set; }

            public bool ComapreParentWithSubject { get; set; }

            //  public string RelationShipWithParent { get; set; }

            public override string ToString()
            {
                return $"{Relation.Name}-> {"Subject:"} { ComapreParentWithSubject}";
            }

        }

        private class RelationsTag
        {
            public RelationsTag()
            {
                RelationInfos = new List<RelationInfo>();
            }
            public List<RelationInfo> RelationInfos { get; set; }

            public void Add(RelationInfo relationInfo)
            {
                RelationInfos.Add(relationInfo);
            }

            public string EntityType { get; set; }

        }

        private class LinkInfo
        {
            public string RescourceType { get; set; }
            public RelationInfo UpStream { get; set; }
            public RelationInfo DownStream { get; set; }
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

            e.Node.Remove();
        }

        private void trvLayOut_MouseHover(object sender, EventArgs e)
        {
            TreeNode selNode = (TreeNode)trvLayOut.GetNodeAt(trvLayOut.PointToClient(Cursor.Position));

            if (selNode != null)
            {
                if (selNode.Tag != null)
                {
                    var relationInfo = selNode.Tag as RelationInfo;
                    selNode.ToolTipText = relationInfo.ToString();
                }

            }
        }


    }
}
