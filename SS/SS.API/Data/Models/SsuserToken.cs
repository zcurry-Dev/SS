using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SS.API.Data.Models
{
    public partial class SsuserToken : IdentityUserToken<int>
    {
        // public int UserId { get; set; }
        // public string LoginProvider { get; set; }
        // public string Name { get; set; }
        // public string Value { get; set; }

        public virtual Ssuser User { get; set; }
    }
}
