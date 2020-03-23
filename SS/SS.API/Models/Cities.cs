using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Addresses = new HashSet<Addresses>();
            ZipCodes = new HashSet<ZipCodes>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public virtual States State { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<ZipCodes> ZipCodes { get; set; }
    }
}
