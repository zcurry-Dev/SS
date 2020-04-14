using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SsroleClaim
    {
        public int RoleClaimId { get; set; }
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Ssrole Role { get; set; }
    }
}
