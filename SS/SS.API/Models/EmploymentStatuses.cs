using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class EmploymentStatuses
    {
        public EmploymentStatuses()
        {
            EmployeeRecords = new HashSet<EmployeeRecords>();
        }

        public int EmploymentStatusId { get; set; }
        public string EmploymentStatus { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<EmployeeRecords> EmployeeRecords { get; set; }
    }
}
