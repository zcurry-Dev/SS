using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public class UsersWithRoles
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}