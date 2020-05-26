using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class ScotchWhiskeyType
    {
        public ScotchWhiskeyType()
        {
            Liquor = new HashSet<Liquor>();
        }

        public int ScotchWhiskeyTypeId { get; set; }
        public string ScotchWhiskeyType1 { get; set; }

        public virtual ICollection<Liquor> Liquor { get; set; }
    }
}
