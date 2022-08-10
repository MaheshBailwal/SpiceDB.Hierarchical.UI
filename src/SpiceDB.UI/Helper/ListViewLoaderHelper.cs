using SpiceDB.UI.Events;

namespace SpiceDB.UI.Helper
{
    internal class ListViewLoader : IEventSubscriber
    {
        ListView _listView;
        public void SubScribeEvents()
        {
            EventContainer.SubscribeEvent(EventType.LoadDataList, LoadDataListEventHandler);
            EventContainer.SubscribeEvent(EventType.TreeNodeSelectionChanged, TreeViewSelectionChangedEventHandler);
        }

        public void UnSubScribeEvents()
        {
            EventContainer.UnSubscribeAll(this);
        }

        private void LoadDataListEventHandler(EventArg arg)
        {
            _listView = arg.Arg as ListView;

            LoadData();
        }

        private void TreeViewSelectionChangedEventHandler(EventArg arg)
        {

            foreach (ListViewItem item in _listView.Items)
            {
                if (item.Tag == arg.Arg)
                {
                    _listView.SelectedItems.Clear();
                    item.Selected = true;
                    _listView.EnsureVisible(item.Index);   
                    return;
                }
            }
        }

        private void LoadData()
        {
            _listView.Items.Clear();
            foreach (var rescource in SpiceDBService.Instance.AllData)
            {
                foreach (var realation in rescource.Value.Data)
                {
                    ListViewItem item = new ListViewItem(new[] {(_listView.Items.Count +1).ToString(),
                    realation.Resource.ObjectType,realation.Resource.ObjectId,realation.Relation,
                    realation.Subject.Object.ObjectType,realation.Subject.Object.ObjectId
                    });

                    item.Tag = realation;

                    _listView.Items.Add(item);
                }
            }
        }


    }
}
