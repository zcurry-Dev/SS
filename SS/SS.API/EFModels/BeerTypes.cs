using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class BeerTypes
    {
        public BeerTypes()
        {
            Beers = new HashSet<Beers>();
        }

        public int BeerTypeId { get; set; }
        public string BeerType { get; set; }
        public int BeerFamilyId { get; set; }

        public BeerFamilies BeerFamily { get; set; }
        public ICollection<Beers> Beers { get; set; }
    }
}
