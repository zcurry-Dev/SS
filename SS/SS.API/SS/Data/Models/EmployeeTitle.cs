using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class EmployeeTitle
    {
        public EmployeeTitle()
        {
            EmployeeRecord = new HashSet<EmployeeRecord>();
        }

        public int EmployeeTitleId { get; set; }
        public string EmployeeTitle1 { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<EmployeeRecord> EmployeeRecord { get; set; }
    }
}
