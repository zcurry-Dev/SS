using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class CiderType
    {
        public CiderType()
        {
            Cider = new HashSet<Cider>();
        }

        public int CiderTypeId { get; set; }
        public string CiderType1 { get; set; }

        public virtual ICollection<Cider> Cider { get; set; }
    }
}
