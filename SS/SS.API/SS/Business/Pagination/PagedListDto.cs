using System.Collections.Generic;

namespace SS.Business.Pagination
{
    public class PagedListDto<T> : PagedList<T>
    {
        public PagedListDto(List<T> items)
        {
            this.AddRange(items);
        }
    }
}