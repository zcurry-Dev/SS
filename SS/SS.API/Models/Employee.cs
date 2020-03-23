using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ArtistStatus = new HashSet<ArtistStatus>();
            ArtistType = new HashSet<ArtistType>();
            EmployeeRecord = new HashSet<EmployeeRecord>();
            EventType = new HashSet<EventType>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ArtistStatus> ArtistStatus { get; set; }
        public virtual ICollection<ArtistType> ArtistType { get; set; }
        public virtual ICollection<EmployeeRecord> EmployeeRecord { get; set; }
        public virtual ICollection<EventType> EventType { get; set; }
    }
}
