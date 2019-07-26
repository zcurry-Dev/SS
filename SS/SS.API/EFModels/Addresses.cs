using System;
using System.Collections.Generic;

namespace SS.API.EFModels
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
        public int ZipCode { get; set; }
        public int StateId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Cities City { get; set; }
        public States State { get; set; }
        public ZipCodes ZipCodeNavigation { get; set; }
        public ICollection<Breweries> Breweries { get; set; }
        public ICollection<Cideries> Cideries { get; set; }
        public ICollection<Distilleries> Distilleries { get; set; }
        public ICollection<Meaderies> Meaderies { get; set; }
        public ICollection<Venues> Venues { get; set; }
        public ICollection<Wineries> Wineries { get; set; }
    }
}
