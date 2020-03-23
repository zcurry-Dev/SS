using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Spirit
    {
        public int SpiritId { get; set; }
        public string SpiritName { get; set; }
        public int SpiritTypeId { get; set; }

        public virtual SpiritType SpiritType { get; set; }
    }
}
