using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class BeerType
    {
        public BeerType()
        {
            BeerTypeSpecific = new HashSet<BeerTypeSpecific>();
        }

        public int BeerTypeId { get; set; }
        public string BeerType1 { get; set; }
        public int BeerFamilyId { get; set; }

        public virtual BeerFamily BeerFamily { get; set; }
        public virtual ICollection<BeerTypeSpecific> BeerTypeSpecific { get; set; }
    }
}
