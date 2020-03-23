using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class VenueHoursOpen
    {
        public int VenueHoursOpenId { get; set; }
        public int VenueId { get; set; }
        public int DayOfWeekId { get; set; }
        public TimeSpan HourOpen { get; set; }
        public TimeSpan HourClose { get; set; }

        public virtual DaysOfWeek DayOfWeek { get; set; }
        public virtual Venues Venue { get; set; }
    }
}
