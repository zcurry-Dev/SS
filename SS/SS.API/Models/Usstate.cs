using System;
using System.Collections.Generic;

namespace SS.API.Models
{
    public partial class Usstate
    {
        public Usstate()
        {
            City = new HashSet<City>();
            Ssaddress = new HashSet<Ssaddress>();
        }

        public int StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Ssaddress> Ssaddress { get; set; }
    }
}
