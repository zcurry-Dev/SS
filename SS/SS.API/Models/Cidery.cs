using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Cidery
    {
        public int CideryId { get; set; }
        public string CideryName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Ssaddress Address { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
