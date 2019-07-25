using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Artists
    {
        public Artists()
        {
            ArtistTypeXref = new HashSet<ArtistTypeXref>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int? ArtistStatusId { get; set; }
        public DateTime CareerBeginDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public ArtistStatuses ArtistStatus { get; set; }
        public ICollection<ArtistTypeXref> ArtistTypeXref { get; set; }
    }
}
