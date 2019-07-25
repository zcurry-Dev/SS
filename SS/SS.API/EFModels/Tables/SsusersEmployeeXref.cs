using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class SsusersEmployeeXref
    {
        public int SsusersEmployeeXrefId { get; set; }
        public int SsuserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? Zapped { get; set; }

        public Ssusers Ssuser { get; set; }
    }
}
