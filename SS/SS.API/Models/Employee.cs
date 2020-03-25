using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeRecord = new HashSet<EmployeeRecord>();
            UserEmployeeXref = new HashSet<UserEmployeeXref>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<EmployeeRecord> EmployeeRecord { get; set; }
        public virtual ICollection<UserEmployeeXref> UserEmployeeXref { get; set; }
    }
}
