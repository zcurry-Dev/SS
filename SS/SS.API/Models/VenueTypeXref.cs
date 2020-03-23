using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class VenueTypeXref
    {
        public int VenueTypeXrefId { get; set; }
        public int VenueId { get; set; }
        public int VenueTypeId { get; set; }
        public bool MainType { get; set; }

        public virtual Venues Venue { get; set; }
        public virtual VenueTypes VenueType { get; set; }
    }
}
