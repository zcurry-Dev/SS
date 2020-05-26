using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SS.API.Data.Models
{
    public partial class SsuserLogin : IdentityUserLogin<int>
    {
        // public string LoginProvider { get; set; }
        // public string ProviderKey { get; set; }
        // public string ProviderDisplayName { get; set; }
        // public int UserId { get; set; }

        public virtual Ssuser User { get; set; }
    }
}
