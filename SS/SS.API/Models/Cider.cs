using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Cider
    {
        public int CiderId { get; set; }
        public string CiderName { get; set; }
        public int CiderTypeId { get; set; }

        public virtual CiderType CiderType { get; set; }
    }
}
