using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class LiquorType
    {
        public LiquorType()
        {
            Liquor = new HashSet<Liquor>();
        }

        public int LiquorTypeId { get; set; }
        public string LiquorType1 { get; set; }
        public int LiquorFamilyId { get; set; }

        public virtual LiquorFamily LiquorFamily { get; set; }
        public virtual ICollection<Liquor> Liquor { get; set; }
    }
}
