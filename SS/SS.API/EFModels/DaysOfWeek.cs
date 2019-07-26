using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class DaysOfWeek
    {
        public DaysOfWeek()
        {
            VenueHoursOpen = new HashSet<VenueHoursOpen>();
        }

        public int DayOfWeekId { get; set; }
        public string DayOfWeekName { get; set; }

        public ICollection<VenueHoursOpen> VenueHoursOpen { get; set; }
    }
}
