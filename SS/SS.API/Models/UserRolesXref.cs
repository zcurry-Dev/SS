using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class UserRolesXref
    {
        public int UserRoleXrefId { get; set; }
        public int UserId { get; set; }
        public int UserRoles { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Users User { get; set; }
        public virtual UserRoles UserRolesNavigation { get; set; }
    }
}
