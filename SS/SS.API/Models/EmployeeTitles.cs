using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class EmployeeTitles
    {
        public EmployeeTitles()
        {
            EmployeeRecords = new HashSet<EmployeeRecords>();
        }

        public int EmployeeTitleId { get; set; }
        public string EmployeeTitle { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<EmployeeRecords> EmployeeRecords { get; set; }
    }
}
