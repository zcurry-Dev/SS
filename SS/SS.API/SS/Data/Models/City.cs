using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class City
    {
        public City()
        {
            ArtistCurrentCity = new HashSet<Artist>();
            ArtistUshomeCity = new HashSet<Artist>();
            InverseClosestMajorCity = new HashSet<City>();
            Ssaddress = new HashSet<Ssaddress>();
            ZipCode = new HashSet<ZipCode>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? ClosestMajorCityId { get; set; }
        public int StateId { get; set; }
        public bool MajorCity { get; set; }

        public virtual City ClosestMajorCity { get; set; }
        public virtual Usstate State { get; set; }
        public virtual ICollection<Artist> ArtistCurrentCity { get; set; }
        public virtual ICollection<Artist> ArtistUshomeCity { get; set; }
        public virtual ICollection<City> InverseClosestMajorCity { get; set; }
        public virtual ICollection<Ssaddress> Ssaddress { get; set; }
        public virtual ICollection<ZipCode> ZipCode { get; set; }
    }
}
