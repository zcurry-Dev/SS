using System;
using System.Collections.Generic;

namespace SS.API.Models
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
        public bool Solo { get; set; }
        public int? UserId { get; set; }
        public bool Verified { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ArtistStatus ArtistStatus { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Ssuser User { get; set; }
        public virtual ICollection<ArtistPhoto> ArtistPhoto { get; set; }
        public virtual ICollection<ArtistTypeXref> ArtistTypeXref { get; set; }
    }
}
