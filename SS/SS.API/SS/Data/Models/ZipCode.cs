using System;
using System.Collections.Generic;

namespace SS.Data.Models
{
    public partial class ZipCode
    {
        public ZipCode()
        {
            Artist = new HashSet<Artist>();
            Ssaddress = new HashSet<Ssaddress>();
        }

        public int ZipCodeId { get; set; }
        public string Digits { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Artist> Artist { get; set; }
        public virtual ICollection<Ssaddress> Ssaddress { get; set; }
    }
}
