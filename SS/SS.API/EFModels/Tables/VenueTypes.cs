using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class VenueTypes
    {
        public VenueTypes()
        {
            VenueTypeXref = new HashSet<VenueTypeXref>();
        }

        public int VenueTypeId { get; set; }
        public string VenueType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Employees CreatedByNavigation { get; set; }
        public ICollection<VenueTypeXref> VenueTypeXref { get; set; }
    }
}
