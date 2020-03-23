using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class ZipCodes
    {
        public ZipCodes()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int ZipCodeId { get; set; }
        public int ZipCode { get; set; }
        public int CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
