using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class ArtistStatuses
    {
        public int ArtistStatusId { get; set; }
        public string ArtistStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employees CreatedByNavigation { get; set; }
    }
}
