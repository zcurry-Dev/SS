using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class SsDays
    {
        public SsDays()
        {
            VenueHoursOpen = new HashSet<VenueHoursOpen>();
        }

        public int SsDayId { get; set; }
        public string SsDay { get; set; }

        public ICollection<VenueHoursOpen> VenueHoursOpen { get; set; }
    }
}
