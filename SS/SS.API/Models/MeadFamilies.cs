using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class MeadFamilies
    {
        public MeadFamilies()
        {
            MeadTypes = new HashSet<MeadTypes>();
        }

        public int MeadFamilyId { get; set; }
        public string MeadFamily { get; set; }

        public virtual ICollection<MeadTypes> MeadTypes { get; set; }
    }
}
