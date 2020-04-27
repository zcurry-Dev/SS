using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class ZipCode
    {
        public ZipCode()
        {
            Ssaddress = new HashSet<Ssaddress>();
        }

        public int ZipCodeId { get; set; }
        public int ZipCode1 { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Ssaddress> Ssaddress { get; set; }
    }
}
