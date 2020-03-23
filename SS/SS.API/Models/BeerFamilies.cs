﻿using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class BeerFamilies
    {
        public BeerFamilies()
        {
            BeerTypes = new HashSet<BeerTypes>();
        }

        public int BeerFamilyId { get; set; }
        public string BeerFamily { get; set; }

        public virtual ICollection<BeerTypes> BeerTypes { get; set; }
    }
}
