using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class MeadType
    {
        public MeadType()
        {
            Mead = new HashSet<Mead>();
        }

        public int MeadTypeId { get; set; }
        public string MeadType1 { get; set; }
        public int MeadFamilyId { get; set; }

        public virtual MeadFamily MeadFamily { get; set; }
        public virtual ICollection<Mead> Mead { get; set; }
    }
}
