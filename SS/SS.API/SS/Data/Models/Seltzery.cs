using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Seltzery
    {
        public int SeltzeryId { get; set; }
        public string SeltzeryName { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
