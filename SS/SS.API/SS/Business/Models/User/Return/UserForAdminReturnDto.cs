using System.Collections.Generic;

namespace SS.Business.Models.User
{
    public class UserForAdminReturnDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}