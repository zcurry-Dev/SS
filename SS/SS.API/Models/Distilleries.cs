﻿using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Distilleries
    {
        public int DistilleryId { get; set; }
        public string DistilleryName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Venues Venue { get; set; }
    }
}