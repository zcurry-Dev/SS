using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class UserEmployeeXref
    {
        public int UserEmployeeXrefId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? Zapped { get; set; }

        public virtual Ssuser User { get; set; }
    }
}
