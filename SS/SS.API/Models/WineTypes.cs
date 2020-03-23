using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class WineTypes
    {
        public WineTypes()
        {
            Wines = new HashSet<Wines>();
        }

        public int WineTypeId { get; set; }
        public string WineType { get; set; }
        public int WineFamilyId { get; set; }

        public virtual WineFamilies WineFamily { get; set; }
        public virtual ICollection<Wines> Wines { get; set; }
    }
}
