using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Beer
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int BeerTypeSpecificId { get; set; }
        public int BreweryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual BeerTypeSpecific BeerTypeSpecific { get; set; }
        public virtual Brewery Brewery { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
    }
}
