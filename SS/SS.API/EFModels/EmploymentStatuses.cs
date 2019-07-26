using System;
using System.Collections.Generic;

namespace SS.API.EFModels
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

        public ICollection<EmployeeRecords> EmployeeRecords { get; set; }
    }
}
