using System;
using System.Collections.Generic;

namespace SS.Data.Models
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
        public int HomeCountryId { get; set; }
        public int? HomeUscityId { get; set; }
        public int? HomeWorldCityId { get; set; }
        public int CurrentCountryId { get; set; }
        public int? CurrentUscityId { get; set; }
        public int? CurrentWorldCityId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ArtistStatus ArtistStatus { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Country CurrentCountry { get; set; }
        public virtual City CurrentUscity { get; set; }
        public virtual WorldCity CurrentWorldCity { get; set; }
        public virtual Country HomeCountry { get; set; }
        public virtual City HomeUscity { get; set; }
        public virtual WorldCity HomeWorldCity { get; set; }
        public virtual Ssuser User { get; set; }
        public virtual ICollection<ArtistPhoto> ArtistPhoto { get; set; }
        public virtual ICollection<ArtistTypeXref> ArtistTypeXref { get; set; }
    }
}
