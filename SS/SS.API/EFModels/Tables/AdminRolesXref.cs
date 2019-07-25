using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class AdminRolesXref
    {
        public int AdminRolesXrefId { get; set; }
        public int AdminId { get; set; }
        public int UserRoles { get; set; }
        public DateTime CreatedDate { get; set; }

        public Admins Admin { get; set; }
        public AdminRoles UserRolesNavigation { get; set; }
    }
}
