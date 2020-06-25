using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            ArtistCurrentCountry = new HashSet<Artist>();
            ArtistHomeCountry = new HashSet<Artist>();
            WorldRegion = new HashSet<WorldRegion>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryNameShorter { get; set; }
        public string CountryAbbreviation2 { get; set; }
        public string CountryAbbreviation3 { get; set; }
        public string Iso3166 { get; set; }

        public virtual ICollection<Artist> ArtistCurrentCountry { get; set; }
        public virtual ICollection<Artist> ArtistHomeCountry { get; set; }
        public virtual ICollection<WorldRegion> WorldRegion { get; set; }
    }
}
