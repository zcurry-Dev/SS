using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class BeerFamilies
    {
        public BeerFamilies()
        {
            BeerTypes = new HashSet<BeerTypes>();
        }

        public int BeerFamilyId { get; set; }
        public string BeerFamily { get; set; }

        public ICollection<BeerTypes> BeerTypes { get; set; }
    }
}
