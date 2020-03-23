using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class AdminRolesXref
    {
        public int AdminRolesXrefId { get; set; }
        public int AdminId { get; set; }
        public int UserRoles { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssadmin Admin { get; set; }
        public virtual AdminRole UserRolesNavigation { get; set; }
    }
}
