using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Mead
    {
        public int MeadId { get; set; }
        public string MeadName { get; set; }
        public int MeadTypeId { get; set; }
        public bool? HoneyWine { get; set; }

        public virtual MeadType MeadType { get; set; }
    }
}
