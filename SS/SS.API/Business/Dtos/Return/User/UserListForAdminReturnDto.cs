using System.Collections.Generic;

namespace SS.API.Business.Dtos.Return
{
    public class UserListForAdminReturnDto
    {
        public IEnumerable<UserForAdminReturnDto> Users { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}