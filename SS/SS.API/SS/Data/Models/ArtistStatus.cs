using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class ArtistStatus
    {
        public ArtistStatus()
        {
            Artist = new HashSet<Artist>();
        }

        public int ArtistStatusId { get; set; }
        public string ArtistStatus1 { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Artist> Artist { get; set; }
    }
}
