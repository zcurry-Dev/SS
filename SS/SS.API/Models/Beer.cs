using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Beer
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int BeerTypeId { get; set; }

        public virtual BeerType BeerType { get; set; }
    }
}
