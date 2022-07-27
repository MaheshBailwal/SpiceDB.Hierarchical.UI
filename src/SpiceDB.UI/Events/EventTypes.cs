using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceDB.UI.Events
{
    public enum EventType
    {
        LoadData,
        LoadDataTree,
        LoadDataList,
        StartImport,
        StartExport,
        UpDateExportButtonText,
        NodeSelectedForOperation,
        AddChildNodes,
        TreeNodeSelectionChanged,
        ListItemSelectionChanged,
        LayOutNodeUpdated,

    }
}
