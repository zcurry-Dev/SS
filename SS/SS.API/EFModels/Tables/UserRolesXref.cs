using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class UserRolesXref
    {
        public int UserRoleXrefId { get; set; }
        public int SsuserId { get; set; }
        public int UserRoles { get; set; }
        public DateTime CreatedDate { get; set; }

        public Ssusers Ssuser { get; set; }
        public UserRoles UserRolesNavigation { get; set; }
    }
}
