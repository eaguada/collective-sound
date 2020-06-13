using System.Collections.Generic;

namespace CollectiveSound.Utils.Collections
{
    public interface IPagedList<T>
    {
        int TotalCount { get; set; }

        IList<T> Items { get; set; }
    }
}
