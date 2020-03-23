using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class CiderType
    {
        public CiderType()
        {
            Cider = new HashSet<Cider>();
        }

        public int CiderTypeId { get; set; }
        public string CiderType1 { get; set; }
        public int CiderFamilyId { get; set; }

        public virtual CiderFamily CiderFamily { get; set; }
        public virtual ICollection<Cider> Cider { get; set; }
    }
}
