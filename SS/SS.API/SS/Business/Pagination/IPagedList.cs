namespace SS.Business.Pagination
{
    public interface IPagedList
    {
        int CurrentPage { get; set; }
        int TotalPages { get; set; }
        int ItemsPerPage { get; set; }
        int TotalItems { get; set; }
    }
}