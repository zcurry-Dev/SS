using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class UserRoles
    {
        public UserRoles()
        {
            UserRolesXref = new HashSet<UserRolesXref>();
        }

        public int UserRoleId { get; set; }
        public string UserRole { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<UserRolesXref> UserRolesXref { get; set; }
    }
}
