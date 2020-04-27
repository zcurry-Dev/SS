using System.Collections.Generic;

namespace SS.API.Business.Dtos.User
{
    public class UsersWithRolesDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}