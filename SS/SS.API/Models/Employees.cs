using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Employees
    {
        public Employees()
        {
            ArtistGroupMemberRoles = new HashSet<ArtistGroupMemberRoles>();
            ArtistStatuses = new HashSet<ArtistStatuses>();
            ArtistTypes = new HashSet<ArtistTypes>();
            EmployeeRecords = new HashSet<EmployeeRecords>();
            EventTypesSs = new HashSet<EventTypesSs>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ArtistGroupMemberRoles> ArtistGroupMemberRoles { get; set; }
        public virtual ICollection<ArtistStatuses> ArtistStatuses { get; set; }
        public virtual ICollection<ArtistTypes> ArtistTypes { get; set; }
        public virtual ICollection<EmployeeRecords> EmployeeRecords { get; set; }
        public virtual ICollection<EventTypesSs> EventTypesSs { get; set; }
    }
}
