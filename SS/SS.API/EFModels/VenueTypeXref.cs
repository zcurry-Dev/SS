using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class VenueTypeXref
    {
        public int VenueTypeXrefId { get; set; }
        public int VenueId { get; set; }
        public int VenueTypeId { get; set; }
        public bool MainType { get; set; }

        public Venues Venue { get; set; }
        public VenueTypes VenueType { get; set; }
    }
}
