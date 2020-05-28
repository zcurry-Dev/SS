using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Ssevent
    {
        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? EventTime { get; set; }
        public int? EventVenueId { get; set; }
        public bool Fundraiser { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual Venue EventVenue { get; set; }
    }
}
