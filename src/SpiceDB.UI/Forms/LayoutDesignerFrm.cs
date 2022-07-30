using SpiceDB.UI.Events;

namespace SpiceDB.UI.Forms
{
    public partial class LayoutDesignerFrm : Form, IEventSubscriber
    {
        TreeNode _selectedNode;
        public LayoutDesignerFrm()
        {
            InitializeComponent();
            SubScribeEvents();
        }

        public void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventType.LayOutNodeUpdated.ToString(), LayOutNodeUpdatedEventHandler);
        }

        public void UnSubScribeEvents()
        {
            EventContainer.UnSubscribeAll(this);
        }

        private async void LayOutNodeUpdatedEventHandler(EventArg arg)
        {
            AddNode(treeView1.SelectedNode, arg.Arg as DisplayNode);
        }

        private void AddNode(TreeNode parentNode, DisplayNode displayNode)
        {
            var node = parentNode.Nodes.Add(displayNode.EntityType, displayNode.EntityType);
            node.Tag = displayNode;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            new AddDisplayNodeFrm("").Show();
        }

        private void LayoutDesignerFrm_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("Root", "Root");
        }

        private void LayoutDesignerFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnSubScribeEvents();
        }
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedNode = treeView1.SelectedNode;
                contextMenuStrip1.Items.Clear();

                if (selectedNode == null)
                    return;

              

                // if (nodeTag != null && !nodeTag.DisplayNode.IsWrapperNode)
                {
                    contextMenuStrip1.Items.Add($"Add Child Node To {selectedNode.Text}");
                    contextMenuStrip1.Items.Add($"Update");
                }


                selectedNode.ContextMenuStrip = contextMenuStrip1;
            }

        }

        private void contextMenuStrip1_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.StartsWith("Add"))
            {
                _selectedNode = treeView1.SelectedNode;

                new AddDisplayNodeFrm(_selectedNode.Text).ShowDialog();
            }
            else if (e.ClickedItem.Text.StartsWith("Copy"))
            {
                Clipboard.SetText(treeView1.SelectedNode.Name);
            }
        }
    }
}
