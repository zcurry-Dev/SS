namespace SS.API.Helpers.Pagination.PagedParams
{
    public class AdminUsersParams
    {
        private const int MaxPageSize = 50;
        public int PN { get; set; } = 1;
        private int ps = 10;
        public int PS
        {
            get { return ps; }
            set { ps = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string OrderBy { get; set; }
    }
}