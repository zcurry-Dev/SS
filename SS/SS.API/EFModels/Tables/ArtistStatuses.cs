using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class ArtistStatuses
    {
        public ArtistStatuses()
        {
            Artists = new HashSet<Artists>();
        }

        public int ArtistStatusId { get; set; }
        public string ArtistStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Employees CreatedByNavigation { get; set; }
        public ICollection<Artists> Artists { get; set; }
    }
}
