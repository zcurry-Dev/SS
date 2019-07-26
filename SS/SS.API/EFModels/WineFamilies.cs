using System;
using System.Collections.Generic;

namespace SS.API.EFModels
{
    public partial class WineFamilies
    {
        public WineFamilies()
        {
            WineTypes = new HashSet<WineTypes>();
        }

        public int WineFamilyId { get; set; }
        public string WineFamily { get; set; }

        public ICollection<WineTypes> WineTypes { get; set; }
    }
}
