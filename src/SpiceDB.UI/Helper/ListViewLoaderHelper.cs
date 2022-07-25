using SpiceDB.UI.Events;
using Authzed.Api.V1;

namespace SpiceDB.UI.Helper
{
    internal class ListViewLoader : IEventSubscriber
    {
        TreeView treeView1;
        //keep eagerLoad flase display duplicate root nodes
        //as child node are not loaded hence duplicasy can not be descovered
        //may need to work on that later
        bool eagerLaod = true;
        private string _selectedNodeParentKey = "";
        public void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventType.LoadDataList.ToString(), LoadDataListEventHandler);
        }

        public void UnSubScribeEvents()
        {
            EventContainer.UnSubscribeAll(this);
        }

        private void LoadDataListEventHandler(EventArg arg)
        {
            var listView = arg.Arg as ListView;

           LoadData(listView);
        }

        private void LoadData(ListView listView)
        {
            foreach (var rescource in SpiceDBService.Instance.AllData)
            {
                foreach (var realation in rescource.Value.Data)
                {
                    ListViewItem item = new ListViewItem(new[] {listView.Items.Count.ToString(),
                    realation.Resource.ObjectType,realation.Resource.ObjectId,realation.Relation,
                    realation.Subject.Object.ObjectType,realation.Subject.Object.ObjectId
                    });

                    listView.Items.Add(item);
                }
            }
        }


    }
}
