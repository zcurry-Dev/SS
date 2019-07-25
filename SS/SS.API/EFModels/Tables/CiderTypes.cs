using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
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

        public CiderFamilies CiderFamily { get; set; }
        public ICollection<Ciders> Ciders { get; set; }
    }
}
