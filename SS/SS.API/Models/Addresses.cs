using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            Breweries = new HashSet<Breweries>();
            Cideries = new HashSet<Cideries>();
            Distilleries = new HashSet<Distilleries>();
            Meaderies = new HashSet<Meaderies>();
            Venues = new HashSet<Venues>();
            Wineries = new HashSet<Wineries>();
        }

        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public int CityId { get; set; }
        public int ZipCodeId { get; set; }
        public int StateId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Cities City { get; set; }
        public virtual States State { get; set; }
        public virtual ZipCodes ZipCode { get; set; }
        public virtual ICollection<Breweries> Breweries { get; set; }
        public virtual ICollection<Cideries> Cideries { get; set; }
        public virtual ICollection<Distilleries> Distilleries { get; set; }
        public virtual ICollection<Meaderies> Meaderies { get; set; }
        public virtual ICollection<Venues> Venues { get; set; }
        public virtual ICollection<Wineries> Wineries { get; set; }
    }
}
