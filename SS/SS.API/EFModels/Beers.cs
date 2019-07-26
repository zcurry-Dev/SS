using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class Beers
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int BeerTypeId { get; set; }

        public BeerTypes BeerType { get; set; }
    }
}
