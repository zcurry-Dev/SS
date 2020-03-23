using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class CiderTypes
    {
        public CiderTypes()
        {
            Ciders = new HashSet<Ciders>();
        }

        public int CiderTypeId { get; set; }
        public string CiderType { get; set; }
        public int CiderFamilyId { get; set; }

        public virtual CiderFamilies CiderFamily { get; set; }
        public virtual ICollection<Ciders> Ciders { get; set; }
    }
}
