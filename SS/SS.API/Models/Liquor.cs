using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Liquor
    {
        public int LiquorId { get; set; }
        public string LiquorName { get; set; }
        public int LiquorTypeId { get; set; }
        public int? AmericanWhiskeyTypeId { get; set; }
        public int? ScotchWhiskeyTypeId { get; set; }
        public int? DistilleryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual AmericanWhiskeyType AmericanWhiskeyType { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Distillery Distillery { get; set; }
        public virtual LiquorType LiquorType { get; set; }
        public virtual ScotchWhiskeyType ScotchWhiskeyType { get; set; }
    }
}
