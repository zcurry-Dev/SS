using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class VenueType
    {
        public VenueType()
        {
            VenueTypeXref = new HashSet<VenueTypeXref>();
        }

        public int VenueTypeId { get; set; }
        public string VenueType1 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<VenueTypeXref> VenueTypeXref { get; set; }
    }
}
