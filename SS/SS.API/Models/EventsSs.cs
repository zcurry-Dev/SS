using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class EventsSs
    {
        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? EventTime { get; set; }
        public int? EventVenueId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual EventTypesSs EventType { get; set; }
        public virtual Venues EventVenue { get; set; }
    }
}
