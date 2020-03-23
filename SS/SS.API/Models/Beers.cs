using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Beers
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int BeerTypeId { get; set; }

        public virtual BeerTypes BeerType { get; set; }
    }
}
