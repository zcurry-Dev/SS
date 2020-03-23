using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Venues
    {
        public Venues()
        {
            Breweries = new HashSet<Breweries>();
            Cideries = new HashSet<Cideries>();
            Distilleries = new HashSet<Distilleries>();
            EventsSs = new HashSet<EventsSs>();
            Meaderies = new HashSet<Meaderies>();
            VenueHoursOpen = new HashSet<VenueHoursOpen>();
            VenueTypeXref = new HashSet<VenueTypeXref>();
            Wineries = new HashSet<Wineries>();
        }

        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public int VenueAddressId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual Addresses VenueAddress { get; set; }
        public virtual ICollection<Breweries> Breweries { get; set; }
        public virtual ICollection<Cideries> Cideries { get; set; }
        public virtual ICollection<Distilleries> Distilleries { get; set; }
        public virtual ICollection<EventsSs> EventsSs { get; set; }
        public virtual ICollection<Meaderies> Meaderies { get; set; }
        public virtual ICollection<VenueHoursOpen> VenueHoursOpen { get; set; }
        public virtual ICollection<VenueTypeXref> VenueTypeXref { get; set; }
        public virtual ICollection<Wineries> Wineries { get; set; }
    }
}
