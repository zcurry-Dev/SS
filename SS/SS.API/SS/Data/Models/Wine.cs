using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class Wine
    {
        public int WineId { get; set; }
        public string WineName { get; set; }
        public int WineTypeId { get; set; }
        public int WineryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Ssuser CreatedByNavigation { get; set; }
        public virtual WineType WineType { get; set; }
        public virtual Winery Winery { get; set; }
    }
}
