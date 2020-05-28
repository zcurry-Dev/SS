using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Meadery
    {
        public Meadery()
        {
            Mead = new HashSet<Mead>();
            Seltzer = new HashSet<Seltzer>();
        }

        public int MeaderyId { get; set; }
        public string MeaderyName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Ssaddress Address { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Mead> Mead { get; set; }
        public virtual ICollection<Seltzer> Seltzer { get; set; }
    }
}
