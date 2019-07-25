using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Ssevents
    {
        public int SsEventId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? EventTime { get; set; }
        public int? EventVenueId { get; set; }
        public DateTime CreatedDate { get; set; }

        public SseventTypes EventType { get; set; }
        public Venues EventVenue { get; set; }
    }
}
