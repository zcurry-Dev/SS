using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SsuserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Ssrole Role { get; set; }
        public virtual Ssuser User { get; set; }
    }
}
