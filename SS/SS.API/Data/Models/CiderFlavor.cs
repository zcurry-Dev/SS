using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class CiderFlavor
    {
        public CiderFlavor()
        {
            Cider = new HashSet<Cider>();
        }

        public int CiderFlavorId { get; set; }
        public string CiderFlavor1 { get; set; }

        public virtual ICollection<Cider> Cider { get; set; }
    }
}
