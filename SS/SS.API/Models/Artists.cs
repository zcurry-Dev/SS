using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Artists
    {
        public Artists()
        {
            ArtistTypeXref = new HashSet<ArtistTypeXref>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ArtistTypeXref> ArtistTypeXref { get; set; }
    }
}
