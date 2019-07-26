using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class UserRolesXref
    {
        public int UserRoleXrefId { get; set; }
        public int UserId { get; set; }
        public int UserRoles { get; set; }
        public DateTime CreatedDate { get; set; }

        public Users User { get; set; }
        public UserRoles UserRolesNavigation { get; set; }
    }
}
