using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class EmployeeRecord
    {
        public int EmployeeRecordId { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeTitleId { get; set; }
        public DateTime HireDate { get; set; }
        public int EmploymentStatusId { get; set; }
        public bool Terminated { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EmployeeTitle EmployeeTitle { get; set; }
        public virtual EmploymentStatus EmploymentStatus { get; set; }
    }
}
