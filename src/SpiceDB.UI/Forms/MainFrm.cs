
using SpiceDB.UI.Events;
using SpiceDB.UI.Helper;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using SpiceDB.UI.Forms;
using Newtonsoft.Json;

namespace SpiceDB.UI
{
    public partial class MainFrm : Form, IEventSubscriber
    {
        private bool _autoRefresh = true;

        IEnumerable<IEventSubscriber> _eventSubscribers;
        private ListViewColumnSorter lvwColumnSorter;
        public MainFrm()
        {
            InitializeComponent();
            treeView1.ItemHeight = 22;
            _eventSubscribers = LoadEventSubScribers();

            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

            btnTest.Enabled = false;
            btnExport.Enabled = false;
            btnImport.Enabled = false;
            btnAddRelation.Enabled = false;
            btnOpenTreeViewDesigner.Enabled = false;


            foreach (var eventSubscriber in _eventSubscribers)
            {
                eventSubscriber.SubScribeEvents();
            }

            SubScribeEvents();
        }

        private IEnumerable<IEventSubscriber> LoadEventSubScribers()
        {
            var eventSubscriberType = typeof(IEventSubscriber);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => eventSubscriberType.IsAssignableFrom(p) && !p.IsInterface && !p.IsSubclassOf(typeof(Form)));


            List<IEventSubscriber> eventSubscribers = new();

            foreach (var type in types)
            {
                eventSubscribers.Add((IEventSubscriber)Activator.CreateInstance(type));
            }

            return eventSubscribers;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
        }

        public void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventType.LoadData.ToString(), LoadDataEventHandler);
            EventContainer.SubscribeEvent(EventType.UpDateExportButtonText.ToString(), UpDateExportButtonTextHandler);
        }

        public void UnSubScribeEvents()
        {
            EventContainer.UnSubscribeAll(this);
        }

        private async Task LoadDataEventHandler(EventArg arg)
        {
            Cursor = Cursors.WaitCursor;
            await SpiceDBService.Instance.Load(txtServer.Text, txtToken.Text);
            EventContainer.PublishEvent(EventType.LoadDataList.ToString(), new EventArg(listView1));
            PublishTreeLoadEvent();

            btnTest.Enabled = true;
            btnExport.Enabled = true;
            btnImport.Enabled = true;
            btnAddRelation.Enabled = true;
            btnOpenTreeViewDesigner.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void UpDateExportButtonTextHandler(EventArg arg)
        {
            btnExport.Text = arg.Arg.ToString();
        }

        private bool ConfirmDelete()
        {
            var confirmResult = MessageBox.Show($"Are you sure to delete {treeView1.SelectedNode.Text} ?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return confirmResult == DialogResult.Yes;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                await LoadDataEventHandler(null);
                button1.Enabled = true;
            }
            catch (Grpc.Core.RpcException ex)
            {

                MessageBox.Show(ex.ToString(), "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex.StatusCode == Grpc.Core.StatusCode.NotFound || ex.StatusCode == Grpc.Core.StatusCode.FailedPrecondition)
                {
                    var confirmResult = MessageBox.Show($"It seems you SpiceDB is not initialized. Do you want to initialize SpiceDB with default data?",
                                     "Confirm initialize SpiceDB with Wenco authorization schema!",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        SpiceDBService.Instance.ImportSchema(@"./schema.yaml");
                        await LoadDataEventHandler(null);
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
                button1.Enabled = true;
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
                return;

            if (!SpiceDBService.Instance.IsDataLoadedSucessfully())
            {
                MessageBox.Show($"It seems data is not loaded successfully from SpiceDB." +
                 $"{Environment.NewLine} Please click on Load Button again",
               "Something Went Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Question);

                treeView1.Nodes.Clear();
                treeView1.Nodes.Add("Please Reload by clicking on load button");

                return;
            }


            EventContainer.PublishEvent(EventType.AddChildNodes.ToString(), new EventArg(e.Node));
        }

        private void treeView1_BeforeExpandOld(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
                return;

            if (!SpiceDBService.Instance.IsDataLoadedSucessfully())
            {
                MessageBox.Show($"It seems data is not loaded successfully from SpiceDB." +
                 $"{Environment.NewLine} Please click on Load Button again",
               "Something Went Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Question);

                treeView1.Nodes.Clear();
                treeView1.Nodes.Add("Please Reload by clicking on load button");

                return;
            }
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedNode = treeView1.SelectedNode;
                contextMenuStrip1.Items.Clear();

                if (selectedNode == null)
                    return;

                var nodeTag = (NodeTag)selectedNode.Tag;

                if (nodeTag != null && !nodeTag.DisplayNode.IsWrapperNode)
                {
                    contextMenuStrip1.Items.Add($"Delete {selectedNode.Text} Relation");
                    contextMenuStrip1.Items.Add($"Copy");
                }


                selectedNode.ContextMenuStrip = contextMenuStrip1;
            }

        }

        private void contextMenuStrip1_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.StartsWith("Delete"))
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!ConfirmDelete())
                    return;

                EventContainer.PublishEvent(EventType.NodeSelectedForOperation.ToString(), new EventArg(treeView1.SelectedNode));

                DeleteRelation();

                if (_autoRefresh)
                    LoadDataEventHandler(null);

                Cursor.Current = Cursors.Default;
            }
            else if (e.ClickedItem.Text.StartsWith("Copy"))
            {
                Clipboard.SetText(treeView1.SelectedNode.Name);
            }
        }

        private void DeleteRelation()
        {
            var nodeTag = (NodeTag)treeView1.SelectedNode.Tag;

            var relation = nodeTag.Relation;

            SpiceDBService.Instance.DeleteRelation(relation.Resource.ObjectType, relation.Resource.ObjectId, relation.Relation, relation.Subject.Object.ObjectType,
                relation.Subject.Object.ObjectId, relation.Subject.OptionalRelation);

            return;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            var testFrm1 = new TestRelationFrm();
            testFrm1.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

            var helpFile = $"file://{Directory.GetParent(Assembly.GetEntryAssembly().Location)}/Help.html".Replace('\\', '/');
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = helpFile;
            process.Start();
        }

        private void btnAddRelation_Click(object sender, EventArgs e)
        {
            new AddRelationFrm().ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            EventContainer.PublishEvent(EventType.StartImport.ToString());
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            EventContainer.PublishEvent(EventType.StartExport.ToString(), new EventArg(treeView1));
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node?.Tag != null)
            {
                var nodeTag = e.Node.Tag as NodeTag;

                if (nodeTag != null && nodeTag.Relation != null)
                {
                    EventContainer.PublishEvent(EventType.TreeNodeSelectionChanged.ToString(), new EventArg(nodeTag.Relation));
                }
            }
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            EventContainer.PublishEvent(EventType.ListItemSelectionChanged.ToString(), new EventArg(listView1.SelectedItems[0].Tag));
        }

        private void btnOpenTreeViewDesigner_Click(object sender, EventArgs e)
        {
            new TreeViewDesignerFrm().Show();
        }

        private void btnChangeTreeLayout_Click(object sender, EventArgs e)
        {
            ChangeLayoutHandler();
        }

        private async void ChangeLayoutHandler()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "json file |*.json";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                string file = openFileDialog1.FileName;
                Properties.Settings.Default.CurrentTreeLayoutFile = file;
                Properties.Settings.Default.Save();
                PublishTreeLoadEvent();
                Cursor.Current = Cursors.Default;
            }
        }

        private void PublishTreeLoadEvent()
        {
            EventContainer.PublishEvent(EventType.LoadDataTree.ToString(), new EventArg(Tuple.Create(treeView1, Properties.Settings.Default.CurrentTreeLayoutFile)));
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }
    }
}