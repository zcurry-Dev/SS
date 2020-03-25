using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Seltzer
    {
        public Seltzer()
        {
            InverseSeltzery = new HashSet<Seltzer>();
        }

        public int SeltzerId { get; set; }
        public string SeltzerName { get; set; }
        public int SeltzerFlavorId { get; set; }
        public int? SeltzeryId { get; set; }
        public int? BreweryId { get; set; }
        public int? CideryId { get; set; }
        public int? MeaderyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Brewery Brewery { get; set; }
        public virtual Cidery Cidery { get; set; }
        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual Meadery Meadery { get; set; }
        public virtual SeltzerFlavor SeltzerFlavor { get; set; }
        public virtual Seltzer Seltzery { get; set; }
        public virtual ICollection<Seltzer> InverseSeltzery { get; set; }
    }
}
