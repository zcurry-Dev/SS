using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Spirits
    {
        public int SpiritId { get; set; }
        public string SpiritName { get; set; }
        public int SpiritTypeId { get; set; }

        public SpiritTypes SpiritType { get; set; }
    }
}
