namespace SS.Business.Pagination
{
    public class PageParams
    {
        private const int MaxPageSize = 50;
        public int PN { get; set; } = 1;
        public string OrderBy { get; set; }
        public string Search { get; set; }
    }

    public class AdminUsersParams : PageParams
    {
        private const int MaxPageSize = 50;
        private int ipp = 10;
        public int IPP
        {
            get { return ipp; }
            set { ipp = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }

    public class ArtistPageParams : PageParams
    {
        private const int MaxPageSize = 50;
        private int ipp = 10;
        public int IPP
        {
            get { return ipp; }
            set { ipp = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }

}