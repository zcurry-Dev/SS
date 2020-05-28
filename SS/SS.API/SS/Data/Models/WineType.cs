using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class WineType
    {
        public WineType()
        {
            Wine = new HashSet<Wine>();
            WineTypeSpecific = new HashSet<WineTypeSpecific>();
        }

        public int WineTypeId { get; set; }
        public string WineType1 { get; set; }
        public int WineFamilyId { get; set; }

        public virtual WineFamily WineFamily { get; set; }
        public virtual ICollection<Wine> Wine { get; set; }
        public virtual ICollection<WineTypeSpecific> WineTypeSpecific { get; set; }
    }
}
