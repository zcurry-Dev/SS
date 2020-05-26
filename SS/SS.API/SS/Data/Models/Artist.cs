using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistPhoto = new HashSet<ArtistPhoto>();
            ArtistTypeXref = new HashSet<ArtistTypeXref>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int? ArtistStatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public bool ArtistGroup { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int HomeCountry { get; set; }
        public int? UshomeCity { get; set; }
        public int? WorldHomeCity { get; set; }
        public int? CurrentCity { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ArtistStatus ArtistStatus { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual City CurrentCityNavigation { get; set; }
        public virtual Country HomeCountryNavigation { get; set; }
        public virtual Ssuser User { get; set; }
        public virtual City UshomeCityNavigation { get; set; }
        public virtual WorldCity WorldHomeCityNavigation { get; set; }
        public virtual ICollection<ArtistPhoto> ArtistPhoto { get; set; }
        public virtual ICollection<ArtistTypeXref> ArtistTypeXref { get; set; }
    }
}
