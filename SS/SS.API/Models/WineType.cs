using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class WineType
    {
        public WineType()
        {
            Wine = new HashSet<Wine>();
        }

        public int WineTypeId { get; set; }
        public string WineType1 { get; set; }
        public int WineFamilyId { get; set; }

        public virtual WineFamily WineFamily { get; set; }
        public virtual ICollection<Wine> Wine { get; set; }
    }
}
