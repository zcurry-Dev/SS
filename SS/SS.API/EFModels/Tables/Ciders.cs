using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
{
    public partial class Ciders
    {
        public int CiderId { get; set; }
        public string CiderName { get; set; }
        public int CiderTypeId { get; set; }

        public CiderTypes CiderType { get; set; }
    }
}
