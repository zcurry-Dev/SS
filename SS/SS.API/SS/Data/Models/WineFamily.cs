using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class WineFamily
    {
        public WineFamily()
        {
            WineType = new HashSet<WineType>();
        }

        public int WineFamilyId { get; set; }
        public string WineFamily1 { get; set; }

        public virtual ICollection<WineType> WineType { get; set; }
    }
}
