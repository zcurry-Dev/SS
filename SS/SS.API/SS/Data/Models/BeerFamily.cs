using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class BeerFamily
    {
        public BeerFamily()
        {
            BeerType = new HashSet<BeerType>();
        }

        public int BeerFamilyId { get; set; }
        public string BeerFamily1 { get; set; }

        public virtual ICollection<BeerType> BeerType { get; set; }
    }
}
