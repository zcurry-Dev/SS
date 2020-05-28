using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class WorldRegion
    {
        public WorldRegion()
        {
            WorldCity = new HashSet<WorldCity>();
        }

        public int WorldRegionId { get; set; }
        public int WorldRegionCountry { get; set; }
        public string WorldRegionAbbreviation { get; set; }
        public string WorldRegionName { get; set; }
        public string WorldRegionType { get; set; }

        public virtual Country WorldRegionCountryNavigation { get; set; }
        public virtual ICollection<WorldCity> WorldCity { get; set; }
    }
}
