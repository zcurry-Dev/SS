using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class ArtistStatuses
    {
        public int ArtistStatusId { get; set; }
        public string ArtistStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Employees CreatedByNavigation { get; set; }
    }
}
