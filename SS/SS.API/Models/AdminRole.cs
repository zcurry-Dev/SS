using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class AdminRole
    {
        public AdminRole()
        {
            AdminRolesXref = new HashSet<AdminRolesXref>();
        }

        public int AdminRoleId { get; set; }
        public string AdminRole1 { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<AdminRolesXref> AdminRolesXref { get; set; }
    }
}
