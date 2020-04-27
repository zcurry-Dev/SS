using System;
using System.Collections.Generic;

namespace SS.API.Data.Models
{
    public partial class Usstate
    {
        public Usstate()
        {
            City = new HashSet<City>();
        }

        public int StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
