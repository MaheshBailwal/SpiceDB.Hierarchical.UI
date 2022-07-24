using Authzed.Api.V1;

namespace SpiceDB.UI
{
    public class TreeLayOut
    {
        public static DisplayNode DisplayNode;

        public static DisplayNode RootDisplayNode;

        static TreeLayOut()
        {
            RootDisplayNode = new DisplayNode()
            {
                WrapperNodeName = "Orgs",
                IsWrapperNode = true,

                ChildNodes = new List<DisplayNode>()
                {
                           new DisplayNode()
                            {
                                DataEntityName = "csmi/organization",
                                RelationShipWithParent = "",
                                MapeToTemplateId = "csmi/organization",
                            }

            }
            };

            DisplayNode = new DisplayNode()
            {
                TemplateId = "csmi/organization",
                IsIdNode = true,
                ChildNodes = new List<DisplayNode>()
                {
                    new DisplayNode()
                    {
                           WrapperNodeName = "Orgs",
                           IsWrapperNode = true,

                           ChildNodes= new List<DisplayNode>()
                           {
                               new DisplayNode()
                               {
                                    DataEntityName = "csmi/organization",
                                    RelationShipWithParent= "csmi/organization.parent",
                                    MapeToTemplateId ="csmi/organization",
                               }
                           }

                    },

                     new DisplayNode()
                    {
                           WrapperNodeName = "Assets",
                           IsWrapperNode= true,
                           ChildNodes= new List<DisplayNode>()
                           {
                               new DisplayNode()
                               {
                                    TemplateId = "csmi/asset",
                                   DataEntityName = "csmi/asset",
                                    MapeToTemplateId="csmi/asset",
                                    RelationShipWithParent= "csmi/asset.manager,csmi/asset.viewer, csmi/asset.historical",
                                    DisplayTemplate ="id (relation)",
                                    ChildNodes= new List<DisplayNode>()
                                    {
                                        new DisplayNode()
                                        {
                                            TemplateId = "csmi/asset.device",
                                            DataEntityName = "csmi/device",
                                            MapeToTemplateId="csmi/asset.device",
                                            RelationShipWithParent= "csmi/device.container",
                                        }
                                    }
                               }
                           }
                    },

                        new DisplayNode()
                    {
                           WrapperNodeName = "Devices",
                           IsWrapperNode= true,
                           ChildNodes= new List<DisplayNode>()
                           {
                               new DisplayNode()
                               {
                                   DataEntityName = "csmi/device",
                                    RelationShipWithParent= "csmi/device.manager",

                               }
                           }
                    },
                 new DisplayNode()
                    {
                           WrapperNodeName = "Users",
                           IsWrapperNode= true,
                           ChildNodes= new List<DisplayNode>()
                           {
                               new DisplayNode()
                               {
                                    TemplateId="csmi/organization.user",
                                    DataEntityName = "csmi/organization",
                                    RelationShipWithParent= "csmi/organization.administrator,csmi/organization.nonadmin",
                                    CompareSubject=false,
                                    MapeToTemplateId="csmi/organization.administrator",
                                    DisplayTemplate="id (relation)"
                               }
                           }
               },

                       new DisplayNode()
                    {
                           WrapperNodeName = "Roles",
                           IsWrapperNode= true,
                           ChildNodes= new List<DisplayNode>()
                           {
                               new DisplayNode()
                               {
                                    TemplateId = "csmi/role",
                                    DataEntityName = "csmi/role",
                                    MapeToTemplateId="csmi/role",
                                    RelationShipWithParent= "csmi/role.manager,csmi/role.viewer",
                                    DisplayTemplate ="id (relation)",
                                    ChildNodes= new List<DisplayNode>()
                                    {
                                        new DisplayNode()
                                        {
                                            WrapperNodeName = "Users",
                                            IsWrapperNode= true,
                                            ChildNodes= new List<DisplayNode>()
                                            {
                                                new DisplayNode()
                                                {
                                                    TemplateId = "csmi/role.user",
                                                    DataEntityName = "csmi/role",
                                                    MapeToTemplateId="csmi/role.user",
                                                    RelationShipWithParent= "csmi/role.direct_member",
                                                    CompareSubject=false,
                                                    DisplayTemplate ="id (relation)",
                                                                }
                                            }

                                        },

                                           new DisplayNode()
                                        {
                                            WrapperNodeName = "RBAC",
                                            IsWrapperNode= true,
                                            ChildNodes= new List<DisplayNode>()
                                            {
                                                new DisplayNode()
                                                {
                                                    TemplateId = "csmi/rbac_entity",
                                                    DataEntityName = "csmi/rbac_entity",
                                                    MapeToTemplateId="csmi/rbac_entity",
                                                    RelationShipWithParent= "csmi/rbac_entity.creator," +
                                                    "csmi/rbac_entity.reader,csmi/rbac_entity.updater,csmi/rbac_entity.deleter",
                                                    DisplayTemplate ="id (relation)",
                                                                }
                                            }

                                        }

                                    }
                               }
                           }
                    },


                }
            };



        }

    

    }

    public class DisplayNode
    {
        public string TemplateId { get; set; }
        public string WrapperNodeName { get; set; }

        public string DisplayTemplate { get; set; } = "id";

        public string DataEntityName { get; set; }

        public string MapeToTemplateId { get; set; }

        public string RelationShipWithParent { get; set; }


        public bool CompareSubject { get; set; } = true;

        public List<DisplayNode> ChildNodes { get; set; } = new List<DisplayNode>();

        public bool IsWrapperNode { get; set; }

        public bool IsIdNode { get; set; }

        public IEnumerable<string> GetRelations()
        {
            var relations = new List<string>();
            if (!string.IsNullOrWhiteSpace(RelationShipWithParent))
            {
                var realtions = RelationShipWithParent.Split(',');
                foreach (var rel in realtions)
                    relations.Add(rel.Split('.')[1]);
            }

            return relations;
        }
        public DisplayNode Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;

            if (TemplateId == id)
                return this;

            foreach (var dn in ChildNodes)
            {
                var foundNode = dn.Find(id);
                if (foundNode != null)
                    return foundNode;
            }

            return null;
        }

    }

    public class NodeTag
    {
        public NodeTag(DisplayNode displayNode, Relationship relation)
        {
            DisplayNode = displayNode;
            Relation = relation;    
        }
        public DisplayNode DisplayNode { get; private set; }
    
        public Relationship Relation { get; private set; }
    }
    
   
}
