using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class WineTypeSpecific
    {
        public int WineTypeSpecificId { get; set; }
        public string WineTypeSpecific1 { get; set; }
        public int WineTypeId { get; set; }

        public virtual WineType WineType { get; set; }
    }
}
