using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SS.Data.Models
{
    public partial class SsuserClaim : IdentityUserClaim<int>
    {
        public int UserClaimId { get; set; }
        // public int UserId { get; set; }
        // public string ClaimType { get; set; }
        // public string ClaimValue { get; set; }

        public virtual Ssuser User { get; set; }
    }
}
