using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SsuserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        public virtual Ssuser User { get; set; }
    }
}
