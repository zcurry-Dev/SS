using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SS.Data.Models
{
    public partial class SsuserRole : IdentityUserRole<int>
    {
        // public int UserId { get; set; }
        // public int RoleId { get; set; }

        public virtual Ssrole Role { get; set; }
        public virtual Ssuser User { get; set; }
    }
}
