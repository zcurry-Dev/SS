using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class BeerType
    {
        public BeerType()
        {
            Beer = new HashSet<Beer>();
        }

        public int BeerTypeId { get; set; }
        public string BeerType1 { get; set; }
        public int BeerFamilyId { get; set; }

        public virtual BeerFamily BeerFamily { get; set; }
        public virtual ICollection<Beer> Beer { get; set; }
    }
}
