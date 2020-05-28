using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SS.Data.Models
{
    public partial class Ssrole : IdentityRole<int>
    {
        public Ssrole()
        {
            SsroleClaim = new HashSet<SsroleClaim>();
            SsuserRole = new HashSet<SsuserRole>();
        }

        public int RoleId { get; set; }
        // public string Name { get; set; }
        // public string NormalizedName { get; set; }
        // public string ConcurrencyStamp { get; set; }

        public virtual ICollection<SsroleClaim> SsroleClaim { get; set; }
        public virtual ICollection<SsuserRole> SsuserRole { get; set; }
    }
}
