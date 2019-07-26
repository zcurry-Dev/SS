using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class SpiritFamiles
    {
        public SpiritFamiles()
        {
            SpiritTypes = new HashSet<SpiritTypes>();
        }

        public int SpiritFamilyId { get; set; }
        public string SpiritFamily { get; set; }

        public ICollection<SpiritTypes> SpiritTypes { get; set; }
    }
}
