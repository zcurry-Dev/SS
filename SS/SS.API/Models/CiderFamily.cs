using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class CiderFamily
    {
        public CiderFamily()
        {
            CiderType = new HashSet<CiderType>();
        }

        public int CiderFamilyId { get; set; }
        public string CiderFamily1 { get; set; }

        public virtual ICollection<CiderType> CiderType { get; set; }
    }
}
