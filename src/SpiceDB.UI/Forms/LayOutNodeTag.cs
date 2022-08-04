using SpiceDB.Core;

namespace SpiceDB.UI.Forms
{
    public partial class TreeViewDesignerFrm
    {
        private class LayOutNodeTag
        {
            public LayOutNodeTag(bool isWrapperNode)
            {
                IsWrapperNode = isWrapperNode;
            }
            public LayOutNodeTag(Relation relation, bool comapreParentWithSubject)
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
    }
}
