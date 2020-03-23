using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class WineFamilies
    {
        public WineFamilies()
        {
            WineTypes = new HashSet<WineTypes>();
        }

        public int WineFamilyId { get; set; }
        public string WineFamily { get; set; }

        public virtual ICollection<WineTypes> WineTypes { get; set; }
    }
}
