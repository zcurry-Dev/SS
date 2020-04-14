using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SsuserToken
    {
        public int UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Ssuser User { get; set; }
    }
}
