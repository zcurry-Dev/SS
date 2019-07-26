using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class MeadTypes
    {
        public MeadTypes()
        {
            Meads = new HashSet<Meads>();
        }

        public int MeadTypeId { get; set; }
        public string MeadType { get; set; }
        public int MeadFamilyId { get; set; }

        public MeadFamilies MeadFamily { get; set; }
        public ICollection<Meads> Meads { get; set; }
    }
}
