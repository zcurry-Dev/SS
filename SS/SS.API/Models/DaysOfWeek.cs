using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class DaysOfWeek
    {
        public DaysOfWeek()
        {
            VenueHoursOpen = new HashSet<VenueHoursOpen>();
        }

        public int DayOfWeekId { get; set; }
        public string DayOfWeekName { get; set; }
        public string DayOfWeekAbbreviation { get; set; }
        public string DayOfWeekLetterAbbreviation { get; set; }
        public bool Weekend { get; set; }

        public virtual ICollection<VenueHoursOpen> VenueHoursOpen { get; set; }
    }
}
