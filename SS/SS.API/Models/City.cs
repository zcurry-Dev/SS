using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class City
    {
        public City()
        {
            Ssaddress = new HashSet<Ssaddress>();
            ZipCode = new HashSet<ZipCode>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public virtual Usstate State { get; set; }
        public virtual ICollection<Ssaddress> Ssaddress { get; set; }
        public virtual ICollection<ZipCode> ZipCode { get; set; }
    }
}
