using System.Collections.Generic;

namespace SS.API.Business.Models
{
    public class UsersWithRoles
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}