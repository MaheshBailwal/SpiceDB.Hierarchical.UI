using SpiceDB.UI.Events;
using Authzed.Api.V1;

namespace SpiceDB.UI.Helper
{
    internal class DataLoaderHelper : IEventSubscriber
    {
        TreeView treeView1;
        //keep eagerLoad flase display duplicate root nodes
        //as child node are not loaded hence duplicasy can not be descovered
        //may need to work on that later
        bool eagerLaod = true;
        private string _selectedNodeParentKey = "";
        public void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventType.LoadData.ToString(), LoadDataEventHandler);
            EventContainer.SubscribeEvent(EventType.AddChildNodes.ToString(), AddChildNodesEventHandler);
            EventContainer.SubscribeEvent(EventType.NodeSelectedForOperation.ToString(), NodeSelectedForOperationEventHandler);
        }

        public void UnSubScribeEvents()
        {
            EventContainer.UnSubscribeAll(this);
        }

        private void NodeSelectedForOperationEventHandler(EventArg arg)
        {
            _selectedNodeParentKey = (arg.Arg as TreeNode).Parent.FullPath;
        }

        private void AddChildNodesEventHandler(EventArg arg)
        {
           var node = (arg.Arg as TreeNode);
           
            if (IsAlreadyLoaded(node))
            {
                return;
            }

            var displayNode = ((NodeTag)node.Tag).DisplayNode;

            foreach (var displayChildNode in displayNode.ChildNodes)
            {
                AddNode(displayChildNode, node);
            }

        }
        private async Task LoadDataEventHandler(EventArg arg)
        {
            var paras = arg.Arg as Object[];

            treeView1 = paras[0] as TreeView;

            await LoadTree(paras[1].ToString(), paras[2].ToString());
        }

        private bool IsAlreadyLoaded(TreeNode parent)
        {
            if (parent.Nodes.Count != 1)
                return true;

            if (parent.Nodes[0].Text != "init")
                return true;

            parent.Nodes.RemoveAt(0);

            return false;
        }

        private class FilteredData
        {
            public string DisplayText { get; set; }
            public Relationship Relationship { get; set; }
        }
        private async Task LoadTree(string server, string token)
        {
            treeView1.Nodes.Clear();
            var _spiceDBService = SpiceDBService.Instance;
            await _spiceDBService.Load(server, token);
            var rootNode = AddRoteNode();

            if (eagerLaod)
            {
                treeView1.ExpandAll();
                treeView1.CollapseAll();
            }

            rootNode.Expand();
            ExpandLastSelectedNode();
            RemoveDuplicateRootNodes();
        }

        private TreeNode AddRoteNode()
        {
            var rootNode = new TreeNode(TreeLayOut.RootDisplayNode.WrapperNodeName);
            rootNode.Tag = new NodeTag(TreeLayOut.RootDisplayNode, null);
            treeView1.Nodes.Add(rootNode);

            if (TreeLayOut.RootDisplayNode.ChildNodes.Count > 0)
            {
                rootNode.Nodes.Add("init", "init");
            }

            return rootNode;
        }

        private void AddNode(DisplayNode displayNode, TreeNode parentNode)
        {
            if (displayNode.IsWrapperNode)
            {
                var node = parentNode.Nodes.Add(displayNode.WrapperNodeName, displayNode.WrapperNodeName);
                node.Tag = new NodeTag(displayNode, null);

                if (displayNode.ChildNodes.Count > 0)
                {
                    node.Nodes.Add("init", "init");
                }

                return;
            }

            if (displayNode.IsIdNode)
            {
                AddNode(displayNode.ChildNodes.First(), parentNode);
                return;
            }

            if (string.IsNullOrEmpty(displayNode.DataEntityName))
                return;

            var parentNodeTag = (NodeTag)parentNode.Tag;

            var realParent = parentNodeTag.DisplayNode.IsWrapperNode ? parentNode.Parent : parentNode;

            var filteredData = GetFilterData(displayNode, realParent);

            foreach (var item in filteredData)
            {
                var nodeKey = item.DisplayText;

                var displayName = GetDisplayText(nodeKey);

                displayName = displayNode.DisplayTemplate.Replace("id", displayName)
                                                         .Replace("relation", item.Relationship.Relation);

                var node = parentNode.Nodes.Add(nodeKey, displayName);

                var displayNodeNew = TreeLayOut.DisplayNode.Find(displayNode.MapeToTemplateId);

                if (displayNodeNew == null)
                    displayNodeNew = displayNode;

                node.Tag = new NodeTag(displayNodeNew, item.Relationship);

                if (displayNodeNew != null && displayNodeNew.ChildNodes.Count > 0)
                {
                    node.Nodes.Add("init", "init");
                }
            }

            UpdateChildCount(parentNode);
        }

        private IEnumerable<FilteredData> GetFilterData(DisplayNode displayNode, TreeNode realParent)
        {
            if (!displayNode.GetRelations().Any())
                return GetDataWithoutRelation(displayNode.DataEntityName);
            else
                return FilterDataByRelations(SpiceDBService.Instance.AllData[displayNode.DataEntityName].Data,
                                           displayNode.GetRelations(),
                                           realParent?.Name,
                                           displayNode.CompareSubject);
        }

        private string GetDisplayText(string nodeKey)
        {
            //we can use this method to map id with same text using some
            //mapping file
            return nodeKey;
        }

        private IEnumerable<FilteredData> GetDataWithoutRelation(string resourceType)
        {
            var filterData = new List<FilteredData>();

            foreach (var resourceSchema in SpiceDBService.Instance.SchemaEntities)
            {
                foreach (var relationship in resourceSchema.Relationships)
                {
                    if (relationship.SubjectType == resourceType)
                    {
                        var data = SpiceDBService.Instance.AllData[resourceSchema.ResourceType].Data;

                        foreach (var x in data)
                        {
                            if (x.Subject.Object.ObjectType == resourceType)
                            {
                                filterData.Add(new FilteredData() { DisplayText = x.Subject.Object.ObjectId, Relationship = x });
                            }
                        }
                    }
                }
            }

            return filterData;
        }

        private void RemoveDuplicateRootNodes()
        {
            var nodes = treeView1.Nodes[0].Nodes;
            foreach (TreeNode node in nodes)
            {
                if (node != null)
                    RemoveOrphanNode(node);
                else
                {
                    RemoveDuplicateRootNodes();
                }
            }
        }

        private void RemoveOrphanNode(TreeNode node)
        {
            var list = treeView1.Nodes.Find(node.Name, true);

            if (list.Length < 2)
                return;

            TreeNode NodeNotToRemove = list.First();

            foreach (var child in list)
            {
                if (NodeNotToRemove.Level < child.Level)
                    NodeNotToRemove = child;
            }

            foreach (var child in list)
            {
                if (child != NodeNotToRemove)
                    treeView1.Nodes.Remove(child);
            }
        }
        private IEnumerable<FilteredData> FilterDataByRelations(IEnumerable<Relationship> data,
                                             IEnumerable<string> relations,
                                              string subject,
                                              bool comapreSubject)
        {
            var filteredData = new List<FilteredData>();

            foreach (var relation in relations)
            {
                foreach (var rel in data)
                {
                    if ((comapreSubject && rel.Subject.Object.ObjectId == subject && rel.Relation == relation) ||
                        (!comapreSubject && rel.Resource.ObjectId == subject && rel.Relation == relation))
                    {
                        filteredData.Add(new FilteredData()
                        {
                            DisplayText = comapreSubject ? rel.Resource.ObjectId : rel.Subject.Object.ObjectId,
                            Relationship = rel
                        });
                    }
                }
            }

            return filteredData;
        }

        private void ExpandLastSelectedNode()
        {
            if (string.IsNullOrEmpty(_selectedNodeParentKey))
                return;

            var paths = _selectedNodeParentKey.Split('\\');

            for (var i = 0; i < paths.Length; i++)
            {
                paths[i] = paths[i].RemoveParenthesis();
            }

            ExpandLastSelectedNode(treeView1.Nodes[0], 1, paths);
        }

        private void ExpandLastSelectedNode(TreeNode node, int index, string[] paths)
        {
            if (index > paths.Length)
                return;

            if (node.FullPath.RemoveParenthesisFromPath() == string.Join('\\', paths, 0, index))
            {
                node.Expand();
                index++;
                foreach (TreeNode childNode in node.Nodes)
                {
                    ExpandLastSelectedNode(childNode, index, paths);
                }
            }
        }

        private static void UpdateChildCount(TreeNode parent)
        {
            var nodeTag = parent.Tag as NodeTag;

            if (nodeTag != null
                && nodeTag.DisplayNode != null
                && parent.Parent != null
                && nodeTag.DisplayNode.IsWrapperNode)

                parent.Text += $" ({parent.Nodes.Count})";
        }
    }
}
