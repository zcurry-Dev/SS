using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class BeerTypeSpecific
    {
        public BeerTypeSpecific()
        {
            Beer = new HashSet<Beer>();
        }

        public int BeerTypeSpecificId { get; set; }
        public string BeerTypeSpecific1 { get; set; }
        public int BeerTypeId { get; set; }

        public virtual BeerType BeerType { get; set; }
        public virtual ICollection<Beer> Beer { get; set; }
    }
}
