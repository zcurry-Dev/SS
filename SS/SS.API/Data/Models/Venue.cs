using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Brewery = new HashSet<Brewery>();
            Cidery = new HashSet<Cidery>();
            Distillery = new HashSet<Distillery>();
            Meadery = new HashSet<Meadery>();
            Seltzery = new HashSet<Seltzery>();
            Ssevent = new HashSet<Ssevent>();
            VenueHoursOpen = new HashSet<VenueHoursOpen>();
            VenueTypeXref = new HashSet<VenueTypeXref>();
            Winery = new HashSet<Winery>();
        }

        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public int VenueAddressId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Ssaddress VenueAddress { get; set; }
        public virtual ICollection<Brewery> Brewery { get; set; }
        public virtual ICollection<Cidery> Cidery { get; set; }
        public virtual ICollection<Distillery> Distillery { get; set; }
        public virtual ICollection<Meadery> Meadery { get; set; }
        public virtual ICollection<Seltzery> Seltzery { get; set; }
        public virtual ICollection<Ssevent> Ssevent { get; set; }
        public virtual ICollection<VenueHoursOpen> VenueHoursOpen { get; set; }
        public virtual ICollection<VenueTypeXref> VenueTypeXref { get; set; }
        public virtual ICollection<Winery> Winery { get; set; }
    }
}
