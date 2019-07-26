using System;
using System.Collections.Generic;

namespace SS.API.EFModels
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

        public Users CreatedByNavigation { get; set; }
        public Addresses VenueAddress { get; set; }
        public ICollection<Breweries> Breweries { get; set; }
        public ICollection<Cideries> Cideries { get; set; }
        public ICollection<Distilleries> Distilleries { get; set; }
        public ICollection<EventsSs> EventsSs { get; set; }
        public ICollection<Meaderies> Meaderies { get; set; }
        public ICollection<VenueHoursOpen> VenueHoursOpen { get; set; }
        public ICollection<VenueTypeXref> VenueTypeXref { get; set; }
        public ICollection<Wineries> Wineries { get; set; }
    }
}
