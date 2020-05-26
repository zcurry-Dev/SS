using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class EmploymentStatus
    {
        public EmploymentStatus()
        {
            EmployeeRecord = new HashSet<EmployeeRecord>();
        }

        public int EmploymentStatusId { get; set; }
        public string EmploymentStatus1 { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<EmployeeRecord> EmployeeRecord { get; set; }
    }
}
