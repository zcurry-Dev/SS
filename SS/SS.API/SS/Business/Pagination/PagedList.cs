using System.Collections.Generic;

namespace SS.Business.Pagination
{
    public class PagedList<T> : List<T>, IPagedList
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
    }
}