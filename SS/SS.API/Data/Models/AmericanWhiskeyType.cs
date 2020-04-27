using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class AmericanWhiskeyType
    {
        public AmericanWhiskeyType()
        {
            Liquor = new HashSet<Liquor>();
        }

        public int AmericanWhiskeyTypeId { get; set; }
        public string AmericanWhiskeyType1 { get; set; }

        public virtual ICollection<Liquor> Liquor { get; set; }
    }
}
