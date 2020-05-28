using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Cider
    {
        public int CiderId { get; set; }
        public string CiderName { get; set; }
        public int CiderTypeId { get; set; }
        public int CiderFlavorId { get; set; }
        public int CideryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual CiderFlavor CiderFlavor { get; set; }
        public virtual CiderType CiderType { get; set; }
        public virtual Cidery Cidery { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
    }
}
