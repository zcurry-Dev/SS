using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Winery
    {
        public Winery()
        {
            Wine = new HashSet<Wine>();
        }

        public int WineryId { get; set; }
        public string WineryName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool Vinyard { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssaddress Address { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Wine> Wine { get; set; }
    }
}
