using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class CiderFamilies
    {
        public CiderFamilies()
        {
            CiderTypes = new HashSet<CiderTypes>();
        }

        public int CiderFamilyId { get; set; }
        public string CiderFamily { get; set; }

        public ICollection<CiderTypes> CiderTypes { get; set; }
    }
}
