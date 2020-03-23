﻿using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Meaderies
    {
        public int MeaderyId { get; set; }
        public string MeaderyName { get; set; }
        public int AddressId { get; set; }
        public int VenueId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Venues Venue { get; set; }
    }
}