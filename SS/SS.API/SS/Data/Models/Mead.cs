using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Mead
    {
        public int MeadId { get; set; }
        public string MeadName { get; set; }
        public int MeadTypeId { get; set; }
        public bool? HoneyWine { get; set; }
        public int MeaderyId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual MeadType MeadType { get; set; }
        public virtual Meadery Meadery { get; set; }
    }
}
