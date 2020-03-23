using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SpiritFamily
    {
        public SpiritFamily()
        {
            SpiritType = new HashSet<SpiritType>();
        }

        public int SpiritFamilyId { get; set; }
        public string SpiritFamily1 { get; set; }

        public virtual ICollection<SpiritType> SpiritType { get; set; }
    }
}
