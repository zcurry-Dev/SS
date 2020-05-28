using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Cidery
    {
        public Cidery()
        {
            Cider = new HashSet<Cider>();
            Seltzer = new HashSet<Seltzer>();
        }

        public int CideryId { get; set; }
        public string CideryName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssaddress Address { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Cider> Cider { get; set; }
        public virtual ICollection<Seltzer> Seltzer { get; set; }
    }
}
