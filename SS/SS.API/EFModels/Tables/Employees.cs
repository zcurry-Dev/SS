using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Employees
    {
        public Employees()
        {
            ArtistGroupMemberRoles = new HashSet<ArtistGroupMemberRoles>();
            ArtistStatuses = new HashSet<ArtistStatuses>();
            ArtistTypes = new HashSet<ArtistTypes>();
            EmployeeRecords = new HashSet<EmployeeRecords>();
            SseventTypes = new HashSet<SseventTypes>();
            VenueTypes = new HashSet<VenueTypes>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ArtistGroupMemberRoles> ArtistGroupMemberRoles { get; set; }
        public ICollection<ArtistStatuses> ArtistStatuses { get; set; }
        public ICollection<ArtistTypes> ArtistTypes { get; set; }
        public ICollection<EmployeeRecords> EmployeeRecords { get; set; }
        public ICollection<SseventTypes> SseventTypes { get; set; }
        public ICollection<VenueTypes> VenueTypes { get; set; }
    }
}
