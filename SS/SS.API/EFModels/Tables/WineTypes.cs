using System;
using System.Collections.Generic;

namespace SS.API.EFModels.Tables
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

        public WineFamilies WineFamily { get; set; }
        public ICollection<Wines> Wines { get; set; }
    }
}
