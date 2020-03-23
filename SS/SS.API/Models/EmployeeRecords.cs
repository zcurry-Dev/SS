using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class EmployeeRecords
    {
        public int EmployeeRecordId { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeTitleId { get; set; }
        public DateTime HireDate { get; set; }
        public int EmploymentStatusId { get; set; }
        public bool Terminated { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual EmployeeTitles EmployeeTitle { get; set; }
        public virtual EmploymentStatuses EmploymentStatus { get; set; }
    }
}
