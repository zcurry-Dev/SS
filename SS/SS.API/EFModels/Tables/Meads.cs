using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Meads
    {
        public int MeadId { get; set; }
        public string MeadName { get; set; }
        public int MeadTypeId { get; set; }
        public bool? HoneyWine { get; set; }

        public MeadTypes MeadType { get; set; }
    }
}
