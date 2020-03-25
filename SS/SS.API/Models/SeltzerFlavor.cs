using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SeltzerFlavor
    {
        public SeltzerFlavor()
        {
            Seltzer = new HashSet<Seltzer>();
        }

        public int SeltzerFlavorId { get; set; }
        public string SeltzerFlavor1 { get; set; }

        public virtual ICollection<Seltzer> Seltzer { get; set; }
    }
}
