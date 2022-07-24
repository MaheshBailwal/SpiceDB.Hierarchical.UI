using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceDB.Core.Types
{
    public struct ResultList<T>
    {
        public List<T> Data { get; set; }
    }

    public enum CacheFreshness
    {
        AnyFreshness,
        AtLeastAsFreshAs,
        MustRefresh
    }
}
