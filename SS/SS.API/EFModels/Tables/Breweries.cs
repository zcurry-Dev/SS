using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Breweries
    {
        public int BreweryId { get; set; }
        public string BreweryName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public Addresses Address { get; set; }
        public Venues Venue { get; set; }
    }
}
