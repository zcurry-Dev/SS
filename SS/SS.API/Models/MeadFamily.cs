using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class MeadFamily
    {
        public MeadFamily()
        {
            MeadType = new HashSet<MeadType>();
        }

        public int MeadFamilyId { get; set; }
        public string MeadFamily1 { get; set; }

        public virtual ICollection<MeadType> MeadType { get; set; }
    }
}
