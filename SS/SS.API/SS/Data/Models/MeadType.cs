using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class MeadType
    {
        public MeadType()
        {
            Mead = new HashSet<Mead>();
        }

        public int MeadTypeId { get; set; }
        public string MeadType1 { get; set; }

        public virtual ICollection<Mead> Mead { get; set; }
    }
}
