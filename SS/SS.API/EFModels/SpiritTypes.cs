using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class SpiritTypes
    {
        public SpiritTypes()
        {
            Spirits = new HashSet<Spirits>();
        }

        public int SpiritTypeId { get; set; }
        public string SpiritType { get; set; }
        public int SpiritFamilyId { get; set; }

        public SpiritFamiles SpiritFamily { get; set; }
        public ICollection<Spirits> Spirits { get; set; }
    }
}
