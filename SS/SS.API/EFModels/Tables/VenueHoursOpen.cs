using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class VenueHoursOpen
    {
        public int VenueHoursOpenId { get; set; }
        public int VenueId { get; set; }
        public int SsDayId { get; set; }
        public TimeSpan HourOpen { get; set; }
        public TimeSpan HourClose { get; set; }

        public SsDays SsDay { get; set; }
        public Venues Venue { get; set; }
    }
}
