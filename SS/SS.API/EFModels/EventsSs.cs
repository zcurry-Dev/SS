using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class EventsSs
    {
        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? EventTime { get; set; }
        public int? EventVenueId { get; set; }
        public DateTime CreatedDate { get; set; }

        public EventTypesSs EventType { get; set; }
        public Venues EventVenue { get; set; }
    }
}
