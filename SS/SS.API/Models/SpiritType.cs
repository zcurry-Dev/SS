using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SpiritType
    {
        public SpiritType()
        {
            Spirit = new HashSet<Spirit>();
        }

        public int SpiritTypeId { get; set; }
        public string SpiritType1 { get; set; }
        public int SpiritFamilyId { get; set; }

        public virtual SpiritFamily SpiritFamily { get; set; }
        public virtual ICollection<Spirit> Spirit { get; set; }
    }
}
