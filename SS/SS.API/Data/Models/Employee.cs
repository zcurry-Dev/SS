using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeRecord = new HashSet<EmployeeRecord>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<EmployeeRecord> EmployeeRecord { get; set; }
    }
}
