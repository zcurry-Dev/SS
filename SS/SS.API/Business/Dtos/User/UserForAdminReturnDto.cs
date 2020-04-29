using System.Collections.Generic;

namespace SS.API.Business.Dtos.User
{
    public class UserForAdminReturnDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}