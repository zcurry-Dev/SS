using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SS.API.Models
{
    public partial class SsroleClaim : IdentityRoleClaim<int>
    {
        public int RoleClaimId { get; set; }
        // public int RoleId { get; set; }
        // public string ClaimType { get; set; }
        // public string ClaimValue { get; set; }

        public virtual Ssrole Role { get; set; }
    }
}
