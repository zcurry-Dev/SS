using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class Wines
    {
        public int WineId { get; set; }
        public string WineName { get; set; }
        public int WineTypeId { get; set; }

        public WineTypes WineType { get; set; }
    }
}
