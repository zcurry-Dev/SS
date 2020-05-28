using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Brewery
    {
        public Brewery()
        {
            Beer = new HashSet<Beer>();
            Seltzer = new HashSet<Seltzer>();
        }

        public int BreweryId { get; set; }
        public string BreweryName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssaddress Address { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Beer> Beer { get; set; }
        public virtual ICollection<Seltzer> Seltzer { get; set; }
    }
}
