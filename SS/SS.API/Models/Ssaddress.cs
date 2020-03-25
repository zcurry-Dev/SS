using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Ssaddress
    {
        public Ssaddress()
        {
            Brewery = new HashSet<Brewery>();
            Cidery = new HashSet<Cidery>();
            Distillery = new HashSet<Distillery>();
            Meadery = new HashSet<Meadery>();
            Venue = new HashSet<Venue>();
            Winery = new HashSet<Winery>();
        }

        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public int CityId { get; set; }
        public int ZipCodeId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual City City { get; set; }
        public virtual ZipCode ZipCode { get; set; }
        public virtual ICollection<Brewery> Brewery { get; set; }
        public virtual ICollection<Cidery> Cidery { get; set; }
        public virtual ICollection<Distillery> Distillery { get; set; }
        public virtual ICollection<Meadery> Meadery { get; set; }
        public virtual ICollection<Venue> Venue { get; set; }
        public virtual ICollection<Winery> Winery { get; set; }
    }
}
