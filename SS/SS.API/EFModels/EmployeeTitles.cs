using System;
using System.Collections.Generic;

namespace SS.API.EFModels
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

        public ICollection<EmployeeRecords> EmployeeRecords { get; set; }
    }
}
