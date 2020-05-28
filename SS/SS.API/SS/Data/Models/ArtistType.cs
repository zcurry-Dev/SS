using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class ArtistType
    {
        public ArtistType()
        {
            ArtistGroupMember = new HashSet<ArtistGroupMember>();
            ArtistTypeXref = new HashSet<ArtistTypeXref>();
        }

        public int ArtistTypeId { get; set; }
        public string ArtistType1 { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ArtistGroupMember> ArtistGroupMember { get; set; }
        public virtual ICollection<ArtistTypeXref> ArtistTypeXref { get; set; }
    }
}
