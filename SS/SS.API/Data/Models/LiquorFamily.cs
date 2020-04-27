using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class LiquorFamily
    {
        public LiquorFamily()
        {
            LiquorType = new HashSet<LiquorType>();
        }

        public int LiquorFamilyId { get; set; }
        public string LiquorFamily1 { get; set; }

        public virtual ICollection<LiquorType> LiquorType { get; set; }
    }
}
