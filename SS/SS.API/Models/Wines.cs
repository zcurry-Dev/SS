﻿using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Wines
    {
        public int WineId { get; set; }
        public string WineName { get; set; }
        public int WineTypeId { get; set; }

        public virtual WineTypes WineType { get; set; }
    }
}
