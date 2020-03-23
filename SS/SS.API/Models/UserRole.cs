using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserRolesXref = new HashSet<UserRolesXref>();
        }

        public int UserRoleId { get; set; }
        public string UserRole1 { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<UserRolesXref> UserRolesXref { get; set; }
    }
}
