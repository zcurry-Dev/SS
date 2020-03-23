using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class SpiritFamiles
    {
        public SpiritFamiles()
        {
            SpiritTypes = new HashSet<SpiritTypes>();
        }

        public int SpiritFamilyId { get; set; }
        public string SpiritFamily { get; set; }

        public virtual ICollection<SpiritTypes> SpiritTypes { get; set; }
    }
}
