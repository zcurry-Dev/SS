using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Distillery
    {
        public Distillery()
        {
            Liquor = new HashSet<Liquor>();
        }

        public int DistilleryId { get; set; }
        public string DistilleryName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssaddress Address { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Liquor> Liquor { get; set; }
    }
}
